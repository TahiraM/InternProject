using System.Linq;
using Serilog;

namespace CsvFileConverter
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
            const string outputFile = "Vali.json";

            if (args.Any())
                inputFile = args[0];

            var fileReader = new FileReader();
            var fileWriter = new FileWriter();
            var legacyDataExtractor = new LegacyDataExtractor();
            var dataExtractor = new DataExtractor(legacyDataExtractor);
            var legacyJsonConverter = new LegacyJsonConverter();
            var jsonConverter = new JsonConverter(legacyJsonConverter);
            var converter = new CsvToJsonConverter(fileReader, fileWriter, dataExtractor, jsonConverter);


            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(
                    outputTemplate:
                    "{Timestamp:HH:mm:ss} [{Level:u3}] [{SourceContent:l}] {Message} {NewLine}{Exception}")
                .WriteTo.File(
                    "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] [{SourceContext}] {Message}{NewLine}{Exception}")
                .CreateLogger();
            Log.Logger.ForContext<FileReader>().Information("");
            Log.Information("Error List");
            converter.Convert(inputFile, outputFile);
        }
    }
}