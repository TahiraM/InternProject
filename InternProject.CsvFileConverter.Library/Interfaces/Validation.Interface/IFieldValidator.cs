using System;

namespace InternProject.CsvFileConverter.Library
{
    public interface IFieldValidator
    {
        Type TypeToValidate { get; }

        FieldValidationResult Validate(string fieldValue);
    }
}