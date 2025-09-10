using Microsoft.AspNetCore.Http;
using Nop.Core.Domain.Orders;
using Nop.Services.Payments;

namespace Nop.Plugin.Payments.Flik.Services;

/// <summary>
/// Represents a payment processor for Flik payments
/// </summary>
public interface IFlikPaymentProcessor
{
    /// <summary>
    /// Returns a value indicating whether payment method should be hidden during checkout
    /// </summary>
    /// <param name="cart">Shopping cart</param>
    /// <returns>
    /// The task result contains true - hide; false - display
    /// A task that represents the asynchronous operation
    /// </returns>
    Task<bool> HidePaymentMethodAsync(IList<ShoppingCartItem> cart);

    /// <summary>
    /// Gets additional handling fee
    /// </summary>
    /// <param name="cart">Shopping cart</param>
    /// <returns>
    /// Additional handling fee
    /// A task that represents the asynchronous operation
    /// </returns>
    Task<decimal> GetAdditionalHandlingFeeAsync(IList<ShoppingCartItem> cart);

    /// <summary>
    /// Refunds a payment
    /// </summary>
    /// <param name="refundPaymentRequest">Request</param>
    /// <returns>
    /// Refund payment result
    /// A task that represents the asynchronous operation
    /// </returns>
    Task<RefundPaymentResult> RefundAsync(RefundPaymentRequest refundPaymentRequest);

    /// <summary>
    /// Handles the webhook callback from Flik
    /// </summary>
    /// <param name="request">Http request object</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task HandleWebhookCallbackAsync(HttpRequest request);
}
