using Microsoft.Playwright;
using TestService.Models;
using TestService.Pages;

namespace TestService.TestCollections.Fixture
{
    public sealed class AdminUiAutoTestFixture : IAsyncLifetime
    {
        public AdminUiHomePage? AdminUiHomePage { get; set; }
        public IBrowser? Browser { get; set; } = null!;
        public IBrowserContext? BrowserContext { get; set; }
        public static bool Headless { get; set; } = false;
        public string? CurrentUserEmail { get; set; }
        public string? CurrentRoleName { get; set; }
        public string? CurrentClientName { get; set; }
        public string? CurrentResourceName { get; set; }
        public static readonly User TestUser = UserFactory.GetTheTestUser();
        public static readonly string DefaultPassword = "Password123!";

        public async Task InitializeAsync()
        {
            await InitBrowser();
        }

        async Task IAsyncLifetime.DisposeAsync()
        {
            await BrowserContext!.DisposeAsync();

            if (Browser != null) await Browser.DisposeAsync();
        }

        private async Task InitBrowser()
        {
            var playwright = await Playwright.CreateAsync();

            // TODO: Create environment variables BrowserType and HeadlessMode on the host. Read these at this point and launch the browser type in the headless mode.  
            Browser ??= await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
            {
                Headless = Headless,
            });

            BrowserContext = await Browser.NewContextAsync(new BrowserNewContextOptions()
            {
                IgnoreHTTPSErrors = true, 
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/125.0.0.0 Safari/537.36"
            });
        }
    }
}
