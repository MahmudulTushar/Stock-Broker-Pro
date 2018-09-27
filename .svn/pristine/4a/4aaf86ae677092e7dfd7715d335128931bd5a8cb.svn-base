using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StockbrokerProNewArch.Classes
{
    public class Logger
    {
        private static string LogFileName = "C:\\Log.txt";
        private static StreamWriter sr;
              

        private static void CreateLog()
        {
            sr = new StreamWriter(LogFileName);
        }

        public static void ErrorLog(string tag,string value)
        {
            sr.WriteLine(tag + "|" + value);
        }

        public static void ErrorLog(string value)
        {
            sr.WriteLine(value);
        }

        public void WarningLog()
        {
        
        }

        public void InfoLog()
        {
        
        }

      

    }
}


