using Microsoft.Playwright;
using TestService.Pages.HomePageViews.Clients;

namespace TestService.Pages.HomePageViews.ClaimTypes
{
    public class NewClaimTypeSetup(IPage currentPage) : ApplicationIdentitySetup(currentPage), ISaveDialog
    {
        protected bool SaveSuccessful { get; set; }

        public async Task<NewClaimTypeSetup> SetName(string name)
        {
            await InternalSetUniqueIdentifier("name", name);

            return this;
        }

        public async Task<NewClaimTypeSetup> SetType(string type)
        {
            await Page.Locator("#type").SelectOptionAsync(new []{type});

            return this;
        }

        public async Task<NewClaimTypeSetup> SetDisplayName(string displayName)
        {
            await InternalSetDisplayName("displayName", displayName);

            return this;
        }

        public async Task<NewClaimTypeSetup> SetDescription(string description)
        {
            await InternalSetDescription("description", description);

            return this;
        }

        public async Task<NewClaimTypeSetup> SetRegexRule(string rule)
        {
            await Page.Locator("#rules").FillAsync(rule);

            return this;
        }

        public async Task<NewClaimTypeSetup> SetRuleValidationFailureDescription(string ruleValidationFailureDescription)
        {
            await Page.Locator("#ruleValidationFailureDescription").FillAsync(ruleValidationFailureDescription);

            return this;
        }

        public async Task<NewClaimTypeSetup> AcceptDefaultRequiredClaimSetting()
        {
            return await UseDefaultSettings();
        }

        public async Task<NewClaimTypeSetup> AcceptDefaultUserEditableSetting()
        {
            return await UseDefaultSettings();
        }

        private async Task<NewClaimTypeSetup> UseDefaultSettings()
        {
            return await Task.FromResult(this);
        }

        public async Task<ISaveDialog> Save()
        {
            await Page.Locator("#addButton").ClickAsync();

            await Page.GetByLabel("Added").WaitForAsync();

            // 3. Wait for the above popup state changes to hidden.
            await Page.GetByLabel("Added").WaitForAsync(new() { State = WaitForSelectorState.Hidden });

            SaveSuccessful = true;

            return this;
        }

        public bool SuccessfullySaved()
        {
            return SaveSuccessful;
        }
    }
}
