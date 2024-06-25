using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients.SAMLServiceProvider
{
    public class SAMLARSEndpointsSetup(IPage page) : EndpointsSetup(page)
    {
        public async Task<SAMLARSEndpointsSetup> SetEndpoint(string endpoint)
        {
            await InternalSetEndpoint(endpoint);

            return this;
        }

        public async Task<SAMLARSEndpointsSetup> SetBindingType(string bindingType)
        {
            await InternalSetBindingType(bindingType);

            return this;
        }

        public async Task<SAMLARSEndpointsSetup> SetIndex(int index)
        {
            await InternalSetIndex(index);

            return this;
        }

        public async Task<SAMLIdentityResourceSetup> Next()
        {
            await InternalNext();

            return new SAMLIdentityResourceSetup(Page);
        }
    }
}
