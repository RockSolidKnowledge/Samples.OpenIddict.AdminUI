using FluentAssertions;
using TestService.Models;
using TestService.Pages;
using TestService.Pages.HomePageViews.Clients;
using TestService.TestCollections.Fixture;
using TestService.TestCollections.HomePageViews.ClientsView;
using Xunit.Extensions.Ordering;
using static TestService.TestCollections.HomePageViews.ClientsView.SetupInfoFactory;

namespace TestService.TestCollections.HomePageViews.SettingsView
{
    [Order(CollectionRunOrder.ManageSettings)]
    public class SettingsManagement(AdminUiAutoTestFixture fixture) : AdminUiTest(fixture)
    {
        [Fact, Order(1)]
        public async Task ConfiguredCustomAccessPoliciesShouldBeListedInAccessPolicyTable()
        {
            var configuredAccessPolicies = new List<AccessPolicySetupInfo>
            {
                new 
                (
                    "role",
                    "Role c4eba9df-e83c-4325-bda5-1b0a151d008e",
                    "UserManagerReadOnly"
                ),
                new
                (
                    "role",
                    "Role c4eba9df-e83c-4325-bda5-1b0a151d008e",
                    "All"
                ),
                new
                (
                    "<any-string>",
                    "<any-string>",
                    "All"
                )
            };

            bool customClaimsAreListed = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                .AndThen(p => p.GotoTheSettingsView())
                .AndThen(p => p.SelectAccessPolicy())
                .AndThen(p => p.ConfirmConfiguredAccessPoliciesAreListed(configuredAccessPolicies));

            customClaimsAreListed.Should().BeTrue();
        }

        [Fact, Order(2)]
        public async Task ConfiguredWebhooksShouldBeListedAndEnabled()
        {
            SetupInfoFactory.WebhooksConfig webhooksConfig = SetupInfoFactory.CreateWebhooksConfiguration();

            bool webhooksVerified = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                .AndThen(p => p.GotoTheSettingsView())
                .AndThen(p => p.SelectWebhooks())
                .AndThen(p => p.ConfirmConfiguredWebhooksAreListedAndEnabled(webhooksConfig));

            webhooksVerified.Should().BeTrue();
        }
    }
}
