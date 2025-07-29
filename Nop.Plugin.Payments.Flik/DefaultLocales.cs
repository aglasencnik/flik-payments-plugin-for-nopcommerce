namespace Nop.Plugin.Payments.Flik;

/// <summary>
/// Represents the default locales.
/// </summary>
public class DefaultLocales
{
    #region Locales

    public const string BASE_LOCALE_ENDPOINT = "FlikPayments";

    public const string PAYMENT_METHOD_DESCRIPTION = $"{BASE_LOCALE_ENDPOINT}.PaymentMethodDescription";

    #region Configuration

    public const string CONFIGURATION_INSTRUCTIONS = $"{BASE_LOCALE_ENDPOINT}.Configuration.Instructions";

    public const string CONFIGURATION_ENABLE = $"{BASE_LOCALE_ENDPOINT}.Configuration.Enable";
    public const string CONFIGURATION_ENABLE_HINT = $"{BASE_LOCALE_ENDPOINT}.Configuration.Enable.Hint";

    public const string CONFIGURATION_ADDITIONAL_FEE_PERCENTAGE = $"{BASE_LOCALE_ENDPOINT}.Configuration.AdditionalFeePercentage";
    public const string CONFIGURATION_ADDITIONAL_FEE_PERCENTAGE_HINT = $"{BASE_LOCALE_ENDPOINT}.Configuration.AdditionalFeePercentage.Hint";

    public const string CONFIGURATION_ADDITIONAL_FEE = $"{BASE_LOCALE_ENDPOINT}.Configuration.AdditionalFee";
    public const string CONFIGURATION_ADDITIONAL_FEE_HINT = $"{BASE_LOCALE_ENDPOINT}.Configuration.AdditionalFee.Hint";

    public const string CONFIGURATION_REMOVE_SETTINGS_ON_UNINSTALL = $"{BASE_LOCALE_ENDPOINT}.Configuration.RemoveSettingsOnUninstall";
    public const string CONFIGURATION_REMOVE_SETTINGS_ON_UNINSTALL_HINT = $"{BASE_LOCALE_ENDPOINT}.Configuration.RemoveSettingsOnUninstall.Hint";

    #endregion

    #endregion

    #region Methods

    /// <summary>
    /// Gets the plugin locales
    /// </summary>
    /// <returns>A dictionary of locale strings</returns>
    public static Dictionary<string, string> GetPluginLocalesEn()
    {
        return new Dictionary<string, string>
        {
            [PAYMENT_METHOD_DESCRIPTION] = "Pay with Flik",

            // Configuration
            [CONFIGURATION_INSTRUCTIONS] = "Please configure the Flik Payments plugin settings below.<br />Ensure that you have the necessary API credentials and that your account is set up to accept payments.",
            [CONFIGURATION_ENABLE] = "Enable Flik Payments Plugin",
            [CONFIGURATION_ENABLE_HINT] = "Check to enable the Flik Payments plugin.",
            [CONFIGURATION_ADDITIONAL_FEE_PERCENTAGE] = "Should the additional fee be a percentage?",
            [CONFIGURATION_ADDITIONAL_FEE_PERCENTAGE_HINT] = "Check to apply the additional fee as a percentage of the order total.",
            [CONFIGURATION_ADDITIONAL_FEE] = "Additional Fee",
            [CONFIGURATION_ADDITIONAL_FEE_HINT] = "Specify the additional fee to be applied to the order total.",
            [CONFIGURATION_REMOVE_SETTINGS_ON_UNINSTALL] = "Remove settings on uninstall",
            [CONFIGURATION_REMOVE_SETTINGS_ON_UNINSTALL_HINT] = "Check to remove all settings related to the Flik Payments plugin when it is uninstalled."
        };
    }

    #endregion
}
