using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper
{
    public interface IFileHelper
    {
        string GenerateTimeBasedFileName(string FileName);

        string GenerateGuidBasedFileName(string FileName);
    }
}