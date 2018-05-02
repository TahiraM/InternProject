using InternProject.CsvFileConverter.Library.Extensions.Mapping;

namespace InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces
{
    public interface IDataStoreWriter
    {
        void Write(DealData[] data);
    }
}