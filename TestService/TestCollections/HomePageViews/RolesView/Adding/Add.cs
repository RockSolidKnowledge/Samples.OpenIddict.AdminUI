using FluentAssertions;
using TestService.Models;
using TestService.TestCollections.Fixture;
using Xunit.Extensions.Ordering;
using static TestService.Pages.HomePageViews.Roles.RolesPage;

namespace TestService.TestCollections.HomePageViews.RolesView.Adding
{
    [Order(CollectionRunOrder.AddRole)]
    public class Add(AdminUiAutoTestFixture fixture) : AdminUiTest(fixture)
    {
        [Fact(Skip = "Not yet determined is validity as an OpenIddict.AdminUI test"), Order(1)]
        public async Task CanAddANewRole()
        {
            Role newRole = RoleFactory.Create();
            TestFixture.NameOfCurrentRole = newRole.Name;

            AddRoleNewRolePage addRoleNewRolePage = await AddRole(newRole);

            bool roleWasSuccessfullyAdded = addRoleNewRolePage.IsRoleSuccessfullyCreated();
            roleWasSuccessfullyAdded.Should().BeTrue(); ;
        }
    }
}
