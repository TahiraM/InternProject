using System.IO;

namespace InternProject.CsvFileConverter.Library
{
    public interface IFileReader
    {
        StringReader ReadContent(string input);
    }
}