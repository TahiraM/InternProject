using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace InternProject.CsvFileConverter.Library
{
    public class Database : IDealDataDb

    {
        //private readonly IUpdateDatabase _updateDatabase;

        //public Database( IUpdateDatabase updateDatabase)
        //{
        //    _updateDatabase = updateDatabase ?? throw new ArgumentNullException(nameof(updateDatabase));
        //}

        public DealData[] SaveMany(DealData[] dealDataArray)
        {
            using (var db = new DealDataDbContext())
            {

                //if (!db.Database.EnsureCreated() )
                // {
                    db.Database.EnsureCreated();
                    db.DealDatas.AddRange(dealDataArray);
                    db.DealDatas.UpdateRange(dealDataArray);
                    db.SaveChanges();
               // }

                
               // _updateDatabase.UpdateRecords(dealDataArray);

                
            }


            return dealDataArray;
        }
    }

    //public interface IUpdateDatabase
    //{
    //    void UpdateRecords(DealData[] arrayOfDatas);
    //}

    //public class UpdateDatabase:IUpdateDatabase
    //{
    //    public void UpdateRecords(DealData[] arrayOfDatas)
    //    {
    //        using (var db = new DealDataDbContext())
    //        {
    //            db.DealDatas.ToList();
                

    //        }
                
    //    }
    //}
}