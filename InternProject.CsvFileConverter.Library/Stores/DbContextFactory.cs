using System;
using Microsoft.EntityFrameworkCore;

namespace InternProject.CsvFileConverter.Library.Stores
{
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