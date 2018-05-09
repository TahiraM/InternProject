using InternProject.CsvFileConverter.Library.Extensions.Mapping;

namespace InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces
{
    public interface IDealDataRepository
    {
        DealData[] SaveMany(DealData[] dealDataList);
    }
}