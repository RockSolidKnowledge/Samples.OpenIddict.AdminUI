#nullable enable
using System;
using IdentityExpress.Identity;
using Microsoft.EntityFrameworkCore;

namespace Rsk.Samples.OpenIddict.AdminUiIntegration.Data;

public class IdentityDbContext(DbContextOptions<IdentityDbContext> options, string? schema = null)
    : IdentityExpressDbContext<ApplicationUser>(options, schema ?? String.Empty);