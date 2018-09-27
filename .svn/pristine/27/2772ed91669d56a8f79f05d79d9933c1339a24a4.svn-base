using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class frmConversionUpdateTest : Form
    {
        public frmConversionUpdateTest()
        {
            InitializeComponent();
        }
        string FPath = string.Empty;
        DataTable dtCompany = new DataTable();
        CommonBAL cmnBAL = new CommonBAL();

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FPath = openFileDialog1.FileName;
                    txtFilePath.Text = FPath;
                    TextFileProcess();
                }
                catch
                {  //          "Please, Rewrite..."+"\r\n"+"It Exceeds The Existing Balance..."
                    MessageBox.Show("File Processing Error..." + "\r\n" + "", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSelectFile.Focus();
                }
            }
        }

        private void TextFileProcess()
        {
            const char CHAR = '~';
            //DataTable dt = new DataTable();
            StreamReader SR = new StreamReader(FPath);

            if (FPath != string.Empty)
            {
                try
                {
                    if (dtCompany.Columns.Count == 0)
                    {
                        dtCompany.Columns.Add("Cust_Code");
                        dtCompany.Columns.Add("Deposit_Type");
                        dtCompany.Columns.Add("Quantity");
                        dtCompany.Columns.Add("Issue_Price");
                        dtCompany.Columns.Add("Issue_Amount");
                        dtCompany.Columns.Add("FractureValue");
                    }
                    dtCompany.Rows.Clear();
                    while (SR.Peek() >= 0)
                    {
                        string[] Row = SR.ReadLine().Split(CHAR);
                        dtCompany.Rows.Add(Row);
                    }
                    dgvFileInformation.DataSource = dtCompany;
                    lblCount.Text = Convert.ToString(dgvFileInformation.Rows.Count);
                }
                catch
                {
                    MessageBox.Show("File Processing Error....");
                }
            }
            else
            {
                MessageBox.Show("No File Found...", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Want to Run Deposit Data Update Process?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                ShareDWBO_Conversion_Collection collectionBO = new ShareDWBO_Conversion_Collection();
                ShareDWBAL BAL = new ShareDWBAL();
                ShareDWBO_Conversion BO = new ShareDWBO_Conversion();

                try
                {
                    collectionBO = ProcessDatatable(dtCompany);
                }
                catch
                {
                    MessageBox.Show("File Process Failed...", "Information!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (ShareDWBO_Conversion DW_BO in collectionBO)
                {
                    try
                    {
                        BAL.UpdateRecord_ForConversion(DW_BO);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                MessageBox.Show("Share Deposit Data Update Process Completed....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private ShareDWBO_Conversion_Collection ProcessDatatable(DataTable dtCompany)
        {
            ShareDWBO_Conversion_Collection CollectionBO = new ShareDWBO_Conversion_Collection();

            foreach (DataRow row in dtCompany.Rows)
            {
                DataTable dt = new DataTable();
                ShareDWBO_Conversion sBO = new ShareDWBO_Conversion();
                ShareDWBAL sBAL = new ShareDWBAL();
                LockInShareBAL lockbal = new LockInShareBAL();

                sBO.CustCode = row["Cust_Code"].ToString();
                sBO.DepositType = row["Deposit_Type"].ToString();
                sBO.Quantity = Convert.ToInt32(row["Quantity"].ToString());
                sBO.IssuePrice = float.Parse(row["Issue_Price"].ToString());
                sBO.IssueAmount = float.Parse(row["Issue_Amount"].ToString());
                sBO.DB_FractureValue = float.Parse(row["FractureValue"].ToString());

                CollectionBO.ADD(sBO);
            }
            return CollectionBO;
        }
    }
}
