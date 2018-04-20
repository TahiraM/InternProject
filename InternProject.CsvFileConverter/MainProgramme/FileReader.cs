using System.IO;
using System.Reflection;
using Serilog;

namespace CsvFileConverter.MainProgramme
{
    public class FileReader : IFileReader
    {
        public StringReader ReadContent(string input)
        {
            if (!File.Exists(input))
            {
                var exception = new FileNotFoundException($"File {input} is not exists");
                Log.Error(exception, $"File {input} is not exists");
                throw exception;
            }

            Log.Information("Input file recieved {Input}", input);
            var extension = Path.GetExtension(input);
            if (extension != ".csv")
            {
                var exception = new FileLoadException($"File{input} not in correct format");
                Log.Error(exception, $"File{input} not in correct format");
                throw exception;
            }

            var content = File.ReadAllText(input);
            Log.Information("it works while program runs fileReader");

            var reader = new StringReader(content);

            return reader;
        }
    }
}