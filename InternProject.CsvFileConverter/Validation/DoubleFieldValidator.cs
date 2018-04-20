using System;
using System.Diagnostics.CodeAnalysis;

namespace CsvFileConverter
{
    [ExcludeFromCodeCoverage]
    public class DoubleFieldValidator : IFieldValidator
    {
        public Type TypeToValidate => typeof(double);

        public FieldValidationResult Validate(string fieldValue)
        {
            if (fieldValue == string.Empty)
                return new FieldValidationResult( "value is empty");

            var check = double.TryParse(fieldValue, out var number);
            return check 
                ? new FieldValidationResult(number) 
                : new FieldValidationResult( "The value Being Validated is not in Double Format");
        }
    }
}