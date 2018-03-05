using System;
using System.IO;

namespace Stage3_Verification
{
    public class FileReader : IFileReader
    {
        public string[] ReadContent(string input)
        {
            if (!File.Exists(input))
                throw new FileNotFoundException($"File {input} is not exists");
            string extension = Path.GetExtension(input);
            if (extension != ".csv")
                throw new FileLoadException($"File{input} not in correct format");

            var content = File.ReadAllLines(input);
            Console.WriteLine(content);
            return content;
        }
    }
}
