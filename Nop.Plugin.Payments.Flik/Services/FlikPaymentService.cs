using Microsoft.AspNetCore.Http;

namespace Nop.Plugin.Payments.Flik.Services;

/// <inheritdoc />
public class FlikPaymentService : IFlikPaymentService
{
    #region Fields

    private readonly FlikPaymentSettings _flikPaymentSettings;

    #endregion

    #region Ctor

    public FlikPaymentService(FlikPaymentSettings flikPaymentSettings)
    {
        _flikPaymentSettings = flikPaymentSettings;
    }

    #endregion

    #region Methods

    public Task HandleWebhookCallbackAsync(HttpRequest request)
    {
        // TODO: Implement the logic to handle webhook callbacks from Flik
        throw new NotImplementedException();
    }

    #endregion
}
