using InternetTeams.Application.Contracts;
using InternetTeams.Persistence.DomainData;
using InternetTeams.Persistence.Repositories;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration Configuration)
        {
            // It is recommended to store a MongoClient instance in a global place
            services.AddSingleton(new DomainDataClient(Configuration.GetSection("DomainDataSettings")));

            // DomainDataContext should have a scoped lifetime so that it can be reused efficiently.
            services.AddScoped(s => new DomainDataContext(s.GetService<DomainDataClient>()));

            services.AddTransient<IDomainValueRepository, DomainValueRepository>();

            return services;
        }
    }
}
