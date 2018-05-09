using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CsvHelper.Configuration;
using InternProject.CsvFileConverter.Library.Interfaces.Validation.Interface;
using Serilog;

namespace InternProject.CsvFileConverter.Library.Extensions.Mapping
{
    [ExcludeFromCodeCoverage]
    public class DealDataMap : ClassMap<DealData>
    {
        private readonly Dictionary<Type, IFieldValidator> _validators;

        public DealDataMap(IEnumerable<IFieldValidator> validators)
        {
            _validators = validators?.ToDictionary(m => m.TypeToValidate) ??
                          throw new ArgumentNullException(nameof(validators));

            AutoMap();

            Map(m => m.ExitDate).Validate(Validate<DateTime>);
            Map(m => m.OtherFees).Validate(Validate<double>);
            Map(m => m.TransactionFees).Validate(Validate<double>);
            Map(m => m.CountryId).Validate(Validate<int>);
            Map(m => m.SectorId).Validate(Validate<int>);
            Map(m => m.TransactionTypeId).Validate(Validate<int>);
        }

        private bool Validate<T>(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            var type = typeof(T);

            if (!_validators.ContainsKey(type))
                throw new Exception($"Validator is not available for {type.Name}");

            var validator = _validators[type];
            var validationResult = validator.Validate(value);

            if (validationResult.HasError != true) return !validationResult.HasError;
            Log.Logger.Error("validation error");
            throw new SyntaxErrorException("file has validation issues");
        }
    }
}