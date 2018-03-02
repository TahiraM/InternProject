using System;
using System.Text;
using Newtonsoft.Json;

namespace Stage3_Verification
{
    public class JsonConverter : IJsonConverter
    {
        public string ConvertToJson(DealData[] data)
        {
            var jsonString = new StringBuilder();
            var dealDataForHeaders = new DealData();
            string[] columnNames =
            {
                nameof(dealDataForHeaders.V3DealId),

                "V3DealId", "EFrontDealId","DealName", "V3CompanyId", "V3CompanyName", "SectorId", "Sector", "CountryId", "Country", "TransactionTypeId",
                "TransactionType", "TransactionFees", "OtherFees", "Currency", "ActiveInActive", "ExitDate"
            };

            jsonString.Append("[");

            for (var i = 0; i <= data.Length - 1; i++)
            {
                var dealData = data[i];
                string[] columnValues =
                {
                    dealData.V3DealId, dealData.EFrontDealId, dealData.DealName, dealData.V3CompanyId, dealData.V3CompanyName, dealData.Sector, dealData.SectorId.ToString(), dealData.Country, dealData.CountryId.ToString(),
                    dealData.TransactionType, dealData.TransactionTypeId.ToString(), dealData.TransactionFees.ToString(), dealData.OtherFees.ToString(), dealData.Currency, dealData.ActiveInActive, dealData.ExitDate
                };

                jsonString.Append("{");
                for (var j = 0; j <= columnNames.Length - 1; j++)
                {
                    jsonString.Append("\"" + columnNames[j] + "\":" + "\"" + columnValues[j] + "\",");
                }
                jsonString.Remove(jsonString.Length - 1, 1);
                jsonString.Append("},");
            }
            jsonString.Remove(jsonString.Length - 1, 1);

            jsonString.Append("]");
            return jsonString.ToString();

            //return JsonConvert.SerializeObject(data);
        }
    }
}