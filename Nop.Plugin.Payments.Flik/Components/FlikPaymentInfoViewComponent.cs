using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Payments.Flik.Components;

public class FlikPaymentInfoViewComponent : NopViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View($"{FlikPaymentDefaults.PublicViewsPath}/PaymentInfo.cshtml");
    }
}