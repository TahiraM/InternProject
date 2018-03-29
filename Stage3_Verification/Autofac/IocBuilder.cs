using System;
using Autofac;
using Serilog;
using Serilog.Exceptions;
// TODO: I tried to dispose of my container by puttuing in a InstancePerLifetimeScope but I dont think this is working
// TODO: I tried to implement other autofac methods such as IStartable, But i could not get the method to work 

namespace CsvFileConverter
{
    public class IocBuilder
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Enrich.WithCaller()
                .WriteTo.File("C:\\GIT\\InternProject\\Stage3_Verification\\Logging\\CsvToJson.log",
                    outputTemplate:
                    "{Timestamp:HH:mm:ss} [{Level}]  (at {Caller}) {Message} {Exception}{NewLine}")
                .WriteTo.Console(
                    outputTemplate:
                    "{Timestamp:HH:mm:ss} [{Level}]  (at {Caller}) {Message} {Exception}{NewLine}")
                .CreateLogger());

            builder.RegisterType<CsvToJsonConverter>().WithParameter("input", "C:\\GIT\\InternProject\\Stage3_Verification\\InputOutputFiles\\Deal.csv")
                .WithParameter("output", "Vali.json").InstancePerLifetimeScope(); 
            builder.RegisterType<FileReader>().As<IFileReader>();
            builder.RegisterType<DataExtractor>().As<IDataExtractor>();
            builder.RegisterType<LegacyDataExtractor>().As<ILegacyDataExtractor>();
            builder.RegisterType<JsonConverter>().As<IJsonConverter>();
            builder.RegisterType<LegacyJsonConverter>().As<ILegacyJsonConverter>();
            builder.RegisterType<FileWriter>().As<IFileWriter>();

            builder.RegisterType<IntFieldValidator>().As<IFieldValidator>();
            builder.RegisterType<DoubleFieldValidator>().As<IFieldValidator>();
            builder.RegisterType<DateFieldValidator>().As<IFieldValidator>();
            builder.RegisterType<StringFieldValidator>().As<IFieldValidator>();
           
           

                var container= builder.Build();
            using (var threadLifetime = container.BeginLifetimeScope())
            {
                var thisThreadsInstance = threadLifetime.Resolve<CsvToJsonConverter>();
            }


            return container;
        }

    }

    
}