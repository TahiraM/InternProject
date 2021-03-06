﻿using System.Diagnostics.CodeAnalysis;
using System.IO;
using Serilog;

namespace InternProject.CsvFileConverter.Library.Logging
{
    [ExcludeFromCodeCoverage]
    public class FileLogger : LoggerConfiguration
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