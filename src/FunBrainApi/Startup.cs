using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunBrainDomain;
using FunBrainInfrastructure;
using FunBrainInfrastructure.Application;
using FunBrainInfrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace FunBrainApi
{
    public class Startup
    {
        public static IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
//            configuration["appSettings.json"];
//            var builder = new ConfigurationBuilder()
//                .SetBasePath(env.ContentRootPath)
//                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);

//            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            SetupIoC(services);
        }

        private void SetupIoC(IServiceCollection services)
        {
            services.AddTransient<IUserRankingService, UserRankingService>();
            services.AddTransient<IUserRankingRepository, UserRankingRepository>();
            services.AddTransient<IRandomGenerator, RandomGenerator>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<GameService>();
            services.AddTransient<RoundOfGame>();

            var iocContainerType = Configuration["appSettings:ioccontainer"];
            if (String.IsNullOrWhiteSpace(iocContainerType))
            {
                throw new NullReferenceException("Container type in appSetings not found.");
            }

            switch (iocContainerType)
            {
                case "memory":
                    services.AddSingleton<IUserRepository, UserRepositoryInMemory>();
                    services.AddSingleton<IGameRepository, GameRepositoryInMemory>();
                    services.AddSingleton<IRoundRepository, RoundRepositoryInMemory>();
                    break;
                case "hard-coded":
                    services.AddSingleton<IUserRepository, UserRepositoryHardCoded>();
                    break;
                    ;
                default:
                    throw new ArgumentOutOfRangeException($"Can't resolve DI for the type '{iocContainerType}. Check the appSettings file.");
            }
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                    .WithOrigins("http://localhost:8080");

            });
            app.UseMvc();



//            app.Run(async (context) =>
//            {
//                await context.Response.WriteAsync("Hello World!");
//            });
        }

        // Example for Accept: application/xml
        private void AddXmlAccept(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));
        }


        // Example
        private void UpperCaseJsonResult(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(o =>
                {
                    if (o.SerializerSettings.ContractResolver != null)
                    {
                        var casstedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
                        casstedResolver.NamingStrategy = null;
                    }
                });
        }
    }
}