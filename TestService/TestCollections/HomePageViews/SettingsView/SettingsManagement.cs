﻿using FluentAssertions;
using TestService.Models;
using TestService.Pages;
using TestService.Pages.HomePageViews.Clients;
using TestService.TestCollections.Fixture;
using TestService.TestCollections.HomePageViews.ClientsView;
using Xunit.Extensions.Ordering;

namespace TestService.TestCollections.HomePageViews.SettingsView
{
    [Order(CollectionRunOrder.ManageSettings)]
    public class SettingsManagement(AdminUiAutoTestFixture fixture) : AdminUiTest(fixture)
    {
        [Fact(Skip = "[Access Policy] tab currently in Read-Only mode"), Order(1)]
        public async Task CanAddAnAccessPolicy()
        {
            SetupInfoFactory.AccessPolicySetupInfo setupInfo = SetupInfoFactory.CreateAccessPolicySetupInfo();

            ISaveDialog saveDialog = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                                        .AndThen(p => p.GotoTheSettingsView())
                                        .AndThen(p => p.SelectAccessPolicy())
                                        .AndThen(p => p.AddPolicy())
                                        .AndThen(s => s.SelectClaimType(setupInfo.ClaimType))
                                        .AndThen(s => s.SetValue(setupInfo.Value))
                                        .AndThen(s => s.SelectPermission(setupInfo.Permission))
                                        .AndThen(s => s.Add())
                                        .AndThen(s => s.Save());

            bool resourceWasAdded = saveDialog.SuccessfullySaved();
            resourceWasAdded.Should().BeTrue();
        }

        [Fact(Skip = "[Webhooks] tab currently in Read-Only mode"), Order(2)]
        public async Task CanAddAWebhook()
        {
            SetupInfoFactory.WebhookSetupInfo setupInfo = SetupInfoFactory.CreateWebhookSetupInfo();

            ISaveDialog saveDialog = await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
                .AndThen(p => p.GotoTheSettingsView())
                .AndThen(p => p.SelectWebhooks())
                .AndThen(p => p.EnableWebhookForMfaReset())
                .AndThen(s => s.SetUrlForMfaReset(setupInfo.MFAResetUrl))
                .AndThen(s => s.SelectProtectingScopeMfaReset(setupInfo.MFAResetProtectingScope))
                .AndThen(p => p.EnableWebhookForPasswordReset())
                .AndThen(s => s.SetUrlForPasswordReset(setupInfo.PasswordResetUrl))
                .AndThen(s => s.SelectProtectingScopeForPasswordReset(setupInfo.PasswordResetProtectingScope))
                .AndThen(p => p.EnableWebhookForUserRegistration())
                .AndThen(s => s.SetUrlForUserRegistration(setupInfo.UserRegistrationUrl))
                .AndThen(s => s.SelectProtectingScopeForUserRegistration(setupInfo.UserRegistrationProtectingScope))
                .AndThen(p => p.EnableWebhookForServerSideSessionDeletion())
                .AndThen(s => s.SetUrlForServerSideSessionDeletion(setupInfo.ServersideSessionDeletionUrl))
                .AndThen(s => s.SelectProtectingScopeForServerSideSessionDeletion(setupInfo.ServersideSessionDeletionProtectingScope))
                .AndThen(s => s.Save());

            bool resourceWasAdded = saveDialog.SuccessfullySaved();
            resourceWasAdded.Should().BeTrue();
        }
    }
}