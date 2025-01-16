using Cashto.Domain.Enums;

namespace Cashto.Domain.Entities;

public class Transaction : BaseEntity
{
    public Guid UserId { get; set; }

    public decimal Amount { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateTime Date { get; set; }

    public TransactionType Type { get; set; }

    public User User { get; set; }

    public Account Account { get; set; }
}

