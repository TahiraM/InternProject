using System;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Interfaces.Core.IO.Interfaces;
using InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces;

namespace InternProject.CsvFileConverter.Library.Core.IO
{
    public class FileDataStoreWriter : IDataStoreWriter
    {
        private readonly IFileWriter _fileWriter;
        private readonly FileOutputOptions _options;

        public FileDataStoreWriter(IFileWriter fileWriter, FileOutputOptions options)
        {
            _fileWriter = fileWriter ?? throw new ArgumentNullException(nameof(fileWriter));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public void Write(DealData[] data)
        {
            _fileWriter.WriteContent(_options.OutputFile, data, _options.OutputFileFormat);
        }
    }
}