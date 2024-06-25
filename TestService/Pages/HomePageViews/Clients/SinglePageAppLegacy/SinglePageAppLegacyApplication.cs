using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.SinglePageAppLegacy
{
    public class SinglePageAppLegacyApplication(IPage page) : ClientApplication(page)
    {
        public async Task<SinglePageAppLegacyApplicationSetup> Start()
        {
            await InternalStart();

            return new SinglePageAppLegacyApplicationSetup(Page);
        }
    }
}
