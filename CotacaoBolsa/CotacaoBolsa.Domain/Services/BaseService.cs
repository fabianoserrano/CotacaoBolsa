using CotacaoBolsa.Domain.Entities;
using CotacaoBolsa.Domain.Interfaces.Repositories;
using CotacaoBolsa.Domain.Interfaces.Services;

namespace CotacaoBolsa.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity>
         where TEntity : BaseEntity
    {
        protected readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public IEnumerable<TEntity> Get(bool includeChildren = false)
        {
            return _repository.Get(includeChildren);
        }

        public TEntity Get(int id, bool includeChildren = false)
        {
            return _repository.Get(id, includeChildren);
        }

        public TEntity Insert(TEntity entity, bool includeChildren = false)
        {
            return _repository.Insert(entity);
        }

        public TEntity Update(TEntity entity, bool includeChildren = false)
        {
            return _repository.Update(entity);
        }

        public virtual List<string> Validation(TEntity entity)
        {
            return new List<string>();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
