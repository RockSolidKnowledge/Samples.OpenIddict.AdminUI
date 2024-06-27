using FluentAssertions;
using TestService.Models;
using TestService.Pages;
using TestService.Pages.HomePageViews.Clients;
using TestService.TestCollections.Fixture;
using Xunit.Extensions.Ordering;

namespace TestService.TestCollections.HomePageViews.ClientsView.WsFedRelyingParty.Adding
{
    [Order(CollectionRunOrder.AddWsFedRelyingPartyClient)]
    public class Add(AdminUiAutoTestFixture testFixture) : AdminUiTest(testFixture)
    {
        [Fact(Skip = "Not yet determined is validity as an OpenIddict.AdminUI test"), Order(1)]
        public async Task CanAddAWsFedRelyingPartyClient()
        {
            SetupInfoFactory.WsFedRelyingPartyClientSetupInfo newClient = SetupInfoFactory.CreateWsFedRelyingPartyClientSetupInfo();
            TestFixture.CurrentClientName = newClient.IdentificationInfo.DisplayName;

            ISaveDialog saveDialog = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                .AndThen(p => p.GotoTheClientsView())
                .AndThen(p => p.AddClient())
                .AndThen(w => w.SelectWsFedRelyingPartyApp())
                .AndThen(a => a.Start())
                .AndThen(s => s.SetRealm(newClient.IdentificationInfo.UniqueIdentifier))
                .AndThen(s => s.SetDisplayName(newClient.IdentificationInfo.DisplayName))
                .AndThen(s => s.SetDescription(newClient.IdentificationInfo.Description))
                .AndThen(s => s.Next())
                .AndThen(s => s.SetCallbackUrl(newClient.CallbackUrl))
                .AndThen(s => s.Next())
                .AndThen(s => s.AssignResources(newClient.IdentityResources))
                .AndThen(s => s.Next())
                .AndThen(s => s.Save());

            bool clientWasAdded = saveDialog.SuccessfullySaved();
            clientWasAdded.Should().BeTrue();
        }
    }
}
