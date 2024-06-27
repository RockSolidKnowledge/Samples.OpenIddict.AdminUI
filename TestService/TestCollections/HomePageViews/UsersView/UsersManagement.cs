using FluentAssertions;
using TestService.Models;
using TestService.Pages;
using TestService.Pages.HomePageViews.Roles;
using TestService.Pages.HomePageViews.Users;
using TestService.TestCollections.Fixture;
using Xunit.Extensions.Ordering;
using static TestService.Pages.HomePageViews.Users.UsersPage.Pager.PagerPage.EditUsersPage;

namespace TestService.TestCollections.HomePageViews.UsersView
{
    [Order(CollectionRunOrder.ManagingUsers)]
    public class UsersManagement(AdminUiAutoTestFixture fixture) : AdminUiTest(fixture)
    {
        [Fact(), Order(1)]
        public async Task CanAddANewUser()
        {
            User newUser = UserFactory.CreateUser();
            TestFixture.CurrentUserEmail = newUser.UserName;

            UsersPage.AddUserNewUserPage addUserNewUserPage = await AddUser(newUser);

            bool userWasAdded = addUserNewUserPage.CreatedPopupWasVisible();
            userWasAdded.Should().BeTrue();
        }

        [Fact, Order(2)]
        public async Task CanEditUser()
        {
            User originalUser = UserFactory.CreateUser();
            await AddUser(originalUser);
            User updatedUserDetails = UserFactory.CreateUser();
            TestFixture.CurrentUserEmail = updatedUserDetails.UserName;

            UsersDetailsPage usersDetailsPage = await LoginToAdminUi(AdminUiAutoTestFixture.TestUser.EmailAddress)
                                                    .AndThen(p => p.GotoTheUsersView())
                                                    .AndThen(p => p.EditTheUser(originalUser.UserName))
                                                    .AndThen(p => p.GotoTheUsersDetailsTab())
                                                    .AndThen(p => p.SetFirstName(updatedUserDetails.FirstName))
                                                    .AndThen(p => p.SetLastName(updatedUserDetails.LastName))
                                                    .AndThen(p => p.SetUserName(updatedUserDetails.UserName))
                                                    .AndThen(p => p.SetEmailAddress(updatedUserDetails.EmailAddress))
                                                    .AndThen(p => p.Save());

            bool userWasUpdate = usersDetailsPage.SuccessPopupWasVisible();
            userWasUpdate.Should().BeTrue();
        }

        [Fact, Order(3)]
        public async Task CanChangeTheLockEnabledStatusOfAUser()
        {
            UsersDetailsPage usersDetailsPage = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                                                    .AndThen(p => p.GotoTheUsersView())
                                                    .AndThen(p => p.EditTheUser(TestFixture.CurrentUserEmail!))
                                                    .AndThen(p => p.GotoTheUsersDetailsTab())
                                                    .AndThen(p => p.ChangeTheLockoutStatus())
                                                    .AndThen(p => p.Save());

            bool isTheLockoutStatusChanged = usersDetailsPage.SuccessPopupWasVisible();
            isTheLockoutStatusChanged.Should().BeTrue();
        }

        [Fact, Order(4)]
        public async Task CanChangeThe2FactorAuthenticationEnabledStatusOfAUser()
        {
            // TODO : The caption on the button in OpenIddict.AdminUI should be: "Depending on your OpenIddict implementation ...". It says  ... "IdentityServer" implementation 
            UsersDetailsPage usersDetailsPage = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                                                    .AndThen(p => p.GotoTheUsersView())
                                                    .AndThen(p => p.EditTheUser(TestFixture.CurrentUserEmail!))
                                                    .AndThen(p => p.GotoTheUsersDetailsTab())
                                                    .AndThen(p => p.ChangeThe2FactorAuthenticationStatus())
                                                    .AndThen(p => p.Save());

            bool is2FAuthenticationEnabledOnTheUser = usersDetailsPage.SuccessPopupWasVisible();
            is2FAuthenticationEnabledOnTheUser.Should().BeTrue();
        }

        // If we want to use the same user for all test cases in this collection, we must run this last bc after de-activation, based of the filter applied, the user may no longer be present when the users table is refreshed  
        [Fact, Order(5)]
        public async Task CanChangeTheActiveStatusOfAUser()
        {
            UsersDetailsPage usersDetailsPage = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                .AndThen(p => p.GotoTheUsersView())
                .AndThen(p => p.EditTheUser(TestFixture.CurrentUserEmail!))
                .AndThen(p => p.GotoTheUsersDetailsTab())
                .AndThen(p => p.ChangeTheActiveStatus())
                .AndThen(p => p.Save());

            bool theActiveStatusWasChanged = usersDetailsPage.SuccessPopupWasVisible();
            theActiveStatusWasChanged.Should().BeTrue();
        }

        [Fact, Order(6)]
        public async Task CanDeleteUser()
        {
            // After deactivation, based on filtering, the user may not be available to be deleted, so we will need to add the item we intend to delete   
            User userToBeDeleted = UserFactory.CreateUser();
            await AddUser(userToBeDeleted);

            UsersDetailsPage.DeleteUserConfirmationPage deleteUserConfirmationPage = await LoginToAdminUi(AdminUiAutoTestFixture.TestUser.EmailAddress)
                .AndThen(p => p.GotoTheUsersView())
                .AndThen(p => p.EditTheUser(userToBeDeleted.UserName))
                .AndThen(p => p.GotoTheUsersDetailsTab())
                .AndThen(p => p.Delete())
                .AndThen(p => p.Confirm());

            bool userWasDeleted = deleteUserConfirmationPage.SuccessPopupWasVisible();
            userWasDeleted.Should().BeTrue();
        }
        
        [Fact, Order(7)]
        public async Task CanAssignAndUnAssignARole()
        {
            Role newRole = RoleFactory.Create();
            User newUser = UserFactory.CreateUser();

            UsersPage.AddUserNewUserPage addUserNewUserPage = await AddUser(newUser);

            bool userWasAdded = addUserNewUserPage.CreatedPopupWasVisible();
            userWasAdded.Should().BeTrue();

            // We're already logged in to add the role, so we can use TestFixture.AdminUiHomePage to navigate through the views 
            RolesPage.AddRoleNewRolePage addRoleNewRolePage = await TestFixture.AdminUiHomePage!
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
    }
}
