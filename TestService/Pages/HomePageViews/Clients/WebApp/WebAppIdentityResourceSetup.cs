using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.WebApp
{
    public class WebAppIdentityResourceSetup(IPage page) : ResourceAssigner(page)
    {
        public async Task<WebAppIdentityResourceSetup> AssignResources(List<string> resources)
        {
            await InternalAssignResources(resources);

            return this;
        }

        public async Task<WebAppProtectedResourceSetup> Next()
        {
            await Page.Locator("#nextBtn").ClickAsync();

            return new WebAppProtectedResourceSetup(Page);
        }
    }
}
