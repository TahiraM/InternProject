using InternProject.CsvFileConverter.Library.Extensions.Formatters;

namespace InternProject.CsvFileConverter.Library.Interfaces.Core.IO.Interfaces.Extensions.Interfaces
{
    public interface ITextFormatter
    {
        FormatterType Type { get; }

        string Format<T>(T t) where T : class;
    }
}