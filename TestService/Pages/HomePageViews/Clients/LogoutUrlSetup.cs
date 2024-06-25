using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients
{
    public abstract class LogoutUrlSetup(IPage page) : SetupDialog(page)
    {
        public async Task InternalSetLogoutUrl(string url)
        {
            await Page.Locator("#LogoutUrl").FillAsync(url);
        }
    }
}
