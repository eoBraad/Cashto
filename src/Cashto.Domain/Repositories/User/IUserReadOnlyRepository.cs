using Cashto.Domain.Entities;

namespace Cashto.Domain.Repositories.User;

public interface IUserReadOnlyRepository : IBaseRepositoryReadOnly<Entities.User>
{
    public Task<int> VerifyUserEmailExisits(string email);

    public Task<Domain.Entities.User> GetUserByEmailAsync(string email);
}