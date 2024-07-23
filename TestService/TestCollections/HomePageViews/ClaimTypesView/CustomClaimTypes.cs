using FluentAssertions;
using Newtonsoft.Json.Linq;
using TestService.Models;
using TestService.Pages;
using TestService.Pages.HomePageViews.Clients;
using TestService.TestCollections.Fixture;
using TestService.TestCollections.HomePageViews.ClientsView;
using Xunit.Extensions.Ordering;
using static TestService.TestCollections.HomePageViews.ClientsView.SetupInfoFactory;

namespace TestService.TestCollections.HomePageViews.ClaimTypesView
{
    [Order(CollectionRunOrder.AddClaimType)]
    public class CustomClaimTypes(AdminUiAutoTestFixture testFixture) : AdminUiTest(testFixture)
    {
        [Fact, Order(1)]
        public async Task ConfiguredCustomClaimTypeArePresent()
        {
            var configuredClaimTypeNames = await GetCustomAdminUiClaimTypes();

            bool customClaimsAreListed = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                                        .AndThen(p => p.GotoTheClaimTypesView())
                                        .AndThen(p => p.ConfirmClaimsListed(configuredClaimTypeNames));

            customClaimsAreListed.Should().BeTrue();
        }

        private async Task<List<string>> GetCustomAdminUiClaimTypes()
        {
            var path = GetAdminUiAppSettingsJson();

            using StreamReader reader = new(path);
            string jsonString = await reader.ReadToEndAsync();

            var claimTypesJTokens = JObject.Parse(jsonString)["CustomClaimTypes"];

            if (claimTypesJTokens == null)
            {
                return new List<string>();
            }

            return claimTypesJTokens.Select(s => s["Name"].Value<string>()).ToList();
        }

        private static string GetAdminUiAppSettingsJson()
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());

            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }

            return new(directory!.FullName + "\\AdminUI\\appsettings.json");
        }
    }
}
