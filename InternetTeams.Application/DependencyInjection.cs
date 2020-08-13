using InternetTeams.Application.Interfaces;
using InternetTeams.Application.Services;
using InternetTeams.Application.UseCases;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ICommonService, CommonService>();
            services.AddTransient<IGetAllDomainValuesInteractor, GetAllDomainValuesInteractor>();
            services.AddTransient<IGetDomainValuesByNameInteractor, GetDomainValuesByNameInteractor>();
            services.AddTransient<ICalculateTimepointsAverageInteractor, CalculateTimepointsAverageInteractor>();
            
            return services;
        }
    }
}
