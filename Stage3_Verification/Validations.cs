using System;

namespace Stage3_Verification
{
    public class Validations
    {
        public static string Error(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Value cannot be null or empty.", nameof(value));
            return "";
        }

        public static string String_Validator(string value)
        {
            var answer = value + " {type:string}";
            return answer;
        }

        public static string IntegerType()
        {
            return " {type:int}";
        }

        public static int? Integer_Validator(string variable)
        {
            if (variable == "") return 0;

            int? i = Convert.ToInt32(variable);
            return i;
        }

        public static string DoubleType()
        {
            return " {type:double}";
        }

        public static double? Double_Validation(string amount)
        {
            if (amount == "")
            {
                return 0;
            }

            double? p = Convert.ToDouble(amount);
            return p;
        }
    }
}