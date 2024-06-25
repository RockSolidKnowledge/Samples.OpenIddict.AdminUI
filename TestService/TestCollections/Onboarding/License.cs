using FluentAssertions;
using TestService.Pages;
using TestService.TestCollections.Fixture;
using Xunit.Extensions.Ordering;

namespace TestService.TestCollections.Onboarding
{
    [Order(CollectionRunOrder.LicenseValidation)]
    public class License(AdminUiAutoTestFixture adminUiAutoTests) : AdminUiTest(adminUiAutoTests)
    {
        [Fact]
        public async Task ShouldVerifyUserLicenseHasNotExpired()
        {
            LicensePage? page = await GotoTheWebsite()
                .AndThen(p => p.LogIn())
                .AndThen(p => p.SetUserEmail("info@rocksolidknowledge.com"))
                .AndThen(p => p.SetPassword(AdminUiAutoTestFixture.DefaultPassword))
                .AndThen(p => p.LoginToBootstrapAdminUser())
                .AndThen(p => p.GetLicenseInfo());

            page.Should().NotBeNull();

            bool licenseHasNotExpired = !await page!.IsLicenseExpired();
            licenseHasNotExpired.Should().BeTrue();
        }
    }
}
