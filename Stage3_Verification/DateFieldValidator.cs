using System;
using System.Globalization;

namespace CsvFileConverter
{
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
}