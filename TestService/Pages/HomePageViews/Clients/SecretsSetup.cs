using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients
{
    public abstract class SecretsSetup(IPage page) : SetupDialog(page)
    {
        protected async Task InternalSetType(string secretType)
        {
            await Page.Locator("#SecretType").SelectOptionAsync(new[] { secretType });
        }

        protected async Task InternalSetValue(string? secretValue)
        {
            if (secretValue == null)
            {
                await Page.Locator("#generateSecret").ClickAsync();
            }
            else
            {
                await Page.Locator("#SecretValue").First.FillAsync(secretValue);
            }
        }

        protected async Task InternalSetDescription(string secretDescription)
        {
            await Page.Locator("#SecretDescription").FillAsync(secretDescription);
        }

        protected async Task InternalAdd()
        {
            await Page.Locator("#addSecretBtn").ClickAsync();
        }
    }
}
