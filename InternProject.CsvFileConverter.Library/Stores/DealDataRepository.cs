using System;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Store.Interfaces.UpdateFormat.Interfaces;

namespace InternProject.CsvFileConverter.Library.Stores
{
    public class DealDataRepository : IDealDataRepository
    {
        private readonly IUpdateRecords _updateRecords;

        public DealDataRepository(IUpdateRecords updateRecords)
        {
            _updateRecords = updateRecords ?? throw new ArgumentNullException(nameof(updateRecords));
        }

        public DealData[] SaveMany(DealData[] dealDataList)
        {
            _updateRecords.UpdateRecords(dealDataList);

            return dealDataList;
        }
    }
}