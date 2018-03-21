﻿using System;
using Newtonsoft.Json;
using Serilog;

namespace CsvFileConverter
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
                Log.Information("Data being parsed through JsonConverter {@Data}",data);
                var result = _legacyJsonConverter.Convert(data);

                var dealDataList = JsonConvert.DeserializeObject(result);
                var endResult = JsonConvert.SerializeObject(dealDataList);
                return endResult;
            }
            catch (Exception e)
            {
                Log.Error("Error in parsing Json");
                throw new JsonException("Error in parsing Json", e);
            }
        }
    }
}