using Microsoft.AspNetCore.Http;
using Nop.Core.Domain.Orders;
using Nop.Services.Orders;
using Nop.Services.Payments;

namespace Nop.Plugin.Payments.Flik.Services;

/// <inheritdoc />
public class FlikPaymentProcessor : IFlikPaymentProcessor
{
    #region Fields

    private readonly FlikPaymentSettings _flikPaymentSettings;
    private readonly IOrderTotalCalculationService _orderTotalCalculationService;

    #endregion

    #region Ctor

    public FlikPaymentProcessor(FlikPaymentSettings flikPaymentSettings,
        IOrderTotalCalculationService orderTotalCalculationService)
    {
        _flikPaymentSettings = flikPaymentSettings;
        _orderTotalCalculationService = orderTotalCalculationService;
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
    public Task InitializePaymentProcessAsync(PostProcessPaymentRequest postProcessPaymentRequest)
    {
        throw new NotImplementedException();
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
