using Microsoft.Playwright;
using static TestService.Pages.WelcomePage.OpenIddictLoginPage;

namespace TestService.Pages
{
    public class WelcomePage(IPage currentPage) : TestPage(currentPage)
    {
        public async Task<OpenIddictLoginPage> LogIn(string selectorId = "#loginBtn")
        {
            await CurrentPage.ClickAsync(selectorId);

            return new OpenIddictLoginPage(CurrentPage);
        }

        public override async Task<string> GetMainHeader()
        {
            return await CurrentPage.GetByRole(AriaRole.Heading, new() { Name = "Welcome to AdminUI" }).InnerTextAsync();
        }

        public class OpenIddictLoginPage(IPage page) : TestPage(page)
        {
            private const string LoginBtnId = "#login-submit";

            public async Task<OpenIddictLoginPage> SetUserEmail(string userEmail)
            {
                await CurrentPage.Locator("#Input_Email").FillAsync(userEmail);

                return this;
            }

            public async Task<OpenIddictLoginPage> SetPassword(string password)
            {
                await CurrentPage.Locator("#Input_Password").FillAsync(password);

                return this;
            }

            public async Task<AdminUserCreationPage> LoginToBootstrapAdminUser()
            {
                await CurrentPage.ClickAsync(LoginBtnId);

                return new AdminUserCreationPage(CurrentPage);
            }

            public async Task<AdminUiHomePage> Login()
            {
                await CurrentPage.ClickAsync(LoginBtnId);

                // TODO : Uncomment when the "new" AdminUI app is enabled 
                //await CurrentPage.GetByRole(AriaRole.Button, new() { Name = " Logout " }).WaitForAsync();

                return new AdminUiHomePage(CurrentPage);
            }

            public class AdminUserCreationPage(IPage page) : TestPage(page)
            {
                private static string FirstNameLabelLocator => "First Name";
                private static string LastNameLabelLocator => "Last Name";
                private static string UserNameLabelLocator => "Username";
                private static string EmailAddressLabelLocator => "Email Address";
                private static string PasswordIdLocator => "#Password";
                private static string ConfirmPasswordIdLocator => "#ConfirmPassword";
                private static string SaveButtonId => "#addUserSubmit";

                public async Task<AdminUserCreationPage> SetFirstName(string name)
                {
                    await CurrentPage.GetByLabel(FirstNameLabelLocator).FillAsync(name);

                    return this;
                }

                public async Task<AdminUserCreationPage> SetLastName(string name)
                {
                    await CurrentPage.GetByLabel(LastNameLabelLocator).FillAsync(name);

                    return this;
                }

                public async Task<AdminUserCreationPage> SetUserName(string name)
                {
                    await CurrentPage.GetByLabel(UserNameLabelLocator).FillAsync(name);

                    return this;
                }

                public async Task<AdminUserCreationPage> SetEmailAddress(string email)
                {
                    await CurrentPage.GetByLabel(EmailAddressLabelLocator).FillAsync(email);

                    return this;
                }

                public async Task<AdminUserCreationPage> SetPassword(string password)
                {

                    await CurrentPage.Locator(PasswordIdLocator).FillAsync(password);

                    return this;
                }

                public async Task<AdminUserCreationPage> SetConfirmedPassword(string password)
                {
                    await CurrentPage.Locator(ConfirmPasswordIdLocator).FillAsync(password);

                    return this;
                }

                public async Task<SuccessPage> Save()
                {
                    await CurrentPage.ClickAsync(SaveButtonId);

                    await CurrentPage.GetByRole(AriaRole.Button, new() { Name = " Save ", Disabled = true }).WaitForAsync();

                    return new SuccessPage(CurrentPage);
                }

                public async Task<LicensePage?> GetLicenseInfo()
                {
                    var response = await CurrentPage.GotoAsync("http://ui-int:5000/license");

                    return response != null ? new LicensePage(CurrentPage, response) : null;
                }

                public class SuccessPage(IPage page) : TestPage(page)
                {
                    public async Task<LogoutConfirmationPage> Login()
                    {
                        await CurrentPage.ClickAsync("#loginBtn");

                        await CurrentPage.GetByRole(AriaRole.Button, new(){Name = "Confirm"}).WaitForAsync();

                        return new LogoutConfirmationPage(CurrentPage);
                    }
                }
            }
        }
    }

    //public class ConsentPage(IPage page) : TestPage(page)
    //{
    //    public async Task<AdminUserCreationPage> AcceptToBootstrapAdminUser()
    //    {
    //        await Accept();

    //        return new AdminUserCreationPage(CurrentPage);
    //    }

    //    public async Task<AdminUiHomePage> AcceptToLoginToAdminUi()
    //    {
    //        await Accept();

    //        return new AdminUiHomePage(CurrentPage);
    //    }

    //    private async Task Accept()
    //    {
    //        await CurrentPage.GetByRole(AriaRole.Button, new() { Name = "Confirm" }).ClickAsync();
    //    }

    //    public async Task<LicensePage?> GetLicenseInfo()
    //    {
    //        var response = await CurrentPage.GotoAsync("http://ui-int:5000/license");

    //        return response != null ? new LicensePage(CurrentPage, response) : null;
    //    }
    //}

    public class LogoutConfirmationPage(IPage page) : TestPage(page)
    {
        public async Task<WelcomePage> Logout()
        {
            await CurrentPage.GetByRole(AriaRole.Button, new() { Name = "Confirm" }).ClickAsync();

            return new WelcomePage(CurrentPage);
        }
    }
}
