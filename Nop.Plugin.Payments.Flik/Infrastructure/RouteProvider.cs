using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc.Routing;

namespace Nop.Plugin.Payments.Flik.Infrastructure;

public class RouteProvider : IRouteProvider
{
    private readonly string _prefix = "Plugins/Nop.Plugin.Payments.Flik";

    public int Priority => 1;

    public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapControllerRoute(
            name: $"{_prefix}.PaymentInfo",
            pattern: "Admin/FlikPayments/Configure",
            defaults: new { controller = "FlikConfiguration", action = "Configure", area = AreaNames.ADMIN }
        );
    }
}
