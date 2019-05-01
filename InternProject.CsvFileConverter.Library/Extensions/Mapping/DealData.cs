using System;
using System.ComponentModel.DataAnnotations;

namespace InternProject.CsvFileConverter.Library.Extensions.Mapping
{
    public class DealData
    {
        [Required(ErrorMessage = "V3DealID cannot be empty")]
        public string V3DealId { get; set; }
        public string DealName { get; set; }
        public string EFrontDealId { get; set; }
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
}

  