using System.Text;

namespace Stage3_Verification
{
    public class LegacyJsonConverter : ILegacyJsonConverter
    {
        public string Convert(DealData[] data)
        {
            var jsonString = new StringBuilder();
            DealData dealDataForHeaders;
            string[] columnNames =
            {
                nameof(dealDataForHeaders.V3DealId),nameof(dealDataForHeaders.EFrontDealId),nameof(dealDataForHeaders.DealName),
                nameof(dealDataForHeaders.V3CompanyId),nameof(dealDataForHeaders.V3CompanyName),nameof(dealDataForHeaders.SectorId),
                nameof(dealDataForHeaders.Sector),nameof(dealDataForHeaders.CountryId),nameof(dealDataForHeaders.Country),
                nameof(dealDataForHeaders.TransactionTypeId),nameof(dealDataForHeaders.TransactionType),nameof(dealDataForHeaders.TransactionFees),
                nameof(dealDataForHeaders.OtherFees),nameof(dealDataForHeaders.Currency),nameof(dealDataForHeaders.ActiveInActive),
                nameof(dealDataForHeaders.ExitDate)
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
        }
    }
}