using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper
{
    public class NumberHelper : INumberHelper
    {
        public string GetTwoDigitNumber(int Number)
        {
            try
            {
                if (Number < 0 || Number > 99)
                {
                    throw new Exception("Number Out of Range. Number should be between 0 and 99.");
                }

                string number = "00" + Number.ToString();
                return number.Substring(number.Length - 2);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public string GetNDigitNumber(int Number, int Digits)
        {
            try
            {
                if (Number < 0)
                {
                    throw new Exception("Number Out of Range. Number should be between 0 and 99.");
                }

                string number = "";

                for (int i = 0; i < Digits; i++)
                    number = number + "0";

                number = number + Number.ToString();
                return number.Substring(number.Length - Digits);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
