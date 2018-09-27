using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.BAL;
using System.Text.RegularExpressions;


namespace CAPEX
{
    public partial class frmNoDepreciation : Form
    {
        public frmNoDepreciation()
        {
            InitializeComponent();
        }

        private int _AssetId;
        public int AssetID
        {
            get { return _AssetId; }
            set { _AssetId = value; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshToDialogBox();
        }

        private void  RefreshToDialogBox()
        {
            txtQuantity.Clear();
            txtSalvageValue.Clear();
            txtPurchasePrice.Clear();

            ddlAssetList.Focus();
            GetRecordInfo();


        }

        private bool CheeckToBlankInput()
        {
            bool status = false;
            try
            {
               

                if (ddlAssetList.Text == String.Empty)
                {
                    MessageBox.Show("Asset Name Required ??", "Asset Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ddlAssetList.Focus();
                    status = false;
                }

                else if (txtQuantity.Text == string.Empty)
                {
                    MessageBox.Show("Asset Quantity Required ?", "Asset Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuantity.Focus();
                    status = false;
                }

                else if (txtPurchasePrice.Text == string.Empty)
                {
                    MessageBox.Show("Purchase Price(Tk.) Required ?", "Asset Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPurchasePrice.Focus();
                    status = false;
                }

                else if (txtSalvageValue.Text == string.Empty)
                {
                    MessageBox.Show("Salvage amount(Tk.) Required ?", "Asset Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSalvageValue.Focus();
                    status = false;
                }

                

                else if (dtpPurchaseDate.Value>dtpServicesDate.Value)
                {
                    MessageBox.Show("Purchase Date must de before than Service Date?", "Asset Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpServicesDate.Focus();
                    status = false;
                }


                else
                {
                    float test;

                    if(float.TryParse(txtPurchasePrice.Text,out test)==false)
                    {
                        status = false;
                        MessageBox.Show("Purchase Price Must be Numeric","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        txtPurchasePrice.Focus();

                    }

                    else if(float.TryParse(txtSalvageValue.Text,out test)==false)
                    {
                        status = false;
                        MessageBox.Show("Salvage Value Must be Numeric", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSalvageValue.Focus();
                    }

                   
                    else
                    {
                        
                            status = true;
                        
                    }
                    


                }

            }
            catch (Exception)
            {
                
                throw;
            }

            return status;


        }

        private void frmNoDepreciation_Load(object sender, EventArgs e)
        {
            try
            {
                ShowAssetList();
                ShowAssetInfo();
                lblDays.Text = GetTotalTotalDays(Int32.Parse(nudYear.Value.ToString()), Int32.Parse(nudMonth.Value.ToString()), Int32.Parse(nudDays.Value.ToString())).ToString();
                GetRecordInfo();
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
                AssetInformationBAL objAssetBal=new AssetInformationBAL();
                objAssetBal.GetAssetCommonInfo();

                lblTotalRecord.Text = "Total Record: " + objAssetBal.TotalRecord.ToString();
                lblPurposeAmount.Text = "Purchase:Tk. " + String.Format("{0:0.00}", objAssetBal.PurpasePrice);
                lblSalaveAmount.Text = "Salvage Tk. " + String.Format("{0:0.00}", objAssetBal.SalvagePrice);
                lblDepriciationAmount.Text = "Total Depriciation Tk. " + String.Format("{0:0.00}", objAssetBal.DepriceationValue);
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        private void ShowAssetList()
        {
            try
            {
                DataTable dtAssetList=new DataTable();
                AssetInformationBAL objAssetBAL=new AssetInformationBAL();
                dtAssetList = objAssetBAL.GetAssetList();

                if(dtAssetList.Rows.Count>0)
                {
                    ddlAssetList.DataSource = dtAssetList;
                    ddlAssetList.DisplayMember = "AssetName";
                }

                else
                {
                    ddlAssetList.Items.Clear();
                }


            }
            catch
            {
  
            }
        }

        private int GetTotalTotalDays(int year,int month,int days)
        {
            int totalDays = 0;
            totalDays = (year*365) + (month*30) + days;
            return totalDays;
        }

        private void ShowAssetInfo()
        {
            try
            {
                DataTable dtAssetInfo=new DataTable();
                AssetInformationBAL objAssetInfoBal=new AssetInformationBAL();
                dtAssetInfo = objAssetInfoBal.GetAssetEntryInfo();

                dgvAssetInfo.DataSource = dtAssetInfo;
                dgvAssetInfo.Columns[0].Visible = false;
                

                
            }
            catch (Exception)
            {
     
                throw;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                
               AddToAssetList();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        

        private void AddToAssetList()
        {
            try
            {
                if (CheeckToBlankInput())
                {
                    AssetEntryBO objAssetBO = new AssetEntryBO();
                    objAssetBO.AssetName = ddlAssetList.Text;
                    objAssetBO.AssetQuantity = Int32.Parse(txtQuantity.Text);
                    objAssetBO.PurchaseDate = dtpPurchaseDate.Value;
                    objAssetBO.ServicesDate = dtpServicesDate.Value;
                    objAssetBO.PurchasePrice = float.Parse(txtPurchasePrice.Text);
                    objAssetBO.SalvageValue = float.Parse(txtSalvageValue.Text);
                    objAssetBO.LifeTime = GetTotalTotalDays(Int32.Parse(nudYear.Value.ToString()),Int32.Parse(nudMonth.Value.ToString()),Int32.Parse(nudDays.Value.ToString()));
                    lblDays.Text = objAssetBO.LifeTime.ToString();

                    AssetInformationBAL objAssetInfoBal = new AssetInformationBAL();
                    objAssetInfoBal.InsertIntoDataBase(objAssetBO);

                    MessageBox.Show("Data Secessfully Saved.", "Asset Entry", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ShowAssetInfo();
                    RefreshToDialogBox();
                    ShowAssetList();
                    GetRecordInfo();

                }
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

       

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Regex.IsMatch(e.KeyChar.ToString(), "\\d+") && e.KeyChar != Convert.ToChar(Keys.Back))
                {
                    e.Handled = true;
                }
            }
            catch 
            {
               
            }
           
        }

       
      

        private void ddlAssetList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                    dtpPurchaseDate.Focus();
            }
            catch 
            {
                
            }
        }

        private void dtpPurchaseDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                    dtpServicesDate.Focus();
            }
            catch
            {

            }
        }

        private void dtpServicesDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                    txtQuantity.Focus();
            }
            catch
            {

            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                    txtPurchasePrice.Focus();
            }
            catch
            {

            }
        }

        private void txtPurchasePrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                    txtSalvageValue.Focus();
            }
            catch
            {

            }
        }

        private void txtSalvageValue_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                   nudYear.Focus();
            }
            catch
            {

            }
        }

        private void txtPurchasePrice_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                float test;
                if (!float.TryParse(txtPurchasePrice.Text, out test) && txtPurchasePrice.Text!=String.Empty)
                {
                    MessageBox.Show("Only Integer or Float\n  Number Allowed.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPurchasePrice.Focus();
                }



            }
            catch
            {

            }
        }

        private void txtSalvageValue_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                float test;
                if (float.TryParse(txtSalvageValue.Text, out test)==false && txtSalvageValue.Text!=String.Empty)
                {
                    MessageBox.Show("Only Integer or Float\n  Number Allowed.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSalvageValue.Focus();
                }



            }
            catch
            {

            }
        }

       

        

        private void dgvAssetInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            

            try
            {
                DefaultCellStyle();
            }
            catch (Exception ex)
            {
                
              MessageBox.Show(ex.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }

        private void ShowAssetInfoByAssetId(int AssetId)
        {
            try
            {
                DataTable dtAssetInfo = new DataTable();
                AssetInformationBAL objAssetInfoBal = new AssetInformationBAL();

                dtAssetInfo = objAssetInfoBal.GetAssetInfoByAssetId(AssetId);

                if(dtAssetInfo.Rows.Count>0)
                {
                    ddlAssetList.Text = dtAssetInfo.Rows[0][0].ToString();
                    txtQuantity.Text = dtAssetInfo.Rows[0][1].ToString();
                    dtpPurchaseDate.Value = Convert.ToDateTime(dtAssetInfo.Rows[0][2].ToString());
                    dtpServicesDate.Value = Convert.ToDateTime(dtAssetInfo.Rows[0][3].ToString());
                    txtPurchasePrice.Text = dtAssetInfo.Rows[0][4].ToString();
                    txtSalvageValue.Text = dtAssetInfo.Rows[0][5].ToString();
                    int TotalDays = Int32.Parse(dtAssetInfo.Rows[0][6].ToString());
                    nudYear.Value =TotalDays/365;
                    nudMonth.Value = (TotalDays%365)/30;
                    nudDays.Value = (TotalDays % 365) % 30;
                    lblDays.Text = TotalDays.ToString();
                   

                }

                else
                {
                    RefreshToDialogBox();
                }
            }

            catch (Exception)
            {

                throw;
            }
        }

        private void DefaultCellStyle()
        {
            try
            {
                dgvAssetInfo.DefaultCellStyle.SelectionBackColor = SystemColors.Info;
                dgvAssetInfo.DefaultCellStyle.SelectionForeColor = Color.Crimson;
                dgvAssetInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

       

        private void rbtAddNewAsset_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                btnAdd.Enabled = true;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void rbtDeleteAsset_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                btnAdd.Enabled = false;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void nudYear_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblDays.Text = GetTotalTotalDays(Int32.Parse(nudYear.Value.ToString()), Int32.Parse(nudMonth.Value.ToString()), Int32.Parse(nudDays.Value.ToString())).ToString();
            }
            catch 
            {
               
            }
        }

        private void nudMonth_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblDays.Text = GetTotalTotalDays(Int32.Parse(nudYear.Value.ToString()), Int32.Parse(nudMonth.Value.ToString()), Int32.Parse(nudDays.Value.ToString())).ToString();
            }
            catch
            {

            }
        }

        private void nudDays_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblDays.Text = GetTotalTotalDays(Int32.Parse(nudYear.Value.ToString()), Int32.Parse(nudMonth.Value.ToString()), Int32.Parse(nudDays.Value.ToString())).ToString();
            }
            catch
            {

            }
        }


    }
}
