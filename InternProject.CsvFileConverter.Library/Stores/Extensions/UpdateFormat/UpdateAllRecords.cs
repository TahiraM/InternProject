using System;
using System.Linq;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Interfaces.Store.Interfaces.UpdateFormat.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternProject.CsvFileConverter.Library.Stores.Extensions.UpdateFormat
{
    public class UpdateAllRecords : IUpdateRecords
    {
        private readonly IDbContextFactory _dbContextFactory;

        public UpdateAllRecords(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        public DealData[] UpdateRecords(DealData[] dealDataList)
        {
            using (var db = _dbContextFactory.Create())
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

                db.SaveChanges();
            }

            return dealDataList;
        }
    }
}