using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.WebApp
{
    public class WebApplication(IPage page) : ClientApplication(page)
    {
        public async Task<WebApplication> SetSupportedFlow(string supportedFlow)
        {
            await Page.Locator($"#webAppFlow").SelectOptionAsync(new[] { supportedFlow });

            return this;
        }

        public async Task<WebApplicationSetup> Start()
        {
            await InternalStart();

            return new WebApplicationSetup(Page);
        }

    }
}
