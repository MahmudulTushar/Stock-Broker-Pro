using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class CompanyListForm : Form
    {
        public CompanyListForm()
        {
            InitializeComponent();
        }

        private void CompanyListForm_Load(object sender, EventArgs e)
        {
            LoadCDBLData();
            LoadNonCDBLData();
        }
        private void LoadCDBLData()
        {
            listBoxCDBL.Items.Clear();
            DataTable cdblDataTable=new DataTable();
            CompanyBAL compBal=new CompanyBAL();
            cdblDataTable = compBal.GetCDBLCompany();
            for (int i = 0; i < cdblDataTable.Rows.Count;i++ )
            {
                object companyName = cdblDataTable.Rows[i]["Comp_Short_Code"];
                listBoxCDBL.Items.Add(companyName.ToString());
            }
            lblCDBL.Text = "Total CDBL:" + listBoxCDBL.Items.Count;

        }
        private void LoadNonCDBLData()
        {
            listBoxNonCDBL.Items.Clear();
            DataTable noncdblDataTable = new DataTable();
            CompanyBAL compBal = new CompanyBAL();
            noncdblDataTable = compBal.GetNonCDBLCompany();
            for (int i = 0; i < noncdblDataTable.Rows.Count; i++)
            {
                object companyName = noncdblDataTable.Rows[i]["Comp_Short_Code"];
                listBoxNonCDBL.Items.Add(companyName.ToString());
            }
            lblNonCDBL.Text = "Total Non-CDBL:" + listBoxNonCDBL.Items.Count;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            object companyName = listBoxNonCDBL.SelectedItem;
            if (companyName == null) return;
            CompanyBAL compBAL=new CompanyBAL();
            compBAL.ConvertNonCDBLToCDBL(companyName);
            listBoxCDBL.Items.Add(companyName);
            listBoxNonCDBL.Items.Remove(companyName);
            lblCDBL.Text = "Total CDBL Company :" + listBoxCDBL.Items.Count;
            lblNonCDBL.Text = "Total Non-CDBL Company :" + listBoxNonCDBL.Items.Count;

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            object companyName = listBoxCDBL.SelectedItem;
            if (companyName == null) return;
            CompanyBAL compBAL = new CompanyBAL();
            compBAL.ConvertCDBLToNonCDBL(companyName);
            listBoxNonCDBL.Items.Add(companyName);
            listBoxCDBL.Items.Remove(companyName);
            lblCDBL.Text = "Total CDBL Company :" + listBoxCDBL.Items.Count;
            lblNonCDBL.Text = "Total Non-CDBL Company :" + listBoxNonCDBL.Items.Count;
        }

       
    }
}
