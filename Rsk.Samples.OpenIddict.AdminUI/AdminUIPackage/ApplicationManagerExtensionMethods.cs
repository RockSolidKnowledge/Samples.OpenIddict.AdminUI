using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using OpenIddict.Abstractions;

namespace IdentityExpress.Manager.BusinessLogic.OpenIddict.Constants;

public static class ApplicationManagerExtensionMethods
{
    public static async Task<List<AdminUIClaim>> GetClaimsFromProperties(this IOpenIddictApplicationManager applicationManager, object scope)
    {
        ImmutableDictionary<string, JsonElement> properties = await applicationManager.GetPropertiesAsync(scope);

        if (properties.TryGetValue(AdminUiConstants.ApplicationPropertyClaims, out var claimsJson))
        {
            return claimsJson.Deserialize<List<AdminUIClaim>>(new JsonSerializerOptions(){PropertyNameCaseInsensitive = true});
        }
        
        return new List<AdminUIClaim>();
    }
    
    public static async Task<List<AdminUIGroupedClaims>> GetGroupedClaimsFromProperties(this IOpenIddictApplicationManager applicationManager, object scope)
    {
        var claimsList = await GetClaimsFromProperties(applicationManager, scope);
        
        return claimsList.GroupBy(c => c.Type)
            .Select(g => new AdminUIGroupedClaims()
            {
                Type = g.Key,
                Values = g.Select(c => c.Value).ToList()
            })
            .ToList();
    }
}