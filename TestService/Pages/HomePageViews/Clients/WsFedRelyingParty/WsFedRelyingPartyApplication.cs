using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.WsFedRelyingParty
{
    public class WsFedRelyingPartyApplication(IPage page) : ClientApplication(page)
    {
        public async Task<WsFedRelyingPartyApplicationSetup> Start()
        {
            await InternalStart();

            return new WsFedRelyingPartyApplicationSetup(Page);
        }
    }
}
