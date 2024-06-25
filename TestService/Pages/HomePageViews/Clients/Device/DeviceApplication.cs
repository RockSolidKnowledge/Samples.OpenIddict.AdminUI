using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.Device
{
    public class DeviceApplication(IPage page) : ClientApplication(page)
    {
        public async Task<DeviceApplicationSetup> Start()
        {
            await InternalStart();

            return new DeviceApplicationSetup(Page);
        }
    }
}
