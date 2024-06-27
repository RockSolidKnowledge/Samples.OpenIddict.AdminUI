using FluentAssertions;
using Microsoft.Playwright;
using TestService.Models;
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
            const string expectedPageTitle = "Log in - Velusia.Server";

            WelcomePage.OpenIddictLoginPage page = await GotoTheWebsite()
                .AndThen(p => p.LogIn());

            string? pageTitle = await page.GetTitle();
            pageTitle.Should().Be(expectedPageTitle);
        }

        [Fact, Order(3)]
        public async Task AfterSuccessfulAuthenticationWithOpenIddict_UserCanLogIn()
        {
            User user = AdminUiAutoTestFixture.TestUser;

            AdminUiHomePage page = await LoginToAdminUi(user.EmailAddress);

            string loggedInUser = await page.GetLoggedInUser();
            loggedInUser.Should().Be(user.UserName);
        }

        [Fact, Order(4)]
        public async Task FromAdminUI_UserCanLogout()
        {
            User user = AdminUiAutoTestFixture.TestUser;

            await LoginToAdminUi(user.EmailAddress)
                .AndThen(p => p.Logout())
                .AndThen(p => p.AcceptToLogout());

            var cookieCount = (await TestFixture.Browser!.Contexts[0].CookiesAsync()).Count(c => c.Name.StartsWith("AdminUI"));
            cookieCount.Should().Be(0);
        }
    }
}
