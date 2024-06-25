namespace TestService.Pages.HomePageViews.Clients
{
    public interface ISaveDialog //: IWizardDialog
    {
        Task<ISaveDialog> Save();
        bool SuccessfullySaved();
    }
}
