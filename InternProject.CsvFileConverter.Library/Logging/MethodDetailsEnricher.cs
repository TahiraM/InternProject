﻿using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace InternProject.CsvFileConverter.Library.Logging
{
    [ExcludeFromCodeCoverage]
    public class MethodDetailsEnricher : ILogEventEnricher
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
}