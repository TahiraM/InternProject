using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Stage3_Verification
{
    internal class Program
    {
        private static void Main(string[] args)
        {
//            if (args.Any())
//                Extraction.FileType = args[0];
//
//            Extraction.ExtractCsvDataFile();

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
            var converter = new CsvToJsonConverter(fileReader);

            converter.Convert(inputFile, outputFile);

        }
    }


    public class CsvToJsonConverter
    {
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;
        private readonly IDataExtractor _dataExtractor;
        private readonly IJsonConverter _dataToJsonConverter;

        public CsvToJsonConverter(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public void Convert(string input, string output)
        {
            // Read the CSV file
            var content = _fileReader.ReadContent(input);

            // Extract Important Information
            var data = _dataExtractor.Extract(content);

            // Converting to json
            var jsonString = _dataToJsonConverter.ConvertToJson(data);

            // Save this into a file
            _fileWriter.WriteContent(output, jsonString);
        }
    }

    public interface IFileWriter
    {
        void WriteContent(string output, string data);
    }

    class FileWriter : IFileWriter
    {
        public void WriteContent(string output, string data)
        {
            if (File.Exists(output))
                throw new ApplicationException($"File {output} is exists and can't be replaced");

            File.WriteAllText(output, data);
        }
    }

    public interface IJsonConverter
    {
        string ConvertToJson(FundData[] data);
    }

    public interface IDataExtractor
    {
        FundData[] Extract(string[] content);
    }

    public class DataExtractor : IDataExtractor
    {
        public FundData[] Extract(string[] rows)
        {
            // Read through rows and for each row 
            // create a new FundData
            // split the row
            // validate sections and assign them to related field
            // add this to output list

            return new List<FundData>().ToArray();
        }
    }

    public class FundData
    {
        public string FundId { get; set; }
        public string FundName { get; set; }
    }

    public class FileReader : IFileReader
    {
        public string[] ReadContent(string input)
        {
            if (!File.Exists(input))
                throw new FileNotFoundException($"File {input} is not exists");

            var content = File.ReadAllLines(input);
            return content;
        }
    }

    public interface IFileReader
    {
        string[] ReadContent(string input);
    }
}