using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rsk.Samples.OpenIddict.AdminUiIntegration.Data;
using Rsk.Samples.OpenIddict.AdminUiIntegration.Models;

namespace Rsk.Samples.OpenIddict.AdminUiIntegration.Controllers;

public class AccountController(SignInManager<ApplicationUser> signInManager) : Controller
{
    [HttpGet]
    public IActionResult Login([FromQuery] string returnUrl)
    {
        return View(new LoginInputModel
        {
            ReturnUrl = returnUrl
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginInputModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await signInManager.UserManager.FindByEmailAsync(model.Email);
            if (user?.UserName == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid Credentials");
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid Credentials");
                return View(model);
            }

            await signInManager.SignInAsync(user, false);

            var returnUrl = model.ReturnUrl;
            if (returnUrl == null || !Url.IsLocalUrl(returnUrl))
            {
                return Redirect("~/");
            }

            return Redirect(returnUrl);
        }
        
        ModelState.AddModelError(string.Empty, "Invalid username or password");
        
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

}