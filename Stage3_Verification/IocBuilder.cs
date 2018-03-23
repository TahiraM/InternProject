using Autofac;
using Serilog;

namespace CsvFileConverter
{
    public class IocBuilder
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance<ILogger>(Log.Logger);

            builder.RegisterType<CsvToJsonConverter>();
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

            return builder.Build();
        }
    }
}