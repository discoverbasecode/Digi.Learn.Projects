using Framework.Core.Domain.Entities;

namespace Framework.Core.Domain.Repositories;

public interface IMongoRepository<TEntity> where TEntity : BaseEntity

{
    Task Delete(Guid id);
    Task<TEntity?> GetById(Guid id);
    Task Insert(TEntity entity);
    Task Update(TEntity entity);
}