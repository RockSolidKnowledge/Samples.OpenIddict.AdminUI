using System.Threading.Tasks;
using Rsk.Samples.OpenIddict.AdminUiIntegration.Models;

namespace Rsk.Samples.OpenIddict.AdminUiIntegration.Services;

public interface IAccountService
{
    Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl);
    LoginViewModel BuildLinkLoginViewModel(string returnUrl);
    Task<LoginViewModel> BuildLoginViewModelAsync(LoginInputModel model);
}