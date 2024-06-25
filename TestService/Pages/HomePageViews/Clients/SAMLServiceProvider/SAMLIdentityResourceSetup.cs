using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.SAMLServiceProvider
{
    public class SAMLIdentityResourceSetup(IPage page) : ResourceAssigner(page)
    {
        public async Task<SAMLIdentityResourceSetup> AssignResources(List<string> resources)
        {
            await InternalAssignResources(resources);

            return this;
        }

        public async Task<ClientSetupReview> Next()
        {
            await InternalNext();

            return new ClientSetupReview(Page);
        }
    }
}
