namespace CsvFileConverter
{
    public static class LegacyDataExtractorExtensions
    {
        public static DealData[] ExtractWithoutHeader(this LegacyDataExtractor extractor, string[] rows)
        {
            return extractor.Extract(rows, false);
        }
    }
}