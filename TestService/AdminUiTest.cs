using Microsoft.Playwright;
using TestService.Models;
using TestService.Pages;
using TestService.Pages.HomePageViews.Clients;
using TestService.Pages.HomePageViews.Users;
using TestService.TestCollections.Fixture;
using TestService.TestCollections.HomePageViews.ClientsView;
using static TestService.Pages.HomePageViews.Roles.RolesPage;

// We do not want tests in parallel. Even though the default is what we want, we are making our intentions clear here.
[assembly: CollectionBehavior(DisableTestParallelization = true)]

// We want to be able to order testFixture classes, i.e. collection of testFixture cases
[assembly: TestCollectionOrderer("Xunit.Extensions.Ordering.CollectionOrderer", "Xunit.Extensions.Ordering")]

// We want to be able to order tests in testFixture class
[assembly: TestCaseOrderer("Xunit.Extensions.Ordering.TestCaseOrderer", "Xunit.Extensions.Ordering")]


namespace TestService
{
    public abstract class AdminUiTest(AdminUiAutoTestFixture testFixture) : IClassFixture<AdminUiAutoTestFixture>
    {
        protected AdminUiAutoTestFixture TestFixture { get; init; } = testFixture;

        protected async Task<WelcomePage> GotoTheWebsite()
        {
            IPage page = await TestFixture.BrowserContext!.NewPageAsync();

            // For running locally (not in docker) 
            await page.GotoAsync("https://localhost:5000");

            // For running in a docker container
            // await page.GotoAsync("http://ui-int:5000"); 

            return new WelcomePage(page);
        }

        protected async Task<AdminUiHomePage> LoginToAdminUi(string userEmail)
        {
            return TestFixture.AdminUiHomePage ??= await GotoTheWebsite()
                .AndThen(p => p.LogIn())
                .AndThen(p => p.SetUserEmail(userEmail))
                .AndThen(p => p.SetPassword(AdminUiAutoTestFixture.DefaultPassword))
                .AndThen(p => p.Login());
        }


        // Not all tests need to create a user, but let all tests that do, be able to do so
        // TODO : : Have all [Users] view tests in one class so only that class can AddUser().
        protected async Task<UsersPage.AddUserNewUserPage> AddUser(User user)
        {
            return await LoginToAdminUi(AdminUiAutoTestFixture.TestUser.EmailAddress)
                .AndThen(p => p.GotoTheUsersView())
                .AndThen(p => p.AddAUser())
                .AndThen(p => p.SetFirstName(user.FirstName))
                .AndThen(p => p.SetLastName(user.LastName))
                .AndThen(p => p.SetUserName(user.UserName))
                .AndThen(p => p.SetEmailAddress(user.EmailAddress))
                .AndThen(p => p.SetPassword(AdminUiAutoTestFixture.DefaultPassword))
                .AndThen(p => p.Save());
        }

        //protected async Task<ISaveDialog> AddClient(Client client)
        //{
        //    return await LoginToAdminUi(AdminUiAutoTestFixture.TestUser.EmailAddress)
        //        .AndThen(p => p.GotoTheClientsView())
        //        .AndThen(p => p.AddClient())
        //        .AndThen(p => p.SelectMachineApp()) //Generic Easy To Create Type
        //        .AndThen(p => p.Start())
        //        .AndThen(p => p.SetUniqueIdentifier(client.clientId))
        //        .AndThen(p => p.SetDisplayName(client.displayName))
        //        .AndThen(p => p.SetDescription(client.description))
        //        .AndThen(p => p.Next())
        //        .AndThen(p => p.AssignResourcesAt(0))
        //        .AndThen(p => p.Next())
        //        .AndThen(p => p.Next())
        //        .AndThen(p => p.Save());
        //}

        //protected async Task<ISaveDialog> AddIdResource(SetupInfoFactory.ResourceSetupInfo resourceSetupInfo)
        //{
        //    return await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
        //        .AndThen(p => p.GotoTheResourcesView())
        //        .AndThen(p => p.SelectIdentityResource())
        //        .AndThen(p => p.AddResource())
        //        .AndThen(s => s.SetUniqueIdentifier(resourceSetupInfo.IdentificationSetupInfo.UniqueIdentifier))
        //        .AndThen(s => s.SetDisplayName(resourceSetupInfo.IdentificationSetupInfo.DisplayName))
        //        .AndThen(s => s.SetDescription(resourceSetupInfo.IdentificationSetupInfo.Description))
        //        .AndThen(s => s.Next())
        //        .AndThen(s => s.AssignResources(resourceSetupInfo.ResourceSettings.IdentityResources))
        //        .AndThen(s => s.Save());
        //}

        //protected async Task<ISaveDialog> AddProtectedResource(SetupInfoFactory.ResourceSetupInfo resourceSetupInfo)
        //{
        //    return await LoginToAdminUi(UserFactory.GetTheTestUser().EmailAddress)
        //        .AndThen(p => p.GotoTheResourcesView())
        //        .AndThen(p => p.SelectProtectedResource())
        //        .AndThen(p => p.AddResource())
        //        .AndThen(s => s.SetUniqueIdentifier(resourceSetupInfo.IdentificationSetupInfo.UniqueIdentifier))
        //        .AndThen(s => s.SetDisplayName(resourceSetupInfo.IdentificationSetupInfo.DisplayName))
        //        .AndThen(s => s.SetDescription(resourceSetupInfo.IdentificationSetupInfo.Description))
        //        .AndThen(s => s.Next())
        //        .AndThen(s => s.AssignResources(resourceSetupInfo.ResourceSettings.ProtectedResources))
        //        .AndThen(s => s.Save());
        //}

        // Not all tests need to create a role, but let all tests that do, be able to do so
        // TODO : : Have all [Roles] view tests in one class so only that class can AddRole().
        protected async Task<AddRoleNewRolePage> AddRole(Role role)
        {
            return await LoginToAdminUi(AdminUiAutoTestFixture.TestUser.EmailAddress)
                .AndThen(p => p.GotoTheRolesView())
                .AndThen(p => p.GotoAddARole())
                .AndThen(p => p.SetName(role.Name))
                .AndThen(p => p.SetDescription(role.Description))
                .AndThen(p => p.Save());
        }

        protected static async Task<string?> TheTitleOfThePage(IPage page)
        {
            return await page.Locator("title").TextContentAsync();
        }
    }

    public class CollectionRunOrder
    {
        public const int LicenseValidation = 1;
        public const int Bootstrap = 2;
        public const int BootstrapValidation = 3;
        public const int LoginLogout = 4;
        public const int ManagingRoles = 5;
        public const int ManagingUsers = 6;   // Adding roles to user requires those roles to exist, so must run AFTER roles are managed
        public const int ManageSettings = 7;
        public const int EditSettings = 12;
        public const int AddSinglePageClient = 13;
        public const int EditSinglePageClient = 14;
        public const int AddWebAppClient = 15;
        public const int EditWebAppClient = 16;
        public const int AddMachineClient = 17;
        public const int EditMachineClient = 18;
        public const int AddSAMLServiceProviderClient = 19;
        public const int EditSAMLServiceProviderClient = 20;
        public const int AddWsFedRelyingPartyClient = 21;
        public const int EditWsFedRelyingPartyClient = 22;
        public const int AddDeviceClient = 23;
        public const int EditDeviceClient = 24;
        public const int AddNativeClient = 25;
        public const int EditNativeClient = 26;
        public const int AddSinglePageAppLegacyClient = 27;
        public const int EditSinglePageAppLegacyClient = 28;
        public const int AddIdentityResource = 29;
        public const int EditIdentityResource = 30;
        public const int AddProtectedResource = 31;
        public const int EditProtectedResource = 32;
        public const int AddClaimType = 33;
        public const int EditClaimType = 34;
    }
}