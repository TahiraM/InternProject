using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InternProject.CsvFileConverter.Library.Autofac
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddSqlDbContext<TDbContext>(this IServiceCollection services,
            string connectionString) where TDbContext : DbContext
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<TDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}