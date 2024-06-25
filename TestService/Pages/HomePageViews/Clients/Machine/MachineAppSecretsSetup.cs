using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.Machine
{
    public class MachineAppSecretsSetup(IPage page) : SecretsSetup(page)
    {
        public async Task<MachineAppSecretsSetup> SetType(string secretType)
        {
            await InternalSetType(secretType);

            return this;
        }

        public async Task<MachineAppSecretsSetup> SetValue(string? secretValue)
        {
            await InternalSetValue(secretValue);

            return this;
        }

        public async Task<MachineAppSecretsSetup> SetDescription(string secretDescription)
        {
            await InternalSetDescription(secretDescription);

            return this;
        }

        public async Task<MachineAppSecretsSetup> Add()
        {
            await InternalAdd();

            return this;
        }

        public async Task<ClientSetupReview> Next()
        {
            await InternalNext();

            return new ClientSetupReview(Page);
        }
    }
}
