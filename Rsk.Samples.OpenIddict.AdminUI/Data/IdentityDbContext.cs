using IdentityExpress.Identity;
using Microsoft.EntityFrameworkCore;

namespace Rsk.Samples.OpenIddict.AdminUiIntegration.Data;

public class IdentityDbContext(DbContextOptions<IdentityDbContext> options)
    : IdentityExpressDbContext<ApplicationUser>(options);