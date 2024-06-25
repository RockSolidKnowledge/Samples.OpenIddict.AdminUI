using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Resources.Identity
{
    public class IdentityResourceAssignClaimTypesSetup(IPage page) : AssignClaimTypesSetup(page)
    {
        public async Task<IdentityResourceAssignClaimTypesSetup> AssignResources(List<string> resources)
        {
            await InternalAssignResources(resources);

            return this;
        }
    }
}
