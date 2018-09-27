using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockbrokerProNewArch
{
    public partial class frm_Import_Dp29_ProcessPromt : Form
    {
        public delegate void Dlg_UpdatedFlag(List<KeyValuePair<string, string>> columnFlag);
           
        
        public List<KeyValuePair<string, string>> columnsFlag;

        public Dlg_UpdatedFlag UpdateFlg_DlgObj;

        public bool IsCancel = false;

        public frm_Import_Dp29_ProcessPromt()
        {
            InitializeComponent();
            columnsFlag = new List<KeyValuePair<string, string>>();
            //UpdateFlg_DlgObj = null;
            InitializeDataGridView();
        }
        public void InitializeDataGridView()
        {
            frm_Import_DP29 frmImportObj = new frm_Import_DP29();

            var index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.AccNo;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.Address;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.BankName;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.BOCatg;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.BOID;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.BoStatus;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.BOTYPE;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.BranchName;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.City;
            //index = dgvColumnSelect.Rows.Add();
            //dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.ClosureDate;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.Country;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.CustCode;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.Email;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.FatherName;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.Fax;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.FullName;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.MotherName;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.Phone;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.PurposeCode;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.Residency;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.SetupDate;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.ShortName;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.State;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.Routing_No;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.Bank_Identification_Code;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.IBAN;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.SWIFT_Code;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.Suspense_Flag;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.Bo_Suspened_Date;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.Suspense_Reason_Code;            
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.Second_Holder_Name;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.Date_of_Birth;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.Gender;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.BO_Nationality;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.Tax_ID_Number;
            index = dgvColumnSelect.Rows.Add();
            dgvColumnSelect.Rows[index].Cells["columnName"].Value = frmImportObj.dgClientInfoColumnsObj.Origin_of_BO;

              




        }


        private void chk_SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgvColumnSelect.Rows)
            {
                dr.Cells["isUpdated"].Value =chk_SelectAll.Checked;
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgvColumnSelect.Rows)
            {
                columnsFlag.Add(new KeyValuePair<string, string>(Convert.ToString(dr.Cells["columnName"].Value), Convert.ToString(dr.Cells["isUpdated"].Value) ==string.Empty ? Convert.ToString("False") : Convert.ToString(dr.Cells["isUpdated"].Value)));

            }
            UpdateFlg_DlgObj(columnsFlag);
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgvColumnSelect.Rows)
            {
                dr.Cells["isUpdated"].Value = false;
            }
            chk_SelectAll.Checked = false;

            IsCancel = true;
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgvColumnSelect.Rows)
            {
                dr.Cells["isUpdated"].Value = false;
            }
            chk_SelectAll.Checked = false;
        }     
      
    }
}
