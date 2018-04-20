using System;
using System.IO;
using Serilog;

namespace CsvFileConverter
{
    public class FileLogger:LoggerConfiguration
    {
        public string FilePath = "LoggingFile.txt";

        public void Log(string message)
        {
            using (var writer = new StreamWriter(FilePath))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }


   
}