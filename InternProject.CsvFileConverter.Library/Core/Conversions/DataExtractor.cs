﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Interfaces.Core.Conversions.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Validation.Interface;
using Microsoft.Extensions.Logging;

namespace InternProject.CsvFileConverter.Library.Core.Conversions
{
    public class DataExtractor : IDataExtractor
    {
        private readonly ILogger<DataExtractor> _logger;
        private readonly IEnumerable<IFieldValidator> _validators;

        public DataExtractor(IEnumerable<IFieldValidator> validators, ILogger<DataExtractor> logger)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public DealData[] ReadContent(StringReader reader, bool headerPresent)
        {
            var config = new Configuration
            {
                Delimiter = "||",
                Encoding = Encoding.UTF8,
                HasHeaderRecord = headerPresent,
                HeaderValidated = null,
                MissingFieldFound = null,
                QuoteNoFields = true,
                PrepareHeaderForMatch = header => header.ToLowerInvariant().Replace(" ", string.Empty)
            };


            try
            {
                using (var csv = new CsvReader(reader, config))
                {
                    var classMap = new DealDataMap(_validators);
                    csv.Configuration.RegisterClassMap(classMap);
                    var dealDatas = csv.GetRecords<DealData>().ToArray();

                    _logger.LogInformation($"CSV DATA OUT! with {dealDatas.Length} records");


                    return dealDatas;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw;
            }
        }
    }
}