using System.Text;
using Newtonsoft.Json;

namespace CsvFileConverter
{
    public class JsonConverter : IJsonConverter
    {
        public string ConvertToJson(DealData[] data)
        {
            var jsonString = new StringBuilder();

            jsonString.Append("[");

            for (var i = 0; i <= data.Length - 1; i++)
            {
                var dealData = data[i];

                jsonString.Append(JsonConvert.SerializeObject(dealData));
            }

            jsonString.Append("]");
            return jsonString.ToString();
        }
    }
}