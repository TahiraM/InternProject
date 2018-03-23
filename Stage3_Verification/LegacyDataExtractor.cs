using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace CsvFileConverter
{
    public class LegacyDataExtractor : ILegacyDataExtractor
    {
        private readonly Dictionary<Type, IFieldValidator> _validators;

        private readonly Type[] _dealFileMapper = {
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

        public LegacyDataExtractor(IEnumerable<IFieldValidator> validators)
        {
            _validators = validators?.ToDictionary(m => m.TypeToValidate) ?? throw new ArgumentNullException(nameof(validators));
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

                    return new {HasError = validationResults.Any(m => m.HasError), Results = validationResults};
                }).ToList();

            if (result.Any(r => r.HasError))
            {
               // Log
                throw new Exception();
            }
            else
            {
                var finalResults = result.Select(data => new DealData
                    {
                        V3DealId = data.Results[0].Value.ToString(),
                        EFrontDealId = data.Results[0].Value.ToString(),
                        DealName = data.Results[0].Value.ToString(),
                        V3CompanyId = data.Results[0].Value.ToString(),
                        V3CompanyName = data.Results[0].Value.ToString(),
                        SectorId = (int)data.Results[0].Value,
                        Sector = data.Results[0].Value.ToString(),
                        CountryId = (int)data.Results[0].Value,
                        Country = data.Results[0].Value.ToString(),
                        TransactionTypeId = (int)data.Results[0].Value,
                        TransactionType = data.Results[0].Value.ToString(),
                        TransactionFees = (double)data.Results[0].Value,
                        OtherFees = (double)data.Results[0].Value,
                        Currency = data.Results[0].Value.ToString(),
                        ActiveInActive = data.Results[0].Value.ToString(),
                        ExitDate = (string)data.Results[0].Value
                }).ToArray();

                return finalResults;
            }
        }
    }
}