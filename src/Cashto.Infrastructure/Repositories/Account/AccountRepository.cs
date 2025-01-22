using Cashto.Domain.Repositories;
using Cashto.Domain.Repositories.Account;
using Cashto.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Cashto.Infrastructure.Repositories.Account;

public class AccountRepository(CashtoDbContext context, IWorkUnity workUnity) : IAccountReadOnlyRepository, IAccountWriteOnlyRepository
{
    public async Task<Domain.Entities.Account?> GetByIdAsync(Guid id)
    {
        return await context.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
    }

    public Task<List<Domain.Entities.Transaction>?> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Domain.Entities.Account?> GetAccountByUserIdAsync(Guid userId)
    {
        return await context.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.UserId == userId);
    }

    public async Task AddAsync(Domain.Entities.Account entity)
    {
        await context.Accounts.AddAsync(entity);
        await workUnity.Commit();
    }
}