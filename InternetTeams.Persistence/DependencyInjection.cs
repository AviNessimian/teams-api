using InternetTeams.Application.Interfaces;
using InternetTeams.Persistence;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<MongoDatabaseContext>();
            services.AddTransient<IDomainValueRepository, DomainValueRepository>();

            return services;
        }
    }
}
