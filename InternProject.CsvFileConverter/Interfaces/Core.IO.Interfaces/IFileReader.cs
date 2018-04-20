using System.IO;

namespace CsvFileConverter.MainProgramme
{
    public interface IFileReader
    {
        StringReader ReadContent(string input);
    }
}