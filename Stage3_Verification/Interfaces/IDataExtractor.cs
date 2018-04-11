using Serilog;

namespace CsvFileConverter
{
    public interface IDataExtractor
    {
        DealData[] ReadContent(string input);
       
    }
}