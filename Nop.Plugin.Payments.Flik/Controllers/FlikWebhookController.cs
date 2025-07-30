using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Payments.Flik.Services;

namespace Nop.Plugin.Payments.Flik.Controllers;

/// <summary>
/// Represents a controller for handling Flik payment webhooks
/// </summary>
public class FlikWebhookController : Controller
{
    #region Fields

    private readonly IFlikPaymentService _flikPaymentService;

    #endregion

    #region Ctor

    public FlikWebhookController(IFlikPaymentService flikPaymentService)
    {
        _flikPaymentService = flikPaymentService;
    }

    #endregion

    #region Methods

    [HttpPost]
    public async Task<IActionResult> WebhookHandler()
    {
        await _flikPaymentService.HandleWebhookCallbackAsync(Request);
        return Ok();
    }

    #endregion
}
