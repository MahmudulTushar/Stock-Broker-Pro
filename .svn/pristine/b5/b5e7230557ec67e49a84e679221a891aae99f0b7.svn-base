using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using System.IO;
using System.Threading;
using Reports;
using CrystalDecisions.CrystalReports.Engine;

namespace StockbrokerProNewArch
{
    public partial class frm_Import_DP29 : Form
    {
        private enum FormState { SelectAll_IsClosed_Completed,SelectAll_IsClosed_Starting, FormLoad, Dp19TempFileTrancate, Dp29FileImport_Start, Dp29FileImport_End, Dp29FileCheck_Start, Dp29FileCheck_End, Dp29FileProcess_Start, Dp29FileProcess_End, DP29WorkProgressing, DP29WorkCompleted };
        private delegate void StatusMessageShow(string Text);
        private List<KeyValuePair<string, string>> ColumnsListToBeUpdated;
        public struct DgClientInfo_ColumnsName
        {
            public string CustCode;
            public string BOID;
            public string BOTYPE;
            public string BOCatg;
            public string FullName;
            public string ShortName;
            public string Address;
            public string City;
            public string State;
            public string Country;
            public string PurposeCode;
            public string Residency;
            public string Phone;
            public string Email;
            public string Fax;
            public string SetupDate;
            public string BoStatus;
            public string ClosureDate;
            public string FatherName;
            public string MotherName;
            public string BankName;
            public string BranchName;
            public string AccNo;
            public string Routing_No;
            public string Bank_Identification_Code;
            public string IBAN;
            public string SWIFT_Code;
            public string Suspense_Flag;
            public string Bo_Suspened_Date;
            public string Suspense_Reason_Code;
            public string Second_Holder_Name;
            public string Occupation;
            public string Date_of_Birth;
            public string Gender;
            public string BO_Nationality;
            public string Tax_ID_Number;
            public string Origin_of_BO;
            public string IsForcedAccClosed;
        };
        public DgClientInfo_ColumnsName dgClientInfoColumnsObj = new DgClientInfo_ColumnsName()
                {
                    AccNo = "AccountNo",
                    Address = "Address",
                    BankName = "BankName",
                    BOCatg = "BoCategory",
                    BOID = "BoId",
                    BoStatus = "BoStatus",
                    BOTYPE = "BoType",
                    BranchName = "BranchName",
                    City = "City",
                    ClosureDate = "ClosureDate",
                    Country = "Country",
                    CustCode = "InternalReferenceNo",
                    Email = "Email",
                    FatherName = "FatherName",
                    Fax = "Fax",
                    FullName = "CustomerFullName",
                    MotherName = "MotherName",
                    Phone = "Phone",
                    PurposeCode = "PurposeCode",
                    Residency = "Residency",
                    SetupDate = "SetupDate",
                    ShortName = "CustomerShortName",
                    State = "Satate",
                    Routing_No = "Routing_No",
                    Bank_Identification_Code = "Bank_Identification_Code",
                    IBAN="IBAN",
                    SWIFT_Code = "SWIFT_Code",
                    Suspense_Flag = "Suspense_Flag",
                    Bo_Suspened_Date = "Bo_Suspened_Date",
                    Suspense_Reason_Code = "Suspense_Reason_Code",
                    Second_Holder_Name = "Second_Holder_Name",
                    Occupation = "Occupation",
                    Date_of_Birth = "Date_of_Birth",
                    Gender = "Gender",
                    BO_Nationality = "BO_Nationality",
                    Tax_ID_Number = "Tax_ID_Number",
                    Origin_of_BO = "Origin_of_BO",
                    IsForcedAccClosed = "IsForcedAccClosed"

                };
        private bool selectAll_IsColsedError_Falg;
        private string BO_Status;
        private string BO_Category;

        public frm_Import_DP29()
        {
            InitializeComponent();
            ColumnsListToBeUpdated = new List<KeyValuePair<string, string>>();
        }
        private void FormStateExecution(FormState fst)
        {
            switch (fst)
            {
                case FormState.FormLoad:
                    {
                        tSStatusLabel_Progress_Comment.Visible = true;
                        tSProgressBar_dp29Import.Visible = false;
                        chk_SelectAll.Visible = false;
                        chk_SelectAll.Enabled = false;
                        lbl_SelectAll.Visible = false;
                        btnCheck.Enabled = false;
                        btnProcess.Enabled = false;
                        dgvClientInfo.Enabled = true;
                        break;
                    }
                case FormState.Dp19TempFileTrancate:
                    {
                        tSStatusLabel_Progress_Comment.Visible = true;
                        tSProgressBar_dp29Import.Visible = false;
                        chk_SelectAll.Visible = false;
                        chk_SelectAll.Enabled = false;
                        lbl_SelectAll.Visible = false;
                        btnCheck.Enabled = false;
                        btnProcess.Enabled = false;
                        break;
                    }
                case FormState.Dp29FileImport_Start:
                    {
                        Height = 365;
                        tSProgressBar_dp29Import.Value = 0;
                        tSStatusLabel_Progress_Comment.Visible = true;
                        tSProgressBar_dp29Import.Visible = true;
                        chk_SelectAll.Visible = false;
                        chk_SelectAll.Enabled = false;
                        lbl_SelectAll.Visible = false;
                        btnCheck.Enabled = false;
                        btnProcess.Enabled = false;
                        dgvClientInfo.Enabled = false;
                        break;
                    }
                case FormState.Dp29FileImport_End:
                    {
                        Height = 365;
                        tSStatusLabel_Progress_Comment.Visible = true;
                        tSProgressBar_dp29Import.Visible = false;
                        chk_SelectAll.Visible = true;
                        chk_SelectAll.Enabled = true;
                        lbl_SelectAll.Visible = true;
                        btnCheck.Enabled = true;
                        btnProcess.Enabled = false;
                        dgvClientInfo.Enabled = true;
                        break;
                    }
                case FormState.Dp29FileCheck_Start:
                    {
                        Height = 365;
                        tSProgressBar_dp29Import.Value = 0;
                        tSStatusLabel_Progress_Comment.Visible = true;
                        tSProgressBar_dp29Import.Visible = true;
                        chk_SelectAll.Visible = true;
                        chk_SelectAll.Enabled = true;
                        lbl_SelectAll.Visible = true;
                        btnCheck.Enabled = true;
                        btnProcess.Enabled = false;
                        dgvClientInfo.Enabled = false;
                        break;
                    }
                case FormState.Dp29FileCheck_End:
                    {
                        Height = 365;
                        tSStatusLabel_Progress_Comment.Visible = true;
                        tSProgressBar_dp29Import.Visible = false;
                        chk_SelectAll.Visible = true;
                        chk_SelectAll.Enabled = true;
                        lbl_SelectAll.Visible = true;
                        btnCheck.Enabled = true;
                        btnProcess.Enabled = true;
                        dgvClientInfo.Enabled = true;
                        break;
                    }
                case FormState.Dp29FileProcess_Start:
                    {
                        Height = 365;
                        tSProgressBar_dp29Import.Value = 0;
                        tSStatusLabel_Progress_Comment.Visible = true;
                        tSProgressBar_dp29Import.Visible = true;
                        chk_SelectAll.Visible = true;
                        chk_SelectAll.Enabled = false;
                        lbl_SelectAll.Visible = true;
                        btnCheck.Enabled = true;
                        btnProcess.Enabled = true;
                        break;
                    }
                case FormState.Dp29FileProcess_End:
                    {
                        Height = 365;
                        tSStatusLabel_Progress_Comment.Visible = true;
                        tSProgressBar_dp29Import.Visible = false;
                        chk_SelectAll.Visible = true;
                        chk_SelectAll.Enabled = true;
                        lbl_SelectAll.Visible = true;
                        btnCheck.Enabled = true;
                        btnProcess.Enabled = true;
                        break;
                    }
                case FormState.DP29WorkProgressing:
                    {
                        btnStartImport.Enabled = false;
                        btnCheck.Enabled = false;
                        btnProcess.Enabled = false;
                        dgvClientInfo.Enabled = false;
                        break;
                    }
                case FormState.DP29WorkCompleted:
                    {
                        btnStartImport.Enabled = true;
                        btnCheck.Enabled = true;
                        btnProcess.Enabled = true;
                        dgvClientInfo.Enabled = true;
                        break;
                    }
                case FormState.SelectAll_IsClosed_Starting:
                    {
                        //tSStatusLabel_Progress_Comment.Visible = true;
                        tSProgressBar_dp29Import.Visible = true;
                        dgvClientInfo.Enabled = false;
                        break;
                    }
                case FormState.SelectAll_IsClosed_Completed:
                    {
                        //tSStatusLabel_Progress_Comment.Visible = false;
                        tSProgressBar_dp29Import.Visible = false;
                        dgvClientInfo.Enabled = true;
                        break;
                    }
           }
        }

        private bool Validation_FileDp19()
        {
            bool result;
            result = true;
            if (txtFileLocation.Text.Trim() == string.Empty)
            {
                MessageBox.Show("No file is Selceted.", "File Upload", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                result = false;
            }
            else if (txtFileLocation.Text.Trim() != string.Empty && ofdFileOpen.FileName.Length == 0)
            {
                MessageBox.Show("No data Exists in the selection File.", "File Upload", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                result = false;
            }

            return result;
        }

        private void Validation_CustCodeBoId(DataRow dr, ref ListBox inputList)
        {
            CustomerBO_DP29BAL balObj = new CustomerBO_DP29BAL();

            if (!balObj.Check_CustCodeBOID(dr[dgClientInfoColumnsObj.CustCode].ToString(), dr[dgClientInfoColumnsObj.BOID].ToString()))
            {
                inputList.Items.Add(dr[dgClientInfoColumnsObj.CustCode] + " ~ " + dr[dgClientInfoColumnsObj.BOID]);
            }
        }

        private void Validation_BoStatusChangedFlow(DataRow dr, ref ListBox inputList)
        {
            CustomerBO_DP29BAL balObj = new CustomerBO_DP29BAL();

            if (!balObj.Check_BOSatusChangedFlow(dr[dgClientInfoColumnsObj.CustCode].ToString(), dr[dgClientInfoColumnsObj.BoStatus].ToString()))
            {
                inputList.Items.Add(dr[dgClientInfoColumnsObj.CustCode] + " ~ " + dr[dgClientInfoColumnsObj.BoStatus]);
            }

        }

        private void Validation_SetupDateChanged(DataRow dr, ref ListBox inputList)
        {
            CustomerBO_DP29BAL balObj = new CustomerBO_DP29BAL();

            if (balObj.Check_SetUpDateChanged(dr[dgClientInfoColumnsObj.CustCode].ToString(), Convert.ToString(dr[dgClientInfoColumnsObj.SetupDate])))
            {
                inputList.Items.Add(dr[dgClientInfoColumnsObj.CustCode] + " ~ " + dr[dgClientInfoColumnsObj.SetupDate]);
            }

        }

        private void Validation_ClosureDateChanged(DataRow dr, ref ListBox inputList)
        {
            CustomerBO_DP29BAL balObj = new CustomerBO_DP29BAL();

            if (balObj.Check_ClosureDateChanged(dr[dgClientInfoColumnsObj.CustCode].ToString(), Convert.ToString(dr[dgClientInfoColumnsObj.ClosureDate])))
            {
                inputList.Items.Add(dr[dgClientInfoColumnsObj.CustCode] + " ~ " + dr[dgClientInfoColumnsObj.ClosureDate]);
            }

        }

        private void dgvClientInfo_Load()
        {
            CustomerBO_DP29BAL objBO29BAL = new CustomerBO_DP29BAL();
            dgvClientInfo.DataSource = objBO29BAL.GetClientBOInfo();
        }

        private void Process_UpdateedByDP29(DataTable dt)
        {
            CustomerBO_DP29BAL DP29BAL = new CustomerBO_DP29BAL();
            List<DataRow> DataTobeInserted = new List<DataRow>();
            int State = 0;
            backgroundWorker_dp29Process.ReportProgress(0, State);
            try
            {
                try
                {
                    int maximumValue = dt.Rows.Count;
                    int progressedValue = 1;
                    State = 1;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!DP29BAL.Check_BOSatusChangedFlow(dr[dgClientInfoColumnsObj.CustCode].ToString(), dr[dgClientInfoColumnsObj.BoStatus].ToString()))
                            continue;
                        //if (DP29BAL.Check_ClosureDateChanged(dr[dgClientInfoColumnsObj.CustCode].ToString(), dr[dgClientInfoColumnsObj.ClosureDate].ToString()))
                            //continue;
                        if (!DP29BAL.Check_CustCodeBOID(dr[dgClientInfoColumnsObj.CustCode].ToString(), dr[dgClientInfoColumnsObj.BOID].ToString()))
                            continue;
                        //if (DP29BAL.Check_SetUpDateChanged(dr[dgClientInfoColumnsObj.CustCode].ToString(), dr[dgClientInfoColumnsObj.SetupDate].ToString()))
                            //continue;
                        DataTobeInserted.Add(dr);
                        //DP29BAL.UpdateRowDP29(dr[dgClientInfoColumnsObj.BOID].ToString());
                        progressedValue++;
                        if (maximumValue != 0)
                            backgroundWorker_dp29Process.ReportProgress((progressedValue * 100) / maximumValue, State);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                try
                {
                    DP29BAL.ConnectionOpen();
                    DP29BAL.BeginTransaction();

                    int maximumValue = DataTobeInserted.Count;
                    int progressedValue = 1;
                    State = 2;
                    foreach (DataRow dr in DataTobeInserted)
                    {
                        DP29BAL.UpdateRowDP29(

                              dr[dgClientInfoColumnsObj.BOID].ToString()
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.BOTYPE).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.BOCatg).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.FullName).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.ShortName).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.Address).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.City).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.State).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.Country).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.PurposeCode).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.Residency).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.Phone).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.Fax).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.Email).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.CustCode).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.SetupDate).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.BoStatus).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.FatherName).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.MotherName).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.BankName).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.BranchName).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t=> t.Key==dgClientInfoColumnsObj.AccNo).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t => t.Key==dgClientInfoColumnsObj.Routing_No).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t => t.Key==dgClientInfoColumnsObj.Bank_Identification_Code).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t => t.Key==dgClientInfoColumnsObj.IBAN).SingleOrDefault().Value)
                            ,Convert.ToBoolean(ColumnsListToBeUpdated.Where(t => t.Key==dgClientInfoColumnsObj.SWIFT_Code).SingleOrDefault().Value)

                            , Convert.ToBoolean(ColumnsListToBeUpdated.Where(t => t.Key == dgClientInfoColumnsObj.Suspense_Flag).SingleOrDefault().Value)
                            , Convert.ToBoolean(ColumnsListToBeUpdated.Where(t => t.Key == dgClientInfoColumnsObj.Bo_Suspened_Date).SingleOrDefault().Value)
                            , Convert.ToBoolean(ColumnsListToBeUpdated.Where(t => t.Key == dgClientInfoColumnsObj.Suspense_Reason_Code).SingleOrDefault().Value)
                            , Convert.ToBoolean(ColumnsListToBeUpdated.Where(t => t.Key == dgClientInfoColumnsObj.Second_Holder_Name).SingleOrDefault().Value)
                            , Convert.ToBoolean(ColumnsListToBeUpdated.Where(t => t.Key == dgClientInfoColumnsObj.Occupation).SingleOrDefault().Value)
                            , Convert.ToBoolean(ColumnsListToBeUpdated.Where(t => t.Key == dgClientInfoColumnsObj.Date_of_Birth).SingleOrDefault().Value)
                            , Convert.ToBoolean(ColumnsListToBeUpdated.Where(t => t.Key == dgClientInfoColumnsObj.Gender).SingleOrDefault().Value)
                            , Convert.ToBoolean(ColumnsListToBeUpdated.Where(t => t.Key == dgClientInfoColumnsObj.BO_Nationality).SingleOrDefault().Value)
                            , Convert.ToBoolean(ColumnsListToBeUpdated.Where(t => t.Key == dgClientInfoColumnsObj.Tax_ID_Number).SingleOrDefault().Value)
                            , Convert.ToBoolean(ColumnsListToBeUpdated.Where(t => t.Key == dgClientInfoColumnsObj.Origin_of_BO).SingleOrDefault().Value)
                 

                            );
                        progressedValue++;
                        if (maximumValue != 0)
                            backgroundWorker_dp29Process.ReportProgress((progressedValue * 100) / maximumValue, State);
                    }

                    DP29BAL.CommitTransaction();
                    MessageBox.Show(@"DP29 Data Updated Successfully");
                }
                catch (Exception ex)
                {
                    DP29BAL.RollBackTransaction();
                    throw ex;
                }
                finally
                {
                    DP29BAL.CloseConnection();
                }
                State = 3;
                backgroundWorker_dp29Process.ReportProgress(100, 3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<ListBox> CheckDP29Data()
        {
            List<ListBox> result = new List<ListBox>();
            DataTable dtDP29 = new DataTable();
            CustomerBO_DP29BAL DP29BAL = new CustomerBO_DP29BAL();
            dtDP29 = DP29BAL.GetClientBOInfo();

            ListBox lboCustCodeBoId_Error_Temp = new ListBox();
            lboCustCodeBoId_Error_Temp.Name = "lboCustCodeBoId_Error_Temp";
            ListBox lbStatusFlow_Error_Temp = new ListBox();
            lbStatusFlow_Error_Temp.Name = "lbStatusFlow_Error_Temp";
            ListBox lbSetupDate_Error_Temp = new ListBox();
            lbSetupDate_Error_Temp.Name = "lbSetupDate_Error_Temp";
            ListBox lbClosureDate_Error_Temp = new ListBox();
            lbClosureDate_Error_Temp.Name = "lbClosureDate_Error_Temp";
            int State = 0;
            backgroundWorker_dp29Check.ReportProgress(0, State);
            try
            {
                State = 1;
                int maximumValue = dtDP29.Rows.Count;
                int progressedValue = 1;
                foreach (DataRow dr in dtDP29.Rows)
                {
                    Validation_ClosureDateChanged(dr, ref lbClosureDate_Error_Temp);
                    Validation_SetupDateChanged(dr, ref lbSetupDate_Error_Temp);
                    Validation_BoStatusChangedFlow(dr, ref lbStatusFlow_Error_Temp);
                    Validation_CustCodeBoId(dr, ref lboCustCodeBoId_Error_Temp);

                    progressedValue = progressedValue + 1;
                    if (maximumValue != 0)
                        backgroundWorker_dp29Check.ReportProgress((progressedValue * 100) / maximumValue, State);
                }
                result.Add(lboCustCodeBoId_Error_Temp);
                result.Add(lbStatusFlow_Error_Temp);
                result.Add(lbSetupDate_Error_Temp);
                result.Add(lbClosureDate_Error_Temp);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            State = 2;
            backgroundWorker_dp29Check.ReportProgress(100, State);
            return result;
        }

        private void ProcessBO_29()
        {

            int State = 0;
            backgroundWorker_dp29Import.ReportProgress(0, State);
            if (Validation_FileDp19())
            {
                CustomerBO_DP29Collection objCustomerBO_DP29Collection = new CustomerBO_DP29Collection();
                objCustomerBO_DP29Collection = GetCustomerCollection(ofdFileOpen.FileName);
                CustomerBO_DP29BAL objCustomerDP29BAL = new CustomerBO_DP29BAL();
                //objCustomerDP29BAL.ConnectionOpen();
                //objCustomerDP29BAL.BeginTransaction();
                State = 1;
                int maximumValue = objCustomerBO_DP29Collection.Count;
                int progressedValue = 1;
                //progress.Maximum = objCustomerBO_DP29Collection.Count;
                //lbProText.Text = "Uploading...";                    
                try
                {
                    foreach (CustomerBO_DP29 objCustomerBO_DP29 in objCustomerBO_DP29Collection)
                    {
                        objCustomerDP29BAL.InsertCustomerBO_DP29(objCustomerBO_DP29);
                        //objCustomerDP29BAL.InsertCustomerBO_DP29_WithTransaction(objCustomerBO_DP29);
                        //progress.Value = progress.Value + 1;
                        progressedValue = progressedValue + 1;
                        if (maximumValue != 0)
                            backgroundWorker_dp29Import.ReportProgress((progressedValue * 100) / maximumValue, State);
                    }
                    MessageBox.Show("Sucessfully Uploaded File Information");
                    //objCustomerDP29BAL.CommitTransaction();
                    State = 2;
                    backgroundWorker_dp29Import.ReportProgress(100, (object)State);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Uploaded File Failed");
                    //objCustomerDP29BAL.RollBackTransaction();
                    State = 3;
                    backgroundWorker_dp29Import.ReportProgress(100, State);
                }
                finally
                {
                    //objCustomerDP29BAL.CloseConnection();
                }
            }

        }

        private bool SelectAll_IsClosed()
        {
        //this.Cursor = Cursors.WaitCursor;

            bool result = true;
            CustomerBO_DP29BAL obj = new CustomerBO_DP29BAL();
            bool ValueChecked = chk_SelectAll.Checked;
            int progressedValue=1;
            //obj.ConnectionOpen();
            //obj.BeginTransaction();
            
            int State = 0;
            backgroundWorker_selectAll_IsClosed.ReportProgress(0, State);
            int maximumValue = dgvClientInfo.Rows.Count;
            try
            {

                State = 1;
                for (int count = 0; count < dgvClientInfo.Rows.Count; count++)
                {
                    //dgvClientInfo.Rows[count].Cells[dgClientInfoColumnsObj.IsForcedAccClosed].Value = ValueChecked;                    
                    //if (count == 12)
                    //{
                    //    throw new Exception();
                    //}
                    var objBO = MapBack_DP29FromGrid(count);
                    objBO.IsForcedAccClosed = ValueChecked;
                    //obj.UpdateCustomerBO_DP29_WithTransaction(objBO);
                    obj.UpdateCustomerBO_DP29(objBO);
                    //obj.UpdateCustomerBO_DP29(objBO);
                    progressedValue = progressedValue + 1;
                    if (maximumValue != 0)
                        backgroundWorker_selectAll_IsClosed.ReportProgress((progressedValue * 100) / maximumValue, State);
                }
                //obj.CommitTransaction();
                
                State = 2;
                backgroundWorker_selectAll_IsClosed.ReportProgress(100, State);
                result = true;

                //checkBox1_CheckAll();
                //string message = "Changes Saved Successfully!!";
                //this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });

            }
            catch (Exception ex)
            {
                //obj.RollBackTransaction();
                State = 3;
                backgroundWorker_selectAll_IsClosed.ReportProgress(100, State);
                result = false;    
            }
            finally
            {
               // obj.CloseConnection();
            }
            //this.Cursor = null;
            return result;
        }

        private CustomerBO_DP29Collection GetCustomerCollection(string filepath)
        {
            const char existingChar = '~';
            CustomerBO_DP29Collection objCustomerBO_DP29Collection = new CustomerBO_DP29Collection();
            StreamReader streamReader = new StreamReader(filepath);
            int count = 1;
            try
            {
                while (streamReader.Peek() > 0)
                {
                    string[] Info = streamReader.ReadLine().Split(existingChar);
                    CustomerBO_DP29 objCustomerBO = new CustomerBO_DP29();
                   
                    objCustomerBO.BoId = Info[0].Replace("'", "''");
                    objCustomerBO.BoType = Info[1].Replace("'", "''");
                    objCustomerBO.BoCategory = Info[2].Replace("'", "''");
                    objCustomerBO.CustomerFullName = Info[3].Replace("'", "''");
                    objCustomerBO.CustomerShortName = Info[4].Replace("'", "''");
                    objCustomerBO.Address = Info[5].Replace("'", "''");
                    objCustomerBO.City = Info[6].Replace("'", "''");
                    objCustomerBO.Satate = Info[7].Replace("'", "''");
                    objCustomerBO.Country = Info[8].Replace("'", "''");
                    objCustomerBO.PurposeCode = Info[9].Replace("'", "''");
                    objCustomerBO.Residency = Info[10].Replace("'", "''");
                    objCustomerBO.Phone = Info[11].Replace("'", "''");
                    objCustomerBO.Fax = Info[12].Replace("'", "''");
                    objCustomerBO.Email = Info[13].Replace("'", "''");
                    objCustomerBO.InternalReferenceNo = Info[14].Replace("'", "''");
                    objCustomerBO.SetupDate = Info[15].Replace("'", "''");
                    objCustomerBO.BoStatus = Info[16].Replace("'", "''");
                    objCustomerBO.ClosureDate = Info[17].Replace("'", "''");
                    objCustomerBO.FatherName = Info[18].Replace("'", "''");
                    objCustomerBO.MotherName = Info[19].Replace("'", "''");
                    objCustomerBO.BankName = Info[20].Replace("'", "''");
                    objCustomerBO.BranchName = Info[21].Replace("'", "''");
                    objCustomerBO.AccountNo = Info[22].Replace("'", "''");
                    objCustomerBO.Routing_No = Info[23].Replace("'", "''");
                    objCustomerBO.Bank_Identification_Code = Info[24].Replace("'", "''");
                    objCustomerBO.IBAN = Info[25].Replace("'", "''");
                    objCustomerBO.SWIFT_Code = Info[26].Replace("'", "''");

                    objCustomerBO.Suspense_Flag = Info[27].Replace("'", "''");
                    objCustomerBO.Bo_Suspened_Date =Info[28].Replace("'", "''").Trim();
                    objCustomerBO.Suspense_Reason_Code = Info[29].Replace("'", "''");
                    objCustomerBO.Second_Holder_Name = Info[30].Replace("'", "''");
                    objCustomerBO.Occupation = Info[31].Replace("'", "''");
                    objCustomerBO.Date_of_Birth = Info[32].Replace("'", "''");
                    objCustomerBO.Gender = Info[33].Replace("'", "''");
                    objCustomerBO.BO_Nationality = Info[34].Replace("'", "''");
                    objCustomerBO.Tax_ID_Number = Info[35].Replace("'", "''");
                    objCustomerBO.Origin_of_BO = Info[36].Replace("'", "''");


                    objCustomerBO_DP29Collection.Add(objCustomerBO);
                    count++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return objCustomerBO_DP29Collection;
        }

        private DataTable GetClientBOInformation()
        {
            CustomerBO_DP29BAL objBO29BAL = new CustomerBO_DP29BAL();
            DataTable data = new DataTable();
            try
            {
                data = objBO29BAL.GetClientBOInfo();
                //dgvClientInfo.DataSource = data;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }

        private void backgroundWorker_dp29Import_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (Convert.ToInt32(e.UserState) == 0)
            {
                FormStateExecution(FormState.DP29WorkProgressing);
            }
            else if (Convert.ToInt32(e.UserState) == 1)
            {
                string message = "Importing..";
                this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
            }
            else if (Convert.ToInt32(e.UserState) == 2)
            {
                string message = "Importing Completed";
                this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
                FormStateExecution(FormState.DP29WorkCompleted);
            }
            else if (Convert.ToInt32(e.UserState) == 3)
            {
                string message = "Importing Failed";
                this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
                FormStateExecution(FormState.DP29WorkCompleted);                
            }

            tSProgressBar_dp29Import.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_dp29Import_DoWork(object sender, DoWorkEventArgs e)
        {
            ProcessBO_29();            
        }

        private void backgroundWorker_dp29Import_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FormStateExecution(FormState.Dp29FileImport_End);
            string message = "";
            this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
            dgvClientInfo_Load();
        }

        private void backgroundWorker_dp29Check_DoWork(object sender, DoWorkEventArgs e)
        {
            List<ListBox> resultData = CheckDP29Data();
            e.Result = resultData;
        }

        private void backgroundWorker_dp29Check_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (Convert.ToInt32(e.UserState) == 0)
            {
                FormStateExecution(FormState.DP29WorkProgressing);
            }
            else if (Convert.ToInt32(e.UserState) == 1)
            {
                string message = "Checking..";
                this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
            }
            else if (Convert.ToInt32(e.UserState) == 2)
            {
                string message = "Checking Completed";
                this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
                FormStateExecution(FormState.DP29WorkCompleted);
            }
            tSProgressBar_dp29Import.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_dp29Check_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FormStateExecution(FormState.Dp29FileCheck_End);
            string message = "";
            this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });

            lbClosureDate_Error.Items.Clear();
            lboCustCodeBoId_Error.Items.Clear();
            lbSetupDate_Error.Items.Clear();
            lbStatusFlow_Error.Items.Clear();

            List<ListBox> result = (List<ListBox>)e.Result;
            foreach (var obj in result)
            {
                if ((obj.Name).Replace("_Temp", "") == lbClosureDate_Error.Name)
                {
                    foreach (var objNested in obj.Items)
                        lbClosureDate_Error.Items.Add(objNested);
                }
                if ((obj.Name).Replace("_Temp", "") == lboCustCodeBoId_Error.Name)
                {
                    foreach (var objNested in obj.Items)
                        lboCustCodeBoId_Error.Items.Add(objNested);
                }
                if ((obj.Name).Replace("_Temp", "") == lbSetupDate_Error.Name)
                {
                    foreach (var objNested in obj.Items)
                        lbSetupDate_Error.Items.Add(objNested);
                }
                if ((obj.Name).Replace("_Temp", "") == lbStatusFlow_Error.Name)
                {
                    foreach (var objNested in obj.Items)
                        lbStatusFlow_Error.Items.Add(objNested);
                }
            }
            if (lbClosureDate_Error.Items.Count > 0 || lboCustCodeBoId_Error.Items.Count > 0 || lbSetupDate_Error.Items.Count > 0 || lbStatusFlow_Error.Items.Count > 0)
            {
                Height = 544;
            }

            message = "";
            this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
        }

        private void backgroundWorker_dp29Process_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dtDP29 = new DataTable();
            CustomerBO_DP29BAL DP29BAL = new CustomerBO_DP29BAL();
            dtDP29 = DP29BAL.GetDP29AllData_ForUpdateDatabase();
            Process_UpdateedByDP29(dtDP29);
        }

        private void backgroundWorker_dp29Process_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (Convert.ToInt32(e.UserState) == 0)
            {
                FormStateExecution(FormState.DP29WorkProgressing);
            }
            else if (Convert.ToInt32(e.UserState) == 1)
            {
                string message = "Preparing Data";
                this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
            }
            else if (Convert.ToInt32(e.UserState) == 2)
            {
                string message = "Data Updating";
                this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
            }
            else if (Convert.ToInt32(e.UserState) == 3)
            {
                string message = "Process Completed";
                this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
                FormStateExecution(FormState.DP29WorkCompleted);
            }
            tSProgressBar_dp29Import.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_dp29Process_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FormStateExecution(FormState.Dp29FileProcess_End);
            string message = "";
            this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
            CustomerBO_DP29BAL objBO29BAL = new CustomerBO_DP29BAL();
            dgvClientInfo.DataSource = null;
            dgvClientInfo.DataSource = objBO29BAL.GetClientBOInfo();

        }

        private void backgroundWorker_selectAll_IsClosed_DoWork(object sender, DoWorkEventArgs e)
        {
                bool result=SelectAll_IsClosed();
                e.Result = result;
        }

        private void backgroundWorker_selectAll_IsClosed_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (Convert.ToInt32(e.UserState) == 0)
            {
                string message = "Starting The Process";
                this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
                FormStateExecution(FormState.SelectAll_IsClosed_Starting);
            }
            else if (Convert.ToInt32(e.UserState) == 1)
            {
                string message = "Please Wait";
                this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
            }
            else if (Convert.ToInt32(e.UserState) == 2)
            {
                string message = "Select All Completed";
                this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
            }
            else if (Convert.ToInt32(e.UserState) == 3)
            {
                string message = "Select All Failed";
                this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
                FormStateExecution(FormState.DP29WorkCompleted);
            }
            tSProgressBar_dp29Import.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_selectAll_IsClosed_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FormStateExecution(FormState.SelectAll_IsClosed_Completed);
            bool result = (bool)e.Result;        
            //Execption Excute
            if(!result)
            {
                selectAll_IsColsedError_Falg = true;
                if (chk_SelectAll.Checked)
                    chk_SelectAll.Checked = false;
                else
                    chk_SelectAll.Checked = true;
                selectAll_IsColsedError_Falg = false;
            }
            dgvClientInfo_Load();
            //string message = "";
            //this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
        }

        private DataTable GetSetupDate_ErrorData()
        {
            DataTable SetupDate_Error = new DataTable();
            SetupDate_Error.Columns.Add("Cust_Code", typeof(string));
            SetupDate_Error.Columns.Add("SetupDate", typeof(string));
            //int i = 0;
            foreach (string item in lbSetupDate_Error.Items)
            {
                DataRow row = SetupDate_Error.NewRow();
                string[] CustCode_SetupDate = item.Split('~');
                row["Cust_Code"] = CustCode_SetupDate[0].ToString().Trim();
                row["SetupDate"] = CustCode_SetupDate[1].ToString().Trim();
                SetupDate_Error.Rows.Add(row);
                //i++;
                //if (i == 5)
                //    break;
            }
            return SetupDate_Error;
        }

        private DataTable GetClosureDate_ErrorData()
        {
            DataTable ClosureDate_Error = new DataTable();
            ClosureDate_Error.Columns.Add("Cust_Code", typeof(string));
            ClosureDate_Error.Columns.Add("ClosureDate", typeof(string));
            //int i = 0;
            foreach (string item in lbClosureDate_Error.Items)
            {
                DataRow row = ClosureDate_Error.NewRow();
                string[] CustCode_Status = item.Split('~');
                row["Cust_Code"] = CustCode_Status[0].ToString().Trim();
                row["ClosureDate"] = CustCode_Status[1].ToString();// +"-" + CustCode_Status[2].ToString() + "-" + CustCode_Status[3].ToString().Trim();
                ClosureDate_Error.Rows.Add(row);
                //i++;
                //if (i == 5)
                //    break;
            }
            return ClosureDate_Error;
        }

        private DataTable GetCustCodeBoId_ErrorData()
        {
            DataTable CustCodeBoId_Error = new DataTable();
            CustCodeBoId_Error.Columns.Add("Cust_Code", typeof(string));
            CustCodeBoId_Error.Columns.Add("BOID", typeof(string));
            //int i = 0;
            foreach (string item in lboCustCodeBoId_Error.Items)
            {
                DataRow row = CustCodeBoId_Error.NewRow();
                string[] CustCode_Status = item.Split('~');
                row["Cust_Code"] = CustCode_Status[0].ToString().Trim();
                row["BOID"] = CustCode_Status[1].ToString().Trim();
                CustCodeBoId_Error.Rows.Add(row);
                // i++;
                //if (i == 5)
                //    break;
            }
            return CustCodeBoId_Error;
        }

        private DataTable GetStatusFlow_ErrorData()
        {
            DataTable StatusFlow_Error = new DataTable();
            StatusFlow_Error.Columns.Add("Cust_Code", typeof(string));
            StatusFlow_Error.Columns.Add("FlowBOStatus", typeof(string));
            //int i = 0;
            foreach (string item in lbStatusFlow_Error.Items)
            {
                DataRow row = StatusFlow_Error.NewRow();
                string[] CustCode_Status = item.Split('~');
                row["Cust_Code"] = CustCode_Status[0].ToString().Trim();
                row["FlowBOStatus"] = CustCode_Status[1].ToString();
                StatusFlow_Error.Rows.Add(row);
                //i++;
                //if (i == 5)
                //    break;
            }
            return StatusFlow_Error;
        }

        private CustomerBO_DP29 MapBack_DP29FromGrid(int rowIndex)
        {
            CustomerBO_DP29 objBO = new CustomerBO_DP29();
            objBO.AccountNo = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.AccNo].Value.ToString();
            objBO.Address = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.Address].Value.ToString();
            objBO.BankName = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.BankName].Value.ToString();
            objBO.BoCategory = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.BOCatg].Value.ToString();
            objBO.BoId = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.BOID].Value.ToString();
            //objBO.BoId = objBO.BoId.Insert(0,"12023500");
            objBO.BoStatus = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.BoStatus].Value.ToString();
            objBO.BoType = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.BOTYPE].Value.ToString();
            objBO.BranchName = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.BranchName].Value.ToString();
            objBO.City = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.City].Value.ToString();
            objBO.ClosureDate = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.ClosureDate].Value.ToString();
            objBO.Country = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.Country].Value.ToString();
            objBO.InternalReferenceNo = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.CustCode].Value.ToString();
            objBO.Email = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.Email].Value.ToString();
            objBO.FatherName = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.FatherName].Value.ToString();
            objBO.Fax = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.Fax].Value.ToString();
            objBO.CustomerFullName = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.FullName].Value.ToString();
            objBO.MotherName = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.MotherName].Value.ToString();
            objBO.Phone = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.Phone].Value.ToString();
            objBO.PurposeCode = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.PurposeCode].Value.ToString();
            objBO.Residency = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.Residency].Value.ToString();
            objBO.SetupDate = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.SetupDate].Value.ToString();
            objBO.CustomerShortName = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.ShortName].Value.ToString();
            objBO.Satate = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.State].Value.ToString();
            
            objBO.Routing_No = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.Routing_No].Value.ToString();
            objBO.Bank_Identification_Code = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.Bank_Identification_Code].Value.ToString();
            objBO.IBAN = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.IBAN].Value.ToString();
            objBO.SWIFT_Code = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.SWIFT_Code].Value.ToString();

            objBO.Suspense_Flag = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.Suspense_Flag].Value.ToString();
            objBO.Bo_Suspened_Date = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.Bo_Suspened_Date].Value.ToString();
            objBO.Suspense_Reason_Code = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.Suspense_Reason_Code].Value.ToString();
            objBO.Second_Holder_Name = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.Second_Holder_Name].Value.ToString();
            objBO.Occupation = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.Occupation].Value.ToString();
            objBO.Date_of_Birth = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.Date_of_Birth].Value.ToString();
            objBO.Gender = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.Gender].Value.ToString();
            objBO.BO_Nationality = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.BO_Nationality].Value.ToString();
            objBO.Tax_ID_Number = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.Tax_ID_Number].Value.ToString();
            objBO.Origin_of_BO = dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.Origin_of_BO].Value.ToString();        



            objBO.IsForcedAccClosed = (
                                        Convert.ToString(
                                                            dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.IsForcedAccClosed].Value
                                        ) == string.Empty
            ) ? false : Convert.ToBoolean(dgvClientInfo.Rows[rowIndex].Cells[dgClientInfoColumnsObj.IsForcedAccClosed].Value) ;

            return objBO;
        }

        private CustomerBO_DP29 MapBack_DP29FromGrid(DataGridViewRow dr)
        {
            CustomerBO_DP29 objBO = new CustomerBO_DP29();
            objBO.AccountNo = dr.Cells[dgClientInfoColumnsObj.AccNo].Value.ToString();
            objBO.Address = dr.Cells[dgClientInfoColumnsObj.Address].Value.ToString();
            objBO.BankName = dr.Cells[dgClientInfoColumnsObj.BankName].Value.ToString();
            objBO.BoCategory = dr.Cells[dgClientInfoColumnsObj.BOCatg].Value.ToString();
            objBO.BoId = dr.Cells[dgClientInfoColumnsObj.BOID].Value.ToString();
            //objBO.BoId = objBO.BoId.Insert(0,"12023500");
            objBO.BoStatus = dr.Cells[dgClientInfoColumnsObj.BoStatus].Value.ToString();
            objBO.BoType = dr.Cells[dgClientInfoColumnsObj.BOTYPE].Value.ToString();
            objBO.BranchName = dr.Cells[dgClientInfoColumnsObj.BranchName].Value.ToString();
            objBO.City = dr.Cells[dgClientInfoColumnsObj.City].Value.ToString();
            objBO.ClosureDate = dr.Cells[dgClientInfoColumnsObj.ClosureDate].Value.ToString();
            objBO.Country = dr.Cells[dgClientInfoColumnsObj.Country].Value.ToString();
            objBO.InternalReferenceNo = dr.Cells[dgClientInfoColumnsObj.CustCode].Value.ToString();
            objBO.Email = dr.Cells[dgClientInfoColumnsObj.Email].Value.ToString();
            objBO.FatherName = dr.Cells[dgClientInfoColumnsObj.FatherName].Value.ToString();
            objBO.Fax = dr.Cells[dgClientInfoColumnsObj.Fax].Value.ToString();
            objBO.CustomerFullName = dr.Cells[dgClientInfoColumnsObj.FullName].Value.ToString();
            objBO.MotherName = dr.Cells[dgClientInfoColumnsObj.MotherName].Value.ToString();
            objBO.Phone = dr.Cells[dgClientInfoColumnsObj.Phone].Value.ToString();
            objBO.PurposeCode = dr.Cells[dgClientInfoColumnsObj.PurposeCode].Value.ToString();
            objBO.Residency = dr.Cells[dgClientInfoColumnsObj.Residency].Value.ToString();
            objBO.SetupDate = dr.Cells[dgClientInfoColumnsObj.SetupDate].Value.ToString();
            objBO.CustomerShortName = dr.Cells[dgClientInfoColumnsObj.ShortName].Value.ToString();
            objBO.Satate = dr.Cells[dgClientInfoColumnsObj.State].Value.ToString();
      
            objBO.Routing_No = dr.Cells[dgClientInfoColumnsObj.Routing_No].Value.ToString();
            objBO.Bank_Identification_Code = dr.Cells[dgClientInfoColumnsObj.Bank_Identification_Code].Value.ToString();
            objBO.IBAN = dr.Cells[dgClientInfoColumnsObj.IBAN].Value.ToString();
            objBO.SWIFT_Code = dr.Cells[dgClientInfoColumnsObj.SWIFT_Code].Value.ToString();

            objBO.Suspense_Flag = dr.Cells[dgClientInfoColumnsObj.Suspense_Flag].Value.ToString();
            objBO.Bo_Suspened_Date = dr.Cells[dgClientInfoColumnsObj.Bo_Suspened_Date].Value.ToString();
            objBO.Suspense_Reason_Code = dr.Cells[dgClientInfoColumnsObj.Suspense_Reason_Code].Value.ToString();
            objBO.Second_Holder_Name = dr.Cells[dgClientInfoColumnsObj.Second_Holder_Name].Value.ToString();
            objBO.Occupation = dr.Cells[dgClientInfoColumnsObj.Occupation].Value.ToString();
            objBO.Date_of_Birth = dr.Cells[dgClientInfoColumnsObj.Date_of_Birth].Value.ToString();
            objBO.Gender = dr.Cells[dgClientInfoColumnsObj.Gender].Value.ToString();
            objBO.BO_Nationality = dr.Cells[dgClientInfoColumnsObj.BO_Nationality].Value.ToString();
            objBO.Tax_ID_Number = dr.Cells[dgClientInfoColumnsObj.Tax_ID_Number].Value.ToString();
            objBO.Origin_of_BO = dr.Cells[dgClientInfoColumnsObj.Origin_of_BO].Value.ToString();
            


            objBO.IsForcedAccClosed = (
                                        Convert.ToString(
                                                            dr.Cells[dgClientInfoColumnsObj.IsForcedAccClosed].EditedFormattedValue
                                        ) == string.Empty
            ) ? false : Convert.ToBoolean(dr.Cells[dgClientInfoColumnsObj.IsForcedAccClosed].EditedFormattedValue);

            return objBO;
        }

        private void Deligate_SetText_tSStatusLabel_Progress_Comment(string Text)
        {
            tSStatusLabel_Progress_Comment.Text = Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFileLocationBrowser_Click(object sender, EventArgs e)
        {
            if (ofdFileOpen.ShowDialog() == DialogResult.OK)
                txtFileLocation.Text = ofdFileOpen.FileName;
        }

        private void btnStartImport_Click(object sender, EventArgs e)
        {
            try
            {
                //ProcessBO_29();
                CustomerBO_DP29BAL dp29Bal = new CustomerBO_DP29BAL();
                FormStateExecution(FormState.Dp19TempFileTrancate);
                string message = "Deleting Temporary..";
                this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
                dp29Bal.TruncateDP29();
                FormStateExecution(FormState.Dp29FileImport_Start);
                message = "File Importing Start..";
                this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
                backgroundWorker_dp29Import.RunWorkerAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvClientInfo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvClientInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name != dgClientInfoColumnsObj.IsForcedAccClosed)
            {
                string message = "Press Enter For Save";
                this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
                //btnDgvClientInfo_EditMode.Visible = true;
            }
        }

        private void dgvClientInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CustomerBO_DP29BAL obj = new CustomerBO_DP29BAL();
                CustomerBO_DP29 objBO = new CustomerBO_DP29();
                if (dgvClientInfo.RowCount >= e.RowIndex && dgvClientInfo.ColumnCount >= e.ColumnIndex)
                {
                    if (dgvClientInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name != dgClientInfoColumnsObj.IsForcedAccClosed)
                    {
                        //objBO.AccountNo = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.AccNo].Value.ToString();
                        //objBO.Address = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.Address].Value.ToString();
                        //objBO.BankName = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.BankName].Value.ToString();
                        //objBO.BoCategory = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.BOCatg].Value.ToString();
                        //objBO.BoId = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.BOID].Value.ToString();
                        ////objBO.BoId = objBO.BoId.Insert(0,"12023500");
                        //objBO.BoStatus = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.BoStatus].Value.ToString();
                        //objBO.BoType = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.BOTYPE].Value.ToString();
                        //objBO.BranchName = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.BranchName].Value.ToString();
                        //objBO.City = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.City].Value.ToString();
                        //objBO.ClosureDate = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.ClosureDate].Value.ToString();
                        //objBO.Country = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.Country].Value.ToString();
                        //objBO.InternalReferenceNo = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.CustCode].Value.ToString();
                        //objBO.Email = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.Email].Value.ToString();
                        //objBO.FatherName = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.FatherName].Value.ToString();
                        //objBO.Fax = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.Fax].Value.ToString();
                        //objBO.CustomerFullName = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.FullName].Value.ToString();
                        //objBO.MotherName = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.MotherName].Value.ToString();
                        //objBO.Phone = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.Phone].Value.ToString();
                        //objBO.PurposeCode = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.PurposeCode].Value.ToString();
                        //objBO.Residency = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.Residency].Value.ToString();
                        //objBO.SetupDate = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.SetupDate].Value.ToString();
                        //objBO.CustomerShortName = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.ShortName].Value.ToString();
                        //objBO.Satate = dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.State].Value.ToString();
                        //objBO.IsForcedAccClosed = Convert.ToBoolean(dgvClientInfo.Rows[e.RowIndex].Cells[dgClientInfoColumnsObj.IsForcedAccClosed].Value);
                       
                        objBO = MapBack_DP29FromGrid(e.RowIndex);
                        obj.UpdateCustomerBO_DP29(objBO);
                        string message = "Changes Saved Successfully!!";
                        this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });

                        dgvClientInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.RoyalBlue;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "Changes Saved Failed!!";
                this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
            }

        }

        private void dgvClientInfo_Leave(object sender, EventArgs e)
        {
            string message = "";
            this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "Checking Start..";
                this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
                FormStateExecution(FormState.Dp29FileCheck_Start);
                backgroundWorker_dp29Check.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {

            try
            {
                frm_Import_Dp29_ProcessPromt frmProcessPromt = new frm_Import_Dp29_ProcessPromt();
                frmProcessPromt.UpdateFlg_DlgObj = new frm_Import_Dp29_ProcessPromt.Dlg_UpdatedFlag(Deligate_UpdateColumsFlag);
                frmProcessPromt.StartPosition = FormStartPosition.CenterParent;
                frmProcessPromt.ShowDialog(this);
                if (!frmProcessPromt.IsCancel)
                {
                    string message = "Processing Start..";
                    this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
                    FormStateExecution(FormState.Dp29FileProcess_Start);
                    backgroundWorker_dp29Process.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void lbSetupDate_Error_Enter(object sender, EventArgs e)
        {
            string message = "Setup Date Changed Error Log";
            this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
        }

        private void lbClosureDate_Error_Enter(object sender, EventArgs e)
        {
            string message = "Closure Date Changed Error Log";
            this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
        }

        private void lboCustCodeBoId_Error_Enter(object sender, EventArgs e)
        {
            string message = "Custcode & Boid Missmatch Error Log ";
            this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
        }

        private void lbStatusFlow_Error_Enter(object sender, EventArgs e)
        {
            string message = "Staus Closed to Active Changed Error Log";
            this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvClientInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CustomerBO_DP29BAL obj = new CustomerBO_DP29BAL();
                CustomerBO_DP29 objBO = new CustomerBO_DP29();
                if (dgvClientInfo.RowCount >= e.RowIndex && dgvClientInfo.ColumnCount >= e.ColumnIndex && e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (dgvClientInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == dgClientInfoColumnsObj.IsForcedAccClosed)
                    {
                        DataGridViewRow dgvRowObj=new DataGridViewRow();
                        if (((DataGridView)sender).SelectedRows.Count > 0)
                        {
                            dgvRowObj = ((DataGridView)sender).SelectedRows[0];
                        }
                        objBO = MapBack_DP29FromGrid(dgvRowObj);
                        obj.UpdateCustomerBO_DP29(objBO);
                        string message = "Changes Saved Successfully!!";
                        this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });

                        dgvClientInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.RoyalBlue;

                    }
                }
            }
            catch (Exception ex)
            {
                string message = "Changes Saved Failed!!";
                this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
            }
        }

        private void dgvClientInfo_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            string message = "";
            this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
        }

        private void checkBox1_CheckAll()
        {
            for (int count = 0; count < dgvClientInfo.Rows.Count; count++)
            {
                dgvClientInfo.Rows[count].Cells[0].Value = true;
            }
        }

        private void checkBox1_UnCheckAll()
        {
            for (int count = 0; count < dgvClientInfo.Rows.Count; count++)
            {
                dgvClientInfo.Rows[count].Cells[0].Value = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(!selectAll_IsColsedError_Falg)
            {
                if (!backgroundWorker_selectAll_IsClosed.IsBusy)
                {
                    selectAll_IsColsedError_Falg = false;
                    backgroundWorker_selectAll_IsClosed.RunWorkerAsync();
                }
            }      
        }

        private void checkBox1_Leave(object sender, EventArgs e)
        {
            string message = "";
            this.Invoke(new StatusMessageShow(Deligate_SetText_tSStatusLabel_Progress_Comment), new object[] { message });
        }

        private void frm_Import_DP29_Load(object sender, EventArgs e)
        {
            FormStateExecution(FormState.FormLoad);
        }

        private void btn_LogReport_Click(object sender, EventArgs e)
        {
            CustomerBO_DP29BAL DP_29BAL = new CustomerBO_DP29BAL();
            List<string> result = new List<string>();
            DataTable SetupDate_Error = new DataTable();
            SetupDate_Error = GetSetupDate_ErrorData();

            DataTable ClosureDate_Error = new DataTable();
            ClosureDate_Error = GetClosureDate_ErrorData();

            DataTable CustCodeBoId_Error = new DataTable();
            CustCodeBoId_Error = GetCustCodeBoId_ErrorData();

            DataTable StatusFlow_Error = new DataTable();
            StatusFlow_Error = GetStatusFlow_ErrorData();

            //for (int x = 0; x < CustCodeBoId_Error.Rows.Count; x++)
            //{
            //    try
            //    {
            //        for (int y = 0; y < SetupDate_Error.Rows.Count;y++ )
            //            if (SetupDate_Error.Rows[x][0].ToString() == CustCodeBoId_Error.Rows[y][0].ToString())
            //            {

            //                MessageBox.Show(SetupDate_Error.Rows[0][x].ToString());
            //            }
            //    }
            //    catch
            //    {
            //    }
            //}
            //DataTable dtErrorLog_Temp = new DataTable();
            //dtErrorLog_Temp.Columns.Add("Cust_Code", typeof(string), string.Empty);
            //dtErrorLog_Temp.Columns.Add("BoStatus", typeof(string), string.Empty);
            //dtErrorLog_Temp.Columns.Add("BOID", typeof(string), string.Empty);
            //dtErrorLog_Temp.Columns.Add("ClosureDate", typeof(string), string.Empty);
            //dtErrorLog_Temp.Columns.Add("FlowBOStatus", typeof(string), string.Empty);

            //Reports.dsImport_Dp29ErrorLogReport ds = new dsImport_Dp29ErrorLogReport();
            //DataTable dtErrorLog_Temp = ds.DataTable1;


            var custList = SetupDate_Error.AsEnumerable().Select(t => new { CustCode = t["Cust_Code"] })
                               .Union(
                                       CustCodeBoId_Error.AsEnumerable().Select(t => new { CustCode = t["Cust_Code"] })
                                         .Union(
                                                 StatusFlow_Error.AsEnumerable().Select(t => new { CustCode = t["Cust_Code"] })
                                                  .Union(
                                                         ClosureDate_Error.AsEnumerable().Select(t => new { CustCode = t["Cust_Code"] })

                                                   )
                                         )
                            ).ToList();

            var custList_distinct = (from a in custList
                                     group a by a.CustCode into g
                                     select new { CustCode = g.Key }).ToList();

            var left = (from cust in custList_distinct
                        join a in SetupDate_Error.AsEnumerable()
                        on cust.CustCode equals a["Cust_Code"] into gja
                        from ga in gja.DefaultIfEmpty()
                        join b in CustCodeBoId_Error.AsEnumerable()
                        on cust.CustCode equals b["Cust_Code"] into gjb
                        from gb in gjb.DefaultIfEmpty()
                        join c in StatusFlow_Error.AsEnumerable()
                        on cust.CustCode equals c["Cust_Code"] into gjc
                        from gc in gjc.DefaultIfEmpty()
                        join d in ClosureDate_Error.AsEnumerable()
                        on cust.CustCode equals d["Cust_Code"] into gjd
                        from gd in gjd.DefaultIfEmpty()
                        select new
                        {
                            Cust_Code = cust.CustCode
                            ,
                            SetupDate = (ga == null ? String.Empty : ga["SetupDate"])
                            ,
                            BOID = (gb == null ? String.Empty : gb["BOID"])
                            ,
                            ClosureDate = (gd == null ? String.Empty : gd["ClosureDate"])
                            ,
                            FlowBOStatus = (gc == null ? String.Empty : gc["FlowBOStatus"])
                            ,
                            Result = GetStatus_Category(cust.CustCode.ToString(), (gb == null ? String.Empty : gb["BOID"].ToString()))
                            //,
                            //BO_Status = ""//(GetStatus_Category(cust.CustCode.ToString(), (gb == null ? String.Empty : gb["BOID"].ToString())).Count>0) ? (GetStatus_Category(cust.CustCode.ToString(), (gb == null ? String.Empty : gb["BOID"]).ToString())[0]) : "Not found by Cust Code"          //(gb == null ? DP_29BAL.GetBO_Status(cust.CustCode.ToString()).Rows[0][0].ToString() : (gb["BOID"].ToString() != "" ? DP_29BAL.GetBO_Status(cust.CustCode.ToString(), gb["BOID"].ToString()).Rows[0][0].ToString() : DP_29BAL.GetBO_Status(cust.CustCode.ToString()).Rows[0][0].ToString()))
                           // ,
                           // BO_Category = "" // (GetStatus_Category(cust.CustCode.ToString(), (gb == null ? String.Empty : gb["BOID"].ToString())).Count > 0) ? (GetStatus_Category(cust.CustCode.ToString(), (gb == null ? String.Empty : gb["BOID"]).ToString())[1]) : "Not found by Cust Code"  //GetStatus_Category(cust.CustCode.ToString(), (gb == null ? String.Empty : gb["BOID"]).ToString())[1]          //(gb == null ? DP_29BAL.GetBO_Status(cust.CustCode.ToString()).Rows[0][0].ToString() : (gb["BOID"].ToString() != "" ? DP_29BAL.GetBO_Status(cust.CustCode.ToString(), gb["BOID"].ToString()).Rows[0][1].ToString() : DP_29BAL.GetBO_Status(cust.CustCode.ToString()).Rows[0][1].ToString())) 
                        }).ToList().Select(t => new
                                                {
                                                    Cust_Code = t.Cust_Code,
                                                    SetupDate = t.SetupDate,
                                                    BOID = t.BOID,
                                                    ClosureDate = t.ClosureDate,
                                                    FlowBOStatus = t.FlowBOStatus,
                                                    BO_Status = t.Result[0],
                                                    BO_Category = t.Result[1]
                                                }
                                                );


            var left_OrderBy = left.OrderBy(t => t.BO_Status).ThenBy(t => t.BOID).ThenBy(t => t.BO_Category).ThenBy(t => t.SetupDate).ThenBy(t => t.ClosureDate).ThenBy(t => t.FlowBOStatus).ThenBy(t => t.Cust_Code);

            //foreach (var item in left_OrderBy)
            //{
            //    DataRow dr = dtErrorLog_Temp.NewRow();
            //    dr["Cust_Code"] = item.Cust_Code;
            //    dr["BoStatus"] = item.BoStatus;
            //    dr["BOID"] = item.BOID;
            //    dr["ClosureDate"] = item.ClosureDate;
            //    dr["FlowBOStatus"] = item.FlowBOStatus;
            //    dtErrorLog_Temp.Rows.Add(dr);
            //}

            frmReportViewer reportViewer = new frmReportViewer();
            crImprot_Dp29ErrorReport CrImprot_Dp29ErrorReport = new crImprot_Dp29ErrorReport();
            //CrImprot_Dp29ErrorReport.SetDataSource(dtErrorLog_Temp);
            CrImprot_Dp29ErrorReport.SetDataSource(left_OrderBy);
            reportViewer.crvReportViewer.ReportSource = CrImprot_Dp29ErrorReport;
            reportViewer.Show();
        }

        private List<string> GetStatus_Category(string Cust_Code, string BOID)
        {
            CustomerBO_DP29BAL DP_29BAL = new CustomerBO_DP29BAL();
            List<string> result = new List<string>();
            if (BOID != "")
            {
                result = DP_29BAL.GetBO_Status(Cust_Code, BOID);
            }
            else
            {
                result = DP_29BAL.GetBO_Status(Cust_Code);
            }
            if (result.Count== 0)
            {
                BO_Status = "";
                BO_Category = "";
                result.Add(BO_Status);
                result.Add(BO_Category);
            }            
            return result;
        }

        private void Deligate_UpdateColumsFlag(List<KeyValuePair<string,string>> lst)
        {
            ColumnsListToBeUpdated.Clear();
            foreach (var data in lst)
            {
                ColumnsListToBeUpdated.Add(data);
            }
        }

        private void btn_MissMatch_Click(object sender, EventArgs e)
        {
            try
            {
                ReportView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }

        }
        private void ReportView()
        {
            DataTable dt = new DataTable();
            CustomerBO_DP29BAL reportBAL = new CustomerBO_DP29BAL();
            LoadCommonInfo CmmInfo = new LoadCommonInfo();
            CompanyBAL objCompanyBal = new CompanyBAL();

            dt = reportBAL.GetDP29MissMatchReport();
            
            cr_DP29MissmatchReport reportFile = new cr_DP29MissmatchReport();
            reportFile.SetDataSource(dt);

            ((TextObject)reportFile.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = CmmInfo.ShowCompanyName();
            ((TextObject)reportFile.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text = objCompanyBal.GetHeadofficeInfo();
           
            frmInstruwiseShareTradeListViewer reportViewer = new frmInstruwiseShareTradeListViewer();
            reportViewer.crvInstruWiseShareTradeList.ReportSource = reportFile;
            reportViewer.Show();


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void bindingSource_ForDgvClient_CurrentChanged(object sender, EventArgs e)
        {

        }
       
    }

}

