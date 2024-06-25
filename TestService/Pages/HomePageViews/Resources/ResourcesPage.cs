using Microsoft.Playwright;
using TestService.Pages.HomePageViews.Resources.Identity;
using TestService.Pages.HomePageViews.Resources.Protected;

namespace TestService.Pages.HomePageViews.Resources
{
    public class ResourcesPage(IPage currentPage) : TestPage(currentPage)
    {
        public async Task<IdentityResourcesPage> SelectIdentityResource()
        {
            await CurrentPage.GetByRole(AriaRole.Button, new() { Name = "Identity Resources", Exact = true }).ClickAsync();

            return await Task.FromResult(new IdentityResourcesPage(CurrentPage));
        }

        public async Task<ProtectedResourcesPage> SelectProtectedResource()
        {
            await CurrentPage.GetByRole(AriaRole.Button, new() { Name = "Protected Resources", Exact = true }).ClickAsync();

            return await Task.FromResult(new ProtectedResourcesPage(CurrentPage));
        }
    }
}
