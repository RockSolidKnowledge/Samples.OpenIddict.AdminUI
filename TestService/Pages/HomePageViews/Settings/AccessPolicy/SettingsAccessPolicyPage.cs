using Microsoft.Playwright;
using TestService.Pages.HomePageViews.Clients;

namespace TestService.Pages.HomePageViews.Settings.AccessPolicy
{
    public class SettingsAccessPolicyPage(IPage currentPage) : TestPage(currentPage)
    {

        public async Task<bool> AreConfiguredAccessPoliciesListedAndAsExpected(string claimType, string claimValue, string accessPermission)
        {
            var rows = await CurrentPage.Locator("tbody").Locator("tr").AllAsync();

            foreach (var row in rows)
            {
                var type = await row.Locator("td").Nth(0).InnerTextAsync();

                if (type == claimType)
                {
                    var value = await row.Locator("td").Nth(1).InnerTextAsync();

                    if (value == claimValue)
                    {
                        var permission = await row.Locator("td").Nth(2).InnerTextAsync();

                        if (permission == accessPermission)
                        {
                            return true;
                        }

                    }
                }
            }

            return false;
        }
    }
}
