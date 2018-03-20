using System;
using System.IO;
using Serilog;

namespace CsvFileConverter
{
    public class FileReader : IFileReader
    {
        public string[] ReadContent(string input)
        {
            if (!File.Exists(input))
                throw new FileNotFoundException($"File {input} is not exists");
            Log.Information("Input file recieved {Input}", input);
            var extension = Path.GetExtension(input);
            if (extension != ".csv")
                Log.Error($"File{input} not in correct format");

            var content = File.ReadAllLines(input);
            Console.WriteLine(content);
            Log.Information("it works while program runs fileReader");
            return content;
        }
    }
}