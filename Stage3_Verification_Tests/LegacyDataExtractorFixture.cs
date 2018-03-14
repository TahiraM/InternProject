using Stage3_Verification;

namespace Stage3_Verification_Tests
{
    public class LegacyDataExtractorFixture
    {
        public LegacyDataExtractorFixture()
        {
            InvalidInputForSector = new[]
            {
                "02B4EFADE6 || 02B4EFADE60B48339D13F93EB851943C || Marston(Project Magenta) || JFV3CompanyId02B4EFADE6 || JFV3Company || no || Advertising || 229 || United Kingdom || 209 || Primary LBO || 2.1 || 0.1 || EUR || Active || 03 / 03 / 03"
            };
            ValidInput = new[]
            {
                "02B4EFADE6 || 02B4EFADE60B48339D13F93EB851943C || Marston(Project Magenta) || JFV3CompanyId02B4EFADE6 || JFV3Company || 1 || Advertising || 229 || United Kingdom || 209 || Primary LBO || 2.1 || 0.1 || EUR || Active || 03 / 03 / 03"
            };
            ValidOutput = new[]
            {
                GenerateOutput(1)
            };
        }

        public string[] ValidInput { get; }
        public DealData[] ValidOutput { get; }

        public string[] InvalidInputForSector { get; }

        private DealData GenerateOutput(int sectorId)
        {
            return new DealData()
            {
                SectorId = sectorId,
            };
        }
    }
}