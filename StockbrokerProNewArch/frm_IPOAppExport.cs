using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using Excel = Microsoft.Office.Interop.Excel;
using BusinessAccessLayer.BO;
using System.IO;

namespace StockbrokerProNewArch
{
    public partial class frm_IPOAppExport : Form
    {
        public frm_IPOAppExport()
        {
            InitializeComponent();
        }
        private void LoadCombo()
        {
            IPOProcessBAL ipoBal = new IPOProcessBAL();
            DataTable dt = ipoBal.GetIPOSessionALL();
            cmb_SessionName.DataSource = dt;
            cmb_SessionName.DisplayMember = "Company_Name";
            cmb_SessionName.ValueMember = "ID";
            cmb_SessionName.SelectedIndex = -1;
        }

        private void cmb_SessionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            IPOProcessBAL ipoBal = new IPOProcessBAL();
            if (cmb_SessionName.ValueMember != string.Empty)
            {

                int id = Convert.ToInt32(cmb_SessionName.SelectedValue);
                txt_SessionName.Text = ipoBal.GetIPOSessionName_CompanyName_BySessionID(id);
                txt_SessionID.Text = Convert.ToString(id);
            }
        }

        private void frm_IPOAppExport_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void btn_GetApplication_Click(object sender, EventArgs e)
        {
            //IPOProcessBAL ipoBal = new IPOProcessBAL();
            //int intTryParse=0;
            //int SessionIDTemp = 0;
            //if( int.TryParse(txt_SessionID.Text,out intTryParse) )
            //{
            //    SessionIDTemp = intTryParse;
            //}
            //DataTable dt=ipoBal.GetApplication(SessionIDTemp);
            //dgApplicationExport.DataSource = dt;
            IPOProcessBAL ipoBal = new IPOProcessBAL();
            int intTryParse = 0;
            int SessionIDTemp = 0;
            if (int.TryParse(txt_SessionID.Text, out intTryParse))
            {
                SessionIDTemp = intTryParse;
            }
            DataTable dt = ipoBal.GetApplication(SessionIDTemp, cmbcategory.Text);
            dgApplicationExport.DataSource = dt;
            CreateFileName_ForIssuer(SessionIDTemp, cmbcategory.Text);
        }
        private void CreateFileName_ForIssuer(int SessionID, string FileCategory)
        {
            IPOProcessBAL ipoBal = new IPOProcessBAL();
            string Comp_Short_Code = "";
            string ApplicatnCategory = "";
            Comp_Short_Code = ipoBal.GetCompanyShortCodeBySessionID(SessionID);
            ApplicatnCategory = cmbcategory.Text;
            if (ApplicatnCategory == "NRB")
            {
                //txt_FileNo.Text = Comp_Short_Code + "_" + "DSE" + "_" + "122"+"_" + ApplicatnCategory ;
                txt_FileNo.Text = Comp_Short_Code + "_" + "DSE" + "_" + ApplicatnCategory + "_" + "122";
            }
            else if (ApplicatnCategory == "RB")
            {
                txt_FileNo.Text = Comp_Short_Code + "_" + "DSE" + "_"+ "122";
            }
            txt_FileNo.ReadOnly = true;
            txt_FileNo.Enabled = false;
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                txtFileLocation.Text = folderBrowserDialog1.SelectedPath;
        }

        private void Export_xls(string FileName)
        {
            IPOProcessBAL objBal = new IPOProcessBAL();
            CommonBAL comBal=new CommonBAL();
            int dataSartingRowIndex = 7;

            DateTime dt_Today = comBal.GetCurrentServerDate();
            string[] ColumnsHeader = new string[] { "Cust_ID", "Name", "BOID", "NoOfShare", "TotalAmount", "CategoryApplicant ", "TotalShare ", "ReceiverName" };
            string[] ColumnsAlphabet = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            var missValue = System.Reflection.Missing.Value;

            var excelApp = new Excel.ApplicationClass();
            //ExcelDoc_Prepared(out excelApp);

            var workbook = excelApp.Workbooks.Add(missValue);
            var currentSheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;
 
            var dataList = objBal.GetApplication_ForExport(Convert.ToInt32(txt_SessionID.Text));
            
            string password = string.Empty;
            password =txt_Password.Text;

            //Initial Formating
            currentSheet.Columns.NumberFormat = "@";
            currentSheet.Name = "KSCL IPOApplication";

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
            currentSheet.get_Range("A5", "H5").Value2 = "EFT Issued Date: " + dt_Today.ToString("dd-MM-yyyy");
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

            int count_Row = dataSartingRowIndex + 1;
            foreach (DataRow obj in dataList.Rows)
            {
                currentSheet.Cells[count_Row, 1] = Convert.ToString(obj["Cust_Code"]).Trim();
                currentSheet.Cells[count_Row, 2] = Convert.ToString(obj["Cust_Name"]).Trim();
                currentSheet.Cells[count_Row, 3] = Convert.ToString(obj["BO_ID"]).Trim();
                currentSheet.Cells[count_Row, 4] = Convert.ToString(obj["No_Of_Share"]).Trim();
                currentSheet.Cells[count_Row, 5] = Convert.ToString(obj["TotalAmount"]).Trim();
                currentSheet.Cells[count_Row, 6] = Convert.ToString(obj["CategoryApplicant"]).Trim();
                currentSheet.Cells[count_Row, 7] = Convert.ToString(obj["No_Of_Share"]).Trim();
                currentSheet.Cells[count_Row, 8] = Convert.ToString(GlobalVariableBO._userName).Trim();
                count_Row++;
            }
            //Column Resizing and Post Formatting
            Excel.Range rngALL = currentSheet.get_Range("A" + dataSartingRowIndex, "" + ColumnsAlphabet[ColumnsHeader.Length] + "" + (dataSartingRowIndex + (dataList.Rows.Count + 1)));
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

        private void btn_Process_Click(object sender, EventArgs e)
        {
            try
            {                
                Validation();
                string FileNo = txt_FileNo.Text;
                string FolderLocation = txtFileLocation.Text;
                //Export_xls(FolderLocation + "\\" + FileNo);
                //MessageBox.Show("Data Export Successfully!!");
                IPOProcessBAL bal = new IPOProcessBAL();
                string sessionId = cmb_SessionName.SelectedValue.ToString();
                //DataTable dt = bal.GetExportForIssuer(sessionId);
                DataTable dt = bal.GetExportForIssuer(sessionId,cmbcategory.Text);
                if (dt.Rows.Count > 0)
                {
                    Write(dt, FolderLocation + "\\" + FileNo);
                    MessageBox.Show("Data Export Successfully!!");

                }
                else
                {
                    MessageBox.Show("No Data for export.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Validation()
        {
            if (txt_FileNo.Text == string.Empty)
                throw new Exception("File No Not Set!!");
            if(txtFileLocation.Text == string.Empty)
                throw new Exception("Where Create The File Didn't Set!!");
            //if (txt_Password.Text == string.Empty)
            //    throw new Exception("Password Not Set");
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Write(DataTable dt,string fileName)
        {
            int i = 0;
            string sFileName = fileName+".txt";
            StreamWriter sw = null;
            try
            {
                //SaveFileDialog oDialog = new SaveFileDialog();
                //oDialog.Filter = "Text files | *.txt";
                //if (oDialog.ShowDialog() == DialogResult.OK)
                //{
                //    sFileName = oDialog.FileName;
                //}
                if (sFileName != null)
                {
                    sw = new StreamWriter(sFileName, false);
                    foreach (DataRow row in dt.Rows)
                    {
                        object[] array = row.ItemArray;

                        for (i = 0; i < array.Length - 1; i++)
                        {
                            sw.Write(array[i].ToString().Trim() + "~");
                        }
                        sw.WriteLine(array[i].ToString());
                    } 
                    sw.Close();
                    //MessageBox.Show("Report saved with file: " + sFileName, "To Text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();


                }
                else
                {
                    //oEXLApp.ActiveWorkbook.Close(false, Missing.Value, Missing.Value);
                    MessageBox.Show("Cannot export to Text...", "Can't export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show("Invalid Operation : \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WriteForCsv(DataTable dt,string fileName)
        {
            int i = 0;
            string sFileName = fileName+".csv";
            StreamWriter sw = null;
            try
            {
                //SaveFileDialog oDialog = new SaveFileDialog();
                //oDialog.Filter = "Text files | *.txt";
                //if (oDialog.ShowDialog() == DialogResult.OK)
                //{
                //    sFileName = oDialog.FileName;
                //}
                if (sFileName != null)
                {
                    sw = new StreamWriter(sFileName, false);
                    foreach (DataRow row in dt.Rows)
                    {
                        object[] array = row.ItemArray;

                        for (i = 0; i < array.Length - 1; i++)
                        {
                            sw.Write(array[i].ToString().Trim() + ",");
                        }
                        sw.WriteLine(array[i].ToString());
                    }
                    
                    sw.Close();
                    //MessageBox.Show("Report saved with file: " + sFileName, "To Text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();


                }
                else
                {
                    //oEXLApp.ActiveWorkbook.Close(false, Missing.Value, Missing.Value);
                    MessageBox.Show("Cannot export to Text...", "Can't export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Invalid Operation : \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Process_Csv_Click(object sender, EventArgs e)
        {
            try
            {
                Validation();
                string FileNo = txt_FileNo.Text;
                string FolderLocation = txtFileLocation.Text;
                
                IPOProcessBAL bal = new IPOProcessBAL();
                string sessionId = cmb_SessionName.SelectedValue.ToString();
                DataTable dt = bal.GetExportForIssuer(sessionId);
                if (dt.Rows.Count > 0)
                {
                    WriteForCsv(dt, FolderLocation + "\\" + FileNo);
                    
                    MessageBox.Show("Data Export Successfully!!");

                }
                else
                {
                    MessageBox.Show("No Data for export.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured." + ex.Message);
            }
        }

        private void dgApplicationExport_DataSourceChanged(object sender, EventArgs e)
        {
            lbl_Count_Grid.Text = "Count: " + dgApplicationExport.Rows.Count;
        }


    }
}
