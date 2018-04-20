﻿using Autofac;
using Serilog;

namespace InternProject.CsvFileConverter.Library
{
    public class IocBuilder
    {
        public static IContainer Build()
        {
            var logger = Log.Logger = new LoggerConfigFile().SeriLogConfig;

            var builder = new ContainerBuilder();

            builder.RegisterType<CsvToJsonConverter>();
            builder.RegisterInstance(logger);
            builder.RegisterType<FileReader>().As<IFileReader>();
            builder.RegisterType<DataExtractor>().As<IDataExtractor>();
            builder.RegisterType<JsonTextFormatter>().As<ITextFormatter>();
            builder.RegisterType<XmlTextFormatter>().As<ITextFormatter>();
            builder.RegisterType<FileWriter>().As<IFileWriter>();

            builder.RegisterType<IntFieldValidator>().As<IFieldValidator>();
            builder.RegisterType<DoubleFieldValidator>().As<IFieldValidator>();
            builder.RegisterType<DateFieldValidator>().As<IFieldValidator>();
            builder.RegisterType<StringFieldValidator>().As<IFieldValidator>();

            var container = builder.Build();
            return container;
        }
    }
}