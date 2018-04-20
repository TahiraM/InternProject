using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace InternProject.CsvFileConverter.Library
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