using System;

namespace InternProject.CsvFileConverter.Library
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