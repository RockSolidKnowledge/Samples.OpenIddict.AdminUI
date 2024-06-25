using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Resources.Protected;

public class CreateProtectedResourceSetup(IPage page) : ApplicationIdentitySetup(page)
{
    public async Task<CreateProtectedResourceSetup> SetUniqueIdentifier(string identifier)
    {
        await InternalSetUniqueIdentifier("idInput", identifier);

        return this;
    }

    public async Task<CreateProtectedResourceSetup> SetDisplayName(string displayName)
    {
        await InternalSetDisplayName("displayNameInput", displayName);

        return this;
    }

    public async Task<CreateProtectedResourceSetup> SetDescription(string description)
    {
        await InternalSetDescription("descriptionInput", description);

        return this;
    }

    public async Task<ProtectedResourceAssignClaimTypesSetup> Next()
    {
        await InternalNext();

        return new ProtectedResourceAssignClaimTypesSetup(Page);
    }
}