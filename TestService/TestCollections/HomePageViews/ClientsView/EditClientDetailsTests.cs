using FluentAssertions;
using TestService.Models;
using TestService.Pages;
using TestService.Pages.HomePageViews.Clients;
using TestService.TestCollections.Fixture;
using Xunit.Extensions.Ordering;

namespace TestService.TestCollections.HomePageViews.ClientsView.Device.Editing;

[Order(CollectionRunOrder.EditDeviceClient)]
public class EditClientDetailsTests(AdminUiAutoTestFixture test) : AdminUiTest(test)
{
    [Fact(Skip = "Not yet determined is validity as an OpenIddict.AdminUI test"), Order(1)]
    public async Task CanEditClient()
    {
        Client originalClient = ClientFactory.Create();
        await AddClient(originalClient);
        Client updatedClientDetails = originalClient with { displayName = "New Display Name" };
        TestFixture.CurrentClientName = updatedClientDetails.displayName;

        ClientsDetailsPage clientsDetailsPage = await LoginToAdminUi(AdminUiAutoTestFixture.TestUser.EmailAddress)
            .AndThen(p => p.GotoTheClientsView())
            .AndThen(p => p.EditTheClient(originalClient.displayName))
            .AndThen(p => p.GotoTheClientsDetailsTab())
            .AndThen(p => p.SetClientName(updatedClientDetails.displayName))
            .AndThen(p => p.Save());

        clientsDetailsPage.SuccessToastWasVisible().Should().BeTrue();
        //clientsDetailsPage.ErrorToastWasVisible().Should().BeFalse();
    }

    private async Task AddClient(Client client)
    {
        await LoginToAdminUi(AdminUiAutoTestFixture.TestUser.EmailAddress)
            .AndThen(p => p.GotoTheClientsView())
            .AndThen(p => p.AddClient())
            .AndThen(p => p.SelectMachineApp()) //Generic Easy To Create Type
            .AndThen(p => p.Start())
            .AndThen(p => p.SetUniqueIdentifier(client.clientId))
            .AndThen(p => p.SetDisplayName(client.displayName))
            .AndThen(p => p.SetDescription(client.description))
            .AndThen(p => p.Next())
            .AndThen(p => p.AssignResourcesAt(0))
            .AndThen(p => p.Next())
            .AndThen(p => p.Next())
            .AndThen(p => p.Save());
    }
}