using Nop.Core.Domain.Payments;
using Nop.Plugin.Payments.Flik.Models;
using Nop.Services.Configuration;
using Nop.Services.Payments;

namespace Nop.Plugin.Payments.Flik.Services;

/// <inheritdoc />
public class ConfigurationService : IConfigurationService
{
    #region Fields

    private readonly ISettingService _settingService;
    private readonly IPaymentPluginManager _paymentPluginManager;

    #endregion

    #region Ctor

    public ConfigurationService(ISettingService settingService,
        IPaymentPluginManager paymentPluginManager)
    {
        _settingService = settingService;
        _paymentPluginManager = paymentPluginManager;
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
        settings.Description = model.Description;
        settings.AdditionalFeePercentage = model.AdditionalFeePercentage;
        settings.AdditionalFee = model.AdditionalFee;
        settings.RemoveSettingsOnUninstall = model.RemoveSettingsOnUninstall;

        await _settingService.SaveSettingAsync(settings);
        await _settingService.ClearCacheAsync();

        var paymentSettings = await _settingService.LoadSettingAsync<PaymentSettings>();
        var pm = await _paymentPluginManager.LoadPluginBySystemNameAsync(FlikPaymentDefaults.SystemName);
        if (_paymentPluginManager.IsPluginActive(pm))
        {
            if (!settings.Enabled)
            {
                // Mark as disabled
                paymentSettings.ActivePaymentMethodSystemNames.Remove(pm.PluginDescriptor.SystemName);
                await _settingService.SaveSettingAsync(paymentSettings);
            }
        }
        else
        {
            if (settings.Enabled)
            {
                // Mark as enabled
                paymentSettings.ActivePaymentMethodSystemNames.Add(pm.PluginDescriptor.SystemName);
                await _settingService.SaveSettingAsync(paymentSettings);
            }
        }
    }

    #endregion
}
