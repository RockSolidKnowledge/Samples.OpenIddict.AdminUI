using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.Device
{
    public class DeviceAppIdentityResourceSetup(IPage page) : ResourceAssigner(page)
    {
        public async Task<DeviceAppIdentityResourceSetup> AssignResources(List<string> resources)
        {
            await InternalAssignResources(resources);

            return this;
        }

        public async Task<ClientSetupReview> Next()
        {
            await Page.Locator("#nextBtn").ClickAsync();

            return new ClientSetupReview(Page);
        }
    }
}
