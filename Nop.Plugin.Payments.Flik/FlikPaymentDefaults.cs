namespace Nop.Plugin.Payments.Flik;

/// <summary>
/// Represents the default values
/// </summary>
public static class FlikPaymentDefaults
{
    public static readonly string SystemName = "Payments.Flik";

    public static readonly string ViewsPath = $"~/Plugins/{SystemName}/Views";

    public static readonly string[] AllowedCountries = { "SI" };
}
