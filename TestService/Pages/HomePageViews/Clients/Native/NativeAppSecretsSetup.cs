using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.Native
{
    public class NativeAppSecretsSetup(IPage page) : SecretsSetup(page)
    {
        public async Task<NativeAppSecretsSetup> SetType(string secretType)
        {
            await InternalSetType(secretType);

            return this;
        }

        public async Task<NativeAppSecretsSetup> SetValue(string? secretValue)
        {
            await InternalSetValue(secretValue);

            return this;
        }

        public async Task<NativeAppSecretsSetup> SetDescription(string secretDescription)
        {
            await InternalSetDescription(secretDescription);

            return this;
        }

        public async Task<NativeAppSecretsSetup> Add()
        {
            await InternalAdd();

            return this;
        }

        public async Task<NativeAppIdentityResourceSetup> Next()
        {
            await InternalNext();

            return new NativeAppIdentityResourceSetup(Page);
        }
    }
}
