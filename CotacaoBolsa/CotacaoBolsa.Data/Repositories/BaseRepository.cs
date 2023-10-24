using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CotacaoBolsa.Data.Entities;
using CotacaoBolsa.Domain.Entities;
using CotacaoBolsa.Domain.Interfaces.Repositories;
using CotacaoBolsa.Data.Context;

namespace CotacaoBolsa.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TModel> : IBaseRepository<TEntity>
            where TEntity : BaseEntity
            where TModel : BaseModel
    {
        public readonly IMapper _mapper;
        public readonly CotacaoBolsaContext _context;

        public BaseRepository(IMapper mapper, CotacaoBolsaContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        protected IQueryable<TModel> GetAll(bool includeChildren = false)
        {
            _context.ChangeTracker.LazyLoadingEnabled = false;
            var queryable = _context.Set<TModel>().AsQueryable().AsNoTracking();

            if (includeChildren)
                foreach (var property in typeof(TModel).GetProperties().Where(x => x.GetGetMethod().IsVirtual).ToList())
                    queryable = queryable.Include(property.Name).AsNoTracking();

            return queryable;
        }

        public virtual IEnumerable<TEntity> Get(bool includeChildren = false)
        {
            return _mapper.Map<List<TEntity>>(GetAll(includeChildren));
        }

        public virtual TEntity Get(int id, bool includeChildren = false)
        {
            return _mapper.Map<TEntity>(GetAll(includeChildren).FirstOrDefault(x => x.Id == id));
        }

        public virtual TEntity Insert(TEntity entity, bool includeChildren = false)
        {
            var result = _context.Add(_mapper.Map<TModel>(entity));
            _context.SaveChanges();
            return this.Get(result.Entity.Id, includeChildren);
        }

        public virtual TEntity Update(TEntity entity, bool includeChildren = false)
        {
            _context.Entry(_mapper.Map<TModel>(entity)).State = EntityState.Modified;
            _context.SaveChanges();
            return this.Get(entity.Id, includeChildren);
        }

        public virtual void Delete(int id)
        {
            var result = _context.Set<TModel>().FirstOrDefault(x => x.Id == id);
            _context.Set<TModel>().Remove(result);
            _context.SaveChanges();
        }
    }
}
