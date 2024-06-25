using IdentityExpress.Manager.BusinessLogic.Configuration;
using IdentityExpress.Manager.UI.Extensions;
using IdentityExpress.Manager.UI.OpenIddict.Extensions;

namespace AdminUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAdminUI(options =>
            {
                options.MigrationOptions = MigrationOptions.None;
            });
            var app = builder.Build();
            app.UseAdminUI();
            app.Run();
        }
    }
}
