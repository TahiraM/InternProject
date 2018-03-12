namespace Stage3_Verification
{
    public class DataExtractor : IDataExtractor
    {
        private readonly ILegacyDataExtractor _legacyDataExtractor;

        public DataExtractor(ILegacyDataExtractor legacyDataExtractor)
        {
            _legacyDataExtractor = legacyDataExtractor;
        }

        public DealData[] Extract(string[] rows)
        {
            return _legacyDataExtractor.Extract(rows);
        }
    }
}