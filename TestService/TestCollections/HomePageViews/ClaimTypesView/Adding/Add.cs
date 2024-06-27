using FluentAssertions;
using TestService.Models;
using TestService.Pages;
using TestService.Pages.HomePageViews.Clients;
using TestService.TestCollections.Fixture;
using TestService.TestCollections.HomePageViews.ClientsView;
using Xunit.Extensions.Ordering;

namespace TestService.TestCollections.HomePageViews.ClaimTypesView.Adding
{
    [Order(CollectionRunOrder.AddClaimType)]
    public class Add(AdminUiAutoTestFixture testFixture) : AdminUiTest(testFixture)
    {
        [Fact(Skip = "Not yet determined is validity as an OpenIddict.AdminUI test"), Order(1)]
        public async Task CanAddAClaimTypeResource()
        {
            SetupInfoFactory.ClaimTypeSetupInfo setupInfo = SetupInfoFactory.CreateClaimTypeSetupInfo();
            TestFixture.CurrentResourceName = setupInfo.IdentificationInfo.UniqueIdentifier;

            ISaveDialog saveDialog = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                                        .AndThen(p => p.GotoTheClaimTypesView())
                                        .AndThen(p => p.AddClaimType())
                                        .AndThen(s => s.SetName(setupInfo.IdentificationInfo.UniqueIdentifier))
                                        .AndThen(s => s.SetDisplayName(setupInfo.IdentificationInfo.DisplayName))
                                        .AndThen(s => s.SetType(setupInfo.Type))
                                        .AndThen(s => s.SetDescription(setupInfo.IdentificationInfo.Description))
                                        .AndThen(s => s.SetRegexRule(setupInfo.RegexRule))
                                        .AndThen(s => s.SetRuleValidationFailureDescription(setupInfo.RuleValidationFailureDescription))
                                        .AndThen(s => s.AcceptDefaultRequiredClaimSetting())
                                        .AndThen(s => s.AcceptDefaultUserEditableSetting())
                                        .AndThen(s => s.Save());

            bool claimTypeWasWasAdded = saveDialog.SuccessfullySaved();
            claimTypeWasWasAdded.Should().BeTrue();
        }
    }
}
