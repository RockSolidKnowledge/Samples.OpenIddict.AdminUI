using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.WebApp
{
    public class WebAppProtectedResourceSetup(IPage page) : ResourceAssigner(page)
    {
        public async Task<WebAppProtectedResourceSetup> AssignResources(List<string> resources)
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
