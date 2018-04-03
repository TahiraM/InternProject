using System;
using Autofac;
using CsvFileConverter.Logging;
using Serilog;
using Serilog.Exceptions;
// TODO: I tried to dispose of my container by puttuing in a InstancePerLifetimeScope but I dont think this is working
// TODO: I tried to implement other autofac methods such as IStartable, But i could not get the method to work 

//TODO: Split the logger config into a seperate file
//TODO: Location of logger should come from the config xml file app.config config manager object. 

namespace CsvFileConverter
{
    public class IocBuilder
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(Log.Logger = new LoggerConfigFile().SeriLogConfig);
            builder.RegisterType<CsvToJsonConverter>().SingleInstance(); 
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

            return container;
        }

    }

    
}