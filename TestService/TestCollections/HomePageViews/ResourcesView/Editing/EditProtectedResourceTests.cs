using FluentAssertions;
using TestService.Models;
using TestService.Pages;
using TestService.Pages.HomePageViews.Clients;
using TestService.Pages.HomePageViews.Resources.Protected;
using TestService.TestCollections.Fixture;
using TestService.TestCollections.HomePageViews.ClientsView;
using Xunit.Extensions.Ordering;

namespace TestService.TestCollections.HomePageViews.ResourcesView.Editing;

[Order(CollectionRunOrder.EditProtectedResource)]
public class EditProtectedResourceTests(AdminUiAutoTestFixture testFixture) : AdminUiTest(testFixture)
{
    [Fact(Skip = "Not yet determined is validity as an OpenIddict.AdminUI test"), Order(1)]
    public async Task CanEditProtectedResource()
    {
        SetupInfoFactory.ResourceSetupInfo setupInfo = SetupInfoFactory.CreateResourceSetupInfo(SetupInfoFactory.ResourceType.Protected);
        await AddProtectedResource(setupInfo);
        TestFixture.CurrentResourceName = setupInfo.IdentificationSetupInfo.DisplayName;
        SetupInfoFactory.ResourceSetupInfo newInfo  = setupInfo with { IdentificationSetupInfo = setupInfo.IdentificationSetupInfo with
        {
            DisplayName = "New Display Name",
            Description = "New Identity Resource Information",
        }};

        ProtectedResourceDetailsPage saveDialog = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
            .AndThen(p => p.GotoTheResourcesView())
            .AndThen(p => p.SelectProtectedResource())
            .AndThen(p => p.EditIdResource(setupInfo.IdentificationSetupInfo.DisplayName))
            .AndThen(s => s.GotoTheIdResourcesDetailsTab())
            .AndThen(s => s.SetProtectedResourceName(newInfo.IdentificationSetupInfo.DisplayName))
            .AndThen(s => s.SetProtectedResourceDescription(newInfo.IdentificationSetupInfo.Description))
            .AndThen(s => s.Save());


        saveDialog.SuccessPopupWasVisible().Should().BeTrue();
    }

    private async Task AddProtectedResource(SetupInfoFactory.ResourceSetupInfo resourceSetupInfo)
    {
        await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
            .AndThen(p => p.GotoTheResourcesView())
            .AndThen(p => p.SelectProtectedResource())
            .AndThen(p => p.AddResource())
            .AndThen(s => s.SetUniqueIdentifier(resourceSetupInfo.IdentificationSetupInfo.UniqueIdentifier))
            .AndThen(s => s.SetDisplayName(resourceSetupInfo.IdentificationSetupInfo.DisplayName))
            .AndThen(s => s.SetDescription(resourceSetupInfo.IdentificationSetupInfo.Description))
            .AndThen(s => s.Next())
            .AndThen(s => s.AssignResources(resourceSetupInfo.ResourceSettings.ProtectedResources))
            .AndThen(s => s.Save());
    }
}