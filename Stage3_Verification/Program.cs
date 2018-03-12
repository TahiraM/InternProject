using System.Linq;

namespace Stage3_Verification
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Convert CSV file to JSON

            // Read the CSV file

            // Extract Important Information

            // Convert to the target format

            // Save this into a file

            var inputFile = "Deal.csv";
            var outputFile = "Vali.json";

            if (args.Any())
                inputFile = args[0];

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