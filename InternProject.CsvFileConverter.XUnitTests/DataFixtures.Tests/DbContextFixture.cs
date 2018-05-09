using InternProject.CsvFileConverter.Library.Stores;
using Microsoft.EntityFrameworkCore;

namespace InternProject.CsvFileConverter.XUnitTests.DataFixtures.Tests
{
    public class DbContextFixture : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=.\\sqlexpress;Integrated Security=True; Initial Catalog=InternProject_CsvFileConverter_Database.dbo");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapDealData();
        }
    }
}