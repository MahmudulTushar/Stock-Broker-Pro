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
    public partial class frmDeleteCapexInformation : Form
    {
        public frmDeleteCapexInformation()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDeleteCapexInformation_Load(object sender, EventArgs e)
        {
            try
            {
                GetRecordInfo();
                ShowAssetInfo();

               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GetRecordInfo()
        {
            try
            {
                AssetInformationBAL objAssetBal = new AssetInformationBAL();
                objAssetBal.GetAssetCommonInfo();

                lblTotalRecord.Text = "Total Record: " +  objAssetBal.TotalRecord.ToString();
                lblPurposeAmount.Text = "Purchase :Tk. " + String.Format("{0:0.00}", objAssetBal.PurpasePrice);
                lblSalaveAmount.Text = "Salvage Tk. " + String.Format("{0:0.00}", objAssetBal.SalvagePrice);
                lblDepriciationAmount.Text = "Total Depriciation Tk. " + String.Format("{0:0.00}", objAssetBal.DepriceationValue);

                
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void DeleteAssetInfo(int AssetId)
        {
            try
            {
                if (MessageBox.Show("Do you want to Delete this Asset Information", "Delete Asset Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    AssetInformationBAL objAssetInfoBAl = new AssetInformationBAL();
                    objAssetInfoBAl.DeleteAssetInfo(AssetId);
                    MessageBox.Show("Asset Information is Secessfully Deleted.", "", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    
                    ShowAssetInfo();

                    GetRecordInfo();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ShowAssetInfo()
        {
            try
            {
                DataTable dtAssetInfo = new DataTable();
                AssetInformationBAL objAssetInfoBal = new AssetInformationBAL();
                dtAssetInfo = objAssetInfoBal.GetAssetEntryInfo();

                dgvAssetInfo.DataSource = dtAssetInfo;
                dgvAssetInfo.Columns[0].Visible = false;

                if(dgvAssetInfo.Rows.Count>0)
                {
                    btnRemove.Enabled = true;
                }

                else
                {
                    btnRemove.Enabled = false;
                }



            }
            catch (Exception)
            {

                throw;
            }
        }

       
       


        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to Delete this Capex Information.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes && dgvAssetInfo.Rows.Count > 0)
                {
                    int expenseId = Int32.Parse(dgvAssetInfo.SelectedRows[0].Cells[0].Value.ToString());
                    DeleteAssetInfo(expenseId);
                    ShowAssetInfo();
                    GetRecordInfo();
                
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvAssetInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if(dgvAssetInfo.Rows.Count>0)
                {
                    int expenseId = Int32.Parse(dgvAssetInfo.SelectedRows[0].Cells[0].Value.ToString());
                    DeleteAssetInfo(expenseId);
                    ShowAssetInfo();
                }
              
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


    }
}
