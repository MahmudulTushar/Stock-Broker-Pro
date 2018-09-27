using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.Constants
{
    public class Indication_TransactioBasedCharge
    {
        public static string BankClearing = "BACH Charge";
        public static string CheckBounce = "Cheque Bounce";
        public static string EftClearing = "BEFTN Charge";
        public static string IPOApp = "IPOApp Charge";
        public static string IPONRBApp = "NRB IPOApp Charge";
        public static string IPOAppRefund = "IPOApp Charge Refund";
        public static string IPONRBAppRefund = "NRB IPOApp Charge Refund";
        
        public static string Charge_Rate="ChargeRate";
        public static string Charge_Amount="ChargeAmount";

        public static string GroupEntry_ChargedAccount_TransReason = "Trn_Charged_Account";

        public static string DepositCompanyAccount = "99";
        

        public static List<KeyValuePair<string, string>> TransReasonList = new List<KeyValuePair<string, string>>() 
        { 
            new KeyValuePair<string, string>(BankClearing, "Cheque_Clearing_Charge")            
            , new KeyValuePair<string, string>(CheckBounce, "Cheque_Bounce_Charge")
            , new KeyValuePair<string, string>(EftClearing, "EFT_Clearing_Charge")
            , new KeyValuePair<string,string>(IPOApp,"IPO_Application_Charge")
            , new KeyValuePair<string,string>(IPOAppRefund,"IPO_ApplicationRefund_Charge")
            , new KeyValuePair<string,string>(IPONRBApp,"NRB_IPO_Application_Charge")
            ,new KeyValuePair<string,string>(IPONRBAppRefund,"NRB_IPO_ApplicationRefund_Charge")
        };

        public static List<KeyValuePair<string, string>> VoucherSLnoList = new List<KeyValuePair<string, string>>() 
        { 
            new KeyValuePair<string, string>(BankClearing, "BACH-C")
            , new KeyValuePair<string, string>(CheckBounce, "BACH-CBC")
            , new KeyValuePair<string, string>(EftClearing, "BACH-C") 
            , new KeyValuePair<string,string>(IPOApp,"IPOSC")
            , new KeyValuePair<string,string>(IPOAppRefund,"IPOWC")
             , new KeyValuePair<string,string>(IPONRBApp,"IPOSC")
             , new KeyValuePair<string,string>(IPONRBAppRefund,"IPOWC")
        };
            

        public static List<KeyValuePair<string, string>> ChargeTypeList = new List<KeyValuePair<string, string>>() 
        { 
            new KeyValuePair<string, string>(BankClearing, Charge_Amount)
            , new KeyValuePair<string, string>(CheckBounce, Charge_Amount)
            , new KeyValuePair<string, string>(EftClearing, Charge_Amount) 
            , new KeyValuePair<string,string>(IPOApp,Charge_Amount)};

        public static NameValueCollection ExceptionString = new NameValueCollection() 
        {
            {BankClearing, "THE CITY BANK LTD."}            
        };        
    }
}
