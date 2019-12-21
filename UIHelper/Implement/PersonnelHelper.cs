using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helper.DataAdapter.dsPersonelTableAdapters;
using Helper.DataAdapter;
using System.Collections;
using Helper.DataAdapter.dsStaffTableAdapters;

namespace Helper
{
    public class PersonnelHelper : IPersonnelHelper
    {
        public string GetStandardEmployeeNo(string EmployeeNo)
        {
            try
            {
                string employeeNo = "00000000" + EmployeeNo;
                employeeNo = employeeNo.Substring(employeeNo.Length - 8);
                return employeeNo;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public Staff SearchStaff(string EmployeeNo)
        {
            try
            {
                StaffInformationTableAdapter adapter = new StaffInformationTableAdapter();
                dsStaff.StaffInformationDataTable staffs = adapter.GetData(EmployeeNo);

                if (staffs.Rows.Count > 0)
                {

                    dsStaff.StaffInformationRow staff = (dsStaff.StaffInformationRow)staffs[0];

                    return new Staff()
                    {
                        EmployeeNo = staff.PNo,
                        FirstName = staff.FirstName,
                        LastName = staff.LastName,
                        NationalId = staff.NationalID,
                        BirthDate = staff.BirthDate,
                        Grade = staff.Grade
                    };

                }
                else
                {
                    return null;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public Staff SearchPersonel(string EmployeeNo)
        {
            try
            {
                DirContEmpTableAdapter adpGharardadi = new DirContEmpTableAdapter();
                dsPersonel.DirContEmpDataTable tblGharardadi = adpGharardadi.GetData(decimal.Parse("0" + EmployeeNo));

                if (tblGharardadi.Rows.Count > 0)
                {

                    return new Staff()
                    {
                        EmployeeNo = EmployeeNo,
                        FirstName = tblGharardadi.Rows[0]["FirstName"].ToString(),
                        LastName = tblGharardadi.Rows[0]["LastName"].ToString(),
                        NationalId = tblGharardadi.Rows[0]["NationalId"].ToString()
                    };

                }
                else
                {

                    MCCS_PerExtraInfoTableAdapter adpPeimankar = new MCCS_PerExtraInfoTableAdapter();
                    dsPersonel.MCCS_PerExtraInfoDataTable tblPeimankar = adpPeimankar.GetData(EmployeeNo);

                    if (tblPeimankar.Rows.Count > 0)
                    {

                        return new Staff()
                        {
                            EmployeeNo = EmployeeNo,
                            FirstName = tblPeimankar.Rows[0]["FirstName"].ToString(),
                            LastName = tblPeimankar.Rows[0]["LastName"].ToString(),
                            NationalId = tblPeimankar.Rows[0]["NationalId"].ToString()
                        };

                    }
                    else
                    {

                        IoocEmpTableAdapter adpRasmi = new IoocEmpTableAdapter();
                        dsPersonel.IoocEmpDataTable tblRasmi = adpRasmi.GetData(decimal.Parse("0" + EmployeeNo));

                        if (tblRasmi.Rows.Count > 0)
                        {

                            return new Staff()
                            {
                                EmployeeNo = EmployeeNo,
                                FirstName = tblRasmi.Rows[0]["FirstName"].ToString(),
                                LastName = tblRasmi.Rows[0]["LastName"].ToString(),
                                NationalId = tblRasmi.Rows[0]["NationalId"].ToString()
                            };

                        }

                    }

                }

                return null;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
