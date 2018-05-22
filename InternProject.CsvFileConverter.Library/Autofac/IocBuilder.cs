using System.Diagnostics.CodeAnalysis;
using Autofac;
using InternProject.CsvFileConverter.Library.Core;
using InternProject.CsvFileConverter.Library.Core.Conversions;
using InternProject.CsvFileConverter.Library.Core.IO;
using InternProject.CsvFileConverter.Library.Extensions.Formatters;
using InternProject.CsvFileConverter.Library.Interfaces.Core.Conversions.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Core.IO.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Core.IO.Interfaces.Extensions.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Store.Interfaces.UpdateFormat.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Validation.Interface;
using InternProject.CsvFileConverter.Library.Logging;
using InternProject.CsvFileConverter.Library.Stores;
using InternProject.CsvFileConverter.Library.Stores.Extensions.UpdateFormat;
using InternProject.CsvFileConverter.Library.Validations;
using Serilog;

namespace InternProject.CsvFileConverter.Library.Autofac
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
            builder.RegisterType<DealDataRepository>().As<IDealDataRepository>();

            builder.RegisterType<EfDataStoreWriter>().AsImplementedInterfaces();
            builder.RegisterType<FileDataStoreWriter>()
                .AsImplementedInterfaces()
                .WithParameter("options", fileOutputOptions);

            builder.RegisterType<DataStore>().AsImplementedInterfaces();


            builder.RegisterType<IntFieldValidator>().As<IFieldValidator>();
            builder.RegisterType<DoubleFieldValidator>().As<IFieldValidator>();
            builder.RegisterType<DateFieldValidator>().As<IFieldValidator>();
            builder.RegisterType<StringFieldValidator>().As<IFieldValidator>();

            builder.RegisterType<UpdateAllRecords>().As<IUpdateRecords>();

            var container = builder.Build();
            return container;
        }
    }
}