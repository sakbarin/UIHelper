using System;
using System.Collections.Generic;

using System.Text;
using System.Globalization;

namespace Helper
{
    public class UIHelper
    {
        private static IPasswordHelper _myPassword;
        public static IPasswordHelper myPassword
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

        private static IDateHelper _myDate;
        public static IDateHelper myDate
        {
            get
            {
                if (_myDate == null)
                    _myDate = new DateHelper(UIHelper.myNumber);

                return _myDate;
            }
        }

        private static IPersonnelHelper _myPersonnel;
        public static IPersonnelHelper myPersonnel
        {
            get
            {
                if (_myPersonnel == null)
                    _myPersonnel = new PersonnelHelper();

                return _myPersonnel;
            }
        }

        private static IFileHelper _myFile;
        public static IFileHelper myFile
        {
            get
            {
                if (_myFile == null)
                    _myFile = new FileHelper(UIHelper.myNumber, UIHelper.myDate);

                return _myFile;
            }
        }

        private static IIPHelper _myIP;
        public static IIPHelper myIP
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