using System.Diagnostics.CodeAnalysis;

namespace InternProject.CsvFileConverter.Library.Validations
{
    [ExcludeFromCodeCoverage]
    public class FieldValidationResult
    {
        public FieldValidationResult(object value, string errorMessage)
        {
            Value = value;
            ErrorMessage = errorMessage;
        }

        public FieldValidationResult(object value)
        {
            Value = value;
            //ErrorMessage = string.Empty;
        }

        public object Value { get; }
        public string ErrorMessage { get; }

        public bool HasError => !string.IsNullOrWhiteSpace(ErrorMessage);
    }
}