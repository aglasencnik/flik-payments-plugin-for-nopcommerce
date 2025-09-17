using Microsoft.AspNetCore.Http;
using Nop.Core;
using Nop.Core.Domain.Orders;
using Nop.Plugin.Payments.Flik.Components;
using Nop.Plugin.Payments.Flik.Services;
using Nop.Services.Configuration;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Payments;
using Nop.Services.Plugins;

namespace Nop.Plugin.Payments.Flik;

public class FlikPaymentPlugin : BasePlugin, IPaymentMethod
{
    #region Fields

    private readonly IWebHelper _webHelper;
    private readonly ISettingService _settingService;
    private readonly ILocalizationService _localizationService;
    private readonly IFlikPaymentProcessor _flikPaymentProcessor;
    private readonly ICountryService _countryService;
    private readonly IPaymentPluginManager _paymentPluginManager;

    #endregion

    #region Ctor

    public FlikPaymentPlugin(IWebHelper webHelper,
        ISettingService settingService,
        ILocalizationService localizationService,
        IFlikPaymentProcessor flikPaymentProcessor,
        ICountryService countryService,
        IPaymentPluginManager paymentPluginManager)
    {
        _webHelper = webHelper;
        _settingService = settingService;
        _localizationService = localizationService;
        _flikPaymentProcessor = flikPaymentProcessor;
        _countryService = countryService;
        _paymentPluginManager = paymentPluginManager;
    }

    #endregion

    #region Methods

    #region Install/Uninstall

    public override async Task InstallAsync()
    {
        // Add localization resources
        await _localizationService.AddOrUpdateLocaleResourceAsync(DefaultLocales.GetPluginLocalesEn());

        // Restrict usage to specific countries
        var restrictedCountryIds = (await _countryService.GetAllCountriesAsync())
            .Where(x => !FlikPaymentDefaults.AllowedCountries.Contains(x.TwoLetterIsoCode))
            .Select(x => x.Id)
            .ToList();

        await _paymentPluginManager.SaveRestrictedCountriesAsync(this, restrictedCountryIds);

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

    #region Payment Methods

    public Task<ProcessPaymentResult> ProcessPaymentAsync(ProcessPaymentRequest processPaymentRequest)
    {
        // We don't implement any actual payment processing logic here.
        return Task.FromResult(new ProcessPaymentResult());
    }

    public Task PostProcessPaymentAsync(PostProcessPaymentRequest postProcessPaymentRequest)
    {
        return Task.CompletedTask;
    }

    public async Task<bool> HidePaymentMethodAsync(IList<ShoppingCartItem> cart)
    {
        return await _flikPaymentProcessor.HidePaymentMethodAsync(cart);
    }

    public async Task<decimal> GetAdditionalHandlingFeeAsync(IList<ShoppingCartItem> cart)
    {
        return await _flikPaymentProcessor.GetAdditionalHandlingFeeAsync(cart);
    }

    public Task<CapturePaymentResult> CaptureAsync(CapturePaymentRequest capturePaymentRequest)
    {
        return Task.FromResult(new CapturePaymentResult { Errors = new[] { "Capture method not supported" } });
    }

    public async Task<RefundPaymentResult> RefundAsync(RefundPaymentRequest refundPaymentRequest)
    {
        return await _flikPaymentProcessor.RefundAsync(refundPaymentRequest);
    }

    public Task<VoidPaymentResult> VoidAsync(VoidPaymentRequest voidPaymentRequest)
    {
        return Task.FromResult(new VoidPaymentResult { Errors = new[] { "Void method not supported" } });
    }

    public Task<ProcessPaymentResult> ProcessRecurringPaymentAsync(ProcessPaymentRequest processPaymentRequest)
    {
        return Task.FromResult(new ProcessPaymentResult
        {
            Errors = new[] { "Recurring payment processing is not supported by this payment method." }
        });
    }

    public Task<CancelRecurringPaymentResult> CancelRecurringPaymentAsync(CancelRecurringPaymentRequest cancelPaymentRequest)
    {
        return Task.FromResult(new CancelRecurringPaymentResult
        {
            Errors = new[] { "Cancel recurring payment method not supported" }
        });
    }

    public Task<bool> CanRePostProcessPaymentAsync(Order order)
    {
        return Task.FromResult(false);
    }

    public Task<IList<string>> ValidatePaymentFormAsync(IFormCollection form)
    {
        return Task.FromResult<IList<string>>(new List<string>());
    }

    public Task<ProcessPaymentRequest> GetPaymentInfoAsync(IFormCollection form)
    {
        return Task.FromResult(new ProcessPaymentRequest());
    }

    public Type GetPublicViewComponent()
    {
        return typeof(PaymentInfoViewComponent);
    }

    public async Task<string> GetPaymentMethodDescriptionAsync()
    {
        return await _localizationService.GetResourceAsync(DefaultLocales.PAYMENT_METHOD_DESCRIPTION);
    }

    #endregion

    #endregion

    #region Properties

    /// <summary>
    /// Gets a value indicating whether capture is supported
    /// </summary>
    public bool SupportCapture => false;

    /// <summary>
    /// Gets a value indicating whether void is supported
    /// </summary>
    public bool SupportVoid => false;

    /// <summary>
    /// Gets a value indicating whether refund is supported
    /// </summary>
    public bool SupportRefund => true;

    /// <summary>
    /// Gets a value indicating whether partial refund is supported
    /// </summary>
    public bool SupportPartiallyRefund => true;

    /// <summary>
    /// Gets a recurring payment type of payment method
    /// </summary>
    public RecurringPaymentType RecurringPaymentType => RecurringPaymentType.NotSupported;

    /// <summary>
    /// Gets a payment method type
    /// </summary>
    public PaymentMethodType PaymentMethodType => PaymentMethodType.Standard;

    /// <summary>
    /// Gets a value indicating whether we should display a payment information page for this plugin
    /// </summary>
    public bool SkipPaymentInfo => false;

    #endregion
}
