using System;
using System.Data;
using System.Globalization;
using Serilog;

namespace CsvFileConverter
{
    public class ValidationOfDealData
    {
        public static int ThisInt(string value)
        {
            if (value == string.Empty) return 0;
            var check = int.TryParse(value, out var num);

            if (check != false) return num;
            Log.Fatal("The Value Being Validated is not in Integer Format");
            throw new FormatException("The Value Being Validated is not in Integer Format");
        }

        public static double ThisDouble(string value)
        {
            if (value == string.Empty) return 0;
            var check = double.TryParse(value, out var num);

            if (check != false) return num;
            Log.Fatal("The Value Being Validated is not in Double Format");
            throw new FormatException("The Value Being Validated is not in Double Format");
        }

        public static string ThisDate(string value)
        {
            try
            {
                var dateParts = value.Split('/');

                var testDate = new DateTime(Convert.ToInt32(dateParts[2]),
                    Convert.ToInt32(dateParts[0]),
                    Convert.ToInt32(dateParts[1]));
                var uk = new CultureInfo("en-UK");
                var validDate = testDate.ToString("d", uk);

                return validDate;
            }
            catch (Exception ex)
            {
                if (value == string.Empty) return " ";
                Log.Error(ex, "The String Being Validated is not in Date Format");
                throw new DataException("The String Being Validated is not in Date Format");
            }
        }
    }
}