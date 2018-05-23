using System;
using InternProject.CsvFileConverter.Library.Interfaces.Core.Conversions.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Core.IO.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces;

namespace InternProject.CsvFileConverter.Library.Core
{
    public interface ICsvToJsonConverter
    {
        void Convert(string input);
    }

    public class CsvToJsonConverter : ICsvToJsonConverter
    {
        private readonly IDataExtractor _dataExtractor;
        private readonly IDataStore _dataStore;
        private readonly IFileReader _fileReader;

        public CsvToJsonConverter(
            IFileReader fileReader,
            IDataExtractor dataExtractor,
            IDataStore dataStore)
        {
            _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
            _dataExtractor = dataExtractor ?? throw new ArgumentNullException(nameof(dataExtractor));
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }

        public void Convert(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            // Read the CSV file
            var content = _fileReader.ReadContent(input);

            //Extract CSV Data
            var data = _dataExtractor.ReadContent(content, true);

            // Store data 
            _dataStore.Store(data);
        }

        
    }
}