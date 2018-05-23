using System.Net.Mime;
using InternProject.CsvFileConverter.Library.Autofac;
using InternProject.CsvFileConverter.Library.Core;
using InternProject.CsvFileConverter.Library.Core.Conversions;
using InternProject.CsvFileConverter.Library.Core.IO;
using InternProject.CsvFileConverter.Library.Extensions.Formatters;
using InternProject.CsvFileConverter.Library.Interfaces.Core.Conversions.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Core.IO.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Core.IO.Interfaces.Extensions.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Validation.Interface;
using InternProject.CsvFileConverter.Library.Stores;
using InternProject.CsvFileConverter.Library.Validations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace InternProject.CsvFileConverter.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(@"C:\GIT\InternProject\InternProject.CsvFileConverter.WebApi\appsettings.Development.json")
                .Build();

            services.AddDbContext<DealDataDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DealData")));
            services.RegisterServices(configuration);

            services.BuildServiceProvider();


            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "Contacts API", Version = "v1"}); });
            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contacts API V1"); });

            app.UseMvc();
        }
    }
}