using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients
{
    public abstract class SetupDialog(IPage page)
    {
        public IPage Page { get; } = page;

        protected async Task InternalNext()
        {
            await Page.Locator("#nextBtn").ClickAsync();
        }
    }
}
