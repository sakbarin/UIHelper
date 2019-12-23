using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;

namespace Helper
{
    public class FileHelper : IFileHelper
    {
        private INumberHelper numberHelper;
        private IDateHelper dateHelper;

        public FileHelper(INumberHelper numberHelper, IDateHelper dateHelper)
        {
            this.numberHelper = numberHelper;
            this.dateHelper = dateHelper;
        }

        public string GenerateTimeBasedFileName(string FileName)
        {
            try
            {
                var calendar = new PersianCalendar();

                string year = numberHelper.GetTwoDigitNumber(dateHelper.GetCurrentYear(2));
                string month = numberHelper.GetTwoDigitNumber(calendar.GetMonth(DateTime.Now));
                string day = numberHelper.GetTwoDigitNumber(calendar.GetDayOfMonth(DateTime.Now));
                string hour = numberHelper.GetTwoDigitNumber(DateTime.Now.Hour);
                string minute = numberHelper.GetTwoDigitNumber(DateTime.Now.Minute);
                string second = numberHelper.GetTwoDigitNumber(DateTime.Now.Second);

                return string.Format("{0}{1}{2}_{3}{4}{5}_{6}", year, month, day, hour, minute, second, FileName.ToString());
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public string GenerateGuidBasedFileName(string FileName)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(FileName);
                return string.Format("{0}{1}", Guid.NewGuid().ToString(), fileInfo.Extension);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
