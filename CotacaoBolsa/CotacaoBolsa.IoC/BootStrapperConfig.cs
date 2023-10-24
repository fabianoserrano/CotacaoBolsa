using Microsoft.Extensions.DependencyInjection;
using CotacaoBolsa.Application.AppServices;
using CotacaoBolsa.Domain.Interfaces.Repositories;
using CotacaoBolsa.Domain.Interfaces.Services;
using CotacaoBolsa.Domain.Services;
using CotacaoBolsa.Data.Repositories;
using CotacaoBolsa.Application.Interfaces;

namespace CotacaoBolsa.IoC
{
    public class BootStrapperConfig
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Services
            services.AddScoped<ICotacaoService, CotacaoService>();

            //App Services
            services.AddScoped<ICotacaoAppService, CotacaoAppService>();

            //Repositories
            services.AddScoped<ICotacaoRepository, CotacaoRepository>();
        }
    }
}
