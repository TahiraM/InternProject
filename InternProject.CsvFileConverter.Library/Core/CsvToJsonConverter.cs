using System;
using System.Collections.Generic;

namespace InternProject.CsvFileConverter.Library
{
    public class CsvToJsonConverter
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

    public interface IDataStore
    {
        void Store(DealData[] data);
    }

    public class DataStore : IDataStore
    {
        private readonly IEnumerable<IDataStoreWriter> _writers;

        public DataStore(IEnumerable<IDataStoreWriter> writers)
        {
            _writers = writers ?? throw new ArgumentNullException(nameof(writers));
        }

        public void Store(DealData[] data)
        {
            foreach (var writer in _writers)
            {
                writer.Write(data);
            }
        }
    }

    public interface IDataStoreWriter
    {
        void Write(DealData[] data);
    }

    public class EfDataStoreWriter : IDataStoreWriter
    {
        private readonly IDealDataDb _dealDataDb;

        public EfDataStoreWriter(IDealDataDb dealDataDb)
        {
            _dealDataDb = dealDataDb ?? throw new ArgumentNullException(nameof(dealDataDb));
        }

        public void Write(DealData[] data)
        {
            _dealDataDb.SaveMany(data);
        }
    }

    public class FileDataStoreWriter : IDataStoreWriter
    {
        private readonly IFileWriter _fileWriter;
        private readonly FileOutputOptions _options;

        public FileDataStoreWriter(IFileWriter fileWriter, FileOutputOptions options)
        {
            _fileWriter = fileWriter ?? throw new ArgumentNullException(nameof(fileWriter));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public void Write(DealData[] data)
        {
            _fileWriter.WriteContent(_options.OutputFile, data, _options.OutputFileFormat);
        }
    }
}