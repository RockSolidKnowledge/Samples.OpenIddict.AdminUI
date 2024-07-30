using FluentAssertions;
using TestService.Pages;
using TestService.TestCollections.Fixture;

namespace TestService.TestCollections
{
    public class FailAlwaysTest(AdminUiAutoTestFixture testFixture) : AdminUiTest(testFixture)
    {
        [Fact(Skip="Only added to enable quickly testing a failed test scenario")]
        public async Task ClickNonExistentElement()
        {
            const string expectedPageTitle = "OpenIddict";

            WelcomePage.OpenIddictLoginPage page = await GotoTheWebsite()
                .AndThen(p => p.Login("#gdsdghsdkj"));

            string? pageTitle = await page.GetTitle();
            pageTitle.Should().Be(expectedPageTitle);
        }

    }
}
