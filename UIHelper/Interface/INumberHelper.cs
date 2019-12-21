using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper
{
    public interface INumberHelper
    {
        string GetTwoDigitNumber(int Number);

        string GetNDigitNumber(int Number, int Digits);
    }
}
