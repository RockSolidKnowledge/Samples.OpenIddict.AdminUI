using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Resources.Identity
{
    public class IdentityResourcesPage : TestPage
    {
        private IdResourcesPager IdResourcesPager { get; init; }

        public IdentityResourcesPage(IPage page) : base(page)
        {
            IdResourcesPager = new IdResourcesPager(this);
        }

        public async Task<CreateIdentityResourceSetup> AddResource()
        {
            await CurrentPage.GetByRole(AriaRole.Button, new() { Name = " Add Resource " }).ClickAsync();

            await CurrentPage.WaitForSelectorAsync("#idInput");

            return new CreateIdentityResourceSetup(CurrentPage);
        }
        
        public async Task<EditIdResourcesPage> EditIdResource(string resourceName)
        {
            IdResourcesPagerPage pagerPage = await GotoTheClient(resourceName);

            return await pagerPage.GotoEditTheResource();
        }

        private async Task<IdResourcesPagerPage> GotoTheClient(string resourceName)
        {
            return await IdResourcesPager.GetThePageThatTheIdResourceIsOn(resourceName);
        }
    }

    public class IdResourcesPager
    {
        public IdResourcesPagerPage CurrentPage { get; set; }
        public IdentityResourcesPage IdResourcesPage { get; }

        public IdResourcesPager(IdentityResourcesPage idResourcesPage)
        {
            IdResourcesPage = idResourcesPage;
            CurrentPage = new IdResourcesPagerPage(this);
        }

        public async Task<bool> TryGoingToTheNextPage()
        {
            if (!await IdResourcesPage.CurrentPage.Locator("#pagerNextPage").IsEnabledAsync()) return false;
            
            await IdResourcesPage.CurrentPage.Locator("#pagerNextPage").ClickAsync();
            return true;

        }

        public async Task<IdResourcesPagerPage> GetThePageThatTheIdResourceIsOn(string idResourceName)
        {
            bool userFound;
            do
            {
                userFound = await CurrentPage.ContainsIdResource(idResourceName);

                if (userFound)
                {
                    return CurrentPage;
                }

            } while (!userFound && await TryGoingToTheNextPage());

            return await Task.FromException<IdResourcesPagerPage>(new ArgumentException($"Unknown ID Resource: {idResourceName}"));
        }
    }

    public class IdResourcesPagerPage
    {
        public IdResourcesPager Pager { get; }
        public int CurrentRow { get; set; } = -1;

        public IdResourcesPagerPage(IdResourcesPager pager)
        {
            Pager = pager;
            CurrentRow = -1;
        }
        
        public async Task<bool> ContainsIdResource(string idResourceName)
        {
            int resourceCount = await Pager.IdResourcesPage.CurrentPage
                .Locator("#identityResourceList")
                .Locator("tr")
                .CountAsync();

            for (var row = 1; row <= resourceCount; row++)
            {
                string currentResourceName = await Pager.IdResourcesPage.CurrentPage
                    .Locator("#identityResourceList")
                    .Locator($"tr:nth-child({row})")
                    .Locator("td:nth-child(1)")
                    .InnerTextAsync();

                if (currentResourceName != idResourceName) continue;
                
                Pager.CurrentPage.CurrentRow = row;
                return true;
            }

            return false;
        }
        
        public async Task<EditIdResourcesPage> GotoEditTheResource()
        {
            await Pager.IdResourcesPage.CurrentPage
                .Locator("#identityResourceList")
                .Locator($"tr:nth-child({CurrentRow})")
                .Locator("#viewOrEditIcon")
                .ClickAsync();

            return new EditIdResourcesPage(Pager.IdResourcesPage.CurrentPage);
        }
    }
    
    public class EditIdResourcesPage(IPage page) : TestPage(page)
    {
        public async Task<IdResourceDetailsPage> GotoTheIdResourcesDetailsTab()
        {
            await CurrentPage.GetByRole(AriaRole.Tablist)
                .GetByRole(AriaRole.Tab, new() { Name = "Details", Exact = true }).ClickAsync();

            await CurrentPage.WaitForSelectorAsync("#displayNameInput");

            return new IdResourceDetailsPage(CurrentPage);
        }
    }

    public class IdResourceDetailsPage(IPage page) : TestPage(page)
    {
        private bool _successfullyUpdated;

        public async Task<IdResourceDetailsPage> SetIdResourceName(string displayName)
        {
            await CurrentPage.Locator("#editIdentityResource").Locator("#displayNameInput").FillAsync(displayName);
            return this;
        }

        public async Task<IdResourceDetailsPage> SetIdResourceDescription(string displayName)
        {
            await CurrentPage.Locator("#editIdentityResource").Locator("#descriptionInput").FillAsync(displayName);
            return this;
        }

        public async Task<IdResourceDetailsPage> Save()
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
}
