using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NHibernate.Linq;

namespace CsvFileConverter
{
    [ExcludeFromCodeCoverage]
    public class JsonTextFormatter : ITextFormatter
    {
        public FormatterType Type => FormatterType.Json;

        public string Format<T>(T t) where T : class
        {
            return JsonConvert.SerializeObject(t);
        }
    }
}