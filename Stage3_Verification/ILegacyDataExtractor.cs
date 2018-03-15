namespace CsvFileConvertor
{
    public interface ILegacyDataExtractor
    {
        DealData[] Extract(string[] rows, bool hasTitleRow = true);
    }
}