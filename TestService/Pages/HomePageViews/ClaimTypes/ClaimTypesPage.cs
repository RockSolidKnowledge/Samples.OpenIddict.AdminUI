using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.ClaimTypes
{
    public class ClaimTypesPage(IPage currentPage) : TestPage(currentPage)
    {
        public async Task<NewClaimTypeSetup> AddClaimType()
        {
            await CurrentPage.GetByRole(AriaRole.Button, new() { Name = " Add Claim Type " }).ClickAsync();

            await CurrentPage.WaitForSelectorAsync("#type");

            return new NewClaimTypeSetup(CurrentPage);
        }
    }
}
