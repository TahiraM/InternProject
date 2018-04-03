using System;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using Serilog;

namespace CsvFileConverter
{
    public class FileReader : IFileReader
    {
        public string[] ReadContent(string input)
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

            var content = File.ReadAllLines(input);
            Log.Information("it works while program runs fileReader");


            using (var read =
                new CsvReader(
                    new StreamReader("C:\\GIT\\InternProject\\Stage3_Verification\\InputOutputFiles\\Deal.csv"), true))
            {
                var missedValue = read.MissingFieldAction == MissingFieldAction.ReplaceByEmpty;
                var fieldCount = read.FieldCount;
                var headers = read.GetFieldHeaders();
                var intValid = new IntFieldValidator();
                while (read.ReadNextRecord())
                {
                    for (var i = 0; i < fieldCount; i++)

                        Console.Write("{0} = {1};", headers[i], read[i] == null ? "" : read[i]);
                    Console.WriteLine();
                }
            }


            // Field headers will automatically be used as column names

            return content;
        }
    }
}