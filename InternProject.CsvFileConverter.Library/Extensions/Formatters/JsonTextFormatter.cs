using InternProject.CsvFileConverter.Library.Interfaces.Core.IO.Interfaces.Extensions.Interfaces;
using Newtonsoft.Json;

namespace InternProject.CsvFileConverter.Library.Extensions.Formatters
{
    public class JsonTextFormatter : ITextFormatter
    {
        public FormatterType Type => FormatterType.Json;

        public string Format<T>(T t) where T : class
        {
            return JsonConvert.SerializeObject(t);
        }
    }
}