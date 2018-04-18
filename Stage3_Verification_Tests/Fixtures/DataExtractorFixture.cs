using System;
using System.Collections.Generic;
using CsvFileConverter;

namespace CsvFileConverterTests
{
    public class DataExtractorFixture
    {
        private readonly Dictionary<Type, IFieldValidator> _validators;

        public DataExtractorFixture()
        {
            var date = "3/3/2003";
            InvalidInputSectorId =
                "02B4EFADE6 || 02B4EFADE60B48339D13F93EB851943C || Marston(Project Magenta) || JFV3CompanyId02B4EFADE6 || JFV3Company || no || Advertising || 229 || United Kingdom || 209 || Primary LBO || 2.1 || 0.1 || EUR || Active || 03 / 03 / 03"
                ;
            InvalidInputCountryId =
                "02B4EFADE6 || 02B4EFADE60B48339D13F93EB851943C || Marston(Project Magenta) || JFV3CompanyId02B4EFADE6 || JFV3Company || 1 || Advertising || no || United Kingdom || 209 || Primary LBO || 2.1 || 0.1 || EUR || Active || 03 / 03 / 03"
                ;
            InvalidInputTransTypeId =
                "02B4EFADE6 || 02B4EFADE60B48339D13F93EB851943C || Marston(Project Magenta) || JFV3CompanyId02B4EFADE6 || JFV3Company || 1 || Advertising || 229 || United Kingdom || no || Primary LBO || 2.1 || 0.1 || EUR || Active || 03 / 03 / 03"
                ;
            InvalidInputTransFees =
                "02B4EFADE6 || 02B4EFADE60B48339D13F93EB851943C || Marston(Project Magenta) || JFV3CompanyId02B4EFADE6 || JFV3Company || 1 || Advertising || 229 || United Kingdom || 209 || Primary LBO || no || 0.1 || EUR || Active || 03 / 03 / 03"
                ;
            InvalidInputOtherFees =
                "02B4EFADE6 || 02B4EFADE60B48339D13F93EB851943C || Marston(Project Magenta) || JFV3CompanyId02B4EFADE6 || JFV3Company || 1 || Advertising || 229 || United Kingdom || 209 || Primary LBO || 2.1 || no || EUR || Active || 03 / 03 / 03"
                ;
            InvalidInputExitDate =
                "02B4EFADE6 || 02B4EFADE60B48339D13F93EB851943C || Marston(Project Magenta) || JFV3CompanyId02B4EFADE6 || JFV3Company || 1 || Advertising || 229 || United Kingdom || 209 || Primary LBO || 2.1 || 0.1 || EUR || Active || no"
                ;

            ValidInput =
                "02B4EFADE6 || 02B4EFADE60B48339D13F93EB851943C || Marston(Project Magenta) || JFV3CompanyId02B4EFADE6 || JFV3Company || 1 || Advertising || 229 || United Kingdom || 209 || Primary LBO || 2.1 || 0.1 || EUR || Active || 03 / 03 / 2003"
                ;
            ValidOutput = new[]
            {
                GenerateOutput(1, 229, 209, 2.1, 0.1, Convert.ToDateTime(date))
            };
        }

        public string ValidInput { get; }
        public DealData[] ValidOutput { get; }

        public string InvalidInputSectorId { get; }
        public string InvalidInputCountryId { get; }
        public string InvalidInputTransTypeId { get; }
        public string InvalidInputTransFees { get; }
        public string InvalidInputOtherFees { get; }
        public string InvalidInputExitDate { get; }

        public IEnumerable<IFieldValidator> GetValidators()
        {
            return new List<IFieldValidator>
            {
                new DateFieldValidator(),
                new DoubleFieldValidator(),
                new IntFieldValidator(),
                new StringFieldValidator()
            };
        }

        private DealData GenerateOutput(int sectorId, int countryId, int transTypeId, double transFees,
            double otherFees, DateTime exitDate)
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