using System.IO;

namespace InternProject.CsvFileConverter.Library.Interfaces.Core.IO.Interfaces
{
    public interface IFileReader
    {
        StringReader ReadContent(string input);
    }
}