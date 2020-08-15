using InternetTeams.Infrastructure.ExceptionHandling;
using InternetTeams.Infrastructure.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<ValidationActionFilter>();

            services.AddCors(options =>
            {
                options.AddPolicy("api", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());


            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("api");
            }
            else
            {
                app.UseExceptionHandler(errorApp => errorApp.Run(GlobalExceptionHandler.Run(loggerFactory)));
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            return app;
        }
    }
}
