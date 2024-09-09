using System.Security.Claims;

namespace IdentityExpress.Manager.BusinessLogic.OpenIddict.Constants;

public class AdminUIClaim
{
    public string Type { get; set; }
    public string Value { get; set; }
    
    public Claim ToSystemClaim()
    {
        return new Claim(this.Type, this.Value);
    }
}