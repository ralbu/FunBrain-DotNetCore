﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunBrainDomain;
using FunBrainInfrastructure;
using FunBrainInfrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace FunBrainApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddTransient<IUserRankingService, UserRankingService>();
            services.AddTransient<IUserRankingRepository, UserRankingRepository>();
            services.AddTransient<IRandomGenerator, RandomGenerator>();
            services.AddTransient<IUserRepository, UserRepositoryInMemory>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
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