using Cashto.Domain.Repositories.User;
using Cashto.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Cashto.Infrastructure.Repositories.User;

public class UserReadOnlyRepository(CashtoDbContext context) : IUserReadOnlyRepository
{
    private readonly CashtoDbContext _context = context;
    public async Task<Domain.Entities.User> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<Domain.Entities.User> GetUserByIdAsync(Guid id)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }
}