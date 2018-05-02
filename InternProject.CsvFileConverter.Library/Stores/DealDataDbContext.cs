using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace InternProject.CsvFileConverter.Library
{
    public class DealDataDbContext : DbContext
    {
        public DbSet<DealData> DealDatas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: Move the configuration to config file
            //optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Integrated Security=True; Initial Catalog=InternProject_CsvFileConverter_Database.dbo");
            var connection =
                ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapDealData();
        }
    }
}