namespace TestService.Pages.HomePageViews.Settings.AccessPolicy
{
    public class NewAccessPolicySetup(SettingsAccessPolicyPage page)
    {
        public SettingsAccessPolicyPage SettingsAccessPolicyPage { get; } = page;

        public async Task<NewAccessPolicySetup> SelectClaimType(string claimType)
        {
            await SettingsAccessPolicyPage.CurrentPage.Locator("#addClaimType").SelectOptionAsync(new[] { claimType });

            return this;
        }

        public async Task<NewAccessPolicySetup> SetValue(string claimValue)
        {
            //if (await SettingsAccessPolicyPage.CurrentPage.Locator("#addPolicyModal").Locator("add-form-row :nth-child(2)").Locator("input").IsVisibleAsync())
            if (await SettingsAccessPolicyPage.CurrentPage.Locator("#formClaimValue").IsEditableAsync())
            {
                await SettingsAccessPolicyPage.CurrentPage.Locator("#formClaimValue").FillAsync(claimValue);
            }
            else
            {
                await SettingsAccessPolicyPage.CurrentPage.Locator("#formClaimValue").SelectOptionAsync(new[] { claimValue });
            }

            return this;
        }

        public async Task<NewAccessPolicySetup> SelectPermission(string permission)
        {
            await SettingsAccessPolicyPage.CurrentPage.Locator("#addClaimPermission").SelectOptionAsync(new[] { permission });

            return this;
        }

        public async Task<SettingsAccessPolicyPage> Add()
        {
            await SettingsAccessPolicyPage.CurrentPage.Locator("#addPolicySubmit").ClickAsync();

            await SettingsAccessPolicyPage.CurrentPage.Locator("#toast-container").GetByLabel("Don't forget to save your changes").WaitForAsync();

            return await Task.FromResult(SettingsAccessPolicyPage);
        }
    }


}
