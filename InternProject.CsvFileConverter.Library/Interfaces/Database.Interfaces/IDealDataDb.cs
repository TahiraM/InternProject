namespace InternProject.CsvFileConverter.Library
{
    public interface IDealDataDb
    {
        DealData[] SaveMany(DealData[] dealDataArray);
    }
}