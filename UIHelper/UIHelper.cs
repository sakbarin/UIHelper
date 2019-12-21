using System;
using System.Collections.Generic;

using System.Text;
using System.Globalization;

namespace Helper
{
    public class UIHelper
    {
        private static PasswordHelper _myPassword;
        public static PasswordHelper myPassword
        {
            get
            {
                if (_myPassword == null)
                    _myPassword = new PasswordHelper();

                return _myPassword;
            }
        }

        private static INationalCardHelper _myNationalCard;
        public static INationalCardHelper myNationalCard
        {
            get
            {
                if (_myNationalCard == null)
                    _myNationalCard = new NationalCardHelper();

                return _myNationalCard;
            }
        }

        private static INumberHelper _myNumber;
        public static INumberHelper myNumber
        {
            get
            {
                if (_myNumber == null)
                    _myNumber = new NumberHelper();

                return _myNumber;
            }
        }

        private static DateHelper _myDate;
        public static DateHelper myDate
        {
            get
            {
                if (_myDate == null)
                {
                    var numberHelper = new NumberHelper();
                    _myDate = new DateHelper(numberHelper);
                }

                return _myDate;
            }
        }

        private static PersonnelHelper _myPersonnel;
        public static PersonnelHelper myPersonnel
        {
            get
            {
                if (_myPersonnel == null)
                    _myPersonnel = new PersonnelHelper();

                return _myPersonnel;
            }
        }

        private static FileHelper _myFile;
        public static FileHelper myFile
        {
            get
            {
                if (_myFile == null)
                {
                    var numberHelper = new NumberHelper();
                    var dateHelper = new DateHelper(numberHelper);
                    _myFile = new FileHelper(numberHelper, dateHelper);
                }

                return _myFile;
            }
        }

        private static IPHelper _myIP;
        public static IPHelper myIP
        {
            get
            {
                if (_myIP == null)
                    _myIP = new IPHelper();

                return _myIP;
            }
        }
    }
}