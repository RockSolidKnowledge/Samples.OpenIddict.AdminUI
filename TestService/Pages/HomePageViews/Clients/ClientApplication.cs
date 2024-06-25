using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients
{
    public abstract class ClientApplication(IPage page)
    {
        protected IPage Page { get; init; } = page;

        protected async Task InternalSelectClientType(string type)
        {
            await Page
                .Locator("#addClientComponent")
                .Locator("ul")
                .Locator("span", new() { HasText = $" {type} ", })
                .First
                .ClickAsync();
        }

        public async Task InternalStart()
        {
            await Page.Locator("app-client-wizard").Locator("#nextModal").ClickAsync();
        }
    }
}
