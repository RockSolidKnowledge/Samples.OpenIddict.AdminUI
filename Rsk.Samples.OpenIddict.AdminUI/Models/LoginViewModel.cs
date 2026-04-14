using System;
using System.Collections.Generic;
using System.Linq;

namespace Rsk.Samples.OpenIddict.AdminUiIntegration.Models;

public class LoginViewModel : LoginInputModel
{
    public bool LinkSetup { get; set; } = false;

    public IEnumerable<ExternalProvider> ExternalProviders { get; set; } = new List<ExternalProvider>();
    public IEnumerable<ExternalProvider> VisibleExternalProviders => ExternalProviders.Where(x => !String.IsNullOrWhiteSpace(x.DisplayName));
    
    public string ExternalLoginScheme => ExternalProviders?.SingleOrDefault()?.AuthenticationScheme;
}