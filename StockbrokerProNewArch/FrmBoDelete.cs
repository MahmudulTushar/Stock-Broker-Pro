using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using DataAccessLayer;
//using BankBook.Components.AppSystem;
//using BankBook.Report.ReportValue;
//using BankBookApplication.Components.DAL;

namespace StockbrokerProNewArch
{
    public partial class FrmBoDelete : Form
    {
        BO_Opening_InformationBAL BoDeleteBal = new BO_Opening_InformationBAL();
        private DbConnection _dbConnection;

        public FrmBoDelete()
        {
            InitializeComponent();          
        }

        private void FrmBoDelete_Load(object sender, EventArgs e)
        {

        }

        private void dateToDateSearch()
        {
            string DateTimeFirst = Convert.ToString(pDateFirst.Value.ToString("yyyy-MM-dd"));
            string DateTimeLast = Convert.ToString(pDateLast.Value.ToString("yyyy-MM-dd"));
            string query = @"select 
                                 OpDate as Dates
                                ,Name as Client_Name
                                ,CellNo as Mobile_No
                                ,Qty as Quantity
                                ,Price
                                ,TotalPrice as Total
                                ,FrmNoFast as First_FormNo
                                ,FrmNoLast as Last_FormNo 
                                from SBP_BO_OpeningInformation
                                where OpDate between '"+DateTimeFirst+"' and '"+DateTimeLast+@"'
                                ORDER BY SlNo DESC";
            dataGridView1.DataSource = BoDeleteBal.Get_Data(query);
            lblCount.Text = Convert.ToString(dataGridView1.Rows.Count);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dateToDateSearch();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)   
        {
            string DateTimeFirst = Convert.ToString(pDateFirst.Value.ToString("yyyy-MM-dd"));
            string DateTimeLast = Convert.ToString(pDateLast.Value.ToString("yyyy-MM-dd"));
            string formNoFirst = txtFormFirst.Text;
            dataGridView1.DataSource = BoDeleteBal.GetSearchDataForDelete(DateTimeFirst, DateTimeLast, formNoFirst);
        }

        private void txtFormLast_TextChanged(object sender, EventArgs e)
        {
            string DateTimeFirst = Convert.ToString(pDateFirst.Value.ToString("yyyy-MM-dd"));
            string DateTimeLast = Convert.ToString(pDateLast.Value.ToString("yyyy-MM-dd"));
            string formNoLast = txtFormLast.Text;
            dataGridView1.DataSource = BoDeleteBal.GetSearchDataForDeleteLast(DateTimeFirst, DateTimeLast, formNoLast);
        }

        int x = 0;       // Note : BoDataDeleteInformation
        string FrmNoFast;
        private void btnDelete_Click(object sender, EventArgs e)  // document file : btnDelete_ClickBO
        {
            if (MessageBox.Show("Sure you want to delete?", "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        int index = row.Index;
                        bool Ischecked = Convert.ToBoolean(dataGridView1.Rows[index].Cells["check"].Value);
                        if (Ischecked==true)
                        {
                            DateTime exDate = Convert.ToDateTime(dataGridView1.Rows[index].Cells["Dates"].Value.ToString());
                            string Mobile = Convert.ToString(dataGridView1.Rows[index].Cells["Mobile_No"].Value.ToString());
                            string frmFirst = Convert.ToString(dataGridView1.Rows[index].Cells["First_FormNo"].Value.ToString());
                            string frmLast = Convert.ToString(dataGridView1.Rows[index].Cells["Last_FormNo"].Value.ToString());

                            BoDeleteBal.DeleteBoInformation(exDate, Mobile, frmFirst, frmLast);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Please select a row first...", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                MessageBox.Show("Deleted Successfully....", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateToDateSearch();
                lblCount.Text = Convert.ToString(dataGridView1.Rows.Count);

                //try
                //{
                //    FrmNoFast = string.Empty;
                //    x = 0;
                //    List<string> lines = new List<string>();
                //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //    {
                //        bool Ischecked = Convert.ToBoolean(dataGridView1.Rows[i].Cells["check"].Value);
                //        if (Ischecked == true)
                //        {
                //            if (x == 0)
                //            {
                //                FrmNoFast = dataGridView1.Rows[i].Cells["First_Form_No"].Value.ToString();
                //                FrmNoFast = "'" + FrmNoFast + "'";
                //            }
                //            else if (x > 0)
                //            {
                //                FrmNoFast = FrmNoFast + ",'" + dataGridView1.Rows[i].Cells["First_Form_No"].Value.ToString();
                //                FrmNoFast = FrmNoFast + "'";
                //            }
                //            x++;
                //        }
                //    }
                //    BoDeleteBal.DeleteBoInformation(FrmNoFast);
                //    MessageBox.Show("Deleted Successfully....", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    dateToDateSearch();
                //    lblCount.Text = Convert.ToString(dataGridView1.Rows.Count);
                //}
                //catch
                //{
                //    MessageBox.Show("Please select a row first...", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            else
            {
                //
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
