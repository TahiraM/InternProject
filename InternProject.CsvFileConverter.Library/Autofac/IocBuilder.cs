using System.Diagnostics.CodeAnalysis;
using Autofac;
using CsvHelper.Configuration;
using Serilog;

namespace InternProject.CsvFileConverter.Library
{
    [ExcludeFromCodeCoverage]
    public class IocBuilder
    {
        public static IContainer Build(FileOutputOptions fileOutputOptions)
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
            builder.RegisterType<Database>().As<IDealDataDb>();

            builder.RegisterType<EfDataStoreWriter>().AsImplementedInterfaces();
            builder.RegisterType<FileDataStoreWriter>()
                .AsImplementedInterfaces()
                .WithParameter("options", fileOutputOptions);

            builder.RegisterType<DataStore>().AsImplementedInterfaces();


            builder.RegisterType<IntFieldValidator>().As<IFieldValidator>();
            builder.RegisterType<DoubleFieldValidator>().As<IFieldValidator>();
            builder.RegisterType<DateFieldValidator>().As<IFieldValidator>();
            builder.RegisterType<StringFieldValidator>().As<IFieldValidator>();

            var container = builder.Build();
            return container;
        }
    }

    public class FileOutputOptions
    {
        public string OutputFile { get; set; }
        public FormatterType OutputFileFormat { get; set; } = FormatterType.Json;
    }
}