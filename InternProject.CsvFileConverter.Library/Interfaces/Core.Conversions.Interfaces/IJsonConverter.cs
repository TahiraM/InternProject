using InternProject.CsvFileConverter.Library.Extensions.Mapping;

namespace InternProject.CsvFileConverter.Library.Interfaces.Core.Conversions.Interfaces
{
    public interface IJsonConverter
    {
        string ConvertToJson(DealData[] data);
    }
}