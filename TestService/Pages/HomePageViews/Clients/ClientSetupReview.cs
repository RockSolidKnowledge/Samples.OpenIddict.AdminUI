using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients
{
    public class ClientSetupReview(IPage page) : ISaveDialog
    {
        public IPage Page { get; set; } = page;

        protected bool SaveSuccessful { get; set; }

        public async Task<ISaveDialog> Save()
        {
            // 1. Click Save button
            await Page
                .Locator("#submitBtn")
                .ClickAsync();

            // 2. Wait for popup to confirm save completed successfully
            await Page.GetByLabel("Success").WaitForAsync();

            // 3. Wait for the above popup state changes to hidden.
            await Page.GetByLabel("Success").WaitForAsync(new() { State = WaitForSelectorState.Hidden });

            SaveSuccessful = true;

            return this;
        }

        public bool SuccessfullySaved()
        {
            return SaveSuccessful;
        }
    }
}
