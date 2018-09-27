using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicCommunication.SMS
{
    public class SMSCommadCode
    {
        public static string IPORequest = "105-106-107-108-109";       
        public static string IPOCompanyFound = "107";
        public static string IPOCustomerFound = "106";
        public static string IPOPaymentType = "108";
        public static string IPORefundType = "109";
        public static string IPORegCust_Code = "105";
        public static string IPODefault_Code = "***";

        public static string IPOInformation = "505-506";
        public static string IPOInfoRegCustCOde = "505";
        public static string IPOInfoCode = "506";



        public static string BuyOrderForMarketPrice ="205-206-207-208-209";
        public static string CompanyShortCode = "206";
        public static string ShareQuentity = "207";
        public static string BuyOrder = "208";
        public static string MarketPrice = "209";
        public static string RegCust_Code = "205";
        public static string DefaultCode = "***";


        public static string SM_ShareSummery = "303-304";
        public static string SM_RegCustCode = "303";
        public static string SM_ShortCode = "304";
        public static string SM_DefaultCode = "***";


        public static string Formate = "707-708";
        public static string Format_RegCustCode = "707";
        public static string Format_FullMessage = "708";



        public static string Deposite_Withdraw = "901-902-903-904-905";
        public static string Deposite_Withdraw_RegCustCode = "901";
        public static string Deposite_Withdraw_Found = "902";
        public static string Deposite_Withdraw_Trade_Ipo="903";
        public static string Deposite_Withdraw_Amount = "904";
        public static string Deposite_Withdraw_CustCode = "905";
        public static string Deposite_Withdraw_Default = "***";

        public static int S = 0;
        public static int K = 0;
        public static void SMSCount()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t\t\t" + "Receive : " + K + " " + "Send  : " + SMSCommadCode.S);
        }
        

    }
}
