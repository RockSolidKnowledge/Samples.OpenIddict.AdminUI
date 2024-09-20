using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Rsk.Samples.OpenIddict.AdminUiIntegration.Data;

namespace Rsk.Samples.OpenIddict.AdminUiIntegration.Services;

public class CustomSignInManager : SignInManager<ApplicationUser>
{
    public CustomSignInManager(UserManager<ApplicationUser> userManager, 
        IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, 
        IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<ApplicationUser>> logger, 
        IAuthenticationSchemeProvider schemes, IUserConfirmation<ApplicationUser> userConfirmation)
        : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, userConfirmation)
    {
    }

    public override async Task<SignInResult> PasswordSignInAsync(string userName, string password,
        bool isPersistent, bool lockoutOnFailure)
    {
        var user = await UserManager.FindByEmailAsync(userName);
        if (user == null)
        {
            return SignInResult.Failed;
        }

        return await PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
    }
}