namespace CsvFileConverter
{
    public interface ILegacyJsonConverter
    {
        string Convert(DealData[] data);
    }
}