namespace CsvFileConverter
{
    public interface ITextFormatter
    {
        FormatterType Type { get; }

        string Format<T>(T t) where T : class;
    }
}