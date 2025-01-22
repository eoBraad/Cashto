namespace Cashto.Domain.Repositories.Account;

public interface IAccountReadOnlyRepository : IBaseRepositoryReadOnly<Entities.Account>
{
    Task<Entities.Account?> GetAccountByUserIdAsync(Guid userId);
}