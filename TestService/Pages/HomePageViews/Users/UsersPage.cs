using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Users
{
    public class UsersPage : TestPage
    {
        public static readonly int UserNameColumn = 1;
        public static readonly int FullNameColumn = 2;
        public static readonly int EmailColumn = 3;
        private Pager UsersPager { get; init; }

        public UsersPage(IPage page) : base(page)
        {
            UsersPager = new Pager(this);
        }

        public async Task<Pager.PagerPage.EditUsersPage> EditTheUser(string userName)
        {
            Pager.PagerPage pagerPage = await GotoTheUser(userName);

            return await pagerPage.GotoEditTheUser();
        }

        public async Task<bool> IsTheUserPresent(string userName)
        {
            await UsersPager.GetThePageThatTheUserIsOn(userName);

            return true;
        }

        public async Task<AddUserNewUserPage> AddAUser()
        {
            await CurrentPage.Locator("#addUserBtn").ClickAsync();
            //await CurrentPage.GetByRole(AriaRole.Button, new() { Name = " Add User " }).ClickAsync();

            await CurrentPage.WaitForSelectorAsync("#FirstName");

            return new AddUserNewUserPage(CurrentPage);
        }

        private async Task<Pager.PagerPage> GotoTheUser(string userName)
        {
            return await UsersPager.GetThePageThatTheUserIsOn(userName);
        }

        public class Pager
        {
            public PagerPage CurrentPagerPage { get; set; }
            private UsersPage UsersPage { get; }

            public Pager(UsersPage usersPage)
            {
                UsersPage = usersPage;
                CurrentPagerPage = new PagerPage(this);
            }

            public async Task<bool> TryGoingToTheNextPage()
            {
                if (await UsersPage.CurrentPage.Locator("#pagerNextPage").IsEnabledAsync())
                {
                    await UsersPage.CurrentPage.Locator("#pagerNextPage").ClickAsync();

                    return true;
                }

                return false;
            }

            public async Task<PagerPage> GotoTheFirstPage()
            {
                if (await UsersPage.CurrentPage.Locator("#pagerNextPage").IsEnabledAsync())
                {
                    await UsersPage.CurrentPage.Locator("#pagerFirstPage").ClickAsync();
                }

                return new PagerPage(UsersPage.UsersPager);
            }

            public async Task<bool> TryGoingToTheLastPage()
            {
                if (await UsersPage.CurrentPage.Locator("#pagerLastPage").IsEnabledAsync())
                {
                    await UsersPage.CurrentPage.Locator("#pagerLastPage").ClickAsync();

                    return true;
                }

                return false;
            }

            public async Task<bool> TryGoingToThePreviousPage()
            {
                if (await UsersPage.CurrentPage.Locator("#pagerPrevPage").IsEnabledAsync())
                {
                    await UsersPage.CurrentPage.Locator("#pagerPrevPage").ClickAsync();

                    return true;
                }

                return false;
            }

            public async Task<PagerPage> GetThePageThatTheUserIsOn(string userName)
            {
                bool userFound;
                do
                {
                    userFound = await CurrentPagerPage.ContainsUser(userName);

                    if (userFound)
                    {
                        return CurrentPagerPage;
                    }

                } while (!userFound && await TryGoingToTheNextPage());

                return await Task.FromException<PagerPage>(new ArgumentException($"Unknown user: {userName}"));
            }

            public class PagerPage
            {
                public Pager Pager { get; }
                public int CurrentRow { get; set; } = -1;

                public PagerPage(Pager pager)
                {
                    Pager = pager;
                    CurrentRow = -1;
                }


                public async Task<bool> ContainsUser(string userName)
                {
                    int userCount = await Pager.UsersPage.CurrentPage.Locator("#usersTable").Locator("tr").CountAsync();

                    for (int row = 1; row <= userCount; row++)
                    {
                        if (await Pager.UsersPage.CurrentPage.Locator("#usersTable").Locator($"tr:nth-child({row})").Locator("td:nth-child(1)").InnerTextAsync() == userName)
                        {
                            Pager.CurrentPagerPage.CurrentRow = row;

                            return true;
                        }
                    }

                    return false;
                }

                public async Task<EditUsersPage> GotoEditTheUser()
                {
                    await Pager.UsersPage.CurrentPage.Locator("#usersTable").Locator($"tr:nth-child({CurrentRow})").Locator("#viewOrEditIcon").ClickAsync();

                    return new EditUsersPage(Pager.UsersPage.CurrentPage);
                }

                public class EditUsersPage(IPage page) : TestPage(page)
                {
                    public async Task<UsersDetailsPage> GotoTheUsersDetailsTab()
                    {

                        await CurrentPage.GetByRole(AriaRole.Tablist)
                            .GetByRole(AriaRole.Tab, new() { Name = "Details", Exact = true }).ClickAsync();

                        await CurrentPage.WaitForSelectorAsync("#FirstName");

                        return new UsersDetailsPage(CurrentPage);
                    }

                    public async Task<UsersRolesPage> GotoTheUsersRolesTab()
                    {
                        await CurrentPage.GetByRole(AriaRole.Tablist)
                            .GetByRole(AriaRole.Tab, new() { Name = "Roles", Exact = true }).ClickAsync();

                        return new UsersRolesPage(CurrentPage);
                    }

                    public class UsersDetailsPage(IPage page) : TestPage(page)
                    {
                        private bool _successfullyUpdated;

                        public async Task<DeleteUserConfirmationPage> Delete()
                        {
                            await CurrentPage.GetByRole(AriaRole.Button, new() { Name = " Delete " }).ClickAsync();

                            return new DeleteUserConfirmationPage(CurrentPage);
                        }

                        public async Task<UsersDetailsPage> SetFirstName(string firstName)
                        {
                            await CurrentPage.Locator("#editUserDetails").Locator("#FirstName").FillAsync(firstName);

                            return this;
                        }

                        public async Task<UsersDetailsPage> SetLastName(string lastName)
                        {
                            await CurrentPage.Locator("#editUserDetails").Locator("#LastName").FillAsync(lastName);
                            return this;
                        }

                        public async Task<UsersDetailsPage> SetUserName(string userName)
                        {
                            await CurrentPage.Locator("#editUserDetails").Locator("#Username").FillAsync(userName);

                            return this;
                        }

                        public async Task<UsersDetailsPage> SetEmailAddress(string emailAddress)
                        {
                            await CurrentPage.Locator("#editUserDetails").Locator("#Email").FillAsync(emailAddress);

                            return this;
                        }

                        public async Task<UsersDetailsPage> Save()
                        {
                            await CurrentPage.Locator("#submitBtn").ClickAsync();

                            await CurrentPage.GetByLabel("Success").First.WaitForAsync();

                            // The popup lingers for too long and that subsequent calls may show a stack of them. We must wait till it popup disappears to avoid multiple calls seeing a stack of them
                            await CurrentPage.GetByLabel("Success").First.WaitForAsync(new() { State = WaitForSelectorState.Hidden });

                            _successfullyUpdated = true;

                            return this;
                        }

                        public async Task<UsersDetailsPage> ChangeTheActiveStatus()
                        {
                            await CurrentPage
                                .Locator("app-form-row")
                                .Filter(new() { HasText = "Active" })
                                .Locator("span")
                                .Nth(2)
                                .ClickAsync();

                            return this;
                        }

                        public async Task<UsersDetailsPage> ChangeTheLockoutStatus()
                        {
                            await CurrentPage
                                .Locator("app-form-row")
                                .Filter(new() { HasText = "Lockout Enabled" })
                                .Locator("span")
                                .Nth(2)
                                .ClickAsync();

                            return this;
                        }

                        public async Task<UsersDetailsPage> ChangeThe2FactorAuthenticationStatus()
                        {
                            await CurrentPage
                                .Locator("app-form-row")
                                .Filter(new() { HasText = "Enable ASP.NET Identity two-factor authentication" })
                                .Locator("span")
                                .Nth(3)
                                .ClickAsync();

                            return this;
                        }

                        public bool SuccessPopupWasVisible()
                        {
                            return _successfullyUpdated;
                        }

                        public class DeleteUserConfirmationPage(IPage currentPage) : TestPage(currentPage)
                        {
                            private bool _successfullyDeleted;

                            public async Task<DeleteUserConfirmationPage> Confirm()
                            {
                                await CurrentPage.Locator("app-user-details").Locator("#deleteUserModal")
                                    .GetByRole(AriaRole.Button, new() { Name = "Delete", Exact = true }).ClickAsync();

                                await CurrentPage.Locator("#toast-container").GetByLabel("Success").WaitForAsync();

                                await CurrentPage.Locator("#toast-container").GetByLabel("Success").WaitForAsync(new() { State = WaitForSelectorState.Hidden });

                                _successfullyDeleted = true;

                                return this;
                            }

                            public bool SuccessPopupWasVisible()
                            {
                                return _successfullyDeleted;
                            }
                        }
                    }

                    public class UsersRolesPage(IPage currentPage) : TestPage(currentPage)
                    {
                        private bool _successfullyAssignedOrUnassigned;

                        public async Task<UsersRolesPage> AssignTheRole(string roleName)
                        {
                            //await Screenshot("AssignTheRole");

                            await CurrentPage
                                .Locator("app-common-picker")
                                .Filter(new() { HasText = "Available" })
                                .WaitForAsync();


                            await CurrentPage
                                .Locator("app-common-picker")
                                .Filter(new() { HasText = "Available" })
                                .GetByText($"{roleName}", new() { Exact = true })
                                .ClickAsync();

                            await CurrentPage.Locator("#assignBtn").ClickAsync();

                            _successfullyAssignedOrUnassigned = await WaitForSaveToComplete();

                            return this;
                        }

                        public async Task<UsersRolesPage> UnAssignTheRole(string roleName)
                        {
                            await CurrentPage
                                .Locator("app-common-picker")
                                .Filter(new() { HasText = "Assigned" })
                                .WaitForAsync();

                            await CurrentPage
                                .Locator("app-common-picker")
                                .Filter(new() { HasText = "Assigned" })
                                .GetByText($"{roleName}", new() { Exact = true })
                                .ClickAsync();

                            await CurrentPage.Locator("#unAssignBtn").ClickAsync();

                            _successfullyAssignedOrUnassigned = await WaitForSaveToComplete();

                            return this;
                        }

                        public async Task<bool> IsAssigned(string roleName)
                        {
                            await CurrentPage
                                .Locator("app-common-picker")
                                .Filter(new() { HasText = "Assigned" })
                                .WaitForAsync();

                            await CurrentPage
                                .Locator("app-common-picker")
                                .Filter(new() { HasText = "Assigned" })
                                .GetByText($"{roleName}", new() { Exact = true })
                                .WaitForAsync();

                            return true;
                        }

                        private async Task<bool> WaitForSaveToComplete()
                        {
                            await CurrentPage.Locator("#toast-container").GetByText("Success", new() { Exact = true }).WaitForAsync();

                            //await CurrentPage.Locator("#toast-container").GetByLabel("Success").WaitForAsync(new() { State = WaitForSelectorState.Hidden });

                            return true;
                        }

                        public bool SuccessPopupShowed()
                        {
                            return _successfullyAssignedOrUnassigned;
                        }
                    }
                }
            }
        }

        public class AddUserNewUserPage(IPage page) : TestPage(page)
        {
            private string? _userName;
            private bool _successfullyCreated;

            public async Task<AddUserNewUserPage> SetFirstName(string firstName)
            {
                await CurrentPage.Locator("#addUserModal").Locator("#FirstName").FillAsync(firstName);

                return this;
            }

            public async Task<AddUserNewUserPage> SetLastName(string lastName)
            {
                await CurrentPage.Locator("#addUserModal").Locator("#LastName").FillAsync(lastName);
                return this;
            }

            public async Task<AddUserNewUserPage> SetUserName(string userName)
            {
                _userName = userName;

                await CurrentPage.Locator("#addUserModal").Locator("#Username").FillAsync(userName);

                return this;
            }

            public async Task<AddUserNewUserPage> SetEmailAddress(string emailAddress)
            {
                await CurrentPage.Locator("#addUserModal").Locator("#Email").FillAsync(emailAddress);

                return this;
            }

            public async Task<AddUserNewUserPage> SetPassword(string password)
            {
                await CurrentPage.Locator("#addUserModal").Locator("form").Locator("#Password").FillAsync(password);

                return this;
            }

            public async Task<AddUserNewUserPage> Save()
            {
                await CurrentPage.Locator("#addUserModal").Locator("#addUserSubmit").ClickAsync();

                await CurrentPage.Locator("#toast-container").GetByLabel($"User {_userName} Created").WaitForAsync();

                await CurrentPage.Locator("#toast-container").GetByLabel($"User {_userName} Created").WaitForAsync(new() { State = WaitForSelectorState.Hidden });

                _successfullyCreated = true;

                return this;
            }

            public bool CreatedPopupWasVisible()
            {
                return _successfullyCreated;
            }
        }
    }
}