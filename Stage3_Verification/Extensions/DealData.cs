using System;

namespace CsvFileConverter
{
    public class DealData
    {
        public string V3DealId { get; set; }
        public string EFrontDealId { get; set; }
        public string DealName { get; set; }
        public string V3CompanyId { get; set; }
        public string V3CompanyName { get; set; }
        public int SectorId { get; set; }
        public string Sector { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public int TransactionTypeId { get; set; }
        public string TransactionType { get; set; }
        public double TransactionFees { get; set; }
        public double OtherFees { get; set; }
        public string Currency { get; set; }
        public string ActiveInActive { get; set; }
        public DateTime ExitDate { get; set; }
    }

    public class DealDataRaw
    {
        public string V3DealId { get; set; }
        public string EFrontDealId { get; set; }
        public string DealName { get; set; }
        public string V3CompanyId { get; set; }
        public string V3CompanyName { get; set; }
        public string SectorId { get; set; }
        public string Sector { get; set; }
        public string CountryId { get; set; }
        public string Country { get; set; }
        public string TransactionTypeId { get; set; }
        public string TransactionType { get; set; }
        public string TransactionFees { get; set; }
        public string OtherFees { get; set; }
        public string Currency { get; set; }
        public string ActiveInActive { get; set; }
        public string ExitDate { get; set; }
    }
}