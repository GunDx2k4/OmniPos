using OmniPos.Domain.Common.Entities;

namespace OmniPos.Domain.Common.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    IUnitOfWork UnitOfWork { get; }

    IQueryable<TEntity> GetQueryableSet();

    Task AddOrUpdateAsync(TEntity entity, CancellationToken? cancellationToken = null);

    Task AddAsync(TEntity entity, CancellationToken? cancellationToken = null);

    Task UpdateAsync(TEntity entity, CancellationToken? cancellationToken = null);

    Task DeleteAsync(TEntity entity, CancellationToken? cancellationToken = null);

    Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> query);

    Task<List<T>> ToListAsync<T>(IQueryable<T> query);
}
