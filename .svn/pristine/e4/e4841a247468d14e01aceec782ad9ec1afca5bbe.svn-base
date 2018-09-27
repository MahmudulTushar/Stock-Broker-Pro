using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using StockbrokerProNewArch.Classes;
using StockbrokerProNewArch.Properties;
using System.Drawing.Printing;

namespace StockbrokerProNewArch
{
    public partial class CheckPrintingNew : Form
    {
        private string _bankName;
        private string _Author;
        int _requisitionSerial;
        int _paymentId;
        string _checkNo;
        string _voucherNo;
        private int _iSACPayee;

        private string EFT_Voucher_Autogen = "(Auto Gen)";

        public CheckPrintingNew()
        {
            InitializeComponent();
        }
        private void CheckPrintingNew_Load(object sender, EventArgs e)
        {
            ddlBankName.SelectedIndex = 0;
            ddlAuthor.SelectedIndex = 0;
            LoadGridData();
            PrinterSetting();
        }

        private void PrinterSetting()
        {
            PaperSize paperSize = new PaperSize("Chk", 350, 1000);
            paperSize.RawKind = (int)PaperKind.Custom;

            Margins margins = new Margins(0, 0, 0, 0);
            printCheck.DefaultPageSettings.PaperSize = paperSize;
            printCheck.DefaultPageSettings.Margins = margins;
            printCheck.DefaultPageSettings.Landscape = true;
            printCheck.DefaultPageSettings.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;
            printCheck.DefaultPageSettings.PrinterSettings.DefaultPageSettings.Margins = margins;

            PrinterSettings printerSettings = new PrinterSettings();
            printerSettings.PrinterName = GetDefaultPrinter();
            printerSettings.DefaultPageSettings.PaperSize = paperSize;
            printerSettings.DefaultPageSettings.Landscape = true;
            //PrintingSystem.Document.AutoFitToDocumentWidth = 1;


        }

        private void LoadGridData()
        {
            CheckPrintNewBAL checkPrintBal = new CheckPrintNewBAL();
            DataTable dtCheckInfo = checkPrintBal.GetAllCheckReceiver();
            dtgCheckReceiver.DataSource = dtCheckInfo;
            dtgCheckReceiver.Columns[2].DefaultCellStyle.Format = "N";
            this.dtgCheckReceiver.Columns[4].Visible = false;
            this.dtgCheckReceiver.Columns[5].Visible = false;
            this.dtgCheckReceiver.Columns[6].Visible = false;

            dtgCheckReceiver.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            lblRecord.Text = "Total Record : " + dtgCheckReceiver.Rows.Count;
            if (dtgCheckReceiver.Rows.Count <= 0)
            {
                ClearAll();
            }
        }

        private void btnGenerateSerial_Click(object sender, EventArgs e)
        {
            if (txtCheckNo.Text.Trim() != "")
            {
                txtCheckNo.Text = Convert.ToString(Convert.ToInt32(txtCheckNo.Text) + 1);
            }
            else
            {
                txtCheckNo.Text = "";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtClientCode.Text.Trim() == "")
            {
                MessageBox.Show("No customer has been select for printing", "Invalid Selection.");
                return;
            }
            else if (txtCheckNo.Text.Trim() == "")
            {
                MessageBox.Show("Enter the Cheque No.", "Field Required.");
                return;
            }
            else if (txtVoucherNo.Text.Trim() == "")
            {
                MessageBox.Show("Enter the Voucher No.", "Field Required.");
                return;
            }
            else
            {
                PaymentInfoBAL paymentBal = new PaymentInfoBAL();
                GetCheckedData();
                if (IsValid())
                {
                    try
                    {
                        //Locking.............
                        if (!IsLockedVoucherNo())
                        {
                            paymentBal.LockVoucherNo();
                            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                            //previewDialog.Margin = new Padding(0);
                            //previewDialog.Document = this.printCheck;
                            //previewDialog.Show();
                            SetVoucherNo();
                            printCheck.Print();
                            UpdateDone();
                            paymentBal.UpdateSerialNo();
                            //Unlocking...............
                            paymentBal.UnLockVoucherNo();
                            LoadGridData();
                            ddlBankName.Focus();

                        }
                        else
                        {
                            throw new Exception("Some one processing,please wait ");
                        }
                    }
                    catch (Exception ex)
                    {
                        //Unlock...............
                        paymentBal.UnLockVoucherNo();
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        private bool IsValid()
        {
            CheckPrintNewBAL checkPrintNewBal = new CheckPrintNewBAL();
            bool check;
            bool voucher;
            check = checkPrintNewBal.ValidateCheckNo(txtCheckNo.Text);
            voucher = checkPrintNewBal.ValidateVoucherNo(txtVoucherNo.Text);
            if (check && voucher)
            {
                return true;
            }
            else if (check && !voucher)
            {
                MessageBox.Show("Voucher No. Allready Exists.");
                return false;
            }
            else if (voucher && !check)
            {
                MessageBox.Show("Cheque No. Allready Exists.");
                return false;
            }
            else
            {
                MessageBox.Show("Cheque No. and Voucher No. Allready Exists.");
                return false;
            }
        }

        private bool UpdateDone()
        {
            bool result = false;
            CheckPrintNewBAL checkPrintNewBal = new CheckPrintNewBAL();
            PaymentInfoBAL paymentBal = new PaymentInfoBAL();
            _voucherNo = txtVoucherNo.Text;
            _checkNo = txtCheckNo.Text;

            if (chkACPayee.Checked)
                _iSACPayee = 1;
            else
                _iSACPayee = 0;

            result = checkPrintNewBal.UpdateRequiredData(_paymentId, _requisitionSerial, _checkNo, _voucherNo, _iSACPayee);
            return result;

        }

        private void GetCheckedData()
        {
            if (ddlBankName.SelectedIndex == 0)
            {
                _bankName = "CITY";
            }
            else
            {
                _bankName = "RUPALI";
            }
            if (ddlAuthor.SelectedIndex == 0)
            {
                _Author = "";
            }
            else if (ddlAuthor.SelectedIndex == 1)
            {
                _Author = "Managing Director";
            }
            else
            {
                _Author = "Director"; ;
            }
        }

        private void dtgCheckReceiver_SelectionChanged(object sender, EventArgs e)
        {
            LoadDataFromGrid();
        }
        private void LoadDataFromGrid()
        {
            foreach (DataGridViewRow row in this.dtgCheckReceiver.SelectedRows)
            {
                txtClientCode.Text = dtgCheckReceiver[0, row.Index].Value.ToString();
                txtName.Text = dtgCheckReceiver[1, row.Index].Value.ToString();
                txtAmount.Text = dtgCheckReceiver[2, row.Index].Value.ToString();
                if (dtgCheckReceiver[3, row.Index].Value != DBNull.Value)
                    dtpDate.Value = Convert.ToDateTime(dtgCheckReceiver[3, row.Index].Value);
                _paymentId = Convert.ToInt32(dtgCheckReceiver[4, row.Index].Value);
                _requisitionSerial = Convert.ToInt32(dtgCheckReceiver[5, row.Index].Value);
                _iSACPayee = Int32.Parse(dtgCheckReceiver[6, row.Index].Value.ToString());

                if (_iSACPayee == 1)
                    chkACPayee.Checked = true;
                else
                    chkACPayee.Checked = false;
            }
        }

        private void ClearAll()
        {
            txtVoucherNo.Text = "";
            txtName.Text = "";
            txtClientCode.Text = "";
            txtCheckNo.Text = "";
            txtAmount.Text = "";
            ddlBankName.SelectedIndex = 0;
            ddlAuthor.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printCheck_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Graphics graphics = e.Graphics;
            switch (_bankName)
            {
                case "CITY":
                    //ChequePrintSetup(e);
                    LoadCityBankData(e);
                    break;
                case "RUPALI":
                    LoadRupaliBankData(graphics);
                    break;
            }

            e.PageSettings.PaperSize.RawKind = (int)PaperKind.Custom;
            e.PageSettings.PaperSize = new PaperSize("Cheque", 350, 1000);

        }
        private void LoadRupaliBankData(Graphics graphics)
        {
            string downdateString = "";
            string upwDate = "";
            string custID = "";
            string custName = "";
            string amount = "";
            string amountWords = "";
            string brokerName = "";
            string author = "";
            string branchName = "";

            CheckPrintNewBAL checkPrintBal = new CheckPrintNewBAL();
            DataTable dtCheckInfo = new DataTable();
            dtCheckInfo = checkPrintBal.GetDataForPrinting(_paymentId, _requisitionSerial, _Author);
            System.Drawing.Font font = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point);
            System.Drawing.Font fontBold = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
            System.Drawing.Font fontItalic = new Font("Arial", 12, FontStyle.Italic, GraphicsUnit.Point);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            if (dtCheckInfo.Rows.Count > 0)
            {
                try
                {
                    downdateString = Convert.ToDateTime(dtCheckInfo.Rows[0]["Received_Date"]).ToString("dd-MMM-yyyy");
                    upwDate = Convert.ToDateTime(dtCheckInfo.Rows[0]["Received_Date"]).ToString("ddMMyyyy");
                    custID = "ID: " + dtCheckInfo.Rows[0]["Cust_Code"].ToString();
                    custName = dtCheckInfo.Rows[0]["Cust_Name"].ToString();
                    amount = dtCheckInfo.Rows[0]["Amount"].ToString();
                    amountWords = dtCheckInfo.Rows[0]["Amount_Words"].ToString();
                    brokerName = dtCheckInfo.Rows[0]["Broker_Name"].ToString();
                    author = dtCheckInfo.Rows[0]["Author"].ToString();
                    branchName = dtCheckInfo.Rows[0]["Branch_ID"].ToString();
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error Occured." + exp.Message);
                }
                float x = 780;
                float y = 79;
                float space = 26;
                if (chkACPayee.Checked)
                {
                    Image myImage = Resources.APO;
                    graphics.DrawImage(myImage, 250, 100);
                }

                //left side
                StringFormat sf = new StringFormat(StringFormatFlags.DirectionVertical);
                //graphics.DrawString(companyACNo, font, solidBrush, 70, 200);
                graphics.RotateTransform(180);
                graphics.DrawString(downdateString, fontBold, solidBrush, 91, 158, sf);
                graphics.DrawString(custID, fontBold, solidBrush, 98, 192, sf);
                graphics.DrawString(custName, font, solidBrush, 65, 221, sf);
                graphics.DrawString(amount, fontBold, solidBrush, 105, 258, sf);
                //graphics.DrawString(branchName, font, solidBrush, 80, 450);
                graphics.ResetTransform();


                //Middle side
                graphics.DrawString(custName, fontBold, solidBrush, 318, 140);
                graphics.DrawString(amountWords, fontBold, solidBrush, 381, 174);
                //Right Side
                CheckDateFormat(upwDate, x, y, space, graphics);
                graphics.DrawString(amount, fontBold, solidBrush, 778, 184);
                graphics.DrawString(brokerName, fontItalic, solidBrush, 600, 350);
                graphics.DrawString(author, fontItalic, solidBrush, 650, 400);
            }

        }

        private void LoadCityBankData(PrintPageEventArgs e)
        {

            //Print Setup
            e.PageSettings.PaperSize.RawKind = (int)PaperKind.Custom;
            e.PageSettings.PaperSize = new PaperSize("Cheque", 350, 1000);
            e.PageSettings.Margins = new Margins(0, 0, 0, 0);
            e.PageSettings.Landscape = true;
            e.PageSettings.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("Cheque", 350, 1000);
            e.PageSettings.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

            Graphics graphics = e.Graphics;
            string downdateString = "";
            string upwDate = "";
            string custID = "";
            string custName = "";
            string amount = "";
            string amountWords = "";
            string brokerName = "";
            string author = "";
            string branchName = "";
            string companyACNo = "3101085921001";
            CheckPrintNewBAL checkPrintBal = new CheckPrintNewBAL();
            DataTable dtCheckInfo = new DataTable();
            dtCheckInfo = checkPrintBal.GetDataForPrinting(_paymentId, _requisitionSerial, _Author);
            System.Drawing.Font font = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point);
            System.Drawing.Font LCfont = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);
            System.Drawing.Font fontBold = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
            System.Drawing.Font fontBold_Arial_11 = new Font("Arial", 11, FontStyle.Bold, GraphicsUnit.Point);
            System.Drawing.Font fontItalic = new Font("Arial", 12, FontStyle.Italic, GraphicsUnit.Point);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            if (dtCheckInfo.Rows.Count > 0)
            {
                try
                {
                    downdateString = Convert.ToDateTime(dtCheckInfo.Rows[0]["Received_Date"]).ToString("dd-MMM-yyyy");
                    upwDate = dtpDate.Value.ToString("dd-MM-yyyy");
                    custID = "ID: " + dtCheckInfo.Rows[0]["Cust_Code"].ToString();
                    custName = dtCheckInfo.Rows[0]["Cust_Name"].ToString();
                    amount = dtCheckInfo.Rows[0]["Amount"].ToString();

                    NumberToEnglish obj = new NumberToEnglish();
                    string MomeyAmount = double.Parse(txtAmount.Text).ToString();
                    amountWords = obj.changeCurrencyToWords(MomeyAmount);
                    lblwordsMoney.Text = amountWords;
                    brokerName = dtCheckInfo.Rows[0]["Broker_Name"].ToString();
                    author = dtCheckInfo.Rows[0]["Author"].ToString();
                    branchName = dtCheckInfo.Rows[0]["Branch_ID"].ToString();
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error Occured." + exp.Message);
                }
                float x = 776;
                float y = 70;
                float space = 25;
                if (chkACPayee.Checked)
                {
                    Image myImage = Resources.APO;
                    graphics.DrawImage(myImage, 250, 10);
                }

                //Image img = Image.FromFile("c:\\chk.jpg");
                //graphics.DrawImage(img,0,0);

                string LCustName = "";
                int LengthOfCustName_FirstPart = 25;
                List<string> LamountWord = new List<string>();
                int LengthOfAmountWord_FirstPart = 35;
                int LengthOfAmountWord_SecondPart = 35;

                if (custName.Length > LengthOfCustName_FirstPart)
                {
                    LCustName = GetActualName(custName, LengthOfCustName_FirstPart);
                }

                else
                {
                    LCustName = custName;
                }
                if (amountWords.Length > LengthOfAmountWord_FirstPart)
                {
                    LamountWord = GetActualAmoundWord(amountWords, LengthOfAmountWord_FirstPart, LengthOfAmountWord_SecondPart);
                }
                else
                {
                    LamountWord.Add(amountWords);
                }

                //left side
                graphics.DrawString(companyACNo, font, solidBrush, 112, 112);
                graphics.DrawString(downdateString, fontBold, solidBrush, 90, 145);
                graphics.DrawString(custID, fontBold, solidBrush, 100, 180);

                graphics.DrawString(LCustName, LCfont, solidBrush, 55, 214);
                graphics.DrawString(amount, fontBold, solidBrush, 110, 250);
                graphics.DrawString(branchName, font, solidBrush, 60, 310);



                //Middle side
                graphics.DrawString(custName, fontBold_Arial_11, solidBrush, 330, 128);
                //graphics.DrawString(amountWords, fontBold, solidBrush,370,160);
                if (LamountWord.Count >= 1)
                    graphics.DrawString(LamountWord[0], fontBold_Arial_11, solidBrush, 370, 163);
                if (LamountWord.Count >= 2)
                    graphics.DrawString(LamountWord[1], fontBold_Arial_11, solidBrush, 370, 179);
                if (LamountWord.Count >= 3)
                    graphics.DrawString(LamountWord[2], fontBold_Arial_11, solidBrush, 370, 195);
                //Right Side
                CheckDateFormat(upwDate, x, y, space, graphics);
                graphics.DrawString(amount, fontBold, solidBrush, 780, 175);
                if (_Author != string.Empty)
                {
                    graphics.DrawString(brokerName, fontItalic, solidBrush, 745, 220);
                    graphics.DrawString(author, fontItalic, solidBrush, 785, 260);
                }


            }
        }

        private string GetActualName(string CustName, int LengthOfFirstPart)
        {
            string actualName = "";
            string lName = "";
            string fName = "";

            try
            {
                string fname;
                string[] wordlist = CustName.Split(' ');
                int estimatedLength = 0;
                for (int i = 0; i < wordlist.Length; i++)
                {
                    estimatedLength = estimatedLength + wordlist[i].Length;
                    if (estimatedLength <= LengthOfFirstPart)
                        fName = fName + wordlist[i] + " ";
                    else
                        lName = lName + wordlist[i] + " ";
                }

                actualName = fName.Trim() + "\n" + lName.Trim();
            }
            catch (Exception)
            {

                throw;
            }

            return actualName;
        }
        private List<string> GetActualAmoundWord(string AmountWord, int FirstPartLength, int SecondPartLength)
        {
            //string actualAmountWord = "";
            List<string> result = new List<string>();
            try
            {

                string[] allwords = AmountWord.Split(' ');
                string First_Part = string.Empty;
                string Second_Part = string.Empty;
                string Third_Part = string.Empty;
                int estimatedNextLength = 0;
                for (int i = 0; i < allwords.Count(); i++)
                {
                    estimatedNextLength = estimatedNextLength + allwords[i].Length;
                    if (estimatedNextLength <= FirstPartLength)
                        First_Part = First_Part + allwords[i] + " ";
                    else if (estimatedNextLength <= SecondPartLength + FirstPartLength)
                        Second_Part = Second_Part + allwords[i] + " ";
                    else
                        Third_Part = Third_Part + allwords[i] + " ";
                }
                //string First_Part = AmountWord.Substring(0, firstPartLength);
                //string Second_Part = AmountWord.Substring(35);
                if (First_Part != string.Empty)
                    result.Add(First_Part);
                if (Second_Part != string.Empty)
                    result.Add(Second_Part);
                if (Third_Part != string.Empty)
                    result.Add(Third_Part);
                //actualAmountWord = First_Part.Trim() + "\n" + Second_Part.Trim();

            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        private void CheckDateFormat(string upwDate, float x, float y, float space, Graphics graphics)
        {
            System.Drawing.Font fontBold = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            upwDate = upwDate.Replace("-", "");
            char[] values = upwDate.ToCharArray();
            for (int i = 0; i < upwDate.Length; i++)
            {
                graphics.DrawString(values[i].ToString(), fontBold, solidBrush, x, y);
                x = x + space;
            }
        }

        private bool IsLockedVoucherNo()
        {
            PaymentInfoBAL paymentBal = new PaymentInfoBAL();
            bool result = false;
            if (paymentBal.IsLockedVoucherLockState())
            {
                result = true;
            }
            return result;
        }
        private void SetVoucherNo()
        {
            PaymentInfoBAL obj = new PaymentInfoBAL();
            string serial = obj.GenerateSerial();
            txtVoucherNo.Text = serial;
        }
        private void btnAutoSerial_Click(object sender, EventArgs e)
        {
            //PaymentInfoBAL paymentBal = new PaymentInfoBAL();
            // txtVoucherNo.Text = paymentBal.GenerateSerial();
            txtVoucherNo.Text = EFT_Voucher_Autogen;

        }

        private void btnPrint_Leave(object sender, EventArgs e)
        {
            ddlBankName.Focus();
        }

        private void ChequePrintSetup(PrintPageEventArgs g)
        {
            g.PageSettings.PaperSize = new PaperSize("Cheque", 350, 1000);
            g.PageSettings.Margins = new Margins(0, 0, 0, 0);
            g.PageSettings.Landscape = true;
            g.PageSettings.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            g.PageSettings.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("Cheque", 350, 1000);

            printCheck.DefaultPageSettings = g.PageSettings;

            PrinterSettings printerSettings = new PrinterSettings();
        }
        string GetDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                    return printer;
            }
            return string.Empty;
        }

        private void btnprintSetup_Click(object sender, EventArgs e)
        {

            pdCheque.AllowSomePages = true;
            pdCheque.ShowHelp = true;
            pdCheque.Document = printCheck;
            DialogResult result = pdCheque.ShowDialog();
            if (result == DialogResult.OK)
            {
                printCheck.Print();
            }
        }

        private void printCheck_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            PaperSize custom;

            custom = new PaperSize("Cheque", 350, 1000);

            e.PageSettings.PaperSize = custom;
        }

        private void lblwordsMoney_Click(object sender, EventArgs e)
        {

        }
    }
}
