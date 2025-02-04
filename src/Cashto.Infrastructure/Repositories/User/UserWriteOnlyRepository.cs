using Cashto.Domain.Repositories;
using Cashto.Domain.Repositories.User;
using Cashto.Infrastructure.Database;

namespace Cashto.Infrastructure.Repositories.User;

public class UserWriteOnlyRepository(CashtoDbContext context, IWorkUnity workUnity) : IUserWriteOnlyRepository
{
    private readonly CashtoDbContext _context = context;

    public async Task AddAsync(Domain.Entities.User user)
    {
        await _context.Users.AddAsync(user);

        await workUnity.Commit();

    }

    public async Task<Domain.Entities.User> UpdateAsync(Domain.Entities.User entity)
    {
        context.Users.Update(entity);

        await workUnity.Commit();

        return entity;
    }

    public Task DeleteAsync(Domain.Entities.User entity)
    {
        context.Users.Remove(entity);

        return workUnity.Commit();
    }
}