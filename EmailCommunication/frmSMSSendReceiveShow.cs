using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using ElectronicCommunication.SMS;

namespace ElectronicCommunication
{
    public partial class frmSMSSendReceiveShow : Form
    {

        DbConnection objConnectionString = new DbConnection();
        private   int tinterval = 0;
        public frmSMSSendReceiveShow()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSMSSendReceiveShow_Load(object sender, EventArgs e)
        {            
            LoadData(dtbDate.Value);
            
        }

        public void LoadData(DateTime Date)
        {
            int ReceiveSMS = 0;
            int SendSMS = 0;
            int TotalSMS = 0;
            int ReceiveEmail = 0;
            int SendEmail = 0;
            int totalEmail = 0;
            int TotalWeb = 0;
            int WebUpload = 0;
            int WebReceive = 0;
            DataTable dt = new DataTable();
            string Query = @"SELECT [ID]
                                  ,'Email' AS 'Media Type'
                                  ,Case Message_Type 
				                         When 1 THEN 'Email Send'  
				                         When 0 THEN 'Email Receive' END  AS 'Message_Type' 
                                  ,[Cust_Code] 
                                  ,[ReceiveEmail] AS 'Email & SMS ID'
                                  ,Convert(Varchar(50),Entry_DateTime,108) AS 'Received & Send Time'    
                                  ,[Message]    
                                   FROM [dbksclCallCenter].[dbo].[tbl_EmailMessageLog]
                                   Where Convert(Varchar(50),Entry_DateTime,110)='" + Date.ToString("MM-dd-yyy") + @"'
                            UNION ALL
                              SELECT [ID]
                                  ,'SMS' AS 'Media Type'
                                  ,Case MessageType 
				                         When 1 THEN 'SMS Send'  
				                         When 0 THEN 'SMS Receive' END  AS 'Message_Type' 
                                  ,[Cust_Code] 
                                  ,[Mobile_No] AS 'Email & SMS ID'  
                                  ,Convert(Varchar(50),Date,108) AS 'Received & Send Time' 
                                  ,[Message]
                                   FROM [dbksclCallCenter].[dbo].[tbl_MessageLog]
                                   Where CONVERT(Varchar(50),Date,110) ='" + Date.ToString("MM-dd-yyy") + @"'
                           UNION ALL
                              Select Web_Server_ID AS ID
                                 ,'Web' AS 'Media Type'
                                 ,Case MessageType 
                                     When 1 THEN 'Web Upload'  
                                     When 0 THEN 'Web Receive' END  AS 'Message_Type'
                                  ,CustCode AS 'Cust_Code' 
                                  ,'' AS 'Email & SMS ID'   
                                  ,Convert(Varchar(50),UploadDate,108) AS 'Received & Send Time'
                                  ,Message  
                                  from tbl_Web_Server_Log 
                                  Where CONVERT(Varchar(50),ReceiveDate,110) ='" + Date.ToString("MM-dd-yyy") + "'";

            objConnectionString.ConnectDatabase_SMSSender();
            dt = objConnectionString.ExecuteQuery_SMSSender(Query);
            GrideSMSShow.DataSource = dt;

          

            foreach (DataGridViewRow dgvr in GrideSMSShow.Rows)
            {
                if (dgvr.Cells["Message_Type"].Value.ToString() == "SMS Send" && dgvr.Cells["Media Type"].Value.ToString() == "SMS")
                {
                    dgvr.DefaultCellStyle.BackColor = Color.LightGray;
                    SendSMS++;
                    TotalSMS++;
                }
               else if (dgvr.Cells["Message_Type"].Value.ToString() == "SMS Receive" && dgvr.Cells["Media Type"].Value.ToString() == "SMS")
                {
                    dgvr.DefaultCellStyle.BackColor = Color.White;
                    ReceiveSMS++;
                    TotalSMS++;
                }
               else if (dgvr.Cells["Message_Type"].Value.ToString() == "Email Send" && dgvr.Cells["Media Type"].Value.ToString() == "Email")
                {
                    dgvr.DefaultCellStyle.BackColor = Color.LightGray;
                    SendEmail++;
                    totalEmail++;
                }
               else if (dgvr.Cells["Message_Type"].Value.ToString() == "Email Receive" && dgvr.Cells["Media Type"].Value.ToString() == "Email")
                {
                    dgvr.DefaultCellStyle.BackColor = Color.White;
                    ReceiveEmail++;
                    totalEmail++;
                }
               else if (dgvr.Cells["Message_Type"].Value.ToString() == "Web Receive" && dgvr.Cells["Media Type"].Value.ToString() == "Web")
                {
                    dgvr.DefaultCellStyle.BackColor = Color.White;
                    WebReceive++;
                    TotalWeb++;
                }
                else if (dgvr.Cells["Message_Type"].Value.ToString() == "Web Upload" && dgvr.Cells["Media Type"].Value.ToString() == "Web")
                {
                    dgvr.DefaultCellStyle.BackColor = Color.LightGray;
                    WebUpload++;
                    TotalWeb++;
                }
            }
            GrideSMSShow.Columns["ID"].Visible = false;
            label3.Text = "Total SMS :"+TotalSMS;           
            label2.Text = "Total Receive SMS :"+ReceiveSMS;
            label1.Text =  "Total Send SMS :"+SendSMS;
            label5.Text = "Total Email :" + totalEmail;
            label6.Text = "Total Receive Email :" + ReceiveEmail;
            label7.Text = "Total Send Email :" + SendEmail;
            label8.Text = "Total Web :" + TotalWeb;
            label9.Text = "Total Receive Web :" + WebReceive;
            label10.Text = "Total Web Upload :" + WebUpload;

           
        }

        private void BtnLoadData_Click(object sender, EventArgs e)
        {
            LoadData(dtbDate.Value);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData(Convert.ToDateTime(System.DateTime.Now.ToShortDateString()));
        }

        private void showMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Value = GrideSMSShow.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells["Message"].Value)).FirstOrDefault();
            FrmShowMessage frm = new FrmShowMessage(Value);
            frm.Show();

        }


        #region Timer Working
        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((Convert.ToInt16(3) >= 1))
            {
                tinterval = tinterval + 1;

            }
            if (Convert.ToInt16(1) == tinterval)
            {
                label3.ForeColor = Color.Red;
                label5.ForeColor = Color.Red;
                label8.ForeColor = Color.Red;

                label2.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label9.ForeColor = Color.White;

                label1.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                label10.ForeColor = Color.White;
            }
            if (Convert.ToInt16(2) == tinterval)
            {
                label3.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label8.ForeColor = Color.White;

                label2.ForeColor = Color.Red;
                label6.ForeColor = Color.Red;
                label9.ForeColor = Color.Red;

                label1.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                label10.ForeColor = Color.White;
            }
            if (Convert.ToInt16(3) == tinterval)
            {
                label3.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label8.ForeColor = Color.White;

                label2.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label9.ForeColor = Color.White;

                label1.ForeColor = Color.Red;
                label7.ForeColor = Color.Red;
                label10.ForeColor = Color.Red;

            }
            if (Convert.ToInt16(4) == tinterval)
            {
               // tinterval = 0;


                label3.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label8.ForeColor = Color.White;

                label2.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label9.ForeColor = Color.White;

                label1.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                label10.ForeColor = Color.White;


            }
            if (Convert.ToInt16(5) == tinterval)
            {               
                label8.ForeColor = Color.Red;
                label9.ForeColor = Color.Red;
                label10.ForeColor = Color.Red;

                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.White;

                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;


            }
            if (Convert.ToInt16(6) == tinterval)
            {
                label8.ForeColor = Color.White;
                label9.ForeColor = Color.White;
                label10.ForeColor = Color.White;

                label5.ForeColor = Color.Red;
                label6.ForeColor = Color.Red;
                label7.ForeColor = Color.Red;

                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;

            }
            if (Convert.ToInt16(7) == tinterval)
            {
                label8.ForeColor = Color.White;
                label9.ForeColor = Color.White;
                label10.ForeColor = Color.White;

                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.White;

                label1.ForeColor = Color.Red;
                label2.ForeColor = Color.Red;
                label3.ForeColor = Color.Red;


            }
            if (Convert.ToInt16(8) == tinterval)
            {
                tinterval = 0;
                label8.ForeColor = Color.White;
                label9.ForeColor = Color.White;
                label10.ForeColor = Color.White;

                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.White;

                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;


            }
        }

        #endregion







    }
}
