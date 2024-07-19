namespace IdentityExpress.Manager.BusinessLogic.OpenIddict.Constants;

public static class AdminUiConstants
{
    public const string ApplicationPropertyBagUrnPrefix = "urn:com:rocksolidknowledge:adminui:application:property:";
    public const string ApplicationPropertyClaims = $"{ApplicationPropertyBagUrnPrefix}claims";
    public const string ApplicationAdminUiClientType = $"{ApplicationPropertyBagUrnPrefix}type";

    public const string ScopePropertyBagUrnPrefix = "urn:com:rocksolidknowledge:adminui:scope:property:";
    public const string ScopePropertyClaims = $"{ScopePropertyBagUrnPrefix}claims";
}