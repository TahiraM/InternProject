using System;

namespace CsvFileConverter
{
    public interface IFieldValidator
    {
        Type TypeToValidate { get; }

        FieldValidationResult Validate(string fieldValue);
    }
}