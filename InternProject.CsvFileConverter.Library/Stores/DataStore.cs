using System;
using System.Collections.Generic;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces;

namespace InternProject.CsvFileConverter.Library.Stores
{
    public class DataStore : IDataStore
    {
        private readonly IEnumerable<IDataStoreWriter> _writers;

        public DataStore(IEnumerable<IDataStoreWriter> writers)
        {
            _writers = writers ?? throw new ArgumentNullException(nameof(writers));
        }

        public void Store(DealData[] data)
        {
            foreach (var writer in _writers) writer.Write(data);
        }
    }
}