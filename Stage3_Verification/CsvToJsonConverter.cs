using System;
using System.Collections.Generic;
using System.Text;

namespace Stage3_Verification
{
    public class CsvToJsonConverter
    {
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;
        private readonly IDataExtractor _dataExtractor;
        private readonly IJsonConverter _dataToJsonConverter;

        public CsvToJsonConverter(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public void Convert(string input, string output)
        {
            // Read the CSV file
            var content = _fileReader.ReadContent(input);

            // Extract Important Information
            var data = _dataExtractor.Extract(content);

            // Converting to json
            var jsonString = _dataToJsonConverter.ConvertToJson(data);

            // Save this into a file
            _fileWriter.WriteContent(output, jsonString);
        }
    }
}
