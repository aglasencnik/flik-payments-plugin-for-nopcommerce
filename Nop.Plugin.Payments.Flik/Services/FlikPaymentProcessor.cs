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
        // TODO: Implement logic to determine if the payment method should be hidden based on the customer country
        return Task.FromResult(false);
    }

    /// <inheritdoc />
    public async Task<decimal> GetAdditionalHandlingFeeAsync(IList<ShoppingCartItem> cart)
    {
        return await _orderTotalCalculationService.CalculatePaymentAdditionalFeeAsync(cart, 
            _flikPaymentSettings.AdditionalFee, _flikPaymentSettings.AdditionalFeePercentage);
    }

    /// <inheritdoc />
    public Task<RefundPaymentResult> RefundAsync(RefundPaymentRequest refundPaymentRequest)
    {
        throw new NotImplementedException();
    }

    #endregion
}
