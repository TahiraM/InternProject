namespace InternProject.CsvFileConverter.Library
{
    public interface IJsonConverter
    {
        string ConvertToJson(DealData[] data);
    }
}