﻿using InternProject.CsvFileConverter.Library.Extensions.Mapping;

namespace InternProject.CsvFileConverter.Library.Interfaces.Store.Interfaces.UpdateFormat.Interfaces
{
    public interface IUpdateRecords
    {
        DealData[] UpdateRecords(DealData[] dealDataList);
    }
}