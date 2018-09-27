using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using DataAccessLayer;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
   public class Web_Data_ReconcilationBAL
    {
       public WebDataExportBAL obj = new WebDataExportBAL();
       private DataTable Non_Valide_WEB = new DataTable();
       private DataTable DataTable_All_Reconcilation_Result = new DataTable();
       private DataTable DataTable_All_Reconcilation_Result_Share_Balance = new DataTable();
       public DataTable NonValide_Share_balance_Web = new DataTable();
       public DataTable NonValide_Share_balance_Local = new DataTable();
       public DataTable Money_balance_Local = new DataTable();
       public DataTable Money_balance_Web = new DataTable();
       public DataTable Company_Profile_Local = new DataTable();
       public DataTable Company_Profile_Web = new DataTable();
       public DataTable Share_DW_Local = new DataTable();
       public DataTable Share_DW_Web = new DataTable();
       public DataTable payment_History_Local = new DataTable();
       public DataTable Payment_history_Web = new DataTable();
       public DataTable Share_Balance_Details_Local = new DataTable();
       public DataTable Share_Balance_Details_Web = new DataTable();
       public DataTable Share_Balance_Local = new DataTable();
       public DataTable Share_Balance_Web = new DataTable();
    
        private DbConnection _dbConnection;
        MySqlConnection Webconnection;
        MySqlTransaction WebTransaction;

        string mySqlConnection = //"DRIVER={MySQL ODBC 3.51 Driver};" +

        //New Pattern
            //@"Server=prelude.websitewelcome.com;" +
            //"Port=3306;" +
            //"Database=ksclbdco_ks;" +
            //"User Id=ksclbdco;" +
            //"Password=16Dec08;" +
            //"Allow Zero Datetime=false;" +
            //"Convert Zero Datetime=true;";

//              @"server= 213.171.200.85;
//            userid=ksclbdco_dbuser;
//            Database=ksclbdco_ks;
//            password=K$clbd12345;
//            database=ksclbdco_ks;";
            @"server= 148.72.232.146;
            userid=ksclbdco;
            Database=ksclbdco_ks;
            password=KoNcvt%hi2Upvj;
            database=ksclbdco_ks;";

         //"Server =localhost;Database=ksclbdco_ks;User Id=root;Password=123;";


        public Web_Data_ReconcilationBAL()
        {
            _dbConnection = new DbConnection();
            Webconnection = new MySqlConnection(mySqlConnection);
            WebTransaction = null;
        }

        public void Connect_SBP()
        {
            _dbConnection.ConnectDatabase();
            _dbConnection.StartTransaction();
        }

        public void Connect_Web()
        {
            Webconnection.Open();
            WebTransaction = Webconnection.BeginTransaction();
        }

        public void Connect_WithoutTransaction_SBP()
        {
            _dbConnection.ConnectDatabase();
            // _dbConnection.StartTransaction();
        }

        public void CloseConnection_SBP()
        {
            _dbConnection.ConnectDatabase();
        }

        public void CloseConnection_Web()
        {
            Webconnection.Close();
            WebTransaction = null;
        }


        public void Commit_SBP()
        {
            _dbConnection.Commit();

        }
        public void Commit_Web()
        {
            WebTransaction.Commit();
        }

        public void Rollback_SBP()
        {
            _dbConnection.Rollback();

        }
        public void Rollback_Web()
        {
            WebTransaction.Rollback();
        }

        public void Connect_SMS()
        {
            _dbConnection.ConnectDatabase_SMSSender();
            _dbConnection.StartTransaction_SMSSender();
        }

        public void Connect_WithoutTransaction_SMS()
        {
            _dbConnection.ConnectDatabase_SMSSender();
            //_dbConnection.StartTransaction_SMSSender();
        }

        public void CloseConnection_SMS()
        {
            _dbConnection.CloseDatabase_SMSSender();
        }

        public void Commit_SMS()
        {
            _dbConnection.Commit_SMSSender();
        }

        public void Rollback_SMS()
        {
            _dbConnection.Rollback_SMSSender();
        }

        public SqlConnection GetConnection()
        {
            return _dbConnection.GetConnection();
        }

        public void SetConnection(SqlConnection con)
        {
            _dbConnection.SetConnection(con);
        }

        public SqlConnection GetConnection_SMS()
        {
            return _dbConnection.GetConnection_SMSSender();
        }

        public void SetConnection_SMS(SqlConnection con)
        {
            _dbConnection.SetConnection_SMSSender(con);
        }

        public SqlTransaction GetTransaction()
        {
            return _dbConnection.GetTransaction();
        }

        public void SetTransaction(SqlTransaction trans)
        {
            _dbConnection.SetTransaction(trans);
        }

        public SqlTransaction GetTransaction_SMS()
        {
            return _dbConnection.GetTransaction_SMSSender();
        }

        public void SetTransaction_SMS(SqlTransaction trans)
        {
            _dbConnection.SetTransaction_SMSSender(trans);
        }


        #region Trade_Balance
        public void Trade_Money_Balance()
        {
            DataTable dt_Web = new DataTable();
            DataTable dt_local = new DataTable();
            try
            {
                obj.Connect_Web();
                obj.Connect_SBP();
                dt_Web = Data_Trade_Money_Balance_Web();
                dt_local = Get_MoneyBalance();
                CompareRows(dt_local, dt_Web);
                New_CompareRows_Money_Balance(dt_local, dt_Web);
                obj.Commit_Web();
                obj.Commit_SBP();

            }
            catch (Exception ex)
            {
                obj.Rollback_SBP();
                obj.Rollback_Web();
            }
            finally
            {
                obj.CloseConnection_SBP();
                obj.CloseConnection_Web();
            }

       }

        public DataTable Get_Not_Valide_Money_Balance_for_Web()
        {
            DataTable dt = new DataTable();
            dt = Non_Valide_WEB;
            return dt;
        }

        public DataTable Get_All_Reconcilation_Result()
        {
            DataTable dt = new DataTable();
            dt = DataTable_All_Reconcilation_Result_Share_Balance;
            return dt;
        }

        #region
        //public void New_CompareRows_Money_Balance(DataTable Local, DataTable Web)
        //{
        //    int k = 0;
        //    //DataTable_All_Reconcilation_Result.Columns.Add("TableName", typeof(string));
        //    //DataTable_All_Reconcilation_Result.Columns.Add("Description", typeof(string));
        //    //DataTable_All_Reconcilation_Result.Columns.Add("True_False", typeof(string));

        //    List<double> Local_Balance = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Balance"].ToString())).ToList();
        //    Double Balance_Local = Math.Round(Convert.ToDouble(Local_Balance.Sum()),0);
        //    List<double> Web_Balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["balance"].ToString())).ToList();
        //    Double Balance_Web = Math.Round(Web_Balance.Sum(), 0);

        //    //List<double> Local_Deposit = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Deposit"].ToString())).ToList();
        //    //Double Deposit_Local = Math.Round(Convert.ToDouble(Local_Deposit.Sum()), 0);
        //    //List<double> Web_Deposit = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["deposit"].ToString())).ToList();
        //    //Double Deposit_Web = Math.Round(Web_Deposit.Sum(), 0);

        //    //List<double> Local_Withdraw = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Withdraw"].ToString())).ToList();
        //    //Double Withdraw_Local = Math.Round(Convert.ToDouble(Local_Withdraw.Sum()), 0);
        //    //List<double> Web_Withdraw = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["withdraw"].ToString())).ToList();
        //    //Double Withdraw_Web = Math.Round(Web_Withdraw.Sum(), 0);

        //    List<double> Local_matured_balance = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["matured_balance"].ToString())).ToList();
        //    Double matured_balance_Local = Math.Round(Convert.ToDouble(Local_matured_balance.Sum()), 0);
        //    List<double> Web_matured_balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["matured_balance"].ToString())).ToList();
        //    Double matured_balance_Web = Math.Round(Web_matured_balance.Sum(), 0);

        //    //List<double> Local_total_gain_loss = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["GainLoss"].ToString())).ToList();
        //    //Double total_gain_loss_Local = Math.Round(Convert.ToDouble(Local_total_gain_loss.Sum()), 0);
        //    //List<double> Web_total_gain_loss = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["total_gain_loss"].ToString())).ToList();
        //    //Double total_gain_loss_Web = Math.Round(Web_total_gain_loss.Sum(), 0);

        //    //List<double> Local_market_value = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["market_value"].ToString())).ToList();
        //    //Double market_value_Local = Math.Round(Convert.ToDouble(Local_market_value.Sum()), 0);
        //    //List<double> Web_market_value = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["market_value"].ToString())).ToList();
        //    //Double market_value_Web = Math.Round(Web_market_value.Sum(), 0);

        //    if (Local.Rows.Count == Web.Rows.Count)
        //    {
        //        k++;
        //    }
        //    if (Balance_Local == Balance_Web)
        //    {
        //        k++;
        //    }
        //    //if (Deposit_Local == Deposit_Web)
        //    //{
        //    //    k++;
        //    //}
        //    //if (Withdraw_Local == Withdraw_Web)
        //    //{
        //    //    k++;
        //    //}
        //    if (matured_balance_Local == matured_balance_Web)
        //    {
        //        k++;
        //    }
        //    //if (total_gain_loss_Local == total_gain_loss_Web)
        //    //{
        //    //    k++;
        //    //}
        //    //if (market_value_Web == market_value_Local)
        //    //{
        //    //    k++;
        //    //}
        //    if (k == 3)
        //    {
        //        DataTable_All_Reconcilation_Result_Share_Balance.Rows.Add("Money Balance", "Ok", "True", Local.Rows.Count.ToString(), Web.Rows.Count.ToString(), Convert.ToString(Balance_Local),Convert.ToString(Balance_Web));
        //    }
        //    else
        //    {
        //        DataTable_All_Reconcilation_Result.Rows.Add("Money Balance", "Not Ok", "False", Local.Rows.Count.ToString(), Web.Rows.Count.ToString(), Convert.ToString(Balance_Local), Convert.ToString(Balance_Web));
        //    }



        //}
        #endregion

        public void New_CompareRows_Money_Balance(DataTable Local, DataTable Web)
        {
            int k = 0;

            if (k == 0 && DataTable_All_Reconcilation_Result_Share_Balance.Rows.Count == 0)
            {
                LoadDataTable();
            }

            List<double> Local_Balance = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Balance"].ToString())).ToList();
            Double Balance_Local = Math.Round(Convert.ToDouble(Local_Balance.Sum()), 0);
            List<double> Web_Balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["balance"].ToString())).ToList();
            Double Balance_Web = Math.Round(Web_Balance.Sum(), 0);

            //List<double> Local_Deposit = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Deposit"].ToString())).ToList();
            //Double Deposit_Local = Math.Round(Convert.ToDouble(Local_Deposit.Sum()), 0);
            //List<double> Web_Deposit = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["deposit"].ToString())).ToList();
            //Double Deposit_Web = Math.Round(Web_Deposit.Sum(), 0);

            //List<double> Local_Withdraw = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Withdraw"].ToString())).ToList();
            //Double Withdraw_Local = Math.Round(Convert.ToDouble(Local_Withdraw.Sum()), 0);
            //List<double> Web_Withdraw = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["withdraw"].ToString())).ToList();
            //Double Withdraw_Web = Math.Round(Web_Withdraw.Sum(), 0);

            List<double> Local_matured_balance = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["matured_balance"].ToString())).ToList();
            Double matured_balance_Local = Math.Round(Convert.ToDouble(Local_matured_balance.Sum()), 0);
            List<double> Web_matured_balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["matured_balance"].ToString())).ToList();
            Double matured_balance_Web = Math.Round(Web_matured_balance.Sum(), 0);

            //List<double> Local_total_gain_loss = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["GainLoss"].ToString())).ToList();
            //Double total_gain_loss_Local = Math.Round(Convert.ToDouble(Local_total_gain_loss.Sum()), 0);
            //List<double> Web_total_gain_loss = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["total_gain_loss"].ToString())).ToList();
            //Double total_gain_loss_Web = Math.Round(Web_total_gain_loss.Sum(), 0);

            //List<double> Local_market_value = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["market_value"].ToString())).ToList();
            //Double market_value_Local = Math.Round(Convert.ToDouble(Local_market_value.Sum()), 0);
            //List<double> Web_market_value = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["market_value"].ToString())).ToList();
            //Double market_value_Web = Math.Round(Web_market_value.Sum(), 0);

            if (Local.Rows.Count == Web.Rows.Count)
            {
                k++;
            }
            if (Balance_Local == Balance_Web)
            {
                k++;
            }
            //if (Deposit_Local == Deposit_Web)
            //{
            //    k++;
            //}
            //if (Withdraw_Local == Withdraw_Web)
            //{
            //    k++;
            //}
            if (matured_balance_Local == matured_balance_Web)
            {
                k++;
            }
            //if (total_gain_loss_Local == total_gain_loss_Web)
            //{
            //    k++;
            //}
            //if (market_value_Web == market_value_Local)
            //{
            //    k++;
            //}

            DataTable_All_Reconcilation_Result.Columns.Add("TableName", typeof(string));
            DataTable_All_Reconcilation_Result.Columns.Add("Description", typeof(string));
            DataTable_All_Reconcilation_Result.Columns.Add("True_False", typeof(string));
            DataTable_All_Reconcilation_Result.Columns.Add("Local_Row_Count", typeof(string));
            DataTable_All_Reconcilation_Result.Columns.Add("Web_Row_Count", typeof(string));
            DataTable_All_Reconcilation_Result.Columns.Add("Balance_Local", typeof(string));
            DataTable_All_Reconcilation_Result.Columns.Add("Balance_Web", typeof(string));

            if (k == 3)
            {
                DataTable_All_Reconcilation_Result_Share_Balance.Rows.Add("Money Balance", "Ok", "True", Local.Rows.Count.ToString(), Web.Rows.Count.ToString(), Convert.ToString(Balance_Local), Convert.ToString(Balance_Web));
            }
            else
            {
                try
                {
                    DataTable_All_Reconcilation_Result.Rows.Add("Money Balance", "Not Ok", "False", Local.Rows.Count.ToString(), Web.Rows.Count.ToString(), Balance_Local, Balance_Web);
                }
                catch (Exception ex)
                { }
            }



        }


        #region
        public DataTable Get_Money_Balance_Local()
        {
            DataTable dt = new DataTable();
            dt = Money_balance_Local;
            return dt;
        }
        public DataTable Get_Money_Balance_Web()
        {
            DataTable dt = new DataTable();
            dt = Money_balance_Web;
            return dt;
        }


        public DataTable Get_Share_Balance_Local()
        {
            DataTable dt = new DataTable();
            dt = Share_Balance_Local;
            return dt;
        }

        public DataTable Get_Share_Balance_Web()
        {
            DataTable dt = new DataTable();
            dt = Share_Balance_Web;
            return dt;
        }

        #region
        //public void CompareRows_Share_Balance(DataTable table1, DataTable table2)
        //{
        //    Share_Balance_Local.Columns.Add("Cust_Code", typeof(string));
        //    Share_Balance_Local.Columns.Add("Comp_Short_Code", typeof(string));
        //    Share_Balance_Local.Columns.Add("Balance", typeof(string));
        //    Share_Balance_Local.Columns.Add("Matured_Balance", typeof(string));
        //    Share_Balance_Local.Columns.Add("MaturedBalProposed", typeof(string));
        //    Share_Balance_Local.Columns.Add("Comp_Category", typeof(string));
        //    Share_Balance_Local.Columns.Add("BuyAvg", typeof(string));
        //    Share_Balance_Local.Columns.Add("lossBen", typeof(string));
        //    Share_Balance_Local.Columns.Add("NetAvg", typeof(string));


        //    Share_Balance_Web.Columns.Add("customer_id", typeof(string));
        //    Share_Balance_Web.Columns.Add("company", typeof(string));
        //    Share_Balance_Web.Columns.Add("balance", typeof(string));
        //    Share_Balance_Web.Columns.Add("matured_balance", typeof(string));
        //    Share_Balance_Web.Columns.Add("prematured_balance", typeof(string));
        //    Share_Balance_Web.Columns.Add("market_group", typeof(string));
        //    Share_Balance_Web.Columns.Add("buy_average_value", typeof(string));
        //    Share_Balance_Web.Columns.Add("loss_gain", typeof(string));
        //    Share_Balance_Web.Columns.Add("breakeven_average", typeof(string));

        //    foreach (DataRow row1 in table1.Rows)
        //    {
                
        //        foreach (DataRow row2 in table2.Rows)
        //        {
        //            string Code_Web = (row2["customer_id"].ToString().Trim());
        //            string Balance_Web = (row2["balance"].ToString().Trim());
        //            string Code_Loacl = (row1["Cust_Code"].ToString().Trim());
        //            string Balance_Loacl = (row1["Balance"].ToString().Trim());

        //            List<DataRow> Found_Local = table1.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Cust_Code"]) == Code_Web && Convert.ToString(t["Balance"]) == Balance_Web).ToList();
        //            List<DataRow> Found_Web = table2.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["customer_id"]) == Code_Loacl && Convert.ToString(t["balance"]) == Balance_Loacl).ToList();

        //            if (Found_Local.Count == 0)
        //            {
        //                Share_Balance_Local.Rows.Add(row1["Cust_Code"].ToString(), row1["Comp_Short_Code"].ToString(), row1["Balance"].ToString(), row1["Matured_Balance"].ToString(), row1["MaturedBalProposed"].ToString(), row1["Comp_Category"].ToString(), row1["BuyAvg"].ToString(), row1["lossBen"].ToString(), row1["NetAvg"].ToString());
        //            }
        //            if (Found_Web.Count == 0)
        //            {
        //                Share_Balance_Web.Rows.Add(row2["customer_id"].ToString(), row2["company"].ToString(), row2["balance"].ToString(), row2["matured_balance"].ToString(), row2["prematured_balance"].ToString(), row2["market_group"].ToString(), row2["buy_average_value"].ToString(), row2["loss_gain"].ToString(), row2["breakeven_average"].ToString());
        //            }
        //            if (Found_Local.Count > 0 && Found_Web.Count > 0)
        //            {
        //                break;
        //            }


        //            //if (row1["Cust_Code"].ToString().Trim().Contains(row2["customer_id"].ToString().Trim()))
        //            //{
        //            //    if (row1["Balance"].ToString().Contains(row2["balance"].ToString())
        //            //        //&& row1["Withdraw"].ToString().Contains(row2["withdraw"].ToString()) && row1["Deposit"].ToString().Contains(row2["deposit"].ToString())
        //            //        //&& row1["GainLoss"].ToString().Contains(row2["total_gain_loss"].ToString()) && row1["market_value"].ToString().Contains(row2["market_value"].ToString())
        //            //        )
        //            //    {
        //            //        break;
        //            //    }
        //            //    else
        //            //    {
        //            //        Share_Balance_Local.Rows.Add(row1["Cust_Code"].ToString(), row1["Comp_Short_Code"].ToString(), row1["Balance"].ToString(), row1["Matured_Balance"].ToString(), row1["MaturedBalProposed"].ToString(), row1["Comp_Category"].ToString(), row1["BuyAvg"].ToString(), row1["lossBen"].ToString(), row1["NetAvg"].ToString());
        //            //        Share_Balance_Web.Rows.Add(row2["customer_id"].ToString(), row2["company"].ToString(), row2["balance"].ToString(), row2["matured_balance"].ToString(), row2["prematured_balance"].ToString(), row2["market_group"].ToString(), row2["buy_average_value"].ToString(), row2["loss_gain"].ToString(), row2["breakeven_average"].ToString());
        //            //        break;
        //            //    }
        //            //}

        //        }
        //    }

        //}
        #endregion

        public void CompareRows_Share_Balance(DataTable table1, DataTable table2)
        {
            Share_Balance_Local.Columns.Add("Cust_Code", typeof(string));
            Share_Balance_Local.Columns.Add("Comp_Short_Code", typeof(string));
            Share_Balance_Local.Columns.Add("Balance", typeof(string));
            Share_Balance_Local.Columns.Add("Matured_Balance", typeof(string));
            Share_Balance_Local.Columns.Add("MaturedBalProposed", typeof(string));
            Share_Balance_Local.Columns.Add("Comp_Category", typeof(string));
            Share_Balance_Local.Columns.Add("BuyAvg", typeof(string));
            Share_Balance_Local.Columns.Add("lossBen", typeof(string));
            Share_Balance_Local.Columns.Add("NetAvg", typeof(string));


            Share_Balance_Web.Columns.Add("customer_id", typeof(string));
            Share_Balance_Web.Columns.Add("company", typeof(string));
            Share_Balance_Web.Columns.Add("balance", typeof(string));
            Share_Balance_Web.Columns.Add("matured_balance", typeof(string));
            Share_Balance_Web.Columns.Add("prematured_balance", typeof(string));
            Share_Balance_Web.Columns.Add("market_group", typeof(string));
            Share_Balance_Web.Columns.Add("buy_average_value", typeof(string));
            Share_Balance_Web.Columns.Add("loss_gain", typeof(string));
            Share_Balance_Web.Columns.Add("breakeven_average", typeof(string));


            try
            {
                foreach (DataRow row1 in table1.Rows)
                {
                    string Code_Loacl = (row1["Cust_Code"].ToString().Trim());
                    string Balance_Loacl = (row1["Balance"].ToString().Trim());

                    List<DataRow> Found_Local = table2.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["customer_id"]) == Code_Loacl && Convert.ToString(t["balance"]) == Balance_Loacl).ToList();
                    if (Found_Local.Count == 0)
                    {
                        Share_Balance_Local.Rows.Add(row1["Cust_Code"].ToString(), row1["Comp_Short_Code"].ToString(), row1["Balance"].ToString(), row1["Matured_Balance"].ToString(), row1["MaturedBalProposed"].ToString(), row1["Comp_Category"].ToString(), row1["BuyAvg"].ToString(), row1["lossBen"].ToString(), row1["NetAvg"].ToString());
                    }

                    //    List<DataRow> Found_Local = table1.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Cust_Code"]) == Code_Web && Convert.ToString(t["Balance"]) == Balance_Web).ToList();
                    //    List<DataRow> Found_Web = table2.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["customer_id"]) == Code_Loacl && Convert.ToString(t["balance"]) == Balance_Loacl).ToList();

                    //    if (Found_Local.Count == 0)
                    //    {
                    //        Share_Balance_Local.Rows.Add(row1["Cust_Code"].ToString(), row1["Comp_Short_Code"].ToString(), row1["Balance"].ToString(), row1["Matured_Balance"].ToString(), row1["MaturedBalProposed"].ToString(), row1["Comp_Category"].ToString(), row1["BuyAvg"].ToString(), row1["lossBen"].ToString(), row1["NetAvg"].ToString());
                    //    }
                    //    if (Found_Web.Count == 0)
                    //    {
                    //        Share_Balance_Web.Rows.Add(row2["customer_id"].ToString(), row2["company"].ToString(), row2["balance"].ToString(), row2["matured_balance"].ToString(), row2["prematured_balance"].ToString(), row2["market_group"].ToString(), row2["buy_average_value"].ToString(), row2["loss_gain"].ToString(), row2["breakeven_average"].ToString());
                    //    }
                    //    if (Found_Local.Count > 0 && Found_Web.Count > 0)
                    //    {
                    //        break;
                    //    }


                    //  }
                }

                foreach (DataRow row2 in table2.Rows)
                {
                    string Code_Web = (row2["customer_id"].ToString().Trim());
                    string Balance_Web = (row2["balance"].ToString().Trim());

                    List<DataRow> Found_Local = table1.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Cust_Code"]) == Code_Web && Convert.ToString(t["Balance"]) == Balance_Web).ToList();

                    if (Found_Local.Count == 0)
                    {
                        Share_Balance_Web.Rows.Add(row2["customer_id"].ToString(), row2["company"].ToString(), row2["balance"].ToString(), row2["matured_balance"].ToString(), row2["prematured_balance"].ToString(), row2["market_group"].ToString(), row2["buy_average_value"].ToString(), row2["loss_gain"].ToString(), row2["breakeven_average"].ToString());
                    }

                }

            }

            catch (Exception ex)
            {
                throw ex;

                //if (row1["Cust_Code"].ToString().Trim().Contains(row2["customer_id"].ToString().Trim()))
                //{
                //    if (row1["Balance"].ToString().Contains(row2["balance"].ToString())
                //        //&& row1["Withdraw"].ToString().Contains(row2["withdraw"].ToString()) && row1["Deposit"].ToString().Contains(row2["deposit"].ToString())
                //        //&& row1["GainLoss"].ToString().Contains(row2["total_gain_loss"].ToString()) && row1["market_value"].ToString().Contains(row2["market_value"].ToString())
                //        )
                //    {
                //        break;
                //    }
                //    else
                //    {
                //        Share_Balance_Local.Rows.Add(row1["Cust_Code"].ToString(), row1["Comp_Short_Code"].ToString(), row1["Balance"].ToString(), row1["Matured_Balance"].ToString(), row1["MaturedBalProposed"].ToString(), row1["Comp_Category"].ToString(), row1["BuyAvg"].ToString(), row1["lossBen"].ToString(), row1["NetAvg"].ToString());
                //        Share_Balance_Web.Rows.Add(row2["customer_id"].ToString(), row2["company"].ToString(), row2["balance"].ToString(), row2["matured_balance"].ToString(), row2["prematured_balance"].ToString(), row2["market_group"].ToString(), row2["buy_average_value"].ToString(), row2["loss_gain"].ToString(), row2["breakeven_average"].ToString());
                //        break;
                //    }
                //}

                // }

            }

        }




        #region
        //public void CompareRows(DataTable table1, DataTable table2)
        //{
        //    Money_balance_Local.Columns.Add("customer_id", typeof(string));
        //    Money_balance_Local.Columns.Add("balance", typeof(string));
        //    Money_balance_Local.Columns.Add("deposit", typeof(string));
        //    Money_balance_Local.Columns.Add("withdraw", typeof(string));
        //    Money_balance_Local.Columns.Add("matured_balance", typeof(string));
        //    Money_balance_Local.Columns.Add("total_gain_loss", typeof(string));
        //    Money_balance_Local.Columns.Add("market_value", typeof(string));


        //    Money_balance_Web.Columns.Add("Cust_Code", typeof(string));
        //    Money_balance_Web.Columns.Add("Balance", typeof(string));
        //    Money_balance_Web.Columns.Add("Deposit", typeof(string));
        //    Money_balance_Web.Columns.Add("Withdraw", typeof(string));
        //    Money_balance_Web.Columns.Add("matured_balance", typeof(string));
        //    Money_balance_Web.Columns.Add("GainLoss", typeof(string));
        //    Money_balance_Web.Columns.Add("market_value", typeof(string));

        //    foreach (DataRow row1 in table1.Rows)
        //    {
        //        string Lical_Cust = row1["Cust_Code"].ToString().Trim();
        //        foreach (DataRow row2 in table2.Rows)
        //        {
        //            if (row1["Cust_Code"].ToString().Trim() == (row2["customer_id"].ToString().Trim()))
        //            {
        //                if (row1["Balance"].ToString().Contains(row2["balance"].ToString()) && row1["matured_balance"].ToString().Contains(row2["matured_balance"].ToString())
        //                    //&& row1["Withdraw"].ToString().Contains(row2["withdraw"].ToString()) && row1["Deposit"].ToString().Contains(row2["deposit"].ToString())
        //                    //&& row1["GainLoss"].ToString().Contains(row2["total_gain_loss"].ToString()) && row1["market_value"].ToString().Contains(row2["market_value"].ToString())
        //                    )
        //                {
        //                    break;
        //                }
        //                else
        //                {
        //                    Money_balance_Local.Rows.Add(row1["Cust_Code"].ToString(), row1["Balance"].ToString(), row1["Deposit"].ToString(), row1["Withdraw"].ToString(), row1["matured_balance"].ToString(), row1["GainLoss"].ToString(), row1["market_value"].ToString());
        //                    Money_balance_Web.Rows.Add(row2["customer_id"].ToString(), row2["balance"].ToString(), row2["deposit"].ToString(), row2["withdraw"].ToString(), row2["matured_balance"].ToString(), row2["total_gain_loss"].ToString(), row2["market_value"].ToString());
        //                    break;
        //                }
        //            }

        //        }
        //    }

        //}
        #endregion

        public void CompareRows(DataTable table1, DataTable table2)
        {
            Money_balance_Local.Columns.Add("customer_id", typeof(string));
            Money_balance_Local.Columns.Add("balance", typeof(string));
            Money_balance_Local.Columns.Add("deposit", typeof(string));
            Money_balance_Local.Columns.Add("withdraw", typeof(string));
            Money_balance_Local.Columns.Add("matured_balance", typeof(string));
            Money_balance_Local.Columns.Add("total_gain_loss", typeof(string));
            Money_balance_Local.Columns.Add("market_value", typeof(string));


            Money_balance_Web.Columns.Add("Cust_Code", typeof(string));
            Money_balance_Web.Columns.Add("Balance", typeof(string));
            Money_balance_Web.Columns.Add("Deposit", typeof(string));
            Money_balance_Web.Columns.Add("Withdraw", typeof(string));
            Money_balance_Web.Columns.Add("matured_balance", typeof(string));
            Money_balance_Web.Columns.Add("GainLoss", typeof(string));
            Money_balance_Web.Columns.Add("market_value", typeof(string));

            foreach (DataRow row1 in table1.Rows)
            {
                string Lical_Cust = row1["Cust_Code"].ToString().Trim();
                foreach (DataRow row2 in table2.Rows)
                {
                    if (row1["Cust_Code"].ToString().Trim() == (row2["customer_id"].ToString().Trim()))
                    {
                        if (row1["Balance"].ToString().Contains(row2["balance"].ToString()) && row1["matured_balance"].ToString().Contains(row2["matured_balance"].ToString())
                            //&& row1["Withdraw"].ToString().Contains(row2["withdraw"].ToString()) && row1["Deposit"].ToString().Contains(row2["deposit"].ToString())
                            //&& row1["GainLoss"].ToString().Contains(row2["total_gain_loss"].ToString()) && row1["market_value"].ToString().Contains(row2["market_value"].ToString())
                            )
                        {
                            break;
                        }
                        else
                        {
                            Money_balance_Local.Rows.Add(row1["Cust_Code"].ToString(), row1["Balance"].ToString(), row1["Deposit"].ToString(), row1["Withdraw"].ToString(), row1["matured_balance"].ToString(), row1["GainLoss"].ToString(), row1["market_value"].ToString());
                            Money_balance_Web.Rows.Add(row2["customer_id"].ToString(), row2["balance"].ToString(), row2["deposit"].ToString(), row2["withdraw"].ToString(), row2["matured_balance"].ToString(), row2["total_gain_loss"].ToString(), row2["market_value"].ToString());
                            break;
                        }
                    }

                }
            }

        }

        public DataTable Get_Share_Balance_Details_Local()
        {
            DataTable dt = new DataTable();
            dt = Share_Balance_Details_Local;
            return dt;
        }

        public DataTable Get_Share_Balance_Details_Web()
        {
            DataTable dt = new DataTable();
            dt = Share_Balance_Details_Web;
            return dt;
        }
        public void CompareRows_Share_Balance_Details(DataTable table1, DataTable table2)
        {
            Share_Balance_Details_Local.Columns.Add("Cust_Code", typeof(string));
            Share_Balance_Details_Local.Columns.Add("Comp_Short_Code", typeof(string));
            Share_Balance_Details_Local.Columns.Add("Buy_Dep_Qty", typeof(string));
            Share_Balance_Details_Local.Columns.Add("Sell_Withdraw_Qty", typeof(string));
            Share_Balance_Details_Local.Columns.Add("Balance", typeof(string));
            Share_Balance_Details_Local.Columns.Add("Buy_Total", typeof(string));
            Share_Balance_Details_Local.Columns.Add("Buy_Avg", typeof(string));
            Share_Balance_Details_Local.Columns.Add("Sell_Total", typeof(string));
            Share_Balance_Details_Local.Columns.Add("Sell_Avg", typeof(string));


            Share_Balance_Details_Local.Columns.Add("customer_id", typeof(string));
            Share_Balance_Details_Local.Columns.Add("company", typeof(string));
            Share_Balance_Details_Local.Columns.Add("buy_quantity", typeof(string));
            Share_Balance_Details_Local.Columns.Add("sale_quantity", typeof(string));
            Share_Balance_Details_Local.Columns.Add("balance_quantity", typeof(string));
            Share_Balance_Details_Local.Columns.Add("total_buy_amoun", typeof(string));
            Share_Balance_Details_Local.Columns.Add("total_buy_avg", typeof(string));
            Share_Balance_Details_Local.Columns.Add("total_sell_amount", typeof(string));
            Share_Balance_Details_Local.Columns.Add("total_sell_avg", typeof(string));


            foreach (DataRow row1 in table1.Rows)
            {
               
                foreach (DataRow row2 in table2.Rows)
                {
                    if (row1["Cust_Code"].ToString().Trim().Contains(row2["customer_id"].ToString().Trim()))
                    {
                        if (row1["Balance"].ToString().Contains(row2["balance_quantity"].ToString())
                            //&& row1["Withdraw"].ToString().Contains(row2["withdraw"].ToString()) && row1["Deposit"].ToString().Contains(row2["deposit"].ToString())
                            //&& row1["GainLoss"].ToString().Contains(row2["total_gain_loss"].ToString()) && row1["market_value"].ToString().Contains(row2["market_value"].ToString())
                            )
                        {
                            break;
                        }
                        else
                        {
                            Share_Balance_Details_Local.Rows.Add(row1["Cust_Code"].ToString(), row1["Comp_Short_Code"].ToString(), row1["Buy_Dep_Qty"].ToString(), row1["Sell_Withdraw_Qty"].ToString(), row1["Balance"].ToString(), row1["Buy_Total"].ToString(), row1["Buy_Avg"].ToString(), row1["Sell_Total"].ToString(), row1["Sell_Avg"].ToString());
                            Share_Balance_Details_Web.Rows.Add(row2["customer_id"].ToString(), row2["company"].ToString(), row2["buy_quantity"].ToString(), row2["sale_quantity"].ToString(), row2["balance_quantity"].ToString(), row2["total_buy_amoun"].ToString(), row2["Buy_Avg"].ToString(), row2["total_sell_amount"].ToString(), row2["total_sell_avg"].ToString());
                            break;
                        }
                    }

                }
            }

        }


        public DataTable Get_Payment_History_Local()
        {
            DataTable dt = new DataTable();
            dt = payment_History_Local;
            return dt;
        }

        public DataTable Get_Payment_History_Web()
        {
            DataTable dt = new DataTable();
            dt = Payment_history_Web;
            return dt;
        }


        public void CompareRows_Payment_History(DataTable table1, DataTable table2)
        {
            payment_History_Local.Columns.Add("Cust_Code", typeof(string));
            payment_History_Local.Columns.Add("Deposit_Withdraw", typeof(string));
            payment_History_Local.Columns.Add("Amount", typeof(string));
            payment_History_Local.Columns.Add("Bank_Name", typeof(string));
            payment_History_Local.Columns.Add("Payment_Media_No", typeof(string));
            payment_History_Local.Columns.Add("Voucher_Sl_No", typeof(string));



            Payment_history_Web.Columns.Add("customer_id", typeof(string));
            Payment_history_Web.Columns.Add("deposit_withdrawal", typeof(string));
            Payment_history_Web.Columns.Add("amount", typeof(string));
            Payment_history_Web.Columns.Add("bank_name", typeof(string));
            Payment_history_Web.Columns.Add("cheque_no", typeof(string));
            Payment_history_Web.Columns.Add("sl_no", typeof(string));
            

            foreach (DataRow row1 in table1.Rows)
            {
                string Lical_Cust = row1["Cust_Code"].ToString().Trim();
                foreach (DataRow row2 in table2.Rows)
                {
                    if (row1["Cust_Code"].ToString().Trim().Contains(row2["customer_id"].ToString().Trim()))
                    {
                        if (row1["Amount"].ToString().Contains(row2["amount"].ToString()) && row1["Voucher_Sl_No"].ToString().Contains(row2["sl_no"].ToString())
                            //&& row1["Withdraw"].ToString().Contains(row2["withdraw"].ToString()) && row1["Deposit"].ToString().Contains(row2["deposit"].ToString())
                            //&& row1["GainLoss"].ToString().Contains(row2["total_gain_loss"].ToString()) && row1["market_value"].ToString().Contains(row2["market_value"].ToString())
                            )
                        {
                            break;
                        }
                        else
                        {
                            Money_balance_Local.Rows.Add(row1["Cust_Code"].ToString(), row1["Deposit_Withdraw"].ToString(), row1["Amount"].ToString(), row1["Bank_Name"].ToString(), row1["Payment_Media_No"].ToString(), row1["Voucher_Sl_No"].ToString());
                            Money_balance_Web.Rows.Add(row2["customer_id"].ToString(), row2["deposit_withdrawal"].ToString(), row2["amount"].ToString(), row2["bank_name"].ToString(), row2["cheque_no"].ToString(), row2["sl_no"].ToString());
                            break;
                        }
                    }

                }
            }

        }
        public DataTable Get_Share_DW_Local()
        {
            DataTable dt = new DataTable();
            dt = Share_DW_Local;
            return dt;
        }
        public DataTable Get_Share_DW_Web()
        {
            DataTable dt = new DataTable();
            dt = Share_DW_Web;
            return dt;
        }
        public void CompareRows_Share_DW(DataTable table1, DataTable table2)
        {
            Share_DW_Local.Columns.Add("Cust_Code", typeof(string));
            Share_DW_Local.Columns.Add("Comp_Short_Code", typeof(string));
            Share_DW_Local.Columns.Add("Quantity", typeof(string));
            Share_DW_Local.Columns.Add("Deposit_Withdraw", typeof(string));
            Share_DW_Local.Columns.Add("No_Script", typeof(string));
            Share_DW_Local.Columns.Add("Vouchar_No", typeof(string));
            Share_DW_Local.Columns.Add("Deposit_Type", typeof(string));


            Share_DW_Web.Columns.Add("customer_id", typeof(string));
            Share_DW_Web.Columns.Add("company", typeof(string));
            Share_DW_Web.Columns.Add("quantity", typeof(string));
            Share_DW_Web.Columns.Add("deposit_withdrawal", typeof(string));
            Share_DW_Web.Columns.Add("no_script", typeof(string));
            Share_DW_Web.Columns.Add("bill_no", typeof(string));
            Share_DW_Web.Columns.Add("deposite_type", typeof(string));

            foreach (DataRow row1 in table1.Rows)
            {
                foreach (DataRow row2 in table2.Rows)
                {
                    if (row1["Cust_Code"].ToString().Trim() == (row2["customer_id"].ToString().Trim()))
                    {
                        if (row1["Quantity"].ToString().Contains(row2["quantity"].ToString()) && row1["Vouchar_No"].ToString().Contains(row2["bill_no"].ToString())
                            //&& row1["Withdraw"].ToString().Contains(row2["withdraw"].ToString()) && row1["Deposit"].ToString().Contains(row2["deposit"].ToString())
                            //&& row1["GainLoss"].ToString().Contains(row2["total_gain_loss"].ToString()) && row1["market_value"].ToString().Contains(row2["market_value"].ToString())
                            )
                        {
                            break;
                        }
                        else
                        {
                            Share_DW_Local.Rows.Add(row1["Cust_Code"].ToString(), row1["Comp_Short_Code"].ToString(), row1["Quantity"].ToString(), row1["Deposit_Withdraw"].ToString(), row1["No_Script"].ToString(), row1["Vouchar_No"].ToString(), row1["Deposit_Type"].ToString());
                            Share_DW_Web.Rows.Add(row2["customer_id"].ToString(), row2["company"].ToString(), row2["quantity"].ToString(), row2["deposit_withdrawal"].ToString(), row2["no_script"].ToString(), row2["bill_no"].ToString(), row2["deposite_type"].ToString());
                            break;
                        }
                    }

                }
            }

        }


        public DataTable Get_Company_Profile_Local()
        {
            DataTable dt = new DataTable();
            dt = Company_Profile_Local;
            return dt;
        }
        public DataTable Get_Company_Profile_Web()
        {
            DataTable dt = new DataTable();
            dt = Company_Profile_Web;
            return dt;
        }


        public void CompareRows_Company_Profile(DataTable table1, DataTable table2)
        {
            Company_Profile_Local.Columns.Add("Comp_Short_Code", typeof(string));
            Company_Profile_Local.Columns.Add("Comp_Name", typeof(string));
            //Company_Profile_Local.Columns.Add("Comp_Short_Code", typeof(string));
            Company_Profile_Local.Columns.Add("Comp_Category", typeof(string));
            Company_Profile_Local.Columns.Add("Face_Value", typeof(string));
            Company_Profile_Local.Columns.Add("Market_Lot", typeof(string));
            Company_Profile_Local.Columns.Add("Share_Type", typeof(string));


            Company_Profile_Web.Columns.Add("code_no", typeof(string));
            Company_Profile_Web.Columns.Add("company_full_name", typeof(string));
            //Company_Profile_Web.Columns.Add("company_short_cod", typeof(string));
            Company_Profile_Web.Columns.Add("market_group", typeof(string));
            Company_Profile_Web.Columns.Add("face_value", typeof(string));
            Company_Profile_Web.Columns.Add("market_lot", typeof(string));
            Company_Profile_Web.Columns.Add("type", typeof(string));


            foreach (DataRow row1 in table1.Rows)
            {
                foreach (DataRow row2 in table2.Rows)
                {
                    
                    string Code_Web = (row2["code_no"].ToString().Trim());
                    string Code_Loacl = (row1["Comp_Short_Code"].ToString().Trim());

                    List<DataRow> Found_Local = table1.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Comp_Short_Code"]) == Code_Web).ToList();
                    List<DataRow> Found_Web = table2.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["code_no"]) == Code_Web).ToList();

                   

                    //if (row1["Comp_Short_Code"].ToString().Trim() == (row2["code_no"].ToString().Trim()))
                    //{
                    //    if (row1["Face_Value"].ToString().Contains(row2["face_value"].ToString()))
                    //    {
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        Company_Profile_Local.Rows.Add(row1["Comp_Short_Code"].ToString(), row1["Comp_Name"].ToString(), row1["Comp_Short_Code"].ToString(), row1["Comp_Category"].ToString(), row1["Face_Value"].ToString(), row1["Market_Lot"].ToString(), row1["Share_Type"].ToString());
                    //        Company_Profile_Web.Rows.Add(row2["code_no"].ToString(), row2["company_full_name"].ToString(), row2["company_short_code"].ToString(), row2["market_group"].ToString(), row2["face_value"].ToString(), row2["market_lot"].ToString(), row2["type"].ToString());
                    //        break;
                    //    }
                    //}
                    if (Found_Local.Count == 0)
                    {
                        Company_Profile_Local.Rows.Add(row1["Comp_Short_Code"].ToString(), row1["Comp_Name"].ToString(), row1["Comp_Short_Code"].ToString(), row1["Comp_Category"].ToString(), row1["Face_Value"].ToString(), row1["Market_Lot"].ToString(), row1["Share_Type"].ToString());
                    }
                    if (Found_Web.Count == 0)
                    {
                        Company_Profile_Web.Rows.Add(row2["code_no"].ToString(), row2["company_full_name"].ToString(), row2["company_short_code"].ToString(), row2["market_group"].ToString(), row2["face_value"].ToString(), row2["market_lot"].ToString(), row2["type"].ToString());
                    }                   
                    if (Found_Local.Count > 0 && Found_Web.Count>0)
                    {
                        break;
                    }

                }
            }

        }
        #endregion


        public DataTable Data_Trade_Money_Balance_Web()
       {
           DataTable dt = new DataTable();
           try
           {
               string Query = @"SELECT `customer_id` , `balance` , `deposit` , `withdraw` , `matured_balance` , `total_gain_loss` , `market_value`
                                FROM `money_balance`
                                ORDER BY `customer_id` ASC";
               MySqlDataAdapter da = new MySqlDataAdapter(Query, Webconnection);
               da.Fill(dt);

           }
           catch (Exception)
           {               
               throw;
           }
           return dt;
       }


       public DataTable Get_MoneyBalance()
       {
           DataTable dt = new DataTable();
           string Query = string.Empty;
           Query = @"SBPWebDataExportIncremental_Reconcilation";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 6);
               dt = _dbConnection.ExecuteProQuery(Query);
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }
        #endregion

       public void LoadDataTable()
       {
           DataTable_All_Reconcilation_Result_Share_Balance.Columns.Add("TableName", typeof(string));
           DataTable_All_Reconcilation_Result_Share_Balance.Columns.Add("Description", typeof(string));
           DataTable_All_Reconcilation_Result_Share_Balance.Columns.Add("True_False", typeof(string));
           DataTable_All_Reconcilation_Result_Share_Balance.Columns.Add("Local_Count", typeof(string));
           DataTable_All_Reconcilation_Result_Share_Balance.Columns.Add("Web_Count", typeof(string));
           DataTable_All_Reconcilation_Result_Share_Balance.Columns.Add("Local_Balance", typeof(string));
           DataTable_All_Reconcilation_Result_Share_Balance.Columns.Add("Web_Balance", typeof(string));
       }

        #region Share_Balane


       public void New_CompareRows_Share_Balance(DataTable Local, DataTable Web)
       {
           int k = 0;

           if (k == 0 && DataTable_All_Reconcilation_Result_Share_Balance.Rows.Count == 0)
           {
               LoadDataTable();
           }

           List<double> Local_Share_Balance = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Balance"].ToString())).ToList();
           Double Balance_Local = Math.Round(Convert.ToDouble(Local_Share_Balance.Sum()), 0);
           List<double> Web_Share_Balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["balance"].ToString())).ToList();
           Double Balance_Web = Math.Round(Web_Share_Balance.Sum(), 0);

           List<double> Local_matured_balance = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Matured_Balance"].ToString())).ToList();
           Double matured_balance_Local = Math.Round(Convert.ToDouble(Local_matured_balance.Sum()), 0);
           List<double> Web_matured_balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["matured_balance"].ToString())).ToList();
           Double matured_balance_Web = Math.Round(Web_matured_balance.Sum(), 0);


           //List<double> Local_BuyAvg = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["BuyAvg"].ToString())).ToList();
           //Double BuyAvg_Local = Math.Round(Convert.ToDouble(Local_BuyAvg.Sum()), 0);
           //List<double> BuyAvg_balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["buy_average_value"].ToString())).ToList();
           //Double BuyAvg_Web = Math.Round(BuyAvg_balance.Sum(), 0);


           //List<double> Local_lossBen = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["lossBen"].ToString())).ToList();
           //Double lossBen_Local = Math.Round(Convert.ToDouble(Local_lossBen.Sum()), 0);
           //List<double> lossBen_balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["loss_gain"].ToString())).ToList();
           //Double lossBen_Web = Math.Round(lossBen_balance.Sum(), 0);

           //List<double> Local_NetAvg = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["NetAvg"].ToString())).ToList();
           //Double NetAvg_Local = Math.Round(Convert.ToDouble(Local_NetAvg.Sum()), 0);
           //List<double> NetAvg_balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["breakeven_average"].ToString())).ToList();
           //Double NetAvg_Web = Math.Round(NetAvg_balance.Sum(), 0);

           string LocalCount = Local.Rows.Count.ToString();
           string WebCount = Web.Rows.Count.ToString();
           string LocalBalance = Convert.ToString(Balance_Local);
           string WebBalance = Convert.ToString(Balance_Web);

           if (Local.Rows.Count == Web.Rows.Count)
           {
               k++;
           }
           if (Balance_Local == Balance_Web)
           {
               k++;
           }
           if (matured_balance_Local == matured_balance_Web)
           {
               k++;
           }
           //if (BuyAvg_Local == BuyAvg_Web)
           //{
           //    k++;
           //}
           //if (lossBen_Local == NetAvg_Web)
           //{
           //    k++;
           //}
           if (k == 3)
           {
               DataTable_All_Reconcilation_Result_Share_Balance.Rows.Add("Share Balance", "Ok", "True", LocalCount, WebCount, LocalBalance, WebBalance);
           }
           else
           {
               DataTable_All_Reconcilation_Result_Share_Balance.Rows.Add("Share Balance", "Not Ok", "False", LocalCount, WebCount, LocalBalance, WebBalance);
           }



       }

       public void Trade_Share_Balance()
       {
           DataTable dt_Web = new DataTable();
           DataTable dt_local = new DataTable();
           try
           {
               obj.Connect_Web();
               obj.Connect_SBP();
               dt_Web = Web_Share_Balanec();
               dt_local = Local_Web_Share_Balance();             
               New_CompareRows_Share_Balance(dt_local, dt_Web);
               CompareRows_Share_Balance(dt_local, dt_Web);
               obj.Commit_Web();
               obj.Commit_SBP();

           }
           catch (Exception ex)
           {
               obj.Rollback_SBP();
               obj.Rollback_Web();
           }
           finally
           {
               obj.CloseConnection_SBP();
               obj.CloseConnection_Web();
           }

       }


       public DataTable Web_Share_Balanec()
       {
           DataTable dt = new DataTable();
           try
           {
               string Query = @"SELECT `customer_id` , `company` , `balance` , `matured_balance` , `prematured_balance` , `market_group` , `buy_average_value` , `loss_gain` , `breakeven_average`
                                FROM `share_balance`
                                ORDER BY `customer_id` ASC";
               MySqlDataAdapter da = new MySqlDataAdapter(Query, Webconnection);
               da.Fill(dt);

           }
           catch (Exception)
           {
               throw;
           }
           return dt;
       }

       public DataTable Local_Web_Share_Balance()
       {
           DataTable dt = new DataTable();
           string Query = string.Empty;
           Query = @"SBPWebDataExportIncremental_Reconcilation";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 8);
               dt = _dbConnection.ExecuteProQuery(Query);
           }
           catch (Exception)
           {
               throw;
           }
           return dt;
       }
       #endregion

        #region Company_profile


       public void New_CompareRows_Company_profile(DataTable Local, DataTable Web)
       {
           int k = 0;
           //DataTable_All_Reconcilation_Result.Columns.Add("TableName", typeof(string));
           //DataTable_All_Reconcilation_Result.Columns.Add("Description", typeof(string));
           //DataTable_All_Reconcilation_Result.Columns.Add("True_False", typeof(string));
           if (k == 0 && DataTable_All_Reconcilation_Result_Share_Balance.Rows.Count == 0)
           {
               LoadDataTable();
           }

           List<double> Local_face_value = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Face_Value"].ToString())).ToList();
           Double face_value_Local = Math.Round(Convert.ToDouble(Local_face_value.Sum()), 0);
           List<double> face_value_Balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["face_value"].ToString())).ToList();
           Double face_value_Web = Math.Round(face_value_Balance.Sum(), 0);

           List<double> Local_market_lot = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["market_lot"].ToString())).ToList();
           Double market_lot_Local = Math.Round(Convert.ToDouble(Local_market_lot.Sum()), 0);
           List<double> market_lot_balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Market_Lot"].ToString())).ToList();
           Double market_lot_Web = Math.Round(market_lot_balance.Sum(), 0);



           if (Local.Rows.Count == Web.Rows.Count)
           {
               k++;
           }
           if (face_value_Local == face_value_Web)
           {
               k++;
           }
           if (market_lot_Local == market_lot_Web)
           {
               k++;
           }
           
           if (k == 3)
           {
               DataTable_All_Reconcilation_Result_Share_Balance.Rows.Add("Company Profile", "Ok", "True", Local.Rows.Count.ToString(), Web.Rows.Count.ToString(), Convert.ToString(face_value_Local), "Face Value : "+Convert.ToString(face_value_Web));
           }
           else
           {
               DataTable_All_Reconcilation_Result_Share_Balance.Rows.Add("Company Profile", "Not Ok", "False", Local.Rows.Count.ToString(), Web.Rows.Count.ToString(), Convert.ToString(face_value_Local), "Face Value : " + Convert.ToString(face_value_Web));
           }



       }

       public void Trade_Web_Company_Profile()
       {
           DataTable dt_Web = new DataTable();
           DataTable dt_local = new DataTable();
           try
           {
               obj.Connect_Web();
               obj.Connect_SBP();
               dt_Web = Web_Company_Profile();
               dt_local = Local_Comapny_profile();
               CompareRows_Company_Profile(dt_local, dt_Web);
               New_CompareRows_Company_profile(dt_local, dt_Web);
               obj.Commit_Web();
               obj.Commit_SBP();

           }
           catch (Exception ex)
           {
               obj.Rollback_SBP();
               obj.Rollback_Web();
           }
           finally
           {
               obj.CloseConnection_SBP();
               obj.CloseConnection_Web();
           }

       }


       public DataTable Web_Company_Profile()
       {
           DataTable dt = new DataTable();
           try
           {
               string Query = @"SELECT `code_no`,`company_full_name`,`company_short_code`,`market_group`,`face_value`,`market_lot`,`type` FROM `company_profile`";
               MySqlDataAdapter da = new MySqlDataAdapter(Query, Webconnection);
               da.Fill(dt);

           }
           catch (Exception)
           {
               throw;
           }
           return dt;
       }

       public DataTable Local_Comapny_profile()
       {
           DataTable dt = new DataTable();
           string Query = string.Empty;
           Query = @"SBPWebDataExportIncremental_Reconcilation";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 2);
               dt = _dbConnection.ExecuteProQuery(Query);
           }
           catch (Exception)
           {
               throw;
           }
           return dt;
       }
       #endregion      

        #region Share_D_W


       public void New_CompareRows_Share_DW(DataTable Local, DataTable Web)
       {
           int k = 0;
           if (k == 0 && DataTable_All_Reconcilation_Result_Share_Balance.Rows.Count == 0)
           {
               LoadDataTable();
           }

           List<double> Local_Quantity = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Quantity"].ToString())).ToList();
           Double Quantity_Local = Math.Round(Convert.ToDouble(Local_Quantity.Sum()), 0);
           List<double> face_Quantity = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["quantity"].ToString())).ToList();
           Double Quantity_Web = Math.Round(face_Quantity.Sum(), 0);

           //List<double> Local_market_lot = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["market_lot"].ToString())).ToList();
           //Double market_lot_Local = Math.Round(Convert.ToDouble(Local_market_lot.Sum()), 0);
           //List<double> market_lot_balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Market_Lot"].ToString())).ToList();
           //Double market_lot_Web = Math.Round(market_lot_balance.Sum(), 0);



           if (Local.Rows.Count == Web.Rows.Count)
           {
               k++;
           }
           if (Quantity_Local == Quantity_Web)
           {
               k++;
           }          

           if (k == 2)
           {
               DataTable_All_Reconcilation_Result_Share_Balance.Rows.Add("Share Deposit & Withdraw", "Ok", "True", Local.Rows.Count.ToString(), Web.Rows.Count.ToString(), "Lacal Quantity : "+Convert.ToString(Quantity_Local),"Web Quantity : "+Convert.ToString(Quantity_Web));
           }
           else
           {
               DataTable_All_Reconcilation_Result_Share_Balance.Rows.Add("Share Deposit & Withdraw", "Not Ok", "False", Local.Rows.Count.ToString(), Web.Rows.Count.ToString(), "Lacal Quantity : " + Convert.ToString(Quantity_Local), "Web Quantity : " + Convert.ToString(Quantity_Web));
           }



       }

       public void Trade_Web_Share_DW()
       {
           DataTable dt_Web = new DataTable();
           DataTable dt_local = new DataTable();
           try
           {
               obj.Connect_Web();
               obj.Connect_SBP();
               dt_Web = Web_Share_DW();
               dt_local = Local_Share_DW();
               CompareRows_Share_DW(dt_local, dt_Web);
               New_CompareRows_Share_DW(dt_local, dt_Web);
               obj.Commit_Web();
               obj.Commit_SBP();

           }
           catch (Exception ex)
           {
               obj.Rollback_SBP();
               obj.Rollback_Web();
           }
           finally
           {
               obj.CloseConnection_SBP();
               obj.CloseConnection_Web();
           }

       }


       public DataTable Web_Share_DW()
       {
           DataTable dt = new DataTable();
           try
           {
               string Query = @"SELECT `customer_id`,`entry_date`,`company`,`quantity`,`deposit_withdrawal`,`no_script`,`bill_no`,`deposite_type` FROM `share_dw`";
               MySqlDataAdapter da = new MySqlDataAdapter(Query, Webconnection);
               da.Fill(dt);

           }
           catch (Exception)
           {
               throw;
           }
           return dt;
       }

       public DataTable Local_Share_DW()
       {
           DataTable dt = new DataTable();
           string Query = string.Empty;
           Query = @"SBPWebDataExportIncremental_Reconcilation";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 10);
               dt = _dbConnection.ExecuteProQuery(Query);
           }
           catch (Exception)
           {
               throw;
           }
           return dt;
       }
       #endregion

        #region payment_history


       public void New_CompareRows_payment_history(DataTable Local, DataTable Web)
       {
           int k = 0;
           //DataTable_All_Reconcilation_Result.Columns.Add("TableName", typeof(string));
           //DataTable_All_Reconcilation_Result.Columns.Add("Description", typeof(string));
           //DataTable_All_Reconcilation_Result.Columns.Add("True_False", typeof(string));

           if (k == 0 && DataTable_All_Reconcilation_Result_Share_Balance.Rows.Count == 0)
           {
               LoadDataTable();
           }

           List<double> Local_Amount = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Amount"].ToString())).ToList();
           Double Amount_Local = Math.Round(Convert.ToDouble(Local_Amount.Sum()), 0);
           List<double> face_Amount = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Amount"].ToString())).ToList();
           Double Amount_Web = Math.Round(face_Amount.Sum(), 0);

           //List<double> Local_market_lot = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["market_lot"].ToString())).ToList();
           //Double market_lot_Local = Math.Round(Convert.ToDouble(Local_market_lot.Sum()), 0);
           //List<double> market_lot_balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Market_Lot"].ToString())).ToList();
           //Double market_lot_Web = Math.Round(market_lot_balance.Sum(), 0);



           if (Local.Rows.Count == Web.Rows.Count)
           {
               k++;
           }
           if (Amount_Local == Amount_Web)
           {
               k++;
           }

           if (k == 2)
           {
               DataTable_All_Reconcilation_Result_Share_Balance.Rows.Add("Payment History", "Ok", "True", Local.Rows.Count.ToString(), Web.Rows.Count.ToString(), Convert.ToString(Amount_Local),Convert.ToString(Amount_Web));
           }
           else
           {
               DataTable_All_Reconcilation_Result_Share_Balance.Rows.Add("Payment History", "Not Ok", "False", Local.Rows.Count.ToString(), Web.Rows.Count.ToString(), Convert.ToString(Amount_Local), Convert.ToString(Amount_Web));
           }



       }

       public void Trade_Web_payment_history()
       {
           DataTable dt_Web = new DataTable();
           DataTable dt_local = new DataTable();
           try
           {
               obj.Connect_Web();
               obj.Connect_SBP();
               dt_Web = Web_payment_history();
               dt_local = Local_payment_history();
               CompareRows_Payment_History(dt_local, dt_Web);
               New_CompareRows_payment_history(dt_local, dt_Web);
               obj.Commit_Web();
               obj.Commit_SBP();

           }
           catch (Exception ex)
           {
               obj.Rollback_SBP();
               obj.Rollback_Web();
           }
           finally
           {
               obj.CloseConnection_SBP();
               obj.CloseConnection_Web();
           }

       }


       public DataTable Web_payment_history()
       {
           DataTable dt = new DataTable();
           try
           {
               string Query = @"SELECT * FROM `payment_history`";
               MySqlDataAdapter da = new MySqlDataAdapter(Query, Webconnection);
               da.Fill(dt);

           }
           catch (Exception)
           {
               throw;
           }
           return dt;
       }

       public DataTable Local_payment_history()
       {
           DataTable dt = new DataTable();
           string Query = string.Empty;
           Query = @"SBPWebDataExportIncremental_Reconcilation";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 7);
               dt = _dbConnection.ExecuteProQuery(Query);
           }
           catch (Exception)
           {
               throw;
           }
           return dt;
       }
       #endregion

        #region transection_detail


       public void New_CompareRows_transection_detail(DataTable Local, DataTable Web)
       {
           int k = 0;
           //DataTable_All_Reconcilation_Result.Columns.Add("TableName", typeof(string));
           //DataTable_All_Reconcilation_Result.Columns.Add("Description", typeof(string));
           //DataTable_All_Reconcilation_Result.Columns.Add("True_False", typeof(string));

           List<double> Local_share_quantity = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["TradeQty"].ToString())).ToList();
           Double share_quantity_Local = Math.Round(Convert.ToDouble(Local_share_quantity.Sum()), 0);
           List<double> face_share_quantity = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["share_quantity"].ToString())).ToList();
           Double share_quantity_Web = Math.Round(face_share_quantity.Sum(), 0);

           List<double> Local_TradePrice = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["TradePrice"].ToString())).ToList();
           Double TradePrice_Local = Math.Round(Convert.ToDouble(Local_TradePrice.Sum()), 0);
           List<double> TradePrice_balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["price"].ToString())).ToList();
           Double TradePrice_Web = Math.Round(TradePrice_balance.Sum(), 0);

           List<double> Local_TotalAmount = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["TotalAmount"].ToString())).ToList();
           Double TotalAmount_Local = Math.Round(Convert.ToDouble(Local_TotalAmount.Sum()), 0);
           List<double> TotalAmount_balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["total"].ToString())).ToList();
           Double TotalAmount_Web = Math.Round(TotalAmount_balance.Sum(), 0);


           List<double> Local_Commission = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Commission"].ToString())).ToList();
           Double Commission_Local = Math.Round(Convert.ToDouble(Local_Commission.Sum()), 0);
           List<double> Commission_balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["comm"].ToString())).ToList();
           Double Commission_Web = Math.Round(Commission_balance.Sum(), 0);




           if (Local.Rows.Count == Web.Rows.Count)
           {
               k++;
           }
           if (share_quantity_Local == share_quantity_Web)
           {
               k++;
           }
           if (TradePrice_Local == TradePrice_Web)
           {
               k++;
           }
           if (TotalAmount_Local == TotalAmount_Web)
           {
               k++;
           }
           if (Commission_Local == Commission_Web)
           {
               k++;
           }

           if (k == 5)
           {
               DataTable_All_Reconcilation_Result_Share_Balance.Rows.Add("Transection Detail", "Ok", "True", Local.Rows.Count.ToString(), Web.Rows.Count.ToString(), "Local Share Quantity :" + Convert.ToString(share_quantity_Local), "Web Share Quantity :" + Convert.ToString(share_quantity_Web));
           }
           else
           {
               DataTable_All_Reconcilation_Result_Share_Balance.Rows.Add("Transection Detail", "Not Ok", "False", Local.Rows.Count.ToString(), Web.Rows.Count.ToString(), "Local Share Quantity :" + Convert.ToString(share_quantity_Local), "Web Share Quantity :" + Convert.ToString(share_quantity_Web));
           }



       }

       public void Trade_Web_transection_detail()
       {
           DataTable dt_Web = new DataTable();
           DataTable dt_local = new DataTable();
           try
           {
               obj.Connect_Web();
               obj.Connect_SMS();
               dt_Web = Web_transection_detail();
               dt_local = Local_transection_detail();
               //CompareRows(dt_local, dt_Web);
               New_CompareRows_transection_detail(dt_local, dt_Web);
               obj.Commit_Web();
               obj.Commit_SBP();

           }
           catch (Exception ex)
           {
               obj.Rollback_SBP();
               obj.Rollback_Web();
           }
           finally
           {
               obj.CloseConnection_SBP();
               obj.CloseConnection_Web();
           }

       }


       public DataTable Web_transection_detail()
       {
           DataTable dt = new DataTable();
           try
           {
               string Query = @"SELECT * FROM `transection_detail`";
               MySqlDataAdapter da = new MySqlDataAdapter(Query, Webconnection);
               da.Fill(dt);

           }
           catch (Exception)
           {
               throw;
           }
           return dt;
       }

       public DataTable Local_transection_detail()
       {
           DataTable dt = new DataTable();
           string Query = string.Empty;
           Query = @"SBPWebDataExportIncremental_Reconcilation";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ActiveStoredProcedure();
               _dbConnection.AddParameter("@NavigationSwitch", SqlDbType.Int, 11);
               dt = _dbConnection.ExecuteProQuery(Query);
           }
           catch (Exception)
           {
               throw;
           }
           return dt;
       }
       #endregion

       #region Share_Balance_Details


       public void New_CompareRows_Share_Balance_Details(DataTable Local, DataTable Web)
       {
           int k = 0;

           if (k == 0 && DataTable_All_Reconcilation_Result_Share_Balance.Rows.Count == 0)
           {
               LoadDataTable();
           }
           //DataTable_All_Reconcilation_Result.Columns.Add("TableName", typeof(string));
           //DataTable_All_Reconcilation_Result.Columns.Add("Description", typeof(string));
           //DataTable_All_Reconcilation_Result.Columns.Add("True_False", typeof(string));

           List<double> Local_share_quantity = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Buy_Dep_Qty"].ToString())).ToList();
           Double share_quantity_Local = Math.Round(Convert.ToDouble(Local_share_quantity.Sum()), 0);
           List<double> face_share_quantity = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["buy_quantity"].ToString())).ToList();
           Double share_quantity_Web = Math.Round(face_share_quantity.Sum(), 0);

           List<double> Local_TradePrice = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Sell_Withdraw_Qty"].ToString())).ToList();
           Double TradePrice_Local = Math.Round(Convert.ToDouble(Local_TradePrice.Sum()), 0);
           List<double> TradePrice_balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["sale_quantity"].ToString())).ToList();
           Double TradePrice_Web = Math.Round(TradePrice_balance.Sum(), 0);

           List<double> Local_TotalAmount = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Buy_Total"].ToString())).ToList();
           Double TotalAmount_Local = Math.Round(Convert.ToDouble(Local_TotalAmount.Sum()), 0);
           List<double> TotalAmount_balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["total_buy_amount"].ToString())).ToList();
           Double TotalAmount_Web = Math.Round(TotalAmount_balance.Sum(), 0);


           List<double> Local_Commission = Local.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Sell_Total"].ToString())).ToList();
           Double Commission_Local = Math.Round(Convert.ToDouble(Local_Commission.Sum()), 0);
           List<double> Commission_balance = Web.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["total_sell_amount"].ToString())).ToList();
           Double Commission_Web = Math.Round(Commission_balance.Sum(), 0);




           if (Local.Rows.Count == Web.Rows.Count)
           {
               k++;
           }
           if (share_quantity_Local == share_quantity_Web)
           {
               k++;
           }
           if (TradePrice_Local == TradePrice_Web)
           {
               k++;
           }
           if (TotalAmount_Local == TotalAmount_Web)
           {
               k++;
           }
           if (Commission_Local == Commission_Web)
           {
               k++;
           }

           if (k == 5)
           {
               DataTable_All_Reconcilation_Result_Share_Balance.Rows.Add("Share Balance Detail", "Ok", "True", Local.Rows.Count.ToString(), Web.Rows.Count.ToString(), Convert.ToString(TotalAmount_Local),Convert.ToString(TotalAmount_Web));
           }
           else
           {
               DataTable_All_Reconcilation_Result_Share_Balance.Rows.Add("Share Balance Detail", "Not Ok", "False", Local.Rows.Count.ToString(), Web.Rows.Count.ToString(), Convert.ToString(TotalAmount_Local), Convert.ToString(TotalAmount_Web));
           }



       }

       public void Trade_Web_Share_Balance_Details()
       {
           DataTable dt_Web = new DataTable();
           DataTable dt_local = new DataTable();
           try
           {
               obj.Connect_Web();
               obj.Connect_SBP();
               dt_Web = Web_Share_Balance_Details();
               dt_local = Local_Share_Balance_Details();
               CompareRows_Share_Balance_Details(dt_local, dt_Web);
               New_CompareRows_Share_Balance_Details(dt_local, dt_Web);
               obj.Commit_Web();
               obj.Commit_SBP();

           }
           catch (Exception ex)
           {
               obj.Rollback_SBP();
               obj.Rollback_Web();
           }
           finally
           {
               obj.CloseConnection_SBP();
               obj.CloseConnection_Web();
           }

       }


       public DataTable Web_Share_Balance_Details()
       {
           DataTable dt = new DataTable();
           try
           {
               string Query = @"SELECT * FROM `share_balance_detail`";
               MySqlDataAdapter da = new MySqlDataAdapter(Query, Webconnection);
               da.Fill(dt);

           }
           catch (Exception)
           {
               throw;
           }
           return dt;
       }

       public DataTable Local_Share_Balance_Details()
       {
           DataTable dt = new DataTable();
           try
           {
               string Query = @"SELECT 
		                              ISNULL(cmpMain.[Cust_Code],'') AS 'Cust_Code'
		                             ,ISNULL(cmpMain.[Comp_Short_Code],'') AS 'Comp_Short_Code'
		                             ,ISNULL(Convert(varchar(10),cmpMain.[Trade_Date],126),'') AS 'Trade_Date'
		                             ,ISNULL(Convert(varchar(200),cmpMain.[Buy_Dep_Qty]),'')AS 'Buy_Dep_Qty'
		                             ,ISNULL(Convert(varchar(200),cmpMain.[Sell_Withdraw_Qty]),'')AS 'Sell_Withdraw_Qty'
		                             ,ISNULL(Convert(varchar(200),cmpMain.[Balance]),'')AS 'Balance'
		                             ,ISNULL(cmpMain.[Remarks],'')AS 'Remarks'
		                             ,ISNULL(Convert(varchar(200),cmpMain.[Buy_Total]),'')AS 'Buy_Total'
		                             ,ISNULL(Convert(varchar(200),cmpMain.[Buy_Avg]),'')AS 'Buy_Avg'
		                             ,ISNULL(Convert(varchar(200),cmpMain.[Sell_Total]),'')AS 'Sell_Total'
		                             ,ISNULL(Convert(varchar(200),Sell_Avg),'') AS 'Sell_Avg'
                                     ,(Select COUNT(*) from SBP_Share_Balance_Temp AS Val Where Val.Cust_Code=cmpMain
                                     .Cust_Code AND Val.Trade_Date = cmpMain.Trade_Date 
                                      AND Val.Comp_Short_Code= cmpMain.Comp_Short_Code) AS 'Count'   
	                            FROM [SBP_Database].[dbo].[SBP_Share_Balance_Temp] as cmpMain
	                            JOIN
	                            dbo.SBP_Service_Registration as reg
	                            ON 
	                            reg.Cust_Code=cmpMain.Cust_Code
	                            AND reg.Web_Service=1
                                --AND DATEPART(YEAR,cmpMain.Trade_Date) >= 2013
                               ";

               _dbConnection.ConnectDatabase();
               dt = _dbConnection.ExecuteQuery(Query);

           }
           catch (Exception)
           {
               throw;
           }
           return dt;
       }
       #endregion

     
    }  
}
