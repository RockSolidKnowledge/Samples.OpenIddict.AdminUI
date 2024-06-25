using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients
{
    public abstract class ExtendedClientSetup(IPage page) : ApplicationIdentitySetup(page)
    {
        protected async Task InternalSetDisplayUrl(string displayUrl)
        {
            await Page.Locator("#Domain").FillAsync(displayUrl);
        }

        protected async Task InternalSetLogoUrl(string logoUrl)
        {
            await Page.Locator("#LogoUrl").FillAsync(logoUrl);
        }
    }
}
