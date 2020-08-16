using InternetTeams.Web.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;

namespace InternetTeams.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
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

            services
                .AddApplication()
                .AddPersistence(Configuration)
                .AddInfrastructure();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("api");
            }
            else
            {
                app.UseExceptionHandler(errorApp => errorApp.Run(HandleException(loggerFactory)));
                app.UseHsts();
            }

            app.UseInfrastructure(env);

            app.UseHttpsRedirection();
            app.UseMvc();
        }


        private static RequestDelegate HandleException(ILoggerFactory loggerFactory)
        =>
            async context =>
            {

                context.Response.StatusCode = 500;
                context.Response.ContentType = "text/plain";

                await context.Response.WriteAsync("Fatal ERROR!");

                var exceptionFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                Exception exceptionThatOccurred = exceptionFeature.Error;

                var looger = loggerFactory.CreateLogger<Startup>();

                looger.LogCritical(exceptionThatOccurred, exceptionThatOccurred.Message);
            };
    }
}
