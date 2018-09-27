using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL; 
using CrystalDecisions.CrystalReports.Engine; 


namespace DseReports
{
    public partial class frmBonus_Instrument_Receive_Report_DSE_21_3 : Form
    {
        private string _instrumentId;
        private string _instrumentName;
        public frmBonus_Instrument_Receive_Report_DSE_21_3()
        {
            InitializeComponent();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            Bonus_Instrument_Receive_Report_DSE_21_3BAL objBAL = new Bonus_Instrument_Receive_Report_DSE_21_3BAL();
            DataTable data = new DataTable();
            frmReportViewer rptviewer = new frmReportViewer();
            crBonus__Instrument__Receive__Report__DSE__21_3 objrpt = new crBonus__Instrument__Receive__Report__DSE__21_3();
            try
            {
                CheckValidation();
                SetInstrumentInfo();
                if (_instrumentId != "" && _instrumentName == "")
                {
                    //data = objBAL.BonusInstrumentReceiveReportData(dtpFromDate.Value, dtpToDate.Value, _instrumentId, "");
                    _instrumentName = GetInstrumentNameByInstrumentID(_instrumentId);
                }
                else if (_instrumentId == "" && _instrumentName != "")
                {
                    //data = objBAL.BonusInstrumentReceiveReportData(dtpFromDate.Value, dtpToDate.Value, "", _instrumentName);
                    _instrumentId = GetInstrumentIDByInstrumentName(_instrumentName);
                }

                data = objBAL.BonusInstrumentReceiveReportData(dtpFromDate.Value, dtpToDate.Value, _instrumentId,_instrumentName);
                objrpt.SetDataSource(data);
                ((TextObject)objrpt.Section2.ReportObjects["txtfromDate"]).Text = Convert.ToDateTime(dtpFromDate.Value.ToString()).ToString("dd/MM/yyyy");
                ((TextObject)(objrpt.Section2.ReportObjects["txttoDate"])).Text = Convert.ToDateTime(dtpToDate.Value.ToShortDateString()).ToString("dd/MM/yyyy");

                rptviewer.crvReportViewer.ReportSource = objrpt;
                rptviewer.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string GetInstrumentNameByInstrumentID(string _instrumentID)
        {
            Bonus_Instrument_Receive_Report_DSE_21_3BAL objBAL = new Bonus_Instrument_Receive_Report_DSE_21_3BAL();
            string tempInstrumentID = "";
            tempInstrumentID = objBAL.GetInstrumentNameByID(_instrumentID);
            return tempInstrumentID;
        }

        private string GetInstrumentIDByInstrumentName(string _instrumentname)
        {
            Bonus_Instrument_Receive_Report_DSE_21_3BAL objBAL = new Bonus_Instrument_Receive_Report_DSE_21_3BAL();
            string tempInstrumentname = "";
            tempInstrumentname = objBAL.GetInstrumentIDByName(_instrumentname);
            return tempInstrumentname;
        }
        private void SetInstrumentInfo()
        {
            try
            {
                if (rdbByInstrumentID.Checked)
                {
                    _instrumentId = ddlInstrumentID.Text.Trim();
                }
                else
                {
                    _instrumentId = "";
                }
                if (rdbByInstrumentName.Checked)
                {
                    _instrumentName = ddlInstrumentName.Text.Trim();
                }
                else
                {
                    _instrumentName = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CheckValidation()
        {
            if (rdbByInstrumentID.Checked && rdbByInstrumentID.Text == "")
            {
                throw new Exception("Instrument ID Required");
            }
            if (rdbByInstrumentName.Checked && rdbByInstrumentName.Text == "")
            {
                throw new Exception("Instrument Name Required");
            }
        }
        private void frmBonus_Instrument_Receive_Report_DSE_21_3_Load(object sender, EventArgs e)
        {
            try
            {
                Bonus_Instrument_Receive_Report_DSE_21_3BAL objBAL = new Bonus_Instrument_Receive_Report_DSE_21_3BAL();

                ddlInstrumentID.DataSource = objBAL.GetInstrumentID();
                ddlInstrumentID.DisplayMember = "Comp_Short_Code";

                ddlInstrumentName.DataSource = objBAL.GetInstrumentName();
                ddlInstrumentName.DisplayMember = "Comp_Name";
                rdbByInstrumentID.Checked = true;
                ddlInstrumentName.Enabled = false;
                ddlInstrumentName.SelectedIndex = -1;
            }
            catch{}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbByInstrumentID_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbByInstrumentID.Checked)
            {
                ddlInstrumentID.Enabled = true;
            }
            else
            {
                ddlInstrumentID.Enabled = false;
                ddlInstrumentID.SelectedIndex = -1;
            }
        }

        private void rdbByInstrumentName_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbByInstrumentName.Checked)
            {
                ddlInstrumentName.Enabled = true;
            }
            else
            {
                ddlInstrumentName.Enabled = false;
                ddlInstrumentName.SelectedIndex = -1;
            }
        }
    }
}
