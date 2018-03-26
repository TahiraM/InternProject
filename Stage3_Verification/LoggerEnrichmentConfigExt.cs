using Serilog;
using Serilog.Configuration;

namespace CsvFileConverter
{
    public static class LoggerEnrichmentConfigExt
    {
        public static LoggerConfiguration WithCaller(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            return enrichmentConfiguration.With<MethodDetailsEnricher>();
        }
    }
}