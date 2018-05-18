using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

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
}