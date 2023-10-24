using CotacaoBolsa.Domain.Entities;

namespace CotacaoBolsa.Domain.Interfaces.Repositories
{
    public interface ICotacaoRepository : IBaseRepository<Cotacao>
    {
        IEnumerable<Cotacao> Get(DateTime dataCotacao, bool includeChildren = false);
        IEnumerable<Cotacao> Get(string codigoAtivo, bool includeChildren = false);
    }
}
