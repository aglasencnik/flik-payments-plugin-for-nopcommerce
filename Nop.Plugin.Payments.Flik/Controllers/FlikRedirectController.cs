using Microsoft.AspNetCore.Mvc;
using Nop.Services.Localization;
using Nop.Services.Messages;

namespace Nop.Plugin.Payments.Flik.Controllers;

/// <summary>
/// Represents the controller for the Flik redirects
/// </summary>
public class FlikRedirectController : Controller
{
    #region Fields

    private readonly INotificationService _notificationService;
    private readonly ILocalizationService _localizationService;

    #endregion

    #region Ctor

    public FlikRedirectController(INotificationService notificationService, 
        ILocalizationService localizationService)
    {
        _notificationService = notificationService;
        _localizationService = localizationService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> RedirectHandler(string status, int orderId)
    {
        if (string.IsNullOrWhiteSpace(status) || orderId <= 0)
            return NotFound();

        if (status.Equals("success", StringComparison.OrdinalIgnoreCase))
        {
            _notificationService.SuccessNotification(
                await _localizationService.GetResourceAsync(DefaultLocales.PAYMENT_SUCCESSFUL_NOTIFICATION)
            );
            
            return RedirectToAction("Completed", "Checkout", new { orderId });
        }

        if (status.Equals("cancel", StringComparison.OrdinalIgnoreCase))
        {
            _notificationService.WarningNotification(
                await _localizationService.GetResourceAsync(DefaultLocales.PAYMENT_CANCELED_NOTIFICATION)
            );

            return RedirectToRoute("OrderDetails", new { orderId });
        }

        if (status.Equals("error", StringComparison.OrdinalIgnoreCase))
        {
            _notificationService.ErrorNotification(
                await _localizationService.GetResourceAsync(DefaultLocales.PAYMENT_FAILED_NOTIFICATION)
            );
            
            return RedirectToRoute("OrderDetails", new { orderId });
        }

        return NotFound();
    }

    #endregion
}