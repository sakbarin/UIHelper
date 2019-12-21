using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Helper
{
    public class DateHelper : IDateHelper
    {
        private INumberHelper numberHelper;

        public DateHelper(INumberHelper numberHelper)
        {
            this.numberHelper = numberHelper;
        }

        public DateTime ConvertShamsiToGregDate(string ShamsiDate)
        {
            try
            {
                string shamsiDate = this.GetStandardShamsiDate(ShamsiDate);

                string year = shamsiDate.Substring(0, 4);
                string month = shamsiDate.Substring(5, 2);
                string day = shamsiDate.Substring(8, 2);
                
                var persianCalendar = new PersianCalendar();
                DateTime gregDate = persianCalendar.ToDateTime(int.Parse(year), int.Parse(month), int.Parse(day), 0, 0, 0, 0);

                return gregDate;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public string ConvertGregToShamsiDate(DateTime GregDate)
        {
            try
            {
                var persianCalendar = new PersianCalendar();

                string year = persianCalendar.GetYear(GregDate).ToString();
                string month = numberHelper.GetTwoDigitNumber(persianCalendar.GetMonth(GregDate));
                string day = numberHelper.GetTwoDigitNumber(persianCalendar.GetDayOfMonth(GregDate));

                return string.Format("{0}/{1}/{2}", year, month, day);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public string GetStandardGregDate(DateTime GregDate)
        {
            try
            {
                string year = GregDate.Year.ToString();
                string month = numberHelper.GetTwoDigitNumber(GregDate.Month);
                string day = numberHelper.GetTwoDigitNumber(GregDate.Day);

                return string.Format("{0}/{1}/{2}", year, month, day);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public string GetStandardShamsiDate(string ShamsiDate)
        {
            try
            {
                if (ShamsiDate == null || ShamsiDate == "")
                    return "";

                string[] dateParts = ShamsiDate.Split('/');

                string year = dateParts[0];
                string month = numberHelper.GetTwoDigitNumber(int.Parse(dateParts[1]));
                string day = numberHelper.GetTwoDigitNumber(int.Parse(dateParts[2]));

                return string.Format("{0}/{1}/{2}", year, month, day);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public string GetTodayPersianDate()
        {
            try
            {
                var persianCalendar = new PersianCalendar();

                string year = persianCalendar.GetYear(DateTime.Now).ToString();
                string month = persianCalendar.GetMonth(DateTime.Now).ToString();
                string day = persianCalendar.GetDayOfMonth(DateTime.Now).ToString();

                return this.GetStandardShamsiDate(string.Format("{0}/{1}/{2}", year, month, day));
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public int GetCurrentYear(int Digits)
        {
            try
            {
                if (Digits > 4 || Digits < 2)
                {
                    throw new Exception("Digits Out of Range. Digits should be in [2, 3, 4].");
                }

                var persianCalendar = new PersianCalendar();
                int currentYear = persianCalendar.GetYear(DateTime.Now);
                int simpleCurrentYear = int.Parse(currentYear.ToString().Substring(4 - Digits, Digits));

                return simpleCurrentYear;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public int GetCurrentMonth()
        {
            try
            {
                var persianCalendar = new PersianCalendar();
                return persianCalendar.GetMonth(DateTime.Now);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public int GetCurrentDay()
        {
            try
            {
                var persianCalendar = new PersianCalendar();
                return persianCalendar.GetDayOfMonth(DateTime.Now);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public string GetMonthName(int MonthIndex)
        {
            try
            {
                if (MonthIndex > 12 || MonthIndex < 1)
                {
                    throw new Exception("MonthIndex Out of Range. MonthIndex should be between 1 and 12.");
                }

                string[] monthNames = { "", "فروردين", "ارديبهشت", "خرداد", "تير", "مرداد", "شهريور", "مهر", "آبان", "آذر", "دي", "بهمن", "اسفند" };
                return monthNames[MonthIndex];
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public string GetDayName(string ShamsiDate)
        {
            try
            {
                DateTime gregDate = this.ConvertShamsiToGregDate(ShamsiDate);
                
                var persianCalendar = new PersianCalendar();
                DayOfWeek dayOfWeek = persianCalendar.GetDayOfWeek(gregDate);

                string[] dayNames = { "يكشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنج شنبه", "جمعه", "شنبه" };
                return dayNames[(int)dayOfWeek];
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public string GetCurrentTime()
        {
            try
            {
                return this.GetStandardTime(DateTime.Now);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public string GetStandardTime(DateTime GregDateTime)
        {
            try
            {
                string hour = numberHelper.GetTwoDigitNumber(GregDateTime.Hour);
                string minute = numberHelper.GetTwoDigitNumber(GregDateTime.Minute);

                return string.Format("{0}:{1}", hour, minute);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public string GetTodayFullText()
        {
            try
            {
                int year = this.GetCurrentYear(4);
                int month = this.GetCurrentMonth();
                int day = this.GetCurrentDay();

                string dayName = this.GetDayName(this.GetTodayPersianDate());

                string fullText = "امروز " + dayName + "، " + day + " " + this.GetMonthName(month) + " " + year;
                return fullText;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}