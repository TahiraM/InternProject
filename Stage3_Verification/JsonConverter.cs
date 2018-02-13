using System;
using System.Collections.Generic;
using System.Text;

namespace Stage3_Verification
{
    class JsonConverter : IJsonConverter
    {
        public StringBuilder jsonString = new StringBuilder();

        public string ConvertToJson(FundData[] data)
        {
            string details = "";
            FundData getData = new FundData();
            //string[] columns = getData.FundId.Split("||");
            string[] rowData = getData.FundName.Split("||");

            for (int i = 0; i <= rowData.Length; i++)
            {
                 details = "\"" + rowData[i] + "\":" + "\"" + rowData[i] + "\"";
            }

            return details;
        }
    }
}
