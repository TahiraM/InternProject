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

            FundData data = new FundData {FundId = rows[0]};
            FundData rowD = new FundData();

            for (var i = 1; i <= rows.Length-1; i++)
            {
                rowD.FundName = rows[i];
               
            }
             

            return new FundData[]{data, rowD};
        }

        
        
    }
}
