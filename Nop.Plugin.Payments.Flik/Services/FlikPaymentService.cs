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



    #endregion
}
