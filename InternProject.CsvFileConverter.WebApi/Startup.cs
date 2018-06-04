using System;
using InternProject.CsvFileConverter.Library.Autofac;
using InternProject.CsvFileConverter.Library.Stores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace InternProject.CsvFileConverter.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }


        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddDbContext<DealDataDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DealData")));
            services.RegisterServices(Configuration);

            services.BuildServiceProvider();
            
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "DealDatas", Version = "v1" }); });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "DealDatas"); });

            app.UseMvc();
        }


    }

    //public class Startup
    //{
    //    public Startup(IConfiguration configuration)
    //    {
    //        Configuration = configuration;
    //    }

    //    public Startup(IHostingEnvironment env)
    //    {
    //        var builder = new ConfigurationBuilder()
    //            .SetBasePath(env.ContentRootPath)
    //            .AddJsonFile("appsettings.json")
    //            .AddEnvironmentVariables();
    //        Configuration = builder.Build();
    //    }

    //    public IConfiguration Configuration { get; }

    //    // This method gets called by the runtime. Use this method to add services to the container.
    //    public void ConfigureServices(IServiceCollection services)
    //    {


    //        services.AddDbContext<DealDataDbContext>(options =>
    //            options.UseSqlServer(Configuration.GetConnectionString("DealData")));

    //        services.BuildServiceProvider();

    //        services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "DealDatas", Version = "v1" }); });
    //        services.AddMvc();
    //    }

    //    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    //    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    //    {
    //        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

    //        app.UseSwagger();
    //        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "DealDatas"); });

    //        app.UseMvc();
    //    }
    //}
}