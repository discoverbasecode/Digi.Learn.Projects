using System.Linq.Expressions;
using Framework.Core.Domain.Entities;
using Framework.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Framework.Core.Persistence.Repositories;

public class BaseRepository<TEntity, TContext>(TContext context) : IBaseRepository<TEntity> where TContext : DbContext where TEntity : BaseEntity
{
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        => await context.AddAsync(entity, cancellationToken);

    public void Add(TEntity entity) => context.Add(entity);

    public async Task AddRange(ICollection<TEntity> entities, CancellationToken cancellationToken)
        => await context.AddRangeAsync(entities, cancellationToken);

    public TEntity? Get(Guid id)
    {
        return context.Set<TEntity>().Find(id);
    }

    public async Task<TEntity?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<TEntity>().FindAsync(id, cancellationToken);
    }

    public async Task<TEntity?> GetTracking(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(c => c.Id.Equals(id), cancellationToken);
    }

    public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public void Edit(TEntity entity) => context.Update(entity);


    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
    {
        return await context.Set<TEntity>().AnyAsync(expression, cancellationToken);
    }

    public bool Exists(Expression<Func<TEntity, bool>> expression)
    {
        return context.Set<TEntity>().Any(expression);
    }

    public async Task<int> Save(CancellationToken cancellationToken)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }

    public void SaveSync() => context.SaveChanges();
}