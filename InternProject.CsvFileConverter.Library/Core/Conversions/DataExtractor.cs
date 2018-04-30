using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace InternProject.CsvFileConverter.Library
{
    public class DataExtractor : IDataExtractor
    {
        private readonly ILogger _logger;
        private readonly IEnumerable<IFieldValidator> _validators;

        public DataExtractor(IEnumerable<IFieldValidator> validators, ILogger logger)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public DealData[] ReadContent(StringReader reader, bool headerPresent)
        {
            var config = new Configuration()
            {
                Delimiter = "||",
                Encoding = Encoding.UTF8,
                HasHeaderRecord = headerPresent,
                HeaderValidated = null,
                MissingFieldFound = null,
                QuoteNoFields = true,
                PrepareHeaderForMatch = header => header.ToLowerInvariant().Replace(" ", string.Empty),
            };


            try
            {
                using (var csv = new CsvReader(reader, config))
                {
                    var classMap = new DealDataMap(_validators);
                    csv.Configuration.RegisterClassMap(classMap);
                    var dealDatas = csv.GetRecords<DealData>().ToArray();

                    _logger.Information($"CSV DATA OUT! with {dealDatas.Length} records");

                    

                    return dealDatas;
                }
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);

                throw;
            }
        }

    }
}
        