using System;
using System.IO;
using System.Threading;
using LumenWorks.Framework.IO.Csv;
using Serilog;

namespace CsvFileConverter
{
    public class FileReader : IFileReader
    {

        
        public string[] ReadContent(string input)
        {
            string[] data = { };

            using (var csv = new CsvReader(new StreamReader(input)))
            {
                csv.DefaultParseErrorAction = ParseErrorAction.RaiseEvent;
                int fieldCount = csv.Columns.Count;
                string[] headers = csv.GetFieldHeaders();
                while (csv.ReadNextRecord())
                {
                    for (int i = 0; (i<= (fieldCount)); i++)
                    {
                        string content = string.Format(headers[i]+": "+ csv[i]+";" );
                        Console.WriteLine(content);
                    }
                }
            }


            return data;
        }
    }
}