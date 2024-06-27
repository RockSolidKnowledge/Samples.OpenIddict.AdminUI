using FluentAssertions;
using TestService.Models;
using TestService.Pages;
using TestService.Pages.HomePageViews.Clients;
using TestService.TestCollections.Fixture;
using Xunit.Extensions.Ordering;

namespace TestService.TestCollections.HomePageViews.ClientsView.Native.Adding
{
    [Order(CollectionRunOrder.AddNativeClient)]
    public class Add(AdminUiAutoTestFixture testFixture) : AdminUiTest(testFixture)
    {
        [Fact(Skip = "Not yet determined is validity as an OpenIddict.AdminUI test"), Order(1)]
        public async Task CanAddAMachineClient()
        {
            SetupInfoFactory.NativeClientSetupInfo newClient = SetupInfoFactory.CreateNativeClientSetupInfo();
            TestFixture.CurrentClientName = newClient.IdentificationInfo.DisplayName;

            ISaveDialog saveDialog = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                                    .AndThen(p => p.GotoTheClientsView())
                                    .AndThen(p => p.AddClient())
                                    .AndThen(w => w.SelectNativeApp())
                                    .AndThen(a => a.SetSupportedFlow(newClient.SupportedFlow))
                                    .AndThen(a => a.Start())
                                    .AndThen(s => s.SetUniqueIdentifier(newClient.IdentificationInfo.UniqueIdentifier))
                                    .AndThen(s => s.SetDisplayName(newClient.IdentificationInfo.DisplayName))
                                    .AndThen(s => s.SetDisplayUrl(newClient.ExtendedSetupInfo.DisplayUrl))
                                    .AndThen(s => s.SetLogoUrl(newClient.ExtendedSetupInfo.LogoUrl))
                                    .AndThen(s => s.SetDescription(newClient.IdentificationInfo.Description))
                                    .AndThen(s => s.Next())
                                    .AndThen(s => s.SetCallbackUrl(newClient.ExtendedSetupInfo.CallbackUrl))
                                    .AndThen(s => s.Next())
                                    .AndThen(s => s.SetType(newClient.SecretsSettings.Type))
                                    .AndThen(s => s.SetValue(newClient.SecretsSettings.Value))
                                    .AndThen(s => s.SetDescription(newClient.SecretsSettings.Description))
                                    .AndThen(s => s.Add())
                                    .AndThen(s => s.Next())
                                    .AndThen(s => s.AssignResources(newClient.ResourceSettings.IdentityResources))
                                    .AndThen(s => s.Next())
                                    .AndThen(s => s.AssignResources(newClient.ResourceSettings.ProtectedResources))
                                    .AndThen(s => s.Next())
                                    .AndThen(s => s.Save());

            bool clientWasAdded = saveDialog.SuccessfullySaved();
            clientWasAdded.Should().BeTrue();
        }
    }
}
