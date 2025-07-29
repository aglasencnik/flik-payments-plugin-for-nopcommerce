using Nop.Core;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;

namespace Nop.Plugin.Payments.Flik;

public class FlikPaymentPlugin : BasePlugin, IPlugin
{
    #region Fields

    private readonly IWebHelper _webHelper;
    private readonly ISettingService _settingService;
    private readonly ILocalizationService _localizationService;

    #endregion

    #region Ctor

    public FlikPaymentPlugin(IWebHelper webHelper,
        ISettingService settingService,
        ILocalizationService localizationService)
    {
        _webHelper = webHelper;
        _settingService = settingService;
        _localizationService = localizationService;
    }

    #endregion

    #region Methods

    #region Install/Uninstall

    public override async Task InstallAsync()
    {
        // Add localization resources
        await _localizationService.AddOrUpdateLocaleResourceAsync(DefaultLocales.GetPluginLocalesEn());

        await base.InstallAsync();
    }

    public override async Task UninstallAsync()
    {
        // Delete localization resources
        await _localizationService.DeleteLocaleResourcesAsync($"{DefaultLocales.BASE_LOCALE_ENDPOINT}.");

        // Delete settings
        var settings = await _settingService.LoadSettingAsync<FlikPaymentSettings>();
        if (settings is not null && settings.RemoveSettingsOnUninstall)
        {
            await _settingService.DeleteSettingAsync<FlikPaymentSettings>();
            await _settingService.ClearCacheAsync();
        }

        await base.UninstallAsync();
    }

    #endregion

    public override string GetConfigurationPageUrl()
    {
        return $"{_webHelper.GetStoreLocation()}Admin/FlikPayments/Configure";
    }

    #endregion
}
