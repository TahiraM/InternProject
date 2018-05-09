using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace InternProject.CsvFileConverter.Library.Stores
{
    [ExcludeFromCodeCoverage]
    public class DealDataDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapDealData();
        }
    }
}