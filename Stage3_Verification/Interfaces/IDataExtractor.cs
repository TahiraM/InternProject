﻿using System.IO;

namespace CsvFileConverter
{
    public interface IDataExtractor
    {
        DealData[] ReadContent(StringReader input);
       
    }
}