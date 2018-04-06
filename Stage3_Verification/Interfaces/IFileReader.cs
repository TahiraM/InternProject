using Serilog;

namespace CsvFileConverter
{
    public interface IFileReader
    {
        DealData[] ReadContent(string input);
       
    }
}