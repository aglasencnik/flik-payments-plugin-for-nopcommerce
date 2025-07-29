using Nop.Plugin.Payments.Flik.Models;
using Nop.Services.Configuration;

namespace Nop.Plugin.Payments.Flik.Services;

/// <inheritdoc />
public class ConfigurationService : IConfigurationService
{
    #region Fields

    private readonly ISettingService _settingService;

    #endregion

    #region Ctor

    public ConfigurationService(ISettingService settingService)
    {
        _settingService = settingService;
    }

    #endregion

    #region Methods

    /// <inheritdoc />
    public async Task SaveConfigurationAsync(ConfigurationVm model)
    {
        var settings = await _settingService.LoadSettingAsync<FlikPaymentSettings>();

        settings.Enabled = model.Enabled;
        settings.Sandbox = model.Sandbox;
        settings.ApiKey = model.ApiKey;
        settings.SharedSecret = model.SharedSecret;
        settings.PublicIntegrationKey = model.PublicIntegrationKey;
        settings.ApiUsername = model.ApiUsername;
        settings.ApiPassword = model.ApiPassword;
        settings.UseSignature = model.UseSignature;
        settings.AdditionalFeePercentage = model.AdditionalFeePercentage;
        settings.AdditionalFee = model.AdditionalFee;
        settings.RemoveSettingsOnUninstall = model.RemoveSettingsOnUninstall;

        await _settingService.SaveSettingAsync(settings);
        await _settingService.ClearCacheAsync();
    }

    #endregion
}
