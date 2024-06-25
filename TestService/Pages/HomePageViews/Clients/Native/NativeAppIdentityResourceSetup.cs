using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.Native
{
    public class NativeAppIdentityResourceSetup(IPage page) : ResourceAssigner(page)
    {
        public async Task<NativeAppIdentityResourceSetup> AssignResources(List<string> resources)
        {
            await InternalAssignResources(resources);

            return this;
        }

        public async Task<NativeAppProtectedResourceSetup> Next()
        {
            await Page.Locator("#nextBtn").ClickAsync();

            return new NativeAppProtectedResourceSetup(Page);
        }
    }
}
