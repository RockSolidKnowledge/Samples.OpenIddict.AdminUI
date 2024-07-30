namespace TestService.TestCollections.HomePageViews.ClientsView
{
    public static class SetupInfoFactory
    {
        static readonly string DisplayUrl = "https://abc/AdminUI/Auto-Tests";
        static readonly string LogoUrl = "https://abc/AdminUI/Auto-Tests/images/1";
        static readonly bool RequiredConsent = true;
        static readonly string CallbackUrl = "https://abc/AdminUI/Support";
        static readonly string LogoutUrl = "https://abc/AdminUI-Home";
        static readonly List<string> IdentityResources = new() { "Admin UI Profile" };
        static readonly List<string> ProtectedResources = new() { "Admin API" };

        public static readonly ExtendedClientSetupInfo ExtendedClientSetup = new (
            DisplayUrl,
            LogoUrl,
            RequiredConsent,
            CallbackUrl,
            LogoutUrl
        );

        public static readonly ResourceSettings SharedResourceSettings = new (
            IdentityResources,
            ProtectedResources
        );

        public static SinglePageClientSetupInfo CreateSinglePageClientSetupInfo()
        {
            return new SinglePageClientSetupInfo
            (
                new IdentificationSetupInfo
                (
                Guid.NewGuid().ToString(),
                "AdminUI test-bot SPA",
                "The AdminUI test-bot Single Page App"
                ),
                ExtendedClientSetup,
                SharedResourceSettings
            );
        }

        public static WepAppClientSetupInfo CreateWebAppClientSetupInfo()
        {
            return new WepAppClientSetupInfo
            (
                new IdentificationSetupInfo
                (
                Guid.NewGuid().ToString(),
                "AdminUI test-bot WebApp",
                "The AdminUI test-bot WebApp"
                ),
                "Authorization code flow + PKCE",
                ExtendedClientSetup,
                SharedResourceSettings,
                new ClientSecretsSettings(
                    "Shared Secret", // TODO : TBD: The secret Value behaves differently based on the selected Type. Should we test all scenarios? Two input elements share the "SecretValue" ID. This makes testing near impossible 
                    Guid.NewGuid().ToString(),
                    DateTime.UtcNow.Date,
                    "Super secret")
            );
        }

        public static MachineClientSetupInfo CreateMachineClientSetupInfo()
        {
            return new MachineClientSetupInfo
            (
                new IdentificationSetupInfo
                (
                Guid.NewGuid().ToString(),
                "AdminUI test-bot Machine",
                "The AdminUI test-bot Machine"
                ),
                "Client Credentials",
                ExtendedClientSetup,
                SharedResourceSettings,
                new ClientSecretsSettings
                (
                    "Shared Secret", // TODO : TBD: The secret Value behaves differently based on the selected Type. Should we test all scenarios? Two input elements share the "SecretValue" ID. This makes testing near impossible 
                    Guid.NewGuid().ToString(),
                    DateTime.UtcNow.Date,
                    "Super secret"
                )
            );
        }

        public static DeviceClientSetupInfo CreateDeviceClientSetupInfo()
        {
            return new DeviceClientSetupInfo
            (
                new IdentificationSetupInfo
                (
                    Guid.NewGuid().ToString(),
                    "AdminUI test-bot Device",
                    "The AdminUI test-bot Device"
                ),
                SharedResourceSettings
            );
        }

        public static SinglePageAppLegacyClientSetupInfo CreateSinglePageAppLegacyClientSetupInfo()
        {
            return new SinglePageAppLegacyClientSetupInfo
            (
                new IdentificationSetupInfo
                (
                    Guid.NewGuid().ToString(),
                    "AdminUI test-bot SPA Legacy",
                    "The AdminUI test-bot Single Page App (Legacy)"
                ),
                ExtendedClientSetup,
                SharedResourceSettings);
        }

        public static NativeClientSetupInfo CreateNativeClientSetupInfo()
        {
            return new NativeClientSetupInfo
            (
                new IdentificationSetupInfo
                (
                    Guid.NewGuid().ToString(),
                    "AdminUI test-bot Native Client",
                    "The AdminUI test-bot Native Client"
                ),
                "Authorization code flow + PKCE",
                ExtendedClientSetup,
                SharedResourceSettings,
                new ClientSecretsSettings(
                    "Shared Secret", // TODO : TBD: The secret Value behaves differently based on the selected Type. Should we test all scenarios? Two input elements share the "SecretValue" ID. This makes testing near impossible 
                    Guid.NewGuid().ToString(),
                    DateTime.UtcNow.Date,
                    "Top secret")
            );
        }

        public static SAMLClientSetupInfo CreateSAMLClientSetupInfo()
        {
            return new SAMLClientSetupInfo
            (
                new IdentificationSetupInfo
                (
                    Guid.NewGuid().ToString(),
                    $"AdminUI test-bot SAML App",
                    "The AdminUI test-bot SAML App"
                ),
                new EndpointSetup
                (
                    ExtendedClientSetup.DisplayUrl,
                    "POST",
                    0
                ),
                new EndpointSetup
                (
                    ExtendedClientSetup.DisplayUrl,
                    "POST",
                    0
                ),
                new EndpointSetup
                (
                    ExtendedClientSetup.DisplayUrl,
                    "SOAP",
                    0
                ),
                SharedResourceSettings.IdentityResources
            );
        }

        public static WsFedRelyingPartyClientSetupInfo CreateWsFedRelyingPartyClientSetupInfo()
        {
            return new WsFedRelyingPartyClientSetupInfo
            (
                new IdentificationSetupInfo
                (
                    Guid.NewGuid().ToString(),
                    "AdminUI test-bot - Ws-Fed Relying Party",
                    "The AdminUI test-bot - Ws-Fed Relying Party App"
                ),
                ExtendedClientSetup.CallbackUrl,
                SharedResourceSettings.IdentityResources
            );
        }

        public static ResourceSetupInfo CreateResourceSetupInfo(ResourceType type)
        {
            return new ResourceSetupInfo
            (
                new IdentificationSetupInfo
                (
                    Guid.NewGuid().ToString(),
                    type == ResourceType.Identity ? $"Identity Resource - {Guid.NewGuid()}" : $"Protected Resource - {Guid.NewGuid()}",
                    $"Auto-TestFixture Resource - {Guid.NewGuid()}"
                ),
                new ResourceSettings
                (
                    type == ResourceType.Identity ?  new List<string>() {"Birthdate", "Email", "Phone Number"} : new(),
                    type == ResourceType.Identity ? new() : new List<string>() { "Birthdate", "Email", "Phone Number" }
                )
            );
        }

        public static ClaimTypeSetupInfo CreateClaimTypeSetupInfo()
        {
            return new ClaimTypeSetupInfo
            (
                new IdentificationSetupInfo
                (
                    Guid.NewGuid().ToString(),
                    $"Claim Type - {Guid.NewGuid()}",
                    $"Auto-TestFixture Claim type - {Guid.NewGuid()}"
                ),
                "String",
                "Regex Rule",
                "The Rule Validation Failure Description"
            );
        }

        public record SinglePageClientSetupInfo
        (
            IdentificationSetupInfo IdentificationInfo,
            ExtendedClientSetupInfo ExtendedSetupInfo,
            ResourceSettings ResourceSettings
        );

        public record WepAppClientSetupInfo
        (
            IdentificationSetupInfo IdentificationInfo,
            string SupportedFlow,
            ExtendedClientSetupInfo ExtendedSetupInfo,
            ResourceSettings ResourceSettings,
            ClientSecretsSettings SecretsSettings
        );

        public record MachineClientSetupInfo
        (
            IdentificationSetupInfo IdentificationInfo,
            string SupportedFlow,
            ExtendedClientSetupInfo ExtendedSetupInfo,
            ResourceSettings ResourceSettings,
            ClientSecretsSettings SecretsSettings
        );

        public record NativeClientSetupInfo(
            IdentificationSetupInfo IdentificationInfo,
            string SupportedFlow,
            ExtendedClientSetupInfo ExtendedSetupInfo,
            ResourceSettings ResourceSettings,
            ClientSecretsSettings SecretsSettings
        );

        public record DeviceClientSetupInfo
        (
            IdentificationSetupInfo IdentificationInfo,
            ResourceSettings ResourceSettings
        );

        public record SinglePageAppLegacyClientSetupInfo
        (
            IdentificationSetupInfo IdentificationInfo,
            ExtendedClientSetupInfo ExtendedSetupInfo,
            ResourceSettings ResourceSettings
        );

        public record SAMLClientSetupInfo
        (
            IdentificationSetupInfo IdentificationInfo,
            EndpointSetup ACSEndpointSetup,
            EndpointSetup SLOEndpointSetup,
            EndpointSetup ARSEndpointSetup,
            List<string> IdentityResources
        );

        public record WsFedRelyingPartyClientSetupInfo
        (
            IdentificationSetupInfo IdentificationInfo,
            string CallbackUrl,
            List<string> IdentityResources
        );

        public record ResourceSetupInfo
        (
            IdentificationSetupInfo IdentificationSetupInfo,
            ResourceSettings ResourceSettings
        );

        public record ClaimTypeSetupInfo
        (
            IdentificationSetupInfo IdentificationInfo,
            string Type,
            string RegexRule,
            string RuleValidationFailureDescription
        );

        public record IdentificationSetupInfo
        (
            string UniqueIdentifier,
            string DisplayName,
            string Description
        );

        public record ExtendedClientSetupInfo
        (
            string DisplayUrl,
            string LogoUrl,
            bool RequiredConsent,
            string CallbackUrl,
            string LogoutUrl
        );
        
        public record ResourceSettings
        (
            List<string> IdentityResources,
            List<string> ProtectedResources
        );

        public record ClientSecretsSettings
        (
            string Type,
            string Value,
            DateTime ExpiryDate,
            string Description
        );

        public record EndpointSetup
        (
            string Endpoint,
            string BindingType,
            int EndpointIndex
        );

        public enum ResourceType
        {
            Identity = 0,
            Protected = 1,
        }

    }
}
