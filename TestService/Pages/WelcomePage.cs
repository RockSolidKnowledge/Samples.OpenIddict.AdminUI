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

                //try
                //{
                //    // This item is never available when the test user tries to login after being bootstrapped! The page is just a WHITE canvas! We are giving it more time to refresh  
                //    await CurrentPage.Locator("#Input_Email").WaitForAsync(new() { Timeout = 60000 });
                    
                //    await CurrentPage.Locator("#Input_Email").FillAsync(userEmail);
                //    await Screenshot("OILPageSetUserEmail");
                //}
                //catch (Exception)
                //{
                //    await Screenshot("OILPageSetUserEmailEx");
                //    throw;
                //}

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

                await CurrentPage.GetByRole(AriaRole.Button, new() { Name = " Logout " }).WaitForAsync();

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

                public async Task<LicensePage?> GetLicenseInfo(string url)
                {
                    var response = await CurrentPage.GotoAsync(url);

                    return response != null ? new LicensePage(CurrentPage, response) : null;
                }

                public class SuccessPage(IPage page) : TestPage(page)
                {
                    public async Task<WelcomePage> Login()
                    {
                        await CurrentPage.ClickAsync("#loginBtn");

                        return new WelcomePage(CurrentPage);
                    }
                }
            }
        }
    }

    //public class LogoutConfirmationPage(IPage page) : TestPage(page)
    //{
    //    public async Task<WelcomePage> AcceptToLogout()
    //    {
    //        await CurrentPage.GetByRole(AriaRole.Button, new() { Name = "Yes" }).ClickAsync();

    //        await CurrentPage.Locator("app-landing-page").Locator("#loginBtn").WaitForAsync();

    //        return new WelcomePage(CurrentPage);
    //    }
    //}
}
