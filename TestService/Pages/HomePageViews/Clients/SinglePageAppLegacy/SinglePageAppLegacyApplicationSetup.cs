using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.SinglePageAppLegacy
{
    public class SinglePageAppLegacyApplicationSetup(IPage page) : ExtendedClientSetup(page)
    {
        public async Task<SinglePageAppLegacyApplicationSetup> SetUniqueIdentifier(string guid)
        {
            await InternalSetUniqueIdentifier("ClientId", guid);

            return this;
        }

        public async Task<SinglePageAppLegacyApplicationSetup> SetDisplayName(string displayName)
        {
            await InternalSetDisplayName("DisplayName", displayName);

            return this;
        }

        public async Task<SinglePageAppLegacyApplicationSetup> SetDescription(string description)
        {
            await InternalSetDescription("Description", description);

            return this;
        }

        public async Task<SinglePageAppLegacyApplicationSetup> SetDisplayUrl(string displayUrl)
        {
            await InternalSetDisplayUrl(displayUrl);

            return this;
        }

        public async Task<SinglePageAppLegacyApplicationSetup> SetLogoUrl(string logoUrl)
        {
            await InternalSetLogoUrl(logoUrl);

            return this;
        }

        public async Task<SinglePageAppLegacyCallbackUrlSetup> Next()
        {
            await InternalNext();

            return new SinglePageAppLegacyCallbackUrlSetup(Page);
        }
    }
}
