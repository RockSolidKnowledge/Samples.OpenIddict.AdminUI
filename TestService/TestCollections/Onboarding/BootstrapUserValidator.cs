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
            User user = AdminUiAutoTestFixture.TestUser;
            
            UsersPage page = await LoginToAdminUi(user.EmailAddress)
                .AndThen(p => p.GotoTheUsersView());

            bool userIsPresent = await page.IsTheUserPresent(user.UserName);
            userIsPresent.Should().BeTrue();
        }

        [Fact, Order(2)]
        public async Task AfterBootstrapping_TheUserIsAssignedTheAdminUIAdministratorRole()
        {
            User user = AdminUiAutoTestFixture.TestUser;

            UsersPage.Pager.PagerPage.EditUsersPage.UsersRolesPage usersRolesPage = await LoginToAdminUi(user.EmailAddress)
                .AndThen(p => p.GotoTheUsersView())
                .AndThen(p => p.EditTheUser(user.UserName))
                .AndThen(p => p.GotoTheUsersRolesTab());

            bool roleHasRoleAdminRole = await usersRolesPage.IsAssigned(RoleFactory.GetAdministratorRoleName());
            roleHasRoleAdminRole.Should().BeTrue();
        }
    }
}
