using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Serilog;

namespace CsvFileConverter
{
    public class DataExtractor : IDataExtractor
    {
        private readonly IEnumerable<IFieldValidator> _validators;
        private readonly ILogger _logger;

        public DataExtractor(IEnumerable<IFieldValidator> validators, ILogger logger)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public DealData[] ReadContent(string input)
        {
            var config = new Configuration
            {
                Delimiter = "||",
                Encoding = Encoding.UTF8,
                HasHeaderRecord = true,
                QuoteNoFields = false,
                PrepareHeaderForMatch = header => header.ToLowerInvariant().Replace(" ", string.Empty)
            };

            var content = File.ReadAllText(input);
            try
            {

                using (var reader = new StringReader(content))
                {
                    using (var csv = new CsvReader(reader, config))
                    {
                        var classMap = new DealDataMap(_validators);
                        csv.Configuration.RegisterClassMap(classMap);

                        var records = csv.GetRecords<DealData>().ToArray();

                        Log.Logger.Information($"CSV DATA OUT! with {records.Length} records");

                        return records;
                    }
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