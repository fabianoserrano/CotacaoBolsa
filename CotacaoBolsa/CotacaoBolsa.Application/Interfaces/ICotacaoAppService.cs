using CotacaoBolsa.Application.ViewModels.Cotacao;
using CotacaoBolsa.Domain.Entities;

namespace CotacaoBolsa.Application.Interfaces
{
    public interface ICotacaoAppService : IBaseAppService<Cotacao, CotacaoViewModel, CotacaoInsertViewModel, CotacaoUpdateViewModel>
    {
        IEnumerable<CotacaoViewModel> Get(DateTime dataCotacao, bool includeChildren = false);
        IEnumerable<CotacaoViewModel> Get(string codigoAtivo, bool includeChildren = false);
    }
}
