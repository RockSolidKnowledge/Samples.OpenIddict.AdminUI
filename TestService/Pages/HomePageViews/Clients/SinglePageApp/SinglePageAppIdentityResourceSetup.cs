using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.SinglePageApp
{
    public class SinglePageAppIdentityResourceSetup(IPage page) : ResourceAssigner(page)
    {
        public async Task<SinglePageAppIdentityResourceSetup> AssignResources(List<string> resources)
        {
            await InternalAssignResources(resources);

            return this;
        }

        public async Task<SinglePageAppProtectedResourceSetup> Next()
        {
            await Page.Locator("#nextBtn").ClickAsync();

            return new SinglePageAppProtectedResourceSetup(Page);
        }
    }
}
