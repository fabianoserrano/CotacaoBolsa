using AutoMapper;
using DomainEntities = CotacaoBolsa.Domain.Entities;
using DataEntities = CotacaoBolsa.Data.Entities;

namespace CotacaoBolsa.Data.Mapper
{
    public class ProfileConfig : Profile
    {
        public ProfileConfig()
        {
            CreateMap<DataEntities.Cotacao, DomainEntities.Cotacao>().ReverseMap();
        }
    }
}
