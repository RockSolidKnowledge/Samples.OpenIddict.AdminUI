using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.WsFedRelyingParty
{
    public class WsFedRelyingPartyAppIdentityResourceSetup(IPage page) : ResourceAssigner(page)
    {
        public async Task<WsFedRelyingPartyAppIdentityResourceSetup> AssignResources(List<string> resources)
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
