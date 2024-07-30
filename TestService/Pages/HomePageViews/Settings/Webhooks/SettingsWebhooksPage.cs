using Microsoft.Playwright;
using TestService.Pages.HomePageViews.Clients;

namespace TestService.Pages.HomePageViews.Settings.Webhooks
{
    

    public class SettingsWebhooksPage(IPage currentPage) : TestPage(currentPage)
    {
        private const int WebhookEnabledElementIndex = 0;
        private const int WebhookUrlElementIndex = 1;
        private const int WebhookScopesElementIndex = 2;

        public async Task<bool> IsWebHookConfigured(string webHookName, string url, string protectingScopes)
        {
            int webHookCount = await CurrentPage.Locator("app-readonly-webhook").CountAsync();
            
            for (int headerIndex = 0; headerIndex < webHookCount; headerIndex++)
            {
                string header = await CurrentPage.Locator("app-manage-webhooks").Locator("h2").Nth(headerIndex).InnerTextAsync();
                if (header == webHookName)
                {
                    if (await UiUrlMatches(headerIndex, url) )
                    {
                        if (await UiProtectingScopesMatch(headerIndex, protectingScopes))
                        {
                            return await UiEnabledStatusMatches(headerIndex, "Yes");
                        }
                    }
                }

            }
            Console.WriteLine("Returning FALSE !!!");
            return false;
        }

        public async Task<bool> IsWebHookNotConfigured(string webhookName)
        {
            int webHookCount = await CurrentPage.Locator("app-readonly-webhook").CountAsync();

            for (int headerIndex = 0; headerIndex < webHookCount; headerIndex++)
            {
                string header = await CurrentPage.Locator("app-manage-webhooks").Locator("h2").Nth(headerIndex).InnerTextAsync();

                if (header == webhookName)
                {
                    return await UiEnabledStatusMatches(headerIndex, "No");
                }

            }

            return false;
        }
        private async Task<bool> UiEnabledStatusMatches(int headerIndex, string expectedStatus)
        {
            string uiStatus = await CurrentPage.Locator("app-readonly-webhook")
                .Nth(headerIndex)
                .Locator("app-form-row")
                .Nth(WebhookEnabledElementIndex)
                .Locator("#singleCommaMainText")
                .InnerTextAsync();

            return uiStatus == expectedStatus;
        }

        private async Task<bool> UiUrlMatches(int headerIndex, string expectedUrl)
        {
            string uiUrl = await CurrentPage.Locator("app-readonly-webhook")
                .Nth(headerIndex)
                .Locator("app-form-row")
                .Nth(WebhookUrlElementIndex)
                .Locator("#singleCommaMainText")
                .InnerTextAsync();

            return uiUrl == expectedUrl;
        }

        private async Task<bool> UiProtectingScopesMatch(int headerIndex, string scopes)
        {
            string uiScopes = await CurrentPage.Locator("app-readonly-webhook")
                .Nth(headerIndex)
                .Locator("app-form-row")
                .Nth(WebhookScopesElementIndex)
                .Locator("#singleCommaMainText")
                .InnerTextAsync();

            return uiScopes == scopes;
        }
    }
}
