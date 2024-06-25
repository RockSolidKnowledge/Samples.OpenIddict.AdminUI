using Microsoft.Playwright;
using TestService.Pages.HomePageViews.Clients;

namespace TestService.Pages.HomePageViews.Settings.Webhooks
{
    public class SettingsWebhooksPage(IPage currentPage) : TestPage(currentPage), ISaveDialog
    {
        private bool SaveSuccessful { get; set; }

        public async Task<SettingsWebhooksPage> EnableWebhookForMfaReset()
        {
            await CurrentPage
                .Locator("app-manage-webhooks")
                .Locator("app-edit-webhook")
                .First
                .Locator(".tw-form-switch__state")
                .ClickAsync();

            return this;
        }

        public async Task<SettingsWebhooksPage> SetUrlForMfaReset(string url)
        {
            await CurrentPage
                .Locator("app-manage-webhooks")
                .Locator("app-edit-webhook")
                .First
                .Locator("#WebhookUrl")
                .FillAsync(url);

            return this;
        }

        public async Task<SettingsWebhooksPage> SelectProtectingScopeMfaReset(string protectingScope)
        {
            await CurrentPage
                .Locator("app-manage-webhooks")
                .Locator("app-edit-webhook")
                .First
                .Locator("#scopes")
                .SelectOptionAsync(new[] { protectingScope });

            return this;
        }

        public async Task<SettingsWebhooksPage> EnableWebhookForPasswordReset()
        {
            await CurrentPage
                .Locator("app-manage-webhooks")
                .Locator("app-edit-webhook")
                .Nth(1)
                .Locator(".tw-form-switch__state")
                .ClickAsync();

            return this;
        }

        public async Task<SettingsWebhooksPage> SetUrlForPasswordReset(string url)
        {
            await CurrentPage
                .Locator("app-manage-webhooks")
                .Locator("app-edit-webhook")
                .Nth(1)
                .Locator("#WebhookUrl")
                .FillAsync(url);

            return this;
        }

        public async Task<SettingsWebhooksPage> SelectProtectingScopeForPasswordReset(string protectingScope)
        {
            await CurrentPage
                .Locator("app-manage-webhooks")
                .Locator("app-edit-webhook")
                .Nth(1)
                .Locator("#scopes")
                .SelectOptionAsync(new[] { protectingScope });

            await CurrentPage
                .Locator("app-manage-webhooks")
                .Locator("app-edit-webhook")
                .Nth(2)
                .Locator("#WebhookUrl")
                .WaitForAsync();

            return this;
        }

        public async Task<SettingsWebhooksPage> EnableWebhookForUserRegistration()
        {
            await CurrentPage
                .Locator("app-manage-webhooks")
                .Locator("app-edit-webhook")
                .Nth(2)
                .Locator(".tw-form-switch__state")
                .ClickAsync();

            return this;
        }

        public async Task<SettingsWebhooksPage> SetUrlForUserRegistration(string url)
        {
            await CurrentPage
                .Locator("app-manage-webhooks")
                .Locator("app-edit-webhook")
                .Nth(2)
                .Locator("#WebhookUrl")
                .FillAsync(url);

            return this;
        }

        public async Task<SettingsWebhooksPage> SelectProtectingScopeForUserRegistration(string protectingScope)
        {
            await CurrentPage
                .Locator("app-manage-webhooks")
                .Locator("app-edit-webhook")
                .Nth(2)
                .Locator("#scopes")
                .SelectOptionAsync(new[] { protectingScope });

            return this;
        }

        public async Task<SettingsWebhooksPage> EnableWebhookForServerSideSessionDeletion()
        {
            await CurrentPage
                .Locator("app-manage-webhooks")
                .Locator("app-edit-webhook")
                .Nth(3)
                .Locator(".tw-form-switch__state")
                .ClickAsync();

            return this;
        }

        public async Task<SettingsWebhooksPage> SetUrlForServerSideSessionDeletion(string url)
        {
            await CurrentPage
                .Locator("app-manage-webhooks")
                .Locator("app-edit-webhook")
                .Nth(3)
                .Locator("#WebhookUrl")
                .FillAsync(url);

            return this;
        }

        public async Task<SettingsWebhooksPage> SelectProtectingScopeForServerSideSessionDeletion(string protectingScope)
        {
            await CurrentPage
                .Locator("app-manage-webhooks")
                .Locator("app-edit-webhook")
                .Nth(3)
                .Locator("#scopes")
                .SelectOptionAsync(new[] { protectingScope });

            return this;
        }

        public async Task<ISaveDialog> Save()
        {
            // 1. Click Save button
            await CurrentPage
                .GetByRole(AriaRole.Button, new() { Name = " Save " })
                .ClickAsync();

            PreCreateConfirmationDialog preDeletionWarningDialog = new (CurrentPage);
            await preDeletionWarningDialog.Continue();

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
