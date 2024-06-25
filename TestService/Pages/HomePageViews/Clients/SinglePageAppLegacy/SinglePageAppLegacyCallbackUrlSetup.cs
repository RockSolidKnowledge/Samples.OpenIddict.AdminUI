using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.SinglePageAppLegacy
{
    public class SinglePageAppLegacyCallbackUrlSetup(IPage page) : CallbackUrlSetup(page)
    {
        public async Task<SinglePageAppLegacyCallbackUrlSetup> SetCallbackUrl(string url)
        {
            await InternalSetCallbackUrl(url);

            return this;
        }

        public async Task<SinglePageAppLegacyLogoutUrlSetup> Next()
        {
            await InternalNext();

            return new SinglePageAppLegacyLogoutUrlSetup(Page);
        }
    }
}
