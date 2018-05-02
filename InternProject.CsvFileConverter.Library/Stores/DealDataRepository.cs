using System;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Store.Interfaces.UpdateFormat.Interfaces;

namespace InternProject.CsvFileConverter.Library.Stores
{
    public class DealDataRepository : IDealDataRepository
    {
        private readonly IUpdateAllRecords _updateAllRecords;

        public DealDataRepository(IUpdateAllRecords updateAllRecords)
        {
            _updateAllRecords = updateAllRecords ?? throw new ArgumentNullException(nameof(updateAllRecords));
        }

        public DealData[] SaveMany(DealData[] dealDataList)
        {
            _updateAllRecords.UpdateAll(dealDataList);

            return dealDataList;
        }
    }
}