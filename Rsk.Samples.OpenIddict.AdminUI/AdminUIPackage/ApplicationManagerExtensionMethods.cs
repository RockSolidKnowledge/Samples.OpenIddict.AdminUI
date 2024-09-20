using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using OpenIddict.Abstractions;

namespace Rsk.Samples.OpenIddict.AdminUiIntegration.AdminUIPackage;

public static class ApplicationManagerExtensionMethods
{
    public static async Task<List<AdminUIClaim>> GetClaimsFromProperties(this IOpenIddictApplicationManager applicationManager, object scope)
    {
        ImmutableDictionary<string, JsonElement> properties = await applicationManager.GetPropertiesAsync(scope);

        return properties.TryGetValue(AdminUiConstants.ApplicationPropertyClaims, out var claimsJson) ?
            claimsJson.Deserialize<List<AdminUIClaim>>(new JsonSerializerOptions {PropertyNameCaseInsensitive = true}) :
            [];
    }
    
    public static async Task<IDictionary<string, ImmutableArray<string>>> GetClaimValuesDictionary(this IOpenIddictApplicationManager applicationManager, object scope)
    {
        var claimsList = await GetClaimsFromProperties(applicationManager, scope);

        return claimsList.GroupBy(c => c.Type)
            .ToDictionary(x => x.Key, 
                x => x.Select(g => g.Value).ToImmutableArray());
    }
}