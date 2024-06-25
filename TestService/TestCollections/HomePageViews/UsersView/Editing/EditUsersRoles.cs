using Xunit.Extensions.Ordering;
using TestService.Models;
using FluentAssertions;
using TestService.Pages;
using TestService.TestCollections.Fixture;
using static TestService.Pages.HomePageViews.Roles.RolesPage;
using TestService.Pages.HomePageViews.Users;
using System.Data;

namespace TestService.TestCollections.HomePageViews.UsersView.Editing
{
    [Order(CollectionRunOrder.EditUsersRoles)]
    public class EditUsersRoles(AdminUiAutoTestFixture fixture) : AdminUiTest(fixture)
    {
        [Fact, Order(1)]
        public async Task CanAssignAndUnAssignARole()
        {
            Role newRole = RoleFactory.Create();
            User newUser = UserFactory.CreateUser();

            UsersPage.AddUserNewUserPage addUserNewUserPage = await AddUser(newUser);

            bool userWasAdded = addUserNewUserPage.CreatedPopupWasVisible();
            userWasAdded.Should().BeTrue();

            // We're already logged in to add the role, so we can use TestFixture.AdminUiHomePage to navigate through the views 
            AddRoleNewRolePage addRoleNewRolePage = await TestFixture.AdminUiHomePage!
                .GotoTheRolesView()
                .AndThen(p => p.GotoAddARole())
                .AndThen(p => p.SetName(newRole.Name))
                .AndThen(p => p.SetDescription(newRole.Description))
                .AndThen(p => p.Save());

            bool roleWasAdded = addRoleNewRolePage.IsRoleSuccessfullyCreated();
            roleWasAdded.Should().BeTrue();

            UsersPage.Pager.PagerPage.EditUsersPage.UsersRolesPage usersRolesPage = await TestFixture.AdminUiHomePage!
                    .GotoTheUsersView()
                    .AndThen(p => p.EditTheUser(newUser.UserName))
                    .AndThen(p => p.GotoTheUsersRolesTab())
                    .AndThen(p => p.AssignTheRole(newRole.Name));

            bool theRoleWasAssigned = usersRolesPage.SuccessPopupShowed();
            theRoleWasAssigned.Should().BeTrue();

            usersRolesPage = await usersRolesPage.UnAssignTheRole(newRole.Name);

            bool theRoleWasUnAssigned = usersRolesPage.SuccessPopupShowed();
            theRoleWasUnAssigned.Should().BeTrue();
        }

        //private async Task<UsersPage.Pager.PagerPage.EditUsersPage.UsersRolesPage> GotoTheUsersRolesTab(User newUser)
        //{
        //    return await LoginToAdminUi(AdminUiAutoTestFixture.TestUser.EmailAddress)
        //                .AndThen(p => p.GotoTheUsersView())
        //                .AndThen(p => p.EditTheUser(newUser.UserName))
        //                .AndThen(p => p.GotoTheUsersRolesTab());
        //}
    }
}
