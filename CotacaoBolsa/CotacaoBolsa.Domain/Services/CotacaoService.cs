using CotacaoBolsa.Domain.Entities;
using CotacaoBolsa.Domain.Interfaces.Repositories;
using CotacaoBolsa.Domain.Interfaces.Services;

namespace CotacaoBolsa.Domain.Services
{
    public class CotacaoService : BaseService<Cotacao>, ICotacaoService
    {
        public CotacaoService(ICotacaoRepository repository)
            : base(repository)
        {
        }

        public IEnumerable<Cotacao> Get(DateTime dataCotacao, bool includeChildren = false)
        {
            var repository = (ICotacaoRepository)_repository;
            return repository.Get(dataCotacao, includeChildren);
        }

        public IEnumerable<Cotacao> Get(string codigoAtivo, bool includeChildren = false)
        {
            var repository = (ICotacaoRepository)_repository;
            return repository.Get(codigoAtivo, includeChildren);
        }
    }
}
