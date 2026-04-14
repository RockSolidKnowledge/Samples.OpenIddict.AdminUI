#nullable enable
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Rsk.Samples.OpenIddict.AdminUiIntegration.Models;

namespace Rsk.Samples.OpenIddict.AdminUiIntegration.Services;

public class AccountService(
    IAuthenticationSchemeProvider schemeProvider,
    IConfiguration configuration,
    IHttpContextAccessor httpContextAccessor) : IAccountService
{
    
    public async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl)
    {
        string? idp = httpContextAccessor.HttpContext?.Request.Query["idp"].ToString();
        string? loginHint = httpContextAccessor.HttpContext?.Request.Query["login_hint"].ToString();
        
        var vm = new LoginViewModel
        {
            ReturnUrl = returnUrl,
            Username = loginHint,
        };
        
        if (!string.IsNullOrWhiteSpace(idp) && await schemeProvider.GetSchemeAsync(idp) != null)
        {
            vm.ExternalProviders = new[] { new ExternalProvider { AuthenticationScheme = idp } };
        }
        else
        {
            var providers = await GetExternalProviderAsync();
            vm.ExternalProviders = providers.ToArray();
        }

        return vm;
    }

    public LoginViewModel BuildLinkLoginViewModel(string returnUrl)
    {
        return new LoginViewModel
        {
            LinkSetup = true,
            ReturnUrl = returnUrl,
        };
    }

    public async Task<LoginViewModel> BuildLoginViewModelAsync(LoginInputModel model)
    {
        var vm = await BuildLoginViewModelAsync(model.ReturnUrl);
        vm.Username = model.Username;
        vm.RememberLogin = model.RememberLogin;
        return vm;
    }
    
    private async Task<IEnumerable<ExternalProvider>> GetExternalProviderAsync()
    {
        string dynamicAuthLicense = configuration["DynamicAuthLicense"];
        if(string.IsNullOrWhiteSpace(dynamicAuthLicense) || dynamicAuthLicense == "***YOUR LICENSE KEY***")
        {
            return new List<ExternalProvider>();
        }
        
        var schemes = await schemeProvider.GetAllSchemesAsync();
        
        return schemes
            .Where(x => x.DisplayName != null)
            .Select(x => new ExternalProvider
            {
                DisplayName = x.DisplayName ?? x.Name,
                AuthenticationScheme = x.Name
            }).ToList();
    }
}