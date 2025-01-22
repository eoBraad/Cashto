namespace Cashto.Domain.Entities;

public class Account : BaseEntity
{
    public Guid UserId { get; set; }

    public User User { get; set; } = new User();

    public decimal Balance { get; set; }

    public List<Transaction> Transactions { get; } = [];

    public string Name { get; set; } = string.Empty;
}