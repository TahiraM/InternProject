using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Serilog;

namespace CsvFileConverter
{
    [ExcludeFromCodeCoverage]
    public class StringFieldValidator : IFieldValidator
    {
        public Type TypeToValidate => typeof(string);

        public FieldValidationResult Validate(string fieldValue)
        {
            return new FieldValidationResult(fieldValue);
        }
    }
}