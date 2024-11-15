using Cashto.Domain.Repositories.User;
using Cashto.Infrastructure.Database;

namespace Cashto.Infrastructure.Repositories.User;

public class UserWriteOnlyRepository(CashtoDbContext context) : IUserWriteOnlyRepository
{
    private readonly CashtoDbContext _context = context;

    public async Task AddAsync(Domain.Entities.User user)
    {
        await _context.Users.AddAsync(user);
    }
}