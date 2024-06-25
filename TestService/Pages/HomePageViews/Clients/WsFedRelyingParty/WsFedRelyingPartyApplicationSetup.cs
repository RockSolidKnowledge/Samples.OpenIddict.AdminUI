using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.WsFedRelyingParty
{
    public class WsFedRelyingPartyApplicationSetup(IPage page) : ApplicationIdentitySetup(page)
    {
        public async Task<WsFedRelyingPartyApplicationSetup> SetRealm(string guid)
        {
            await InternalSetUniqueIdentifier("ClientId", guid);

            return this;
        }

        public async Task<WsFedRelyingPartyApplicationSetup> SetDisplayName(string displayName)
        {
            await InternalSetDisplayName("DisplayName", displayName);

            return this;
        }

        public async Task<WsFedRelyingPartyApplicationSetup> SetDescription(string description)
        {
            await InternalSetDescription("Description", description);

            return this;
        }

        public async Task<WsFedRelyingPartyAppCallbackUrlSetup> Next()
        {
            await InternalNext();

            return new WsFedRelyingPartyAppCallbackUrlSetup(Page);
        }

    }
}
