using System.Text;
using Newtonsoft.Json;
using Serilog;

namespace CsvFileConverter
{
    public class JsonConverter : IJsonConverter
    {
        public string ConvertToJson(DealData[] data)
        {
            var jsonString = new StringBuilder();
            
            jsonString.Append("[");

            jsonString.Append(JsonConvert.SerializeObject(data));

            jsonString.Append("]");
            Log.Logger.Information("Data being converted to json format");
            return jsonString.ToString();
        }
    }
}