using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Resources.Protected;

public class ProtectedResourcesPage : TestPage
{
    private ProtectedResourcesPager ProtectedResourcesPager { get; init; }
    
    public ProtectedResourcesPage(IPage currentPage) : base(currentPage)
    {
        ProtectedResourcesPager = new ProtectedResourcesPager(this);
    }

    public async Task<CreateProtectedResourceSetup> AddResource()
    {
        await CurrentPage.GetByRole(AriaRole.Button, new() { Name = " Add Resource " }).ClickAsync();

        await CurrentPage.WaitForSelectorAsync("#idInput");

        return new CreateProtectedResourceSetup(CurrentPage);
    }
        
    public async Task<EditProtectedResourcesPage> EditIdResource(string resourceName)
    {
        ProtectedResourcesPagerPage pagerPage = await GotoTheClient(resourceName);

        return await pagerPage.GotoEditTheResource();
    }

    private async Task<ProtectedResourcesPagerPage> GotoTheClient(string resourceName)
    {
        return await ProtectedResourcesPager.GetThePageThatTheProtectedResourceIsOn(resourceName);
    }
}

public class ProtectedResourcesPager
{
    public ProtectedResourcesPagerPage CurrentPage { get; set; }
    public ProtectedResourcesPage ProtectedResourcesPage { get; }

    public ProtectedResourcesPager(ProtectedResourcesPage protectedResourcesPage)
    {
        ProtectedResourcesPage = protectedResourcesPage;
        CurrentPage = new ProtectedResourcesPagerPage(this);
    }

    public async Task<bool> TryGoingToTheNextPage()
    {
        if (!await ProtectedResourcesPage.CurrentPage.Locator("#pagerNextPage").IsEnabledAsync()) return false;
            
        await ProtectedResourcesPage.CurrentPage.Locator("#pagerNextPage").ClickAsync();
        return true;

    }

    public async Task<ProtectedResourcesPagerPage> GetThePageThatTheProtectedResourceIsOn(string idResourceName)
    {
        bool userFound;
        do
        {
            userFound = await CurrentPage.ContainsProtectedResource(idResourceName);

            if (userFound)
            {
                return CurrentPage;
            }

        } while (!userFound && await TryGoingToTheNextPage());

        return await Task.FromException<ProtectedResourcesPagerPage>(new ArgumentException($"Unknown Protected Resource: {idResourceName}"));
    }
}

public class ProtectedResourcesPagerPage
{
    public ProtectedResourcesPager Pager { get; }
    public int CurrentRow { get; set; } = -1;

    public ProtectedResourcesPagerPage(ProtectedResourcesPager pager)
    {
        Pager = pager;
        CurrentRow = -1;
    }
        
    public async Task<bool> ContainsProtectedResource(string protectedResourceName)
    {
        int resourceCount = await Pager.ProtectedResourcesPage.CurrentPage
            .Locator("#protectedResourcesList")
            .Locator("tr")
            .CountAsync();

        for (var row = 1; row <= resourceCount; row++)
        {
            string currentResourceName = await Pager.ProtectedResourcesPage.CurrentPage
                .Locator("#protectedResourcesList")
                .Locator($"tr:nth-child({row})")
                .Locator("td:nth-child(1)")
                .InnerTextAsync();

            if (currentResourceName != protectedResourceName) continue;
                
            Pager.CurrentPage.CurrentRow = row;
            return true;
        }

        return false;
    }
        
    public async Task<EditProtectedResourcesPage> GotoEditTheResource()
    {
        await Pager.ProtectedResourcesPage.CurrentPage
            .Locator("#protectedResourcesList")
            .Locator($"tr:nth-child({CurrentRow})")
            .Locator("#viewOrEditIcon")
            .ClickAsync();

        return new EditProtectedResourcesPage(Pager.ProtectedResourcesPage.CurrentPage);
    }
}

public class EditProtectedResourcesPage(IPage page) : TestPage(page)
{
    public async Task<ProtectedResourceDetailsPage> GotoTheIdResourcesDetailsTab()
    {
        await CurrentPage.GetByRole(AriaRole.Tablist)
            .GetByRole(AriaRole.Tab, new() { Name = "Details", Exact = true }).ClickAsync();

        await CurrentPage.WaitForSelectorAsync("#displayNameInput");

        return new ProtectedResourceDetailsPage(CurrentPage);
    }
}

public class ProtectedResourceDetailsPage(IPage page) : TestPage(page)
{
    private bool _successfullyUpdated;

    public async Task<ProtectedResourceDetailsPage> SetProtectedResourceName(string displayName)
    {
        await CurrentPage.Locator("#editProtectedResource").Locator("#displayNameInput").FillAsync(displayName);
        return this;
    }

    public async Task<ProtectedResourceDetailsPage> SetProtectedResourceDescription(string displayName)
    {
        await CurrentPage.Locator("#editProtectedResource").Locator("#descriptionInput").FillAsync(displayName);
        return this;
    }

    public async Task<ProtectedResourceDetailsPage> Save()
    {
        await CurrentPage
            .Locator("app-button-bar")
            .Locator("button.tw-btn-success")
            .ClickAsync();

        await CurrentPage.GetByLabel("Success").First.WaitForAsync();

        // The popup lingers for too long and that subsequent calls may show a stack of them. We must wait till it popup disappears to avoid multiple calls seeing a stack of them
        await CurrentPage.GetByLabel("Success").First.WaitForAsync(new() { State = WaitForSelectorState.Hidden });

        _successfullyUpdated = true;

        return this;
    }
        
    public bool SuccessPopupWasVisible()
    {
        return _successfullyUpdated;
    }
}