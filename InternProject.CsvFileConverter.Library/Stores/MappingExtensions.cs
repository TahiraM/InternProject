using Microsoft.EntityFrameworkCore;

namespace InternProject.CsvFileConverter.Library
{
    public static class MappingExtensions
    {
        public static ModelBuilder MapDealData(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<DealData>();

            entity.HasKey(b => new
            {
                b.ID,
                b.V3DealId
            });

            

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
            entity.Property(m => m.TransactionFees).HasColumnType("DECIMAL");
            entity.Property(m => m.OtherFees).HasColumnType("DECIMAL");
            entity.Property(m => m.ExitDate).HasColumnType("DATETIME");

            entity.Property(m => m.Currency).HasColumnType("VARCHAR(5)");


            return modelBuilder;
        }

        //public static ModelBuilder UpdateDealData(this ModelBuilder modelBuilder)
        //{

        //    var entity = modelBuilder.Entity<DealData>();
        //    entity.HasKey(b => b.V3DealId);
        //    entity.Property(m => m.V3DealId).IsConcurrencyToken();
        //        entity.Property(m => m.EFrontDealId).HasColumnType("VARCHAR(40)").IsRowVersion();
        //        entity.Property(m => m.DealName).HasColumnType("VARCHAR(30)").IsRowVersion();
        //        entity.Property(m => m.V3CompanyId).HasColumnType("VARCHAR(40)").IsRowVersion();
        //        entity.Property(m => m.V3CompanyName).HasColumnType("VARCHAR(30)").IsRowVersion();
        //        entity.Property(m => m.SectorId).HasColumnType("INT").IsRowVersion();
        //        entity.Property(m => m.Sector).HasColumnType("VARCHAR(25)").IsRowVersion();
        //        entity.Property(m => m.CountryId).HasColumnType("INT").IsRowVersion();
        //        entity.Property(m => m.Country).HasColumnType("VARCHAR(15)").IsRowVersion();
        //        entity.Property(m => m.TransactionTypeId).HasColumnType("INT").IsRowVersion();
        //        entity.Property(m => m.TransactionType).HasColumnType("VARCHAR(25)").IsRowVersion();
        //        entity.Property(m => m.TransactionFees).HasColumnType("DECIMAL").IsRowVersion();
        //        entity.Property(m => m.OtherFees).HasColumnType("DECIMAL").IsRowVersion();
        //        entity.Property(m => m.ExitDate).HasColumnType("DATETIME").IsRowVersion();
        //        entity.Property(m => m.Currency).HasColumnType("VARCHAR(5)").IsRowVersion();


        //    return modelBuilder;
        //}
    }
}