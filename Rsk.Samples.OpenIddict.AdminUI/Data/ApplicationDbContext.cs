using IdentityExpress.Identity;
using Microsoft.EntityFrameworkCore;

namespace Rsk.Samples.OpenIddict.AdminUiIntegration.Data;

public class ApplicationDbContext : IdentityExpressDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
}
