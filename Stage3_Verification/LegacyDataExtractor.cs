using System.Linq;

namespace CsvFileConverter
{
    public class LegacyDataExtractor : ILegacyDataExtractor
    {
        public DealData[] Extract(string[] rows, bool hasTitleRow = true)
        {
            var result = rows
                .Skip(hasTitleRow == false ? 0 : 1)
                .Select(row => row.Split("||"))
                .Select(data => new DealData
                {
                    V3DealId = data[0],
                    EFrontDealId = data[1],
                    DealName = data[2],
                    V3CompanyId = data[3],
                    V3CompanyName = data[4],
                    SectorId = ValidationOfDealData.ThisInt(data[5]),
                    Sector = data[6],
                    CountryId = ValidationOfDealData.ThisInt(data[7]),
                    Country = data[8],
                    TransactionTypeId = ValidationOfDealData.ThisInt(data[9]),
                    TransactionType = data[10],
                    TransactionFees = ValidationOfDealData.ThisDouble(data[11]),
                    OtherFees = ValidationOfDealData.ThisDouble(data[12]),
                    Currency = data[13],
                    ActiveInActive = data[14],
                    ExitDate = ValidationOfDealData.ThisDate(data[15])
                })
                .ToArray();

            return result;
        }
    }

    public static class LegacyDataExtractorExtensions
    {
        public static DealData[] ExtractWithoutHeader(this LegacyDataExtractor extractor, string[] rows)
        {
            return extractor.Extract(rows, false);
        }
    }
}