using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.SinglePageAppLegacy
{
    public class SinglePageAppLegacyLogoutUrlSetup(IPage page) : LogoutUrlSetup(page)
    {
        public async Task<SinglePageAppLegacyLogoutUrlSetup> SetLogoutUrl(string url)
        {
            await InternalSetLogoutUrl(url);

            return this;
        }

        public async Task<SinglePageAppLegacyIdentityResourceSetup> Next()
        {
            await InternalNext();

            return new SinglePageAppLegacyIdentityResourceSetup(Page);
        }
    }
}
