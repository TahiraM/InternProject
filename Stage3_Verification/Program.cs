using System;
using Serilog;
using Serilog.Exceptions;

namespace CsvFileConverter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Enrich.WithCaller()
                .Enrich.WithMethodName()
                .WriteTo.File("CsvToJson.log", outputTemplate: "{Timestamp:HH:mm:ss} [{Level}] [{SourceContext}.{Method}] (at {Caller}) {Message} {Exception}")
                .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{Level}] [{SourceContext}.{Method}] (at {Caller}) {Message} {Exception}")
                .CreateLogger();

            var loggerForContext = Log.Logger.ForContext<MainMethods>();
            var service = new MainMethods(loggerForContext);
            service.StartDataConversion();
            Log.CloseAndFlush();
            Console.ReadKey();
        }
    }
}