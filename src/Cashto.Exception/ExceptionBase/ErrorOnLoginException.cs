using System.Net;

namespace Cashto.Exception.ExceptionBase;

public class ErrorOnLoginException(string message) : CashtoException(string.Empty)
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public override string Message { get; } = message;

    public override List<string> GetErrors()
    {
        return new List<string>() { message };
    }
}