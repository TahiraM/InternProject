using System;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces;

namespace InternProject.CsvFileConverter.Library.Stores
{
    public class EfDataStoreWriter : IDataStoreWriter
    {
        private readonly IDealDataRepository _dealDataRepository;

        public EfDataStoreWriter(IDealDataRepository dealDataRepository)
        {
            _dealDataRepository = dealDataRepository ?? throw new ArgumentNullException(nameof(dealDataRepository));
        }

        public void Write(DealData[] data)
        {
            _dealDataRepository.SaveMany(data);
        }
    }
}