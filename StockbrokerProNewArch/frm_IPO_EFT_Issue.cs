﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
//using Microsoft.Office.Core;
using Excel=Microsoft.Office.Interop.Excel;
using CrystalDecisions.CrystalReports.Engine;
using Reports;
using System.Runtime.InteropServices;
using BusinessAccessLayer.Constants;



namespace StockbrokerProNewArch
{
    public partial class frm_IPO_EFT_Issue : Form
    {
        private const int SC_CLOSE = 0xF060;
        private const int MF_GRAYED = 0x1;
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern int EnableMenuItem(IntPtr hMenu, int wIDEnableItem, int wEnable);

        //private delegate void ColseButtonActiveInActive(bool IsActive);
        
        private struct Reports_Type_Def
        {
            public string Summary_Reports_Name;
            public string Details_Reports_Name;
            public string Summary_Reports_Print_ToolTipMessage;
            public string Details_Reports_Print_ToolTipMessage;
        };

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        private enum FormState { Saved, NotSaved, Printed, FileExported };
        private enum ButtonPress {Load, Add, AddAll, Remove, RemoveAll };

        private Reports_Type_Def Reports_Type = new Reports_Type_Def() { Details_Reports_Name = "Detail Report", Summary_Reports_Name = "Summary Report", Summary_Reports_Print_ToolTipMessage = "Summary Report Print", Details_Reports_Print_ToolTipMessage="Details Report Print" };
        private EFT_IssueBAL Eft = new EFT_IssueBAL();
        private List<Payment_PostingBO> objList_ApprovedAll = new List<Payment_PostingBO>();
        private List<Payment_PostingBO> objList_IssueNext = new List<Payment_PostingBO>();
        private List<string> printedDocument=new List<string>();

        public frm_IPO_EFT_Issue()
        {
            InitializeComponent();
           
            FormState_Execution(FormState.NotSaved);

        }
        
        private bool IsThereRoutingNo(string custCode)
        {
            bool result = false;
            EFT_IssueBAL objBal = new EFT_IssueBAL();
            var data = objBal.GetRoutingByCustCode(custCode);
            if (data != string.Empty)
                result = true;
            return result;
        }

        private void Export_xls(string FileName)
        {
            EFT_IssueBAL objBal = new EFT_IssueBAL();
            int dataSartingRowIndex = 7;

            string[] ColumnsHeader = new string[] { "Reason", "SenderAccNumber", "ReceivingBankRouting", "BankAccNo", "AccType", "Amount", "ReceiverID", "ReceiverName" };
            string[] ColumnsAlphabet = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            var missValue = System.Reflection.Missing.Value;

            var excelApp = new Excel.ApplicationClass();
            //ExcelDoc_Prepared(out excelApp);

            var workbook = excelApp.Workbooks.Add(missValue);
            var currentSheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;

            var dataList = objBal.GetExport_ExcelDocByFileNo_Export(txtFileNo.Text.Trim(),Indication_CompanyBankInformation.CityBank_IPOAccount_AccountNo,string.Empty);
            string password = string.Empty;
            password = objBal.GetAllEFT_File_Info_ByFileNo(txtFileNo.Text.Trim()).File_Password;
          
            //Initial Formating
            currentSheet.Columns.NumberFormat = "@";
            currentSheet.Name = "KSCL EFT";

            Excel.Range rngColumns = currentSheet.get_Range("A" + dataSartingRowIndex, "" + ColumnsAlphabet[ColumnsHeader.Length] +""+ dataSartingRowIndex);
            rngColumns.Font.Bold = true;
            rngColumns.Interior.Color = ColorTranslator.ToOle(Color.LightGray);

            /////////////////////////////////

            ////////********** Set Company Name & Address ***************////////
            CommonInfoBal objComm = new CommonInfoBal();
            DataTable data = new DataTable();
            data = objComm.GetCompanyNameHeadOffice();


            //////// *************** Company Name  ***************** ///////////
            currentSheet.get_Range("A1", "H1").Merge(true);
            currentSheet.get_Range("A1", "H1").Value2 = data.Rows[0]["BrokerName"].ToString();
            currentSheet.get_Range("A1", "H1").HorizontalAlignment = 3;
            currentSheet.get_Range("A1", "H1").Font.Name = "Arial";
            currentSheet.get_Range("A1", "H1").Font.Bold = true;
            currentSheet.get_Range("A1", "H1").Font.Size = 11;
            currentSheet.get_Range("A1", "H1").RowHeight = 15;
            currentSheet.get_Range("A1", "H1").VerticalAlignment = 3;
            currentSheet.get_Range("A1", "H1").HorizontalAlignment = 3;


            //////// *************** Company Name  ***************** ///////////
            currentSheet.get_Range("A2", "H2").Merge(true);
            currentSheet.get_Range("A2", "H2").Value2 = data.Rows[0]["Address"].ToString();
            currentSheet.get_Range("A2", "H2").HorizontalAlignment = 3;
            currentSheet.get_Range("A2", "H2").Font.Name = "Arial";
            currentSheet.get_Range("A2", "H2").Font.Size = 10;
            currentSheet.get_Range("A2", "H2").RowHeight = 12.75;
            currentSheet.get_Range("A2", "H2").VerticalAlignment = 3;
            currentSheet.get_Range("A2", "H2").HorizontalAlignment = 3;


            //////// *************** Phone & Fax  ***************** ///////////
            currentSheet.get_Range("A3", "H3").Merge(true);
            currentSheet.get_Range("A3", "H3").Value2 = "Phone: " + data.Rows[0]["Telephone"].ToString() + ",Fax: " + data.Rows[0]["Fax"].ToString();
            currentSheet.get_Range("A3", "H3").HorizontalAlignment = 3;
            currentSheet.get_Range("A3", "H3").Font.Name = "Arial";
            currentSheet.get_Range("A3", "H3").Font.Size = 10;
            currentSheet.get_Range("A3", "H3").RowHeight = 12.75;
            currentSheet.get_Range("A3", "H3").VerticalAlignment = 3;
            currentSheet.get_Range("A3", "H3").HorizontalAlignment = 3;


            //////// *************** Contact Numner  ***************** ///////////
            currentSheet.get_Range("A4", "H4").Merge(true);
            currentSheet.get_Range("A4", "H4").Value2 = "Contact No: 01720220321, 01710878300";
            currentSheet.get_Range("A4", "H4").HorizontalAlignment = 3;
            currentSheet.get_Range("A4", "H4").Font.Name = "Arial";
            currentSheet.get_Range("A4", "H4").Font.Size = 10;
            currentSheet.get_Range("A4", "H4").RowHeight = 12.75;
            currentSheet.get_Range("A4", "H4").VerticalAlignment = 3;
            currentSheet.get_Range("A4", "H4").HorizontalAlignment = 3;

            //////// *************** Cheque Requisition Date  ***************** ///////////
            currentSheet.get_Range("A5", "H5").Merge(true);
            currentSheet.get_Range("A5", "H5").Value2 = "EFT Issued Date: " + dtToday.Value.ToString("dd-MM-yyyy");
            currentSheet.get_Range("A5", "H5").HorizontalAlignment = 3;
            currentSheet.get_Range("A5", "H5").Font.Name = "Arial";
            currentSheet.get_Range("A5", "H5").Font.Bold = true;
            currentSheet.get_Range("A5", "H5").Font.Size = 9;
            currentSheet.get_Range("A5", "H5").Font.Underline = true;
            currentSheet.get_Range("A5", "H5").RowHeight = 12.75;
            currentSheet.get_Range("A5", "H5").VerticalAlignment = 3;
            currentSheet.get_Range("A5", "H5").HorizontalAlignment = 3;





            //////////////////////////////
            //Insert Columns Name
            int count_Columns = 1;
            foreach (string str in ColumnsHeader)
            {
                currentSheet.Cells[dataSartingRowIndex, count_Columns] = str;
                count_Columns++;
            }

            int count_Row = dataSartingRowIndex+1;
            foreach (var obj in dataList)
            {
                currentSheet.Cells[count_Row, 1] = Convert.ToString(obj.Reason).Trim();
                currentSheet.Cells[count_Row, 2] = Convert.ToString(obj.SenderAccNumber).Trim();
                currentSheet.Cells[count_Row, 3] = Convert.ToString(obj.RoutingNo).Trim();
                currentSheet.Cells[count_Row, 4] = Convert.ToString(obj.Bank_Account_No).Trim();
                currentSheet.Cells[count_Row, 5] = Convert.ToString(obj.Account_Type).Trim();
                currentSheet.Cells[count_Row, 6] = Convert.ToString(obj.Amount).Trim();
                currentSheet.Cells[count_Row, 7] = Convert.ToString(obj.Cust_Code).Trim();
                currentSheet.Cells[count_Row, 8] = Convert.ToString(objBal.GetCustomerName(obj.Cust_Code,"")).Trim();
                count_Row++;
            }
            //Column Resizing and Post Formatting
            Excel.Range rngALL = currentSheet.get_Range("A" + dataSartingRowIndex, "" + ColumnsAlphabet[ColumnsHeader.Length] + "" + (dataSartingRowIndex+(dataList.Count + 1)));
            rngALL.Columns.AutoFit();
            rngALL.VerticalAlignment = 3;
            rngALL.HorizontalAlignment = 3;

            currentSheet.Protect(password, true, true, true, false, false, true, true, false, false, false, false, false, true, true, false);

            workbook.Author = "K-Secuirites Ltd.";
            workbook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, password, missValue,
             false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
             missValue, missValue, missValue, missValue, missValue);
            workbook.Close(true, missValue, missValue);
            excelApp.Quit();
            releaseObject(excelApp);
            releaseObject(workbook);
            releaseObject(currentSheet);

        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        } 

        private void InsertEft_Issue(List<Payment_PostingBO> objList)
        {
            List<EFT_IssueBO> issuBoList=new List<EFT_IssueBO>();
            EFT_IssueBAL objBal = new EFT_IssueBAL();
            EFT_File_InfoBO objMaster = new EFT_File_InfoBO();
            objMaster.File_No = txtFileNo.Text.Trim();
            //objMaster.File_Path = txtFilePath.Text;
            objMaster.File_Issue_Date = dtToday.Value;
            objMaster.File_Password = txt_Password.Text.Trim();
            objMaster.Issue_By = GlobalVariableBO._userName;
            
            foreach (var obj in objList)
            {
                EFT_IssueBO issueBo = new EFT_IssueBO();
                issueBo.Amount = obj.Amount;
                issueBo.Cust_Code = obj.Cust_Code;
                issueBo.File_No_ID = objMaster.File_No;
                issueBo.Received_Date = obj.Received_Date;
                issueBo.Req_ID = obj.Payment_ID;
                issueBo.Bank_ID = obj.Bank_ID;
                issueBo.BankName = obj.Bank_Name;
                issueBo.Branch_ID = obj.Branch_ID;
                issueBo.BranchName = obj.Bank_Branch;
                issueBo.RoutingNo = obj.RoutingNo;//objBal.GetRoutingByCustCode(obj.Cust_Code);
                issueBo.Account_Type = objBal.GetAccountTypeByCustCode(obj.Cust_Code);
                issueBo.ReqType = Indication_IPOPaymentTransaction.ReqType_EftIssue_IPOAccount;
                if (issueBo.Account_Type == "")
                {
                    issueBo.Account_Type = "Savings";
                }
                issuBoList.Add(issueBo);
            }
            //objBal.InsertEFT_FileInfo(objMaster);
            //objBal.InsertEFT_Issue(issuBoList);        
            objBal.InsertEFT(objMaster, issuBoList);
        }

        private void btnSaveFileDialog_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog_EftSave.ShowDialog() == DialogResult.OK)
                txtFilePath.Text = folderBrowserDialog_EftSave.SelectedPath;
        }

        private void EFT_Issue_Load(object sender, EventArgs e)
        {
            try
            {
                EFT_IssueBAL objBal = new EFT_IssueBAL();
                IPOProcessBAL ipoBal = new IPOProcessBAL();
                CommonBAL comBal = new CommonBAL();
                var objList = ipoBal.GetIPOEftRequisitionRequest();
                objList_ApprovedAll = objList;
                txt_Password.Text = string.Empty + objBal.GetLastFilePasswordByLoginName(GlobalVariableBO._userName);
                txt_RetypePass.Text= string.Empty + objBal.GetLastFilePasswordByLoginName(GlobalVariableBO._userName);
                bindingSource_ApprovedAll.DataSource = objList_ApprovedAll;
                bindingSource_IssueNext.DataSource = objList_IssueNext;
                this.cmbReport.Items.AddRange(new object[] {
                Reports_Type.Summary_Reports_Name,
                Reports_Type.Details_Reports_Name});
                cmbReport.SelectedIndex = 0;
                dtToday.Value = comBal.GetCurrentServerDate();

                //dgvApprovedAll.DataSource = dtApprovedPosting;
                //dgvNotIssued.DataSource = Eft.GetBlankData();

                //dgvNotIssued.Columns["Payment Media"].Visible = false;
                //dgvNotIssued.Columns["Received Date"].Visible = false;
                btn_AutoFileGen_Click(sender, e);
                ButtonPress_Execution(ButtonPress.Load);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void FormState_Execution(FormState st)
        {
            switch (st)
            {
                case FormState.Saved:
                    {
                        txtFileNo.Enabled = false;
                        txtFilePath.Enabled = false;
                        txt_Password.Enabled = false;
                        dtToday.Enabled = false;
                        btnSaveFileDialog.Enabled = false;
                        btnSave.Enabled = false;
                        btn_Preview.Enabled = true;
                        btnClose.Enabled = false;
                        btnProcess.Enabled = false;
                        txt_RetypePass.Enabled = false;
                        bool isEnable=false;
                        EnableMenuItem(GetSystemMenu(this.Handle, isEnable), SC_CLOSE, MF_GRAYED);
                        break;
                    }
                case FormState.NotSaved:
                    {
                        txtFileNo.Enabled = true;
                        txtFilePath.Enabled = true;
                        txt_Password.Enabled = true;
                        dtToday.Enabled = false;
                        btnSaveFileDialog.Enabled = true;
                        btnSave.Enabled = true;
                        btn_Preview.Enabled = false;
                        btnClose.Enabled = true;
                        btnProcess.Enabled = false;
                        txt_RetypePass.Enabled = true;
                        bool isEnable = false;
                        EnableMenuItem(GetSystemMenu(this.Handle, isEnable), SC_CLOSE, MF_GRAYED);                        
                        break;
                    }
               case FormState.FileExported:
                    {
                        txtFileNo.Enabled = false;
                        txtFilePath.Enabled = false;
                        txt_Password.Enabled = false;
                        dtToday.Enabled = false;
                        btnSaveFileDialog.Enabled = false;
                        btnSave.Enabled = false;
                        btn_Preview.Enabled = false;
                        btnClose.Enabled = true;
                        btnProcess.Enabled = false;
                        txt_RetypePass.Enabled = false;
                        bool isEnable = false;
                        EnableMenuItem(GetSystemMenu(this.Handle, isEnable), SC_CLOSE, MF_GRAYED);                        
                        break;
                    }
               case FormState.Printed:
                    {
                        txtFileNo.Enabled = false;
                        txtFilePath.Enabled = false;
                        txt_Password.Enabled = false;
                        dtToday.Enabled = false;
                        btnSaveFileDialog.Enabled = false;
                        btnSave.Enabled = false;
                        btn_Preview.Enabled = true;
                        btnClose.Enabled = false;
                        btnProcess.Enabled = true;
                        txt_RetypePass.Enabled = false;
                        bool isEnable = false;
                        EnableMenuItem(GetSystemMenu(this.Handle, isEnable), SC_CLOSE, MF_GRAYED);                        
                        break;
                    }
            }
        }
        private void ButtonPress_Execution(ButtonPress btnpress)
        {
            switch (btnpress)
            {
                case ButtonPress.Load:
                    if (dgvNotIssued.Rows.Count == 0)
                    {
                        DisableRemoveButton();
                    }
                    if (dgvApprovedAll.Rows.Count == 0)
                    {
                        DisableAddButton();
                    }
                    break;
                case ButtonPress.Add:
                    if (dgvApprovedAll.Rows.Count == 0)
                    {
                        DisableAddButton();
                    }
                    if (dgvNotIssued.Rows.Count > 0)
                    {
                        EnableRemoveButton();
                    }
                    break;
                case ButtonPress.AddAll:
                    if (dgvApprovedAll.Rows.Count == 0)
                    {
                        DisableAddButton();
                    }
                    if (dgvNotIssued.Rows.Count > 0)
                    {
                        EnableRemoveButton();
                    }
                    break;
                case ButtonPress.Remove:
                    if (dgvNotIssued.Rows.Count == 0)
                    {
                        DisableRemoveButton();
                    }
                    if (dgvApprovedAll.Rows.Count > 0)
                    {
                        EnableAddButton();
                    }
                    break;
                case ButtonPress.RemoveAll:
                    if (dgvNotIssued.Rows.Count == 0)
                    {
                        DisableRemoveButton();
                    }
                    if (dgvApprovedAll.Rows.Count > 0)
                    {
                        EnableAddButton();
                    }
                    break;
            }
        }
        private void DisableAddButton()
        {
            btnAdd.Enabled = false;
            btnAddAll.Enabled = false;
        }
        private void DisableRemoveButton()
        {
            btnRemove.Enabled = false;
            btnRemoveAll.Enabled = false;
        }
        private void EnableAddButton()
        {
            btnAdd.Enabled = true;
            btnAddAll.Enabled = true;
        }
        private void EnableRemoveButton()
        {
            btnRemove.Enabled = true;
            btnRemoveAll.Enabled = true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var data = (Payment_PostingBO)bindingSource_ApprovedAll.Current;
                //if (!IsThereRoutingNo(data.Cust_Code))
                //  throw new Exception("Customer Bank Information Missing");
                objList_ApprovedAll.Remove(data);
                objList_IssueNext.Add(data);
                bindingSource_ApprovedAll.DataSource = null;
                bindingSource_ApprovedAll.DataSource = objList_ApprovedAll;
                dgvApprovedAll.Refresh();
                bindingSource_IssueNext.DataSource = null;
                bindingSource_IssueNext.DataSource = objList_IssueNext;
                dgvNotIssued.Refresh();

                btn_AutoFileGen_Click(sender, e);
                ButtonPress_Execution(ButtonPress.Add);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                var data = (Payment_PostingBO)bindingSource_IssueNext.Current;
                objList_ApprovedAll.Add(data);
                objList_IssueNext.Remove(data);
                bindingSource_ApprovedAll.DataSource = null;
                bindingSource_ApprovedAll.DataSource = objList_ApprovedAll;
                dgvApprovedAll.Refresh();
                bindingSource_IssueNext.DataSource = null;
                bindingSource_IssueNext.DataSource = objList_IssueNext;
                dgvNotIssued.Refresh();

                btn_AutoFileGen_Click(sender, e);
                ButtonPress_Execution(ButtonPress.Remove);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            try
            {
                var dataList = (List<Payment_PostingBO>)bindingSource_ApprovedAll.DataSource;
                
                objList_IssueNext.AddRange(dataList);
                objList_ApprovedAll.Clear();

                bindingSource_ApprovedAll.DataSource = null;
                bindingSource_ApprovedAll.DataSource = objList_ApprovedAll;
                dgvApprovedAll.Refresh();
                
                bindingSource_IssueNext.DataSource = null;
                bindingSource_IssueNext.DataSource = objList_IssueNext;
                dgvNotIssued.Refresh();

                btn_AutoFileGen_Click(sender, e);
                ButtonPress_Execution(ButtonPress.AddAll);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {

            try
            {
                var dataList = (List<Payment_PostingBO>)bindingSource_IssueNext.DataSource;
                
                objList_ApprovedAll.AddRange(dataList);
                objList_IssueNext.Clear();

                bindingSource_ApprovedAll.DataSource = null;
                bindingSource_ApprovedAll.DataSource = objList_ApprovedAll;
                dgvApprovedAll.Refresh();

                bindingSource_IssueNext.DataSource = null;
                bindingSource_IssueNext.DataSource = objList_IssueNext;
                dgvNotIssued.Refresh();

                btn_AutoFileGen_Click(sender, e);
                ButtonPress_Execution(ButtonPress.RemoveAll);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFilePath.Text == string.Empty)
                {
                    MessageBox.Show("Please Entry File Path");
                    return;
                }
                if (txtFileNo.Text == string.Empty)
                {
                    MessageBox.Show("Please Entry File No");
                    return;
                }
                if (txt_Password.Text != txt_RetypePass.Text)
                {
                    MessageBox.Show("Password And Retype Password Not Same");
                    return;
                }
                if (dgvNotIssued.Rows.Count < 1)
                {
                    MessageBox.Show("Atleast one transaction should be added");
                    return;
                }
                var dataList = (List<Payment_PostingBO>)bindingSource_IssueNext.DataSource;
                if (dataList != null)
                    InsertEft_Issue(dataList);
                FormState_Execution(FormState.Saved);
                MessageBox.Show("Saved Successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                EFT_IssueBAL objBal = new EFT_IssueBAL();
                List<EFT_FileContentsBO> fileContentsList = new List<EFT_FileContentsBO>();
                Export_xls(txtFilePath.Text + "\\" + txtFileNo.Text.Trim());
                objBal.UpdateExportFlag_EFT_FileInfo(txtFileNo.Text.Trim());
                
                //Inserting File Contents
                var dataList = objBal.GetExport_ExcelDocByFileNo_Export(txtFileNo.Text,Indication_CompanyBankInformation.CityBank_IPOAccount_AccountNo,"");
                fileContentsList.Clear();
                foreach (var obj in dataList)
                {
                    EFT_FileContentsBO boObj = new EFT_FileContentsBO();
                    boObj.Account_Type = obj.Account_Type;
                    boObj.Amount = obj.Amount;
                    boObj.Bank_Account_No = obj.Bank_Account_No;
                    boObj.Bank_ID = obj.Bank_ID;
                    boObj.BankName = obj.BankName;
                    boObj.Branch_ID = obj.Branch_ID;
                    boObj.BranchName = obj.BranchName;
                    boObj.Cust_Code = obj.Cust_Code;
                    boObj.EftIssue_ID = obj.ID;
                    boObj.File_No_ID = obj.File_No_ID;
                    boObj.Received_Date = obj.Received_Date;
                    boObj.Req_ID = obj.Req_ID;
                    boObj.RoutingNo = obj.RoutingNo;
                    boObj.SenderAccNo = obj.SenderAccNumber;
                    boObj.EFT_Reason = obj.Reason;
                    fileContentsList.Add(boObj);
                }
                objBal.InsertEFT_FileContents(fileContentsList);
                ///////////-------------------------////////////

                MessageBox.Show("File Exported Successfully");
                FormState_Execution(FormState.FileExported);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }      

        private void btn_AutoFileGen_Click(object sender, EventArgs e)
        {
            int count;
            count = dgvNotIssued.Rows.Count;
            string fileNo = string.Empty;
            EFT_IssueBAL objBal = new EFT_IssueBAL();
            txtFileNo.Text = objBal.GetMaxFileNo_ByDate(dtToday.Value,count);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Report_Preview(string report)
        {
            if (report == Reports_Type.Summary_Reports_Name)
            {
                DataTable dtBEFTN = new DataTable();  
                EFT_IssueBAL EFT_IssueBAL = new EFT_IssueBAL();
                dtBEFTN = EFT_IssueBAL.GetBEFTN_ReportData(txtFileNo.Text, Indication_CompanyBankInformation.CityBank_TradeAccount_AccountNo,"");  //Change for just run an extra bank named added
                cr_BEFTN crBEFTNrpt = new cr_BEFTN(); 
                crBEFTNrpt.SetDataSource(dtBEFTN);
                frmReportViewer ReportViewer = new frmReportViewer();
                ReportViewer.crvReportViewer.DisplayGroupTree = false;
                ReportViewer.crvReportViewer.ReportSource = crBEFTNrpt;
                ReportViewer.crvReportViewer.ShowExportButton = false;
                foreach (ToolStrip ts in ReportViewer.crvReportViewer.Controls.OfType<ToolStrip>())
                {
                    foreach (ToolStripButton tsb in ts.Items.OfType<ToolStripButton>())
                    {   
                        //hack but should work. you can probably figure out a better method
                        if (tsb.ToolTipText.ToLower().Contains("print"))
                        {
                            //Adding a handler for our propose
                            tsb.ToolTipText = Reports_Type.Summary_Reports_Print_ToolTipMessage;
                            tsb.Click += new EventHandler(PrintButton_Click);
                        }
                    }
                }
                ReportViewer.Show();
            }
            else
            {
                EFT_IssueBAL EFT_IssueBAL = new EFT_IssueBAL();
                crEFT_Issue crEFT_Issue = new crEFT_Issue();
                frmReportViewer ReportViewer = new frmReportViewer();
                var dtEFT_Issue = EFT_IssueBAL.GetExport_ExcelDocByFileNo_Report(txtFileNo.Text.Trim(),Indication_CompanyBankInformation.CityBank_TradeAccount_AccountNo,"");
                crEFT_Issue.SetDataSource(dtEFT_Issue);
                ReportViewer.crvReportViewer.DisplayGroupTree = false;
                ReportViewer.crvReportViewer.ReportSource = crEFT_Issue;
                ReportViewer.crvReportViewer.ReportSource = crEFT_Issue;
                ReportViewer.crvReportViewer.ShowExportButton = false;
                foreach (ToolStrip ts in ReportViewer.crvReportViewer.Controls.OfType<ToolStrip>())
                {
                    foreach (ToolStripButton tsb in ts.Items.OfType<ToolStripButton>())
                    {
                        //hacky but should work. you can probably figure out a better method
                        if (tsb.ToolTipText.ToLower().Contains("print"))
                        {
                            //Adding a handler for our propose
                            tsb.ToolTipText = Reports_Type.Details_Reports_Print_ToolTipMessage;
                            tsb.Click += new EventHandler(PrintButton_Click);
                        }
                    }
                }
              
                ReportViewer.Show();
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
           
            if (((System.Windows.Forms.ToolStripButton)sender).ToolTipText == Reports_Type.Details_Reports_Print_ToolTipMessage)
            {
                printedDocument.Add(Reports_Type.Details_Reports_Name);
            }
            else if (((System.Windows.Forms.ToolStripButton)sender).ToolTipText == Reports_Type.Summary_Reports_Print_ToolTipMessage)
            {
                printedDocument.Add(Reports_Type.Summary_Reports_Name);
            }

     
            if (printedDocument.Contains(Reports_Type.Details_Reports_Name) && printedDocument.Contains(Reports_Type.Summary_Reports_Name))
                FormState_Execution(FormState.Printed);
        }
        
        private void btn_Preview_Click(object sender, EventArgs e)
        {
            try
            {
                Report_Preview(cmbReport.SelectedItem.ToString());
               // FormState_Execution(FormState.Saved);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void GetCommonInfo()
        {

            try
            {
                CommonInfoBal objCommonInfoBal = new CommonInfoBal();
                DataRow drCommonInfo = null;

                drCommonInfo = objCommonInfoBal.GetCommpanyInfo();

                if (drCommonInfo != null)
                {
                    _CommpanyName = drCommonInfo.Table.Rows[0][0].ToString();
                    _branchName = drCommonInfo.Table.Rows[0][1].ToString();
                    _branchAddress = drCommonInfo.Table.Rows[0][2].ToString();
                    _branchContactNumber = drCommonInfo.Table.Rows[0][3].ToString();


                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ExcelWorkbookBeforeSave(Excel.Workbook wb, bool saveAsUI, ref bool cancel)
        {
            //MessageBox.Show("Save Document Is Disabled!!");
            saveAsUI = false;
            cancel = true;            
        }


        //private void DeligateMethod_ButtonClosedActiveDeactive(bool IsActive)
        //{
        //    bool isEnable = IsActive;
        //    EnableMenuItem(GetSystemMenu(this.Handle, isEnable), SC_CLOSE, MF_GRAYED);
            
        //}
        
    }
}