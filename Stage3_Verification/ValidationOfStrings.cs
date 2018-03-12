using System;

namespace Stage3_Verification
{
    public class ValidationOfStrings
    {
        public static int ThisInt(string value)
        {
            var check = int.TryParse(value, out var num);
            return check ? num : 0;
        }

        public static double ThisDouble(string value)
        {
            var check = double.TryParse(value, out var num);
            return check ? num : 0;
        }

        public static string ThisDate(string value)
        {
            try
            {
                var dateParts = value.Split('/');

                var testDate = new DateTime(Convert.ToInt32(dateParts[2]),
                    Convert.ToInt32(dateParts[0]),
                    Convert.ToInt32(dateParts[1]));
                var validDate = testDate.ToString("d");

                return validDate;
            }
            catch
            {
                throw new FormatException("Date not in correct format");
            }
        }
    }
}