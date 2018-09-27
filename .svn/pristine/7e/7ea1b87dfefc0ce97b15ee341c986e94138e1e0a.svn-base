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


namespace StockbrokerProNewArch
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
            txtDeprciation.Text = "10";
            txtPurchasePrice.Text = "0";
            txtSalvageValue.Text = "0";

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

                else if(txtDeprciation.Text.Trim()==string.Empty)
                {
                    MessageBox.Show("Deprciation Rate Can not be Blank", "Asset Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDeprciation.Focus();
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

                    else if(float.TryParse(txtDeprciation.Text,out test)==false)
                    {
                        status = false;
                        MessageBox.Show("Deprciation Rate Must be Numeric", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                GenerateDepriationRate();
                GetCatagoryList();
                ShowAssetList();
                ShowAssetInfo();
                GetRecordInfo();
                btnAddCatagory.Enabled = GlobalVariableBO._addCategoryPriv;
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
                lblDepriciationAmount.Text = "Net Purchase Tk. " + String.Format("{0:0.00}", objAssetBal.DepriceationValue);
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

                if (ddlCatagory.Text.Trim() != string.Empty)
                {
                    int CatagoryId = Int32.Parse(ddlCatagory.SelectedValue.ToString());
                    dtAssetList = objAssetBAL.GetAssetList(CatagoryId);

                    ddlAssetList.DataSource = dtAssetList;
                    ddlAssetList.DisplayMember = "AssetName";
                    

                    if (dtAssetList.Rows.Count<=0)
                    {
                        ddlAssetList.Text = "";
                    }
                  

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
                    objAssetBO.LifeTime =Int32.Parse(lblDays.Text);
                    lblDays.Text = objAssetBO.LifeTime.ToString();
                    objAssetBO.CatagoryId = Int32.Parse(ddlCatagory.SelectedValue.ToString());
                    objAssetBO.DeprceiationRate = float.Parse(txtDeprciation.Text);

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
                   txtDeprciation.Focus();
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

    

        private void btnAddCatagory_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddCapexCatagory objCatagory=new frmAddCapexCatagory();
                objCatagory.ShowDialog();
                GetCatagoryList();
                ShowAssetList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GetCatagoryList()
        {
            try
            {
                DataTable dtList=new DataTable();
                AssetInformationBAL objAssetInfoBal=new AssetInformationBAL();
                dtList=objAssetInfoBal.GetCapexCategoryList();
                ddlCatagory.DataSource = dtList;
                ddlCatagory.DisplayMember = "CategoryName";
                ddlCatagory.ValueMember = "CategoryId";


            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void ddlCatagory_SelectedValueChanged(object sender, EventArgs e)
        {
            /*try
            {
                ShowAssetList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }*/
        }

        private void ddlCatagory_TextChanged(object sender, EventArgs e)
        {
            /*try
            {
                ShowAssetList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }*/
        }

        private void ddlCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ShowAssetList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

     

        private void GenerateDepriationRate()
        {
            try
            {
                if(txtDeprciation.Text.Trim()!=string.Empty && txtPurchasePrice.Text.Trim()!=string.Empty && txtSalvageValue.Text.Trim()!=string.Empty)
                {
                    float test;

                    if(float.TryParse(txtPurchasePrice.Text,out test)==false)
                    {
                         MessageBox.Show("Purchase Price Can not alphanumeric", "Invaild Purchase Price",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDeprciation.Focus();
                    }

                    else if(float.TryParse(txtSalvageValue.Text,out test)==false)
                    {
                         MessageBox.Show("Salvage Price Can not alphanumeric", "Invaid Salvage Price",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSalvageValue.Focus();
                    }

                    else if(float.TryParse(txtDeprciation.Text,out test)==false)
                    {
                         MessageBox.Show("Deprciation Rate Can not alphanumeric", " Invaild Deprciation Rate",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDeprciation.Focus();
                    }

                    else

                    {
                        float deprciationRate = float.Parse(txtDeprciation.Text)/100;
                        float NetExpenseCost = float.Parse(txtPurchasePrice.Text) - float.Parse(txtSalvageValue.Text);
                        int Days = (int) ((365*NetExpenseCost)/deprciationRate);
                        lblDays.Text = Days.ToString();

                    }

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDeprciation_TextChanged(object sender, EventArgs e)
        {
            GenerateDepriationRate();
        }


    }
}
