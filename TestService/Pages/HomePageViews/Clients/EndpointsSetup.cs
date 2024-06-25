using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients
{
    public abstract class EndpointsSetup(IPage page) : SetupDialog(page)
    {
        protected async Task InternalSetEndpoint(string url)
        {
            await Page.Locator("#EndpointUrl").FillAsync(url);
        }

        protected async Task InternalSetBindingType(string binding)
        {
            await Page.Locator("#EndpointBinding").SelectOptionAsync(new[] { binding });
        }

        protected async Task InternalSetIndex(int index)
        {
            await Page.Locator("#EndpointIndex").FillAsync($"{index}");
        }
    }
}
