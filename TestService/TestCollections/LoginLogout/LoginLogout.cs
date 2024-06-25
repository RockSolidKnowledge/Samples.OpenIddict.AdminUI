using FluentAssertions;
using Microsoft.Playwright;
using TestService.Pages;
using TestService.TestCollections.Fixture;
using Xunit.Extensions.Ordering;

namespace TestService.TestCollections.LoginLogout
{
    [Order(CollectionRunOrder.LoginLogout)]
    public class LoginLogout(AdminUiAutoTestFixture fixture) : AdminUiTest(fixture)
    {
        [Fact, Order(1)]
        public async Task DuringLogin_UserShouldFirstBeTakenToTheWelcomePage()
        {
            WelcomePage page = await GotoTheWebsite();

            string mainHeader = await page.GetMainHeader();
            mainHeader.Should().Be("Welcome to AdminUI");
        }

        [Fact, Order(2)]
        public async Task FromTheWelcomePage_UserIsTakenToOpenIddict()
        {
            const string expectedPageTitle = "OpenIddict";

            WelcomePage.OpenIddictLoginPage page = await GotoTheWebsite()
                .AndThen(p => p.LogIn());

            string? pageTitle = await page.GetTitle();
            pageTitle.Should().Be(expectedPageTitle);
        }

        [Fact, Order(3)]
        public async Task AfterSuccessfulAuthenticationWithOpenIddict_UserCanLogIn()
        {
            string testUserEmail = AdminUiAutoTestFixture.TestUser.EmailAddress;

            AdminUiHomePage page = await LoginToAdminUi(testUserEmail);

            string loggedInUser = await page.GetLoggedInUser();
            loggedInUser.Should().Be(testUserEmail);
        }

        [Fact, Order(4)]
        public async Task FromAdminUI_UserCanLogoutAndReturnToTheWelcomePage()
        {
            const string expectedPageTitle = "AdminUI";
            string testUserEmail = AdminUiAutoTestFixture.TestUser.EmailAddress;

            IPage page = await LoginToAdminUi(testUserEmail)
                .AndThen(p => p.Logout());

            string? pageTitle = await TheTitleOfThePage(page);
            pageTitle.Should().Be(expectedPageTitle);
            var cookieCount =
                (await TestFixture.Browser!.Contexts[0].CookiesAsync()).Count(c =>
                    c.Name.StartsWith("AdminUI"));
            cookieCount.Should().Be(0);
        }
    }
}
