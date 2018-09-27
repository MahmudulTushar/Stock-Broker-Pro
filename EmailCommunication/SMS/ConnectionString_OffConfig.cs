using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicCommunication.SMS
{
    public class ConnectionString_OffConfig
    {
        private static string _callCenter_ConnectionString = @"Data Source=120.130.1.2;Initial Catalog=dbksclCallCenter;User ID=sa;Password=123,Connection Timeout=600;";

        public static string CallCenter_ConnectionString
        {
            get { return _callCenter_ConnectionString; }
            set { _callCenter_ConnectionString = value; }
        }
    //@"Data Source=150.1.122.2;Initial Catalog=dbksclCallCenter;User ID=ksclmst;Password=kscl@d122;Connection Timeout=600;";

       // @"Data Source=.;Initial Catalog=dbksclCallCenter;Integrated Security=True;Connection Timeout=600;";
    }
}
