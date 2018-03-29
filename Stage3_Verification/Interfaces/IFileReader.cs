using Serilog;

namespace CsvFileConverter
{
    public interface IFileReader
    {
        string[] ReadContent(string input);
       
    }
}