using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Resources.Identity
{
    public class CreateIdentityResourceSetup(IPage page) : ApplicationIdentitySetup(page)
    {
        public async Task<CreateIdentityResourceSetup> SetUniqueIdentifier(string identifier)
        {
            await InternalSetUniqueIdentifier("idInput", identifier);

            return this;
        }

        public async Task<CreateIdentityResourceSetup> SetDisplayName(string displayName)
        {
            await InternalSetDisplayName("displayNameInput", displayName);

            return this;
        }

        public async Task<CreateIdentityResourceSetup> SetDescription(string description)
        {
            await InternalSetDescription("descriptionInput", description);

            return this;
        }

        public async Task<IdentityResourceAssignClaimTypesSetup> Next()
        {
            await InternalNext();

            return new IdentityResourceAssignClaimTypesSetup(Page);
        }
    }
}
