using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.WebApp
{
    public class WebAppCallbackUrlSetup(IPage page) : CallbackUrlSetup(page)
    {
        public async Task<WebAppCallbackUrlSetup> SetCallbackUrl(string url)
        {
            await InternalSetCallbackUrl(url);

            return this;
        }

        public async Task<WebAppLogoutUrlSetup> Next()
        {
            await InternalNext();

            return new WebAppLogoutUrlSetup(Page);
        }
    }
}
