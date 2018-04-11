using System;
using Autofac;

namespace CsvFileConverter
{

    public class CsvToJsonConverter
    {
        
        private readonly IJsonConverter _dataToJsonConverter;
        private readonly IDataExtractor _dataExtractor;
        private readonly IFileWriter _fileWriter;
        private readonly IValidations _validations;

        public CsvToJsonConverter(
            IDataExtractor dataExtractor, 
            IFileWriter fileWriter, 
            IJsonConverter dataToJsonConverter, 
            IValidations validations)
        {
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
            var content = _dataExtractor.ReadContent(input);
            var valid = _validations.ValidateData(content);
            // Converting to json
            var jsonString = _dataToJsonConverter.ConvertToJson(content);

            // Save this into a file
            _fileWriter.WriteContent(output, jsonString);
        }

        

        
    }
}