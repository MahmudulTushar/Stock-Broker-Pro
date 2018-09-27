using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.Constants
{
    public static class Indication_PaymentTransaction
    {
        public static string Return_Indicator = "Return";
        public static string Cancel_Indicatior = "Cancel";

        public static string Ecash = "Ecash";
        public static string Cash="Cash";
        public static string Cash_Return = Cash + Return_Indicator;
        public static string Cheque = "Check";
        public static string Cheque_Return = Cheque + Return_Indicator;
        public static string EFT = "EFT";
        public static string EFT_Return = EFT + Return_Indicator;
        public static string EFT_Cancel = EFT + Cancel_Indicatior;
        public static string Pay_Order = "Payorder";
        public static string Pay_Order_Return = Pay_Order + Return_Indicator;
        public static string Pay_Pal = "Paypal";
        public static string Pay_Pal_Return = Pay_Pal + Return_Indicator;
        public static string TR = "TR";
        public static string TRIPO = "TRIPO";
        public static string ReqType_EftIssue_TradeAccount = "TRADE";
        public static string ReqType_EftIssue_IPOAccount = "IPO";
        
    }
}
