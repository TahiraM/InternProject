using System;
using Autofac;
using InternProject.CsvFileConverter.Library;
using Serilog;

namespace CsvFileConverter
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            const string inputFile = @"C:\GIT\InternProject\InternProject.CsvFileConverter\Deal.csv";
            const string outputFile = @"C:\GIT\InternProject\InternProject.CsvFileConverter\Vali.json";
            try
            {
                var configuration = new FileOutputOptions {OutputFile = outputFile };

                Log.Logger.Information($"Setup container");
                var container = IocBuilder.Build(configuration);

                Log.Logger.Information($"Create converter from container");
                var converter = container.Resolve<CsvToJsonConverter>();

                Log.Logger.Information($"Start of the conversion process from {inputFile} to {outputFile}");
                converter.Convert(inputFile);


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