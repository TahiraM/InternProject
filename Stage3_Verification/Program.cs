using Serilog;
using Serilog.Exceptions;
using System;
using Autofac;

namespace CsvFileConverter
{
    internal class Program
    {
        const string inputFile = "Deal.csv";
        const string outputFile = "Vali.json";

        private static int Main()
        {
            var logger = SetupLogger();
            try
            {

                logger.Information($"Setup container");
                var container = IocBuilder.Build();

                logger.Information($"Create converter from container");
                var converter = container.Resolve<CsvToJsonConverter>();

                logger.Information($"Start of the conversion process from {inputFile} to {outputFile}");
                converter.Convert(inputFile, outputFile);

                Console.ReadKey();
            }
            catch (Exception e)
            {
                logger.Error($"Error in execution of convertion", e);
                return -1;
            }
            finally
            {
                Log.CloseAndFlush();
            }

            return 0;
        }

        private static ILogger SetupLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Enrich.WithCaller()
                .Enrich.WithMethodName()
                .WriteTo.File("CsvToJson.log", outputTemplate: "{Timestamp:HH:mm:ss} {Datestamp: DD:mm:yy}[{Level}] [{SourceContext}.{Method}] (at {Caller}) {Message} {Exception} {NewLine}")
                .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{Level}] [{SourceContext}.{Method}] (at {Caller}) {Message} {Exception}{NewLine}")
                .CreateLogger();

            return Log.Logger;
        }
    }
}