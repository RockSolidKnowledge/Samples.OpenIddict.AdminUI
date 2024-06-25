using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.Native
{
    public class NativeAppProtectedResourceSetup(IPage page) : ResourceAssigner(page)
    {
        public async Task<NativeAppProtectedResourceSetup> AssignResources(List<string> resources)
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
