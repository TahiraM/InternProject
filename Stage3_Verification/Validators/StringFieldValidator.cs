using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Serilog;

namespace CsvFileConverter
{
    public class StringFieldValidator : IFieldValidator
    {
        public Type TypeToValidate => typeof(string);

        public FieldValidationResult Validate(string fieldValue)
        {
            return new FieldValidationResult(fieldValue);
        }
    }
}