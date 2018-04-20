namespace InternProject.CsvFileConverter.Library
{
    public interface IFileWriter
    {
        void WriteContent(string output, DealData[] data);
        void WriteContent(string output, DealData[] data, bool overwrite);
        void WriteContent(string output, DealData[] data, FormatterType formatterType);
        void WriteContent(string output, DealData[] data, bool overwrite, FormatterType formatterType);
    }
}