using Nop.Plugin.Payments.Flik.Models;
using Nop.Services.Configuration;

namespace Nop.Plugin.Payments.Flik.Factories;

/// <inheritdoc />
public class ConfigurationFactory : IConfigurationFactory
{
    #region Fields

    private readonly ISettingService _settingService;

    #endregion

    #region Ctor

    public ConfigurationFactory(ISettingService settingService)
    {
        _settingService = settingService;
    }

    #endregion

    #region Methods

    /// <inheritdoc />
    public async Task<ConfigurationVm> PrepareConfigurationModelAsync()
    {
        var settings = await _settingService.LoadSettingAsync<FlikPaymentSettings>();
        var model = new ConfigurationVm
        {
            Enabled = settings.Enabled,
            AdditionalFeePercentage = settings.AdditionalFeePercentage,
            AdditionalFee = settings.AdditionalFee,
            RemoveSettingsOnUninstall = settings.RemoveSettingsOnUninstall,
        };

        return model;
    }

    #endregion
}
