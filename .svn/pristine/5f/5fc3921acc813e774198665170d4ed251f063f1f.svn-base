using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class frmAddPaymentOOCPurpose : Form
    {
        public frmAddPaymentOOCPurpose()
        {
            InitializeComponent();
        }

        private DialogResult _addOcc;

        public DialogResult AddOcc
        {
            get { return _addOcc; }
            set { _addOcc = value; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddToPaymentOCC();
        }

        private void AddToPaymentOCC()
        {
            try
            {
                if (txtPurpose.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Other Charges & Credits Purpose Required ?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPurpose.Focus();
                }

                else if (txtAmount.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Other Charges & Credits Amount Tk. Required?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAmount.Focus();
                }

                else
                {
                    float test;

                    if (float.TryParse(txtAmount.Text, out test) == false)
                    {
                        MessageBox.Show("Other Charges & Credits Purpose Amount must be Money.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtAmount.Focus();
                    }

                    else
                    {
                        paymentOCCPaurpose objPaymentOCCPurpose = new paymentOCCPaurpose();
                        objPaymentOCCPurpose.AddOccPaymentPurpose(txtPurpose.Text, float.Parse(txtAmount.Text));
                        MessageBox.Show("Sucessfully Saved Other Charges & Credits Purpose.", "Payment OOC Purpose",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDeletablePurpose();

                        _addOcc = DialogResult.Yes;
                        txtAmount.Text = "";
                        txtPurpose.Text = "";

                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmAddPaymentOOCPurpose_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDeletablePurpose();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDeletablePurpose()
        {
            try
            {
                paymentOCCPaurpose objOccPurpose=new paymentOCCPaurpose();
                DataTable data=new DataTable();
                data = objOccPurpose.GetDeletablePurpose();
                dgvPurposeInfo.DataSource = data;
                dgvPurposeInfo.Columns[0].Visible = false;
                dgvPurposeInfo.Columns["Amount"].DefaultCellStyle.Format = "N";
                dgvPurposeInfo.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                lblRecord.Text="Total Record : " + dgvPurposeInfo.Rows.Count;

                label4.Text = "Existing Other Charges & Credits Purpose : " + objOccPurpose.GetPaymentOccPurpose();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

      

        private  void  DeletePurpose(int PurposeId)
        {
            try
            {
                if (MessageBox.Show("Do you want to Delete this Other Charges & Credits Purpose.", "Purpose", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    paymentOCCPaurpose objPurpose=new paymentOCCPaurpose();
                    objPurpose.DeletePurpose(PurposeId);
                    MessageBox.Show("Sucessfully Delete this Other Charges & Credits Purpose Information.", "Purpose",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDeletablePurpose();
                    _addOcc = DialogResult.Yes;
                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvPurposeInfo.Rows.Count>0)
            {
                int PurposeID = Int32.Parse(dgvPurposeInfo.Rows[0].Cells[0].Value.ToString());
                DeletePurpose(PurposeID);
            }
            else
            {
                MessageBox.Show("No Other Charges & Credits Purpose Exists.", "Purpose", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

            }
        }
    }
}
