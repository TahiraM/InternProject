using System;
using System.IO;
using Autofac;
using InternProject.CsvFileConverter.Library.Autofac;
using InternProject.CsvFileConverter.Library.Core;
using InternProject.CsvFileConverter.Library.Core.Conversions;
using InternProject.CsvFileConverter.Library.Core.IO;
using InternProject.CsvFileConverter.Library.Extensions.Formatters;
using InternProject.CsvFileConverter.Library.Interfaces.Core.Conversions.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Core.IO.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Core.IO.Interfaces.Extensions.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Store.Interfaces.UpdateFormat.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Validation.Interface;
using InternProject.CsvFileConverter.Library.Stores;
using InternProject.CsvFileConverter.Library.Stores.Extensions.UpdateFormat;
using InternProject.CsvFileConverter.Library.Validations;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
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