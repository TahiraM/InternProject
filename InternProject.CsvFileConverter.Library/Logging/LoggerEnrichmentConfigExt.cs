using Serilog;
using Serilog.Configuration;

namespace InternProject.CsvFileConverter.Library
{
    public static class LoggerEnrichmentConfigExt
    {
        public static LoggerConfiguration WithCaller(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            return enrichmentConfiguration.With<MethodDetailsEnricher>();
        }
    }
}