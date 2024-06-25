using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.Device
{
    public class DeviceApplicationSetup(IPage page) : ApplicationIdentitySetup(page)
    {
        public async Task<DeviceApplicationSetup> SetUniqueIdentifier(string guid)
        {
            await InternalSetUniqueIdentifier("ClientId", guid);

            return this;
        }

        public async Task<DeviceApplicationSetup> SetDisplayName(string displayName)
        {
            await InternalSetDisplayName("DisplayName", displayName);

            return this;
        }

        public async Task<DeviceApplicationSetup> SetDescription(string description)
        {
            await InternalSetDescription("Description", description);

            return this;
        }

        public async Task<DeviceAppProtectedResourceSetup> Next()
        {
            await InternalNext();

            return new DeviceAppProtectedResourceSetup(Page);
        }
    }
}
