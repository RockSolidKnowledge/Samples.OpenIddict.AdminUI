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

        public async Task<bool> ConfirmConfiguredClaimTypesAreListed(List<string> expectedClaimTypes)
        {
            bool allConfiguredClaimTypesAreListed = false;
            int expectedListedCount = expectedClaimTypes.Count;

            if (expectedListedCount == 0)
            {
                return true;  // We have verified that there are no configured custom claim types in AdminUI appsettings.json
            }


            var rows = await CurrentPage.Locator("tbody").Locator("tr").AllAsync();

            var numberFound = 0;

            foreach (var row in rows)
            {
                var listedCLaimName = await row.Locator("td").Nth(0).InnerTextAsync();

                if (expectedClaimTypes.Contains(listedCLaimName))
                {
                    if (++numberFound == expectedListedCount)
                    {
                        allConfiguredClaimTypesAreListed = true;
                        break;
                    }
                }
            }

            return allConfiguredClaimTypesAreListed;
        }
    }
}
