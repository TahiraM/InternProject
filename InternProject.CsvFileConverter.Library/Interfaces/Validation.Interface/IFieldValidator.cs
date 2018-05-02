using System;
using InternProject.CsvFileConverter.Library.Validations;

namespace InternProject.CsvFileConverter.Library.Interfaces.Validation.Interface
{
    public interface IFieldValidator
    {
        Type TypeToValidate { get; }

        FieldValidationResult Validate(string fieldValue);
    }
}