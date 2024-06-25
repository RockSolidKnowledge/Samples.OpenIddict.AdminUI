using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.SAMLServiceProvider
{
    public class SAMLApplicationSetup(IPage page) : ApplicationIdentitySetup(page)
    {
        public async Task<SAMLApplicationSetup> SetUniqueIdentifier(string guid)
        {
            await InternalSetUniqueIdentifier("ClientId", guid);

            return this;
        }

        public async Task<SAMLApplicationSetup> SetDisplayName(string displayName)
        {
            await InternalSetDisplayName("DisplayName", displayName);

            return this;
        }

        public async Task<SAMLApplicationSetup> SetDescription(string description)
        {
            await InternalSetDescription("Description", description);

            return this;
        }

        public async Task<SAMLACSEndpointsSetup> Next()
        {
            await InternalNext();

            return new SAMLACSEndpointsSetup(Page);
        }
    }
}
