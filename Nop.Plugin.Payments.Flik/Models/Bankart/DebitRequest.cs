using Newtonsoft.Json;

namespace Nop.Plugin.Payments.Flik.Models.Bankart;

public class DebitRequest
{
    public string MerchantTransactionId { get; set; }
    
    public string Amount { get; set; }
    
    public string Currency { get; set; }
    
    public string SuccessUrl { get; set; }

    public string ErrorUrl { get; set; }

    public string CancelUrl { get; set; }

    public string CallbackUrl { get; set; }
    
    public string Description { get; set; }
    
    public RequestExtraData ExtraData { get; set; }
    
    public RequestCustomer Customer { get; set; }

    public string Language { get; set; }

    #region Nested classes

    public class RequestExtraData
    {
        public string Alias { get; set; }
    }
    
    public class RequestCustomer
    {
        public string IpAddress { get; set; }
    }

    #endregion
}
