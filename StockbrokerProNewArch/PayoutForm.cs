using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class PayoutForm : Form
    {
        public PayoutForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            try
            {
                PayInTradeBAL tradeFileBal = new PayInTradeBAL();
                tradeFileBal.GeneratePayOutData(Convert.ToInt16(ddlGroup.SelectedValue), ddlGroup.Text);
                PayinOutEditor payinOutEditor = new PayinOutEditor();
                payinOutEditor.Paylog = "O";
                DialogResult dialogResult = payinOutEditor.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    GeneratePayout();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Fail to process payin files. Because: " + exception.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GeneratePayout()
        {
            try
            {
                PayInTradeBAL tradeFileBal = new PayInTradeBAL();
                DataTable datatable = tradeFileBal.MH_GetPayOutData();
                if (datatable.Rows.Count > 0)
                {
                    Write(datatable, GeneratePayoutFileName());
                }
                else
                {
                    MessageBox.Show("No Data for export.");
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error occured." + exc.Message);
            }
        }

        private void LoadGroups()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Comp_Category");
            ddlGroup.DataSource = dtData;
            ddlGroup.DisplayMember = "Comp_Category";
            ddlGroup.ValueMember = "Min_Date";
            if (ddlGroup.HasChildren)
                ddlGroup.SelectedIndex = 0;
        }

        private void PayoutForm_Load(object sender, EventArgs e)
        {
            LoadGroups();
        }

        public void Write(DataTable dt, string sFileName)
        {
            StreamWriter sw = null;
            try
            {
                SaveFileDialog oDialog = new SaveFileDialog();
                oDialog.Filter = "Payin files | *.01";
                oDialog.FileName = sFileName;

                if (oDialog.ShowDialog() == DialogResult.OK)
                {
                    sFileName = oDialog.FileName;
                }

                if (sFileName != null)
                {
                    sw = new StreamWriter(sFileName, false);
                    foreach (DataRow row in dt.Rows)
                    {
                        sw.WriteLine(row[0].ToString());
                    }
                    sw.Close();

                    MessageBox.Show("Report saved with file: " + sFileName, "To Text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    //oEXLApp.ActiveWorkbook.Close(false, Missing.Value, Missing.Value);
                    MessageBox.Show("Cannot export to Text...", "Can't export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Invalid Operation : \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GeneratePayoutFileName()
        {
            return "02023500" + DateTime.Today.ToString("ddMMyyyy") + ".02";
        }

        private void btnGenSpot_Click(object sender, EventArgs e)
        {
            try
            {
                PayInTradeBAL tradeFileBal = new PayInTradeBAL();
                tradeFileBal.GenerateSpotPayOutData(2);
                PayinOutEditor payinOutEditor = new PayinOutEditor();
                payinOutEditor.Paylog = "O";
                DialogResult dialogResult = payinOutEditor.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    GenerateSpotFile();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Fail to process payin files. Because: " + exception.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateSpotFile()
        {
            try
            {
                PayInTradeBAL tradeFileBal = new PayInTradeBAL();
                DataTable datatable = tradeFileBal.MH_GetSpotPayOutData();
                if (datatable.Rows.Count > 0)
                {
                    Write(datatable, GeneratePayoutFileName());
                }
                else
                {
                    MessageBox.Show("No Data for export.");
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error occured." + exc.Message);
            }
        }

    }
}
