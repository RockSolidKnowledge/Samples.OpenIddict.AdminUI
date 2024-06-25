using Microsoft.Playwright;

namespace TestService.Pages.HomePageViews.Clients
{
    public class ClientsPage : TestPage
    {
        private ClientsPager ClientsPager { get; init; }

        public ClientsPage(IPage page) : base(page)
        {
            ClientsPager = new ClientsPager(this);
        }

        public async Task<ClientWizardPage> AddClient()
        {
            await CurrentPage.Locator("#addClientBtn").ClickAsync();

            return new ClientWizardPage(CurrentPage);
        }
        
        public async Task<EditClientsPage> EditTheClient(string clientName)
        {
            ClientsPagerPage pagerPage = await GotoTheClient(clientName);

            return await pagerPage.GotoEditTheUser();
        }

        private async Task<ClientsPagerPage> GotoTheClient(string clientName)
        {
            return await ClientsPager.GetThePageThatTheClientIsOn(clientName);
        }

    }

    public class ClientsPager
    {
        public ClientsPagerPage CurrentPage { get; set; }
        public ClientsPage ClientsPage { get; }

        public ClientsPager(ClientsPage clientsPage)
        {
            ClientsPage = clientsPage;
            CurrentPage = new ClientsPagerPage(this);
        }

        public async Task<bool> TryGoingToTheNextPage()
        {
            if (!await ClientsPage.CurrentPage.Locator("#pagerNextPage").IsEnabledAsync()) return false;
            
            await ClientsPage.CurrentPage.Locator("#pagerNextPage").ClickAsync();
            return true;

        }

        public async Task<ClientsPagerPage> GetThePageThatTheClientIsOn(string clientName)
        {
            bool clientFound;
            do
            {
                clientFound = await CurrentPage.ContainsClient(clientName);

                if (clientFound)
                {
                    return CurrentPage;
                }

            } while (!clientFound && await TryGoingToTheNextPage());

            return await Task.FromException<ClientsPagerPage>(new ArgumentException($"Unknown client: {clientName}"));
        }
    }

    public class ClientsPagerPage
    {
        public ClientsPager Pager { get; }
        public int CurrentRow { get; set; } = -1;

        public ClientsPagerPage(ClientsPager pager)
        {
            Pager = pager;
            CurrentRow = -1;
        }
        
        public async Task<bool> ContainsClient(string clientName)
        {
            int clientCount = await Pager.ClientsPage.CurrentPage
                .Locator("#clientsTable")
                .Locator("tr")
                .CountAsync();

            for (var row = 1; row <= clientCount; row++)
            {
                string currentClientName = await Pager.ClientsPage.CurrentPage
                    .Locator("#clientsTable")
                    .Locator($"tr:nth-child({row})")
                    .Locator("td:nth-child(2)")
                    .InnerTextAsync();

                if (currentClientName != clientName) continue;
                
                Pager.CurrentPage.CurrentRow = row;
                return true;
            }

            return false;
        }
        
        public async Task<EditClientsPage> GotoEditTheUser()
        {
            await Pager.ClientsPage.CurrentPage
                .Locator("#clientsTable")
                .Locator($"tr:nth-child({CurrentRow})")
                .Locator("#viewOrEditIcon")
                .ClickAsync();

            return new EditClientsPage(Pager.ClientsPage.CurrentPage);
        }
    }
    
    public class EditClientsPage(IPage page) : TestPage(page)
    {
        public async Task<ClientsDetailsPage> GotoTheClientsDetailsTab()
        {
            await CurrentPage.GetByRole(AriaRole.Tablist)
                .GetByRole(AriaRole.Tab, new() { Name = "Details", Exact = true }).ClickAsync();

            await CurrentPage.WaitForSelectorAsync("#cloneBtn");

            return new ClientsDetailsPage(CurrentPage);
        }
    }

    public class ClientsDetailsPage(IPage page) : TestPage(page)
    {
        private bool _successToastWasVisible;

        //TODO : This was inherited. It's always false. Triggers build warnings. Need to justify for motive for introducing it in the first place. 
        //private bool _errorToastWasVisible;

        public async Task<ClientsDetailsPage> SetClientName(string displayName)
        {
            await CurrentPage.Locator("#editClientDetails").Locator("#clientName").FillAsync(displayName);

            return this;
        }

        public async Task<ClientsDetailsPage> Save()
        {
            LocatorGetByLabelOptions locatorOptions = new () { Exact = true };
            
            await CurrentPage.Locator("#submitBtn").ClickAsync();
            
            var toastContainer = CurrentPage.Locator("#toast-container");
            
            await toastContainer.GetByLabel("Success", locatorOptions).WaitForAsync();
            // The popup lingers for too long and that subsequent calls may show a stack of them. We must wait till it popup disappears to avoid multiple calls seeing a stack of them
            await toastContainer.GetByLabel("Success", locatorOptions).First.WaitForAsync(new() { State = WaitForSelectorState.Hidden });
                
            _successToastWasVisible = true;
            return this;
        }
        
        public bool SuccessToastWasVisible()
        {
            return _successToastWasVisible;
        }
        
        //public bool ErrorToastWasVisible()
        //{
        //    return _errorToastWasVisible;
        //}
    }
}
