using Nop.Core.Domain.Orders;
using Nop.Services.Payments;

namespace Nop.Plugin.Payments.Flik.Services;

/// <inheritdoc />
public class FlikPaymentProcessor : IFlikPaymentProcessor
{
    #region Fields



    #endregion

    #region Ctor

    public FlikPaymentProcessor()
    {
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
    public Task<decimal> GetAdditionalHandlingFeeAsync(IList<ShoppingCartItem> cart)
    {
        // TODO: Implement logic to calculate additional handling fee
        return Task.FromResult(0m);
    }

    /// <inheritdoc />
    public Task<RefundPaymentResult> RefundAsync(RefundPaymentRequest refundPaymentRequest)
    {
        throw new NotImplementedException();
    }

    #endregion
}
