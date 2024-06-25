using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.Device
{
    public class DeviceAppProtectedResourceSetup(IPage page) : ResourceAssigner(page)
    {
        public async Task<DeviceAppProtectedResourceSetup> AssignResources(List<string> resources)
        {
            await InternalAssignResources(resources);

            return this;
        }

        public async Task<DeviceAppIdentityResourceSetup> Next()
        {
            await Page.Locator("#nextBtn").ClickAsync();

            return new DeviceAppIdentityResourceSetup(Page);
        }
    }
}
