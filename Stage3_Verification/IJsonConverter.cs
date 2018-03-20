namespace CsvFileConverter
{
    public interface IJsonConverter
    {
        string ConvertToJson(DealData[] data);
    }
}