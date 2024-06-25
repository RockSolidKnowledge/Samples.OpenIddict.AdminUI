using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.SAMLServiceProvider
{
    public class SAMLACSEndpointsSetup(IPage page) : EndpointsSetup(page)
    {
        public async Task<SAMLACSEndpointsSetup> SetEndpoint(string endpoint)
        {
            await InternalSetEndpoint(endpoint);

            return this;
        }

        public async Task<SAMLACSEndpointsSetup> SetBindingType(string binding)
        {
            await InternalSetBindingType(binding);

            return this;
        }

        public async Task<SAMLACSEndpointsSetup> SetIndex(int index)
        {
            await InternalSetIndex(index);

            return this;
        }

        public async Task<SAMLSLOEndpointsSetup> Next()
        {
            await InternalNext();

            return new SAMLSLOEndpointsSetup(Page);
        }
    }
}
