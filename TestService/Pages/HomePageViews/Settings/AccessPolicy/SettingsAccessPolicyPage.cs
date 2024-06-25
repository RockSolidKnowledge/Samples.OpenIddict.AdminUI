using Microsoft.Playwright;
using TestService.Pages.HomePageViews.Clients;

namespace TestService.Pages.HomePageViews.Settings.AccessPolicy
{
    public class SettingsAccessPolicyPage(IPage currentPage) : TestPage(currentPage), ISaveDialog
    {
        private bool SaveSuccessful { get; set; }

        public async Task<NewAccessPolicySetup> AddPolicy()
        {
            await CurrentPage.GetByRole(AriaRole.Button, new() { Name = " Add Policy " }).ClickAsync();

            return new NewAccessPolicySetup(this);
        }

        public async Task<ISaveDialog> Save()
        {
            // 1. Click Save button
            await CurrentPage
                .GetByRole(AriaRole.Button, new() { Name = "Save" })
                .ClickAsync();

            // 2. Wait for popup to confirm save completed successfully
            string expectedSuccessLabel = "Success";
            await CurrentPage.GetByLabel(expectedSuccessLabel).WaitForAsync();

            // 3. Wait for the above popup state changes to hidden.
            await CurrentPage.GetByLabel(expectedSuccessLabel).WaitForAsync(new() { State = WaitForSelectorState.Hidden });

            SaveSuccessful = true;

            return this;
        }

        public bool SuccessfullySaved()
        {
            return SaveSuccessful;
        }
    }
}
