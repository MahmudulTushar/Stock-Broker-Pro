using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using System.Net.Mail;
using System.Net;
using CrystalDecisions.CrystalReports.Engine;
using Reports;

namespace StockbrokerProNewArch
{
    public partial class frmChequeConfirmationByEmail : Form
    {
        public frmChequeConfirmationByEmail()
        {
            InitializeComponent();
        }

        private string _emailTo;
        private string _emailFrom;
        private string _emailSubject;
        private string _emailMessage;
       

        private DataTable _dtChequeRequistionInfo = new DataTable();
       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChequeConfirmationByEmail_Load(object sender, EventArgs e)
        {
            GetChequePaymentInfo();
        }

        private void GetEmailConfirmationData()
        {
            try
            {
                EmailConfirmationBAL objEmailConfirmation = new EmailConfirmationBAL();
                DataTable data = new DataTable();
                data = objEmailConfirmation.GetEmailConfirmation();

                _emailMessage = data.Rows[0]["Body"].ToString();
                _emailFrom = data.Rows[0]["From"].ToString();
                _emailSubject = data.Rows[0]["Subject"].ToString();
                _emailTo = data.Rows[0]["To"].ToString();

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GetChequePaymentInfo()
        {
            try
            {
                CheckRequisitionBAL objChequeReqistationBal = new CheckRequisitionBAL();
                DataTable data = new DataTable();
                data = objChequeReqistationBal.ChequePaymentInfo(dtpRequistionDate.Value);
                _dtChequeRequistionInfo = data;
                dgvInfo.DataSource = data;
                dgvInfo.Columns["Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInfo.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInfo.Columns["Amount"].DefaultCellStyle.Format = "N";


                lblTotalRecoed.Text = "Total Record: " + dgvInfo.Rows.Count.ToString();

                if (dgvInfo.Rows.Count > 0)
                {
                    btnExport.Enabled = true;
                }

                else
                {
                    btnExport.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpRequistionDate_ValueChanged(object sender, EventArgs e)
        {
            GetChequePaymentInfo();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ProcessExcelFile();
        }

        private void ProcessExcelFile()
        {
            try
            {

                Microsoft.Office.Interop.Excel.Range xlworkSheetRange=null;
                Microsoft.Office.Interop.Excel.Application xlApp;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                Microsoft.Office.Interop.Excel.Range xlEntireColumn = null;
                Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.get_Range("A1", "HM232");
                range.NumberFormat = "0";
               


                ////////********** Set Company Name & Address ***************////////
                CommonInfoBal objComm=new CommonInfoBal();
                DataTable data=new DataTable();
                data=objComm.GetCompanyNameHeadOffice();

                
                //////// *************** Company Name  ***************** ///////////
                xlWorkSheet.get_Range("A1", "F1").Merge(true);
                xlWorkSheet.get_Range("A1", "F1").Value2 = data.Rows[0]["BrokerName"].ToString();
                xlWorkSheet.get_Range("A1", "F1").HorizontalAlignment = 3;
                xlWorkSheet.get_Range("A1", "F1").Font.Name = "Arial";
                xlWorkSheet.get_Range("A1", "F1").Font.Bold = true;
                xlWorkSheet.get_Range("A1", "F1").Font.Size =11;
                xlWorkSheet.get_Range("A1", "F1").RowHeight = 15;


                //////// *************** Company Name  ***************** ///////////
                xlWorkSheet.get_Range("A2", "F2").Merge(true);
                xlWorkSheet.get_Range("A2", "F2").Value2 = data.Rows[0]["Address"].ToString();
                xlWorkSheet.get_Range("A2", "F2").HorizontalAlignment = 3;
                xlWorkSheet.get_Range("A2", "F2").Font.Name = "Arial";
                xlWorkSheet.get_Range("A2", "F2").Font.Size = 10;
                xlWorkSheet.get_Range("A2", "F2").RowHeight = 12.75;

                //////// *************** Phone & Fax  ***************** ///////////
                xlWorkSheet.get_Range("A3", "F3").Merge(true);
                xlWorkSheet.get_Range("A3", "F3").Value2 = "Phone: " +data.Rows[0]["Telephone"].ToString() + ",Fax: "+ data.Rows[0]["Fax"].ToString();
                xlWorkSheet.get_Range("A3", "F3").HorizontalAlignment = 3;
                xlWorkSheet.get_Range("A3", "F3").Font.Name = "Arial";
                xlWorkSheet.get_Range("A3", "F3").Font.Size = 10;
                xlWorkSheet.get_Range("A3", "F3").RowHeight = 12.75;


                //////// *************** Contact Numner  ***************** ///////////
                xlWorkSheet.get_Range("A4", "F4").Merge(true);
                xlWorkSheet.get_Range("A4", "F4").Value2 = "Contact No: 01720220321, 01710878300";
                xlWorkSheet.get_Range("A4", "F4").HorizontalAlignment = 3;
                xlWorkSheet.get_Range("A4", "F4").Font.Name = "Arial";
                xlWorkSheet.get_Range("A4", "F4").Font.Size = 10;
                xlWorkSheet.get_Range("A4", "F4").RowHeight = 12.75;

                //////// *************** Cheque Requisition Date  ***************** ///////////
                xlWorkSheet.get_Range("A5", "F5").Merge(true);
                xlWorkSheet.get_Range("A5", "F5").Value2 ="Cheque Issued Date: "+dtpRequistionDate.Value.ToString("dd-MM-yyyy");
                xlWorkSheet.get_Range("A5", "F5").HorizontalAlignment = 3;
                xlWorkSheet.get_Range("A5", "F5").Font.Name = "Arial";
                xlWorkSheet.get_Range("A5", "F5").Font.Bold = true;
                xlWorkSheet.get_Range("A5", "F5").Font.Size = 9;
                xlWorkSheet.get_Range("A5", "F5").Font.Underline = true;
                xlWorkSheet.get_Range("A5", "F5").RowHeight = 12.75;


                //////// *************** Account No  ***************** ///////////
                xlWorkSheet.get_Range("A7","A7").Value2 = "Account No";
                xlWorkSheet.get_Range("A7", "A7").ColumnWidth = 13;
                xlWorkSheet.get_Range("A7", "A7").Font.Name = "Arial";
                xlWorkSheet.get_Range("A7","A7").Font.Bold = true;
                xlWorkSheet.get_Range("A7","A7").Font.Size = 9;
                xlWorkSheet.get_Range("A7", "A7").WrapText = true;
                xlWorkSheet.get_Range("A7", "A7").RowHeight = 12.75;

                //////// *************** Date  ***************** ///////////
                xlWorkSheet.get_Range("B7", "B7").Value2 = "Date";
                xlWorkSheet.get_Range("B7", "B7").Font.Name = "Arial";
                xlWorkSheet.get_Range("B7", "B7").ColumnWidth = 9.71;
                xlWorkSheet.get_Range("B7", "B7").Font.Bold = true;
                xlWorkSheet.get_Range("B7", "B7").Font.Size = 9;
                xlWorkSheet.get_Range("B7", "B7").WrapText = true;
                xlWorkSheet.get_Range("B7", "B7").RowHeight = 12.75;
                

                //////// *************** Name of the Benificiery  ***************** ///////////
                xlWorkSheet.get_Range("C7", "C7").Value2 = "Name of the Benificiery";
                xlWorkSheet.get_Range("C7", "C7").Font.Name = "Arial";
                xlWorkSheet.get_Range("C7", "C7").ColumnWidth = 25.14;
                xlWorkSheet.get_Range("C7", "C7").Font.Bold = true;
                xlWorkSheet.get_Range("C7", "C7").Font.Size = 9;
                xlWorkSheet.get_Range("C7", "C7").WrapText = true;
                xlWorkSheet.get_Range("C7", "C7").RowHeight = 12.75;

                //////// *************** Cheque Serial Nory  ***************** ///////////
                xlWorkSheet.get_Range("D7", "D7").Value2 = "Cheque Serial No";
                xlWorkSheet.get_Range("D7", "D7").Font.Name = "Arial";
                xlWorkSheet.get_Range("D7", "D7").ColumnWidth = 14;
                xlWorkSheet.get_Range("D7", "D7").Font.Bold = true;
                xlWorkSheet.get_Range("D7", "D7").Font.Size = 9;
                xlWorkSheet.get_Range("D7", "D7").WrapText = true;
                xlWorkSheet.get_Range("D7", "D7").RowHeight = 12.75;

                //////// *************** Amount  ***************** ///////////
                xlWorkSheet.get_Range("E7", "E7").Value2 = "Amount";
                xlWorkSheet.get_Range("E7", "E7").ColumnWidth = 9.71;
                xlWorkSheet.get_Range("E7", "E7").Font.Name = "Arial";
                xlWorkSheet.get_Range("E7", "E7").Font.Bold = true;
                xlWorkSheet.get_Range("E7", "E7").Font.Size = 9;
                xlWorkSheet.get_Range("E7", "E7").WrapText = true;
                xlWorkSheet.get_Range("E7", "E7").RowHeight = 12.75;


                //////// *************** A/C Pay/Cash  ***************** ///////////
                xlWorkSheet.get_Range("F7", "F7").Value2 = "A/C Pay/Cash";
                xlWorkSheet.get_Range("F7", "F7").ColumnWidth = 9.57;
                xlWorkSheet.get_Range("F7", "F7").Font.Name = "Arial";
                xlWorkSheet.get_Range("F7", "F7").Font.Bold = true;
                xlWorkSheet.get_Range("F7", "F7").Font.Size = 9;
                xlWorkSheet.get_Range("F7", "F7").WrapText =true;
                xlWorkSheet.get_Range("F7", "F7").RowHeight = 12.75;



                int i = 0;
                int j = 0;
               
              

                if(dgvInfo.Rows.Count>0)
                {
                    for (i = 0; i <= dgvInfo.RowCount - 1; i++)
                    {
                        for (j = 0; j <= dgvInfo.ColumnCount - 1; j++)
                        {
                            xlWorkSheet.get_Range(xlWorkSheet.Cells[i + 8, j + 1], xlWorkSheet.Cells[i + 8, j + 1]).RowHeight = 18;

                            if(j==1)
                            {
                                xlWorkSheet.get_Range(xlWorkSheet.Cells[i + 8, j + 1], xlWorkSheet.Cells[i + 8, j + 1]).NumberFormat="@";
                            }

                            xlWorkSheet.get_Range(xlWorkSheet.Cells[i + 8, j + 1], xlWorkSheet.Cells[i + 8, j + 1]).Font.Name = "Arial";
                            xlWorkSheet.get_Range(xlWorkSheet.Cells[i + 8, j + 1], xlWorkSheet.Cells[i + 8, j + 1]).Font.Size = 10;
                            xlWorkSheet.Cells[i + 8, j + 1] =_dtChequeRequistionInfo.Rows[i][j].ToString();
                            xlEntireColumn = range.EntireColumn;
                            xlEntireColumn.AutoFit();
                        }
                    }
                }

               


                //////// *************** Issused By  ***************** ///////////
                i = i + 15;

               
                xlWorkSheet.get_Range("A"+i,"B"+i).Merge(true);
                xlWorkSheet.get_Range("A"+i,"B"+i).Value2 = "Mohammad Rafiqul Islam";
                xlWorkSheet.get_Range("A" + i , "B" + i).HorizontalAlignment = 1;
                xlWorkSheet.get_Range("A" + i, "B" + i).Font.Name = "Arial";
                xlWorkSheet.get_Range("A" + i, "B" + i).Font.Size =10;
                xlWorkSheet.get_Range("A" + i, "B" + i).Font.Underline =true;
                xlWorkSheet.get_Range("A" + i, "B" + i).RowHeight = 12.75;


                //////// *************** Issused By  ***************** ///////////
                xlWorkSheet.get_Range("E" + i, "F" + i).Merge(true);
                xlWorkSheet.get_Range("E" + i, "F" + i).Value2 = "Md Rafiqul Islam";
                xlWorkSheet.get_Range("E" + i, "F" + i).Font.Name = "Arial";
                xlWorkSheet.get_Range("E" + i, "F" + i).Font.Size = 10;
                xlWorkSheet.get_Range("E" + i, "F" + i).Font.Underline = true;
                xlWorkSheet.get_Range("E" + i, "F" + i).WrapText = true;
                xlWorkSheet.get_Range("E" + i, "F" + i).RowHeight = 12.75;


                //////// *************** Approved By  ***************** ///////////
                xlWorkSheet.get_Range("A" + (i + 1), "B" + (i + 1)).Merge(true);
                xlWorkSheet.get_Range("A" + (i + 1), "B" + (i + 1)).Value2 = "Issued By";
                xlWorkSheet.get_Range("A" + (i + 1), "B" + (i + 1)).HorizontalAlignment = 3;
                xlWorkSheet.get_Range("A" + (i + 1), "B" + (i + 1)).Font.Name = "Arial";
                xlWorkSheet.get_Range("A" + (i + 1), "B" + (i + 1)).Font.Size = 10;
                xlWorkSheet.get_Range("A" + (i + 1), "B" + (i + 1)).WrapText = true;
                xlWorkSheet.get_Range("A" + (i + 1), "B" + (i + 1)).RowHeight =18;
                
                xlWorkSheet.get_Range("E" + (i + 1), "F" + (i + 1)).Merge(true);
                xlWorkSheet.get_Range("E" + (i + 1), "F" + (i + 1)).Value2 = "Approved By";
                xlWorkSheet.get_Range("E" + (i + 1), "F" + (i + 1)).Font.Name = "Arial";
                xlWorkSheet.get_Range("E" + (i + 1), "F" + (i + 1)).Font.Size = 10;
                xlWorkSheet.get_Range("E" + (i + 1), "F" + (i + 1)).WrapText = true;
                xlWorkSheet.get_Range("E" + (i + 1), "F" + (i + 1)).RowHeight = 12.75;

                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

               MessageBox.Show("File Secessfully Exported.");
    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }


        private void SendMail()
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
                client.Credentials = new NetworkCredential("rumon10@gmail.com", "rumonkumar");
                MailMessage msg = new MailMessage();

                    msg.From = new MailAddress("rumon10@gmail.com");
                    msg.Subject =_emailSubject;
                    msg.To.Add(_emailTo);

                    msg.Body =_emailMessage;
                    client.Send(msg);

                    MessageBox.Show("Send Secessfully....");
              
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }

        private void btnBalenceRpt_Click(object sender, EventArgs e)
        {
            
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
           

        }

       

    }
}
