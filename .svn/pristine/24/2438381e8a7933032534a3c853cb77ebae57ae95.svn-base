using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using CrystalDecisions.CrystalReports.Engine;
using BusinessAccessLayer.Constants;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using BusinessAccessLayer.BO;


namespace Reports
{
    public partial class frmIPOSuccessfulUnsuccessful : Form
    {
        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        public frmIPOSuccessfulUnsuccessful()
        {
            InitializeComponent();
        }
        IPOApplicationSuccessfulUnSuccessful objBAL = new IPOApplicationSuccessfulUnSuccessful();
        private void loadStatusNmae()
        {
            IPOProcessBAL process = new IPOProcessBAL();
            DataTable dt = new DataTable();
            dt = objBAL.GetIpoStatusNmae();
            cmbStatusName.DataSource = dt;
            cmbStatusName.DisplayMember = dt.Columns[0].ToString();
            cmbStatusName.ValueMember = dt.Columns[0].ToString();

            DataTable dtallSession = new DataTable();
            dtallSession = process.GetIPOSessionALL();
            Cmbcompanyname.DataSource = dtallSession;
            Cmbcompanyname.DisplayMember = dtallSession.Columns["Company_Name"].ToString();
            Cmbcompanyname.ValueMember = dtallSession.Columns["ID"].ToString();
            rdbRB.Checked = true;
            
        }

        private void FrmIPOSuccessfulUnsuccessful_Load(object sender, EventArgs e)
        {
            
            loadStatusNmae();
            if(cmbStatusName.Items.Count>0)
            cmbStatusName.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rdbRB.Checked == true)
            {
                RB();
            }
            else
            {
                NRB();
            }
             
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void ChkIndividualCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkIndividualCustomer.Checked == true)
            {
                CmbCustomerCode.Enabled = true;
                CustomerCode();
                if (CmbCustomerCode.Items.Count>0)
                {
                    CmbCustomerCode.SelectedIndex = 0; 
                }
               
            }
            else
            {
                CmbCustomerCode.Enabled = false;
                CmbCustomerCode.Text = "";
            }
        }
        private void CustomerCode()
        {
            DataTable dtcustCode = new DataTable();
            dtcustCode = objBAL.GetAllIpoCustomerCode();
            CmbCustomerCode.DataSource = dtcustCode;
            CmbCustomerCode.DisplayMember = dtcustCode.Columns[0].ToString();
            CmbCustomerCode.ValueMember = dtcustCode.Columns[0].ToString();
        }

        private void RB()
        {
            DataTable dt = new DataTable();
            dt = objBAL.IPOSuccessfulUnsuccessfulApplication(cmbStatusName.Text, Cmbcompanyname.Text, CmbCustomerCode.Text);
            crIPOSuccessfulUnsuccessful objRPT = new crIPOSuccessfulUnsuccessful();
            crIPOApproavedUniapproaved objRPTapp = new crIPOApproavedUniapproaved();

            frmIPOReportViewer viewer = new frmIPOReportViewer();
            if (cmbStatusName.Text == "Successfull" || cmbStatusName.Text == "Unsuccessfull")
            {
                objRPT.SetDataSource(dt);
                if (cmbStatusName.Text == "Successfull")
                {
                    ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
                           "IPO Successfull Status";
                }
                else if (cmbStatusName.Text == "Unsuccessfull")
                {
                    ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
                           "IPO Unsuccessfull Status";
                }

                GetCommonInfo();
                ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
                    _CommpanyName;
                ///// Load Branch Name
                ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
                    "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                viewer.crystalReportViewer1.ReportSource = objRPT;
                viewer.Show();
            }
            else if (cmbStatusName.Text == "All")
            {
                objRPT.SetDataSource(dt);
                ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
                               "IPO All Kind of Status";
                GetCommonInfo();
                ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
                    _CommpanyName;
                ///// Load Branch Name
                ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
                    "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                viewer.crystalReportViewer1.ReportSource = objRPT;
                viewer.Show();
            }
            else if (cmbStatusName.Text == "Approved")
            {
                objRPT.SetDataSource(dt);
                ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
                           "IPO Approved Status";
                GetCommonInfo();
                ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
                    _CommpanyName;
                ///// Load Branch Name
                ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
                    "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                viewer.crystalReportViewer1.ReportSource = objRPT;
                viewer.Show();
            }
            else if (cmbStatusName.Text == "Pending")
            {
                objRPT.SetDataSource(dt);
                ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
                       "IPO Pending Status";
                GetCommonInfo();
                ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
                    _CommpanyName;
                ///// Load Branch Name
                ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
                    "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                viewer.crystalReportViewer1.ReportSource = objRPT;
                viewer.Show();
            }
            else if (cmbStatusName.Text == "Rejected")
            {
                objRPT.SetDataSource(dt);
                ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
                       "IPO Rejected Status";
                GetCommonInfo();
                ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
                    _CommpanyName;
                ///// Load Branch Name
                ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
                    "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                viewer.crystalReportViewer1.ReportSource = objRPT;
                viewer.Show();
            }
            else if (cmbStatusName.Text == "Check")
            {
                objRPT.SetDataSource(dt);
                ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
                       "IPO Rejected Status";
                GetCommonInfo();
                ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
                    _CommpanyName;
                ///// Load Branch Name
                ((TextObject)objRPT.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
                    "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                viewer.crystalReportViewer1.ReportSource = objRPT;
                viewer.Show();
            }
        }
        private void NRB()
        {
            IPOReportBAL bal = new IPOReportBAL();
            DataTable dt = new DataTable();
            dt = bal.GetNRBSuccessfulUnsuccessful(cmbStatusName.Text, Cmbcompanyname.Text, CmbCustomerCode.Text);
            crNrbSuccessfulUnsuccessful nrb = new crNrbSuccessfulUnsuccessful();
            frmIPOReportViewer viewer = new frmIPOReportViewer();
            nrb.SetDataSource(dt);
            
            //GetCommonInfo();
            //((TextObject)nrb.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
            //    _CommpanyName;
            /////// Load Branch Name
            //((TextObject)nrb.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
            //    "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
            viewer.crystalReportViewer1.ReportSource = nrb;
            viewer.Show();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string File = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File = saveFileDialog1.FileName;
            }
            
            Export_xls(File);
        }

        private void Export_xls(string FileName)
        {
            IPOReportBAL bal = new IPOReportBAL();
            int dataSartingRowIndex = 7;

            string[] ColumnsHeader = new string[] { "Trec Code", "DPID", "Customer ID", "Applicants Name", "Bo ID No", "Applicant Category", "Currency", "Amount", "Draft No", "BankName", "Branch Name", "Date", "Security Code", "Remarks" };
            string[] ColumnsAlphabet = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            var missValue = System.Reflection.Missing.Value;

            var excelApp = new Excel.ApplicationClass();
            //ExcelDoc_Prepared(out excelApp);

            var workbook = excelApp.Workbooks.Add(missValue);
            var currentSheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;

            
            string password = string.Empty;
            //password = objBal.GetAllEFT_File_Info_ByFileNo(txtFileNo.Text.Trim()).File_Password;

            //Initial Formating
            currentSheet.Columns.NumberFormat = "@";
            currentSheet.Name = "KSCL EFT";

            Excel.Range rngColumns = currentSheet.get_Range("A" + dataSartingRowIndex, "" + ColumnsAlphabet[ColumnsHeader.Length] + "" + dataSartingRowIndex);
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
            currentSheet.get_Range("A5", "H5").Value2 = "NRB Print Date: " + DateTime.Today.Date.ToString("dd-MM-yyyy");
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
            DataTable dt = new DataTable();
            dt = bal.GetNRBSuccessfulUnsuccessful(cmbStatusName.Text, Cmbcompanyname.Text, CmbCustomerCode.Text);
            List<Export_ExcelDocBo> resultList = new List<Export_ExcelDocBo>();
            foreach (DataRow row in dt.Rows)
            {
                Export_ExcelDocBo obj = new Export_ExcelDocBo();
                obj.TrecCode = Convert.ToString((int)row["Trec Code"]);
                obj.DPID = (string)row["DPID"] ?? string.Empty;
                obj.Cust_Code = (string)row["Customer ID"] ?? string.Empty;
                obj.ReceiverName = (string)row["Applicants Name"] ?? string.Empty;
                obj.BOID = (string)row["Bo ID No"] ?? string.Empty;
                obj.ApplicantCategory = (string)row["Applicant Category"] ?? string.Empty;
                obj.Currency = (string)row["Currency"] ?? string.Empty;
                obj.Amount = Convert.ToDouble(row["Amount"]) != 0.00 ? Convert.ToDouble(row["Amount"]) : 0.00;
                obj.DraftNO = (string)row["Draft No"] ?? string.Empty;
                obj.BankName = (string)row["BankName"] ?? string.Empty;
                obj.BranchName = (string)row["Branch Name"] ?? string.Empty;
                obj.Received_Date = Convert.ToDateTime(row["Date"]);
                obj.SecurityCode = (string)row["Security Code"] ?? string.Empty;
                obj.Reason = (string)row["Remarks"] ?? string.Empty;
                resultList.Add(obj);

            }
            var dataList = resultList;
            int count_Row = dataSartingRowIndex + 1;
            foreach (var obj in dataList)
            {
                currentSheet.Cells[count_Row,1] = Convert.ToString(obj.TrecCode).Trim();
                currentSheet.Cells[count_Row, 2] = Convert.ToString(obj.DPID).Trim();
                currentSheet.Cells[count_Row, 3] = Convert.ToString(obj.Cust_Code).Trim();
                currentSheet.Cells[count_Row, 4] = Convert.ToString(obj.ReceiverName).Trim();
                currentSheet.Cells[count_Row, 5] = Convert.ToString(obj.BOID).Trim();
                currentSheet.Cells[count_Row, 6] = Convert.ToString(obj.ApplicantCategory).Trim();
                currentSheet.Cells[count_Row, 7] = Convert.ToString(obj.Currency).Trim();
                currentSheet.Cells[count_Row, 8] = Convert.ToString(obj.Amount).Trim();
                currentSheet.Cells[count_Row, 9] = Convert.ToString(obj.DraftNO).Trim();
                currentSheet.Cells[count_Row, 10] = Convert.ToString(obj.BankName).Trim();
                currentSheet.Cells[count_Row, 11] = Convert.ToString(obj.BranchName).Trim();
                currentSheet.Cells[count_Row, 12] = Convert.ToString(obj.Received_Date.ToShortDateString());
                currentSheet.Cells[count_Row, 13] = Convert.ToString(obj.SecurityCode).Trim();
                currentSheet.Cells[count_Row, 14] = Convert.ToString(obj.Reason).Trim();
                count_Row++;
            }
            //Column Resizing and Post Formatting
            Excel.Range rngALL = currentSheet.get_Range("A" + dataSartingRowIndex, "" + ColumnsAlphabet[ColumnsHeader.Length] + "" + (dataSartingRowIndex + (dataList.Count + 1)));
            rngALL.Columns.AutoFit();
            rngALL.VerticalAlignment = 3;
            rngALL.HorizontalAlignment = 3;

            //currentSheet.Protect(password, true, true, true, false, false, true, true, false, false, false, false, false, true, true, false);

            workbook.Author = "K-Secuirites Ltd.";
            workbook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, password, missValue,
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
    }
}
