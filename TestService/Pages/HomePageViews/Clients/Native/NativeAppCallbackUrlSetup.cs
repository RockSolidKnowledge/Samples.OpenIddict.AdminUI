using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.Native
{
    public class NativeAppCallbackUrlSetup(IPage page) : CallbackUrlSetup(page)
    {
        public async Task<NativeAppCallbackUrlSetup> SetCallbackUrl(string url)
        {
            await InternalSetCallbackUrl(url);

            return this;
        }

        public async Task<NativeAppSecretsSetup> Next()
        {
            await InternalNext();

            return new NativeAppSecretsSetup(Page);
        }
    }
}
