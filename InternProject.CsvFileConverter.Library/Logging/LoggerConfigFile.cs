using System.Diagnostics.CodeAnalysis;
using Serilog;
using Serilog.Exceptions;

namespace InternProject.CsvFileConverter.Library.Logging
{
    [ExcludeFromCodeCoverage]
    internal class LoggerConfigFile
    {
        public ILogger SeriLogConfig => Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithCaller()
            .WriteTo.File("CsvToJson.log",
                outputTemplate:
                "{Timestamp:HH:mm:ss} [{Level}]  (at {Caller}) {Message} {Exception}{NewLine}")
            .WriteTo.Console(
                outputTemplate:
                "{Timestamp:HH:mm:ss} [{Level}]  (at {Caller}) {Message} {Exception}{NewLine}")
            .CreateLogger();
    }
}