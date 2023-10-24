using Microsoft.Extensions.DependencyInjection;
using App = CotacaoBolsa.Application.Mapper;
using Repo = CotacaoBolsa.Data.Mapper;

namespace CotacaoBolsa.IoC
{
    public class MapperConfig
    {
        public static void Configure(IServiceCollection services)
        {

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new App.ProfileConfig());
                cfg.AddProfile(new Repo.ProfileConfig());
            }, System.AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
