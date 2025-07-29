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
