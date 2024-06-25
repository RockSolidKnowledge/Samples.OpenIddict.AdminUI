using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Roles
{
    public class RolesPage(IPage page) : TestPage(page)
    {
        public static readonly int NameColumn = 1;
        public static readonly int DescriptionColumn = 2;
        public int CurrentRow = -1;

        public async Task<AddRoleNewRolePage> GotoAddARole()
        {
            await CurrentPage.GetByRole(AriaRole.Button, new() { Name = " Add Role " }).ClickAsync();

            await CurrentPage.WaitForSelectorAsync("#addRoleName");

            return new AddRoleNewRolePage(CurrentPage);
        }

        public async Task<EditRoleDetailsPage> EditTheRole()
        {
            await CurrentPage.Locator("#rolesTable").Locator($"tr:nth-child({CurrentRow})").Locator("#viewOrEditIcon").ClickAsync();

            await CurrentPage.WaitForSelectorAsync("#editRoleDetails");

            return new EditRoleDetailsPage(CurrentPage);
        }

        public class AddRoleNewRolePage(IPage page) : TestPage(page)
        {
            private bool _savedSuccessful;

            public async Task<AddRoleNewRolePage> SetName(string name)
            {
                await CurrentPage.Locator("#addRoleModal").Locator("#addRoleName").FillAsync(name);

                return this;
            }

            public async Task<AddRoleNewRolePage> SetDescription(string description)
            {
                await CurrentPage.Locator("#addRoleModal").Locator("#addRoleDescription").FillAsync(description);

                return this;
            }

            public async Task<AddRoleNewRolePage> Save()
            {
                await CurrentPage.Locator("#addRoleSubmit").ClickAsync();

                await CurrentPage.Locator("#toast-container").GetByLabel("Role Created").WaitForAsync();

                await CurrentPage.Locator("#toast-container").GetByLabel("Role Created").WaitForAsync(new() { State = WaitForSelectorState.Hidden });

                _savedSuccessful = true;

                return this;
            }

            public bool IsRoleSuccessfullyCreated()
            {
                return _savedSuccessful;
            }
        }

        public class EditRoleDetailsPage(IPage page) : TestPage(page)
        {
            private bool _successfullyUpdated;

            public async Task<EditRoleDetailsPage> SetName(string name)
            {
                await CurrentPage.Locator("#addRoleName").FillAsync(name);

                return this;
            }

            public async Task<EditRoleDetailsPage> SetDescription(string description)
            {
                await CurrentPage.Locator("#addRoleDescription").FillAsync(description);

                return this;
            }

            public async Task<EditRoleDetailsPage> Save()
            {
                await CurrentPage.Locator("#updateRoleBtn").ClickAsync();

                await CurrentPage.Locator("#toast-container").GetByLabel("Success").WaitForAsync();

                await CurrentPage.Locator("#toast-container").GetByLabel("Success").WaitForAsync(new() { State = WaitForSelectorState.Hidden });

                _successfullyUpdated = true;

                return this;
            }

            public async Task<DeleteRoleConfirmationPage> DeleteRole()
            {
                await CurrentPage.Locator("#showModal").ClickAsync();

                return new DeleteRoleConfirmationPage(CurrentPage);
            }

            public bool IsRoleSuccessfullyUpdated()
            {
                return _successfullyUpdated;
            }

            public class DeleteRoleConfirmationPage(IPage currentPage) : TestPage(currentPage)
            {
                private bool _successfullyDeleted;

                public async Task<DeleteRoleConfirmationPage> Confirm()
                {
                    await CurrentPage.Locator("#deleteRoleModal").Locator("#deleteRoleModal-confirmBtn").ClickAsync();

                    await CurrentPage.Locator("#toast-container").GetByLabel("Deleted").WaitForAsync();

                    _successfullyDeleted = true;

                    return this;
                }

                public bool IsRoleSuccessfullyDeleted()
                {
                    return _successfullyDeleted;
                }
            }
        }

        public async Task<RolesPage> GotoTheRole(string roleName)
        {
            await CurrentPage.WaitForSelectorAsync("#rolesList");

            int roleCount = await CurrentPage.Locator("#rolesTable").Locator("tbody").Locator("tr").CountAsync();

            for (int row = 1; row <= roleCount; row++)
            {
                if (roleName == await CurrentPage.Locator("#rolesTable").Locator("tbody").Locator($"tr:nth-child({row})").Locator($"td:nth-child({NameColumn})").InnerTextAsync())
                {
                    CurrentRow = row;
                }
            }

            return this;
        }
    }
}
