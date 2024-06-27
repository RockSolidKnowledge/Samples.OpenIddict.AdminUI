using FluentAssertions;
using TestService.Models;
using TestService.Pages;
using TestService.Pages.HomePageViews.Clients;
using TestService.TestCollections.Fixture;
using Xunit.Extensions.Ordering;

namespace TestService.TestCollections.HomePageViews.ClientsView.Machine.Adding
{
    [Order(CollectionRunOrder.AddMachineClient)]
    public class Add(AdminUiAutoTestFixture test) : AdminUiTest(test)
    {
        [Fact(Skip = "Not yet determined is validity as an OpenIddict.AdminUI test"), Order(1)]
        public async Task CanAddAMachineClient()
        {
            SetupInfoFactory.MachineClientSetupInfo newClient = SetupInfoFactory.CreateMachineClientSetupInfo();
            TestFixture.CurrentClientName = newClient.IdentificationInfo.DisplayName;

            ISaveDialog saveDialog = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                                    .AndThen(p => p.GotoTheClientsView())
                                    .AndThen(p => p.AddClient())
                                    .AndThen(w => w.SelectMachineApp())
                                    .AndThen(a => a.SetSupportedFlow(newClient.SupportedFlow))
                                    .AndThen(a => a.Start())
                                    .AndThen(s => s.SetUniqueIdentifier(newClient.IdentificationInfo.UniqueIdentifier))
                                    .AndThen(s => s.SetDisplayName(newClient.IdentificationInfo.DisplayName))
                                    .AndThen(s => s.SetDescription(newClient.IdentificationInfo.Description))
                                    .AndThen(s => s.Next())
                                    .AndThen(s => s.AssignResources(newClient.ResourceSettings.ProtectedResources))
                                    .AndThen(s => s.Next())
                                    .AndThen(s => s.SetType(newClient.SecretsSettings.Type))
                                    .AndThen(s => s.SetValue(newClient.SecretsSettings.Value))
                                    .AndThen(s => s.SetDescription(newClient.SecretsSettings.Description))
                                    .AndThen(s => s.Add())
                                    .AndThen(s => s.Next())
                                    .AndThen(s => s.Save());

            bool clientWasAdded = saveDialog.SuccessfullySaved();
            clientWasAdded.Should().BeTrue();
        }
    }
}
