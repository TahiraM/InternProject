using System;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Interfaces.Core.IO.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces;
using Microsoft.Extensions.Options;

namespace InternProject.CsvFileConverter.Library.Core.IO
{
    public class FileDataStoreWriter : IDataStoreWriter
    {
        private readonly IFileWriter _fileWriter;
        private readonly FileOutputOptions _options;

        public FileDataStoreWriter(IFileWriter fileWriter, IOptions<FileOutputOptions> optionsAccessor)
        {
            _fileWriter = fileWriter ?? throw new ArgumentNullException(nameof(fileWriter));
            _options = optionsAccessor?.Value ?? throw new ArgumentNullException(nameof(optionsAccessor));
        }

        public void Write(DealData[] data)
        {
            _fileWriter.WriteContent(_options.OutputFile, data, _options.OutputFileFormat);
        }
    }
}