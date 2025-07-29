using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Payments.Flik.Components;

/// <summary>
/// Represents a view component for displaying payment information
/// </summary>
public class PaymentInfoViewComponent : NopViewComponent
{
    /// <summary>
    /// Invokes the view component
    /// </summary>
    /// <param name="widgetZone">Widget zone</param>
    /// <param name="additionalData">Additional data passed to component</param>
    /// <returns>
    /// View component result
    /// A task that represents the asynchronous operation.
    /// </returns>
    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
    {
        return View($"{FlikPaymentDefaults.ViewsPath}/PaymentInfo.cshtml");
    }
}
