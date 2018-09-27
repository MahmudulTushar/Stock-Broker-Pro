using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BusinessAccessLayer.Constants
{
    public class Validation
    {
        public static double Payment_MinimumBalanceHave_InWithdraw_ForActive= 500;
        public static double Payment_MinimumBalanceHave_InWithdraw_ForColsed = 0;

        /// <summary>
        /// Email Address validation By passing Email address
        /// Added By Md.Rashedul Hasan On 30 August 2015
        /// </summary>
        /// <param name="inputEmail"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        /// <summary>
        /// 11 Digit Phone no Checking
        /// Added by Md.Rashedul Hasan on 30 August 2015
        /// </summary>
        /// <param name="strPhoneNumber"></param>
        /// <returns></returns>
        public static bool IsValidPhonNumber(string strPhoneNumber)
        {
            string MatchPhoneNumberPattern = @"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            if (strPhoneNumber != null) return Regex.IsMatch(strPhoneNumber, MatchPhoneNumberPattern);
            else return false;
        }
    }
}
