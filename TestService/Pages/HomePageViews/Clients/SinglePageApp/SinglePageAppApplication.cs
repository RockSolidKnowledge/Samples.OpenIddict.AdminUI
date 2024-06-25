using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.SinglePageApp
{
    public class SinglePageAppApplication(IPage page) : ClientApplication(page)
    {
        public async Task<SinglePageAppApplicationSetup> Start()
        {
            await InternalStart();

            return new SinglePageAppApplicationSetup(Page);
        }
    }
}

