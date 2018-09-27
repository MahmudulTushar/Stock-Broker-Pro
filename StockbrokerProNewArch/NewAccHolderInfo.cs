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
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class NewAccHolderInfo : Form
    {
        public NewAccHolderInfo()
        {
            InitializeComponent();
        }

        private void btnStartImport_Click(object sender, EventArgs e)
        {
            UploadProcess();
        }

        private void btnFileLocationBrowser_Click(object sender, EventArgs e)
        {
            if (ofdFileOpen.ShowDialog() == DialogResult.OK)
                txtFileLocation.Text = ofdFileOpen.FileName;
        }

        private void NewAccHolderInfo_Load(object sender, EventArgs e)
        {

            Reset();
        }

        private void UploadProcess()
        {
            ProcessingMessage("Processing CDBL File...");
            if (txtFileLocation.Text.Length.Equals(0))
            {
                err.SetError(txtFileLocation, "CDBL File location is a required field.");
                return;
            }
            else
            {
                err.SetError(txtFileLocation, "");
            }

            CustomerCollectionBO customerCollectionBo = new CustomerCollectionBO();
            try
            {
                customerCollectionBo = ProcessTextFile(txtFileLocation.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Fail to process txt file. No data saved. Because : " + exception.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset();
                return;
            }
            ProcessingMessage("Importing data into database....");
            CustomerBAL customerBal = new CustomerBAL();

            progress.Maximum = customerCollectionBo.Count + 1;
            foreach (CustomerBO customerBo in customerCollectionBo)
            {
                try
                {
                    customerBal.ProcessDatabase(customerBo);
                }
                catch (Exception exception)
                {
                    AddErrorInGrid(customerBo.CustomerCode.ToString(), exception.Message);
                }
                progress.PerformStep();
            }
            //ProcessingMessage("Bank Branch Updating.....");
            //customerBal.Update_BankID_BranchID_In_SBPCustBankInfo();
            ProcessingMessage("Data imported successfully....");
            MessageBox.Show("New Customer Information Imported Successfully.", "Import Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Reset();
        }

        private void ModificationProcess()
        {
            ProcessingMessage("Processing CDBL File...");
            if (txtFileLocation.Text.Length.Equals(0))
            {
                err.SetError(txtFileLocation, "CDBL File location is a required field.");
                return;
            }
            else
            {
                err.SetError(txtFileLocation, "");
            }

            CustomerCollectionBO customerCollectionBo = new CustomerCollectionBO();
            try
            {
                customerCollectionBo = ProcessTextFile(txtFileLocation.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Fail to process txt file. No data saved. Because : " + exception.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset();
                return;
            }
            ProcessingMessage("Updating data into database....");
            CustomerBAL customerBal = new CustomerBAL();

            progress.Maximum = customerCollectionBo.Count + 1;
            foreach (CustomerBO customerBo in customerCollectionBo)
            {
                try
                {
                    customerBal.ProcessDatabase(customerBo);
                }
                catch (Exception exception)
                {
                    AddErrorInGrid(customerBo.CustomerCode.ToString(), exception.Message);
                }
                progress.PerformStep();
            }
            ProcessingMessage("Data updated successfully....");
            MessageBox.Show("Customer Information Updated Successfully.", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Reset();
        }

        private CustomerCollectionBO ProcessTextFile(string filePath)
        {
            const char proChar = '~';
            CustomerCollectionBO customerCollectionBo = new CustomerCollectionBO();
            StreamReader streamReader = new StreamReader(filePath);
            CustomerBAL customerBal = new CustomerBAL();
            DataTable dtBankBranchId = new DataTable();

            while (streamReader.Peek() >= 0)
            {
                string[] values = streamReader.ReadLine().Split(proChar);

                CustomerBO customerBo = new CustomerBO();
                CommonBAL commonBAL = new CommonBAL();
                customerBo.BoId = values[0].Substring(8, 8);               

                if (!values[1].Trim().Length.Equals(0))
                    customerBo.BoTypeID = commonBAL.GetIdByName(values[1], "BO_Type_ID", "BO_Type", "SBP_BO_Type");
                if (!values[2].Trim().Length.Equals(0))
                    customerBo.BoCategoryID = commonBAL.GetIdByName(values[2], "BO_Category_ID", "BO_Category",
                                                                    "SBP_BO_Category");
                customerBo.CustomerCode = values[3];
                customerBo.CustomerName = values[4].Replace("'", "''");
                customerBo.SecoundHolder = values[5].Replace("'", "''");

                customerBo.Sex = values[8];
                if (!values[9].Trim().Length.Equals(0))
                    customerBo.BirthDate = Convert.ToDateTime(values[9]);
                customerBo.FatherName = values[11].Replace("'", "''");
                customerBo.MotherName = values[12].Replace("'", "''");
                customerBo.Occupation = values[13].Replace("'", "''");
                customerBo.Residence = values[14].Replace("'", "''");
                customerBo.Nationality = values[15].Replace("'", "''");
                customerBo.Address1 = values[16].Replace("'", "''");
                customerBo.Address2 = values[17].Replace("'", "''");
                customerBo.Address3 = values[18].Replace("'", "''");
                customerBo.City = values[19].Replace("'", "''");
                customerBo.District = values[20].Replace("'", "''");
                customerBo.Country = values[21].Replace("'", "''");
                customerBo.PostalCode = values[22].Replace("'", "''");
                customerBo.Phone = values[23].Replace("'", "''");
                customerBo.Email = values[24].Replace("'", "''");
                customerBo.Fax = values[25].Replace("'", "''");
                if (!values[26].Trim().Length.Equals(0))
                    customerBo.StatementCycleID = commonBAL.GetIdByName(values[26], "Statement_Cycle_ID",
                                                                        "Statement_Cycle", "SBP_Statement_Cycle");
                customerBo.PassportNo = values[30];
                if (!values[31].Trim().Length.Equals(0))
                    customerBo.PassportIssueDate = Convert.ToDateTime(values[31]);
                if (!values[32].Trim().Length.Equals(0))
                    customerBo.PassportExpiryDate = Convert.ToDateTime(values[32]);
                customerBo.PassportIssuePlace = values[33].Replace("'", "''");
                //customerBo.BankName = values[34].Replace("'", "''");
                // customerBo.BranchName = values[35].Replace("'","''");
                //  Bank_Name                     Branch_Name                   Routing_No
                if (values[34] != string.Empty && values[35] != string.Empty && values[42] != string.Empty)
                {
                    //                                                    Routing_No
                    dtBankBranchId = customerBal.GetBankBranchRoutingInfo(values[42]);
                    if (dtBankBranchId.Rows.Count > 0)
                    {
                        customerBo.BankId = Convert.ToInt32(dtBankBranchId.Rows[0]["Bank_ID"].ToString());
                        customerBo.BankName = dtBankBranchId.Rows[0]["Bank_Name"].ToString();

                        customerBo.BranchId = Convert.ToInt32(dtBankBranchId.Rows[0]["Branch_ID"].ToString());
                        customerBo.BranchName = dtBankBranchId.Rows[0]["Branch_Name"].ToString();
                        customerBo.Routing_No = dtBankBranchId.Rows[0]["Routing_No"].ToString();
                    }
                }
                //       Bank_Name                     Branch_Name                   Routing_No
                else if (values[34] != string.Empty && values[35] != string.Empty && values[42] == string.Empty)
                {
                    //                                                    Bank_Name   Branch_Name
                    dtBankBranchId = customerBal.GetBankBranchRoutingInfo(values[34], values[35]);
                    if (dtBankBranchId.Rows.Count > 0)
                    {
                        customerBo.BankId = Convert.ToInt32(dtBankBranchId.Rows[0]["Bank_ID"].ToString());
                        customerBo.BankName = values[34].Replace("'", "''");

                        customerBo.BranchId = Convert.ToInt32(dtBankBranchId.Rows[0]["Branch_ID"].ToString());
                        customerBo.BranchName = values[35].Replace("'", "''");
                        customerBo.Routing_No = dtBankBranchId.Rows[0]["Routing_No"].ToString();
                    }
                }

                else
                {
                    customerBo.BankId = 0;
                    customerBo.BankName = string.Empty;

                    customerBo.BranchId = 0;
                    customerBo.BranchName = string.Empty;
                    customerBo.Routing_No = string.Empty;
                }

                customerBo.AccountNo = values[36].Replace("'", "''");
                if (!values[37].Trim().Length.Equals(0))
                    if (values[37] == "YES")
                        customerBo.Edc = 1;
                if (!values[38].Trim().Length.Equals(0))
                    if (values[38] == "YES")
                        customerBo.TaxExemption = 1;
                customerBo.Tin = values[39].Replace("'", "''");
                customerBo.SWIFT_Code = values[44].Replace("'", "''");
                customerBo.IBAN = values[45].Replace("'", "''");
                //customerBo.Bank_Routine_Number = values[42].Replace("'", "''");

                customerBo.firstHolder_NID = values[46];
                customerBo.secondHolder_NID = values[47];
                customerBo.thirdHolder_NID = values[48];
                customerBo.BO_Open_Date = Convert.ToDateTime(values[49].Replace("'", "''").ToString());

                customerCollectionBo.Add(customerBo);
            }
            return customerCollectionBo;
        }
        private void AddErrorInGrid(string customerCode, string errorMessage)
        {

            string[] rowString = new string[] { (dgvErrors.Rows.Count + 1).ToString(), customerCode, errorMessage };
            dgvErrors.Rows.Add(rowString);
        }
        private void ProcessingMessage(string message)
        {
            lbProText.Text = message;
            progress.PerformStep();
        }

        private void Reset()
        {
            lbProText.Text = "Ready for new import process..";
            progress.Maximum = 100;
            progress.Value = 0;
        }
    }
}
