using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.SinglePageApp
{
    public class SinglePageAppProtectedResourceSetup(IPage page) : ResourceAssigner(page)
    {
        public async Task<SinglePageAppProtectedResourceSetup> AssignResources(List<string> resources)
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
