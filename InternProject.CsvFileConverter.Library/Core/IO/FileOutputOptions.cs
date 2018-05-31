using System.Diagnostics.CodeAnalysis;
using InternProject.CsvFileConverter.Library.Extensions.Formatters;

namespace InternProject.CsvFileConverter.Library.Core.IO
{
    [ExcludeFromCodeCoverage]
    public class FileOutputOptions
    {
        public string OutputFile { get; set; } 
        public FormatterType OutputFileFormat { get; set; } = FormatterType.Json;
    }
}