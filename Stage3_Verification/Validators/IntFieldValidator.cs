using System;

namespace CsvFileConverter
{
    public class IntFieldValidator : IFieldValidator
    {
        public Type TypeToValidate => typeof(int);

        public FieldValidationResult Validate(string fieldValue)
        {
            if (fieldValue == string.Empty)
                return new FieldValidationResult(null, "value is empty");

            var check = int.TryParse(fieldValue, out var number);
            return check 
                ? new FieldValidationResult(number) 
                : new FieldValidationResult(null, "The value Being Validated is not in Int Format");
        }
    }
}