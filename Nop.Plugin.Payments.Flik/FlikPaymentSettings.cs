using Nop.Core.Configuration;

namespace Nop.Plugin.Payments.Flik;

public class FlikPaymentSettings : ISettings
{
    /// <summary>
    /// Gets or sets whether the Flik payments plugin is enabled.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Gets or sets whether to use the sandbox environment.
    /// </summary>
    public bool Sandbox { get; set; }

    /// <summary>
    /// Gets or sets the API key for Flik payments.
    /// </summary>
    public string ApiKey { get; set; }

    /// <summary>
    /// Gets or sets the shared secret for Flik payments.
    /// </summary>
    public string SharedSecret { get; set; }

    /// <summary>
    /// Gets or sets the public integration key for Flik payments.
    /// </summary>
    public string PublicIntegrationKey { get; set; }

    /// <summary>
    /// Gets or sets the API username for Flik payments.
    /// </summary>
    public string ApiUsername { get; set; }

    /// <summary>
    /// Gets or sets the API password for Flik payments.
    /// </summary>
    public string ApiPassword { get; set; }

    /// <summary>
    /// Gets or sets whether to use the signature for Flik payments.
    /// </summary>
    public bool UseSignature { get; set; }

    /// <summary>
    /// Gets or sets the description to appear to the customer in Flik.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets whether the additional fee is in percentage.
    /// </summary>
    public bool AdditionalFeePercentage { get; set; }

    /// <summary>
    /// Gets or sets the additional fee amount.
    /// </summary>
    public decimal AdditionalFee { get; set; }

    /// <summary>
    /// Gets or sets whether to remove settings on uninstall.
    /// </summary>
    public bool RemoveSettingsOnUninstall { get; set; }
}
