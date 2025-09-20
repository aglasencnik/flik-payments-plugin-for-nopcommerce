using System.Globalization;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Nop.Core;
using Nop.Core.Domain.Orders;
using Nop.Plugin.Payments.Flik.Models.Bankart;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Logging;

namespace Nop.Plugin.Payments.Flik.Services;

/// <inheritdoc />
public class FlikPaymentService : IFlikPaymentService
{
    #region Fields

    private readonly JsonSerializerSettings _defaultJsonSerializerSettings = new JsonSerializerSettings
    {
        ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
        NullValueHandling = NullValueHandling.Ignore,
    };
    
    private readonly FlikPaymentSettings _flikPaymentSettings;
    private readonly ICurrencyService _currencyService;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IWebHelper _webHelper;
    private readonly ILogger _logger;
    private readonly ICustomerService _customerService;

    #endregion

    #region Ctor

    public FlikPaymentService(FlikPaymentSettings flikPaymentSettings,
        ICurrencyService currencyService,
        IHttpClientFactory httpClientFactory,
        IWebHelper webHelper,
        ILogger logger,
        ICustomerService customerService)
    {
        _flikPaymentSettings = flikPaymentSettings;
        _currencyService = currencyService;
        _httpClientFactory = httpClientFactory;
        _webHelper = webHelper;
        _logger = logger;
        _customerService = customerService;
    }

    #endregion

    #region Utils

    private HttpClient GetHttpClient()
    {
        return _httpClientFactory.CreateClient();
    }

    private async Task<string> CalculateSignatureAsync(HttpRequestMessage requestMessage)
    {
        var content = requestMessage.Content;
        var jsonContent = content is not null ? await content.ReadAsStringAsync() : string.Empty;
        var contentHash = Convert.ToHexStringLower(SHA512.HashData(Encoding.UTF8.GetBytes(jsonContent)));
        
        var message = requestMessage.Method.Method.ToUpperInvariant() + "\n"
            + contentHash + "\n"
            + "application/json; charset=utf-8\n"
            + requestMessage.Headers.Date?.ToUniversalTime().ToString("R") + "\n"
            + requestMessage.RequestUri?.PathAndQuery;
        
        var signature = Convert.ToBase64String(HMACSHA512.HashData( 
            Encoding.UTF8.GetBytes(_flikPaymentSettings.SharedSecret),
            Encoding.UTF8.GetBytes(message))
        );

        return signature;
    }

    private AuthenticationHeaderValue GetAuthenticationHeader()
    {
        var authString = $"{_flikPaymentSettings.ApiUsername}:{_flikPaymentSettings.ApiPassword}";
        var authBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(authString));
        return new AuthenticationHeaderValue("Basic", authBase64);
    }

    #endregion

    #region Methods

    /// <inheritdoc />
    public async Task<DebitResponse> CreateRequestToPayAsync(Order order)
    {
        var customerCurrency = await _currencyService.GetCurrencyByCodeAsync(order.CustomerCurrencyCode);
        var euroCurrency = await _currencyService.GetCurrencyByCodeAsync("EUR");
        var amountInEuro =
            await _currencyService.ConvertCurrencyAsync(order.OrderTotal, customerCurrency, euroCurrency);

        var gatewayEndpoint = _flikPaymentSettings.Sandbox
            ? FlikPaymentDefaults.PaymentGatewaySandboxEndpoint
            : FlikPaymentDefaults.PaymentGatewayEndpoint;

        var requestUrl = $"{gatewayEndpoint}/transaction/{_flikPaymentSettings.ApiKey}/debit";
        var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
        request.Headers.Authorization = GetAuthenticationHeader();
        
        var transactionRequestDate = DateTime.UtcNow;

        request.Headers.Date = transactionRequestDate;

        var storeUrl = _webHelper.GetStoreLocation(_webHelper.IsCurrentConnectionSecured());
        
        var debitRequest = new DebitRequest
        {
            MerchantTransactionId = $"Flik-{transactionRequestDate:yyyyMMddHHmmss}-{Guid.NewGuid().ToString()[..5]}",
            Amount = Math.Round(amountInEuro, 2, MidpointRounding.AwayFromZero).ToString("0.00", CultureInfo.InvariantCulture),
            Currency = "EUR",
            SuccessUrl = $"{storeUrl}Plugins/FlikPayments/Redirect?status=success?orderId={order.Id}",
            ErrorUrl = $"{storeUrl}Plugins/FlikPayments/Redirect?status=error?orderId={order.Id}",
            CancelUrl = $"{storeUrl}Plugins/FlikPayments/Redirect?status=cancel?orderId={order.Id}",
            CallbackUrl = $"{storeUrl}Plugins/FlikPayments/Callback?orderId={order.Id}",
            Description = _flikPaymentSettings.Description,
            Customer = new DebitRequest.RequestCustomer
            {
                IpAddress = order.CustomerIp,
            },
            Language = "sl",
        };
        
        var debitRequestJson = JsonConvert.SerializeObject(debitRequest, _defaultJsonSerializerSettings);

        request.Content = new StringContent(debitRequestJson, Encoding.UTF8, "application/json");
        
        if (_flikPaymentSettings.UseSignature)
            request.Headers.Add("X-Signature", await CalculateSignatureAsync(request));
        
        var client = GetHttpClient();
        var response = await client.SendAsync(request);
        
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception("Failed to create request to pay", new Exception(responseContent));

        return JsonConvert.DeserializeObject<DebitResponse>(responseContent);
    }

    #endregion
}
