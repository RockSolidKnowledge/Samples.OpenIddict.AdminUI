using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.WebApp
{
    public class WebAppLogoutUrlSetup(IPage page) : LogoutUrlSetup(page)
    {
        public async Task<WebAppLogoutUrlSetup> SetLogoutUrl(string url)
        {
            await InternalSetLogoutUrl(url);

            return this;
        }

        public async Task<WebAppSecretsSetup> Next()
        {
            await InternalNext();

            return new WebAppSecretsSetup(Page);
        }
    }
}
