﻿using System.Collections.Generic;

namespace Stage3_Verification
{
    public class LegacyDataExtractor : ILegacyDataExtractor
    {
        public DealData[] Extract(string[] rows)
        {
            // Read through rows and for each row 
            // create a new FundData
            // split the row
            // validate sections and assign them to related field
            // add this to output list
            var funds = new List<DealData>();

            for (var i = 1; i <= rows.Length - 1; i++)
            {
                var data = rows[i].Split("||");


                var fund = new DealData
                {
                    V3DealId = data[0],
                    EFrontDealId = data[1],
                    DealName = data[2],
                    V3CompanyId = data[3],
                    V3CompanyName = data[4],
                    SectorId = ValidationOfDealData.ThisInt(data[5]),
                    Sector = data[6],
                    CountryId = ValidationOfDealData.ThisInt(data[7]),
                    Country = data[8],
                    TransactionTypeId = ValidationOfDealData.ThisInt(data[9]),
                    TransactionType = data[10],
                    TransactionFees = ValidationOfDealData.ThisDouble(data[11]),
                    OtherFees = ValidationOfDealData.ThisDouble(data[12]),
                    Currency = data[13],
                    ActiveInActive = data[14],
                    ExitDate = ValidationOfDealData.ThisDate(data[15])
                };
                funds.Add(fund);
            }


            return funds.ToArray();
        }
    }
}