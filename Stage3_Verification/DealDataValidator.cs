using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using Serilog;

namespace CsvFileConverter
{
    public interface IFieldValidator
    {
        Type TypeToValidate { get; }

        FieldValidationResult Validate(string fieldValue);
    }

    public class StringFieldValidator : IFieldValidator
    {
        public Type TypeToValidate => typeof(string);

        public FieldValidationResult Validate(string fieldValue)
        {
            return new FieldValidationResult(fieldValue);
        }
    }
    
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

    public class DoubleFieldValidator : IFieldValidator
    {
        public Type TypeToValidate => typeof(double);

        public FieldValidationResult Validate(string fieldValue)
        {
            if (fieldValue == string.Empty)
                return new FieldValidationResult(null, "value is empty");

            var check = double.TryParse(fieldValue, out var number);
            return check 
                ? new FieldValidationResult(number) 
                : new FieldValidationResult(null, "The value Being Validated is not in Double Format");
        }
    }

    public class DateFieldValidator : IFieldValidator
    {
        public Type TypeToValidate => typeof(DateTime);

        public FieldValidationResult Validate(string fieldValue)
        {
            if (fieldValue == string.Empty)
                return new FieldValidationResult(null, "value is empty");
            try
            {
                var dateParts = fieldValue.Split('/');

                var testDate = new DateTime(Convert.ToInt32(dateParts[2]),
                    Convert.ToInt32(dateParts[0]),
                    Convert.ToInt32(dateParts[1]));
                var uk = new CultureInfo("en-UK");
                var date = testDate.ToString("d", uk);

                return new FieldValidationResult(date);
            }
            catch (IndexOutOfRangeException ex)
            {
                return new FieldValidationResult(null, "The value Being Validated is not in date Format");
            }
        }
    }

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
            ErrorMessage = string.Empty;
        }

        public bool HasError => !string.IsNullOrWhiteSpace(ErrorMessage);
    }
}