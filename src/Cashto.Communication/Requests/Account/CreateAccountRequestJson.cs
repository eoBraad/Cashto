namespace Cashto.Communication.Requests.Account;

public class CreateAccountRequestJson
{
    public decimal Balance { get; set; }
    public string Name { get; set; } = string.Empty;
}