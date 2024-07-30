using FluentAssertions;
using Newtonsoft.Json.Linq;
using TestService.Models;
using TestService.Pages;
using TestService.Pages.HomePageViews.ClaimTypes;
using TestService.TestCollections.Fixture;
using Xunit.Extensions.Ordering;

namespace TestService.TestCollections.HomePageViews.ClaimTypesView
{
    [Order(CollectionRunOrder.AddClaimType)]
    public class CustomClaimTypes(AdminUiAutoTestFixture testFixture) : AdminUiTest(testFixture)
    {
        [Fact, Order(1)]
        public async Task ClaimTypes_ConfiguredClaimTypesShouldBeListedInClaimTypesTable()
        {
            var configuredClaimTypeNames = new List<string>() { "playwright_test1", "playwright_test2" };

            ClaimTypesPage page = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                                                        .AndThen(p => p.GotoTheClaimTypesView());

            bool claimsAreListed = await page.ConfirmConfiguredClaimTypesAreListed(configuredClaimTypeNames);
            claimsAreListed.Should().BeTrue();
        }
    }
}
