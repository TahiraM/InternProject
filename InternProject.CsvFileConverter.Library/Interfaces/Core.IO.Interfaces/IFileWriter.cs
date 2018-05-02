using InternProject.CsvFileConverter.Library.Extensions.Formatters;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;

namespace InternProject.CsvFileConverter.Library.Interfaces.Core.IO.Interfaces
{
    public interface IFileWriter
    {
        void WriteContent(string output, DealData[] data);
        void WriteContent(string output, DealData[] data, bool overwrite);
        void WriteContent(string output, DealData[] data, FormatterType formatterType);
        void WriteContent(string output, DealData[] data, bool overwrite, FormatterType formatterType);
    }
}