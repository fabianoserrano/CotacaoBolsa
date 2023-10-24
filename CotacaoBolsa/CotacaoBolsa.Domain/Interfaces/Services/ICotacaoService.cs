using CotacaoBolsa.Domain.Entities;

namespace CotacaoBolsa.Domain.Interfaces.Services
{
    public interface ICotacaoService : IBaseService<Cotacao>
    {
        IEnumerable<Cotacao> Get(DateTime dataCotacao, bool includeChildren = false);
        IEnumerable<Cotacao> Get(string codigoAtivo, bool includeChildren = false);
    }
}
