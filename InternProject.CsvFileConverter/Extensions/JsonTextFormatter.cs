using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NHibernate.Linq;

namespace CsvFileConverter
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