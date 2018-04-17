using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using CsvFileConverter.MainProgramme;
using Newtonsoft.Json;

namespace CsvFileConverter
{
    public class CsvToJsonConverter
    {
        private readonly IDataExtractor _dataExtractor;
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;

        public CsvToJsonConverter(
            IFileReader fileReader,
            IDataExtractor dataExtractor,
            IFileWriter fileWriter)
        {
            _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
            _dataExtractor = dataExtractor ?? throw new ArgumentNullException(nameof(dataExtractor));
            _fileWriter = fileWriter ?? throw new ArgumentNullException(nameof(fileWriter));
        }

        public void Convert(string input, string output)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (output == null) throw new ArgumentNullException(nameof(output));

            // Read the CSV file
            var content = _fileReader.ReadContent(input);

            //Extract CSV Data
            var data = _dataExtractor.ReadContent(content, true);

            // Save this into a file
            _fileWriter.WriteContent(output, data);
        }
    }

    public enum FormatterType
    {
        Json,
        Xml
    }

    public interface ITextFormatter
    {
        FormatterType Type { get; }

        string Format<T>(T t) where T : class;
    }

    public class XmlTextFormatter : ITextFormatter
    {
        public FormatterType Type => FormatterType.Xml;

        public string Format<T>(T t) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var stringWriter = new StringWriter())
            {
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    serializer.Serialize(writer, t);
                    return stringWriter.ToString();
                }
            }
        }
    }

    public class JsonTextFormatter : ITextFormatter
    {
        public FormatterType Type => FormatterType.Json;

        public string Format<T>(T t) where T : class
        {
            return JsonConvert.SerializeObject(t);
        }
    }
}