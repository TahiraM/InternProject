using System;
using System.Collections.Generic;
using System.Text;

namespace Stage3_Verification
{
    class ValidationOfStrings
    {
        public static int thisInt(string value)
        {
            int num;
            bool check = Int32.TryParse(value, out num);
            if (check == false)
            {
                num = 0;
                return num;
            }
            else
            {
                return num;
            }

        }

        public static double thisDouble(string value)
        {
            double num;
            bool check = Double.TryParse(value, out num);
            if (check == false)
            {
                num = 0;
                return num;
            }
            else
            {
                return num;
            }

        }
    }
}
