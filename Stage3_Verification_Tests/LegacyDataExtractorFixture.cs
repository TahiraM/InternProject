using CsvFileConverter;

namespace CsvFileConverterTests
{
    public class LegacyDataExtractorFixture
    {
        public LegacyDataExtractorFixture()
        {
            InvalidInputSectorId = new[]
            {
                "02B4EFADE6 || 02B4EFADE60B48339D13F93EB851943C || Marston(Project Magenta) || JFV3CompanyId02B4EFADE6 || JFV3Company || no || Advertising || 229 || United Kingdom || 209 || Primary LBO || 2.1 || 0.1 || EUR || Active || 03 / 03 / 03"
            };
            InvalidInputCountryId = new[]
            {
                "02B4EFADE6 || 02B4EFADE60B48339D13F93EB851943C || Marston(Project Magenta) || JFV3CompanyId02B4EFADE6 || JFV3Company || 1 || Advertising || no || United Kingdom || 209 || Primary LBO || 2.1 || 0.1 || EUR || Active || 03 / 03 / 03"
            };
            InvalidInputTransTypeId = new[]
            {
                "02B4EFADE6 || 02B4EFADE60B48339D13F93EB851943C || Marston(Project Magenta) || JFV3CompanyId02B4EFADE6 || JFV3Company || 1 || Advertising || 229 || United Kingdom || no || Primary LBO || 2.1 || 0.1 || EUR || Active || 03 / 03 / 03"
            };
            InvalidInputTransFees = new[]
            {
                "02B4EFADE6 || 02B4EFADE60B48339D13F93EB851943C || Marston(Project Magenta) || JFV3CompanyId02B4EFADE6 || JFV3Company || 1 || Advertising || 229 || United Kingdom || 209 || Primary LBO || no || 0.1 || EUR || Active || 03 / 03 / 03"
            };
            InvalidInputOtherFees = new[]
            {
                "02B4EFADE6 || 02B4EFADE60B48339D13F93EB851943C || Marston(Project Magenta) || JFV3CompanyId02B4EFADE6 || JFV3Company || 1 || Advertising || 229 || United Kingdom || 209 || Primary LBO || 2.1 || no || EUR || Active || 03 / 03 / 03"
            };
            InvalidInputExitDate = new[]
            {
                "02B4EFADE6 || 02B4EFADE60B48339D13F93EB851943C || Marston(Project Magenta) || JFV3CompanyId02B4EFADE6 || JFV3Company || 1 || Advertising || 229 || United Kingdom || 209 || Primary LBO || 2.1 || 0.1 || EUR || Active || no"
            };

            ValidInput = new[]
            {
                "02B4EFADE6 || 02B4EFADE60B48339D13F93EB851943C || Marston(Project Magenta) || JFV3CompanyId02B4EFADE6 || JFV3Company || 1 || Advertising || 229 || United Kingdom || 209 || Primary LBO || 2.1 || 0.1 || EUR || Active || 03 / 03 / 2003"
            };
            ValidOutput = new[]
            {
                GenerateOutput(1,229,209, 2.1, 0.1, "3/3/2003")
            };
        }

        public string[] ValidInput { get; }
        public DealData[] ValidOutput { get; }

        public string[] InvalidInputSectorId { get; }
        public string[] InvalidInputCountryId { get; }
        public string[] InvalidInputTransTypeId { get; }
        public string[] InvalidInputTransFees { get; }
        public string[] InvalidInputOtherFees { get; }
        public string[] InvalidInputExitDate { get; }


        private DealData GenerateOutput(int sectorId, int countryId, int transTypeId, double transFees, double otherFees, string exitDate)
        {
            return new DealData
            {
                SectorId = sectorId,
                CountryId = countryId,
                TransactionTypeId = transTypeId,
                TransactionFees = transFees,
                OtherFees = otherFees, 
                ExitDate = exitDate
            };
        }
    }
}