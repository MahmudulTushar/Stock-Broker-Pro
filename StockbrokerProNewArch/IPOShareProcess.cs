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
    public partial class IPOShareProcess : Form
    {
        public IPOShareProcess()
        {
            InitializeComponent();
        }

        private void IPOShareProcess_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void LoadDataIntoGrid()
        {
            IPOShareBAL ipoShareBal = new IPOShareBAL();
            DataTable datatable = ipoShareBal.GetGridData();
            dtg16DP95UX.DataSource = datatable;
            dtg16DP95UX.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            lbCompShortCodeError.Items.Clear();
            lbBOError.Items.Clear();
            ValidateBOID();
            ValidateCompany();
            if (lbBOError.Items.Count == 0 && lbCompShortCodeError.Items.Count == 0)
            {
                btnProcess.Enabled = true;
            }
            else
            {
                Height = 436;
            }
        }


        private void ValidateCompany()
        {
            try
            {
                IPOShareBAL ipoShareBal = new IPOShareBAL();
                DataTable companyDataTable = new DataTable();
                companyDataTable = ipoShareBal.ValidateCompany();
                if (companyDataTable.Rows.Count > 0)
                {
                    lbCompShortCodeError.Items.Clear();
                    for (int i = 0; i < companyDataTable.Rows.Count; i++)
                    {
                        lbCompShortCodeError.Items.Add(companyDataTable.Rows[i]["ISIN_Short_Name"]);

                    }
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
            }
        }

        private void ValidateBOID()
        {
            try
            {
                IPOShareBAL ipoShareBal = new IPOShareBAL();
                DataTable boDataTable = new DataTable();
                boDataTable = ipoShareBal.ValidateBOID();
                if (boDataTable.Rows.Count > 0)
                {
                    lbBOError.Items.Clear();
                    for (int i = 0; i < boDataTable.Rows.Count; i++)
                    {
                        lbBOError.Items.Add(boDataTable.Rows[i]["BO_ID"]);

                    }
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                IPOProcessBAL ipoBAl = new IPOProcessBAL();
                IPOShareBAL ipoShareBal = new IPOShareBAL();
                
                DataTable dtCustcode_BOID = ipoBAl.GetDP9Cust_Code();
                DataTable dtComp_Short_ISIN = ipoBAl.GetDP9CompanyShortCode();
                try
                {
                    ipoBAl.ConnectDatabase();
                    ipoShareBal.SetConnection(ipoBAl.GetConnection());
                    ipoShareBal.SetTransaction(ipoBAl.GetTransaction());
                    //string Code = dtCustcode.ToString();
                    //string Comshort=dtComp_Code.ToString();
                    foreach (DataRow row in ipoShareBal.GetGridData_UTTransApplied().Rows)
                    {
                        string Custcode_tmp = dtCustcode_BOID.Rows.Cast<DataRow>()
                            .Where(t => Convert.ToString(t["BO_ID"]) == Convert.ToString(row["BO ID"]))
                            .Select(t => Convert.ToString(t["Cust_Code"])).FirstOrDefault();
                        string Comp_Code_tmp = dtComp_Short_ISIN.Rows.Cast<DataRow>()
                            .Where(t => Convert.ToString(t["ISIN_No"]) == Convert.ToString(row["ISIN No"]))
                            .Select(t => Convert.ToString(t["Comp_Short_Code"])).FirstOrDefault();
                        ipoBAl.Insert_WithDraw_From_SharetempVolt_UITrans(Custcode_tmp,Comp_Code_tmp);
                    }
                    ipoShareBal.SaveIntoShareDW_UITran(ipoBAl._dbConnection);
                    ipoBAl.UpdateIPoSessionMatured_ByCompShortCode_UITrans(Convert.ToString(dtComp_Short_ISIN.Rows[0]["Comp_Short_Code"]));

                    //ipoShareBal.Commit();
                    ipoBAl.Commit();                    
                    MessageBox.Show("IPO Share Data imported successfully.");
                }

                catch (Exception ex)
                {
                    //ipoShareBal.RollBack();
                    ipoBAl.RollBack();
                    throw ex;
                }
                finally
                {
                    //ipoShareBal.CloseDatabase();
                    ipoBAl.CloseDatabase();
                }
                this.Close();
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
