dotnet ef migrations add InitialIdentity_IdentityExpress6 -o Migrations/Identity --context IdentityDbContext
dotnet ef migrations add InitialApplication_OpenIddict5 -o Migrations/OpenIddict --context ApplicationDbContext

#dotnet ef migrations add InitialSamlConfig -o Migrations/Saml/Config --context SamlConfigurationDbContext
#dotnet ef migrations add InitialSamlArtifact -o Migrations/Saml/Artifact --context SamlArtifactDbContext
#dotnet ef migrations add InitialSamlMessage -o Migrations/Saml/Msg --context OpenIddictSamlMessageDbContext
