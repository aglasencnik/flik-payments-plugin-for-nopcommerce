using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Payments.Flik.Services;

namespace Nop.Plugin.Payments.Flik.Controllers;

/// <summary>
/// Represents a controller for handling Flik payment webhooks
/// </summary>
public class FlikWebhookController : Controller
{
    #region Fields

    private readonly IFlikPaymentProcessor _flikPaymentProcessor;

    #endregion

    #region Ctor

    public FlikWebhookController(IFlikPaymentProcessor flikPaymentProcessor)
    {
        _flikPaymentProcessor = flikPaymentProcessor;
    }

    #endregion

    #region Methods

    [HttpPost]
    public async Task<IActionResult> WebhookHandler()
    {
        await _flikPaymentProcessor.HandleWebhookCallbackAsync(Request);
        return Ok("OK");
    }

    #endregion
}
