using System;
using Serilog;

namespace CsvFileConverter
{
    public class MainMethods
    {
        private readonly ILogger _logger;

        public MainMethods(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void StartDataConversion()
        {
            const string inputFile = "Deal.csv";
            const string outputFile = "Vali.json";

            
            var fileReader = new FileReader();
            var fileWriter = new FileWriter();
            var legacyDataExtractor = new LegacyDataExtractor();
            var dataExtractor = new DataExtractor(legacyDataExtractor);
            var legacyJsonConverter = new LegacyJsonConverter();
            var jsonConverter = new JsonConverter(legacyJsonConverter);
            var converter = new CsvToJsonConverter(fileReader, fileWriter, dataExtractor, jsonConverter);

            

            converter.Convert(inputFile, outputFile);
        }
    }
}