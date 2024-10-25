using Microsoft.EntityFrameworkCore;

namespace Rsk.Samples.OpenIddict.AdminUiIntegration.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options);
