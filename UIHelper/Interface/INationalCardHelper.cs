using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper
{
    public interface INationalCardHelper
    {
        bool IsValid(string NationalID);

        string GetStandardNationalID(string NationalID);
    }
}
