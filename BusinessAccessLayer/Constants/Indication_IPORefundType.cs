using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.Constants
{
    public static class Indication_IPORefundType
    {
        public static string Refund_TRTA = "TRTA";
        public static string Refund_TRTA_Desc = "Trade Account";
        public static string Refund_TRIPO = "TRIPO";
        public static string Refund_TRIPO_Desc = "IPO Account";
        public static string Refund_EFT = "EFT";
        public static string Refund_EFT_Desc = "EFT (Electronic Fund Transfer)";
        public static string Refund_MMT = "MMT";
        public static string Refund_MMT_Desc = "Mobile Money Transfer";
        public static string Refund_TRPR = "TRPR";
        public static string Refund_TRPR_Desc = "Parent Tarade Account(All)";
        public static string Refund_TRPRIPO = "TRPRIPO";
        public static string Refund_TRPRIPO_Desc = "Parent IPO Account (All)";

        
        public static int Refund_TRTA_ID = 1;
        public static int Refund_TRIPO_ID =2;
        public static int Refund_TRPR_ID = 4;
        public static int Refund_EFT_ID = 3;
        public static int Refund_TRPRIPO_ID = 5;
        

    }
   
}
