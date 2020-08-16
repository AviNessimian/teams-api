using InternetTeams.Domain.Contracts;
using InternetTeams.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddLazyCache();
            services.Decorate<IDomainValueRepository, DomainValueRepositoryCache>();

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app, IHostingEnvironment env)
        {
            return app;
        }
    }
}
