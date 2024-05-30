using System;
using System.Collections.Immutable;
using System.Text.Json;
using System.Threading.Tasks;
using OpenIddict.Abstractions;

namespace IdentityExpress.Manager.BusinessLogic.OpenIddict.Constants;

public static class ScopeManagerExtensionMethods
{
    public static async Task<string[]> GetClaimsFromProperties(this IOpenIddictScopeManager scopeManager, object scope)
    {
        ImmutableDictionary<string, JsonElement> properties = await scopeManager.GetPropertiesAsync(scope);
        
        if (!properties.ContainsKey(AdminUiConstants.ScopePropertyClaims)) return Array.Empty<string>();
        
        return JsonSerializer.Deserialize<string[]>(properties[AdminUiConstants.ScopePropertyClaims]);
    }
}