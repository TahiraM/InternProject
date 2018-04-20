using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CsvHelper.Configuration;
using FluentValidation;
using NHibernate.Mapping;
using Serilog;

namespace CsvFileConverter
{
    public class DealDataRawValidator : AbstractValidator<DealDataRaw>
    {
        private readonly Dictionary<Type, IFieldValidator> _validators;

        public DealDataRawValidator(IEnumerable<IFieldValidator> validators)
        {
            _validators = validators?.ToDictionary(m => m.TypeToValidate) ??
                          throw new ArgumentNullException(nameof(validators));
           
            RuleFor(x => x.SectorId).Must(Validate<int>).WithMessage("This value is not an int ");
            RuleFor(x => x.CountryId).Must(Validate<int>).WithMessage("This value is not an int "); ;
            RuleFor(x => x.TransactionTypeId).Must(Validate<int>).WithMessage("This value is not an int "); ;
            RuleFor(x => x.TransactionFees).Must(Validate<double>).WithMessage("This value is not an double "); ;
            RuleFor(x => x.OtherFees).Must(Validate<double>).WithMessage("This value is not an double "); ;
            RuleFor(x => x.ExitDate).Must(Validate<DateTime>).WithMessage("This value is not an DateTime "); ;
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