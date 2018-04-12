using System;
using Autofac;
using CsvFileConverter.Logging;
using CsvFileConverter.MainProgramme;
using Serilog;
using Serilog.Exceptions;

//TODO: Location of logger should come from the config xml file app.config config manager object. 

namespace CsvFileConverter
{
    public class IocBuilder
    {
        public static IContainer Build()
        {
            var logger = Log.Logger = new LoggerConfigFile().SeriLogConfig;

            var builder = new ContainerBuilder();
            builder.RegisterInstance(logger);
            builder.RegisterType<FileReader>().As<IFileReader>();
            builder.RegisterType<CsvToJsonConverter>().SingleInstance(); 
            builder.RegisterType<DataExtractor>().As<IDataExtractor>();
            builder.RegisterType<JsonConverter>().As<IJsonConverter>();
            builder.RegisterType<FileWriter>().As<IFileWriter>();
            builder.RegisterType<Validations>().As<IValidations>();
            builder.RegisterType<IntFieldValidator>().As<IFieldValidator>();
            builder.RegisterType<DoubleFieldValidator>().As<IFieldValidator>();
            builder.RegisterType<DateFieldValidator>().As<IFieldValidator>();
            builder.RegisterType<StringFieldValidator>().As<IFieldValidator>();
           
           

                var container= builder.Build();

            return container;
        }

    }

    
}