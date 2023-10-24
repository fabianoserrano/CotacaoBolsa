using CotacaoBolsa.Domain.Entities;

namespace CotacaoBolsa.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> Get(bool includeChildren = false);
        TEntity Get(int id, bool includeChildren = false);
        TEntity Insert(TEntity entity, bool includeChildren = false);
        TEntity Update(TEntity entity, bool includeChildren = false);
        void Delete(int id);
    }
}
