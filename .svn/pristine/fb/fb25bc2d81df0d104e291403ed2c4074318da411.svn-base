using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ElectronicCommunication.Email;
using DataAccessLayer;
using System.Data.SqlClient;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.Constants;
using System.Threading;

namespace ElectronicCommunication
{
    public partial class frmExportIPOInformation : Form
    {

        SqlDataQuery objQuery = new SqlDataQuery();
        public DbConnection objConnectionString = new DbConnection();
        DataTable dtgrid = new DataTable();
        public static bool isProgressed;

        public frmExportIPOInformation()
        {
            InitializeComponent();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmExportIPOInformation_Load(object sender, EventArgs e)
        {
            cmbSession.SelectedIndex = -1;
            cmbSession.Text = "Select";
            LoadCombo();
            Loaddata();
            //LoadDataGride();         
        }

        public void LoadCombo()
        {
            DataTable data = new DataTable();
            data = objQuery.GetIPOSessionName(); 
            cmbSession.DataSource = data;
            //cmbSession.ValueMember = "Criteria_ID";
            cmbSession.DisplayMember = "IPOSession_Name";
            cmbSession.ValueMember = "IPO_Session_ID";
            cmbSession.SelectedIndex = -1;
            cmbSession.Text = "Select";
        }

        public void Loaddata()
        {
            dtgrid.Clear();
            dtgrid.Columns.Add("Cust_Code");
            dtgrid.Columns.Add("ID");
            dtgrid.Columns.Add("Intended_IPOSession_ID");
            dtgrid.Columns.Add("IPOSessionName");
            dtgrid.Columns.Add("IPOStatus");
            dtgrid.Columns.Add("Money_Transaction_TypeName");
            dtgrid.Columns.Add("Refund_Name");
            dtgrid.Columns.Add("Email");
            dtgrid.Columns.Add("TotalAmount");
            dtgrid.Columns.Add("Applied_Company");
            //DataRow _ravi = dtgrid.NewRow();
            //dtgrid.Rows.Add(_ravi);
        }

        public DataTable GetGridData()
        {
            int IPOSessionID ;
            string IPOSessionName = string.Empty;
            string EmailCustCode = string.Empty;
            string TransReason = string.Empty;
            string MoneyTransactionTypeName = string.Empty;
            string PaymentPostingCustCode = string.Empty;          
            string IPOStatus = string.Empty;
            string IPOAppLicationID = String.Empty;
            string RefundName = string.Empty;
            string Email = string.Empty;
            double Amount = 0.0;
            string CompanyName = string.Empty;

            try
            {
                //string Conn = Email_Constant.SBPDataBase_ConnectionString;
                //SqlConnection Connection = new SqlConnection(Conn);
                //DataSet adataset = new DataSet();
                //SqlDataAdapter aAqldataAdapter = new SqlDataAdapter();
                IPOSessionID = Convert.ToInt32(cmbSession.SelectedValue);
                DataTable dt = new DataTable();
                DataTable alreadyExportedData = GetAlreadyExportedEmail(IPOSessionID);
                string createTempTable = @"CREATE TABLE #SBP_Email_Application_Notification(
	                                        [ApplicationID] INT,
	                                        [EmailSerialNumber] INT,
	                                        [EmailType] varchar(100),
	                                        [ApplicationStatus] varchar(100),
	                                        [EmailSendingStatus] INT
                                        )";

                string insertToTempTable=string.Empty;
                foreach(DataRow dr in alreadyExportedData.Rows)
                {
                    string tempInsert=@"
                    INSERT INTO #SBP_Email_Application_Notification 
                    ([ApplicationID],[EmailType],[EmailSerialNumber],[ApplicationStatus],[EmailSendingStatus])
                    VALUES ("+Convert.ToString(dr["IPOApplicationID"])+@",'"+Indication_IPOPaymentTransaction.ApplicationSMSNotification_EmailType+"',"+Convert.ToString(dr["Email_SerialNumber"])+@",'"+Convert.ToString(dr["IPO_Status"])+@"',"+Convert.ToString(dr["Status"])+@")";
                    insertToTempTable = insertToTempTable + tempInsert;
                }

                string Query = @"Select t.Cust_Code,t.Intended_IPOSession_ID,t.Intended_IPOSession_Name,
                                t.Trans_Reason ,t.Money_TransactionType_Name ,temp.Status_Name,P.ID , M.Method_Name AS Refund_Name
                                ,(
                                    CASE 
                                        WHEN P.Cust_Code IN ( 
                                                        Select e.Child_Code 
                                                        From SBP_Parent_Child_Details as e
                                        ) 
                                        THEN (
                                                                Select dt.Handeler_Email_1
                                                                From SBP_Parent_Child_Owner_Details as dt
                                                                Where dt.Parent_Id=(
						                                                                Select g.Parent_Code
						                                                                From SBP_Parent_Child_Details as g
						                                                                Where g.Child_Code=P.Cust_Code
                                                                )
                                                                AND dt.Handeler_Email_1 LIKE '%@%.%'
                                        )
                                        ELSE 
                                        (
                                                Select reg.Email
                                                From SBP_Service_Registration as reg
                                                Where reg.Cust_Code=P.Cust_Code
                                        )
                                    END
                                ) AS Email
                                ,1 AS Email_Serial_Number	                                	
                                ,P.TotalAmount+10 AS 'TotalAmount',p.Applied_Company
                                from dbo.SBP_IPO_Customer_Broker_MoneyTransaction AS t  
                                JOIN dbo.SBP_IPO_Application_BasicInfo AS P    ON  t.ID = P.Money_Trans_Ref_ID 
                                JOIN dbo.SBP_IPO_Application_ExtendedInfo  AS R    ON R.BasicInfo_ID = P.ID 
                                JOIN dbo.SBP_IPO_Approval_Status AS temp    ON temp.ID = P .Application_Satus
                                JOIN dbo.SBP_IPO_MoneyRefund_Method AS M ON M.ID = R.Refund_Method
                                Where t.Intended_IPOSession_ID= P.IPOSession_ID AND P.Application_Satus IN (1,2,3,4,5)
                                AND NOT EXISTS(
                                                    Select * From #SBP_Email_Application_Notification as t 
                                                    Where t.ApplicationID=P.ID AND t.ApplicationStatus=(Select c.Status_Name From SBP_IPO_Approval_Status as c Where c.ID=P.Application_Satus)
                                                    AND t.EmailSendingStatus IN (0,1,2,3)					
                                )
                               AND 
                                    (
                                        EXISTS (
                                                    Select *
                                                    From SBP_Parent_Child_Owner_Details as dt
                                                    Where dt.Parent_Id=(
						                                                    Select g.Parent_Code
						                                                    From SBP_Parent_Child_Details as g
						                                                    Where g.Child_Code=P.Cust_Code
                                                    )
                                                    AND dt.Handeler_Email_1 LIKE '%@%.%'
                                        )
                                        OR 
                                        EXISTS
                                        (
                                                    Select reg.Email
                                                    From SBP_Service_Registration as reg
                                                    Where reg.Cust_Code=P.Cust_Code
                                                    And reg.Email LIKE '%@%.%'
                                        )
                                	
                                    )
                                AND t.Intended_IPOSession_ID=" + IPOSessionID + "" +
                               @"UNION ALL

	                                    Select P.Cust_Code,P.IPOSession_ID,P.IPOSession_Name,
	                                    'Application From IPO Account' ,'PIPO',temp.Status_Name,P.ID , M.Method_Name AS Refund_Name
	                                    ,(
		                                    CASE 
			                                    WHEN P.Cust_Code IN ( 
							                                    Select e.Child_Code 
							                                    From SBP_Parent_Child_Details as e
			                                    ) 
			                                    THEN (
									                                    Select dt.Handeler_Email_1
									                                    From SBP_Parent_Child_Owner_Details as dt
									                                    Where dt.Parent_Id=(
															                                    Select g.Parent_Code
															                                    From SBP_Parent_Child_Details as g
															                                    Where g.Child_Code=P.Cust_Code
									                                    )
									                                    AND dt.Handeler_Email_1 LIKE '%@%.%'
			                                    )
			                                    ELSE 
			                                    (
					                                    Select reg.Email
					                                    From SBP_Service_Registration as reg
					                                    Where reg.Cust_Code=P.Cust_Code
			                                    )
		                                    END
	                                    ) AS Email
	                                    ,1 AS Email_Serial_Number	                                	
	                                    ,P.TotalAmount+10 AS 'TotalAmount',p.Applied_Company
	                                    from 
	                                    dbo.SBP_IPO_Application_BasicInfo AS P    
	                                    JOIN dbo.SBP_IPO_Application_ExtendedInfo  AS R    ON R.BasicInfo_ID = P.ID 
	                                    JOIN dbo.SBP_IPO_Approval_Status AS temp    ON temp.ID = P .Application_Satus
	                                    JOIN dbo.SBP_IPO_MoneyRefund_Method AS M ON M.ID = R.Refund_Method
	                                    Where P.Application_Satus IN (1,2,3,4,5) AND ISNULL(P.Money_Trans_Ref_ID,0)=0
	                                    AND NOT EXISTS(
						                                    Select * From #SBP_Email_Application_Notification as t 
						                                    Where t.ApplicationID=P.ID AND t.ApplicationStatus=(Select c.Status_Name From SBP_IPO_Approval_Status as c Where c.ID=P.Application_Satus)
						                                    AND t.EmailSendingStatus IN (0,1,2,3)					
	                                    )
	                                   AND 
	                                            (
		                                            EXISTS (
					                                            Select *
					                                            From SBP_Parent_Child_Owner_Details as dt
					                                            Where dt.Parent_Id=(
											                                            Select g.Parent_Code
											                                            From SBP_Parent_Child_Details as g
											                                            Where g.Child_Code=P.Cust_Code
					                                            )
					                                            AND dt.Handeler_Email_1 LIKE '%@%.%'
		                                            )
		                                            OR 
		                                            EXISTS
		                                            (
					                                            Select reg.Email
					                                            From SBP_Service_Registration as reg
					                                            Where reg.Cust_Code=P.Cust_Code
					                                            And reg.Email LIKE '%@%.%'
		                                            )
                                            	
	                                            )
	                                     AND p.IPOSession_ID=" + IPOSessionID + "";
                                    
                //aAqldataAdapter.SelectCommand = new SqlCommand(Query, Connection);
                //aAqldataAdapter.Fill(adataset);
                string Query_Full = createTempTable + ' ' + insertToTempTable + ' ' + Query;
                
                objConnectionString.ConnectDatabase();
                objConnectionString.TimeoutPeriod = 10;
                dtgrid = objConnectionString.ExecuteQuery(Query_Full);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConnectionString.CloseDatabase();
            }

            return dtgrid;
        }

        public void LoadDataGride()
        {
            try
            {
                DataTable dt = GetGridData();
                dtgIPOFile.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private DataTable GetAlreadyExportedEmail(int SeesionID)
        {
            DataTable dt = new DataTable();
            string query = @"
                    SELECT [ID]
                          ,[IPOApplicationID]
                          ,[Cust_Code]
                          ,[Amount]
                          ,[Email]
                          ,[ReferenceID]
                          ,[Email_SerialNumber]
                          ,[IPO_Status]
                          ,[IPO_Session_ID]
                          ,[IPO_Session_Name]
                          ,[Company_Name]
                          ,[MoneyTrans_TypeName]
                          ,[Refund_Name]
                          ,[EmailType]
                          ,[FailureReason]
                          ,[Status]
                          ,[ProcessDate]
                          ,[DelivaryDate]
                    FROM [dbksclCallCenter].[dbo].[tbl_IPOConfirmation_Email] as p
                    WHERE 
                    ID=(
					                    Select ID
					                    From [tbl_IPOConfirmation_Email] as t
					                    Where  t.IPOApplicationID=p.IPOApplicationID 
					                    AND t.Email_SerialNumber=
					                    (
											                    Select MAX(e.Email_SerialNumber)
											                    From [tbl_IPOConfirmation_Email] as e
											                    Where e.IPOApplicationID=p.IPOApplicationID	
											                    --AND e.ProcessDate=CONVERT(varchar(10),GETDATE(),111)
                                                                AND e.IPO_Session_ID="+SeesionID+@"
											                    AND e.EmailType='" + Indication_IPOPaymentTransaction.ApplicationSMSNotification_EmailType+ @"'
					                    )
					                    --AND t.ProcessDate=CONVERT(varchar(10),GETDATE(),111)
                                        AND t.IPO_Session_ID="+SeesionID+@"
					                    AND t.EmailType='" + Indication_IPOPaymentTransaction.ApplicationSMSNotification_EmailType + @"'
                    )
                    --AND p.ProcessDate=CONVERT(varchar(10),GETDATE(),111)
                    AND p.EmailType='" + Indication_IPOPaymentTransaction.ApplicationSMSNotification_EmailType + @"'
                    AND p.IPO_Session_ID=" + SeesionID + @"
                    AND [Status] IN (0,1,2,3)
            ";

            try
            {
                objConnectionString.ConnectDatabase_SMSSender();
                dt=objConnectionString.ExecuteQuery_SMSSender(query);                
            
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                objConnectionString.CloseDatabase_SMSSender();
            }

            return dt;
            
        }

        private string[] ResendEmail()
        {
            string[] result = null;



            return result;

        }


        public void ExportCallCenterData(DataTable dt)
        {
            try
            {
                objQuery.ConnectCallCenterDb();

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    //try
                    //{
                        //if (i == 900)
                        //{
                        //    string kamal = "jamal";
                        //}
                        
                        String CustCode = string.Empty;
                        string IPOApplicationID = string.Empty;
                        string IPOSessionID = string.Empty;
                        String IPOSessionName = string.Empty;
                        String IPOStatus = string.Empty;
                        string IPOMoneyTransactionTypeName = string.Empty;
                        string RefundType = string.Empty;
                        string Email = string.Empty;
                        double Amount = 0.0;
                        string CompanyName = string.Empty;
                        string Email_serial_number = string.Empty;

                        string Approve_RejectEmailType = objQuery.GetIPO_EmailType("3");
                        // string RejectEmailType = objQuery.GetIPO_EmailType("3");
                        String Successfully_UnSeccessfullyEmailType = objQuery.GetIPO_EmailType("1");
                        //String UnSeccessfullyEmailType = objQuery.GetIPO_EmailType("1");

                        CustCode = dt.Rows[i]["Cust_Code"].ToString();
                        //CustCode = dr["Cust_Code"].Value.ToString();
                        IPOApplicationID = dt.Rows[i]["ID"].ToString();
                        //IPOApplicationID = dr["ID"].Value.ToString();
                        IPOSessionID = dt.Rows[i]["Intended_IPOSession_ID"].ToString();
                        //IPOSessionID = dr["Intended_IPOSession_ID"].Value.ToString();
                        IPOSessionName = dt.Rows[i]["Intended_IPOSession_Name"].ToString();
                        //IPOSessionName = dr["Intended_IPOSession_Name"].Value.ToString();
                        IPOStatus = dt.Rows[i]["Status_Name"].ToString();
                        //IPOStatus = dr["Status_Name"].Value.ToString();
                        IPOMoneyTransactionTypeName = dt.Rows[i]["Money_TransactionType_Name"].ToString();
                        //IPOMoneyTransactionTypeName = dr["Money_TransactionType_Name"].Value.ToString();
                        RefundType = dt.Rows[i]["Refund_Name"].ToString();
                        //RefundType = dr["Refund_Name"].Value.ToString();
                        Email = dt.Rows[i]["Email"].ToString();
                        //Email = dr["Email"].Value.ToString();
                        Amount = Convert.ToDouble(dt.Rows[i]["TotalAmount"].ToString());
                        //Amount = Convert.ToDouble(dr["TotalAmount"].Value.ToString());
                        CompanyName = dt.Rows[i]["Applied_Company"].ToString();
                        //CompanyName = dr["Applied_Company"].Value.ToString();
                        Email_serial_number = dt.Rows[i]["Email_Serial_Number"].ToString();
                        //Email_serial_number = dr["Email_Serial_Number"].Value.ToString();


                        //if (IPOStatus.ToLower() == ("Approved").ToLower())
                        //{
                            objQuery.IPOApproveDataInsert(CustCode, Email, Amount, IPOSessionID, IPOSessionName, CompanyName, Approve_RejectEmailType, "null", "0", IPOStatus, IPOApplicationID, IPOMoneyTransactionTypeName, RefundType, Email_serial_number);
                            //dtgIPOFile.Rows.RemoveAt(dtgIPOFile.Rows[i].Index);
                            //label1.Text = "Count : " + dtgrid.Rows.Count;
                            //label1.ForeColor = Color.White;
                        //}

                        //else if (IPOStatus.ToLower() == ("Rejected").ToLower())
                        //{
                        //    objQuery.IPOApproveDataInsert(CustCode, Email, Amount, IPOSessionID, IPOSessionName, CompanyName, Approve_RejectEmailType, "null", "0", IPOStatus, IPOApplicationID, IPOMoneyTransactionTypeName, RefundType, Email_serial_number);
                        //    //dtgIPOFile.Rows.RemoveAt(dtgIPOFile.Rows[i].Index);
                        //    //label1.Text = "Count : " + dtgrid.Rows.Count;
                        //    //label1.ForeColor = Color.White;
                        //}

                        //else if (IPOStatus.ToLower() == ("Successfull").ToLower())
                        //{
                        //    objQuery.IPOApproveDataInsert(CustCode, Email, Amount, IPOSessionID, IPOSessionName, CompanyName, Successfully_UnSeccessfullyEmailType, "null", "0", IPOStatus, IPOApplicationID, IPOMoneyTransactionTypeName, RefundType, Email_serial_number);
                        //    //dtgIPOFile.Rows.RemoveAt(dtgIPOFile.Rows[i].Index);
                        //    //label1.Text = "Count : " + dtgrid.Rows.Count;
                        //    //label1.ForeColor = Color.White;
                        //}

                        //else if (IPOStatus.ToLower() == ("Unsuccessfull").ToLower())
                        //{
                        //    objQuery.IPOApproveDataInsert(CustCode, Email, Amount, IPOSessionID, IPOSessionName, CompanyName, Successfully_UnSeccessfullyEmailType, "null", "0", IPOStatus, IPOApplicationID, IPOMoneyTransactionTypeName, RefundType, Email_serial_number);
                        //    //dtgIPOFile.Rows.RemoveAt(dtgIPOFile.Rows[i].Index);
                        //    //label1.Text = "Count : " + dtgrid.Rows.Count;
                        //    //label1.ForeColor = Color.White;
                        //}
                    //}
                    //catch (Exception ex)
                    //{
                    //    string Kamal = "Kamal";
                    //}
                }
                objQuery.CommitCallCenterDb();
                //MessageBox.Show("Data Exported Successfully!!");
                LoadDataGride();
            }
            catch (Exception ex)
            {
                objQuery.RollBackCallCenterDb();
                MessageBox.Show("Data Exported Fail, Error: "+ex.Message);
            }
            finally
            {
                objQuery.CloseCallCenterDB();
            }
        }
        private void ExportParentChildInfo()
        {
            SMSSyncBAL bal = new SMSSyncBAL();
            try
            {
                bal.Connect_SBP();
                bal.Connect_SMS();

                bal.TruncateTable_SMSSyncExport_AccountGrouping_Info_UITransApplied();
                SqlDataReader dr_AccountGrouping = bal.GetIPO_AccountGrouping_Info_UITransApplied();
                bal.InsertTable_SMSSyncExport_AccountGrouping_Info_UITransApplied(dr_AccountGrouping);

                bal.Commit_SBP();
                bal.Commit_SMS();
            }
            catch (Exception ex)
            {
                bal.Rollback_SBP();
                bal.Rollback_SMS();
            }
            finally
            {
                bal.CloseConnection_SBP();
                bal.CloseConnection_SMS();
            }

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Thread thrd = new Thread(WaitWindow_ThreadforIPOExport);
                isProgressed = true;
                thrd.Start();
                DataTable dt = GetGridData();
                ExportParentChildInfo();
                objQuery.Truncate_Table_IPO_Conformation_Email(cmbSession.Text.Trim());
                ExportCallCenterData(dt);
                isProgressed = false;
                MessageBox.Show("Data Export Successfully.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem Found in Export "+ex.Message);
            }
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



        private void btnSearch_Click(object sender, EventArgs e)
        {
            dtgrid.Clear();
            LoadDataGride();
            dtgIPOFile.DataSource = dtgrid;
            label1.Text = "Count : " + dtgrid.Rows.Count;
            label1.ForeColor = Color.White;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dtgIPOFile.SelectedRows)
            {
                dtgIPOFile.Rows.RemoveAt(item.Index);              
            }
        }

       
       

       
    }
}
