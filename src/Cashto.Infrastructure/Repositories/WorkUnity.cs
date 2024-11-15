using Cashto.Domain.Repositories;
using Cashto.Infrastructure.Database;

namespace Cashto.Infrastructure.Repositories;

public class WorkUnity(CashtoDbContext dbContext) : IWorkUnity
{
    private readonly CashtoDbContext _context = dbContext;

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
}