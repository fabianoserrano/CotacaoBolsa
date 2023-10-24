using CotacaoBolsa.Domain.Entities;

namespace CotacaoBolsa.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> Get(bool includeChildren = false);
        TEntity Get(int id, bool includeChildren = false);
        TEntity Insert(TEntity entity, bool includeChildren = false);
        TEntity Update(TEntity entity, bool includeChildren = false);
        List<string> Validation(TEntity entity);
        void Delete(int id);
    }
}
