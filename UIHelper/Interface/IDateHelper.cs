using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper
{
    public interface IDateHelper
    {
        DateTime ConvertShamsiToGregDate(string ShamsiDate);

        string ConvertGregToShamsiDate(DateTime GregDate);

        string GetStandardGregDate(DateTime GregDate);

        string GetStandardShamsiDate(string ShamsiDate);

        string GetTodayPersianDate();

        int GetCurrentYear(int Digits);

        int GetCurrentMonth();

        int GetCurrentDay();

        string GetMonthName(int MonthIndex);

        string GetDayName(string ShamsiDate);

        string GetCurrentTime();

        string GetStandardTime(DateTime GregDateTime);

        string GetTodayFullText();
    }
}
