using System;
using System.Collections.Generic;
using System.IO;

namespace Stage3_Verification
{
    public class DataExtractor : IDataExtractor
    {
        public FundData[] Extract(string[] rows)
        {
            // Read through rows and for each row 
            // create a new FundData
            // split the row
            // validate sections and assign them to related field
            // add this to output list

            FileReader parseFile = new FileReader();

            parseFile.ReadContent(string input)

            return new List<FundData>().ToArray();
        }
    }
}
