using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.Native
{
    public class NativeApplication(IPage page) : ClientApplication(page)
    {
        public async Task<NativeApplication> SetSupportedFlow(string supportedFlow)
        {
            await Page.Locator($"#nativeAppFlow").SelectOptionAsync(new[] { supportedFlow });

            return this;
        }

        public async Task<NativeApplicationSetup> Start()
        {
            await InternalStart();

            return new NativeApplicationSetup(Page);
        }
    }
}
