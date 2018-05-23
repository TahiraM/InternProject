using System.Collections.Generic;
using System.Threading.Tasks;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;

namespace InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces
{
    public interface IDealDataRepository
    {
        DealData[] SaveMany(DealData[] dealDataList);

        Task<IEnumerable<DealData>> GetListAsync();
        Task<DealData> GetAsync(string dealId);
        Task<IEnumerable<DealData>> SaveManyAsync(DealData[] dealDataList);
    }
}