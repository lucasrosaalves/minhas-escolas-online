using MEO.Domain.Repositories;
using MEO.Infra.Data;
using MEO.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MEO.API.Configurations
{
    public static class ServicesConfig
    {
        public static void RegisterApiServices(this IServiceCollection services)
        {
            services.AddScoped<IEscolaRepository, EscolaRepository>();
            services.AddScoped<DataContext>();
        }

    }
}
