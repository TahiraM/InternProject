using CsvFileConverter;

namespace CsvFileConverterTests
{
    public class LegacyJsonConverterFixture
    {
        public LegacyJsonConverterFixture()
        {
            ValidInput = new []
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
                    ExitDate = "1/1/2001"
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
                    ExitDate = "1/1/2001"
                }

            };

            ValidOutput = GenerateOutput();




        }

        public DealData[] ValidInput { get; }
        public string ValidOutput { get; }
        public DealData[] InValidInput { get; }

        private string GenerateOutput()
        {
            return
                "[{\"V3DealId\":\"02B4EFADE6\",\"EFrontDealId\":\"02B4EFADE60B48339D13F93EB851943C\",\"DealName\":\"Marston (Project Magenta)\",\"V3CompanyId\":\"\",\"V3CompanyName\":\"\",\"SectorId\":\"\",\"Sector\":\"3\",\"CountryId\":\"United Kingdom\",\"Country\":\"229\",\"TransactionTypeId\":\"\",\"TransactionType\":\"1\",\"TransactionFees\":\"98.76\",\"OtherFees\":\"0.998\",\"Currency\":\"EUR\",\"ActiveInActive\":\"Active\",\"ExitDate\":\"1/1/2001\"}]";
        }

    }
}