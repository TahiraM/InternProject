using System;
using Autofac;
using CsvFileConverter.MainProgramme;

namespace CsvFileConverter
{

    public class CsvToJsonConverter
    {
        
        private readonly IJsonConverter _dataToJsonConverter;
        private readonly IDataExtractor _dataExtractor;
        private readonly IFileWriter _fileWriter;
        private readonly IFileReader _fileReader;
        private readonly IValidations _validations;

        public CsvToJsonConverter(
            IFileReader fileReader,
            IDataExtractor dataExtractor, 
            IFileWriter fileWriter, 
            IJsonConverter dataToJsonConverter, 
            IValidations validations)
        {
            _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
            _dataExtractor = dataExtractor ?? throw new ArgumentNullException(nameof(dataExtractor));
            _fileWriter = fileWriter ?? throw new ArgumentNullException(nameof(fileWriter));
            _dataToJsonConverter = dataToJsonConverter ?? throw new ArgumentNullException(nameof(dataToJsonConverter));
            _validations = validations ?? throw new ArgumentNullException(nameof(validations));
        }

        public void Convert(string input, string output)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (output == null) throw new ArgumentNullException(nameof(output));

            // Read the CSV file
            var content = _fileReader.ReadContent(input);

            //Extract CSV Data
            var data = _dataExtractor.ReadContent(content);

            // Converting to json
            var jsonString = _dataToJsonConverter.ConvertToJson(data);

            // Save this into a file
            _fileWriter.WriteContent(output, jsonString);
        }

        

        
    }
}