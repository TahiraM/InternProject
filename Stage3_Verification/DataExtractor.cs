using System;
using System.Collections.Generic;

namespace Stage3_Verification
{
    public class DataExtractor : IDataExtractor
    {
        public DealData[] Extract(string[] rows)
        {
            // Read through rows and for each row 
            // create a new FundData
            // split the row
            // validate sections and assign them to related field
            // add this to output list
            rows[0].Split("||");
            var funds = new List<DealData>();

            
                var data = rows[3].Split("||");

                var fund = new DealData
                {
                    V3DealId = data[0],
                    EFrontDealId = data[1],
                    DealName = data[2],
                    V3CompanyId = data[3],
                    V3CompanyName = data[4],
                    SectorId = Convert.ToInt32(data[5]),
                    Sector = data[6],
                    CountryId = Convert.ToInt32(data[7]),
                    Country = data[8],
                    TransactionTypeId = Convert.ToInt32(data[9]),
                    TransactionType = data[10],
                    TransactionFees = Convert.ToDouble(data[11]),
                    OtherFees = Convert.ToDouble(data[12]),
                    Currency = data[13],
                    ActiveInActive = data[14],
                    ExitDate = data[15]
                };
                funds.Add(fund);
            


            return funds.ToArray();
        }
    }
}