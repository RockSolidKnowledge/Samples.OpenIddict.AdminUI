using Microsoft.Playwright;
using TestService.Pages.HomePageViews.Clients.Device;
using TestService.Pages.HomePageViews.Clients.Machine;
using TestService.Pages.HomePageViews.Clients.Native;
using TestService.Pages.HomePageViews.Clients.SAMLServiceProvider;
using TestService.Pages.HomePageViews.Clients.SinglePageApp;
using TestService.Pages.HomePageViews.Clients.SinglePageAppLegacy;
using TestService.Pages.HomePageViews.Clients.WebApp;
using TestService.Pages.HomePageViews.Clients.WsFedRelyingParty;

namespace TestService.Pages.HomePageViews.Clients
{
    public class ClientWizardPage(IPage page) : ClientTypeSelector(page)
    {
        public async Task<SinglePageAppApplication> SelectSinglePageApp()
        {
            await InternalSelectClientType("Single Page App");

            return await Task.FromResult(new SinglePageAppApplication(Page));
        }

        public async Task<WebApplication> SelectWebApp()
        {
            await InternalSelectClientType("Web App");

            return await Task.FromResult(new WebApplication(Page));
        }

        public async Task<MachineApplication> SelectMachineApp()
        {
            await InternalSelectClientType("Machine");

            return new MachineApplication(Page);
        }

        public async Task<SAMLApplication> SelectSAMLApp()
        {
            await InternalSelectClientType("SAML Service Provider");

            return new SAMLApplication(Page);
        }

        public async Task<WsFedRelyingPartyApplication> SelectWsFedRelyingPartyApp()
        {
            await InternalSelectClientType("Ws-Fed Relying Party");

            return new WsFedRelyingPartyApplication(Page);
        }

        public async Task<NativeApplication> SelectNativeApp()
        {
            await InternalSelectClientType("Native");

            return new NativeApplication(Page);
        }

        public async Task<DeviceApplication> SelectDeviceApp()
        {
            await InternalSelectClientType("Device");

            return new DeviceApplication(Page);
        }

        public async Task<SinglePageAppLegacyApplication> SelectSinglePageAppLegacy()
        {
            await InternalSelectClientType("Single Page App (Legacy)");

            return new SinglePageAppLegacyApplication(Page);
        }
    }
}
