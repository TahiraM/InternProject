using System.IO;
using System.Xml;
using System.Xml.Serialization;
using InternProject.CsvFileConverter.Library.Interfaces.Core.IO.Interfaces.Extensions.Interfaces;

namespace InternProject.CsvFileConverter.Library.Extensions.Formatters
{
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
}