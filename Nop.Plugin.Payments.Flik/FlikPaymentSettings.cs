using Nop.Core.Configuration;

namespace Nop.Plugin.Payments.Flik;

public class FlikPaymentSettings : ISettings
{
    /// <summary>
    /// Gets or sets whether the Flik payments plugin is enabled.
    /// </summary>
    public bool Enabled { get; set; }

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
