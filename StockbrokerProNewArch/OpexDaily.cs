using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class OpexDaily : Form
    {
        private Image _image;
        public OpexDaily()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetTxtfield();
        }

        private void ResetTxtfield()
        {
            txtAmount.Text = "";
            txtLogoPath.Text = "";
            txtRemarks.Text = "";
            txtVoucherNo.Text = "";
            _image = null;
            picVouchar.Image = null;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("Expense Amount Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
                return;
            }

            if (ddlPurpose.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Purpose Name Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                opexDailyBo.VoucherNo = txtVoucherNo.Text;
                opexDailyBo.Remarks = txtRemarks.Text;
                opexDailyBo.PurposeId = Convert.ToInt32(ddlPurpose.SelectedValue);
                opexDailyBo.Purpose = ddExpur.Text;
                opexDailyBo.ExpenseDate = dtExpenseDate.Value;
                opexDailyBo.BranchId = GlobalVariableBO._branchId;
                opexDailyBo.Amount = float.Parse(txtAmount.Text);
                opexDailyBo.ExpenseType = "Daily";

                if (txtLogoPath.Text.Trim() != "")
                    opexDailyBo.VoucherImage = GetImageBytes(txtLogoPath.Text);

                OpexBAL opexBal = new OpexBAL();
                opexBal.SaveDailyOpexInfo(opexDailyBo);
                MessageBox.Show("  Expense Info successfully saved. ","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                LoadDataIntoGrid();
                LoadPurposes();
                ResetTxtfield();
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

        private void OpexDaily_Load(object sender, EventArgs e)
        {
            lblBranch.Text = GlobalVariableBO._branchName.ToUpper();
            btnAddPurpose.Enabled = GlobalVariableBO._addCategoryPriv;
            LoadDDL();
            LoadDataIntoGrid();
        }

        private void CreateDeleteButtonOndatagridView()
        {
            try
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dgvInfo.Columns.Add(btn);
                btn.HeaderText = "";
                btn.Text = "Cancel";
                btn.Name = "btn";
                btn.Width = 70;
                btn.DefaultCellStyle.BackColor = SystemColors.ButtonFace;
                btn.DefaultCellStyle.ForeColor = Color.DarkRed;
                btn.UseColumnTextForButtonValue = true;
                

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void GetOpexHighlightDailyRecord()
        {
            try
            {
                OpexBAL objOpexBal=new OpexBAL();
                DataTable dtOPexRecord=new DataTable();
               
                    dtOPexRecord = objOpexBal.GetOpexDailyInfo();
                    dgvInfo.DataSource = dtOPexRecord;
                    dgvInfo.Columns[0].Visible = false;

                    if (dgvInfo.Rows.Count> 0)
                    {
                        btnDelete.Enabled = true;
                    }

                    else
                    {
                        btnDelete.Enabled = false;
                    }

                

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void LoadDDL()
        {
            LoadPurpose();
            ddlPurpose.SelectedIndex = 0;
        }

        private void LoadPurpose()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            string excluse = "WHERE Purpose_Type='Daily' ORDER BY Purpose_Id DESC";
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Expense_Purpose",excluse);
            if (dtData.Rows.Count > 0)
            {
                ddlPurpose.DisplayMember = "Purpose_Name";
                ddlPurpose.ValueMember = "Purpose_Id";
                ddlPurpose.DataSource = dtData;
            }
        }

        private void LoadBranch()
        {
            
        }

        private void dgvInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void DeleteRecordInfo(int expenseId)
        {
            try
            {
                OpexBAL objOPex=new OpexBAL();

                if(MessageBox.Show("Do you want to delete this Record","Delete Message",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
                {
                    objOPex.DeleteExpenseData(expenseId);
                    MessageBox.Show("Data has been deleted successfully", "Delete Message", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    GetOpexHighlightDailyRecord();
                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void dgvInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dgvInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInfo.SelectedRows.Count > 0)
                {
                    int expenseId = Int32.Parse(dgvInfo.SelectedRows[0].Cells[0].Value.ToString());
                    DeleteRecordInfo(expenseId);
                    LoadDataIntoGrid();
                    ResetTxtfield();
                }

                else
                {
                    MessageBox.Show("No Daily Expenditure Information is Selected.","Daily Expenditure",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddPurpose_Click(object sender, EventArgs e)
        {
            frmAddopexPurpose objaddpurpose = new frmAddopexPurpose();
            objaddpurpose.ExpenseType = "Daily";
            objaddpurpose.ShowDialog();
            LoadDDL();

        }

        private void dtSearchDate_ValueChanged(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void LoadDataIntoGrid()
        {
            OpexBAL opexBal = new OpexBAL();
            DataTable datatable = opexBal.GetDailyGridInfo(dtSearchDate.Value);
            dgvInfo.DataSource = datatable;
            dgvInfo.Columns[0].Visible = false;
            dgvInfo.Columns[3].DefaultCellStyle.Format = "N";
            dgvInfo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvInfo.Columns[1].Width = 120;
            dgvInfo.Columns[2].Width = 200;
            dgvInfo.Columns[3].Width = 100;
            dgvInfo.Columns[4].Width = 120;
            lblTotalRecord.Text = "Total Record : " + datatable.Rows.Count.ToString();

            if (dgvInfo.Rows.Count > 0)
            {
                if (dgvInfo.SelectedRows[0].Cells["Status"].Value.Equals("Approved"))
                    btnDelete.Enabled = false;
                else
                    btnDelete.Enabled = true;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInfo.Rows.Count > 0)
                {
                    int expwenseId = Int32.Parse(dgvInfo.SelectedRows[0].Cells[0].Value.ToString());
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
                    txtVoucherNo.Text = dtRecordInfo.Rows[0]["Voucher_No"].ToString();

                    byte[] ImageBytes = (byte[])((dtRecordInfo.Rows[0]["Voucher_Image"] == DBNull.Value) ? new byte[0]: dtRecordInfo.Rows[0]["Voucher_Image"]);

                    if(ImageBytes.Length!=0)
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
                data = opexBal.GetPuposes("Daily", Convert.ToInt32(ddlPurpose.SelectedValue));
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
            if(ddlPurpose.Items.Count > 0)
                LoadPurposes();
        }

        private void picVouchar_Click(object sender, EventArgs e)
        {
            if(_image == null)
                return;

            ImageViewer imageViewer = new ImageViewer(_image);
            imageViewer.ShowDialog();
        }

        private void dgvInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvInfo.Rows.Count > 0)
            {
                if (dgvInfo.SelectedRows[0].Cells["Status"].Value.Equals("Approved"))
                    btnDelete.Enabled = false;
                else
                    btnDelete.Enabled = true;
            }
        }

        private void btnPurpose_Click(object sender, EventArgs e)
        {
            frmOpexCategoryPurpose objPurpose=new frmOpexCategoryPurpose();
            objPurpose.CategoryName = ddlPurpose.Text;
            objPurpose.CategoryId = Int32.Parse(ddlPurpose.SelectedValue.ToString());
            objPurpose.ShowDialog();
            if(objPurpose.Result==DialogResult.Yes)
            GetPurposeList();

        }

        private void GetPurposeList()
        {
            try
            {
                OpexPurposeBAL objPurpose=new OpexPurposeBAL();
                DataTable data=new DataTable();
                data = objPurpose.GetPurposeList(Int32.Parse(ddlPurpose.SelectedValue.ToString()));
                ddExpur.DataSource = data;
                ddExpur.DisplayMember = "Purpose_Name";
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
