namespace Cashto.Exception.ExceptionBase;

public abstract class CashtoException : SystemException
{
    protected CashtoException(string message) : base(message)
    {

    }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}