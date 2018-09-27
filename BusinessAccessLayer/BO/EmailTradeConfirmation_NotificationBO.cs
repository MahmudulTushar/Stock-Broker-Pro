using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
   public class EmailTradeConfirmation_NotificationBO
   {
       private string _cust_Code;

       public string Cust_Code
       {
           get { return _cust_Code; }
           set { _cust_Code = value; }
       }
       private string _cust_Name;

       public string Cust_Name
       {
           get { return _cust_Name; }
           set { _cust_Name = value; }
       }
       private DateTime _trade_Date;

       public DateTime Trade_Date
       {
           get { return _trade_Date; }
           set { _trade_Date = value; }
       }
       private double _interest;

       public double Interest
       {
           get { return _interest; }
           set { _interest = value; }
       }
       private string _comp_Short_Code;

       public string Comp_Short_Code
       {
           get { return _comp_Short_Code; }
           set { _comp_Short_Code = value; }
       }
       private double _buy_Qty;

       public double Buy_Qty
       {
           get { return _buy_Qty; }
           set { _buy_Qty = value; }
       }
       private double _buy_Avg;

       public double Buy_Avg
       {
           get { return _buy_Avg; }
           set { _buy_Avg = value; }
       }
       private double _buy_Total;

       public double Buy_Total
       {
           get { return _buy_Total; }
           set { _buy_Total = value; }
       }
       private double _sell_Qty;

       public double Sell_Qty
       {
           get { return _sell_Qty; }
           set { _sell_Qty = value; }
       }
       private double _sell_Avg;

       public double Sell_Avg
       {
           get { return _sell_Avg; }
           set { _sell_Avg = value; }
       }
       private double _sell_Total;

       public double Sell_Total
       {
           get { return _sell_Total; }
           set { _sell_Total = value; }
       }
       private double _balance;

       public double Balance
       {
           get { return _balance; }
           set { _balance = value; }
       }
       private double _amount;

       public double Amount
       {
           get { return _amount; }
           set { _amount = value; }
       }
       private double _commission;

       public double Commission
       {
           get { return _commission; }
           set { _commission = value; }
       }
       private double _pre_Balance;

       public double Pre_Balance
       {
           get { return _pre_Balance; }
           set { _pre_Balance = value; }
       }
       private double _totalOnBuyTotal;

       public double TotalOnBuyTotal
       {
           get { return _totalOnBuyTotal; }
           set { _totalOnBuyTotal = value; }
       }
       private double _totalOnSellToal;

       public double TotalOnSellToal
       {
           get { return _totalOnSellToal; }
           set { _totalOnSellToal = value; }
       }
       private double _totalOnBalance;

       public double TotalOnBalance
       {
           get { return _totalOnBalance; }
           set { _totalOnBalance = value; }
       }
       private double _totalOnCommission;

       public double TotalOnCommission
       {
           get { return _totalOnCommission; }
           set { _totalOnCommission = value; }
       }

       private double _totalOnPayable;

       public double TotalOnPayable
       {
           get { return _totalOnPayable; }
           set { _totalOnPayable = value; }
       }

       private double _currentBalance;

       public double CurrentBalance
       {
           get { return _currentBalance; }
           set { _currentBalance = value; }
       }

       private double _totalOnAmount;

       public double TotalOnAmount
       {
           get { return _totalOnAmount; }
           set { _totalOnAmount = value; }
       }


       public EmailTradeConfirmation_NotificationBO()
       {
           _cust_Code = string.Empty;
           _cust_Name = string.Empty;
           _interest = 0.00;
           _comp_Short_Code = string.Empty;
           _buy_Qty = 0.00;
           _buy_Avg = 0.00;
           _buy_Total = 0.00;
           _sell_Qty = 0.00;
           _sell_Avg = 0.00;
           _sell_Total = 0.00;
           _balance = 0.00;
           _amount = 0.00;
           _commission = 0.00;
           _pre_Balance = 0.00;
           _totalOnSellToal = 0.00;
           _totalOnBuyTotal = 0.00;
           _totalOnBalance = 0.00;
           _totalOnCommission = 0.00;
           _totalOnPayable = 0.00;
           _currentBalance = 0.00;
           _totalOnAmount = 0.00;
       }

   }
}
