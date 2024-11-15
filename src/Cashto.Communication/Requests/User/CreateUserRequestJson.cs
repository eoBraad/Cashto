namespace Cashto.Communication.Requests.User;

public class CreateUserRequestJson
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
}