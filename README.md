# Sample of OpenIddict Server for AdminUI Integration
**OpenIddict implementation using the ASP.NET Identity schema from the [AdminUI product](https://www.openiddictcomponents.com/products/adminui) from [Rock Solid Knowledge](https://www.openiddictcomponents.com).**

This package uses the AdminUI ASP.NET Identity schema found on [NuGet](https://www.nuget.org/packages/IdentityExpress.Identity/):

`Install-Package IdentityExpress.Identity`

*For AdminUI documentation, visit [OpenIddictComponents.com](https://www.openiddictcomponents.com/documentation/adminui/)*


## Create the database

To create the database you have to create and run migrations. You can do this from a command-line shell:

#### AdminUI migrations

This is the most basic migration to be able to run OpenIddict and AdminUI:

- Create migration:
```language-bash
dotnet ef migrations add InitialCreate -c ApplicationDbContext
```

- Run migration in database:
```language-bash
dotnet ef database update -c ApplicationDbContext
```

#### SAML migrations

You only have to run these migrations if you want to use SAML applications:

- Create migrations:
```language-bash 
dotnet ef migrations add InitialCreate -c OpenIddictSamlMessageDbContext
dotnet ef migrations add InitialCreate -c SamlConfigurationDbContext
dotnet ef migrations add InitialCreate -c SamlArtifactDbContext
```

- Run migrations in database:
```language-bash 
dotnet ef database update -c OpenIddictSamlMessageDbContext
dotnet ef database update -c SamlConfigurationDbContext
dotnet ef database update -c SamlArtifactDbContext
```

*Remember to add a [SAML license](https://www.openiddictcomponents.com/products/saml2p) in appsettings.json if you want to use the SAML component.*