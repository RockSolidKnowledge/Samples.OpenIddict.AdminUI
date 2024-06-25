using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients
{
    public abstract class CallbackUrlSetup(IPage page) : SetupDialog(page)
    {
        public async Task InternalSetCallbackUrl(string url)
        {
            await Page.Locator("#CallbackUrl").FillAsync(url);
        }

    }
}
