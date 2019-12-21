using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper
{
    public class Staff
    {
        public Staff()
        {
            this.employeeNo = "";
            this.firstName = "";
            this.lastName = "";
            this.birthDate = "";
            this.nationalId = "";
            this.grade = "";
        }

        private string employeeNo;
        public string EmployeeNo
        {
            get
            {
                return employeeNo.Trim();
            }
            internal set
            {
                employeeNo = value;
            }
        }

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName.Trim();
            }
            internal set
            {
                firstName = value;
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName.Trim();
            }
            internal set
            {
                lastName = value;
            }
        }

        private string nationalId;
        public string NationalId
        {
            get
            {
                nationalId = "0000000000" + nationalId.Trim();
                return nationalId.Substring(nationalId.Length - 10);
            }
            internal set
            {
                nationalId = value;
            }
        }

        private string birthDate;
        public string BirthDate
        {
            get
            {
                return UIHelper.myDate.GetStandardShamsiDate(birthDate);
            }
            internal set
            {
                birthDate = "13" + value.Trim();
                birthDate = birthDate.Substring(0, 4) + "/" + birthDate.Substring(4, 2) + "/" + birthDate.Substring(6, 2);
            }
        }

        private string grade;
        public string Grade
        {
            get
            {
                return grade;
            }
            internal set
            {
                if (value == null || value.Trim() == "")
                    grade = "-";
                else
                    grade = value;
            }
        }
    }
}
