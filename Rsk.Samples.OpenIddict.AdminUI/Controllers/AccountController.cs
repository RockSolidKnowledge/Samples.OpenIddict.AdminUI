using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityExpress.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Rsk.Samples.OpenIddict.AdminUiIntegration.Data;
using Rsk.Samples.OpenIddict.AdminUiIntegration.Models;
using Rsk.Samples.OpenIddict.AdminUiIntegration.Services;

namespace Rsk.Samples.OpenIddict.AdminUiIntegration.Controllers;

public class AccountController(
    SignInManager<ApplicationUser> signInManager,
    IAccountService accountService,
    IAuthenticationSchemeProvider schemeProvider,
    IUrlHelperFactory urlHelperFactory) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Login([FromQuery] string returnUrl)
    {
        bool externalLogin = Request.Cookies["Identity.External"] != null;
        
        var vm = !externalLogin ? await accountService.BuildLoginViewModelAsync(returnUrl)
            : accountService.BuildLinkLoginViewModel(returnUrl);
        
        return View(vm);
    }

    /// <summary>
    /// Handle postback from username/password login
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginInputModel model, string button)
    {
        if (button != "login")
        {
            if (Request.Cookies["Identity.External"] != null)
            {
                await HttpContext.SignOutAsync("Identity.External");
            }
            
            return Redirect(model.ReturnUrl);
        }
        
        if (ModelState.IsValid)
        {
            var user = await signInManager.UserManager.FindByNameAsync(model.Username);

            if (user != null && await signInManager.UserManager.CheckPasswordAsync(user, model.Password))
            {
                // only set explicit expiration here if user chooses "remember me". 
                // otherwise we rely upon expiration configured in cookie middleware.
                AuthenticationProperties props = null;
                if (model.RememberLogin)
                {
                    props = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.Add(TimeSpan.FromDays(30))
                    };
                }
                
                // issue authentication cookie with subject ID and username
                await signInManager.SignInAsync(user, props);

                // link external login if cookie exists
                await LinkIfExternalLogin(user);

                // make sure the returnUrl is still valid, and if so redirect back to authorize endpoint or a local page
                if (!Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                return Redirect("~/");
            }

            ModelState.AddModelError("", "Invalid username or password");
        }
        
        // something went wrong, show form with error
        var vm = await accountService.BuildLoginViewModelAsync(model);
        vm.LinkSetup = Request.Cookies["Identity.External"] != null;
        return View(model);
    }
    
    [HttpGet]
    public IActionResult Logout()
    {
        return View(new LogoutViewModel());
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout(LogoutInputModel model)
    {
        var user = HttpContext.User;
        if (user?.Identity.IsAuthenticated == true)
        {
            await signInManager.SignOutAsync();
        }

        return View("LoggedOut");
    }

    /// <summary>
    /// initiate roundtrip to external authentication provider
    /// </summary>
    [HttpGet]
    public IActionResult ExternalLogin(string provider, string returnUrl)
    {
        var urlHelper = urlHelperFactory.GetUrlHelper(ControllerContext);
        var props = new AuthenticationProperties
        {
            RedirectUri = urlHelper.Action("ExternalLoginCallback"),
            Items =
            {
                { "returnUrl", returnUrl }
            }
        };

        // challenge specific authentication middleware
        props.Items.Add("scheme", provider);
        return Challenge(props, provider);
    }
    
    /// <summary>
    /// Post processing of external authentication
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> ExternalLoginCallback()
    {
        // get external identity from external scheme cookie
        var result = await HttpContext.AuthenticateAsync("Identity.External");
        if (result?.Succeeded != true) throw new Exception("External authentication error");

        var externalUser = result.Principal;
        var claims = externalUser.Claims.ToList();

        // try to determine the unique id of the external user
        var userIdClaim = claims.FirstOrDefault(x => x.Type == "sub") ?? claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        if (userIdClaim == null) throw new Exception("Unknown userid");

        claims.Remove(userIdClaim);
        var userId = userIdClaim.Value;
        var provider = result.Properties.Items["scheme"];
        
        var returnUrl = result.Properties.Items["returnUrl"];
        
        if (!Url.IsLocalUrl(returnUrl))
        {
            returnUrl = "~/";
        }

        // check if the external user is already provisioned
        ApplicationUser user = await signInManager.UserManager.FindByLoginAsync(provider, userId);

        if (user == null)
        {
            return RedirectToAction("Login", new { returnUrl });
        }

        var additionalClaims = new List<IdentityExpressClaim>();

        // if the external system sent a session id claim, copy it over
        var sid = claims.FirstOrDefault(x => x.Type == "sid");
        if (sid != null) additionalClaims.Add(new IdentityExpressClaim(){ClaimType = "sid", ClaimValue = sid.Value});

        // if the external provider issued an id_token, we'll keep it for signout
        AuthenticationProperties props = null;
        var idToken = result.Properties.GetTokenValue("id_token");
        if (idToken != null)
        {
            props = new AuthenticationProperties();
            props.StoreTokens(new[] { new AuthenticationToken { Name = "id_token", Value = idToken } });
        }
        
        // issue local authentication cookie for user
        await signInManager.SignInAsync(user, props);

        // delete temporary cookie used during external authentication
        await HttpContext.SignOutAsync("Identity.External");

        return Redirect(returnUrl);
    }
    
    private async Task<IdentityResult> LinkIfExternalLogin(ApplicationUser localUser)
    {
        // get external identity from external scheme cookie
        var result = await HttpContext.AuthenticateAsync("Identity.External");
        if (result?.Succeeded != true) return null;

        var externalUser = result.Principal;
        var claims = externalUser.Claims.ToList();

        // try to determine the unique id of the external user
        var userIdClaim = claims.FirstOrDefault(x => x.Type == "sub") ?? claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        if (userIdClaim == null) throw new Exception("Unknown userid");

        claims.Remove(userIdClaim);
        var userId = userIdClaim.Value;
        var providerScheme = result.Properties.Items["scheme"];
            
        var provider = await schemeProvider.GetSchemeAsync(providerScheme);
        var outcome =  await signInManager.UserManager.AddLoginAsync(localUser, new UserLoginInfo(provider.Name, userId, provider.DisplayName));
        await HttpContext.SignOutAsync("Identity.External");
        return outcome;
    }
}