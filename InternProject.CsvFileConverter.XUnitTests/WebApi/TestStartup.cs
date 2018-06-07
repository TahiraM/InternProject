using System;
using InternProject.CsvFileConverter.Library.Stores;
using InternProject.CsvFileConverter.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InternProject.CsvFileConverter.XUnitTests.WebApi
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void AddDbServices(IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            services.AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<DealDataDbContext>(options => options.UseInMemoryDatabase("DealData"));
        }
    }
}