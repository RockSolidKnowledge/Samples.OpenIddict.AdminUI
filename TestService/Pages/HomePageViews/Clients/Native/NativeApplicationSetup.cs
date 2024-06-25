using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.Native
{
    public class NativeApplicationSetup(IPage page) : ExtendedClientSetup(page)
    {
        public async Task<NativeApplicationSetup> SetUniqueIdentifier(string guid)
        {
            await InternalSetUniqueIdentifier("ClientId", guid);

            return this;
        }

        public async Task<NativeApplicationSetup> SetDisplayName(string displayName)
        {
            await InternalSetDisplayName("DisplayName", displayName);

            return this;
        }

        public async Task<NativeApplicationSetup> SetDescription(string description)
        {
            await InternalSetDescription("Description", description);

            return this;
        }

        public async Task<NativeApplicationSetup> SetDisplayUrl(string displayUrl)
        {
            await InternalSetDisplayUrl(displayUrl);

            return this;
        }

        public async Task<NativeApplicationSetup> SetLogoUrl(string logoUrl)
        {
            await InternalSetLogoUrl(logoUrl);

            return this;
        }

        public async Task<NativeAppCallbackUrlSetup> Next()
        {
            await InternalNext();

            return new NativeAppCallbackUrlSetup(Page);
        }
    }
}
