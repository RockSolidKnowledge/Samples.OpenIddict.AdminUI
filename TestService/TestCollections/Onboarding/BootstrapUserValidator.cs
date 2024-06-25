using FluentAssertions;
using TestService.Models;
using TestService.Pages;
using TestService.Pages.HomePageViews.Users;
using TestService.TestCollections.Fixture;
using Xunit.Extensions.Ordering;

namespace TestService.TestCollections.Onboarding
{
    [Order(CollectionRunOrder.BootstrapValidation)]
    public class BootstrapUserValidator(AdminUiAutoTestFixture testFixture) : AdminUiTest(testFixture)
    {
        [Fact, Order(1)]
        public async Task AfterBootstrapping_TheUserIsPresentInTheUsersTable()
        {
            User testUser = AdminUiAutoTestFixture.TestUser;
            TestFixture.NameOfCurrentUser = testUser.UserName;

            string userName = TestFixture.NameOfCurrentUser!;

            UsersPage page = await LoginToAdminUi(testUser.UserName)
                .AndThen(p => p.GotoTheUsersView());

            bool userIsPresent = await page.IsTheUserPresent(testUser.UserName);
            userIsPresent.Should().BeTrue();
        }

        [Fact, Order(2)]
        public async Task AfterBootstrapping_TheUserIsAssignedTheAdminUIAdministratorRole()
        {
            string userName = TestFixture.NameOfCurrentUser!;

            UsersPage.Pager.PagerPage.EditUsersPage.UsersRolesPage usersRolesPage = await LoginToAdminUi(userName)
                .AndThen(p => p.GotoTheUsersView())
                .AndThen(p => p.EditTheUser(userName))
                .AndThen(p => p.GotoTheUsersRolesTab());

            bool roleHasRoleAdminRole = await usersRolesPage.IsAssigned(RoleFactory.GetAdministratorRoleName());
            roleHasRoleAdminRole.Should().BeTrue();
        }
    }
}
