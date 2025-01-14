using Cashto.Domain.Repositories.User;
using Cashto.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Cashto.Infrastructure.Repositories.User;

public class UserReadOnlyRepository(CashtoDbContext context) : IUserReadOnlyRepository
{

    public async Task<int> VerifyUserEmailExisits(string email)
    {
        return await context.Users.CountAsync(x => x.Email == email);
    }

    public async Task<Domain.Entities.User> GetUserByEmailAsync(string email)
    {
         var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email == email);

         return user;
    }

    public async Task<Domain.Entities.User> GetUserByIdAsync(Guid id)
    {
        return await context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }
}