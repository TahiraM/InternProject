namespace InternProject.CsvFileConverter.Library
{
    public class Database : IDealDataDb

    {
        public DealData[] SaveMany(DealData[] dealDataArray)
        {
            using (var db = new DealDataDbContext())
            {
                db.Database.EnsureCreated();

                db.AddRange(dealDataArray);

                db.SaveChanges();
            }


            return dealDataArray;
        }
    }
}