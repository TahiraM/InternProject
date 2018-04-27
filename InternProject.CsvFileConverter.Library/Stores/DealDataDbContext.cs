using Microsoft.EntityFrameworkCore;

namespace InternProject.CsvFileConverter.Library
{
    public class DealDataDbContext : DbContext
    {
//        public DbSet<DealData> DealData { get; set; }
//
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: Move the configuration to config file
            optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Integrated Security=True; Initial Catalog=InternProject_CsvFileConverter_Database.dbo");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapDealData();
            
        }
    }
}