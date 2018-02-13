using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;

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
            var headerValues = rows[0].Split("||");

            FundData header = new FundData();
             header.FundHeader.g

            return new FundData[]{};
        }

        
        
    }
}
