using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Net;

namespace Helper
{
    public class IPHelper : IIPHelper
    {
        private string InterNetwork
        {
            get
            {
                return "InterNetwork";
            }
        }

        public string GetIP4Address()
        {
            string IP4Address = string.Empty;

            foreach (IPAddress IpAdress in Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
            {
                if (IpAdress.AddressFamily.ToString() == InterNetwork)
                {
                    IP4Address = IpAdress.ToString();
                    break;
                }
            }

            if (IP4Address != string.Empty)
            {
                return IP4Address;
            }


            foreach (IPAddress IpAddress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IpAddress.AddressFamily.ToString() == InterNetwork)
                {
                    IP4Address = IpAddress.ToString();
                    break;
                }
            }

            return IP4Address;
        }
    }
}