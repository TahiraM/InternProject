namespace CsvFileConvertor
{
    public interface IJsonConverter
    {
        string ConvertToJson(DealData[] data);
    }
}