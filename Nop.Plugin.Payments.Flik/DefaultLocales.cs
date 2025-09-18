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

    public const string CONFIGURATION_SANDBOX = $"{BASE_LOCALE_ENDPOINT}.Configuration.Sandbox";
    public const string CONFIGURATION_SANDBOX_HINT = $"{BASE_LOCALE_ENDPOINT}.Configuration.Sandbox.Hint";

    public const string CONFIGURATION_API_KEY = $"{BASE_LOCALE_ENDPOINT}.Configuration.ApiKey";
    public const string CONFIGURATION_API_KEY_HINT = $"{BASE_LOCALE_ENDPOINT}.Configuration.ApiKey.Hint";

    public const string CONFIGURATION_SHARED_SECRET = $"{BASE_LOCALE_ENDPOINT}.Configuration.SharedSecret";
    public const string CONFIGURATION_SHARED_SECRET_HINT = $"{BASE_LOCALE_ENDPOINT}.Configuration.SharedSecret.Hint";

    public const string CONFIGURATION_PUBLIC_INTEGRATION_KEY = $"{BASE_LOCALE_ENDPOINT}.Configuration.PublicIntegrationKey";
    public const string CONFIGURATION_PUBLIC_INTEGRATION_KEY_HINT = $"{BASE_LOCALE_ENDPOINT}.Configuration.PublicIntegrationKey.Hint";

    public const string CONFIGURATION_API_USERNAME = $"{BASE_LOCALE_ENDPOINT}.Configuration.ApiUsername";
    public const string CONFIGURATION_API_USERNAME_HINT = $"{BASE_LOCALE_ENDPOINT}.Configuration.ApiUsername.Hint";

    public const string CONFIGURATION_API_PASSWORD = $"{BASE_LOCALE_ENDPOINT}.Configuration.ApiPassword";
    public const string CONFIGURATION_API_PASSWORD_HINT = $"{BASE_LOCALE_ENDPOINT}.Configuration.ApiPassword.Hint";

    public const string CONFIGURATION_USE_SIGNATURE = $"{BASE_LOCALE_ENDPOINT}.Configuration.UseSignature";
    public const string CONFIGURATION_USE_SIGNATURE_HINT = $"{BASE_LOCALE_ENDPOINT}.Configuration.UseSignature.Hint";
    
    public const string CONFIGURATION_DESCRIPTION = $"{BASE_LOCALE_ENDPOINT}.Configuration.Description";
    public const string CONFIGURATION_DESCRIPTION_HINT = $"{BASE_LOCALE_ENDPOINT}.Configuration.Description.Hint";

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
            [PAYMENT_METHOD_DESCRIPTION] = "Pay with Flik (you’ll be redirected to complete payment securely).",

            // Configuration
            [CONFIGURATION_INSTRUCTIONS] = "Please configure the Flik Payments plugin settings below.<br />Ensure that you have the necessary API credentials and that your account is set up to accept payments.",
            [CONFIGURATION_ENABLE] = "Enable Flik Payments Plugin",
            [CONFIGURATION_ENABLE_HINT] = "Check to enable the Flik Payments plugin.",
            [CONFIGURATION_SANDBOX] = "Use Sandbox Environment",
            [CONFIGURATION_SANDBOX_HINT] = "Check to use the sandbox environment for testing purposes. Uncheck to use the live environment.",
            [CONFIGURATION_API_KEY] = "API Key",
            [CONFIGURATION_API_KEY_HINT] = "Enter your Flik API key here. This is required for processing payments.",
            [CONFIGURATION_SHARED_SECRET] = "Shared Secret",
            [CONFIGURATION_SHARED_SECRET_HINT] = "Enter your Flik shared secret here. This is required for secure communication with the Flik API.",
            [CONFIGURATION_PUBLIC_INTEGRATION_KEY] = "Public Integration Key",
            [CONFIGURATION_PUBLIC_INTEGRATION_KEY_HINT] = "Enter your Flik public integration key here. This is used for client-side integration.",
            [CONFIGURATION_API_USERNAME] = "API Username",
            [CONFIGURATION_API_USERNAME_HINT] = "Enter your Flik API username here. This is required for authentication.",
            [CONFIGURATION_API_PASSWORD] = "API Password",
            [CONFIGURATION_API_PASSWORD_HINT] = "Enter your Flik API password here. This is required for authentication.",
            [CONFIGURATION_USE_SIGNATURE] = "Use Signature",
            [CONFIGURATION_USE_SIGNATURE_HINT] = "Check to use a signature for additional security. Uncheck if you do not want to use a signature.",
            [CONFIGURATION_DESCRIPTION] = "Description",
            [CONFIGURATION_DESCRIPTION_HINT] = "Message that will appear to the user in Flik.",
            [CONFIGURATION_ADDITIONAL_FEE_PERCENTAGE] = "Should the additional fee be a percentage?",
            [CONFIGURATION_ADDITIONAL_FEE_PERCENTAGE_HINT] = "Check to apply the additional fee as a percentage of the order total.",
            [CONFIGURATION_ADDITIONAL_FEE] = "Additional Fee",
            [CONFIGURATION_ADDITIONAL_FEE_HINT] = "Specify the additional fee to be applied to the order total.",
            [CONFIGURATION_REMOVE_SETTINGS_ON_UNINSTALL] = "Remove settings on uninstall",
            [CONFIGURATION_REMOVE_SETTINGS_ON_UNINSTALL_HINT] = "Check to remove all settings related to the Flik Payments plugin when it is uninstalled.",
        };
    }

    #endregion
}
