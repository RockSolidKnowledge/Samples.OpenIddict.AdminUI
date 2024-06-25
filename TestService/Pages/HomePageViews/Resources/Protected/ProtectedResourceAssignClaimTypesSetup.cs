using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Resources.Protected;

public class ProtectedResourceAssignClaimTypesSetup(IPage page) : AssignClaimTypesSetup(page)
{
    public async Task<ProtectedResourceAssignClaimTypesSetup> AssignResources(List<string> resources)
    {
        await InternalAssignResources(resources);

        return this;
    }
}