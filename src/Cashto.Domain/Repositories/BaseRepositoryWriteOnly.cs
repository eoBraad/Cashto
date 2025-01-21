namespace Cashto.Domain.Repositories;

public interface IBaseRepositoryWriteOnly<T>
{
    Task AddAsync(T entity);
}