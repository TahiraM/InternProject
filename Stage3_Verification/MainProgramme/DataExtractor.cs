using Serilog;

namespace CsvFileConverter
{
    public class DataExtractor : IDataExtractor
    {
        private readonly ILegacyDataExtractor _legacyDataExtractor;

        public DataExtractor(ILegacyDataExtractor legacyDataExtractor)
        {
            _legacyDataExtractor = legacyDataExtractor;
        }

        public DealData[] Extract(string[] rows, bool hasTitleRow = true)
        {

            Log.Information("Number of rows being parsed in DataExtractor {Rows}",rows.Length);
            return _legacyDataExtractor.Extract(rows);
        }
    }
}