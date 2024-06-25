using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.Machine
{
    public class MachineApplicationSetup(IPage page) : ApplicationIdentitySetup(page)
    {
        public async Task<MachineApplicationSetup> SetUniqueIdentifier(string guid)
        {
            await InternalSetUniqueIdentifier("ClientId", guid);

            return this;
        }

        public async Task<MachineApplicationSetup> SetDisplayName(string displayName)
        {
            await InternalSetDisplayName("DisplayName", displayName);

            return this;
        }

        public async Task<MachineApplicationSetup> SetDescription(string description)
        {
            await InternalSetDescription("Description", description);

            return this;
        }

        public async Task<MachineAppProtectedResourceSetup> Next()
        {
            await InternalNext();

            return new MachineAppProtectedResourceSetup(Page);
        }
    }
}
