using Microsoft.Playwright;

namespace TestService.Pages
{
    public class LicensePage(IPage currentPage, IResponse licenseResponse) : TestPage(currentPage)
    {
        public async Task<bool> IsLicenseExpired()
        {
            var body = await licenseResponse.TextAsync();

            return (await licenseResponse.TextAsync()).Contains("isExpired\":true");
        }
    }
}
