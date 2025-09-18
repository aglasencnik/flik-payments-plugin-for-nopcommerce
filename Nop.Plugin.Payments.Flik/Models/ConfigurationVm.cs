using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Payments.Flik.Models;

public class ConfigurationVm
{
    /// <summary>
    /// Gets or sets whether the Flik payments plugin is enabled.
    /// </summary>
    [NopResourceDisplayName(DefaultLocales.CONFIGURATION_ENABLE)]
    public bool Enabled { get; set; }

    /// <summary>
    /// Gets or sets whether to use the sandbox environment.
    /// </summary>
    [NopResourceDisplayName(DefaultLocales.CONFIGURATION_SANDBOX)]
    public bool Sandbox { get; set; }

    /// <summary>
    /// Gets or sets the API key for Flik payments.
    /// </summary>
    [NopResourceDisplayName(DefaultLocales.CONFIGURATION_API_KEY)]
    public string ApiKey { get; set; }

    /// <summary>
    /// Gets or sets the shared secret for Flik payments.
    /// </summary>
    [NopResourceDisplayName(DefaultLocales.CONFIGURATION_SHARED_SECRET)]
    public string SharedSecret { get; set; }

    /// <summary>
    /// Gets or sets the public integration key for Flik payments.
    /// </summary>
    [NopResourceDisplayName(DefaultLocales.CONFIGURATION_PUBLIC_INTEGRATION_KEY)]
    public string PublicIntegrationKey { get; set; }

    /// <summary>
    /// Gets or sets the API username for Flik payments.
    /// </summary>
    [NopResourceDisplayName(DefaultLocales.CONFIGURATION_API_USERNAME)]
    public string ApiUsername { get; set; }

    /// <summary>
    /// Gets or sets the API password for Flik payments.
    /// </summary>
    [NopResourceDisplayName(DefaultLocales.CONFIGURATION_API_PASSWORD)]
    public string ApiPassword { get; set; }

    /// <summary>
    /// Gets or sets whether to use the signature for Flik payments.
    /// </summary>
    [NopResourceDisplayName(DefaultLocales.CONFIGURATION_USE_SIGNATURE)]
    public bool UseSignature { get; set; }
    
    /// <summary>
    /// Gets or sets the description to appear to the customer in Flik.
    /// </summary>
    [NopResourceDisplayName(DefaultLocales.CONFIGURATION_DESCRIPTION)]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets whether the additional fee is in percentage.
    /// </summary>
    [NopResourceDisplayName(DefaultLocales.CONFIGURATION_ADDITIONAL_FEE_PERCENTAGE)]
    public bool AdditionalFeePercentage { get; set; }

    /// <summary>
    /// Gets or sets the additional fee amount.
    /// </summary>
    [NopResourceDisplayName(DefaultLocales.CONFIGURATION_ADDITIONAL_FEE)]
    public decimal AdditionalFee { get; set; }

    /// <summary>
    /// Gets or sets whether to remove settings on uninstall.
    /// </summary>
    [NopResourceDisplayName(DefaultLocales.CONFIGURATION_REMOVE_SETTINGS_ON_UNINSTALL)]
    public bool RemoveSettingsOnUninstall { get; set; }
}
