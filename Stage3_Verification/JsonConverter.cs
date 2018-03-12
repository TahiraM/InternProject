using System;
using Newtonsoft.Json;

namespace Stage3_Verification
{
    public class JsonConverter : IJsonConverter
    {
        private readonly ILegacyJsonConverter _legacyJsonConverter;

        public JsonConverter(ILegacyJsonConverter legacyJsonConverter)
        {
            _legacyJsonConverter = legacyJsonConverter;
        }

        public string ConvertToJson(DealData[] data)
        {
            try
            {
                var deserializer = new JsonSerializer();
                var result = _legacyJsonConverter.Convert(data);

                var dealDataList = JsonConvert.DeserializeObject(result);
                var endResult = JsonConvert.SerializeObject(dealDataList);
                return endResult;
            }
            catch (Exception e)
            {
                throw new JsonException("Error in parsing Json", e);
            }
        }
    }
}