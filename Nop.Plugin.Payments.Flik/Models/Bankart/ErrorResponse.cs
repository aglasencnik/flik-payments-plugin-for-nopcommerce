namespace Nop.Plugin.Payments.Flik.Models.Bankart;

public class ErrorResponse
{
    public bool Success { get; set; }

    public string ErrorMessage { get; set; }

    public int ErrorCode { get; set; }
}