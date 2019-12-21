using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper
{
    public interface IPersonnelHelper
    {
        string GetStandardEmployeeNo(string EmployeeNo);

        Staff SearchStaff(string EmployeeNo);

        Staff SearchPersonel(string EmployeeNo);
    }
}