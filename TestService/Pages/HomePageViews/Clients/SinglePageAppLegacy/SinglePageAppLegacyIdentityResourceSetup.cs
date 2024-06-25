using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.SinglePageAppLegacy
{
    public class SinglePageAppLegacyIdentityResourceSetup(IPage page) : ResourceAssigner(page)
    {
        public async Task<SinglePageAppLegacyIdentityResourceSetup> AssignResources(List<string> resources)
        {
            await InternalAssignResources(resources);

            return this;
        }

        public async Task<SinglePageAppLegacyProtectedResourceSetup> Next()
        {
            await Page.Locator("#nextBtn").ClickAsync();

            return new SinglePageAppLegacyProtectedResourceSetup(Page);
        }
    }
}
