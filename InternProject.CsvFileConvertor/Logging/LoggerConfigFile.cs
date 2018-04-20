using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Exceptions;

namespace CsvFileConverter.Logging
{
    class LoggerConfigFile 
    {

        public ILogger SeriLogConfig => Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Enrich.WithCaller()
                .WriteTo.File("C:\\GIT\\InternProject\\Stage3_Verification\\Logging\\CsvToJson.log",
                    outputTemplate:
                    "{Timestamp:HH:mm:ss} [{Level}]  (at {Caller}) {Message} {Exception}{NewLine}")
                .WriteTo.Console(
                    outputTemplate:
                    "{Timestamp:HH:mm:ss} [{Level}]  (at {Caller}) {Message} {Exception}{NewLine}")
                .CreateLogger();
    }

    
}
