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
            return _legacyDataExtractor.Extract(rows);
        }
    }
}