using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.SinglePageApp
{
    public class SinglePageAppApplicationSetup(IPage page) : ExtendedClientSetup(page)
    {
        public async Task<SinglePageAppApplicationSetup> SetUniqueIdentifier(string guid)
        {
            await InternalSetUniqueIdentifier("ClientId", guid);

            return this;
        }

        public async Task<SinglePageAppApplicationSetup> SetDisplayName(string displayName)
        {
            await InternalSetDisplayName("DisplayName", displayName);

            return this;
        }

        public async Task<SinglePageAppApplicationSetup> SetDescription(string description)
        {
            await InternalSetDescription("Description", description);

            return this;
        }

        public async Task<SinglePageAppApplicationSetup> SetDisplayUrl(string displayUrl)
        {
            await InternalSetDisplayUrl(displayUrl);

            return this;
        }

        public async Task<SinglePageAppApplicationSetup> SetLogoUrl(string logoUrl)
        {
            await InternalSetLogoUrl(logoUrl);

            return this;
        }

        public async Task<SinglePageAppCallbackUrlSetup> Next()
        {
            await InternalNext();

            return new SinglePageAppCallbackUrlSetup(Page);
        }
    }
}
