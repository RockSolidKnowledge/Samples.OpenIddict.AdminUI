using FluentAssertions;
using TestService.Models;
using TestService.Pages;
using TestService.TestCollections.Fixture;
using Xunit.Extensions.Ordering;
using static TestService.Pages.HomePageViews.Users.UsersPage.Pager.PagerPage.EditUsersPage;

namespace TestService.TestCollections.HomePageViews.UsersView.Editing
{
    [Order(CollectionRunOrder.EditUsersDetails)]
    public class EditUsersDetails(AdminUiAutoTestFixture test) : AdminUiTest(test)
    {
        [Fact, Order(1)]
        public async Task CanEditUser()
        {
            User originalUser = UserFactory.CreateUser();
            await AddUser(originalUser);
            User updatedUserDetails = UserFactory.CreateUser();
            TestFixture.NameOfCurrentUser = updatedUserDetails.UserName;

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

        [Fact, Order(2)]
        public async Task CanChangeTheLockEnabledStatusOfAUser()
        {
            UsersDetailsPage usersDetailsPage = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                                                    .AndThen(p => p.GotoTheUsersView())
                                                    .AndThen(p => p.EditTheUser(TestFixture.NameOfCurrentUser!))
                                                    .AndThen(p => p.GotoTheUsersDetailsTab())
                                                    .AndThen(p => p.ChangeTheLockoutStatus())
                                                    .AndThen(p => p.Save());

            bool isTheLockoutStatusChanged = usersDetailsPage.SuccessPopupWasVisible();
            isTheLockoutStatusChanged.Should().BeTrue();
        }

        [Fact, Order(3)]
        public async Task CanChangeThe2FactorAuthenticationEnabledStatusOfAUser()
        {
            // TODO : The caption on the button in OpenIddict.AdminUI should be: "Depending on your OpenIddict implementation ...". It says  ... "IdentityServer" implementation 
            UsersDetailsPage usersDetailsPage = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                                                    .AndThen(p => p.GotoTheUsersView())
                                                    .AndThen(p => p.EditTheUser(TestFixture.NameOfCurrentUser!))
                                                    .AndThen(p => p.GotoTheUsersDetailsTab())
                                                    .AndThen(p => p.ChangeThe2FactorAuthenticationStatus())
                                                    .AndThen(p => p.Save());

            bool is2FAuthenticationEnabledOnTheUser = usersDetailsPage.SuccessPopupWasVisible();
            is2FAuthenticationEnabledOnTheUser.Should().BeTrue();
        }

        // If we want to use the same user for all test cases in this collection, we must run this last bc after de-activation, based of the filter applied, the user may no longer be present when the users table is refreshed  
        [Fact, Order(4)]
        public async Task CanChangeTheActiveStatusOfAUser()
        {
            UsersDetailsPage usersDetailsPage = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                .AndThen(p => p.GotoTheUsersView())
                .AndThen(p => p.EditTheUser(TestFixture.NameOfCurrentUser!))
                .AndThen(p => p.GotoTheUsersDetailsTab())
                .AndThen(p => p.ChangeTheActiveStatus())
                .AndThen(p => p.Save());

            bool theActiveStatusWasChanged = usersDetailsPage.SuccessPopupWasVisible();
            theActiveStatusWasChanged.Should().BeTrue();
        }

        [Fact, Order(5)]
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
    }
}
