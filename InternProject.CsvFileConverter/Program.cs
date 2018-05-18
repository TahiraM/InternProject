using System;
using InternProject.CsvFileConverter.Library.Autofac;
using InternProject.CsvFileConverter.Library.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace CsvFileConverter
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            const string inputFile = @"C:\GIT\InternProject\InternProject.CsvFileConverter\Deal.csv";

            try
            {
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

                var services = new ServiceCollection();
                services.RegisterServices(configuration);

                var serviceProvider = services.BuildServiceProvider();

                var conveter = serviceProvider.GetRequiredService<CsvToJsonConverter>();
                conveter.Convert(inputFile);

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Log.Logger.Error($"Error in execution of convertion", e);
                return -1;
            }
            finally
            {
                Log.CloseAndFlush();
            }

            return 0;
        }
    }
}