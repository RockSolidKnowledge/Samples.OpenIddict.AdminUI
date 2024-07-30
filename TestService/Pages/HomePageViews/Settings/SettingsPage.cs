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

            await CurrentPage.Locator("tr").Nth(0).WaitForAsync();
            
            return new SettingsAccessPolicyPage(CurrentPage);
        }

        public async Task<SettingsWebhooksPage> SelectWebhooks()
        {
            await CurrentPage.GetByRole(AriaRole.Tab, new(){Name = "Webhooks"}).ClickAsync();

            await CurrentPage.Locator("app-manage-webhooks").WaitForAsync();

            return new SettingsWebhooksPage(CurrentPage);
        }
    }
}
