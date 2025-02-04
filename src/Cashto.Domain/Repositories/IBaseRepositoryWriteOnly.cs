namespace Cashto.Domain.Repositories;

public interface IBaseRepositoryWriteOnly<T>
{
    Task AddAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}