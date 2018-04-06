using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace CsvFileConverter
{
    public class FileReader : IFileReader
    {
        public DealData[] ReadContent(string input)
        {
           
            
            var config = new Configuration
            {
                Delimiter = "||",
                Encoding = Encoding.UTF8,
                HasHeaderRecord = true,
                QuoteNoFields = false,
                PrepareHeaderForMatch = header => header.ToLowerInvariant().Replace(" ", string.Empty)
            };

            using (var stream = File.OpenRead(input))
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            using (var csv = new CsvReader(reader, config))
            {
                 var records = csv.GetRecords<DealData>().ToArray();
                Console.WriteLine(records.ToString());
                return records;
            }

            


            
        }
    }
}