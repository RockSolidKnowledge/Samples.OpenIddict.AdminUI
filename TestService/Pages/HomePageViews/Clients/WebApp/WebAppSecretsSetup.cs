using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.WebApp
{
    public class WebAppSecretsSetup(IPage page) : SecretsSetup(page)
    {
        public async Task<WebAppSecretsSetup> SetType(string secretType)
        {
            await InternalSetType(secretType);

            return this;
        }

        public async Task<WebAppSecretsSetup> SetValue(string? secretValue)
        {
            await InternalSetValue(secretValue);

            return this;
        }

        public async Task<WebAppSecretsSetup> SetDescription(string secretDescription)
        {
            await InternalSetDescription(secretDescription);

            return this;
        }

        public async Task<WebAppSecretsSetup> Add()
        {
            await InternalAdd();

            return this;
        }

        public async Task<WebAppIdentityResourceSetup> Next()
        {
            await InternalNext();

            return new WebAppIdentityResourceSetup(Page);
        }
    }
}
