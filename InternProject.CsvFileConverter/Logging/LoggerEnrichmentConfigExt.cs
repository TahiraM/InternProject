using System.Diagnostics.CodeAnalysis;
using Serilog;
using Serilog.Configuration;

namespace CsvFileConverter
{
    [ExcludeFromCodeCoverage]
    public static class LoggerEnrichmentConfigExt
    {
        public static LoggerConfiguration WithCaller(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            return enrichmentConfiguration.With<MethodDetailsEnricher>();
        }
    }
}