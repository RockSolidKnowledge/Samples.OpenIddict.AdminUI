using System.ComponentModel.DataAnnotations;

namespace Rsk.Samples.OpenIddict.AdminUiIntegration.Models;

public class LoginInputModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    public string ReturnUrl { get; set; }
    
    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}