namespace CsvFileConvertor
{
    public interface ILegacyJsonConverter
    {
        string Convert(DealData[] data);
    }
}