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
                var result = _legacyJsonConverter.Convert(data);
                var dealDataList = JsonConvert.DeserializeObject<DealData[]>(result);

                return JsonConvert.SerializeObject(dealDataList);
            }
            catch (Exception e)
            {
                throw new JsonException("Error in parsing Json", e);
            }
        }
    }
}