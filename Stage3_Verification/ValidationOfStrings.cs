namespace Stage3_Verification
{
    class ValidationOfStrings
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
    }
}
