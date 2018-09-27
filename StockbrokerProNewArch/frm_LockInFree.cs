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
    public partial class frm_LockInFree : Form
    {
        private enum FormMode { AfterSearch, BeforSearch };
        
        
        public frm_LockInFree()
        {
            InitializeComponent();
        }
        private void Load_Dtg_LockInGrid()
        {
            try
            {
                LockInShareBAL lshBal = new LockInShareBAL();
                DateTime fromDate=new DateTime();
                DateTime toDate=new DateTime();
                DataTable dt = new DataTable();
                fromDate= dtp_fromDate.Value.Date;
                toDate = dtp_ToDate.Value.Date;
                dt = lshBal.GetLockInFreeGrid(fromDate, toDate);
                dtg_LockInGrid.DataSource = null;
                dtg_LockInGrid.DataSource = dt;
                dtg_LockInGrid.Columns["Share_DW_ID"].Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormModeExecution(FormMode fm)
        {
            switch (fm)
            {
                case FormMode.AfterSearch:
                    btn_Free.Enabled = true;
                    txt_FreeQty.Enabled = true;
                    break;
                case FormMode.BeforSearch:
                    Refresh_FreeRecordPanel();
                    dtg_LockInGrid.DataSource = null;
                    btn_Free.Enabled = false;
                    txt_FreeQty.Enabled = false;
                    break;
            }
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                Load_Dtg_LockInGrid();
                FormModeExecution(FormMode.AfterSearch);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
        }
        private void Validate_FreeQty(double Qty, double LockInQty, double AvailableQty, double FreeQty)
        {
            try
            {
                if (!(LockInQty >= FreeQty))
                    throw new Exception("Invalid Free Qty");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }        
        }
        private void Refresh_FreeRecordPanel()
        {
            CommonBAL cmBal=new CommonBAL();
            txt_AvailableQty.Text = "";
            txt_FreeQty.Text = "";
            txt_LockInQty.Text = "";
            txt_Share_DW_ID.Text = "";
            txt_ShareQty.Text = "";
            dtp_ExpiryDate.Value = cmBal.GetCurrentServerDate();
            dtp_ReceivedDate.Value = cmBal.GetCurrentServerDate();
        }

        private void dtg_LockInGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int intTryParse;
                double doubleTryParse;
                DateTime dateTimeTryParse;
                int Share_DW_ID = 0;
                double AppledFreeQty = 0.00;

                Refresh_FreeRecordPanel();

                if (int.TryParse(dtg_LockInGrid.Rows[e.RowIndex].Cells["Share_DW_ID"].Value.ToString(), out intTryParse))
                    txt_Share_DW_ID.Text = Convert.ToString(intTryParse);

                if (double.TryParse(dtg_LockInGrid.Rows[e.RowIndex].Cells["Qty"].Value.ToString(), out doubleTryParse))
                    txt_ShareQty.Text = Convert.ToString(doubleTryParse);

                if (double.TryParse(dtg_LockInGrid.Rows[e.RowIndex].Cells["Avail. Qty"].Value.ToString(), out doubleTryParse))
                    txt_AvailableQty.Text = Convert.ToString(doubleTryParse);
                if (double.TryParse(dtg_LockInGrid.Rows[e.RowIndex].Cells["LockIn Qty"].Value.ToString(), out doubleTryParse))
                    txt_LockInQty.Text = Convert.ToString(doubleTryParse);
                if (DateTime.TryParse(dtg_LockInGrid.Rows[e.RowIndex].Cells["Received Date"].Value.ToString(), out dateTimeTryParse))
                    dtp_ReceivedDate.Value = dateTimeTryParse;

                if (DateTime.TryParse(dtg_LockInGrid.Rows[e.RowIndex].Cells["Expiry Date"].Value.ToString(), out dateTimeTryParse))
                    dtp_ExpiryDate.Value = dateTimeTryParse;
            }
        }

        private void btn_Free_Click(object sender, EventArgs e)
        {
            try
            {
                double doubleTryParse;
                int intTryParse;
                double Qty=0.00;
                double LockInQty = 0.00;
                double FreeQty=0.00;
                double AvailableQty = 0.00;                
                double AppliedAvailAbleQty = 0.00;
                double AppliedLockInQty=0.00;
              
                int Share_DW_ID=0;

                LockInShareBAL lshBal = new LockInShareBAL();
                
                if (double.TryParse(txt_ShareQty.Text, out doubleTryParse))
                    Qty = doubleTryParse;
                if (double.TryParse(txt_LockInQty.Text, out doubleTryParse))
                    LockInQty = doubleTryParse;
                if(double.TryParse(txt_FreeQty.Text,out doubleTryParse))
                    FreeQty=doubleTryParse;
                if (double.TryParse(txt_AvailableQty.Text, out doubleTryParse))
                    AvailableQty = doubleTryParse;
                if(int.TryParse(txt_Share_DW_ID.Text,out intTryParse))
                    Share_DW_ID=intTryParse;
                Refresh_FreeRecordPanel();
                Validate_FreeQty(Qty,LockInQty,AvailableQty,FreeQty);
                AppliedAvailAbleQty=AvailableQty+FreeQty;
                AppliedLockInQty = Qty - (AvailableQty + FreeQty);
                lshBal.FreeLockInShare(Share_DW_ID, Qty, AppliedLockInQty, AppliedAvailAbleQty);
                MessageBox.Show("Successfully Free!!");

                Load_Dtg_LockInGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frm_LockInFree_Load(object sender, EventArgs e)
        {
            try
            {
                FormModeExecution(FormMode.BeforSearch);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtp_fromDate_ValueChanged(object sender, EventArgs e)
        {
            FormModeExecution(FormMode.BeforSearch);

        }

        private void dtp_ToDate_ValueChanged(object sender, EventArgs e)
        {
            FormModeExecution(FormMode.BeforSearch);
        }
    }
}
