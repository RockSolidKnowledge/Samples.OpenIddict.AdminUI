using System;
using System.Reflection;
using IdentityExpress.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Rsk.Saml.Configuration;
using Rsk.Saml.OpenIddict.AspNetCore.Identity.Configuration.DependencyInjection;
using Rsk.Saml.OpenIddict.Configuration.DependencyInjection;
using Rsk.Saml.OpenIddict.EntityFrameworkCore.Configuration.DependencyInjection;
using Rsk.Saml.OpenIddict.Quartz.Configuration.DependencyInjection;
using Rsk.Samples.OpenIddict.AdminUiIntegration.Data;
using Rsk.Samples.OpenIddict.AdminUiIntegration.Services;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Rsk.Samples.OpenIddict.AdminUiIntegration;

public class Startup
{
    public Startup(IConfiguration configuration)
        => Configuration = configuration;

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddRazorPages();

        services.AddDbContext<IdentityDbContext>(GetDbConnection);
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            GetDbConnection(options);

            // Register the entity sets needed by OpenIddict.
            // Note: use the generic overload if you need
            // to replace the default OpenIddict entities.
            options.UseOpenIddict();
        });

        services.AddDatabaseDeveloperPageExceptionFilter();

        // Register the Identity services.
        services.AddIdentity<ApplicationUser, IdentityExpressRole>()
            .AddEntityFrameworkStores<IdentityDbContext>()
            .AddDefaultTokenProviders()
            .AddSignInManager<CustomSignInManager>();

        // OpenIddict offers native integration with Quartz.NET to perform scheduled tasks
        // (like pruning orphaned authorizations/tokens from the database) at regular intervals.
        services.AddQuartz(options =>
        {
            options.UseMicrosoftDependencyInjectionJobFactory();
            options.UseSimpleTypeLoader();
            options.UseInMemoryStore();
        });

        // Register the Quartz.NET service and configure it to block shutdown until jobs are complete.
        services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

        services.AddOpenIddict()

            // Register the OpenIddict core components.
            .AddCore(options =>
            {
                // Configure OpenIddict to use the Entity Framework Core stores and models.
                // Note: call ReplaceDefaultEntities() to replace the default OpenIddict entities.
                options.UseEntityFrameworkCore()
                    .UseDbContext<ApplicationDbContext>();

                // Enable Quartz.NET integration.
                options.UseQuartz();
            })

            // Register the OpenIddict server components.
            .AddServer(options =>
            {
                options.DisableAccessTokenEncryption();
                
                // Enable the authorization, logout, token and userinfo endpoints.
                options
                    //Authorisation Endpoints
                    .SetAuthorizationEndpointUris("connect/authorize")
                    .SetLogoutEndpointUris("connect/logout")
                    //Device Endpoints
                    .SetDeviceEndpointUris("connect/device")
                    .SetVerificationEndpointUris("connect/verify")
                    //Shared Endpoints
                    .SetTokenEndpointUris("connect/token")
                    .SetUserinfoEndpointUris("connect/userinfo");

                // Mark the "email", "profile" and "roles" scopes as supported scopes.
                options.RegisterScopes(Scopes.Email, Scopes.Profile, Scopes.Roles);

                options.AllowAuthorizationCodeFlow()
                    .AllowRefreshTokenFlow()
                    .AllowClientCredentialsFlow()
                    .AllowDeviceCodeFlow();

                // Register the signing and encryption credentials.
                options.AddDevelopmentEncryptionCertificate()
                    .AddDevelopmentSigningCertificate();

                // Register the ASP.NET Core host and configure the ASP.NET Core-specific options.
                options.UseAspNetCore()
                    .DisableTransportSecurityRequirement()
                    .EnableAuthorizationEndpointPassthrough()
                    .EnableLogoutEndpointPassthrough()
                    .EnableTokenEndpointPassthrough()
                    .EnableUserinfoEndpointPassthrough()
                    .EnableStatusCodePagesIntegration()
                    .EnableVerificationEndpointPassthrough();
                
                options.AddSamlPlugin(builder =>
                {
                    builder.UseSamlEntityFrameworkCore()
                        .AddSamlArtifactDbContext(GetDbConnection)
                        .AddSamlConfigurationDbContext(GetDbConnection)
                        .AddSamlMessageDbContext(GetDbConnection);
                
                    builder.ConfigureSamlOpenIddictServerOptions(serverOptions =>
                    {
                        serverOptions.HostOptions = new SamlHostUserInteractionOptions()
                        {
                            LoginUrl = "/Identity/Account/Login",
                            LogoutUrl = "/connect/logout",
                        };
                        
                        var licensee = Configuration.GetValue<string>("SAML2PLicensee");
                        var license = Configuration.GetValue<string>("SAML2PLicense");
                        serverOptions.IdpOptions = new SamlIdpOptions()
                        {
                            Licensee = licensee,
                            LicenseKey = license,
                        };
                    });
                
                    builder.PruneSamlMessages();
                
                    builder.AddSamlAspIdentity<ApplicationUser>();
                });
            })

            // Register the OpenIddict validation components.
            .AddValidation(options =>
            {
                // Import the configuration from the local OpenIddict server instance.
                options.UseLocalServer();

                // Register the ASP.NET Core host.
                options.UseAspNetCore();
            });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseStatusCodePagesWithReExecute("~/error");
            //app.UseExceptionHandler("~/error");

            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseOpenIddictSamlPlugin();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapDefaultControllerRoute();
            endpoints.MapRazorPages();
        });
    }

    private void GetDbConnection(DbContextOptionsBuilder optBuilder)
    {
        var openIddictConnectionString = Configuration.GetValue<string>("OpenIddictConnectionString");
        var dbProvider = Configuration.GetValue<string>("DbProvider");
        var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            
        switch (dbProvider)
        {
            case "SqlServer":
                optBuilder.UseSqlServer(openIddictConnectionString, options => options.MigrationsAssembly(migrationAssembly));
                break;
            case "MySql":
                optBuilder.UseMySql(openIddictConnectionString, ServerVersion.AutoDetect(openIddictConnectionString), options => options.MigrationsAssembly(migrationAssembly));
                break;
            case "PostgreSql":
                optBuilder.UseNpgsql(openIddictConnectionString, options => options.MigrationsAssembly(migrationAssembly));
                break;
            default:
                throw new NotSupportedException($"{dbProvider} is not a supported database provider.");
        }
    }
}