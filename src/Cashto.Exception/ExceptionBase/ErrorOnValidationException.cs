using System.Net;

namespace Cashto.Exception.ExceptionBase;

public class ErrorOnValidationException(List<string> errorMessages) : CashtoException(string.Empty)
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public override List<string> GetErrors()
    {
        return errorMessages;
    }
}
