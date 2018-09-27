using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using System.Threading;
using System.Diagnostics;
using System.Globalization;

namespace StockbrokerProNewArch
{
    public partial class Web_Data_Reconcilation : Form
    {
        public WebDataExportBAL objWebDataExportBAL = new WebDataExportBAL();
        public Web_Data_ReconcilationBAL objWeb_Data_ReconcilationBAL = new Web_Data_ReconcilationBAL();
        public static bool isProgressed;
        public DataTable Local = new DataTable();
        public DataTable Web = new DataTable();
      
        string currentTime = string.Empty;


        public Web_Data_Reconcilation()
        {
            InitializeComponent();
            
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            Thread thrd = new Thread(WaitWindow_ThreadforIPOExport);           
            isProgressed = true;
            thrd.Start();
            All_Result();
            isProgressed = false;            
        }

       
        public void All_Result()
        {
            int K = 10;
            string Table_Name = string.Empty;
            string Result = string.Empty;
            string True_False = string.Empty;
            string Local_Count = string.Empty;
            string Web_Count = string.Empty;
            string Local_balance = string.Empty;
            string Web_balance = string.Empty;
            DataTable Local = new DataTable();
            objWeb_Data_ReconcilationBAL.Trade_Share_Balance();
            objWeb_Data_ReconcilationBAL.Trade_Web_Company_Profile();
            objWeb_Data_ReconcilationBAL.Trade_Web_Share_DW();
            objWeb_Data_ReconcilationBAL.Trade_Money_Balance();
            objWeb_Data_ReconcilationBAL.Trade_Web_payment_history();
            objWeb_Data_ReconcilationBAL.Trade_Web_transection_detail();
            objWeb_Data_ReconcilationBAL.Trade_Web_Share_Balance_Details();
            Local = objWeb_Data_ReconcilationBAL.Get_All_Reconcilation_Result();
            ReconcilationGride.DataSource = Local;
            int M = 1;
            foreach (DataGridViewRow row in ReconcilationGride.Rows)
            {
                int o = Local.Rows.Count;
                if (M <= o)
                {
                    string RowType = row.Cells[2].Value.ToString();

                    if (RowType.ToUpper().Trim() == ("TRUE").ToUpper().Trim())
                    {
                        row.DefaultCellStyle.BackColor = Color.Green;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (RowType.ToUpper().Trim() == ("False").ToUpper().Trim())
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    M++;
                }
            }

            #region

            //foreach (DataRow dr in Local.Rows)
            //{
                  
            //    Table_Name = dr[0].ToString();
            //    Result = dr[1].ToString();
            //    True_False = dr[2].ToString();
            //    Local_Count = dr[3].ToString();
            //    Web_Count = dr[4].ToString();
            //    Local_balance = dr[5].ToString();
            //    Web_balance = dr[6].ToString();

            //    if (K == 10)
            //    {
            //        Lable10.Visible = true;
            //        if (True_False.ToLower().Trim().Contains(("True").ToLower().Trim()))
            //        {
            //            Lable10.ForeColor = Color.Green;
            //            label17.ForeColor = Color.Green;
            //            label18.ForeColor = Color.Green;
            //            label19.ForeColor = Color.Green;
            //            label20.ForeColor = Color.Green;
            //            Lable10.Text = Table_Name + " ---------" + " Ok";
            //            label17.Text ="Local Row Count :"+ Local_Count;
            //            label18.Text ="Web Row Count : " +Web_Count;
            //            label19.Text ="Local Sum Balance :"+ Local_balance;
            //            label20.Text ="Web Sum Balance :"+ Web_balance;
                        
            //        }
            //        else if (True_False.ToLower().Trim().Contains(("false").ToLower().Trim()))
            //        {
            //            Lable10.ForeColor = Color.Red;
            //            label17.ForeColor = Color.Red;
            //            label18.ForeColor = Color.Red;
            //            label19.ForeColor = Color.Red;
            //            label20.ForeColor = Color.Red;
            //            Lable10.Text = Table_Name + " ---------" + "Not Ok";
            //            label17.Text = "Local Row Count :" + Local_Count;
            //            label18.Text = "Web Row Count : " + Web_Count;
            //            label19.Text = "Local Sum Balance :" + Local_balance;
            //            label20.Text = "Web Sum Balance :" + Web_balance;      
            //        }
            //    }
            //    else if (K == 11)
            //    {
            //        label11.Visible = true;
            //        if (True_False.ToLower().Trim().Contains(("True").ToLower().Trim()))
            //        {
            //            label11.ForeColor = Color.Green;
            //            label11.Text = Table_Name + " ---------" + " Ok";
            //        }
            //        else if (True_False.ToLower().Trim().Contains(("false").ToLower().Trim()))
            //        {
            //            label11.ForeColor = Color.Red;
            //            label11.Text = Table_Name + " ---------" + " Not Ok";
            //        }
            //    }
            //    else if (K == 12)
            //    {
            //        label12.Visible = true;
            //        if (True_False.ToLower().Trim().Contains(("True").ToLower().Trim()))
            //        {
            //            label12.ForeColor = Color.Green;
            //            label12.Text = Table_Name + " --" + "Ok";
            //        }
            //        else if (True_False.ToLower().Trim().Contains(("false").ToLower().Trim()))
            //        {
            //            label12.ForeColor = Color.Red;
            //            label12.Text = Table_Name + " --" + "Not Ok";
            //        }
            //    }
            //    else if (K == 13)
            //    {
            //        label13.Visible = true;
            //        if (True_False.ToLower().Trim().Contains(("True").ToLower().Trim()))
            //        {
            //            label13.ForeColor = Color.Green;
            //            label13.Text = Table_Name + " ---------" + " Ok";
            //        }
            //        else if (True_False.ToLower().Trim().Contains(("false").ToLower().Trim()))
            //        {
            //            label13.ForeColor = Color.Red;
            //            label13.Text = Table_Name + " ---------" + " Not Ok";
            //        }
            //    }
            //    else if (K == 14)
            //    {
            //        label14.Visible = true;
            //        if (True_False.ToLower().Trim().Contains(("True").ToLower().Trim()))
            //        {
            //            label14.ForeColor = Color.Green;
            //            label14.Text = Table_Name + " ---------" + " Ok";
            //        }
            //        else if (True_False.ToLower().Trim().Contains(("false").ToLower().Trim()))
            //        {
            //            label14.ForeColor = Color.Red;
            //            label14.Text = Table_Name + " ---------" + " Not Ok";
            //        }
            //    }
            //    else if (K == 15)
            //    {
            //        label15.Visible = true;
            //        if (True_False.ToLower().Trim().Contains(("True").ToLower().Trim()))
            //        {
            //            label15.ForeColor = Color.Green;
            //            label15.Text = Table_Name + " ---------" + " Ok";
            //        }
            //        else if (True_False.ToLower().Trim().Contains(("false").ToLower().Trim()))
            //        {
            //            label15.ForeColor = Color.Red;
            //            label15.Text = Table_Name + " ---------" + " Not Ok";
            //        }
            //    }
            //    else if (K == 16)
            //    {
            //        label16.Visible = true;
            //        if (True_False.ToLower().Trim().Contains(("True").ToLower().Trim()))
            //        {
            //            label16.ForeColor = Color.Green;
            //            label16.Text = Table_Name + " --" + " Ok";
            //        }
            //        else if (True_False.ToLower().Trim().Contains(("false").ToLower().Trim()))
            //        {
            //            label16.ForeColor = Color.Red;
            //            label16.Text = Table_Name + " --" + " Not Ok";
            //        }
            //    }
            //    K++;
            //}

            #endregion
        }
        private void Web_Data_Reconcilation_Load(object sender, EventArgs e)
        {
            btnProcess.Enabled = false;
        }

        private void WaitWindow_ThreadforIPOExport()
        {
            WaitWindow waitWindow = new WaitWindow();
            waitWindow.Show();
            while (isProgressed)
            {
                waitWindow.Refresh();
            }
            waitWindow.Close();
        }

        private void btnMoneyBalance_Click(object sender, EventArgs e)
        {
            Thread thrd = new Thread(WaitWindow_ThreadforIPOExport);
            isProgressed = true;
            thrd.Start();          
            objWeb_Data_ReconcilationBAL.Trade_Money_Balance();
            Local = objWeb_Data_ReconcilationBAL.Get_Money_Balance_Local();
            Web = objWeb_Data_ReconcilationBAL.Get_Money_Balance_Web();
            FrmRecincilationSecondPart from = new FrmRecincilationSecondPart(Local, Web);
            from.Show();           
            isProgressed = false;   

            
        }

        private void btnShareDW_Click(object sender, EventArgs e)
        {
           
            Thread thrd = new Thread(WaitWindow_ThreadforIPOExport);
            isProgressed = true;
            thrd.Start();
            objWeb_Data_ReconcilationBAL.Trade_Web_Share_DW();
            Local = objWeb_Data_ReconcilationBAL.Get_Share_DW_Local();
            Web = objWeb_Data_ReconcilationBAL.Get_Share_DW_Web();
            FrmRecincilationSecondPart from = new FrmRecincilationSecondPart(Local, Web);
            from.Show();
            isProgressed = false;   
        }

        private void btnPaymentHistory_Click(object sender, EventArgs e)
        {
            Thread thrd = new Thread(WaitWindow_ThreadforIPOExport);
            isProgressed = true;
            thrd.Start();
            objWeb_Data_ReconcilationBAL.Trade_Web_payment_history();
            Local = objWeb_Data_ReconcilationBAL.Get_Payment_History_Local();
            Web = objWeb_Data_ReconcilationBAL.Get_Payment_History_Web();
            FrmRecincilationSecondPart from = new FrmRecincilationSecondPart(Local, Web);
            from.Show();
            isProgressed = false;   
        }

        private void btnShaerBalanceDetails_Click(object sender, EventArgs e)
        {
            Thread thrd = new Thread(WaitWindow_ThreadforIPOExport);
            isProgressed = true;
            thrd.Start();
            objWeb_Data_ReconcilationBAL.Trade_Web_Share_Balance_Details();
            Local = objWeb_Data_ReconcilationBAL.Get_Share_Balance_Details_Local();
            Web = objWeb_Data_ReconcilationBAL.Get_Share_Balance_Details_Web();
            FrmRecincilationSecondPart from = new FrmRecincilationSecondPart(Local, Web);
            from.Show();
            isProgressed = false;   
        }

        private void btnShareBalance_Click(object sender, EventArgs e)
        {
            Thread thrd = new Thread(WaitWindow_ThreadforIPOExport);
            isProgressed = true;
            thrd.Start();
            objWeb_Data_ReconcilationBAL.Trade_Share_Balance();
            Local = objWeb_Data_ReconcilationBAL.Get_Share_Balance_Local();
            Web = objWeb_Data_ReconcilationBAL.Get_Share_Balance_Web();
            FrmRecincilationSecondPart from = new FrmRecincilationSecondPart(Local, Web);
            from.Show();
            isProgressed = false; 
        }

        private void btnCompantProfile_Click(object sender, EventArgs e)
        {
            Thread thrd = new Thread(WaitWindow_ThreadforIPOExport);
            isProgressed = true;
            thrd.Start();
            objWeb_Data_ReconcilationBAL.Trade_Web_Company_Profile();
            Local = objWeb_Data_ReconcilationBAL.Get_Company_Profile_Local();
            Web = objWeb_Data_ReconcilationBAL.Get_Company_Profile_Web();
            FrmRecincilationSecondPart from = new FrmRecincilationSecondPart(Local, Web);
            from.Show();
            isProgressed = false; 

        }

       


        
    }
}
