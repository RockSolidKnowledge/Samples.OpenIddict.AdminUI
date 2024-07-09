using Microsoft.Playwright;

namespace TestService.Pages
{
    public abstract class TestPage(IPage currentPage)
    {
        public IPage CurrentPage { get; init; } = currentPage;

        //CurrentPage.Console += OutputConsoleMessage;

        public async Task<string?> GetTitle()
        {
            return await CurrentPage.Locator("title").TextContentAsync();
        }
        
        public virtual async Task<string> GetMainHeader()
        {
            return await Task.FromResult("");
        }

        private static void OutputConsoleMessage(object? sender, IConsoleMessage e)
        {
            DateTime now = DateTime.Now;

            if ("error".Equals(e.Type))
            {
                Console.WriteLine($"{now.Year}-{now.Hour}{now.Minute}{now.Second}-{now.Millisecond} :  javascript : Message: {e.Text}");
            }
        }

        protected async Task Screenshot(string caller)
        {
            DateTime now = DateTime.Now;

            await CurrentPage.ScreenshotAsync(new(){Path = $"/log/{caller}-{now.Hour}{now.Minute}{now.Second}-{now.Millisecond}.png"});
        }
    }
}
