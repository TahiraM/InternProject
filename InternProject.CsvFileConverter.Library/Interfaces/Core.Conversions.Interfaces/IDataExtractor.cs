using System.IO;

namespace InternProject.CsvFileConverter.Library
{
    public interface IDataExtractor
    {
        DealData[] ReadContent(StringReader input, bool headerPresent);
    }
}