namespace CsvFileConverter
{
    public interface IValidations
    {
        DealData[] ValidateData(DealData[] rows);
    }
}