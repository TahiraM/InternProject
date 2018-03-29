using System;
using System.IO;
using Serilog;

namespace CsvFileConverter
{
    public class FileWriter : IFileWriter
    {
        public void WriteContent(string output, string data, bool overwrite = true)
        {
            if (overwrite == false && File.Exists(output))
            {   var exception = new ApplicationException($"File {output} exists and can't be replaced");
                Log.Error(exception, "File {Output} exists and can't be replaced", output);
                throw exception;
            }

            Log.Information("Data is being saved to {Output}",output);
            Log.Information("The Data being saved is {Data}", data);

            File.WriteAllText(output, data);
            
        }
    }
}