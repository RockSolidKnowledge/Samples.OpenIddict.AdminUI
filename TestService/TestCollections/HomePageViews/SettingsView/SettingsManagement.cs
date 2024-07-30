using FluentAssertions;
using TestService.Models;
using TestService.Pages;
using TestService.Pages.HomePageViews.Settings.AccessPolicy;
using TestService.Pages.HomePageViews.Settings.Webhooks;
using TestService.TestCollections.Fixture;
using Xunit.Extensions.Ordering;

namespace TestService.TestCollections.HomePageViews.SettingsView
{
    [Order(CollectionRunOrder.ManageSettings)]
    public class SettingsManagement(AdminUiAutoTestFixture fixture) : AdminUiTest(fixture)
    {
        [Fact, Order(1)]
        public async Task AccessPolicies_ShouldDisplayConfiguredAccessPolicies()
        {
            SettingsAccessPolicyPage page = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                .AndThen(p => p.GotoTheSettingsView())
                .AndThen(p => p.SelectAccessPolicy());

            bool result = await page.AreConfiguredAccessPoliciesListedAndAsExpected("role", "Role c4eba9df-e83c-4325-bda5-1b0a151d008e", "User Manager Read Only");
            result.Should().BeTrue();

            result = await page.AreConfiguredAccessPoliciesListedAndAsExpected("role", "Role c4eba9df-e83c-4325-bda5-1b0a151d008e", "All");
            result.Should().BeTrue();

            result = await page.AreConfiguredAccessPoliciesListedAndAsExpected("<any-string>", "<any-string>", "All");
            result.Should().BeTrue();
        }

        [Fact, Order(2)]
        public async Task WebHooks_ShouldDisplayConfiguredAndNonConfiguredHooks()
        {
            SettingsWebhooksPage page = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                .AndThen(p => p.GotoTheSettingsView())
                .AndThen(p => p.SelectWebhooks());

            bool result = await page.IsWebHookConfigured("Multi-factor Authentication Reset", "https://dosomething.com/mfa-reset", "scope-mfa");
            result.Should().BeTrue();

            result = await page.IsWebHookConfigured("Password Reset", "https://dosomething.com/pass-reset", "scope-pres scope-b");
            result.Should().BeTrue();

            result = await page.IsWebHookConfigured("Server Side Session Deletion", "https://dosomething.com/server-side-session", "scope-sss");
            result.Should().BeTrue();

            result = await page.IsWebHookNotConfigured("User Registration");
            result.Should().BeTrue();
        }
    }
}
