using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Serilog;

namespace CsvFileConverter
{
    public class FileWriter : IFileWriter
    {
        private readonly Dictionary<FormatterType, ITextFormatter> _formatters;

        public FileWriter(IEnumerable<ITextFormatter> formatters)
        {
            _formatters = formatters?.ToDictionary(m => m.Type) ?? throw new ArgumentNullException(nameof(formatters));
        }

        public void WriteContent(string output, DealData[] dealData)
        {
            WriteContent(output, dealData, true, FormatterType.Json);
        }

        public void WriteContent(string output, DealData[] dealData, bool overwrite)
        {
            WriteContent(output, dealData, overwrite, FormatterType.Json);
        }

        public void WriteContent(string output, DealData[] dealData, FormatterType formatterType)
        {
            WriteContent(output, dealData, true, formatterType);
        }

        public void WriteContent(string output, DealData[] dealData, bool overwrite, FormatterType formatterType)
        {
            if (overwrite == false && File.Exists(output))
            {
                var exception = new ApplicationException($"File {output} exists and can't be replaced");
                Log.Error(exception, "File {Output} exists and can't be replaced", output);
                throw exception;
            }

            Log.Information($"Data is being saved to {output} and Data is {dealData}");

            if (!_formatters.ContainsKey(formatterType))
                throw new Exception($"Formatter is not available for {formatterType.ToString()}");

            var formatter = _formatters[formatterType];
            var data = formatter.Format(dealData);

            File.WriteAllText(output, data);
        }
    }
}