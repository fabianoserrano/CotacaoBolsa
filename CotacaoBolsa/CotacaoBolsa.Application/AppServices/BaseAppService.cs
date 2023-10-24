using AutoMapper;
using CotacaoBolsa.Application.Interfaces;
using CotacaoBolsa.Application.ViewModels;
using CotacaoBolsa.Domain.Entities;
using CotacaoBolsa.Domain.Interfaces.Services;

namespace CotacaoBolsa.Application.AppServices
{
    public abstract class BaseAppService<TModel, TViewModel, TInsertViewModel, TUpdateViewModel> : IBaseAppService<TModel, TViewModel, TInsertViewModel, TUpdateViewModel>
        where TModel : BaseEntity
        where TViewModel : BaseViewModel
        where TInsertViewModel : BaseViewModel
        where TUpdateViewModel : BaseViewModel
    {
        protected readonly IBaseService<TModel> _service;
        protected readonly IMapper _mapper;

        public BaseAppService(IMapper mapper, IBaseService<TModel> service)
            : base()
        {
            this._mapper = mapper;
            this._service = service;
        }

        public virtual IEnumerable<TViewModel> Get(bool includeChildren = false)
        {
            return _mapper.Map<IEnumerable<TViewModel>>(_service.Get(includeChildren));
        }

        public virtual TViewModel Get(int id, bool includeChildren = false)
        {
            return _mapper.Map<TViewModel>(_service.Get(id, includeChildren));
        }

        public virtual TViewModel Insert(TInsertViewModel model, bool includeChildren = false)
        {
            return _mapper.Map<TViewModel>(_service.Insert(_mapper.Map<TModel>(model), includeChildren));
        }

        public virtual TViewModel Update(TUpdateViewModel model, bool includeChildren = false)
        {
            return _mapper.Map<TViewModel>(_service.Update(_mapper.Map<TModel>(model), includeChildren));
        }

        public virtual List<string> Validation(TViewModel model)
        {
            return _service.Validation(_mapper.Map<TModel>(model));
        }

        public virtual void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
