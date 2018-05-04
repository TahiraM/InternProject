using System.Configuration;
using InternProject.CsvFileConverter.Library.Stores;
using Microsoft.EntityFrameworkCore;

namespace InternProject.CsvFileConverter.XUnitTests.DataFixtures.Tests
{
    internal class DbFixture : DbContext
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