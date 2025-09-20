using Newtonsoft.Json;

namespace Nop.Plugin.Payments.Flik.Models.Bankart;

public class DebitResponse : ErrorResponse
{
    [JsonProperty("uuid")]
    public string UUID { get; set; }

    public string PurchaseId { get; set; }

    public string ReturnType { get; set; }

    public string RedirectUrl { get; set; }

    public string PaymentMethod { get; set; }
}