using System;
using InternProject.CsvFileConverter.Library.Interfaces.Validation.Interface;

namespace InternProject.CsvFileConverter.Library.Validations
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