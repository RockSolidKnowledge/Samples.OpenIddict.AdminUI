using FluentAssertions;
using TestService.Models;
using TestService.Pages;
using TestService.Pages.HomePageViews.Clients;
using TestService.TestCollections.Fixture;
using TestService.TestCollections.HomePageViews.ClientsView;
using Xunit.Extensions.Ordering;

namespace TestService.TestCollections.HomePageViews.ResourcesView.Adding
{
    [Order(CollectionRunOrder.AddIdentityResource)]
    public class Identity(AdminUiAutoTestFixture test) : AdminUiTest(test)
    {
        [Fact(Skip = "Not yet determined is validity as an OpenIddict.AdminUI test"), Order(1)]
        public async Task CanAddAnIdentityResource()
        {
            SetupInfoFactory.ResourceSetupInfo setupInfo = SetupInfoFactory.CreateResourceSetupInfo(SetupInfoFactory.ResourceType.Identity);
            TestFixture.NameOfCurrentResource = setupInfo.IdentificationSetupInfo.DisplayName;

            ISaveDialog saveDialog = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                .AndThen(p => p.GotoTheResourcesView())
                .AndThen(p => p.SelectIdentityResource())
                .AndThen(p => p.AddResource())
                .AndThen(s => s.SetUniqueIdentifier(setupInfo.IdentificationSetupInfo.UniqueIdentifier))
                .AndThen(s => s.SetDisplayName(setupInfo.IdentificationSetupInfo.DisplayName))
                .AndThen(s => s.SetDescription(setupInfo.IdentificationSetupInfo.Description))
                .AndThen(s => s.Next())
                .AndThen(s => s.AssignResources(setupInfo.ResourceSettings.IdentityResources))
                .AndThen(s => s.Save());


            bool resourceWasAdded = saveDialog.SuccessfullySaved();
            resourceWasAdded.Should().BeTrue();
        }
    }
}
