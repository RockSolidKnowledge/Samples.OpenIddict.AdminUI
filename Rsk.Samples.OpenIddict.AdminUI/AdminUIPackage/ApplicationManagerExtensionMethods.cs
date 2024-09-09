using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.Json;
using System.Threading.Tasks;
using OpenIddict.Abstractions;

namespace IdentityExpress.Manager.BusinessLogic.OpenIddict.Constants;

public static class ApplicationManagerExtensionMethods
{
    public static async Task<Dictionary<string, string>> GetClaimsFromProperties(this IOpenIddictApplicationManager applicationManager, object scope)
    {
        ImmutableDictionary<string, JsonElement> properties = await applicationManager.GetPropertiesAsync(scope);

        if (properties.TryGetValue(AdminUiConstants.ApplicationPropertyClaims, out var claimsJson))
        {
            return claimsJson.Deserialize<Dictionary<string, string>>();
        }
        
        return new Dictionary<string, string>();
    }
}