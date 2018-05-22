namespace InternProject.CsvFileConverter.Library.Stores
{
    public interface IDbContextFactory
    {
        DealDataDbContext Create();
    }
}