using System;
using CsvHelper.Configuration;
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
using InternProject.CsvFileConverter.Library.Stores;
using InternProject.CsvFileConverter.Library.Validations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InternProject.CsvFileConverter.Library.Autofac
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            return services
                .RegisterFrameworkServices(configuration)
                .RegisterCoreServices(configuration);
        }

        public static IConfiguration Configuration { get; }

        private static IServiceCollection RegisterCoreServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddOptions().Configure<FileOutputOptions>(configuration);

            services.AddTransient<ICsvToJsonConverter, CsvToJsonConverter>();
            services.AddTransient<IFileWriter, FileWriter>();
            services.AddTransient<IDataExtractor, DataExtractor>();
            services.AddTransient<ITextFormatter, JsonTextFormatter>();
            services.AddTransient<ITextFormatter, XmlTextFormatter>();
            services.AddTransient<IFileReader, FileReader>();
            services.AddTransient<IDealDataRepository, DealDataRepository>();

            services.AddTransient<IDataStoreWriter, EfDataStoreWriter>();
            services.AddTransient<IDataStoreWriter, FileDataStoreWriter>();
            services.AddTransient<IDataStore, DataStore>();
            services.AddTransient<IDbContextFactory, DbContextFactory>();

            services.AddTransient<IFieldValidator, IntFieldValidator>();
            services.AddTransient<IFieldValidator, DoubleFieldValidator>();
            services.AddTransient<IFieldValidator, DateFieldValidator>();
            services.AddTransient<IFieldValidator, StringFieldValidator>();
            services.AddTransient<IFileWriter, FileWriter>();;
            services.AddDbContext<DealDataDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DealData")));
            services.AddTransient<IDbContextFactory, DbContextFactory>();
            
            return services;
        }

        private static IServiceCollection RegisterFrameworkServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddSqlDbContext<DealDataDbContext>(configuration.GetConnectionString("DealData"));

            return services;
        }
    }
}