﻿using System.Linq;
using InternProject.CsvFileConverter.Library.Extensions.Mapping;
using InternProject.CsvFileConverter.Library.Interfaces.Store.Interfaces.UpdateFormat.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternProject.CsvFileConverter.Library.Stores.Extensions.UpdateFormat
{
    public class UpdateSelectedRecords : IUpdateRecords
    {
        public DealData[] UpdateRecords(DealData[] dealDataList)
        {
            using (var db = new DealDataDbContext())
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