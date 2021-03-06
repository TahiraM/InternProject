﻿using InternProject.CsvFileConverter.Library.Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace InternProject.CsvFileConverter.WebApi
{
    public class Startup
    {
        public string Url = "http://localhost:61686/";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCoreServices(Configuration);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "DealDatas", Version = "v1" }); });
            services.AddMvc();
            services.AddCors(options => options.AddPolicy("AllowSpecificOrigin", builder =>
            {
                builder.WithOrigins(Url).AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }));

            AddDbServices(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseCors("AllowSpecificOrigin");
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "DealDatas"); });

            app.UseMvc();
        }

        protected virtual void AddDbServices(IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbServices(configuration);
        }
    }
}