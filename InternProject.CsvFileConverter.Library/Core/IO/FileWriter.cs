using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using InternProject.CsvFileConverter.Library.Extensions.Formatters;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Interfaces.Core.IO.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Core.IO.Interfaces.Extensions.Interfaces;
using Serilog;

namespace InternProject.CsvFileConverter.Library.Core.IO
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
            var extension = Path.GetExtension(output);
            if (extension != ".json")
            {
                if (extension == ".xml") WriteContent(output, dealData, true, FormatterType.Xml);
            }
            else
            {
                WriteContent(output, dealData, true, FormatterType.Json);
            }
        }

        public void WriteContent(string output, DealData[] dealData, bool overwrite)
        {
            var extension = Path.GetExtension(output);
            if (extension != ".json")
            {
                if (extension == ".xml") WriteContent(output, dealData, true, FormatterType.Xml);
            }
            else
            {
                WriteContent(output, dealData, true, FormatterType.Json);
            }
        }

        public void WriteContent(string output, DealData[] dealData, FormatterType formatterType)
        {
            var extension = Path.GetExtension(output);
            if (extension != ".json")
            {
                if (extension == ".xml") WriteContent(output, dealData, true, FormatterType.Xml);
            }
            else
            {
                WriteContent(output, dealData, true, FormatterType.Json);
            }
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