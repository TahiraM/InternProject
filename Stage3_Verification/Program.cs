using System;
using System.Diagnostics;
using System.Linq;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;

namespace CsvFileConverter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Convert CSV file to JSON

            // Read the CSV file

            // Extract Important Information

            // Convert to the target format

            // Save this into a file
           
            
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithCaller()
                .Enrich.WithMethodName()
                .WriteTo.File("consoleapp.log", outputTemplate: "{Timestamp:HH:mm:ss} [{Level}] [{SourceContext}.{Method}] (at {Caller}) {Message}{NewLine}{Exception}")
                .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{Level}] [{SourceContext}.{Method}] (at {Caller}) {Message}{NewLine}{Exception}")
                .CreateLogger();

            var loggerForContext = Log.Logger.ForContext<MyService>();
            var service = new MyService(loggerForContext);
            service.DoWork();
            Log.CloseAndFlush();
            Console.ReadKey();
            
        }
    }

    public class CodeMethodNameEnricher : ILogEventEnricher
    {
        public string MethodPlaceHolder = "Method";
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var skip = 3;
            while (true)
            {
                var stack = new StackFrame(skip);
                if (!stack.HasMethod())
                {
                    logEvent.AddPropertyIfAbsent(new LogEventProperty(MethodPlaceHolder, new ScalarValue("<unknown method>")));
                    return;
                }

                var method = stack.GetMethod();
                if (method.DeclaringType.Assembly != typeof(Log).Assembly)
                {
                    logEvent.AddPropertyIfAbsent(new LogEventProperty(MethodPlaceHolder,new ScalarValue(method.Name)));
                }

                skip++;
            }
        }
    }

    public class CallerEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var skip = 3;
            while (true)
            {
                var stack = new StackFrame(skip);
                if (!stack.HasMethod())
                {
                    logEvent.AddPropertyIfAbsent(new LogEventProperty("Caller", new ScalarValue("<unknown method>")));
                    return;
                }

                var method = stack.GetMethod();
                if (method.DeclaringType.Assembly != typeof(Log).Assembly)
                {
                    var caller =
                        $"{method.DeclaringType.FullName}.{method.Name}({string.Join(", ", method.GetParameters().Select(pi => pi.ParameterType.FullName))})";
                    logEvent.AddPropertyIfAbsent(new LogEventProperty("Caller", new ScalarValue(caller)));
                }

                skip++;
            }
        }
    }

    public static class LoggerEnrichmentConfigExt
    {
        public static LoggerConfiguration WithCaller(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            return enrichmentConfiguration.With<CallerEnricher>();
        }

        public static LoggerConfiguration WithMethodName(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            return enrichmentConfiguration.With<CodeMethodNameEnricher>();
        }
    }

    public class MyService
    {
        private readonly ILogger _logger;

        public MyService(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void DoWork()
        {
            const string inputFile = "Deal.csv";
            const string outputFile = "Vali.json";

            
            var fileReader = new FileReader();
            var fileWriter = new FileWriter();
            var legacyDataExtractor = new LegacyDataExtractor();
            var dataExtractor = new DataExtractor(legacyDataExtractor);
            var legacyJsonConverter = new LegacyJsonConverter();
            var jsonConverter = new JsonConverter(legacyJsonConverter);
            var converter = new CsvToJsonConverter(fileReader, fileWriter, dataExtractor, jsonConverter);

            

            converter.Convert(inputFile, outputFile);
        }
    }
}