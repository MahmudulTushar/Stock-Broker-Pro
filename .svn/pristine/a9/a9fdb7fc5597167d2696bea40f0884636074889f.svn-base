using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using DataAccessLayer;

namespace StockbrokerProNewArch
{
    public partial class Dp29FileUploadSetting : Form
    {
        public Dp29FileUploadSetting()
        {
            InitializeComponent();
        }

        DP29File_DataMatchBAL DP29Bal = new DP29File_DataMatchBAL();

        private void Dp29FileUploadSetting_Load(object sender, EventArgs e)
        {
                var Isexist = new DbConnection().IsTableExist("SBP_CDBLtextFileMapping");
                if (Isexist)
                {
                    dgvLoadMapping.DataSource = DP29Bal.MappingTablespecificdata();

                    var allColumn = DP29Bal.getMappingtableCDBLColumnName("0");
                    if (allColumn != null)
                    {
                        cboDp29Column.Items.Clear();
                        cboDp29Column.Items.AddRange(allColumn);
                    }



                    var AllTableName = DP29Bal.GetMappingTableColumnGroupbyValue();
                    cboMasterTableName.Items.Clear();
                    cboMasterTableName.Items.AddRange(AllTableName);



                    //var AllTableName = DP29Bal.getAllTableName();
                    //cboMasterTableName.Items.Clear();
                    //cboMasterTableName.Items.AddRange(AllTableName);

                }

        

        }




        private void cboMasterTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedValue = cboMasterTableName.Text;
            if (SelectedValue != "")
            {
                var selectedColumnName = DP29Bal.getSelectColumnName(SelectedValue);
                cboMastercolumnName.Items.AddRange(selectedColumnName);
            }
       
        }

        private void ckbUpdateExisting_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbUpdateExisting.Checked)
            {
                var allColumn = DP29Bal.getMappingtableCDBLColumnName("1");
                if (allColumn != null)
                {
                    cboDp29Column.Items.Clear();
                    cboDp29Column.Items.AddRange(allColumn);
                }
            }
            else
            {

                var allColumn = DP29Bal.getMappingtableCDBLColumnName("0");
                if (allColumn != null)
                {
                    cboDp29Column.Items.Clear();
                    cboDp29Column.Items.AddRange(allColumn);
                }

            }

        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string CDBLColmnName = cboDp29Column.Text;
            string masterTableName = cboMasterTableName.Text;
            string MasterTableColumnName = cboMastercolumnName.Text;

            if (CDBLColmnName == "select One" || masterTableName == "" || MasterTableColumnName == "")
            {
                MessageBox.Show("Please Select dropdown item");
            }
            else 
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Update " + CDBLColmnName + " Column ", "Account Update", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string Query = "update  SBP_CDBLtextFileMapping set TargetColumnName='" + MasterTableColumnName + "',TargetTableName='" + masterTableName + "',isTableCreated=1,ColumnType='text',FormID=1   where CDBLFileColumnName='" + CDBLColmnName + "';";
                    DP29Bal.UpdateCDBLFileMappingTable(Query);
                 
                    cboDp29Column.Text = "";
                    cboMasterTableName.Text = "";
                    cboMastercolumnName.Text = "";
                    dgvLoadMapping.DataSource = DP29Bal.MappingTablespecificdata();

                    var allColumn = DP29Bal.getMappingtableCDBLColumnName("0");
                    if (allColumn != null)
                    {
                        cboDp29Column.Items.Clear();
                        cboDp29Column.Items.AddRange(allColumn);
                    }
                    MessageBox.Show("Update Complete");


                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }   
            }  
        }





        private void cboDp29Column_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CDBLColmnName = cboDp29Column.Text;
            string query = "select TargetColumnName,TargetTableName from SBP_CDBLtextFileMapping where CDBLFileColumnName='" + CDBLColmnName + "'";
            var data = DP29Bal.ReportDP29MisMatchTableQuery(query);
            if (data != null)
            {
                cboMasterTableName.Text = data.Rows[0][0].ToString();
                cboMastercolumnName.Text = data.Rows[0][1].ToString();
            }
        }




        private void btnSchemabrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Please Select DP29 Schema File";
            fDialog.Filter = "DP29|*.txt";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                txtSchemabrowse.Text = fDialog.FileName;
                btnUpload.Enabled = true;
            }
        }





        private void btnUpload_Click(object sender, EventArgs e)
        {
            string FileExtention = (txtSchemabrowse.Text).Split('.')[1].ToLower();
            if (FileExtention == "txt" && txtSchemabrowse.Text.Contains("DP29"))
            {

                var Isexist = new DbConnection().IsTableExist("SBP_CDBLtextFileMapping");
                if (!Isexist)
                {
                    DP29Bal.SBP_CDBLtextFileMappingTableCreate();
                }


                //Read Data From Database Asynchronous using Thread

                DataTable databaseDATA = DP29Bal.getCDBLTextfileMapping();


                //Data Read From CDBL File 
                string FileLocation = txtSchemabrowse.Text;
                StreamReader reader = new StreamReader(FileLocation);
                List<string> CDBLFileData = new List<string>();
                while (reader.Peek() > 0)
                {
                    var line = reader.ReadLine();
                    if (line.Contains("="))
                    {
                        var FData = line.Split('=')[1];
                        string ModifyData = Regex.Replace(FData, @"[^0-9a-zA-Z]+", "");
                        CDBLFileData.Add(ModifyData);
                    }
                }



               


                //Match CDBL & mapping Table
                if (CDBLFileData.ToArray().Length > 0)
                {
                    for (int i = 0; i < CDBLFileData.Count; i++)
                    {
                        string CDBL = CDBLFileData[i].ToString().ToLower();
                        string Database = "";
                        if (databaseDATA.Rows.Count <= i)
                        {
                            Database = "";
                        }
                        else
                        {
                            Database = databaseDATA.Rows[i][0].ToString().ToLower();
                        }

                        if (Database != CDBL)
                        {
                            if (Database == "")
                            {
                                string InsertQuery = "INSERT INTO SBP_CDBLtextFileMapping(CDBLFileColumnName,TargetColumnName,TargetTableName,isTableCreated,ColumnType,FormID) VALUES('" + CDBL + "','','',0,'text',1)";
                                DP29Bal.UpdateCDBLFileMappingTable(InsertQuery);
                                Database = "";
                            }
                            else
                            {
                                string UpdateQuery = "update SBP_CDBLtextFileMapping set CDBLFileColumnName='" + CDBL + "', TargetColumnName='',TargetTableName='',isTableCreated=0,ColumnType='text',FormID=1   where CDBLFileColumnName='" + Database + "'";
                                DP29Bal.UpdateCDBLFileMappingTable(UpdateQuery);
                                Database = "";
                            }
                        }
                    }


                    if (databaseDATA.Rows.Count > CDBLFileData.ToArray().Length)
                    {
                        for (int i = CDBLFileData.ToArray().Length; i < databaseDATA.Rows.Count; i++)
                        {
                            string rowValue = databaseDATA.Rows[i][0].ToString().ToLower();
                            string query = "delete from SBP_CDBLtextFileMapping where CDBLFileColumnName='" + rowValue + "'";
                            DP29Bal.UpdateCDBLFileMappingTable(query);
                        }
                    }
                }

                //load combo box
                var allColumn = DP29Bal.getMappingtableCDBLColumnName("0");
                if (allColumn != null)
                {
                    cboDp29Column.Items.Clear();
                    cboDp29Column.Items.AddRange(allColumn);
                }
                dgvLoadMapping.DataSource = DP29Bal.MappingTablespecificdata();
                MessageBox.Show("Update Complete");
            }

            else
            {
                MessageBox.Show("Your selected file is not DP29 file");
                txtSchemabrowse.Text = "Please Select DP29_V6 File";
            }
        }



        private void cboMastercolumnName_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }



        private void ckbotherTable_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbotherTable.Checked)
            {
                var AllTableName = DP29Bal.getAllTableName();
                cboMasterTableName.Items.Clear();
                cboMasterTableName.Items.AddRange(AllTableName);
            }
            else
            {
                var AllTableName = DP29Bal.GetMappingTableColumnGroupbyValue();
                cboMasterTableName.Items.Clear();
                cboMasterTableName.Items.AddRange(AllTableName);
            }
        }



        //load previous set Value
        public void defalutLoadDP29FileMapping()
        {
            string Query = @"SET IDENTITY_INSERT [dbo].[SBP_CDBLtextFileMapping] ON
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (1, N'BOIdentificationNumber', N'BO_ID', N'SBP_Customers', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (2, N'BOType', N'BO_Type_ID', N'SBP_Customers', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (3, N'BOCategory', N'BO_Category_ID', N'SBP_Customers', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (4, N'FullName', N'Cust_Name', N'SBP_Cust_Personal_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (5, N'ShortName', N'Last_Name', N'SBP_Cust_Personal_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (6, N'Address', N'Address1', N'SBP_Cust_Contact_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (7, N'City', N'City_Name', N'SBP_Cust_Contact_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (8, N'State', N'Division_Name', N'SBP_Cust_Contact_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (9, N'Country', N'Country_Name', N'SBP_Cust_Contact_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (10, N'PurposeCode', N'Post_Code', N'SBP_Cust_Contact_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (11, N'Residency', N'Recidency', N'SBP_Cust_Additional_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (12, N'TelphoneNumber', N'Phone', N'SBP_Cust_Contact_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (13, N'Fax', N'Fax', N'SBP_Cust_Contact_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (14, N'Email', N'Email', N'SBP_Cust_Contact_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (15, N'InternalReferenceNumber', N'Internal_Ref_No', N'SBP_Cust_Additional_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (16, N'SetupDate', N'BO_Open_Date', N'SBP_Customers', 1, N'date', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (17, N'BOStatus', N'BO_Status_ID', N'SBP_Customers', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (18, N'ClosureDate', N'BO_Close_Date', N'SBP_Customers', 1, N'date', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (19, N'BOFatherHusband', N'Father_Name', N'SBP_Cust_Personal_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (20, N'BOMother', N'Mother_Name', N'SBP_Cust_Personal_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (21, N'BankName', N'Bank_Name', N'SBP_Cust_Bank_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (22, N'BranchName', N'Branch_Name', N'SBP_Cust_Bank_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (23, N'AccountNumber', N'Account_No', N'SBP_Cust_Bank_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (24, N'BankRoutineNumber', N'Routing_No', N'SBP_Cust_Bank_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (25, N'BankIdentificationCode', N'Bank_ID', N'SBP_Cust_Bank_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (26, N'InternationalBankAccountNumber', N'IBAN', N'SBP_Cust_Bank_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (27, N'BankSwiftCode', N'SWIFT_Code', N'SBP_Cust_Bank_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (28, N'SuspenseFlag', N'Suspense_Flag', N'SBP_Cust_Additional_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (29, N'BoSuspeneddate', N'Bo_Suspened_Date', N'SBP_Cust_Additional_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (30, N'SuspenseReasonCode', N'Suspense_Reason_Code', N'SBP_Cust_Additional_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (31, N'SecondHolderName', N'Joint_Name', N'SBP_Joint_holder', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (32, N'Occupation', N'Occupation', N'SBP_Cust_Personal_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (33, N'DateofBirth', N'DOB', N'SBP_Cust_Personal_Info', 1, N'date', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (34, N'Gender', N'Gender', N'SBP_Cust_Personal_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (35, N'BONationality', N'Nationality', N'SBP_Cust_Additional_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (36, N'TaxIDNumber', N'TIN', N'SBP_Cust_Bank_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (37, N'OriginofBO', N'Origin_of_BO', N'SBP_Cust_Additional_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (38, N'FirstHolderNationalID', N'National_ID', N'SBP_Cust_Personal_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (39, N'SecondHolderNationalID', N'SecondHolderNID', N'SBP_Cust_Personal_Info', 1, N'text', 1)
                            INSERT [dbo].[SBP_CDBLtextFileMapping] ([id], [CDBLFileColumnName], [TargetColumnName], [TargetTableName], [isTableCreated], [ColumnType], [FormID]) VALUES (40, N'ThirdHolderNationalID', N'ThirdHolderNID', N'SBP_Cust_Personal_Info', 1, N'text', 1)
                            SET IDENTITY_INSERT [dbo].[SBP_CDBLtextFileMapping] OFF";

           var con= new DbConnection();
           con.ConnectDatabase();
           con.ExecuteNonQuery("truncate table SBP_CDBLtextFileMapping");
            con.ExecuteNonQuery(Query);
        
        }





        private void btnLoadDefault_Click(object sender, EventArgs e)
        {
            defalutLoadDP29FileMapping();
            dgvLoadMapping.DataSource = DP29Bal.MappingTablespecificdata();
        }





    }
}
