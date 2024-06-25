using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.SAMLServiceProvider
{
    public class SAMLApplication(IPage page) : ClientApplication(page)
    {
        public async Task<SAMLApplicationSetup> Start()
        {
            await InternalStart();

            return new SAMLApplicationSetup(Page);
        }
    }
}
