using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.SinglePageApp
{
    public class SinglePageAppCallbackUrlSetup(IPage page) : CallbackUrlSetup(page)
    {
        public async Task<SinglePageAppCallbackUrlSetup> SetCallbackUrl(string url)
        {
            await InternalSetCallbackUrl(url);

            return this;
        }

        public async Task<SinglePageAppLogoutUrlSetup> Next()
        {
            await InternalNext();

            return new SinglePageAppLogoutUrlSetup(Page);
        }
    }
}
