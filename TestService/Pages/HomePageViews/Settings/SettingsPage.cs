using Microsoft.Playwright;
using TestService.Pages.HomePageViews.Settings.AccessPolicy;
using TestService.Pages.HomePageViews.Settings.Webhooks;

namespace TestService.Pages.HomePageViews.Settings
{
    public class SettingsPage(IPage currentPage) : TestPage(currentPage)
    {
        public async Task<SettingsAccessPolicyPage> SelectAccessPolicy()
        {
            await CurrentPage.Locator("#acessPolicyTab").ClickAsync();

            return new SettingsAccessPolicyPage(CurrentPage);
        }

        public async Task<SettingsWebhooksPage> SelectWebhooks()
        {
            await CurrentPage.GetByRole(AriaRole.Tab, new(){Name = "Webhooks"}).ClickAsync();

            // The next control we will be interacting with is the checkbox. Making sure it is visible. 
            await CurrentPage
                .Locator("app-manage-webhooks")
                .Locator("app-edit-webhook")
                .Nth(3)
                .Locator("span", new() { HasText = "Protecting Scope" })
                .WaitForAsync();

            return new SettingsWebhooksPage(CurrentPage);
        }
    }
}
