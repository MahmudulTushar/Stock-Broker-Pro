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
    public partial class CompanySelectionForPrice : Form
    {
        public CompanySelectionForPrice()
        {
            InitializeComponent();
        }

        private void CompanySelectionForPrice_Load(object sender, EventArgs e)
        {
            LoadVisibleCompany();
            LoadHiddenCompany();
        }

        private void LoadHiddenCompany()
        {
            listBoxVisibleCompany.Items.Clear();
            DataTable visibleDataTable = new DataTable();
            LatestTradePriceBAL latestTradePriceBal = new LatestTradePriceBAL();
            visibleDataTable = latestTradePriceBal.GetVisibleComapny();
            for (int i = 0; i < visibleDataTable.Rows.Count; i++)
            {
                object companyName = visibleDataTable.Rows[i]["Instrument_Code"];
                listBoxVisibleCompany.Items.Add(companyName.ToString());
            }
            lblVisible.Text = "Total Visible:" + listBoxVisibleCompany.Items.Count;
            
        }

        private void LoadVisibleCompany()
        {
            listBoxHiddenCompany.Items.Clear();
            DataTable hiddenDataTable = new DataTable();
            LatestTradePriceBAL latestTradePriceBal = new LatestTradePriceBAL();
            hiddenDataTable = latestTradePriceBal.GetHiddenCompany();
            for (int i = 0; i < hiddenDataTable.Rows.Count; i++)
            {
                object companyName = hiddenDataTable.Rows[i]["Instrument_Code"];
                listBoxHiddenCompany.Items.Add(companyName.ToString());
            }
            lblHidden.Text = "Total Hidden:" + listBoxHiddenCompany.Items.Count;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            object companyName = listBoxVisibleCompany.SelectedItem;
            if (companyName == null) return;
            LatestTradePriceBAL latestTradePriceBal = new LatestTradePriceBAL();
            latestTradePriceBal.ConvertVisibleToHidden(companyName);
            listBoxHiddenCompany.Items.Add(companyName);
            listBoxVisibleCompany.Items.Remove(companyName);
            lblVisible.Text = "Total Visible :" + listBoxVisibleCompany.Items.Count;
            lblHidden.Text = "Total Hidden :" + listBoxHiddenCompany.Items.Count;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            object companyName = listBoxHiddenCompany.SelectedItem;
            if (companyName == null) return;
            LatestTradePriceBAL latestTradePriceBal = new LatestTradePriceBAL();
            latestTradePriceBal.ConvertHiddenToVisible(companyName);
            listBoxVisibleCompany.Items.Add(companyName);
            listBoxHiddenCompany.Items.Remove(companyName);
            lblVisible.Text = "Total Visible :" + listBoxVisibleCompany.Items.Count;
            lblHidden.Text = "Total Hidden :" + listBoxHiddenCompany.Items.Count;
        }
    }
}
