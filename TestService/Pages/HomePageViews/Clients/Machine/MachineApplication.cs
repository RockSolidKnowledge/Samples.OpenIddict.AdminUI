using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.Machine
{
    public class MachineApplication(IPage page) : ClientApplication(page)
    {
        public async Task<MachineApplication> SetSupportedFlow(string supportedFlow)
        {
            await Page.Locator($"#robotAppFlow").SelectOptionAsync(new[] { supportedFlow });

            return this;
        }

        public async Task<MachineApplicationSetup> Start()
        {
            await InternalStart();

            return new MachineApplicationSetup(Page);
        }
    }
}
