using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients
{
    public abstract class ResourceAssigner(IPage page) : SetupDialog(page)
    {
        public async Task InternalAssignResources(List<string> resources)
        {
            foreach (string resource in resources)
            {
                await Page
                    .Locator("app-common-picker")
                    .Filter(new() { HasText = "Available" })
                    .Locator("#unassignedItems")
                    .GetByText(resource, new() { Exact = true })
                    .ClickAsync();
            }

            await Page.Locator("#assignBtn").ClickAsync();
        }

        public async Task InternalAssignResources(int index)
        {
            await Page
                .Locator("app-common-picker")
                .Filter(new LocatorFilterOptions { HasText = "Available" })
                .Locator("#unassignedItems")
                .Nth(index)
                .ClickAsync();
            
            await Page.Locator("#assignBtn").ClickAsync();
        }
    }
}
