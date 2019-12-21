using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper
{
    public interface IPasswordHelper
    {
        string HashPassword(string Password);
    }
}
