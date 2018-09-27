using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.Constants
{
    public class Indication_Fixed_VoucherNo_TransReason
    {
        private static string BORenewal_VoucherNo = "BAC";
        public static string BORenewal_DepositWithdraw = "Withdraw";
        public static string BO_Open = "BO Open";
        public static string RenewalBO = "Renewal BO";
        public static string OCC_VoucherNo = "OCC-C";
        public static string TransferIPO_Purpose = "TransferIPO";
        public static string BO_DUE_TransReason = "BAC_DUE";
        public static string GetBORenewal_VoucherNo(DateTime dt)
        {
            string final_VoucherNo;
            string ChargedYear = string.Empty;
            if (dt.Month > 6)
                ChargedYear = dt.AddYears(1).Year.ToString();
            else
                ChargedYear = dt.Year.ToString();

            final_VoucherNo = BORenewal_VoucherNo + ChargedYear;
            return final_VoucherNo;
        }
        public static string GetBORenewal_TransReason(DateTime dt)
        {
            string transReason;
            string ChargedYear = string.Empty;
            if (dt.Month > 6)
                ChargedYear = dt.AddYears(1).Year.ToString();
            else
                ChargedYear = dt.Year.ToString();

            transReason = BORenewal_VoucherNo + "-" + ChargedYear;
            return transReason;
        }

        public static string GetOCC_VoucherNo()
        {
            string VoucherNo;
            VoucherNo = "OCC-C";
            return VoucherNo;
        }
    }
}
