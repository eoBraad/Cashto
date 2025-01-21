namespace Cashto.Domain.Repositories;

public interface IBaseRepositoryReadOnly<T>
{
    Task<T> GetByIdAsync(Guid id);

    Task<List<Entities.Transaction>> GetAllAsync();
}