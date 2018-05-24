using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Interfaces.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternProject.CsvFileConverter.Library.Stores
{
    public class DealDataRepository : IDealDataRepository
    {
        private readonly IDbContextFactory _dbContextFactory;

        public DealDataRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        public DealData[] SaveMany(DealData[] dealDataList)
        {
            using (var db = _dbContextFactory.Create())
            {
                SaveToDatabase(dealDataList, db);

                db.SaveChanges();
            }

            return dealDataList;
        }

        public async Task<IEnumerable<DealData>> SaveManyAsync(DealData[] dealDataList)
        {
            using (var db = _dbContextFactory.Create())
            {
                SaveToDatabase(dealDataList, db);

                await db.SaveChangesAsync();
            }

            return dealDataList;
        }

        public async Task<IEnumerable<DealData>> GetListAsync()
        {
            using (var db = _dbContextFactory.Create())
            {
                db.Database.EnsureCreated();

                return await db.Set<DealData>().ToListAsync();
            }
        }

        public async Task<DealData> GetAsync(string dealId)
        {
            using (var db = _dbContextFactory.Create())
            {
                db.Database.EnsureCreated();

                return await db.Set<DealData>().FindAsync(dealId);
            }
        }

        private static void SaveToDatabase(DealData[] dealDataList, DealDataDbContext db)
        {
            db.Database.EnsureCreated();

            foreach (var dealData in dealDataList)
            {
                var loaded = db.Set<DealData>()
                    .AsNoTracking()
                    .FirstOrDefault(d => d.V3DealId == dealData.V3DealId);

                if (loaded == null)
                    db.Set<DealData>().Add(dealData);
                else
                    db.Set<DealData>().Update(dealData);
            }
        }
    }
}