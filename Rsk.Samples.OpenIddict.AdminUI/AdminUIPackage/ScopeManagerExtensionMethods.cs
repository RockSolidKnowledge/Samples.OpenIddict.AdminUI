using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using OpenIddict.Abstractions;

namespace Rsk.Samples.OpenIddict.AdminUiIntegration.AdminUIPackage;

public static class ScopeManagerExtensionMethods
{
    public static async Task<List<string>> GetClaimsFromProperties(this IOpenIddictScopeManager scopeManager, object scope)
    {
        ImmutableDictionary<string, JsonElement> properties = await scopeManager.GetPropertiesAsync(scope);
        
        return properties.TryGetValue(AdminUiConstants.ScopePropertyClaims, out var claimsJson) ?
            claimsJson.Deserialize<List<string>>() : [];
    }
    
    public static async Task<bool> ScopesExist(this IOpenIddictScopeManager scopeManager, OpenIddictRequest request)
    {
        var scopes = request.GetScopes().ToList();
        
        foreach (var scope in scopes)
        {
            if (await scopeManager.FindByNameAsync(scope) == null)
            {
                return false;
            }
        }

        return true;
    }
}