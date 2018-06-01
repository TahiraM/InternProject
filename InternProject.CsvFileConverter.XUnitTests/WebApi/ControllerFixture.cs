using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using InternProject.CsvFileConverter.Library.Stores;
using InternProject.CsvFileConverter.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InternProject.CsvFileConverter.XUnitTests.WebApi
{
    public class ControllerFixture
    {
        public ControllerFixture()
        {
            var hostBuilder = new WebHostBuilder().UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((context, builder) =>
                {
                    var env = context.HostingEnvironment;
                    env.EnvironmentName = "Development";

                    builder.SetBasePath(env.ContentRootPath)
                        .AddJsonFile("appsettings.json", false, true);
                })
                .UseStartup<Startup>();

            Server = new TestServer(hostBuilder);
            Client = Server.CreateClient();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpClient Client { get; }

        public TestServer Server { get; }

        public DealDataDbContext Context => Server.Host.Services.GetRequiredService<DealDataDbContext>();
    }
}