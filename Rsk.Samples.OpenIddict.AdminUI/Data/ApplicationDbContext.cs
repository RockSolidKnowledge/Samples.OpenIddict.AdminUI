#nullable enable
using Microsoft.EntityFrameworkCore;

namespace Rsk.Samples.OpenIddict.AdminUiIntegration.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, string? schema = null) : DbContext(options)
{
    private string Schema { get; } = schema ?? string.Empty;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (!string.IsNullOrEmpty(Schema))
        {
            modelBuilder.HasDefaultSchema(Schema);
        }

        base.OnModelCreating(modelBuilder);
    }
}
