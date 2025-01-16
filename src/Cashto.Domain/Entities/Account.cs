namespace Cashto.Domain.Entities;

public class Account : BaseEntity
{
    public Guid UserId { get; set; }

    public User User { get; set; }

    public decimal Balance { get; set; }

    public List<Transaction> Transactions { get; set; } = new List<Transaction>();

    public string Name { get; set; } = string.Empty;
}