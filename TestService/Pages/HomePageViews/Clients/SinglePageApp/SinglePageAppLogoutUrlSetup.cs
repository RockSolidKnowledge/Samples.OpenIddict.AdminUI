using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.SinglePageApp
{
    public class SinglePageAppLogoutUrlSetup(IPage page) : LogoutUrlSetup(page)
    {
        public async Task<SinglePageAppLogoutUrlSetup> SetLogoutUrl(string url)
        {
            await InternalSetLogoutUrl(url);

            return this;
        }

        public async Task<SinglePageAppIdentityResourceSetup> Next()
        {
            await InternalNext();

            return new SinglePageAppIdentityResourceSetup(Page);
        }
    }
}
