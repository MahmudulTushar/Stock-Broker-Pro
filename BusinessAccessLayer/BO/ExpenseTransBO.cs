using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public class ExpenseTransBO
    {
        private int _expense_ID;
        private string _expense_Name;
        private int _category_ID;

        private int _sub_catagory_ID;

        private string _category_Name;
        private DateTime _expense_Date;
        private DateTime _payment_Date;
        private double _amount;
        private int _quantity;
        private int _voucherId;
        private string _voucher_No;
        private int _purchaser_Emp_ID;
        private string _entry_By;
        private DateTime _entry_Date;
        private int _approval_Status;
        private string _approved_By;
        private string _remarks;
        private int _branch_ID;
        private DateTime? _approved_Date;
        private byte[] _voucherImage;

        private string _Payment_Media;
        private string _Pay_Bank_Name;
        private string _Bank_Account_No;
        private string _Pay_Cheque_No;

        private double _Rate;

        public ExpenseTransBO()
        {
            _expense_ID = 0;
            _expense_Name = string.Empty;
            _category_ID = 0;

            _sub_catagory_ID = 0;

            _category_Name = string.Empty;
            _expense_Date = DateTime.MinValue;
            _payment_Date = DateTime.MinValue;
            _amount = 0;
            _quantity = 0;
            _voucher_ID = 0;
            _voucher_No = string.Empty;
            _purchaser_Emp_ID = 0;
            _entry_By = string.Empty;
            _entry_Date = DateTime.MinValue;
            _approval_Status = 0;
            _remarks = string.Empty;
            _branch_ID = 0;
            _approved_By = string.Empty;
            _approved_Date = null;
            _voucherImage=new byte[0];

            _Payment_Media=string.Empty;
            _Pay_Bank_Name=string.Empty;
            _Bank_Account_No=string.Empty;
            _Pay_Cheque_No = string.Empty;

            _Rate = 0.00;
        }

        public int Expense_ID
        {
            get { return _expense_ID; }
            set { _expense_ID = value; }
        }

        public string Expense_Name
        {
            get { return _expense_Name; }
            set { _expense_Name = value; }
        }

        public int Category_ID
        {
            get { return _category_ID; }
            set { _category_ID = value; }
        }

        public int sub_catagory_ID
        {
            get { return _sub_catagory_ID; }
            set { _sub_catagory_ID = value; }
        }


        public string Category_Name
        {
            get { return _category_Name; }
            set { _category_Name = value; }
        }

        public DateTime Expense_Date
        {
            get { return _expense_Date; }
            set { _expense_Date = value; }
        }

        public DateTime Payment_Date
        {
            get { return _payment_Date; }
            set { _payment_Date = value; }
        }

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public int Qquantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public int _voucher_ID
        {
            get { return _voucherId; }
            set { _voucherId = value; }
        }
        public string Voucher_No
        {
            get { return _voucher_No; }
            set { _voucher_No = value; }
        }
        
        public int Purchaser_Emp_ID
        {
            get { return _purchaser_Emp_ID; }
            set { _purchaser_Emp_ID = value; }
        }

        public string Entry_By
        {
            get { return _entry_By; }
            set { _entry_By = value; }
        }

        public DateTime Entry_Date
        {
            get { return _entry_Date; }
            set { _entry_Date = value; }
        }

        public int Approval_Status
        {
            get { return _approval_Status; }
            set { _approval_Status = value; }
        }

        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        public int Branch_ID
        {
            get { return _branch_ID; }
            set { _branch_ID = value; }
        }

        public string Approved_By
        {
            get { return _approved_By; }
            set { _approved_By = value; }
        }

        public DateTime? Approved_Date
        {
            get { return _approved_Date; }
            set { _approved_Date = value; }
        }

        public byte[] Voucher_Image
        {
            get { return _voucherImage; }
            set { _voucherImage = value; }
        }

        public string Payment_Media
        {
            get { return _Payment_Media; }
            set { _Payment_Media = value; }
        }

        public string Pay_Bank_Name
        {
            get { return _Pay_Bank_Name; }
            set { _Pay_Bank_Name = value; }
        }

        public string Bank_Account_No
        {
            get { return _Bank_Account_No; }
            set { _Bank_Account_No = value; }
        }

        public string Pay_Cheque_No
        {
            get { return _Pay_Cheque_No; }
            set { _Pay_Cheque_No = value; }
        }

        public double Rate
        {
            get { return _Rate; }
            set { _Rate = value; }
        }
    }
}
