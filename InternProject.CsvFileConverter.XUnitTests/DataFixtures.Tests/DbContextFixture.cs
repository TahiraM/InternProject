using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Stores;
using Microsoft.EntityFrameworkCore;
using NHibernate.SqlCommand;

namespace InternProject.CsvFileConverter.XUnitTests.DataFixtures.Tests
{
    public class DbContextFixture : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection =
                "Data Source=.\\sqlexpress;Integrated Security=True; Initial Catalog=InternProject_CsvFileConverter_Database.dbo";
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapDealDataFixture();
        }
    }

    

    public class DealDataFixture
    {
        public string V3DealId { get; set; }
        public string EFrontDealId { get; set; }
        public string DealName { get; set; }
        public string V3CompanyId { get; set; }
        public string V3CompanyName { get; set; }
        public int? SectorId { get; set; }
        public string Sector { get; set; }
        public int? CountryId { get; set; }
        public string Country { get; set; }
        public int? TransactionTypeId { get; set; }
        public string TransactionType { get; set; }
        public double? TransactionFees { get; set; }
        public double? OtherFees { get; set; }
        public string Currency { get; set; }
        public string ActiveInActive { get; set; }
        public DateTime? ExitDate { get; set; }
    }

    public static class MappingExtensions
    {
        public static ModelBuilder MapDealDataFixture(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<DealDataFixture>();

            entity.ToTable("DealData");

            entity.HasKey(b => b.V3DealId);

            entity.Property(m => m.V3DealId);
            entity.Property(m => m.EFrontDealId);
            entity.Property(m => m.DealName);
            entity.Property(m => m.V3CompanyId).HasColumnType("VARCHAR(40)");
            entity.Property(m => m.V3CompanyName).HasColumnType("VARCHAR(30)");
            entity.Property(m => m.SectorId).HasColumnType("INT");
            entity.Property(m => m.Sector).HasColumnType("VARCHAR(25)");
            entity.Property(m => m.CountryId).HasColumnType("INT");
            entity.Property(m => m.Country).HasColumnType("VARCHAR(15)");
            entity.Property(m => m.TransactionTypeId).HasColumnType("INT");
            entity.Property(m => m.TransactionType).HasColumnType("VARCHAR(25)");
            entity.Property(m => m.TransactionFees);
            entity.Property(m => m.OtherFees);
            entity.Property(m => m.ExitDate).HasColumnType("DATETIME");
            entity.Property(m => m.Currency).HasColumnType("VARCHAR(5)");

            return modelBuilder;
        }
    }
   
}


