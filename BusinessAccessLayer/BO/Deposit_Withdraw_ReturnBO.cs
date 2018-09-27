﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public static class Deposit_Withdraw_ReturnBO
    {
        private static string _pid;

        public static string Pid
        {
            get { return Deposit_Withdraw_ReturnBO._pid; }
            set { Deposit_Withdraw_ReturnBO._pid = value; }
        }
        private static string _code;

        public static string Code
        {
            get { return Deposit_Withdraw_ReturnBO._code; }
            set { Deposit_Withdraw_ReturnBO._code = value; }
        }
        private static double _amount;

        public static double Amount
        {
            get { return Deposit_Withdraw_ReturnBO._amount; }
            set { Deposit_Withdraw_ReturnBO._amount = value; }
        }
        private static DateTime _recdate;

        public static DateTime Recdate
        {
            get { return Deposit_Withdraw_ReturnBO._recdate; }
            set { Deposit_Withdraw_ReturnBO._recdate = value; }
        }
        private static string _p_Media;

        public static string P_Media
        {
            get { return Deposit_Withdraw_ReturnBO._p_Media; }
            set { Deposit_Withdraw_ReturnBO._p_Media = value; }
        }

        private static string _p_MediaNo;

        public static string P_MediaNo
        {
            get { return Deposit_Withdraw_ReturnBO._p_MediaNo; }
            set { Deposit_Withdraw_ReturnBO._p_MediaNo = value; }
        }

        private static DateTime _p_Mediadate;

        public static DateTime P_Mediadate
        {
            get { return Deposit_Withdraw_ReturnBO._p_Mediadate; }
            set { Deposit_Withdraw_ReturnBO._p_Mediadate = value; }
        }
        private static string _bank_Code;

        public static string Bank_Code
        {
            get { return Deposit_Withdraw_ReturnBO._bank_Code; }
            set { Deposit_Withdraw_ReturnBO._bank_Code = value; }
        }
        private static int _bank_ID;

        public static int Bank_ID
        {
            get { return _bank_ID; }
            set { _bank_ID = value; }
        }
        private static string _bank_Name;

        public static string Bank_Name
        {
            get { return Deposit_Withdraw_ReturnBO._bank_Name; }
            set { Deposit_Withdraw_ReturnBO._bank_Name = value; }
        }
        private static int _branch_ID;

        public static int Branch_ID
        {
            get { return _branch_ID; }
            set { _branch_ID = value; }
        }
        private static string _branch_Code;

        public static string Branch_Code
        {
            get { return Deposit_Withdraw_ReturnBO._branch_Code; }
            set { Deposit_Withdraw_ReturnBO._branch_Code = value; }
        }
        private static string _bank_Branch;

        public static string Bank_Branch
        {
            get { return Deposit_Withdraw_ReturnBO._bank_Branch; }
            set { Deposit_Withdraw_ReturnBO._bank_Branch = value; }
        }
        private static string _routingNo;

        public static string RoutingNo
        {
            get { return Deposit_Withdraw_ReturnBO._routingNo; }
            set { Deposit_Withdraw_ReturnBO._routingNo = value; }
        }
        private static string _bankAccNo;

        public static string BankAccNo
        {
            get { return Deposit_Withdraw_ReturnBO._bankAccNo; }
            set { Deposit_Withdraw_ReturnBO._bankAccNo = value; }
        }
        private static string _received_By;

        public static string Received_By
        {
            get { return Deposit_Withdraw_ReturnBO._received_By; }
            set { Deposit_Withdraw_ReturnBO._received_By = value; }
        }
        private static string _dW;

        public static string DW
        {
            get { return Deposit_Withdraw_ReturnBO._dW; }
            set { Deposit_Withdraw_ReturnBO._dW = value; }
        }
        private static string _approved_By;

        public static string Approved_By
        {
            get { return Deposit_Withdraw_ReturnBO._approved_By; }
            set { Deposit_Withdraw_ReturnBO._approved_By = value; }
        }
        private static DateTime _appv_Date;

        public static DateTime Appv_Date
        {
            get { return Deposit_Withdraw_ReturnBO._appv_Date; }
            set { Deposit_Withdraw_ReturnBO._appv_Date = value; }
        }
        private static string _voucher;

        public static string Voucher
        {
            get { return Deposit_Withdraw_ReturnBO._voucher; }
            set { Deposit_Withdraw_ReturnBO._voucher = value; }
        }
        private static string _transReason;

        public static string TransReason
        {
            get { return Deposit_Withdraw_ReturnBO._transReason; }
            set { Deposit_Withdraw_ReturnBO._transReason = value; }
        }



        
        
    }
}