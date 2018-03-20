using System;
using System.IO;

namespace CsvFileConverter
{
    public class FileWriter : IFileWriter
    {
        public void WriteContent(string output, string data, bool overwrite = true)
        {
            if (overwrite == false && File.Exists(output))
                throw new ApplicationException($"File {output} is exists and can't be replaced");

            File.WriteAllText(output, data);
        }
    }
}