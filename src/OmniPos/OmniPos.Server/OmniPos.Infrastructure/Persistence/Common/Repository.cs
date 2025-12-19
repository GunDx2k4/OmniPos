using Microsoft.EntityFrameworkCore;
using OmniPos.Domain.Common.Entities;
using OmniPos.Domain.Common.Repositories;

namespace OmniPos.Infrastructure.Persistence.Common;

public abstract class Repository<TEntity>(OmniPosDbContext dbContext) : IRepository<TEntity> where TEntity : Entity
{
    private readonly OmniPosDbContext _dbContext = dbContext;

    protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

    public IUnitOfWork UnitOfWork
    {
        get => _dbContext;
    }

    public IQueryable<TEntity> GetQueryableSet()
    {
        return _dbContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity, CancellationToken? cancellationToken = null)
    {
        if (entity is AuditableEntity e) 
        {
            e.CreatedAt = DateTimeOffset.UtcNow;
        }

        await DbSet.AddAsync(entity, cancellationToken ?? CancellationToken.None);

    }

    public Task AddOrUpdateAsync(TEntity entity, CancellationToken? cancellationToken = null)
    {
        if (entity.Id == 0)
        {
            return AddAsync(entity, cancellationToken);
        }
        else
        {
            return UpdateAsync(entity, cancellationToken);
        }
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken? cancellationToken = null)
    {
        if (entity is AuditableEntity e)
        {
            e.LastModifiedAt = DateTimeOffset.UtcNow;
        }
        DbSet.Update(entity);
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken? cancellationToken = null)
    {
        if (entity is IArchivable e)
        {
            e.IsArchived = true;
            e.ArchivedAt = DateTimeOffset.UtcNow;
            await UpdateAsync(entity, cancellationToken);

        }
        else
        {
            DbSet.Remove(entity);
        }
    }

    public async Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> query)
    {
        return await query.FirstOrDefaultAsync();
    }

    public Task<List<T>> ToListAsync<T>(IQueryable<T> query)
    {
        return query.ToListAsync();
    }
}
