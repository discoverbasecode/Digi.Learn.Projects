using System.Linq.Expressions;
using Framework.Core.Domain.Entities;

namespace Framework.Core.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    void Add(TEntity entity);
    Task AddRange(ICollection<TEntity> entities, CancellationToken cancellationToken);

    TEntity? Get(Guid id);
    Task<TEntity?> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<TEntity?> GetTracking(Guid id, CancellationToken cancellationToken);
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);

    void Edit(TEntity entity);

    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
    bool Exists(Expression<Func<TEntity, bool>> expression);

    Task<int> Save(CancellationToken cancellationToken);
    void SaveSync();
}