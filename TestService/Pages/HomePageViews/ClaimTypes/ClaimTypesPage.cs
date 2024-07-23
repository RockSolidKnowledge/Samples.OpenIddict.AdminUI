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

        public async Task<bool> ConfirmClaimsListed(List<string> expectedClaimTypes)
        {
            if (expectedClaimTypes.Count == 0)
            {
                return true;  // We have verified that there are no configured custom claim types in AdminUI appsettings.json
            }

            var allListedClaimTypes = new List<string>();

            int rowCount = await CurrentPage.Locator(".tbody").Locator("tr").CountAsync();

            for (int i = 0; i < rowCount; i++)
            {
                var listedCLaimName = await CurrentPage.Locator(".tbody").Locator("tr").Nth(i).Locator("td").Nth(1).InnerTextAsync();
                if (expectedClaimTypes.Contains(listedCLaimName))
                {
                    expectedClaimTypes.Remove(listedCLaimName);
                }
            }

            return expectedClaimTypes.Count == 0;
        }
    }
}
