using System;
using System.Collections.Generic;
using CsvFileConverter;
using FluentValidation;

namespace CsvFileConverterTests
{
    public class LegacyDataExtractorFixture
    {
        private readonly Dictionary<Type, IFieldValidator> _validators;
        public LegacyDataExtractorFixture()
        {
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
            //ValidOutput = new[]
            //{
            //    GenerateOutput(1, 229, 209, 2.1, 0.1, "03 / 03 / 2003")
            //};
        }

        public string ValidInput { get; }
        public DealData[] ValidOutput { get; }

        public string InvalidInputSectorId { get; }
        public string InvalidInputCountryId { get; }
        public string InvalidInputTransTypeId { get; }
        public string InvalidInputTransFees { get; }
        public string InvalidInputOtherFees { get; }
        public string InvalidInputExitDate { get; }

        public IValidator<DealDataRaw> GetValidators()
        {
        
            return new InlineValidator<DealDataRaw>();
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