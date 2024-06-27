using FluentAssertions;
using TestService.Models;
using TestService.Pages;
using TestService.TestCollections.Fixture;
using static TestService.Pages.HomePageViews.Roles.RolesPage;
using Xunit.Extensions.Ordering;
namespace TestService.TestCollections.HomePageViews.RolesView
{
    [Order(CollectionRunOrder.ManagingRoles)]
    public class RolesManagement(AdminUiAutoTestFixture fixture) : AdminUiTest(fixture)
    {
        [Fact, Order(1)]
        public async Task CanAddANewRole()
        {
            Role newRole = RoleFactory.Create();
            
            AddRoleNewRolePage addRoleNewRolePage = await AddRole(newRole);

            bool roleWasSuccessfullyAdded = addRoleNewRolePage.IsRoleSuccessfullyCreated();
            roleWasSuccessfullyAdded.Should().BeTrue();

            TestFixture.CurrentRoleName = newRole.Name;
        }

        [Fact, Order(2)]
        public async Task CanUpdateRole()
        {
            Role updatedRoleDetails = RoleFactory.Create();

            EditRoleDetailsPage editRoleDetailsPage = await TestFixture.AdminUiHomePage!.GotoTheRolesView()
                .AndThen(rolesPage => rolesPage.GotoTheRole(TestFixture.CurrentRoleName!))
                .AndThen(rolesPage => rolesPage.EditTheRole())
                .AndThen(editRoleDetailDetailsPage => editRoleDetailDetailsPage.SetName(updatedRoleDetails.Name))
                .AndThen(editRoleDetailDetailsPage => editRoleDetailDetailsPage.SetDescription(updatedRoleDetails.Description))
                .AndThen(editRoleDetailDetailsPage => editRoleDetailDetailsPage.Save());

            bool roleWasUpdated = editRoleDetailsPage.IsRoleSuccessfullyUpdated();
            roleWasUpdated.Should().BeTrue();

            TestFixture.CurrentRoleName = updatedRoleDetails.Name;
        }

        [Fact, Order(3)]
        public async Task CanDeleteRole()
        {
            EditRoleDetailsPage.DeleteRoleConfirmationPage deleteRoleConfirmationPage = await TestFixture.AdminUiHomePage!.GotoTheRolesView()
                .AndThen(rolesPage => rolesPage.GotoTheRole(TestFixture.CurrentRoleName!))
                .AndThen(rolesPage => rolesPage!.EditTheRole())
                .AndThen(editRoleDetailsPage => editRoleDetailsPage.DeleteRole())
                .AndThen(deleteConfirmationPage => deleteConfirmationPage.Confirm());

            bool roleWasDeleted = deleteRoleConfirmationPage.IsRoleSuccessfullyDeleted();
            roleWasDeleted.Should().BeTrue();

            TestFixture.CurrentRoleName = null;
        }
    }
}
