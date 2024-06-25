using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.Machine
{
    public class MachineAppProtectedResourceSetup(IPage page) : ResourceAssigner(page)
    {
        public async Task<MachineAppProtectedResourceSetup> AssignResources(List<string> resources)
        {
            await InternalAssignResources(resources);

            return this;
        }

        public async Task<MachineAppProtectedResourceSetup> AssignResourcesAt(int index)
        {
            await InternalAssignResources(index);

            return this;
        }

        public async Task<MachineAppSecretsSetup> Next()
        {
            await InternalNext();

            return new MachineAppSecretsSetup(Page);
        }
    }
}
