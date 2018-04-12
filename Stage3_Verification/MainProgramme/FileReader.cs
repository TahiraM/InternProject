using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using FluentValidation;
using Serilog;

namespace CsvFileConverter.MainProgramme
{
    public class FileReader : IFileReader
    {
        public StringReader ReadContent(string input)
        {
            if (!File.Exists(input))
            {
                var exception = new FileNotFoundException($"File {input} is not exists");
                Log.Error(exception, $"File {input} is not exists");
                throw exception;
            }

            Log.Information("Input file recieved {Input}", input);
            var extension = Path.GetExtension(input);
            if (extension != ".csv")
            {
                var exception = new FileLoadException($"File{input} not in correct format");
                Log.Error(exception, $"File{input} not in correct format");
                throw exception;
            }

            var content = File.ReadAllText(input);
            Log.Information("it works while program runs fileReader");

            var reader = new StringReader(content);

            return reader;
        }
    }

    public class FileDataValidator : AbstractValidator<DealDataString>
    {
        private readonly Dictionary<Type, IFieldValidator> _validators;
        public FileDataValidator(IEnumerable<IFieldValidator> validators)
        {
            _validators = validators?.ToDictionary(m => m.TypeToValidate) ??
                          throw new ArgumentNullException(nameof(validators));

            RuleFor(x => x.SectorId).Must(Validate<int>).WithMessage("Invalid Data in Sector ID Entered");
            RuleFor(x => x.CountryId).Must(Validate<int>).WithMessage("Invalid Data in Country ID Entered");
            RuleFor(x => x.TransactionTypeId).Must(Validate<int>).WithMessage("Invalid Data in Transaction Type ID Entered");
            RuleFor(x => x.TransactionFees).Must(Validate<double>).WithMessage("Invalid Data in Transaction Fees Entered");
            RuleFor(x => x.OtherFees).Must(Validate<double>).WithMessage("Invalid Data in Other Fees Entered");
            RuleFor(x => x.ExitDate).Must(Validate<DateTime>).WithMessage("Invalid Data in Date Time Entered");

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