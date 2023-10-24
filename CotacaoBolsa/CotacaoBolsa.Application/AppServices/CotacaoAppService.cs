using AutoMapper;
using CotacaoBolsa.Application.Interfaces;
using CotacaoBolsa.Application.ViewModels.Cotacao;
using CotacaoBolsa.Domain.Entities;
using CotacaoBolsa.Domain.Interfaces.Services;

namespace CotacaoBolsa.Application.AppServices
{
    public class CotacaoAppService : BaseAppService<Cotacao, CotacaoViewModel, CotacaoInsertViewModel, CotacaoUpdateViewModel>, ICotacaoAppService
    {
        public CotacaoAppService(IMapper mapper, ICotacaoService service)
            : base(mapper, service)
        {
        }

        public IEnumerable<CotacaoViewModel> Get(DateTime dataCotacao, bool includeChildren = false)
        {
            var service = (ICotacaoService)_service;
            return _mapper.Map<IEnumerable<CotacaoViewModel>>(service.Get(dataCotacao, includeChildren));
        }

        public IEnumerable<CotacaoViewModel> Get(string codigoAtivo, bool includeChildren = false)
        {
            var service = (ICotacaoService)_service;
            return _mapper.Map<IEnumerable<CotacaoViewModel>>(service.Get(codigoAtivo, includeChildren));
        }
    }
}
