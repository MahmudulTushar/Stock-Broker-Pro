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

namespace StockbrokerProNewArch
{
    public partial class EFTCancel : Form
    {
        EFT_IssueBAL Bal = new EFT_IssueBAL();
        
        DbConnection _dbConnection;

        DataTable dtEftInfo = new DataTable();
        DataTable dtEftIssue = new DataTable();
        string serial = "";     

        

        public EFTCancel()
        {
            InitializeComponent();
            _dbConnection = new DbConnection();
        }

        private void EFTCancel_Load(object sender, EventArgs e)
        {
            //FormLoadEvent();
        }

        private void FormLoadEvent()
        {
            dtEftInfo = Bal.LoadEftFileInfo();
            dgEFTFileInfo.DataSource = dtEftInfo;
            dgEFTFileInfo.Columns["ID"].Visible = false;
            var Lowest = dtEftInfo.Rows.Cast<DataRow>().Select(c => Convert.ToDateTime(c["File_Issue_Date"]).Date).Min();
            var Max = dtEftInfo.Rows.Cast<DataRow>().Select(c => Convert.ToDateTime(c["File_Issue_Date"]).Date).Max();            
            label1.Text = "From " + Lowest.Date.ToString("yyyy-MM-dd") + " To " + DateTime.Today.Date.ToString("yyyy-MM-dd");
            
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgEFTIssue.Rows.Count > 0)
                {
                    dgEFTIssue.Rows.Clear();
                }
                string File_No = dgEFTFileInfo.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells["File_No"].Value)).First();
                LoadEftIssue(File_No);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }        
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CmbSelection.Text.Trim() == "Cancel")
            {
                PaymentInfoBAL paymentBal = new PaymentInfoBAL();
                EFT_IssueBAL Bal = new EFT_IssueBAL();

                try
                {
                    int Eft_Id = dgEFTFileInfo.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToInt32(c.Cells["ID"].Value)).First();
                    string File_no = dgEFTFileInfo.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells["File_No"].Value)).First();

                    Bal.ConnectDatabase();
                    paymentBal.SetConnection(Bal.GetConnection());
                    paymentBal.SetTransaction(Bal.GetTransaction());

                    //Bal.StartTransaction();
                    if (!paymentBal.IsLockedVoucherLockState_UI())
                    {
                        paymentBal.LockVoucherNo_UI();
                        foreach (DataGridViewRow row in dgEFTIssue.Rows)
                        {
                            if ((bool)row.Cells["Value"].Value == true)
                            {
                                serial = paymentBal.GenerateSerial_UI();
                                Bal.Insert_EFT_File_Info_And_Issue(row.Cells["File_No_ID"].Value.ToString(), row.Cells["Code"].Value.ToString(), row.Cells["Req_ID"].Value.ToString(), Eft_Id, row.Cells["Req_Type"].Value.ToString(), row.Cells["IssueID"].Value.ToString(), serial, row.Cells["Remarks"].Value.ToString());
                                paymentBal.UpdateSerialNo_UI();

                            }
                        }
                        Bal.UpdateEFTFile(Eft_Id, File_no);
                    }
                    else
                    {
                        throw new Exception("Some one processing,please wait ");
                    }
                    //Bal.Insert_EFT_File_Info_And_Issue(string.Join(",", distFile.ToArray()), cust_code.ToArray(), RequisitionId.ToArray(), Eft_Id, Requst_Type.ToArray(), List_IssueID.ToArray(), serial, List_Remarks.ToArray());
                    paymentBal.UnLockVoucherNo_UI();
                    Bal.Commit();
                    MessageBox.Show("EFT Cancel Successfully");
                    //FormLoadEvent();
                    LoadEFTFileNO(txtEFTFileNo.Text);
                    LoadEftIssue(File_no);
                    label3.Text = "Total: " + dgEFTIssue.Rows.Count;
                }
                catch (Exception ex)
                {
                    //paymentBal.UnLockVoucherNo_UI();
                    Bal.RollBack();

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Bal.CloseDatabase();

                }
            }
            else if (CmbSelection.Text.Trim() == "Delete")
            {
                if (DialogResult.Yes == MessageBox.Show("Are You sure to delete this data", "Delete EFT File", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    try
                    {
                        //ID,File_No
                        string[] IsuueID = dgEFTIssue.Rows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells["IssueID"].Value)).ToArray();
                        string[] Issue_File_No_ID = dgEFTIssue.Rows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells["File_No_ID"].Value)).Distinct().ToArray();
                        string[] Eft_File_No_ID = dgEFTFileInfo.Rows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();
                        string[] Eft_FileNO = dgEFTFileInfo.Rows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells["File_No"].Value)).ToArray();
                        string join_Issue_File_No_ID = Issue_File_No_ID.Aggregate((a, b) => a + "," + b);
                        string Join_IssueID = IsuueID.Aggregate((a, b) => a + "," + b);
                        string Join_Eft_File_No_ID = Eft_File_No_ID.Aggregate((a, b) => a + "," + b);
                        string Join_Eft_FileNO = Eft_FileNO.Aggregate((a, b) => a + "," + b);
                        Bal.Delete_EFT_FileAndIssue(Join_Eft_File_No_ID, Join_Eft_FileNO, Join_IssueID, join_Issue_File_No_ID);
                        MessageBox.Show("EFT Delete Successfully");
                        LoadEFTFileNO(txtEFTFileNo.Text);
                        if (dgEFTIssue.Rows.Count > 0)
                        {
                            dgEFTIssue.Rows.Clear();
                        }
                        label3.Text = "Total: " + dgEFTIssue.Rows.Count;
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else
            {
                MessageBox.Show("What Do you want Cancel Or delete please Select one?", "Cancel Or Delete", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            //label2.Text = "Total: " + dgEFTFileInfo.Rows.Count;
        }

        private void LoadEftIssue(string File_No)
        {
            try
            {
                dtEftIssue = Bal.LoadEftIssueInfo_ByEftFile(File_No);
                //File_No_ID,Req_ID,Req_Type,Cust_Code,Amount,Bank_Name,Branch_Name,Routing_No,Bank_Account_No,Account_Type
                if (dtEftIssue.Rows.Count > 0)
                {
                    foreach (DataRow dt in dtEftIssue.Rows)
                    {
                        string IssueID = dt["ID"].ToString();
                        string File_No_ID = dt["File_No_ID"].ToString();
                        string Req_ID = dt["Req_ID"].ToString();
                        string Req_Type = dt["Req_Type"].ToString();
                        string Code = dt["Cust_Code"].ToString();
                        string Amount = dt["Amount"].ToString();
                        string Bank_Name = dt["Bank_Name"].ToString();
                        string Branch_Name = dt["Branch_Name"].ToString();
                        string Routing_No = dt["Routing_No"].ToString();
                        string Bank_Account_No = dt["Bank_Account_No"].ToString();
                        string Account_Type = dt["Account_Type"].ToString();
                        bool value = false;
                        string Remarks = "";
                        dgEFTIssue.Rows.Add(new object[] { IssueID, value, Code,Remarks, File_No_ID, Req_ID, Req_Type, Amount, Bank_Name, Branch_Name, Routing_No, Bank_Account_No, Account_Type });
                        //label3.Text = "Total: " + dgEFTIssue.Rows.Count;
                    }
                    dgEFTIssue.Columns["IssueID"].Visible = false;
                    
                }
                else
                {
                    if (dgEFTIssue.Rows.Count > 0)
                    {
                        dgEFTIssue.Rows.Clear();
                    }
                }
                label3.Text = "Total: " + dgEFTIssue.Rows.Count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void dgEFTFileInfo_DataSourceChanged(object sender, EventArgs e)
        {
            label2.Text = "Total: " + dgEFTFileInfo.Rows.Count;
        }

        private void dgEFTIssue_DataSourceChanged(object sender, EventArgs e)
        {
            label3.Text = "Total: " + dgEFTIssue.Rows.Count;
        }

        private void dgEFTIssue_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RowCheckBoxClick();
        }
        private void RowCheckBoxClick()         
        {
            foreach (DataGridViewRow Row in dgEFTIssue.Rows)
            {
                if (((bool)(Row.Cells["Value"].Value) == true)&&Row.Cells["Value"].Value!=null)
                {
                    this.dgEFTIssue.Rows[Row.Index].Selected = true;
                    this.dgEFTIssue.Rows[Row.Index].Cells["Remarks"].ReadOnly = false;
                    Row.DefaultCellStyle.SelectionBackColor = Color.LightSlateGray;
                }
                else
                {
                    this.dgEFTIssue.Rows[Row.Index].Selected = false;
                    this.dgEFTIssue.Rows[Row.Index].Cells["Remarks"].ReadOnly = true;
                }
            }
        }
        private void SaveData()
        {
            string[] code = dgEFTIssue.Rows.Cast<DataGridViewRow>().Where(c => Convert.ToBoolean(c.Cells["Value"].Value).Equals(true))
                .Select(c => Convert.ToString(c.Cells["Code"].Value).ToString()).ToArray();
        }

        private void txtEFTFileNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    LoadEFTFileNO(txtEFTFileNo.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void LoadEFTFileNO(string FileNO)
        {
            if (dgEFTIssue.Rows.Count > 0)
            {
                dgEFTIssue.Rows.Clear();
            }
            dtEftInfo = Bal.LoadEftFileInfo(FileNO);
            dgEFTFileInfo.DataSource = dtEftInfo;
            dgEFTFileInfo.Columns["ID"].Visible = false;
        }
    }
}
