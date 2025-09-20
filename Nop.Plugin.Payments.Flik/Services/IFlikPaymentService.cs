using Microsoft.AspNetCore.Http;
using Nop.Core.Domain.Orders;
using Nop.Plugin.Payments.Flik.Models.Bankart;

namespace Nop.Plugin.Payments.Flik.Services;

/// <summary>
/// Represents the Flik payment service
/// </summary>
public interface IFlikPaymentService
{
    Task<DebitResponse> CreateRequestToPayAsync(Order order);
}
