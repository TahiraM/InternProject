using System;
using System.Globalization;
using InternProject.CsvFileConverter.Library.Interfaces.Validation.Interface;

namespace InternProject.CsvFileConverter.Library.Validations
{
    public class DateFieldValidator : IFieldValidator
    {
        public Type TypeToValidate => typeof(DateTime);

        public FieldValidationResult Validate(string fieldValue)
        {
            if (fieldValue == string.Empty)
                return new FieldValidationResult("value is empty");

            var culture = CultureInfo.CreateSpecificCulture("en-GB");

            return DateTime.TryParse(fieldValue, culture, DateTimeStyles.AssumeUniversal, out var dataTime)
                ? new FieldValidationResult(dataTime)
                : new FieldValidationResult("The value Being Validated is not in date Format");
        }
    }
}