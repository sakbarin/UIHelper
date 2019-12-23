using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper
{
    public class NationalCardHelper : INationalCardHelper
    {
        private string NationalId;

        public int this[int index]
        {
            get
            {
                if (index > 10 || index < 1)
                    throw new Exception("Index is out of range.");

                return int.Parse(NationalId[10 - index].ToString());
            }
        }

        public bool IsValid(string NationalId)
        {
            try
            {
                this.NationalId = NationalId.Trim();

                long NId;
                if (long.TryParse(NationalId, out NId) == false)
                    return false;


                if (NationalId.Length != 10)
                    return false;


                int sum = 0;
                for (int i = 2; i <= 10; i++)
                {
                    sum += (i * this[i]);

                    // 2 | 3 | 0 | 0 | 2 | 3 | 8 | 2 | 1 | 7 = NationalId
                    // 10| 9 | 8 | 7 | 6 | 5 | 4 | 3 | 2 | 1 = NationalId Index Order
                    // 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 = C# Index Order
                }


                int div = sum % 11;


                if (div < 2)
                    return (this[1] == div);
                else
                    return (this[1] == (11 - div));
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
                return false;
            }
        }

        public string GetStandardNationalID(string NationalID)
        {
            try
            {
                NationalId = "0000000000" + NationalID.Trim();
                NationalId = NationalId.Substring(NationalId.Length - 10);

                return NationalId;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}