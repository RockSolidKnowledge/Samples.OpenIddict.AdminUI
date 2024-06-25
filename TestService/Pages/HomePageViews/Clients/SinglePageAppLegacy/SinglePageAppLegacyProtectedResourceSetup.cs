using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.SinglePageAppLegacy
{
    public class SinglePageAppLegacyProtectedResourceSetup(IPage page) : ResourceAssigner(page)
    {
        public async Task<SinglePageAppLegacyProtectedResourceSetup> AssignResources(List<string> resources)
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
