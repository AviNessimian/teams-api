using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
      

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app, IHostingEnvironment env)
        {
            return app;
        }
    }
}
