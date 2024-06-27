using Microsoft.Playwright;
using TestService.Pages.HomePageViews.ClaimTypes;
using TestService.Pages.HomePageViews.Clients;
using TestService.Pages.HomePageViews.Resources;
using TestService.Pages.HomePageViews.Roles;
using TestService.Pages.HomePageViews.Settings;
using TestService.Pages.HomePageViews.Users;

namespace TestService.Pages
{
    public class AdminUiHomePage(IPage page) : TestPage(page)
    {
        public const int SignedInUserDiv = 2;
        public const int SignedInUserSpan = 2;

        public async Task<string> GetLoggedInUser()
        {
            return await CurrentPage.Locator("#metaMenu").Locator("div").Locator("div").Locator($"div:nth-child({SignedInUserDiv})").Locator($"span:nth-child({SignedInUserSpan})").InnerTextAsync();
        }

        public async Task<LogoutConfirmationPage> Logout()
        {
            await CurrentPage.GetByRole(AriaRole.Button, new() { Name = " Logout " }).ClickAsync();

            await CurrentPage.GetByRole(AriaRole.Button, new(){ Name = "Yes" }).WaitForAsync();
            
            return new LogoutConfirmationPage(CurrentPage);
        }

        public async Task<UsersPage> GotoTheUsersView()
        {
            await CurrentPage
                .Locator("#app-nav-item-users")
                .ClickAsync();

            await CurrentPage.Locator("#usersTable").WaitForAsync();

            return new UsersPage(CurrentPage);
        }

        public async Task<RolesPage> GotoTheRolesView()
        {
            await CurrentPage
                .Locator("#mainNavLinks")
                .GetByRole(AriaRole.Button, new() { Name = " Roles ", Exact = true })
                .ClickAsync();
            
            await CurrentPage.Locator("#rolesTable").WaitForAsync();
            
            return new RolesPage(CurrentPage);
        }

        public async Task<ClientsPage> GotoTheClientsView()
        {
            await CurrentPage
                .Locator("#mainNavLinks")
                .GetByRole(AriaRole.Button, new() { Name = " Clients ", Exact = true })
                .ClickAsync();
            
            await CurrentPage.Locator("#clientsTable").WaitForAsync();

            return new ClientsPage(CurrentPage);
        }

        public async Task<ResourcesPage> GotoTheResourcesView()
        {
            await CurrentPage.GetByRole(AriaRole.Button, new() { Name = "Resources"}).ClickAsync();

            return new ResourcesPage(CurrentPage);
        }

        public async Task<ClaimTypesPage> GotoTheClaimTypesView()
        {
            await CurrentPage
                .Locator("#mainNavLinks")
                .GetByRole(AriaRole.Button, new() { Name = " Claim Types ", Exact = true })
                .ClickAsync();

            await CurrentPage.Locator("#claimTypesTable").WaitForAsync();

            return new ClaimTypesPage(CurrentPage);
        }

        public async Task<SettingsPage> GotoTheSettingsView()
        {
            await CurrentPage
                .Locator("#mainNavLinks")
                .GetByRole(AriaRole.Button, new() { Name = " Settings ", Exact = true })
                .ClickAsync();

            await CurrentPage.GetByRole(AriaRole.Tab, new() { Name = "Webhooks" }).WaitForAsync();
            
            return new SettingsPage(CurrentPage);
        }
    }
}
