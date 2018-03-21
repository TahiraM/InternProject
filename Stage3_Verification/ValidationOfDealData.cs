using System;
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

            if (check == false)
                throw new FormatException("Data not in correct format");
            return num;
        }

        public static double ThisDouble(string value)
        {
            if (value == string.Empty) return 0;
            var check = double.TryParse(value, out var num);

            if (check == false)
                Log.Fatal( "The 25"); 
            return num;
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
            catch
            {
                if (value == string.Empty) return " ";


                throw new FormatException("Date not in correct format");
            }
        }
    }
}