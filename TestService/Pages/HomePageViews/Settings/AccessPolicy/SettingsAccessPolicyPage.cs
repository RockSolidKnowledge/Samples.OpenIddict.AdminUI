using Microsoft.Playwright;
using TestService.Pages.HomePageViews.Clients;
using TestService.TestCollections.HomePageViews.ClientsView;
using static TestService.TestCollections.HomePageViews.ClientsView.SetupInfoFactory;

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

        public async Task<bool> ConfirmConfiguredAccessPoliciesAreListed(List<AccessPolicySetupInfo> expectedAccessPolicies)
        {
            bool accessPoliciesListed = false;
            int expectedListedCount = expectedAccessPolicies.Count;

            if (expectedListedCount == 0)
            {
                return true;  // We have verified that there are no configured custom claim types in AdminUI appsettings.json
            }

            
            var rows = await CurrentPage.Locator("tbody").Locator("tr").AllAsync();

            var numberFound = 0;

            foreach (var row in rows)
            {
                var type = await row.Locator("td").Nth(0).InnerTextAsync();
                var value = await row.Locator("td").Nth(1).InnerTextAsync();

                if (expectedAccessPolicies.Exists(p => p.ClaimType == type && p.Value == value ))
                {
                    if (++numberFound == expectedListedCount)
                    {
                        accessPoliciesListed = true;
                        break;
                    }
                }
            }
        
            return accessPoliciesListed;
        }
    }
}
