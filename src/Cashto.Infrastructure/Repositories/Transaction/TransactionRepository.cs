using Cashto.Domain.Repositories;
using Cashto.Domain.Repositories.Transaction;
using Cashto.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Cashto.Infrastructure.Repositories.Transaction;

public class TransactionRepository(CashtoDbContext context, IWorkUnity workUnity)
    : ITransactionWriteOnlyRepository, ITransactionReadOnlyRepository
{
    public async Task AddAsync(Domain.Entities.Transaction? entity)
    {
        await context.Transactions.AddAsync(entity!);
        await workUnity.Commit();
    }

    public async Task<Domain.Entities.Transaction> UpdateAsync(Domain.Entities.Transaction entity)
    {
        context.Transactions.Update(entity);

        await workUnity.Commit();

        return entity;
    }

    public async Task DeleteAsync(Domain.Entities.Transaction entity)
    {
        context.Transactions.Remove(entity);
        await workUnity.Commit();

    }

    public async Task<Domain.Entities.Transaction?> GetByIdAsync(Guid id)
    {
        return await context.Transactions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Domain.Entities.Transaction>?> GetAllAsync()
    {
        return await context.Transactions.AsNoTracking().ToListAsync();
    }
}