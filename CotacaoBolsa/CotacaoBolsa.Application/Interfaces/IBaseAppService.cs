using CotacaoBolsa.Application.ViewModels;
using CotacaoBolsa.Domain.Entities;

namespace CotacaoBolsa.Application.Interfaces
{
    public interface IBaseAppService<TModel, TViewModel, TInsertViewModel, TUpdateViewModel>
        where TModel : BaseEntity
        where TViewModel : BaseViewModel
        where TInsertViewModel : BaseViewModel
        where TUpdateViewModel : BaseViewModel
    {
        IEnumerable<TViewModel> Get(bool includeChildren = false);
        TViewModel Get(int id, bool includeChildren = false);
        TViewModel Insert(TInsertViewModel model, bool includeChildren = false);
        TViewModel Update(TUpdateViewModel model, bool includeChildren = false);
        List<string> Validation(TViewModel model);
        void Delete(int id);
    }
}
