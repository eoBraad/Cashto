using Cashto.Domain.Entities;

namespace Cashto.Domain.Repositories.User;

public interface IUserReadOnlyRepository
{
    public Task<int> GetUserByEmailAsync(string email);

    public Task<Domain.Entities.User> GetUserByIdAsync(Guid id);
}