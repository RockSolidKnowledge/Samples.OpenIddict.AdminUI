using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.WebApp
{
    public class WebApplicationSetup(IPage page) : ExtendedClientSetup(page)
    {
        public async Task<WebApplicationSetup> SetUniqueIdentifier(string guid)
        {
            await InternalSetUniqueIdentifier("ClientId", guid);

            return this;
        }

        public async Task<WebApplicationSetup> SetDisplayName(string displayName)
        {
            await InternalSetDisplayName("DisplayName", displayName);

            return this;
        }

        public async Task<WebApplicationSetup> SetDescription(string description)
        {
            await InternalSetDescription("Description", description);

            return this;
        }

        public async Task<WebApplicationSetup> SetDisplayUrl(string displayUrl)
        {
            await InternalSetDisplayUrl(displayUrl);

            return this;
        }

        public async Task<WebApplicationSetup> SetLogoUrl(string logoUrl)
        {
            await InternalSetLogoUrl(logoUrl);

            return this;
        }

        public async Task<WebAppCallbackUrlSetup> Next()
        {
            await InternalNext();

            return new WebAppCallbackUrlSetup(Page);
        }
    }
}
