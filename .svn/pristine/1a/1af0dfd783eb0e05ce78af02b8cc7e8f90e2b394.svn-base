using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using System.IO;
using System.Drawing;

namespace StockbrokerProNewArch
{
    public partial class CommonOPEX : Form
    {
        private int _expenseIDforUpdate;
        private Image _image;

        public CommonOPEX()
        {
            InitializeComponent();
        }

        private void CommonOPEX_Load(object sender, EventArgs e)
        {
            lblBranch.Text = GlobalVariableBO._branchName.ToUpper();
            btnAddPurpose.Enabled = GlobalVariableBO._addCategoryPriv;
            LoadDDL();
            LoadDataIntoGrid();

        }

        private void GetHighlightCommonOpexInfo()
        {
            try
            {
                DataTable dtCommonRecord = new DataTable();
                OpexBAL objOPex = new OpexBAL();

                dtCommonRecord = objOPex.GetOpexCommonInfo();
                dtgOPEXInfo.DataSource = dtCommonRecord;
                dtgOPEXInfo.Columns[0].Visible = false;

            }

            catch (Exception)
            {
                throw;
            }
        }
        private void LoadDDL()
        {
            LoadPurpose();
        }
        private void LoadPurpose()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();

            string exCluse = "WHERE Purpose_Type='Common' ORDER BY Purpose_Id DESC";
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Expense_Purpose", exCluse);
            ddlPurpose.DisplayMember = "Purpose_Name";
            ddlPurpose.ValueMember = "Purpose_Id";
            ddlPurpose.DataSource = dtData;
            if (ddlPurpose.HasChildren)
                ddlPurpose.SelectedIndex = 0;
        }
        private void LoadDataIntoGrid()
        {
            OpexBAL opexBal = new OpexBAL();
            DataTable datatable = opexBal.GetCommonGridInfo(dtSearchDate.Value);
            dtgOPEXInfo.DataSource = datatable;
            this.dtgOPEXInfo.Columns[0].Visible = false;
            dtgOPEXInfo.Columns["Expense Amount"].DefaultCellStyle.Format = "N";
            dtgOPEXInfo.Columns["Expense Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            lblTotalRecord.Text = "Total Record : " + datatable.Rows.Count.ToString();

            if (dtgOPEXInfo.Rows.Count > 0)
            {
                if (dtgOPEXInfo.SelectedRows[0].Cells["Status"].Value.Equals("Approved"))
                    btnDelete.Enabled = false;
                else
                    btnDelete.Enabled = true;
            }

        }

        private void dtSearchDate_ValueChanged(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("Expense Amount Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
                return;
            }

            if (ddlPurpose.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Expense Purpose Name Required..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ddlPurpose.Focus();
                return;
            }
            SaveExpenseInfo();
        }
        private void SaveExpenseInfo()
        {
            try
            {
                OpexDailyBO opexDailyBo = new OpexDailyBO();
                OpexBAL opexBal = new OpexBAL();

                opexDailyBo.Remarks = txtRemarks.Text;
                opexDailyBo.MonthOfExpense = dtExpenseMonth.Value;
                opexDailyBo.PurposeId = Convert.ToInt32(ddlPurpose.SelectedValue);
                opexDailyBo.Purpose = ddExpur.Text;
                opexDailyBo.ExpenseDate = dtExpenseDate.Value;
                opexDailyBo.Amount = float.Parse(txtAmount.Text);
                opexDailyBo.VoucherNo = txtVoucherNo.Text;
                opexDailyBo.ExpenseType = "Common";
                if (txtLogoPath.Text.Trim() != String.Empty)
                {
                    opexDailyBo.VoucherImage = GetImageBytes(txtLogoPath.Text);
                }



                //opexBal.SaveCommonOpexInfo(opexDailyBo);
                opexBal.SaveDailyOpexInfo(opexDailyBo);

                MessageBox.Show("Expense Info successfully saved.");
                LoadDataIntoGrid();
                LoadPurposes();
                ClearAll();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Expense Info saved unsuccessful.Because of the error:" + exc.Message);
            }
        }

        private byte[] GetImageBytes(string fileName)
        {
            MemoryStream stream = new MemoryStream();
            try
            {
                Bitmap image = new Bitmap(fileName);
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                image.Dispose();
                return stream.ToArray();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong Image File." + ex.Message);
            }
            return null;
        }

        private void ClearAll()
        {
            txtRemarks.Text = "";
            txtAmount.Text = "";
            dtExpenseMonth.Value = DateTime.Today;
            dtExpenseDate.Value = DateTime.Today;
            txtLogoPath.Text = "";
            picVouchar.Image = null;
        }
        private void LoadDataFromGrid()
        {
            foreach (DataGridViewRow row in this.dtgOPEXInfo.SelectedRows)
            {
                _expenseIDforUpdate = Convert.ToInt32(dtgOPEXInfo[0, row.Index].Value);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtgOPEXInfo.Rows.Count <= 0)
            {
                MessageBox.Show("No Common Expenditure Information is Selected.", "Common Expenditure.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Do you want to continue to delete the Data?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    //LoadDataFromGrid();

                    if (dtgOPEXInfo.Rows.Count > 0)
                    {
                        OpexBAL opexBal = new OpexBAL();
                        opexBal.DeleteExpenseData(Int32.Parse(dtgOPEXInfo.Rows[0].Cells[0].Value.ToString()));
                        MessageBox.Show("Expense Data successfully Deleted.");
                        LoadDataIntoGrid();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete unsuccessfull. Error Occured: " + ex.Message);
                }
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtAmount.Text, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTxtfield();
        }
        private void ResetTxtfield()
        {
            txtAmount.Text = "";
            txtLogoPath.Text = "";
            txtRemarks.Text = "";
            _image = null;
            picVouchar.Image = null;
        }

        private void btnAddPurpose_Click(object sender, EventArgs e)
        {
            frmAddopexPurpose objaddpurpose = new frmAddopexPurpose();
            objaddpurpose.ExpenseType = "Common";
            objaddpurpose.ShowDialog();
            LoadDDL();
        }

        private void btnBrowseLogo_Click(object sender, EventArgs e)
        {
            if (ofdVoucher.ShowDialog() != DialogResult.Cancel)
            {
                txtLogoPath.Text = ofdVoucher.FileName;
                _image = Image.FromFile(txtLogoPath.Text);
                picVouchar.Image = _image;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgOPEXInfo.Rows.Count > 0)
                {
                    int expwenseId = Int32.Parse(dtgOPEXInfo.SelectedRows[0].Cells[0].Value.ToString());
                    ViewDailyInfo(expwenseId);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ViewDailyInfo(int expenseId)
        {
            try
            {
                OpexBAL objOPex = new OpexBAL();
                DataTable dtRecordInfo = new DataTable();

                dtRecordInfo = objOPex.GetDailyVoucherInfo(expenseId);

                if (dtRecordInfo.Rows.Count > 0)
                {
                    ddlPurpose.Text = dtRecordInfo.Rows[0]["Purpose_Name"].ToString();
                    ddExpur.Text = dtRecordInfo.Rows[0]["Purpose"].ToString();
                    txtAmount.Text = dtRecordInfo.Rows[0]["Amount"].ToString();
                    txtLogoPath.Text = dtRecordInfo.Rows[0]["Voucher_No"].ToString();

                    byte[] ImageBytes = (byte[])((dtRecordInfo.Rows[0]["Voucher_Image"] == DBNull.Value) ? new byte[0] : dtRecordInfo.Rows[0]["Voucher_Image"]);

                    if (ImageBytes.Length != 0)
                    {
                        MemoryStream ms = new MemoryStream(ImageBytes);
                        _image = Image.FromStream(ms);
                        picVouchar.Image = _image;
                    }

                    else
                    {
                        _image = null;
                        picVouchar.Image = _image;
                    }


                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*********************************************************************************/
        private void LoadPurposes()
        {
            DataTable data;
            try
            {
                OpexBAL opexBal = new OpexBAL();
                data = opexBal.GetPuposes("Common", Convert.ToInt32(ddlPurpose.SelectedValue));
                ddExpur.DataSource = data;
                ddExpur.DisplayMember = "Purpose";

                if (data.Rows.Count == 0)
                    ddExpur.Text = "";
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fail to load pupose dropdown. Because: " + exc.Message);
            }
        }

        private void ddlPurpose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPurpose.Items.Count > 0)
                LoadPurposes();
        }

        private void picVouchar_Click(object sender, EventArgs e)
        {
            if (_image == null)
                return;

            ImageViewer imageViewer = new ImageViewer(_image);
            imageViewer.ShowDialog();
        }

        private void dtgOPEXInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgOPEXInfo.Rows.Count > 0)
            {
                if (dtgOPEXInfo.SelectedRows[0].Cells["Status"].Value.Equals("Approved"))
                    btnDelete.Enabled = false;
                else
                    btnDelete.Enabled = true;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmOpexCategoryPurpose objPurpose = new frmOpexCategoryPurpose();
            objPurpose.CategoryName = ddlPurpose.Text;
            objPurpose.CategoryId = Int32.Parse(ddlPurpose.SelectedValue.ToString());
            objPurpose.ShowDialog();
            if (objPurpose.Result == DialogResult.Yes)
                GetPurposeList();
        }


        private void GetPurposeList()
        {
            try
            {
                OpexPurposeBAL objPurpose = new OpexPurposeBAL();
                DataTable data = new DataTable();
                data = objPurpose.GetPurposeList(Int32.Parse(ddlPurpose.SelectedValue.ToString()));
                ddExpur.DataSource = data;
                ddExpur.DisplayMember = "Purpose_Name";
                ddExpur.ValueMember = "Purpose_ID";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

    }
}
