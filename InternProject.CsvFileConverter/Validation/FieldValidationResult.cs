using System.Diagnostics.CodeAnalysis;

namespace CsvFileConverter
{
    [ExcludeFromCodeCoverage]
    public class FieldValidationResult
    {
        public object Value { get; }
        public string ErrorMessage { get; }

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

        public bool HasError => !string.IsNullOrWhiteSpace(ErrorMessage);
    }
}