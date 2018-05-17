using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InternProject.CsvFileConverter.Library.Stores
{
    [ExcludeFromCodeCoverage]
    public class DealDataDbContext : DbContext
    {
        public DealDataDbContext(DbContextOptions<DealDataDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapDealData();
        }
    }

    public interface IDbContextFactory
    {
        DealDataDbContext Create();
    }

    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContextOptions<DealDataDbContext> _options;

        public DbContextFactory(DbContextOptions<DealDataDbContext> options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public DealDataDbContext Create()
        {
            return new DealDataDbContext(_options);
        }
    }
}