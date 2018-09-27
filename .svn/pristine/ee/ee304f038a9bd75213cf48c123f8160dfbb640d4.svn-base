using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using StockbrokerProNewArch.Properties;


namespace StockbrokerProNewArch
{
    public partial class CheckPrinting : Form
    {
        private DateTime searchDate;
        private int custCodeForView;
        private string _bankName;
        private string _Author;

        public CheckPrinting()
        {
            InitializeComponent();
        }

        private void dtSearchDate_ValueChanged(object sender, EventArgs e)
        {
            searchDate = dtSearchDate.Value;
            LoadFirstDataIntoForm();
            LoadGridData();
        }

        private void LoadFirstDataIntoForm()
        {
            CheckPrintBAL checkPrintBal = new CheckPrintBAL();
            DataTable dtCheckInfo = checkPrintBal.GetAllCheckReceiver(searchDate);
            if (dtCheckInfo.Rows.Count > 0)
            {
                txtClientCode.Text = dtCheckInfo.Rows[0]["Client Code"].ToString();
                txtName.Text = dtCheckInfo.Rows[0]["Name"].ToString();
                txtAmount.Text = dtCheckInfo.Rows[0]["Amount"].ToString();
                txtCheckNo.Text = dtCheckInfo.Rows[0]["Check No"].ToString();
                txtVoucherNo.Text = dtCheckInfo.Rows[0]["Voucher No"].ToString();
                if (dtCheckInfo.Rows[0]["Check Date"] != DBNull.Value)
                    dtReceivedDate.Value = Convert.ToDateTime(dtCheckInfo.Rows[0]["Check Date"]);
            }

        }

        private void LoadGridData()
        {
            CheckPrintBAL checkPrintBal = new CheckPrintBAL();
            DataTable dtCheckInfo = checkPrintBal.GetAllCheckReceiver(searchDate);
            dtgCheckReceiver.DataSource = dtCheckInfo;
            dtgCheckReceiver.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void dtgCheckReceiver_SelectionChanged(object sender, EventArgs e)
        {
            LoadDataFromGrid();
            ClearView();
        }

        private void ClearView()
        {
            lblAmount.Text = "";
            lblNameOnCheck.Text = "";
            lblTakainWords.Text = "";
            dtCheckDate.Value = DateTime.Today;
        }

        private void LoadDataFromGrid()
        {
            foreach (DataGridViewRow row in this.dtgCheckReceiver.SelectedRows)
            {
                txtClientCode.Text = dtgCheckReceiver[0, row.Index].Value.ToString();
                txtName.Text = dtgCheckReceiver[1, row.Index].Value.ToString();
                txtAmount.Text = dtgCheckReceiver[2, row.Index].Value.ToString();
                txtCheckNo.Text = dtgCheckReceiver[3, row.Index].Value.ToString();
                txtVoucherNo.Text = dtgCheckReceiver[4, row.Index].Value.ToString();
                if (dtgCheckReceiver[5, row.Index].Value != DBNull.Value)
                    dtReceivedDate.Value = Convert.ToDateTime(dtgCheckReceiver[5, row.Index].Value);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if(txtClientCode.Text.Trim()=="")
            {
                MessageBox.Show("No Customer has selected for view.Please select a customer first.","Customer Code Invalid.");
                return;
            } 
            if (txtClientCode.Text.Trim() != "")
                custCodeForView = Convert.ToInt32(txtClientCode.Text);
            CheckPrintBAL checkPrintBal = new CheckPrintBAL();
            DataTable dtCheckInfo = checkPrintBal.GetCheckInfoForView(custCodeForView,searchDate);
            if(dtCheckInfo.Rows.Count>0)
            {
                lblNameOnCheck.Text = dtCheckInfo.Rows[0]["Cust_Name"].ToString();
                lblAmount.Text = dtCheckInfo.Rows[0]["Amount"].ToString()+"/-";
                lblTakainWords.Text = dtCheckInfo.Rows[0]["Amount_Words"].ToString();
                if (dtCheckInfo.Rows[0]["Received_Date"] != DBNull.Value)
                    dtCheckDate.Value = Convert.ToDateTime(dtCheckInfo.Rows[0]["Received_Date"]);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ChangeButtonState();
            if (!btnNext.Enabled)
                return;
            dtgCheckReceiver.Rows[dtgCheckReceiver.SelectedRows[0].Index + 1].Selected = true;
        }

        private void ChangeButtonState()
        {
            int nRowIndex = dtgCheckReceiver.Rows.Count - 1;
            btnNext.Enabled = !dtgCheckReceiver.Rows[nRowIndex].Selected;
            btnPrevious.Enabled = !dtgCheckReceiver.Rows[0].Selected;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            ChangeButtonState();
            if(!btnPrevious.Enabled)
                return;
            dtgCheckReceiver.Rows[dtgCheckReceiver.SelectedRows[0].Index - 1].Selected = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(txtClientCode.Text.Trim()=="")
            {
                MessageBox.Show("No customer has been select for printing", "Invalid Selection.");
                return;
            }
            else
            {
                GetCheckedData();
                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                previewDialog.Document = this.printCheck;
                previewDialog.Show();
                ////Insert Into History
                InsertIntoPrintHistory();
                LoadGridData();
            }
        }

        private void InsertIntoPrintHistory()
        {
            CheckPrintLogBO checkPrintLogBo = new CheckPrintLogBO();
            CommonBAL commonBal=new CommonBAL();
            checkPrintLogBo.SlNo = commonBal.GenerateID("SBP_Check_Print_History", "Sl_No");
            checkPrintLogBo.CustCode = txtClientCode.Text;
            if (rdoRupaliBank.Checked)
            {
                checkPrintLogBo.Bankname = "Rupali Bank Ltd";
            }
            else
            {
                checkPrintLogBo.Bankname = "The City Bank Ltd";
            }
            checkPrintLogBo.PaymentMediaNo = txtCheckNo.Text;
            checkPrintLogBo.VoucherSlNo = txtVoucherNo.Text;
            checkPrintLogBo.RecievedDate = dtReceivedDate.Value;
            CheckPrintBAL checkPrintBal = new CheckPrintBAL();
            checkPrintBal.InsertPrintLog(checkPrintLogBo);

            
        }

        private void GetCheckedData()
        {
            if (rdoRupaliBank.Checked)
            {
                _bankName = "RUPALI";
            }
            else
            {
                _bankName = "CITY";
            }
            if (rdoDirector.Checked)
            {
                _Author = "Director";
            }
            else
            {
                _Author = "Managing Director";
            }
        }

        private void printCheck_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            switch (_bankName)
            {
                case "CITY":
                    LoadCityBankData(graphics);
                    break;
                case "RUPALI":
                    LoadRupaliBankData(graphics);
                    break;
            }
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

            CheckPrintBAL checkPrintBal = new CheckPrintBAL();
            DataTable dtCheckInfo = new DataTable();
            dtCheckInfo = checkPrintBal.GetDataForPrinting(txtClientCode.Text, dtReceivedDate.Value,_Author);
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
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error Occured." + exp.Message);
                }
                float x = 600;
                float y = 150;
                float space = 25;
                if (chkACPayee.Checked)
                {
                    Image myImage = Resources.APO;
                    graphics.DrawImage(myImage, 250, 100);
                }
                //left side
                //StringFormat sf = new StringFormat(StringFormatFlags.DirectionVertical);
                //graphics.DrawString(companyACNo, font, solidBrush, 70, 200);
                //graphics.RotateTransform(180);
                //graphics.DrawString(downdateString, fontBold, solidBrush, 50, 250,sf);
                //graphics.DrawString(custID, fontBold, solidBrush, 90, 250,sf);
                //graphics.DrawString(custName, font, solidBrush, 120, 250,sf);
                //graphics.DrawString(amount, fontBold, solidBrush, 150, 250,sf);
                //graphics.ResetTransform();


                //Middle side
                graphics.DrawString(custName, fontBold, solidBrush, 200, 250);
                graphics.DrawString(amountWords, fontBold, solidBrush, 250, 300);
                //Right Side
                CheckDateFormat(upwDate, x, y, space, graphics);
                graphics.DrawString(amount, fontBold, solidBrush, 700, 300);
                graphics.DrawString(brokerName, fontItalic, solidBrush, 600, 350);
                graphics.DrawString(author, fontItalic, solidBrush, 650, 400);
            }

        }

        private void LoadCityBankData(Graphics graphics)
        {
            string downdateString = "";
            string upwDate = "";
            string custID = "";
            string custName = "";
            string amount = "";
            string amountWords = "";
            string brokerName = "";
            string author = "";
            string companyACNo = "3101085921001";
            CheckPrintBAL checkPrintBal = new CheckPrintBAL();
            DataTable dtCheckInfo = new DataTable();
            dtCheckInfo = checkPrintBal.GetDataForPrinting(txtClientCode.Text, dtReceivedDate.Value,_Author);
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
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error Occured." + exp.Message);
                }
                float x = 600;
                float y = 150;
                float space = 25;
                if (chkACPayee.Checked)
                {
                    Image myImage = Resources.APO;
                    graphics.DrawImage(myImage, 250, 100);
                }
                //left side
                graphics.DrawString(companyACNo, font, solidBrush, 70, 200);
                graphics.DrawString(downdateString, fontBold, solidBrush, 50, 250);
                graphics.DrawString(custID, fontBold, solidBrush, 50, 300);
                graphics.DrawString(custName, font, solidBrush, 35, 350);
                graphics.DrawString(amount, fontBold, solidBrush, 75, 400);


                //Middle side
                graphics.DrawString(custName, fontBold, solidBrush, 200, 250);
                graphics.DrawString(amountWords, fontBold, solidBrush, 250, 300);
                //Right Side
                CheckDateFormat(upwDate, x, y, space, graphics);
                graphics.DrawString(amount, fontBold, solidBrush, 700, 300);
                graphics.DrawString(brokerName, fontItalic, solidBrush, 600, 350);
                graphics.DrawString(author, fontItalic, solidBrush, 650, 400);
        }
    }

        private void CheckDateFormat(string upwDate, float x, float y, float space, Graphics graphics)
        {
            System.Drawing.Font fontBold = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            char[] values = upwDate.ToCharArray(); 
            for (int i = 0; i <upwDate.Length; i++)
            {
                graphics.DrawString(values[i].ToString(), fontBold,solidBrush, x,y);
                x = x + space;
            }
        }

        //public static extern int SetTextCharacterExtra(
        //    IntPtr hdc,    // DC handle
        //    int nCharExtra // extra-space value 
        //);
        //[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        //public void Draw(Graphics g)
        //{
        //    IntPtr hdc = g.GetHdc();
        //    SetTextCharacterExtra(hdc, 24); //set spacing between characters 
        //    g.ReleaseHdc(hdc);

        //    e.Graphics.DrawString("str", this.Font, Brushes.Black, 0, 0);
        //}  

        private void CheckPrinting_Load(object sender, EventArgs e)
        {
            dtSearchDate.Value = DateTime.Today;
            rdoCityBank.Checked = true;
            rdoMD.Checked = true;
        }
    }
}
