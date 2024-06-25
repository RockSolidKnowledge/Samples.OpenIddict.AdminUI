using FluentAssertions;
using TestService.Models;
using TestService.Pages;
using TestService.TestCollections.Fixture;
using static TestService.Pages.HomePageViews.Roles.RolesPage;
using Xunit.Extensions.Ordering;

namespace TestService.TestCollections.HomePageViews.RolesView.Editing
{
    [Order(CollectionRunOrder.EditRole)]
    public class Edit(AdminUiAutoTestFixture testFixture) : AdminUiTest(testFixture)
    {
        [Fact(Skip = "Not yet determined is validity as an OpenIddict.AdminUI test"), Order(1)]
        public async Task CanUpdateRole()
        {
            Role updatedRoleDetails = RoleFactory.Create();
            TestFixture.NameOfCurrentRole = updatedRoleDetails.Name;
            Role newRole = RoleFactory.Create();
            
            await AddRole(newRole);

            EditRoleDetailsPage editRoleDetailsPage = await TestFixture.AdminUiHomePage!.GotoTheRolesView()
                .AndThen(rolesPage => rolesPage.GotoTheRole(newRole.Name))
                .AndThen(rolesPage => rolesPage.EditTheRole())
                .AndThen(editRoleDetailDetailsPage => editRoleDetailDetailsPage.SetName(updatedRoleDetails.Name))
                .AndThen(editRoleDetailDetailsPage => editRoleDetailDetailsPage.SetDescription(updatedRoleDetails.Description))
                .AndThen(editRoleDetailDetailsPage => editRoleDetailDetailsPage.Save());

            bool roleWasUpdated = editRoleDetailsPage.IsRoleSuccessfullyUpdated();
            roleWasUpdated.Should().BeTrue();
        }

        [Fact(Skip = "Not yet determined is validity as an OpenIddict.AdminUI test"), Order(2)]
        public async Task CanDeleteRole()
        {
            EditRoleDetailsPage.DeleteRoleConfirmationPage deleteRoleConfirmationPage = await TestFixture.AdminUiHomePage!.GotoTheRolesView()
                .AndThen(rolesPage => rolesPage.GotoTheRole(TestFixture.NameOfCurrentRole!))
                .AndThen(rolesPage => rolesPage!.EditTheRole())
                .AndThen(editRoleDetailsPage => editRoleDetailsPage.DeleteRole())
                .AndThen(deleteConfirmationPage => deleteConfirmationPage.Confirm());

            bool roleWasDeleted = deleteRoleConfirmationPage.IsRoleSuccessfullyDeleted();
            roleWasDeleted.Should().BeTrue();
        }
    }
}
