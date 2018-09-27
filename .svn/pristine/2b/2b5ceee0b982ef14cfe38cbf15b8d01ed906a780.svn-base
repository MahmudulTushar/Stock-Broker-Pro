using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.Constants;
using StockbrokerProNewArch.Classes;
using System.Threading;

namespace StockbrokerProNewArch
{
    public partial class frmSMSConfirmationProcess : Form
    {
        public string MenuName;
        public static bool isProgressed;

        public enum FormMode {EditMode,DeleteMode,DefulatMode,CheckMode,NonCheckMode,MenuNameMode};
        
        public frmSMSConfirmationProcess(string MName)
        {
            InitializeComponent();
            MenuName = MName;
            this.Text = MenuName;
            if (MenuName == MenuNameList.SMS_Trade_Confirmation)
            {

            }
            else if (MenuName == MenuNameList.SMS_Money_Transaction)
            {
                CCSBAL bal = new CCSBAL();
                bal.CCS_PopulateTemp_ForSMS_MoneyTransaction();
            }
            else if (MenuName == MenuNameList.Email_Trade_Confirmation)
            {
                CCSBAL bal = new CCSBAL();
                bal.CCS_PopulateTemp_EmailTradeConfirmation();
            }
            else if (MenuName == MenuNameList.Email_Money_Transaction)
            {
                CCSBAL bal = new CCSBAL();
                bal.CCS_PopulateTemp_ForEmail_MoneyTransaction();
            }
            
        }

        private void FormModeExecution(FormMode md)
        {
            switch (md)
            {
                case FormMode.DefulatMode:
                    btnEdit.Enabled = false;
                    btnCheck.Enabled = false;
                    break;
                case FormMode.DeleteMode:
                    btnEdit.Enabled = true;
                    btnEdit.Text = "Delete";
                    break;
                case FormMode.EditMode:
                    btnEdit.Enabled = true;
                    btnEdit.Text = "Edit";
                    break;
                case FormMode.CheckMode:
                    btnCheck.Enabled = true;
                    break;
                case FormMode.NonCheckMode:
                    btnCheck.Enabled = false;
                    break;
                case FormMode.MenuNameMode:
                    if (MenuName == MenuNameList.SMS_Trade_Confirmation)
                    {
                        FormModeExecution(FormMode.CheckMode);
                        btnSmsConfirmation.Enabled = true;
                        btnSmsConfirmation.Text = "Send Confirmation SMS";
                    }
                    else if (MenuName == MenuNameList.SMS_Money_Transaction)
                    {
                        FormModeExecution(FormMode.NonCheckMode);
                        btnSmsConfirmation.Enabled = true;
                        btnSmsConfirmation.Text = "Send SMS";
                        btn_SendEmail.Enabled = false;
                        btn_SendEmail.Text = "Send Email";   
                    }
                    else if (MenuName == MenuNameList.Email_Trade_Confirmation)
                    {
                        FormModeExecution(FormMode.NonCheckMode);
                        btnSmsConfirmation.Text = "Send SMS";
                        btnSmsConfirmation.Enabled = false;
                        btn_SendEmail.Enabled = true;
                        btn_SendEmail.Text = "Send Email";                        
                    }
                    else if (MenuName == MenuNameList.Email_Money_Transaction)
                    {
                        FormModeExecution(FormMode.NonCheckMode);
                        btnSmsConfirmation.Text = "Send SMS";
                        btnSmsConfirmation.Enabled = false;
                        btn_SendEmail.Enabled = true;
                        btn_SendEmail.Text = "Send Email";
                    }
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSMSConfirmationProcess_Load(object sender, EventArgs e)
        {
            try
            {                
                LoadDataIntoGrid();
                label13.Text ="Total Records :"+ dtgTradeFile.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void LoadDataIntoGrid()
        {
            try
            {
                DataTable datatable=new DataTable();
                if (MenuNameList.SMS_Trade_Confirmation == MenuName)
                {
                    PayInTradeBAL tradeFileBal = new PayInTradeBAL();
                    datatable = tradeFileBal.GetTradedataByWorkstation();
                    dtgTradeFile.DataSource = datatable;
                    dtgTradeFile.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dtgTradeFile.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dtgTradeFile.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dtgTradeFile.Columns[5].DefaultCellStyle.Format = "N";
                    FormModeExecution(FormMode.DefulatMode);
                    FormModeExecution(FormMode.MenuNameMode);
                }
                else if (MenuNameList.SMS_Money_Transaction == MenuName)
                {
                    CCSBAL bal = new CCSBAL();
                    datatable = bal.CCS_GetTemp_MoneyTransaction_ForSMS_ForGrid();
                    dtgTradeFile.DataSource = datatable;
                    dtgTradeFile.Columns["ID"].Visible = false;
                    FormModeExecution(FormMode.DefulatMode);
                    FormModeExecution(FormMode.MenuNameMode);
                }
                else if (MenuNameList.Email_Money_Transaction == MenuName)
                {
                    CCSBAL bal = new CCSBAL();
                    datatable = bal.CCS_GetTemp_MoneyTransaction_ForEmail_ForGrid();
                    dtgTradeFile.DataSource = datatable;
                    dtgTradeFile.Columns["ID"].Visible = false;
                    FormModeExecution(FormMode.DefulatMode);
                    FormModeExecution(FormMode.MenuNameMode);
                }
                else if (MenuNameList.Email_Trade_Confirmation == MenuName)
                {
                    CCSBAL bal = new CCSBAL();
                    datatable = bal.CCS_GetTemp_EmailTradeConfirmation_ForGrid();
                    dtgTradeFile.DataSource = datatable;
                    FormModeExecution(FormMode.DefulatMode);
                    FormModeExecution(FormMode.MenuNameMode);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ddlWorkStation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDataIntoGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            ValidateBOID();
            ValidateCustCode();
            ValidateCustCodeBOID();
            ValidateCompany();
            ValdateISIN();
            ValidateCompanyCategory();
            ValidateGroupMisMatch();
            if (lbCustCodeError.Items.Count == 0 && lbBOError.Items.Count == 0 && lbCodeBOError.Items.Count == 0 && lbCompShortCodeError.Items.Count == 0 && lbISINError.Items.Count == 0 && lbCompanyCatError.Items.Count == 0)
            {
                this.Height=367;
                btnSmsConfirmation.Enabled = true;
                btnEdit.Enabled = true;
            }
            else
            {

                Height = 482;
            }
        }

        private void ValidateGroupMisMatch()
        {
            try
            {
                TradeBAL tradeBal = new TradeBAL();
                DataTable groupDataTable = new DataTable();
                groupDataTable = tradeBal.ValidateGroupMisMatch();
                if (groupDataTable.Rows.Count > 0)
                {
                    dtgGroupMismatch.DataSource = groupDataTable;
                    dtgGroupMismatch.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                }
                else
                {

                    dtgGroupMismatch.Columns.Clear();
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show("Group Mismatch Error." + exc.Message);
            }
        }

        private void ValidateCompanyCategory()
        {
            try
            {
                TradeBAL tradeBal = new TradeBAL();
                DataTable ctegoryDataTable = new DataTable();
                ctegoryDataTable = tradeBal.ValidateCompanyCategory();
                if (ctegoryDataTable.Rows.Count > 0)
                {
                    lbCompanyCatError.Items.Clear();
                    for (int i = 0; i < ctegoryDataTable.Rows.Count; i++)
                    {
                        lbCompanyCatError.Items.Add(ctegoryDataTable.Rows[i]["InstrumentCategory"]);

                    }
                }
                else
                {
                    lbCompanyCatError.Items.Clear();
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show("Company Validation Error. " + exc.Message);
            }
        }
        private void ValidateCustCodeBOID()
        {
            try
            {
                TradeBAL tradeBal = new TradeBAL();
                DataTable codeBODataTable = new DataTable();
                codeBODataTable = tradeBal.ValidateCustCodeBOID();
                lbCodeBOError.Items.Clear();
                if (codeBODataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < codeBODataTable.Rows.Count; i++)
                    {
                        lbCodeBOError.Items.Add(codeBODataTable.Rows[i]["Cust_Code_BO"]);
                    }
                }
                else
                {
                    lbCodeBOError.Items.Clear();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Client Code & BO Id Mismatch Error." + exc.Message);
            }
        }

        private void ValdateISIN()
        {
            try
            {
                TradeBAL tradeBal = new TradeBAL();
                DataTable isinDataTable = new DataTable();
                isinDataTable = tradeBal.ValidateISIN();
                if (isinDataTable.Rows.Count > 0)
                {
                    lbISINError.Items.Clear();
                    for (int i = 0; i < isinDataTable.Rows.Count; i++)
                    {
                        lbISINError.Items.Add(isinDataTable.Rows[i]["ISIN"]);

                    }
                }
                else
                {
                    lbISINError.Items.Clear();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("ISIN Validation Error. " + exc.Message);
            }
        }

        private void ValidateCustCode()
        {
            try
            {
                TradeBAL tradeBal = new TradeBAL();
                DataTable custCodeDataTable = new DataTable();
                custCodeDataTable = tradeBal.ValidateCustCode();
                if (custCodeDataTable.Rows.Count > 0)
                {
                    lbCustCodeError.Items.Clear();
                    for (int i = 0; i < custCodeDataTable.Rows.Count; i++)
                    {
                        lbCustCodeError.Items.Add(custCodeDataTable.Rows[i]["Customer"]);

                    }
                }
                else
                {
                    lbCustCodeError.Items.Clear();

                }
            }
            catch (Exception exc)
            {

                MessageBox.Show("Customer Code Validation Error. " + exc.Message);
            }
        }

        private void ValidateCompany()
        {
            try
            {
                TradeBAL tradeBal = new TradeBAL();
                DataTable companyDataTable = new DataTable();
                companyDataTable = tradeBal.ValidateCompany();
                if (companyDataTable.Rows.Count > 0)
                {
                    lbCompShortCodeError.Items.Clear();
                    for (int i = 0; i < companyDataTable.Rows.Count; i++)
                    {
                        lbCompShortCodeError.Items.Add(companyDataTable.Rows[i]["InstrumentCode"]);

                    }
                }
                else
                {
                    lbCompShortCodeError.Items.Clear();
                }

            }

            catch (Exception exc)
            {

                MessageBox.Show("Company Validation Error." + exc.Message);
            }

        }

        private void ValidateBOID()
        {
            try
            {
                TradeBAL tradeBal = new TradeBAL();
                DataTable boDataTable = new DataTable();
                boDataTable = tradeBal.ValidateBOID();
                if (boDataTable.Rows.Count > 0)
                {
                    lbBOError.Items.Clear();
                    for (int i = 0; i < boDataTable.Rows.Count; i++)
                    {
                        lbBOError.Items.Add(boDataTable.Rows[i]["BOID"]);
                    }
                }
                else
                {
                    lbBOError.Items.Clear();
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show("BO ID Validation Error. " + exc.Message);
            }

        }

        private void btnSmsConfirmation_Click(object sender, EventArgs e)
        {
            try
            {
                if (MenuName == MenuNameList.SMS_Trade_Confirmation)
                {
                    PayInTradeBAL payInTradeBal = new PayInTradeBAL();
                    payInTradeBal.ProcessSmsConf();
                    MessageBox.Show("SMS Confirmation Process done successfully.", "Success Message", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Close();
                }
                else if (MenuName == MenuNameList.SMS_Money_Transaction)
                {
                    CCSBAL bal = new CCSBAL();
                    this.Cursor = Cursors.WaitCursor;
                    bal.CCS_MoneyTransConfirmationSMS_Sync();                    
                    MessageBox.Show("SMS Process done successfully.", "Success Message", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;
                    LoadDataIntoGrid();
                    //this.Close();
                }
                
            }
            catch (Exception exception)
            {
                MessageBox.Show("Fail to process Sms Confirmation. Because: " + exception.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                if (dtgTradeFile.Rows.Count <= 0)
                    return;

                int rowIndex = dtgTradeFile.SelectedRows[0].Index;
                if (rowIndex < 0)
                    return;
                SMSDataEdit smsDataEdit = new SMSDataEdit(dtgTradeFile.Rows[rowIndex].Cells[0].Value.ToString());
                smsDataEdit.ShowDialog();
                LoadDataIntoGrid();
            }
            else if (btnEdit.Text == "Delete")
            {
                if (dtgTradeFile.Rows.Count <= 0)
                    return;

                int rowIndex = dtgTradeFile.SelectedRows[0].Index;
                if (rowIndex < 0)
                    return;

                CCSBAL bal = new CCSBAL();
                int Id = dtgTradeFile.Rows[rowIndex].Cells["ID"].Value==DBNull.Value?0:Convert.ToInt32(dtgTradeFile.Rows[rowIndex].Cells["ID"].Value.ToString());
                if (Id > 0)
                    bal.CCS_DeleteFromTemp_MoneyTransaction(Id);
                LoadDataIntoGrid();
            }
        }

        private void dtgTradeFile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MenuNameList.SMS_Trade_Confirmation == MenuName)
            {
                FormModeExecution(FormMode.EditMode);
            }
            else if (MenuNameList.SMS_Money_Transaction == MenuName)
            {
                FormModeExecution(FormMode.DeleteMode);
            }
        }

        private void dtgTradeFile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (MenuName == MenuNameList.SMS_Money_Transaction)
                {
                    if (dtgTradeFile.Rows.Count <= 0)
                        return;
                    ((DataGridView)sender).BeginEdit(false);
                    int rowIndex = e.RowIndex; ;
                    int columnIndex = e.ColumnIndex;

                    if (rowIndex < 0)
                        return;
                    if (columnIndex < 0)
                        return;
                    if (columnIndex == 0)
                    {
                        
                        CCSBAL bal = new CCSBAL();
                        DataGridViewRow selectedRow = ((DataGridView)sender).SelectedRows[0];
                        int Id = selectedRow.Cells["ID"].Value == DBNull.Value ? 0 : Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());
                        bool Selection = selectedRow.Cells["IsSelected"].EditedFormattedValue == DBNull.Value ? false : Convert.ToBoolean(selectedRow.Cells["IsSelected"].EditedFormattedValue.ToString());
                        if (Id > 0)
                        {
                            bal.CCS_UpdatedSelection_MoneyTransactionTemp(Id, Selection);
                            //dtgTradeFile.Rows[rowIndex].Cells["IsSelected"].Value = Selection;                       
                        }
                        ((DataGridView)sender).EndEdit();
                    }
                    //LoadDataIntoGrid();
                }
                else if (MenuName == MenuNameList.Email_Money_Transaction)
                {
                    if (dtgTradeFile.Rows.Count <= 0)
                        return;
                    ((DataGridView)sender).BeginEdit(false);
                    int rowIndex = e.RowIndex; ;
                    int columnIndex = e.ColumnIndex;

                    if (rowIndex < 0)
                        return;
                    if (columnIndex < 0)
                        return;
                    if (columnIndex == 0)
                    {

                        CCSBAL bal = new CCSBAL();
                        DataGridViewRow selectedRow = ((DataGridView)sender).SelectedRows[0];
                        int Id = selectedRow.Cells["ID"].Value == DBNull.Value ? 0 : Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());
                        bool Selection = selectedRow.Cells["IsSelected"].EditedFormattedValue == DBNull.Value ? false : Convert.ToBoolean(selectedRow.Cells["IsSelected"].EditedFormattedValue.ToString());
                        if (Id > 0)
                        {
                            bal.CCS_UpdatedSelection_MoneyTransactionTemp(Id, Selection);
                            //dtgTradeFile.Rows[rowIndex].Cells["IsSelected"].Value = Selection;                       
                        }
                        ((DataGridView)sender).EndEdit();
                    }
                    //LoadDataIntoGrid();
                }
                else if (MenuName == MenuNameList.Email_Trade_Confirmation)
                {
                    if (dtgTradeFile.Rows.Count <= 0)
                        return;
                    ((DataGridView)sender).BeginEdit(false);
                    int rowIndex = e.RowIndex; ;
                    int columnIndex = e.ColumnIndex;

                    if (rowIndex < 0)
                        return;
                    if (columnIndex < 0)
                        return;
                    if (columnIndex == 0)
                    {

                        CCSBAL bal = new CCSBAL();
                        DataGridViewRow selectedRow = ((DataGridView)sender).SelectedRows[0];
                        string Code = selectedRow.Cells["Cust_Code"].Value == DBNull.Value ? string.Empty : selectedRow.Cells["Cust_Code"].Value.ToString();
                        bool Selection = selectedRow.Cells["IsSelected"].EditedFormattedValue == DBNull.Value ? false : Convert.ToBoolean(selectedRow.Cells["IsSelected"].EditedFormattedValue.ToString());
                        if (Code !=string.Empty)
                        {
                            bal.CCS_Update_EmailTradeConfirmation(Code, Selection);
                            //dtgTradeFile.Rows[rowIndex].Cells["IsSelected"].Value = Selection;                       
                        }
                        ((DataGridView)sender).EndEdit();
                    }
                    //LoadDataIntoGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ((DataGridView)sender).EndEdit();
            }
        }

        private void btn_SendEmail_Click(object sender, EventArgs e)
        {
            if (MenuName == MenuNameList.Email_Money_Transaction)
            {
                try
                {
                    EmailClient emc = new EmailClient();
                    Thread thrd = new Thread(WaitWindow_Thread);
                    isProgressed = true;
                    thrd.Start();
                    emc.SetMessages_MoneyTrans();
                    string[] result = emc.Send_Message_MoneyTrans();
                    isProgressed = false;
                    MessageBox.Show("Email Successfully Send - " + result[0] + " And Fail - " + result[1] + " ", "Success Message", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;
                    LoadDataIntoGrid();

                    //this.Close();
                }
                catch (Exception ex) { isProgressed = false; MessageBox.Show(ex.Message); }
            }
            else if (MenuName == MenuNameList.Email_Trade_Confirmation)
            {
               try
               {
                EmailClient emc = new EmailClient();
                Thread thrd = new Thread(WaitWindow_Thread);
                isProgressed = true;
                thrd.Start();
                emc.SetMessages_TradeConfirmation();
                string[] result = emc.Send_Message_TradeConfirmation();
                isProgressed = false;
                MessageBox.Show("Email Successfully Send - " + result[0] + " And Fail - " + result[1] + " ", "Success Message", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
                LoadDataIntoGrid();
                //this.Close();
                }
               catch (Exception ex) { isProgressed = false; MessageBox.Show(ex.Message); }
            }
        }
        private void WaitWindow_Thread()
        {
            WaitWindow waitWindow = new WaitWindow();
            waitWindow.Show();
            while (isProgressed)
            {
                waitWindow.Refresh();
            }
            waitWindow.Close();
        }
      
    }
}
