using Cashto.Domain.Entities;

namespace Cashto.Domain.Repositories.User;

public interface IUserWriteOnlyRepository
{
    public Task AddAsync(Entities.User user);
}