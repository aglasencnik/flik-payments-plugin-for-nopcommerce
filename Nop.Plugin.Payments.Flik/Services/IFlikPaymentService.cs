using Microsoft.AspNetCore.Http;

namespace Nop.Plugin.Payments.Flik.Services;

/// <summary>
/// Represents the Flik payment service
/// </summary>
public interface IFlikPaymentService
{
    /// <summary>
    /// Handles the webhook callback from Flik
    /// </summary>
    /// <param name="request">Http request object</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task HandleWebhookCallbackAsync(HttpRequest request);
}
