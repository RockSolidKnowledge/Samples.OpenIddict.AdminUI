using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Settings.Webhooks
{
    public class PreCreateConfirmationDialog(IPage page)
    {
        public IPage Page { get; } = page;

        public async Task Continue()
        {
            await Page
                .GetByLabel("Client Creation").GetByText(" Continue ", new() { Exact = true })
                .ClickAsync();
        }
    }
}
