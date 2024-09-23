using System.ComponentModel.DataAnnotations;

namespace Rsk.Samples.OpenIddict.AdminUiIntegration.ViewModels.Shared;

public class ErrorViewModel
{
    [Display(Name = "Error")]
    public string Error { get; set; }

    [Display(Name = "Description")]
    public string ErrorDescription { get; set; }
}
