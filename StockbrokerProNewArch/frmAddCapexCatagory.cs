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
    public partial class frmAddCapexCatagory : Form
    {
        public frmAddCapexCatagory()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveCategory();
        }

        private void SaveCategory()
        {
            try
            {
                if(txtCategoryName.Text.Trim()==String.Empty)
                {
                    MessageBox.Show("Category Name Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCategoryName.Focus();
                }

                else
                {
                    AssetInformationBAL objAssetInformationBal = new AssetInformationBAL();
                    objAssetInformationBal.InsertCapexCatagory(txtCategoryName.Text);
                    Close();

                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmAddCapexCatagory_Load(object sender, EventArgs e)
        {
            try
            {
                AssetInformationBAL objAsset = new AssetInformationBAL();
                label2.Text = "Add New Capex Catagory   Total Category: " + objAsset.GetCapexCategory().ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
