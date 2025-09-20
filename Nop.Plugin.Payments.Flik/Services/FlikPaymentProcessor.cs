using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Nop.Core;
using Nop.Core.Domain.Orders;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Orders;
using Nop.Services.Payments;

namespace Nop.Plugin.Payments.Flik.Services;

/// <inheritdoc />
public class FlikPaymentProcessor : IFlikPaymentProcessor
{
    #region Fields

    private readonly FlikPaymentSettings _flikPaymentSettings;
    private readonly IOrderTotalCalculationService _orderTotalCalculationService;
    private readonly IFlikPaymentService _flikPaymentService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly INotificationService _notificationService;
    private readonly ILocalizationService _localizationService;
    private readonly IUrlHelperFactory _urlHelperFactory;
    private readonly ILogger _logger;
    private readonly IWebHelper _webHelper;

    #endregion

    #region Ctor

    public FlikPaymentProcessor(FlikPaymentSettings flikPaymentSettings,
        IOrderTotalCalculationService orderTotalCalculationService,
        IFlikPaymentService flikPaymentService,
        IHttpContextAccessor httpContextAccessor,
        INotificationService notificationService,
        ILocalizationService localizationService,
        IUrlHelperFactory urlHelperFactory,
        ILogger logger,
        IWebHelper webHelper)
    {
        _flikPaymentSettings = flikPaymentSettings;
        _orderTotalCalculationService = orderTotalCalculationService;
        _flikPaymentService = flikPaymentService;
        _httpContextAccessor = httpContextAccessor;
        _notificationService = notificationService;
        _localizationService = localizationService;
        _urlHelperFactory = urlHelperFactory;
        _logger = logger;
        _webHelper = webHelper;
    }

    #endregion

    #region Methods

    /// <inheritdoc />
    public Task<bool> HidePaymentMethodAsync(IList<ShoppingCartItem> cart)
    {
        if (!_flikPaymentSettings.Enabled)
            return Task.FromResult(true);

        return Task.FromResult(false);
    }

    /// <inheritdoc />
    public async Task<decimal> GetAdditionalHandlingFeeAsync(IList<ShoppingCartItem> cart)
    {
        return await _orderTotalCalculationService.CalculatePaymentAdditionalFeeAsync(cart, 
            _flikPaymentSettings.AdditionalFee, _flikPaymentSettings.AdditionalFeePercentage);
    }

    /// <inheritdoc />
    public async Task InitializePaymentProcessAsync(PostProcessPaymentRequest postProcessPaymentRequest)
    {
        try
        {
            var order = postProcessPaymentRequest.Order;
            var requestToPay = await _flikPaymentService.CreateRequestToPayAsync(order);

            var httpContext = _httpContextAccessor.HttpContext;
            httpContext?.Response.Redirect(requestToPay.RedirectUrl);
        }
        catch (Exception ex)
        {
            await _logger.ErrorAsync("Flik: Error while initializing payment process", ex);

            _notificationService.ErrorNotification(
                await _localizationService.GetResourceAsync(DefaultLocales.PAYMENT_PROCESS_NOT_STARTED_NOTIFICATION)
            );
            
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var urlHelper = _urlHelperFactory.GetUrlHelper(
                    new ActionContext(httpContext, new RouteData(), new ActionDescriptor())
                );
                
                var redirectUrl = urlHelper.RouteUrl("OrderDetails", new { orderId = postProcessPaymentRequest.Order.Id });

                httpContext.Response.Redirect(
                    redirectUrl ?? _webHelper.GetStoreLocation(_webHelper.IsCurrentConnectionSecured())
                );
            }
        }
    }

    /// <inheritdoc />
    public Task<RefundPaymentResult> RefundAsync(RefundPaymentRequest refundPaymentRequest)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task HandleWebhookCallbackAsync(HttpRequest request)
    {
        // TODO: Implement the logic to handle webhook callbacks from Flik
        return Task.CompletedTask;
    }

    #endregion
}
