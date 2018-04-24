using System;
using System.Collections.Generic;
using InternProject.CsvFileConverter.Library;

namespace InternProject.CsvFileConverter.XUnitTests
{
    public class FileWriterFixture
    {
        public FileWriterFixture()
        {
            ValidInput = new[]
            {
                new DealData
                {
                    V3DealId = "02B4EFADE6",
                    EFrontDealId = "02B4EFADE60B48339D13F93EB851943C",
                    DealName = "Marston (Project Magenta)",
                    V3CompanyId = "",
                    V3CompanyName = "",
                    SectorId = 3,
                    Sector = "",
                    CountryId = 229,
                    Country = "United Kingdom",
                    TransactionTypeId = 1,
                    TransactionType = "",
                    TransactionFees = 98.76,
                    OtherFees = 0.998,
                    Currency = "EUR",
                    ActiveInActive = "Active",
                    ExitDate = Convert.ToDateTime("1/1/2001")
                }
            };

            InValidInput = new[]
            {
                new DealData
                {
                    V3DealId = "02B4EFADE6",
                    EFrontDealId = "02B4EFADE60B48339D13F93EB851943C",
                    DealName = "Marston (Project Magenta)",
                    V3CompanyId = "",
                    V3CompanyName = "",
                    SectorId = 0,
                    Sector = " ",
                    CountryId = 229,
                    Country = "United Kingdom",
                    TransactionTypeId = 1,
                    TransactionType = " ",
                    TransactionFees = 9.0,
                    OtherFees = 0.998,
                    Currency = "EUR",
                    ActiveInActive = "Active",
                    ExitDate = Convert.ToDateTime("1/1/2001")
                }
            };

            ValidOutput = GenerateOutput();
        }

        public DealData[] ValidInput { get; }
        public string ValidOutput { get; }
        public DealData[] InValidInput { get; }

        public IEnumerable<ITextFormatter> GetFormatters()
        {
            return new List<ITextFormatter>
            {
                new JsonTextFormatter(),
                new XmlTextFormatter()
            };
        }

        private string GenerateOutput()
        {
            return
                "[{\"V3DealId\":\"02B4EFADE6\",\"EFrontDealId\":\"02B4EFADE60B48339D13F93EB851943C\",\"DealName\":\"Marston (Project Magenta)\",\"V3CompanyId\":\"\",\"V3CompanyName\":\"\",\"SectorId\":3,\"Sector\":\"\",\"CountryId\":229,\"Country\":\"United Kingdom\",\"TransactionTypeId\":1,\"TransactionType\":\"\",\"TransactionFees\":98.76,\"OtherFees\":0.998,\"Currency\":\"EUR\",\"ActiveInActive\":\"Active\",\"ExitDate\":\"2001-01-01T00:00:00\"}]";
        }
    }
}