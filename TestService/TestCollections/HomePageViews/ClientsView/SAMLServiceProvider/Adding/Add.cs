using FluentAssertions;
using TestService.Models;
using TestService.Pages;
using TestService.Pages.HomePageViews.Clients;
using TestService.TestCollections.Fixture;
using Xunit.Extensions.Ordering;

namespace TestService.TestCollections.HomePageViews.ClientsView.SAMLServiceProvider.Adding
{
    [Order(CollectionRunOrder.AddSAMLServiceProviderClient)]
    public class Add(AdminUiAutoTestFixture test) : AdminUiTest(test)
    {
        [Fact(Skip = "Not yet determined is validity as an OpenIddict.AdminUI test"), Order(1)]
        public async Task CanAddAnSAMLClient()
        {
            SetupInfoFactory.SAMLClientSetupInfo newClient = SetupInfoFactory.CreateSAMLClientSetupInfo();
            TestFixture.CurrentClientName = newClient.IdentificationInfo.DisplayName;

            ISaveDialog saveDialog = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                                    .AndThen(p => p.GotoTheClientsView())
                                    .AndThen(p => p.AddClient())
                                    .AndThen(w => w.SelectSAMLApp())
                                    .AndThen(a => a.Start())
                                    .AndThen(s => s.SetUniqueIdentifier(newClient.IdentificationInfo.UniqueIdentifier))
                                    .AndThen(s => s.SetDisplayName(newClient.IdentificationInfo.DisplayName))
                                    .AndThen(s => s.SetDescription(newClient.IdentificationInfo.Description))
                                    .AndThen(s => s.Next())
                                    .AndThen(e => e.SetEndpoint(newClient.ACSEndpointSetup.Endpoint))
                                    .AndThen(e => e.SetBindingType(newClient.ACSEndpointSetup.BindingType))
                                    .AndThen(e => e.SetIndex(newClient.ACSEndpointSetup.EndpointIndex))
                                    .AndThen(e => e.Next())
                                    .AndThen(e => e.SetEndpoint(newClient.SLOEndpointSetup.Endpoint))
                                    .AndThen(e => e.SetBindingType(newClient.SLOEndpointSetup.BindingType))
                                    .AndThen(e => e.SetIndex(newClient.SLOEndpointSetup.EndpointIndex))
                                    .AndThen(e => e.Next())
                                    .AndThen(e => e.SetEndpoint(newClient.ARSEndpointSetup.Endpoint))
                                    .AndThen(e => e.SetBindingType(newClient.ARSEndpointSetup.BindingType))
                                    .AndThen(e => e.SetIndex(newClient.ARSEndpointSetup.EndpointIndex))
                                    .AndThen(e => e.Next())
                                    .AndThen(i => i.AssignResources(newClient.IdentityResources))
                                    .AndThen(i => i.Next())
                                    .AndThen(s => s.Save());

            bool clientWasAdded = saveDialog.SuccessfullySaved();
            clientWasAdded.Should().BeTrue();
        }

    }
}
