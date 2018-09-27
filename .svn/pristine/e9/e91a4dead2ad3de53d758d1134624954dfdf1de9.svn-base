using System;
using System.Collections.Generic;
using System.Linq;


namespace ElectronicCommunication.SMS
{
    static class LevenshteinDistance
    {

        private struct Segregation_Key
        {
            public string Key;
            public string Value;
        };

        private static List<Segregation_Key> Segregation_KeyList = new List<Segregation_Key>();
        /// <summary>
        /// Compute the distance between two strings.
        /// </summary>
        private static void Init_SMS_Segregation_KeyList()
        {
            Segregation_KeyList.Add(new Segregation_Key(){Key=SMSCommadCode.IPORequest, Value="pipo"});
            Segregation_KeyList.Add(new Segregation_Key() { Key = SMSCommadCode.IPORequest, Value = "pmipo" });
            Segregation_KeyList.Add(new Segregation_Key() { Key = SMSCommadCode.IPORequest, Value = "pmtrade" });
            Segregation_KeyList.Add(new Segregation_Key() { Key = SMSCommadCode.IPORequest, Value = "ptrade" });
            Segregation_KeyList.Add(new Segregation_Key() { Key = SMSCommadCode.IPORequest, Value = "ripo" });
            Segregation_KeyList.Add(new Segregation_Key() { Key = SMSCommadCode.IPORequest, Value = "rtrade" });
            Segregation_KeyList.Add(new Segregation_Key() { Key = SMSCommadCode.IPORequest, Value = "reft" });
            Segregation_KeyList.Add(new Segregation_Key() { Key = SMSCommadCode.IPORequest, Value = "rmipo" });
            Segregation_KeyList.Add(new Segregation_Key() { Key = SMSCommadCode.IPORequest, Value = "rmtrade" });
        }
        
        
        public static int Compute_Difference(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }

        public static int Compute_Matching(string individual, string target)
        {
            int sum = 0;
            if (target != string.Empty && individual != string.Empty)
            {
                for (int i = 0; i < individual.Length; i++)
                    if (individual[i] == target[i]) sum++;
            }
            return sum;
        }

        public static int GetNoOfMissMatchCode(string value)
        {
            int result = 0;
            
            string noMatchString = SMSCommadCode.IPODefault_Code;

            string[] valueTemp = value.Split('-');
            foreach (string eachValue in valueTemp)
                if (eachValue == noMatchString)
                    result++;
                    
            return result;
        }

        public static int Get_KeyCount(string value, string key)
        {
            int result=0;
            
            Init_SMS_Segregation_KeyList();

            int CountKey = 0;
            foreach (Segregation_Key obj in Segregation_KeyList.Where(t=> t.Key==key).ToList())
            {
                if (value.Contains(obj.Value))
                {
                    CountKey++;
                }
            }
            result = CountKey;

            return result;
        }

    }

}