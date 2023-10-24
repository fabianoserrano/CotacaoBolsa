using AutoMapper;
using CotacaoBolsa.Application.ViewModels.Cotacao;
using CotacaoBolsa.Domain.Entities;

namespace CotacaoBolsa.Application.Mapper
{
    public class ProfileConfig : Profile
    {
        public ProfileConfig()
        {
            CreateMap<Cotacao, CotacaoViewModel>().ReverseMap();
            CreateMap<Cotacao, CotacaoInsertViewModel>().ReverseMap();
            CreateMap<Cotacao, CotacaoUpdateViewModel>().ReverseMap();
        }
    }
}
