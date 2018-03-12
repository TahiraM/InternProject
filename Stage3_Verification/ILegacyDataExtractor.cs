namespace Stage3_Verification
{
    public interface ILegacyDataExtractor
    {
        DealData[] Extract(string[] rows);
    }
}