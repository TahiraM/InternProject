﻿namespace CsvFileConverter
{
    public interface IDataExtractor
    {
        DealData[] Extract(string[] rows, bool hasTitleRow = true);
    }
}