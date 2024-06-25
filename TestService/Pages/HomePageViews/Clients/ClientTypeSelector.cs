using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients
{
    public abstract class ClientTypeSelector(IPage page)
    {
        protected IPage Page { get; init; } = page;

        public async Task InternalSelectClientType(string type)
        {
            await Page
                .Locator("#addClientComponent")
                .Locator("ul")
                .Locator("span", new() { HasText = $" {type} ", })
                .First
                .ClickAsync();
        }
    }
}
