using FluentAssertions;
using TestService.Models;
using TestService.Pages;
using TestService.Pages.HomePageViews.Clients;
using TestService.TestCollections.Fixture;
using Xunit.Extensions.Ordering;

namespace TestService.TestCollections.HomePageViews.ClientsView.SinglePageApp.Adding
{
    [Order(CollectionRunOrder.AddSinglePageClient)]
    public class Add(AdminUiAutoTestFixture test) : AdminUiTest(test)
    {
        [Fact(Skip = "Not yet determined is validity as an OpenIddict.AdminUI test"), Order(1)]
        public async Task CanAddASinglePageClient()
        {
            SetupInfoFactory.SinglePageClientSetupInfo newClient = SetupInfoFactory.CreateSinglePageClientSetupInfo();
            TestFixture.CurrentClientName = newClient.IdentificationInfo.DisplayName;

            ISaveDialog saveDialog = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                                    .AndThen(p => p.GotoTheClientsView())
                                    .AndThen(p => p.AddClient())
                                    .AndThen(w => w.SelectSinglePageApp())
                                    .AndThen(a => a.Start())
                                    .AndThen(s => s.SetUniqueIdentifier(newClient.IdentificationInfo.UniqueIdentifier))
                                    .AndThen(s => s.SetDisplayName(newClient.IdentificationInfo.DisplayName))
                                    .AndThen(s => s.SetDisplayUrl(newClient.ExtendedSetupInfo.DisplayUrl))
                                    .AndThen(s => s.SetLogoUrl(newClient.ExtendedSetupInfo.LogoUrl))
                                    .AndThen(s => s.SetDescription(newClient.IdentificationInfo.Description))
                                    .AndThen(s => s.Next())
                                    .AndThen(s => s.SetCallbackUrl(newClient.ExtendedSetupInfo.CallbackUrl))
                                    .AndThen(s => s.Next())
                                    .AndThen(s => s.SetLogoutUrl(newClient.ExtendedSetupInfo.LogoutUrl))
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
