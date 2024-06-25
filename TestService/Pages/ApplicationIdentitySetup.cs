using Microsoft.Playwright;
using TestService.Pages.HomePageViews.Clients;

namespace TestService.Pages
{
    public abstract class ApplicationIdentitySetup(IPage page) : SetupDialog(page)
    {
        protected async Task InternalSetUniqueIdentifier(string elementId, string guid)
        {
            await FillElement(elementId, guid);
        }

        protected async Task InternalSetDisplayName(string elementId, string displayName)
        {
            await FillElement(elementId, displayName);
        }

        protected async Task InternalSetDescription(string elementId, string description)
        {
            await FillElement(elementId, description);
        }

        private async Task FillElement(string id, string value)
        {
            await Page.Locator($"#{id}").FillAsync(value);
        }
    }
}
