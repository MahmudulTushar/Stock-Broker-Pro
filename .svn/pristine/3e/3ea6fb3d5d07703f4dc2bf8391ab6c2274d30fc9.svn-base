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
    public partial class frmOpexCategoryPurpose : Form
    {
        public frmOpexCategoryPurpose()
        {
            InitializeComponent();
        }

        private int _categoryId=0;
        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        private string _categoryName;
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }

        public DialogResult Result
        {
            get { return _result; }
            set { _result = value; }
        }

        private DialogResult _result = DialogResult.None;



        private void frmOpexCategory_Load(object sender, EventArgs e)
        {
            if(_categoryId!=null)
            {
                txtCategory.Text = _categoryName;
            }

            ShowDeleatablepurpose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SavePurpose();
        }

        private void SavePurpose()
        {
            try
            {
                if(txtPurpose.Text.Trim()==string.Empty)
                {
                    MessageBox.Show("Opex Purpose Name Required.", "Opex Purpose", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    txtPurpose.Focus();
                    return;
                }

                else
                {
                    if(_categoryId!=0)
                    {
                        OpexPurposeBAL objPurpose = new OpexPurposeBAL();
                        objPurpose.InsertOpexPurpose(_categoryId, txtPurpose.Text);
                        MessageBox.Show("Purpose Information Sucessfully Saved.", "Purpose Information",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _result = DialogResult.Yes;
                        txtPurpose.Text = "";
                        txtPurpose.Focus();
                        ShowDeleatablepurpose();
                    }

                    else
                    {
                        MessageBox.Show("No Category Exists to Save under Purpose Information.", "Purpose Information",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowDeleatablepurpose()
        {
            try
            {
                OpexPurposeBAL objPurpose=new OpexPurposeBAL();
                DataTable data=new DataTable();
                data = objPurpose.GetDeletablePurposeList();
                dgvPurposeInfo.DataSource = data;
                dgvPurposeInfo.Columns[0].Visible = false;
                lblRecord.Text = "Total Record : " + dgvPurposeInfo.Rows.Count;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dgvPurposeInfo.Rows.Count>0)
            {
                DeleteOpexPurpose();
            }

            else
            {
                MessageBox.Show("No Purpose Information to Delete.", "Purpose Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void DeleteOpexPurpose()
        {
            try
            {
                if(MessageBox.Show("Do you want to Delete this Opex Purpose Information \n of " + txtCategory.Text + " Category.","Purpose Information",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    int purposeId = Int32.Parse(dgvPurposeInfo.SelectedRows[0].Cells[0].Value.ToString());
                    OpexPurposeBAL objPurpiose = new OpexPurposeBAL();
                    objPurpiose.DeletePurposeInformation(purposeId);
                    MessageBox.Show("Sucessfully Delete Opex Purpose Information.", "Purpose Information",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowDeleatablepurpose();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
