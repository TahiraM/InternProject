namespace CsvFileConverter
{
    public interface IFileWriter
    {
        void WriteContent(string output, string data, bool overwrite = true);
    }
}