namespace Cashto.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public List<Account> Accounts { get; set; } = new List<Account>();

    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
}