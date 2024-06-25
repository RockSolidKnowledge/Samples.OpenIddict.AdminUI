using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.WsFedRelyingParty
{
    public class WsFedRelyingPartyAppCallbackUrlSetup(IPage page) : CallbackUrlSetup(page)
    {
        public async Task<WsFedRelyingPartyAppCallbackUrlSetup> SetCallbackUrl(string url)
        {
            await InternalSetCallbackUrl(url);

            return this;
        }

        public async Task<WsFedRelyingPartyAppIdentityResourceSetup> Next()
        {
            await InternalNext();

            return new WsFedRelyingPartyAppIdentityResourceSetup(Page);
        }
    }
}