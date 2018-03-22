using System.Diagnostics;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace CsvFileConverter
{
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
}