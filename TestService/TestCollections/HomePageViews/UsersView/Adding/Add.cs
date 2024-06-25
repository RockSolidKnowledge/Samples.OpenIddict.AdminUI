using FluentAssertions;
using TestService.Models;
using TestService.Pages.HomePageViews.Users;
using TestService.TestCollections.Fixture;
using Xunit.Extensions.Ordering;

namespace TestService.TestCollections.HomePageViews.UsersView.Adding
{
    [Order(CollectionRunOrder.AddUser)]
    public class Add(AdminUiAutoTestFixture fixture) : AdminUiTest(fixture)
    {
        [Fact(), Order(1)]
        public async Task CanAddANewUser()
        {
            User newUser = UserFactory.CreateUser();
            TestFixture.NameOfCurrentUser = newUser.UserName;

            UsersPage.AddUserNewUserPage addUserNewUserPage = await AddUser(newUser);

            bool userWasAdded = addUserNewUserPage.CreatedPopupWasVisible();
            userWasAdded.Should().BeTrue();
        }
    }
}