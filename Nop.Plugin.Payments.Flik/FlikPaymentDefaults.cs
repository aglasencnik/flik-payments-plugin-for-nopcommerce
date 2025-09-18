namespace Nop.Plugin.Payments.Flik;

/// <summary>
/// Represents the default values
/// </summary>
public static class FlikPaymentDefaults
{
    public static readonly string SystemName = "Payments.Flik";

    public static readonly string ViewsPath = $"~/Plugins/{SystemName}/Views";
    
    public static readonly string AdminViewsPath = $"{ViewsPath}/Admin";

    public static readonly string[] AllowedCountries = { "SI" };

    public static readonly string PaymentGatewaySandboxEndpoint = "https://bankart.paymentsandbox.cloud/api/v3";
    
    public static readonly string PaymentGatewayEndpoint = "https://gateway.bankart.si/api/v3";
}
