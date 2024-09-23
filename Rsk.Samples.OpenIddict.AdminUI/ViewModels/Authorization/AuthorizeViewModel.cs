using System.ComponentModel.DataAnnotations;

namespace Rsk.Samples.OpenIddict.AdminUiIntegration.ViewModels.Authorization;

public class AuthorizeViewModel
{
    [Display(Name = "Application")]
    public string ApplicationName { get; set; }

    [Display(Name = "Scope")]
    public string Scope { get; set; }
}
