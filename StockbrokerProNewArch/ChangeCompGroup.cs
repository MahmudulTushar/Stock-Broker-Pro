using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class ChangeCompGroup : Form
    {
        public ChangeCompGroup()
        {
            InitializeComponent();
        }
        CompanyCategoryChangeBO changeBo = new CompanyCategoryChangeBO();

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                
                changeBo.CompShortCode = ddlCompanyName.SelectedValue.ToString();
                changeBo.NewCategoryId =Convert.ToInt32(ddlNewCategory.SelectedValue);
                changeBo.EffectiveDate = dtEffectiveDate.Value;
                CompanyCategoryChangeBAL changeBal = new CompanyCategoryChangeBAL();
                changeBal.Insert(changeBo);
                MessageBox.Show("Company Category has been changed.");
                LoadGridData();
            }
            catch (Exception exc)
            {

                MessageBox.Show("Company Category can not changed.Error: " + exc.Message);
            }
        }

        private void ChangeCompCategory_Load(object sender, EventArgs e)
        {
            LoadFunction();
            ddlCompanyName.SelectedIndex = 0;
            ddlNewCategory.SelectedIndex = 0;
        }

        private void LoadFunction()
        {
            LoadCompanyddl();
            LoadCategoryddl();
            LoadGridData();
        }

        private void LoadGridData()
        {
            CompanyCategoryChangeBAL changeBal = new CompanyCategoryChangeBAL();
            DataTable datatable = changeBal.GetGridInfo();
            dtgChangedCompcategory.DataSource = datatable;
            this.dtgChangedCompcategory.Columns[0].Visible = false;
            dtgChangedCompcategory.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            
        }

        private void LoadCategoryddl()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Comp_Category");
            ddlNewCategory.DataSource = dtData;
            ddlNewCategory.DisplayMember = "Comp_Category";
            ddlNewCategory.ValueMember = "Comp_Cat_ID";
            if (ddlNewCategory.HasChildren)
                ddlNewCategory.SelectedIndex = 0;
           
        }

        private void LoadCompanyddl()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Company");
            ddlCompanyName.DataSource = dtData;
            ddlCompanyName.DisplayMember = "Comp_Short_Code";
            ddlCompanyName.ValueMember = "Comp_Short_Code";
            if (ddlCompanyName.HasChildren)
                ddlCompanyName.SelectedIndex = -1;
            LoadOldCategory();
           
        }

        private void ddlCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOldCategory();
        }

        private void LoadOldCategory()
        {
            string companyShortName = "";
            companyShortName = ddlCompanyName.SelectedValue.ToString();
            CompanyBAL companyBal = new CompanyBAL();
            DataTable oldCatDT = new DataTable();
            oldCatDT = companyBal.GetOldCategory(companyShortName);
            if (oldCatDT.Rows.Count > 0)
            {
               changeBo.OldCategoryId = Convert.ToInt32(oldCatDT.Rows[0][0]);
               txtOldCategory.Text = oldCatDT.Rows[0][1].ToString();
            }
        }
    }
}
