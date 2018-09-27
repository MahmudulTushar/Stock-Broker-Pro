using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using CrystalDecisions.CrystalReports.Engine;
 

namespace DseReports 
{
    public partial class frmPortfolio_Statement_Instrumnet_Wise_DSE_22_3 : Form
    {
        Portfolio_Statement_Instrumnet_Wise_DSE_22_3BAL objBAL = new Portfolio_Statement_Instrumnet_Wise_DSE_22_3BAL();

        public frmPortfolio_Statement_Instrumnet_Wise_DSE_22_3()
        {
            InitializeComponent();
            
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            crPortfolio_Statement_Instrumnet_Wise_DSE_22_3 objRPT = new crPortfolio_Statement_Instrumnet_Wise_DSE_22_3();
            frmReportViewer viewer = new frmReportViewer();

            string insCode = txtCompanyCode.Text;            
           string dcode = objBAL.GetCompanyCode(insCode);


            if (insCode == "")
            {
                MessageBox.Show("Please enter your company code");
            }
            else if (dcode!=insCode)
            {
                MessageBox.Show("Your Company Code is invalid");
            }
            else
            {
                string Exchange = cmbExchangeName.Text;
                
                DataTable dt = new DataTable();
                dt = objBAL.Portfolio_Statement_Instrumnet_Wise(insCode, dtpTradeDate.Value, Exchange);
                objRPT.SetDataSource(dt);
                viewer.crvReportViewer.ReportSource = objRPT;
                if (Exchange == "DSE")
                {
                    Exchange = "DSE";
                }
                else
                {
                    Exchange = "All";
                }
                ((TextObject)objRPT.Section2.ReportObjects["txtInstrumentId"]).Text = insCode;
                ((TextObject)objRPT.Section2.ReportObjects["txtExchangeName"]).Text = cmbExchangeName.Text;
                ((TextObject)objRPT.Section2.ReportObjects["txtReportDate"]).Text = dtpTradeDate.Value.ToString("dd-MMMM-yyyy");
                viewer.Show();
            }
        }

        #region Load ComboBox
        public void LoadComboBox()
        {
            DataTable dtExchange = new DataTable();
            DataTable dtBranch = new DataTable();

            dtExchange = objBAL.GetExchangeName();
            cmbExchangeName.DataSource = dtExchange;
            cmbExchangeName.DisplayMember = dtExchange.Columns[0].ToString();
            cmbExchangeName.ValueMember = dtExchange.Columns[0].ToString();

            //dtBranch = objBAL.GetCompanyCode();
            //cmbCompanyCode.DataSource = dtBranch;
            //cmbCompanyCode.DisplayMember = dtBranch.Columns[0].ToString();
            //cmbCompanyCode.ValueMember = dtBranch.Columns[0].ToString();
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
