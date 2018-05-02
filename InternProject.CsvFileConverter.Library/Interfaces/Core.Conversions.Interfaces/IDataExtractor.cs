using System.IO;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;

namespace InternProject.CsvFileConverter.Library.Interfaces.Core.Conversions.Interfaces
{
    public interface IDataExtractor
    {
        DealData[] ReadContent(StringReader input, bool headerPresent);
    }
}