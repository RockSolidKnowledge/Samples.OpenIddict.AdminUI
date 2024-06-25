using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.SAMLServiceProvider
{
    public class SAMLSLOEndpointsSetup(IPage page) : EndpointsSetup(page)
    {
        public async Task<SAMLSLOEndpointsSetup> SetEndpoint(string endpoint)
        {
            await InternalSetEndpoint(endpoint);

            return this;
        }

        public async Task<SAMLSLOEndpointsSetup> SetBindingType(string bindingType)
        {
            await InternalSetBindingType(bindingType);

            return this;
        }

        public async Task<SAMLSLOEndpointsSetup> SetIndex(int index)
        {
            await InternalSetIndex(index);

            return this;
        }

        public async Task<SAMLARSEndpointsSetup> Next()
        {
            await InternalNext();

            return new SAMLARSEndpointsSetup(Page);
        }
    }
}
