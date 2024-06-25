using Microsoft.Playwright;
using TestService.Pages.HomePageViews.Clients;

namespace TestService.Pages.HomePageViews.Resources
{
    public class ResourceSaveDialog(IPage page) : ISaveDialog
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
            string expectedSuccessLabel = "Resource Added Successfully";
            await Page.GetByLabel(expectedSuccessLabel).WaitForAsync();

            // 3. Wait for the above popup state changes to hidden.
            await Page.GetByLabel(expectedSuccessLabel).WaitForAsync(new() { State = WaitForSelectorState.Hidden });

            SaveSuccessful = true;

            return this;
        }

        public bool SuccessfullySaved()
        {
            return SaveSuccessful;
        }
    }
}
