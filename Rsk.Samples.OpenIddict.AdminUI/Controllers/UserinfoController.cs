using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityExpress.Manager.BusinessLogic.OpenIddict.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using Velusia.Server.Data;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Velusia.Server.Controllers;

public class UserinfoController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IOpenIddictScopeManager _scopeManager;

    public UserinfoController(UserManager<ApplicationUser> userManager, IOpenIddictScopeManager scopeManager)
    {
        _scopeManager = scopeManager;
        _userManager = userManager;
    }

    //
    // GET: /api/userinfo
    [Authorize(AuthenticationSchemes = OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)]
    [HttpGet("~/connect/userinfo"), HttpPost("~/connect/userinfo"), Produces("application/json")]
    public async Task<IActionResult> Userinfo()
    {
        var requestedClaims = HttpContext.User.Claims;
        var user = await _userManager.FindByIdAsync(User.GetClaim(Claims.Subject));
        if (user is null)
        {
            return Challenge(
                authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme,
                properties: new AuthenticationProperties(new Dictionary<string, string>
                {
                    [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.InvalidToken,
                    [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
                        "The specified access token is bound to an account that no longer exists."
                }));
        }

        var claims = new Dictionary<string, object>(StringComparer.Ordinal)
        {
            // Note: the "sub" claim is a mandatory claim and must be included in the JSON response.
            [Claims.Subject] = await _userManager.GetUserIdAsync(user)
        };
        
        // Loop throw each scope (oi_scp) and get attached claims from properties
        // Then add those claims to the response
        foreach (var claim in requestedClaims)
        {
           if(claim.Type == "oi_scp")
           {
               var scope = await _scopeManager.FindByNameAsync(claim.Value);
               
               if(scope == null) continue;
               

               var scopeClaimList = await _scopeManager.GetClaimsFromProperties(scope);
               foreach (var scopeClaim in scopeClaimList)
               {
                     switch(scopeClaim) 
                     {
                         case Scopes.Profile:
                             claims[Claims.Name] = await _userManager.GetUserNameAsync(user);
                             claims[Claims.GivenName] = $"{user.FirstName} {user.LastName}";
                             claims[Claims.Email] = await _userManager.GetEmailAsync(user);
                             claims[Claims.EmailVerified] = await _userManager.IsEmailConfirmedAsync(user);
                             claims[Claims.PhoneNumber] = await _userManager.GetPhoneNumberAsync(user);
                             claims[Claims.PhoneNumberVerified] = await _userManager.IsPhoneNumberConfirmedAsync(user);
                             break;
                         case "name":
                             claims[Claims.Name] = await _userManager.GetUserNameAsync(user);
                             break;
                         case "given_name":
                             claims[Claims.GivenName] = $"{user.FirstName} {user.LastName}";
                             break;
                         case Scopes.Email:
                             claims[Claims.Email] = await _userManager.GetEmailAsync(user);
                             claims[Claims.EmailVerified] = await _userManager.IsEmailConfirmedAsync(user);
                             break;
                         case Scopes.Phone:
                             claims[Claims.PhoneNumber] = await _userManager.GetPhoneNumberAsync(user);
                             claims[Claims.PhoneNumberVerified] = await _userManager.IsPhoneNumberConfirmedAsync(user);
                             break;
                         case Scopes.Roles:
                         case "role":
                             claims[Claims.Role] = await _userManager.GetRolesAsync(user);
                             break;
                         default:
                             claims[scopeClaim] = User.GetClaim(scopeClaim);
                             break;
                     } 
               }
           }
        }
        

        if (User.HasScope(Scopes.Email))
        {
            claims[Claims.Email] = await _userManager.GetEmailAsync(user);
            claims[Claims.EmailVerified] = await _userManager.IsEmailConfirmedAsync(user);
        }

        if (User.HasScope(Scopes.Phone))
        {
            claims[Claims.PhoneNumber] = await _userManager.GetPhoneNumberAsync(user);
            claims[Claims.PhoneNumberVerified] = await _userManager.IsPhoneNumberConfirmedAsync(user);
        }

        if (User.HasScope(Scopes.Roles) || User.HasScope("role"))
        {
            claims[Claims.Role] = await _userManager.GetRolesAsync(user);
        }

        // Note: the complete list of standard claims supported by the OpenID Connect specification
        // can be found here: http://openid.net/specs/openid-connect-core-1_0.html#StandardClaims

        return Ok(claims);
    }
}
