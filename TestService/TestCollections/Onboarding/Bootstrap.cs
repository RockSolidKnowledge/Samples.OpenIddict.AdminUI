using FluentAssertions;
using TestService.Models;
using TestService.Pages;
using TestService.TestCollections.Fixture;
using Xunit.Extensions.Ordering;

namespace TestService.TestCollections.Onboarding
{
    [Order(CollectionRunOrder.Bootstrap)]
    public class Bootstrap(AdminUiAutoTestFixture adminUiAutoTests) : AdminUiTest(adminUiAutoTests)
    {
        [Fact, Order(1)]
        public async Task DuringOnboarding_TheUserCanBootstrapAUserAndLoginAsTheNewUser()
        {
            User testUser = AdminUiAutoTestFixture.TestUser;
            string password = AdminUiAutoTestFixture.DefaultPassword;

            AdminUiHomePage page = await GotoTheWebsite()
                .AndThen(p => p.LogIn())
                .AndThen(p => p.SetUserEmail("info@rocksolidknowledge.com"))
                .AndThen(p => p.SetPassword(password))
                .AndThen(p => p.LoginToBootstrapAdminUser())
                .AndThen(p => p.SetFirstName(testUser.FirstName))
                .AndThen(p => p.SetLastName(testUser.LastName))
                .AndThen(p => p.SetUserName(testUser.UserName))
                .AndThen(p => p.SetEmailAddress(testUser.EmailAddress))
                .AndThen(p => p.SetPassword(password))
                .AndThen(p => p.SetConfirmedPassword(password))
                .AndThen(p => p.Save())
                .AndThen(p => p.Login())
                .AndThen(p => p.LogIn())
                .AndThen(p => p.SetUserEmail(testUser.EmailAddress))
                .AndThen(p => p.SetPassword(password))
                .AndThen(p => p.Login());

            // await LoginToAdminUi(testUser.EmailAddress);

            string loggedInUser = await page.GetLoggedInUser();
            loggedInUser.Should().Be(testUser.UserName);
        }
    }
}
