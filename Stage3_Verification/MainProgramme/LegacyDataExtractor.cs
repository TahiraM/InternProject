using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CsvFileConverter
{
    public class LegacyDataExtractor : ILegacyDataExtractor
    {
        private readonly Type[] _dealFileMapper =
        {
            typeof(string),
            typeof(string),
            typeof(string),
            typeof(string),
            typeof(string),
            typeof(int),
            typeof(string),
            typeof(int),
            typeof(string),
            typeof(int),
            typeof(string),
            typeof(double),
            typeof(double),
            typeof(string),
            typeof(string),
            typeof(DateTime)
        };

        private readonly Dictionary<Type, IFieldValidator> _validators;

       

        public LegacyDataExtractor(IEnumerable<IFieldValidator> validators)
        {
            _validators = validators?.ToDictionary(m => m.TypeToValidate) ??
                          throw new ArgumentNullException(nameof(validators));
        }

        

        public DealData[] Extract(string[] rows, bool hasTitleRow = true)
        {
            var result = rows
                .Skip(hasTitleRow == false ? 0 : 1)
                .Select(row =>
                {
                    var validationResults = row.Split("||").Select((m, i) =>
                    {
                        var type = _dealFileMapper[i];
                        var validator = _validators[type];
                        var validationResult = validator.Validate(m);

                        return validationResult;
                    }).ToList();

                    return new {Results = validationResults, HasError = validationResults.Any(m => m.HasError)};
                }).ToList();

            if (result.Any(r => r.HasError))
            {
                // Log
                Log.Logger.Error(new Exception(), "Error when Extracting data from CSV file");
            }

            var finalResults = result.Select(data => new DealData
            {
                V3DealId = data.Results[0].Value.ToString(),
                EFrontDealId = data.Results[1].Value.ToString(),
                DealName = data.Results[2].Value.ToString(),
                V3CompanyId = data.Results[3].Value.ToString(),
                V3CompanyName = data.Results[4].Value.ToString(),
                SectorId = (int) data.Results[5].Value,
                Sector = data.Results[6].Value.ToString(),
                CountryId = (int) data.Results[7].Value,
                Country = data.Results[8].Value.ToString(),
                TransactionTypeId = (int) data.Results[9].Value,
                TransactionType = data.Results[10].Value.ToString(),
                TransactionFees = (double) data.Results[11].Value,
                OtherFees = (double) data.Results[12].Value,
                Currency = data.Results[13].Value.ToString(),
                ActiveInActive = data.Results[14].Value.ToString(),
                ExitDate = data.Results[15].Value.ToString()
            }).ToArray();

            return finalResults;
        }
    }
}