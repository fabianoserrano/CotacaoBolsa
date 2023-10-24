using AutoMapper;
using DomainEntities = CotacaoBolsa.Domain.Entities;
using DataEntities = CotacaoBolsa.Data.Entities;
using CotacaoBolsa.Domain.Interfaces.Repositories;
using CotacaoBolsa.Data.Context;

namespace CotacaoBolsa.Data.Repositories
{
    public class CotacaoRepository : BaseRepository<DomainEntities.Cotacao, DataEntities.Cotacao>, ICotacaoRepository
    {
        public CotacaoRepository(IMapper mapper, CotacaoBolsaContext context)
            : base(mapper, context)
        {
        }

        public IEnumerable<DomainEntities.Cotacao> Get(DateTime dataCotacao, bool includeChildren = false)
        {
            return _mapper.Map<IEnumerable<DomainEntities.Cotacao>>(GetAll(includeChildren).Where(x => x.DataCotacao.Date == dataCotacao.Date));
        }

        public IEnumerable<DomainEntities.Cotacao> Get(string codigoAtivo, bool includeChildren = false)
        {
            return _mapper.Map<IEnumerable<DomainEntities.Cotacao>>(GetAll(includeChildren).Where(x => x.CodigoAtivo == codigoAtivo));
        }
    }
}
