using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class frmExpenseVoucherImage : Form
    {
        private Image _image;
        public frmExpenseVoucherImage()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetTxtfield();
        }

        private void ResetTxtfield()
        {
            txtLogoPath.Text = "";
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
           SaveExpenseInfo();
        }

        private void SaveExpenseInfo()
        {
            try
            {
                ExpenseVoucherImageBO expenseVoucherImageBO = new ExpenseVoucherImageBO();
                expenseVoucherImageBO.VoucherNo = txtVoucherNo.Text;
                expenseVoucherImageBO.ExpenseDate = dtExpenseDate.Value;

                if (txtLogoPath.Text.Trim() != "")
                    expenseVoucherImageBO.VoucherImage = GetImageBytes(txtLogoPath.Text);


                ExpenseVoucherImageBAL expenseVoucherImageBAL = new ExpenseVoucherImageBAL();
                expenseVoucherImageBAL.SaveExpenseVoucherImage(expenseVoucherImageBO);
                MessageBox.Show("  Expense Info successfully saved. ","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                LoadDataIntoGrid();
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

        private void ExpenseVoucherImage_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        //private void CreateDeleteButtonOndatagridView()
        //{
        //    try
        //    {
        //        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
        //        dgvInfo.Columns.Add(btn);
        //        btn.HeaderText = "";
        //        btn.Text = "Cancel";
        //        btn.Name = "btn";
        //        btn.Width = 70;
        //        btn.DefaultCellStyle.BackColor = SystemColors.ButtonFace;
        //        btn.DefaultCellStyle.ForeColor = Color.DarkRed;
        //        btn.UseColumnTextForButtonValue = true;
                

        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //}

        private void GetExpenseVoucherImageHighlightDailyRecord()
        {
            try
            {
                ExpenseVoucherImageBAL expenseVoucherImageBAL = new ExpenseVoucherImageBAL();
                DataTable dtExpenseVoucherImage = new DataTable();

                dtExpenseVoucherImage = expenseVoucherImageBAL.GetExpenseVoucherImage();
                dgvInfo.DataSource = dtExpenseVoucherImage;
                dgvInfo.Columns[0].Visible = false;

                if (dgvInfo.Rows.Count > 0)
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


        private void DeleteRecordInfo(int expenseId)
        {
            try
            {
                ExpenseVoucherImageBAL expenseVoucherImageBAL = new ExpenseVoucherImageBAL();

                if(MessageBox.Show("Do you want to delete this Record","Delete Message",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
                {
                    expenseVoucherImageBAL.DeleteExpenseVoucherImage(expenseId);
                    MessageBox.Show("Data has been deleted successfully", "Delete Message", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    GetExpenseVoucherImageHighlightDailyRecord();
                }

            }
            catch (Exception)
            {
                
                throw;
            }
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


        private void LoadDataIntoGrid()
        {
            ExpenseVoucherImageBAL expenseVoucherImageBAL = new ExpenseVoucherImageBAL();
            DataTable datatable = expenseVoucherImageBAL.GetDailyGridInfo(dtSearchDate.Value);
            dgvInfo.DataSource = datatable;
            dgvInfo.Columns[0].Visible = false;
            dgvInfo.Columns[3].DefaultCellStyle.Format = "N";
            dgvInfo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvInfo.Columns[1].Width = 120;
            dgvInfo.Columns[2].Width = 200;
            dgvInfo.Columns[3].Width = 100;
            lblTotalRecord.Text = "Total Record : " + datatable.Rows.Count.ToString();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInfo.Rows.Count > 0)
                {
                    int voucherImageId = Int32.Parse(dgvInfo.SelectedRows[0].Cells[0].Value.ToString());
                    ViewVoucherImage(voucherImageId);
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ViewVoucherImage(int voucherImageId)
        {
            try
            {
                ExpenseVoucherImageBAL expenseVoucherImageBAL = new ExpenseVoucherImageBAL();
                DataTable dtRecordInfo = new DataTable();

                dtRecordInfo = expenseVoucherImageBAL.GetVoucherImageInfo(voucherImageId);

                if (dtRecordInfo.Rows.Count > 0)
                {
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

        private void picVouchar_Click(object sender, EventArgs e)
        {
            if(_image == null)
                return;

            ImageViewer imageViewer = new ImageViewer(_image);
            imageViewer.ShowDialog();
        }

        
    }
}
