using System;

namespace InternProject.CsvFileConverter.Library
{
    public class CsvToJsonConverter
    {
        private readonly IDataExtractor _dataExtractor;
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;

        public CsvToJsonConverter(
            IFileReader fileReader,
            IDataExtractor dataExtractor,
            IFileWriter fileWriter)
        {
            _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
            _dataExtractor = dataExtractor ?? throw new ArgumentNullException(nameof(dataExtractor));
            _fileWriter = fileWriter ?? throw new ArgumentNullException(nameof(fileWriter));
        }

        public void Convert(string input, string output)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (output == null) throw new ArgumentNullException(nameof(output));

            // Read the CSV file
            var content = _fileReader.ReadContent(input);

            //Extract CSV Data
            var data = _dataExtractor.ReadContent(content, true);

            // Save this into a file
            _fileWriter.WriteContent(output, data);
        }
    }
}