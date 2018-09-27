using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BusinessAccessLayer.BAL;
using System.Threading;
using System.Text.RegularExpressions;
using DataAccessLayer;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class frm_DP29File_DataMatch : Form
    {
        public frm_DP29File_DataMatch()
        {
            InitializeComponent();
        }

        //Develop By Md.Mahfujul Haque 01670881378


        //delegate Declare for invoke thread 
        private delegate void StatusMessageShow(int Text);
        private delegate void CheckboxColumnList(object[] data);
        private delegate void ProcessStatusshow(string Text);


        //Stop excution flag
        private bool Cencel = false;



        //load event
        private void frm_DP29File_DataMatch_Load(object sender, EventArgs e)
        {
            var Isexist = new DbConnection().IsTableExist("SBP_DP29Mismatch");
            if (Isexist)
            {
                var bal = new DP29File_DataMatchBAL();
                var MismatchStatus = bal.ReportDP29MisMatchTableQuery("select Status  from SBP_DP29Mismatch group by Status ");
                var loadData = (from DataRow cp in MismatchStatus.Rows select cp[0]).ToArray();
                cmbReport.Items.AddRange(loadData);
                cmbReport.SelectedIndex = 0;
                Thread thee = new Thread(() =>
                {
                    var allColumn = bal.getAllDP29MisMatchTableColumnNameArray();
                    this.Invoke(new CheckboxColumnList(loadclbColumnName), new object[] { allColumn });
                });
                thee.Start();
                thee.IsBackground = true;
                ChkSelectAll.Enabled = false;

                if (GlobalVariableBO._userName.ToLower() == "admin")
                {
                    btnSetting.Enabled = true;
                }
                else
                {
                    btnSetting.Enabled = false;
                }

            } 
        }






      
        public void loadclbColumnName(object[] dataItem)
        {
            List<string> ColumnName = new List<string>();

            //not show this list setting page drop down page 
            string[] removeFromList = new string[] { "ID", "Status", "CustCode", "BOIdentificationNumber", "BOType", "InternalReferenceNumber" };
            foreach (var c in dataItem)
            {
                if (!removeFromList.Contains(c.ToString()))
                {
                    ColumnName.Add(c.ToString());
                }
            }

            //Add dropdown list
            clbColumnName.Items.Clear();
            clbColumnName.Items.AddRange(ColumnName.ToArray());
            dbcSelectColumn.Items.Clear();
            dbcSelectColumn.Items.AddRange(dataItem);
            dbcSelectColumn.SelectedIndex = 0;
        }







        //-----------------------------Schema Check ------------------


        private void btnSchemabrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Please Select DP29 Schema File";
            fDialog.Filter = "DP29|*.txt";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                string txtSchemabrowseName = fDialog.FileName;
                string FileName = fDialog.SafeFileName;

                string FileExtention = txtSchemabrowseName.Split('.')[1].ToLower();
                if (FileExtention == "txt" && FileName.Contains("DP29"))
                {
                    txtSchemabrowse.Text = fDialog.FileName;
                    btncheck.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Your selected file is not DP29 file");
                    txtSchemabrowse.Text = "Please Select DP29_V6 File";
                }
            }
        }








        private void btncheck_Click(object sender, EventArgs e)
        {
            string FileExtention = (txtSchemabrowse.Text).Split('.')[1].ToLower();
            if (FileExtention == "txt" && txtSchemabrowse.Text.Contains("DP29"))
            {
                //Read Data From Database Asynchronous using Thread
                DataTable databaseDATA = null;


                Thread thread = new Thread(() =>
                {
                   databaseDATA = new DP29File_DataMatchBAL().getCDBLTextfileMapping();
                });
                thread.Start();




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





                //tread join Main Thread
                thread.Join();




                //Match CDBL & mapping Table
                int countTrue = 0;
                if (databaseDATA.Rows.Count == CDBLFileData.ToArray().Length)
                {
                    for (int i = 0; i < CDBLFileData.Count; i++)
                    {
                        string CDBL = CDBLFileData[i].ToString().ToLower();
                        string Database = databaseDATA.Rows[i][0].ToString().ToLower();

                        if (Database == CDBL)
                        {
                            countTrue += 1;
                        }
                    }
                }
               



                //Check Mismatch count 
                if (CDBLFileData.ToArray().Length == countTrue)
                {
                    btnDataFileBrowse.Enabled = true;


                    btnSchemabrowse.Enabled = false;
                    btncheck.Enabled = false;
                    txtSchemabrowse.Enabled = false;
                    txtSchemabrowse.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("CDBL Column Name Mismatch. Please Update Mapping Table");
                }



            }
            else
            {
                MessageBox.Show("Your selected file is not DP29 file");
                txtSchemabrowse.Text = "Please Select DP29_V6 File";
            }
        }


        //----------------------End btn Schema Check -----------------------








        //------------------------ btn Start Upload -------------------------

        private void btnDataFileBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Please Select DP29 data File";
            fDialog.Filter = "DP29|*.txt";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                string txtSchemabrowseName = fDialog.FileName;
                string FileName = fDialog.SafeFileName;
                //collect file Extention
                string FileExtention = FileName.Split('.')[1].ToLower();
                if (FileExtention == "txt" && FileName.Contains("DP29"))
                {
                    txtDataFileBrowse.Text = fDialog.FileName;
                    btnStartImport.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Your selected file is not DP29 file");
                    txtSchemabrowse.Text = "Please Select DP29_V6 File";
                }
            }
        }







        private void btnStartImport_Click(object sender, EventArgs e)
        {
            DP29File_DataMatchBAL DP29Bal = new DP29File_DataMatchBAL();
            string FileExtention = (txtDataFileBrowse.Text).Split('.')[1].ToLower();
            if (FileExtention == "txt" && txtDataFileBrowse.Text.Contains("DP29"))
            {
                toolStripStatusLabel.Text = "File Importing Start..";
                string FileLocation = txtDataFileBrowse.Text;

                //create or trancate DP29 Table 
                DP29Bal.CreateSBP_DP29Table();


                // Check DP29 Table is Available
                var Isexist = new DbConnection().IsTableExist("SBP_DP29");
                if (Isexist)
                {
                    //Collect DP29 table column Name
                    DataTable DP29ColumnName = DP29Bal.getAllDP29ColumnName();

                    //Count Column from CDBL File
                    StreamReader streamReader = new StreamReader(FileLocation);
                    int CDBLColumn = streamReader.ReadLine().Split('~').Length - 1;


                    int TableColumn = DP29ColumnName.Rows.Count;

                    if (CDBLColumn < TableColumn || CDBLColumn > TableColumn)
                    {
                        MessageBox.Show("CDBL file is less then DP29 Column ");
                        return;
                    }




                    //Check CDBL and DP29 Column leanth 
                    if (CDBLColumn == TableColumn)
                    {
                        List<string> ListDp29FileData = new List<string>();


                        //Collect Data From DP29 Text File Using Tread
                        Thread DataFileRead = new Thread(() =>
                        {
                            //select single column 
                            var ColumnNameArray = (from DataRow myRow in DP29ColumnName.Rows select myRow["COLUMN_NAME"]).ToArray();
                            //Array to Comma separated value
                            var Paramiter = ColumnNameArray.Select(a => a.ToString()).Aggregate((i, j) => i + "," + j);
                            ListDp29FileData = GetCustomerDataFromDP29TextFile(streamReader, Paramiter);
                        });
                        //Thread start
                        DataFileRead.Start();

                        //Thread Join 
                        DataFileRead.Join();

                        //Data Save to Database
                        int Totalquery = ListDp29FileData.Count;
                        toolStripStatusLabel.Text = "Process..";
                        for (int i = 0; i < Totalquery; i++)
                        {
                            DP29Bal.InsertCustomerBO_DP29(ListDp29FileData[i].ToString());
                            int progress = i * 100 / (Totalquery - 1);
                            toolStripProgressBar.Value = progress;
                            toolStripStatusCount.Text = i.ToString();
                            Application.DoEvents();
                        }
                        dgdDisplayData.Columns.Clear();
                        dgdDisplayData.DataSource = DP29Bal.GetClientBOInfo();
                        toolStripProgressBar.Value = 0;
                        toolStripStatusLabel.Text = "Process Complete";
                        Application.DoEvents();
                        MessageBox.Show("Data Insert Successfully");

                       

                    }

                }
                else
                {
                    MessageBox.Show("DP29 Table Missing.Please Try Again. System Automatically Create DP29 Table ");
                }
            }
        }






        //Read Data from D29 Text file 
        private List<string> GetCustomerDataFromDP29TextFile(StreamReader streamReader, string Insertparamiter)
        {
            List<string> InsertQueryList = new List<string>();

            try
            {
                while (streamReader.Peek() > 0)
                {
                    string[] Info = streamReader.ReadLine().Split('~');
                    string Insertvalue = "";
                    //Info.Length - 1   //last Date is not count 
                    for (var i = 0; i < Info.Length - 1; i++)
                    {
                        if (i == Info.Length - 2)
                        {
                            Insertvalue += "'" + Info[i].Replace("'", "''") + "'";
                        }
                        else
                        {
                            Insertvalue += "'" + Info[i].Replace("'", "''") + "'" + ",";
                        }
                    }

                    if (Insertvalue == "")
                    {
                        continue;
                    }

                    //adding to list
                    string querystring = "insert into SBP_DP29(" + Insertparamiter + ")values(" + Insertvalue + ")";
                    InsertQueryList.Add(querystring);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return InsertQueryList;
        }


        //------------------------End btn Start Upload -------------------------
        //------------------------Btn Mismatch ---------------------------

        private void btnMismatch_Click(object sender, EventArgs e)
        {

            string from = txtFrom.Text;
            string To = txtTo.Text;

            if (from == "" && To == "")
            {
                MessageBox.Show("Please Input Range Row number such as 1 To 50");
                return;
            }

            btnMismatch.Enabled = false;
            btnLoadPrvData.Enabled = false;
            btnForceClose.Enabled = false;
            btnChange.Enabled = false;
            btnLoadDP29.Enabled = false;
            btnReport.Enabled = false;
            Cencel = false;
            toolStripStatusLabel.Text = "Checking....";



            dgdDisplayData.Columns.Clear();
            DataMismatchBackgroudworker.RunWorkerAsync();

        }



        private void DataMismatchBackgroudworker_DoWork(object sender, DoWorkEventArgs e)
        {
            string from = txtFrom.Text;
            string To = txtTo.Text;
            MatchDataDP29toMasterTable(from, To);
        }


        private void DataMismatchBackgroudworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DP29File_DataMatchBAL DP29Bal = new DP29File_DataMatchBAL();
            //Collect data from DP29Mismatch Table
            DataTable misdata = DP29Bal.GetMismatchData();


            //Add Gridview Checkbox
            DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            checkbox.HeaderText = "";
            checkbox.Name = "IID";
            checkbox.Width = 30;
            dgdDisplayData.Columns.Insert(0, checkbox);


            //load data in GridView
            dgdDisplayData.DataSource = misdata;

            for (int p = 1; p < dgdDisplayData.Columns.Count; p++)
            {
                dgdDisplayData.Columns[p].ReadOnly = true;
            }


            //Load  Report dropdown
            var bal = new DP29File_DataMatchBAL();
            var MismatchStatus = bal.ReportDP29MisMatchTableQuery("select Status  from SBP_DP29Mismatch group by Status ");
            var loadData = (from DataRow cp in MismatchStatus.Rows select cp[0]).ToArray();
            cmbReport.Items.Clear();
            cmbReport.Items.AddRange(loadData);
            cmbReport.SelectedIndex = 0;

            //Load Column Name list
        
            var allColumn = bal.getAllDP29MisMatchTableColumnNameArray();
            loadclbColumnName(allColumn);



            //Set Validation
            this.Invoke(new ProcessStatusshow(ProcessStatus), new object[] { "ProcessComplete" });
            toolStripProgressBar.Value = 0;
            toolStripStop.Visible = false;
            btnFind.Enabled = true;
            btnForceClose.Enabled = true;
            btnChange.Enabled = true;
            btnMismatch.Enabled = true;
            btnLoadPrvData.Enabled = true;
            btnForceClose.Enabled = true;
            btnChange.Enabled = true;
            btnLoadDP29.Enabled = true;
            btnReport.Enabled = true;
            ChkSelectAll.Enabled = true;
 


        }



        private void DataMismatchBackgroudworker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }



   




        public void MatchDataDP29toMasterTable(string from, string to)
        {
            DP29File_DataMatchBAL DP29Bal = new DP29File_DataMatchBAL();

            //All Data read from DP29 Table
            DataTable D29TableData = DP29Bal.Dp29TableData(from, to);

            //All Data Read form Master table
            DataTable MasterTableData = DP29Bal.MainTableData();
            if (MasterTableData == null)
            {
                MessageBox.Show("Please set Column Mapping");
                return;
            }

            //Mapping Table load
            DataTable MappingTable = DP29Bal.MappingTableData();



            //Create DP29 Mismatch Table or delete all data
            DP29Bal.CreateSBP_DP29MissmatchTable();


       

            //flag
            string Status = "";
            bool CDBLclose = false;
            bool BackOfficeClose = false;
            bool BackofficeSuspend = false;
            bool CDBLSuspend = false;


            //count total Row
            int totalSteps = D29TableData.Rows.Count;


            List<string> MismatchQueryString = new List<string>();

            //filter data and add this list
            List<string> TempDataTableList = new List<string>();


            toolStripStop.Visible = true;

            for (var i = 1; i < totalSteps; i++)
            {
                Status = "";
                CDBLclose = false;
                BackOfficeClose = false;
                if (Cencel == true)
                {
                    break;
                }



                Thread.Sleep(50);

                //CDBL file Column Name
                var DP29BoID = D29TableData.Columns[1].ColumnName.ToString();

                //Master table Column Name
                var MasterTableColumnName = (from DataRow aa in MappingTable.Rows where aa["CDBLFileColumnName"].ToString().ToLower() == DP29BoID.ToLower() select aa["TargetColumnName"]).FirstOrDefault();


                //Load Boid from row
                var DP29BoIDValue = D29TableData.Rows[i][1].ToString().Substring(8);

                //Read single Row row 
                DataRow Dp29TableRow = D29TableData.Rows[i];


                //Find row from Master Table 
                DataRow MasterTableRow = (from DataRow a in MasterTableData.Rows where a[MasterTableColumnName.ToString()].ToString() == DP29BoIDValue select a).FirstOrDefault();

               
                //get all Mismatch column Name
                string MismatchTableColumnName = DP29Bal.getAllDP29MisMatchTableColumnName();
 

                //----------Check null Value if null  add database as New Entry-------------------------
                if (MasterTableRow == null)
                {
                  
                    TempDataTableList.Clear();
                    TempDataTableList.Add("");//Cust code add null data


                    for (var p = 1; p < Dp29TableRow.ItemArray.Length - 1; p++)
                    {
                        if (Regex.IsMatch(Dp29TableRow[p].ToString(), "[0-9]") && Dp29TableRow[p].ToString().Length == 16)
                        {
                            TempDataTableList.Add(Dp29TableRow[p].ToString().Substring(8));
                        }
                        else
                        {
                            string D29Column = D29TableData.Columns[p].ColumnName.ToString();
                            if (D29Column == "BOStatus")
                            {
                                Status = Dp29TableRow[p].ToString() == "Closed" ? "Not in BackOffice But CDBL Close" : "New Entry";
                            }
                            TempDataTableList.Add(Dp29TableRow[p].ToString());
                        }
                    }


                    TempDataTableList.Insert(0, Status);
                    string Value = "";
                    for (var u = 0; u < TempDataTableList.Count; u++)
                    {
                        if (u == TempDataTableList.Count - 1)
                        {
                            Value += "'" + TempDataTableList[u].Replace("'", "''") + "'";
                        }
                        else
                        {
                            Value += "'" + TempDataTableList[u].Replace("'", "''") + "'" + ",";
                        }
                    }

                    string Query = "insert into SBP_DP29Mismatch (" + MismatchTableColumnName + ") values (" + Value + ")";
                    DP29Bal.SaveDP29MismatchTable(Query);

                    continue;
                }
                //--------------------------------End new entry-----------------------------------

                //-------------------End Data Retrive Each Row



                //list clear
                TempDataTableList.Clear();


                //Find Master table last Column Name
                string MasterColumnName = MasterTableData.Columns[MasterTableData.Columns.Count - 1].ColumnName.ToString();
                if (MasterColumnName == "Cust_Status_ID")
                {                                     //find last column from master table
                    BackOfficeClose = MasterTableRow[MasterTableData.Columns.Count - 1].ToString() == "2" ? true : false;
                    BackofficeSuspend = MasterTableRow[MasterTableData.Columns.Count - 1].ToString() == "4" ? true : false;
                }



                //check two table column leanth is equal
                if (D29TableData.Columns.Count == MasterTableData.Columns.Count)
                {
                    for (var j = 0; j < Dp29TableRow.ItemArray.Length; j++)
                    {
                        string D29Column = D29TableData.Columns[j].ColumnName.ToString();

                        switch (D29Column)
                        {
                            case "BOIdentificationNumber":
                                {
                                    TempDataTableList.Add(MasterTableRow[j].ToString());
                                    continue;
                                }
                            case "BOStatus":
                                {
                                    CDBLclose = Dp29TableRow[j].ToString() == "Closed" ? true : false;
                                    break;
                                }
                            case "SuspenseFlag":
                                {
                                    CDBLSuspend = Dp29TableRow[j].ToString() != "Not Suspended" ? true : false;
                                    break;
                                }
                        }



                        string MaintableColumn = MasterTableData.Columns[j].ColumnName.ToString();

                        switch (MaintableColumn)
                        {
                            case "Cust_Code":
                                {
                                    TempDataTableList.Add(MasterTableRow[j].ToString());
                                    break;
                                }
                            case "BO_Type_ID":
                                {
                                    string QueryValue = Dp29TableRow[j].ToString();
                                    QueryValue = QueryValue == "Joint Holder" ? "JOINT HOLDERS" : QueryValue;
                                    string query = "select BO_Type_ID from SBP_BO_Type where BO_Type='" + QueryValue + "'";
                                    Dp29TableRow[j] = DP29Bal.FindPrimaryID(query);
                                    break;
                                }

                            case "BO_Category_ID":
                                {
                                    string QueryValue = Dp29TableRow[j].ToString();
                                    string query = "select BO_Category_ID from SBP_BO_Category Where BO_Category='" + QueryValue + "'";
                                    Dp29TableRow[j] = DP29Bal.FindPrimaryID(query);

                                    break;
                                }
                            case "BO_Status_ID":
                                {

                                    var SespendFlag = Dp29TableRow["SuspenseFlag"].ToString() != "Not Suspended" ? true : false;
                                    if (SespendFlag)
                                    {
                                        Dp29TableRow[j] = "4";
                                       
                                    }
                                    else 
                                    {
                                        string QueryValue = Dp29TableRow[j].ToString();
                                        string query = "select Cust_Status_ID from SBP_Cust_Status where Cust_Status='" + QueryValue + "'";
                                        Dp29TableRow[j] = DP29Bal.FindPrimaryID(query);
                                    }
                                    break;
                                }
                        }




                        var MappingCDBLColumnName = (from DataRow aa in MappingTable.Rows where aa["TargetColumnName"].ToString().ToLower() == MaintableColumn.ToLower() select aa["CDBLFileColumnName"]).FirstOrDefault();
                        MappingCDBLColumnName = MappingCDBLColumnName == null ? "" : MappingCDBLColumnName;

                        //column name check 
                        if (D29Column.ToLower() == MappingCDBLColumnName.ToString().ToLower())
                        {
                            string MasterTableCellValue = MasterTableRow[j].ToString().ToLower();
                            string DP29Value = "";
                            switch (MappingCDBLColumnName.ToString())
                            {


                                case "DateofBirth":
                                    {
                                        DP29Value = Dp29TableRow[j].ToString();
                                        if (!string.IsNullOrEmpty(DP29Value))
                                        {
                                            DP29Value = Convert.ToDateTime(DP29Value).ToString("yyyy-MM-dd");
                                            if (!string.IsNullOrEmpty(MasterTableCellValue))
                                            {
                                                MasterTableCellValue = Convert.ToDateTime(MasterTableCellValue).Date.ToString("yyyy-MM-dd");
                                            }
                                        }
                                        break;
                                    }



                                case "SetupDate":
                                    {
                                        DP29Value = Dp29TableRow[j].ToString();
                                        if (!string.IsNullOrEmpty(DP29Value))
                                        {
                                            DP29Value = Convert.ToDateTime(DP29Value).ToString("yyyy-MM-dd");
                                            if (!string.IsNullOrEmpty(MasterTableCellValue))
                                            {
                                                MasterTableCellValue = Convert.ToDateTime(MasterTableCellValue).Date.ToString("yyyy-MM-dd");
                                            }
                                        }
                                        break;
                                    }




                                case "ClosureDate":
                                    {
                                        DP29Value = Dp29TableRow[j].ToString().Trim();
                                        if (!string.IsNullOrEmpty(DP29Value))
                                        {
                                            DP29Value = Convert.ToDateTime(DP29Value).ToString("yyyy-MM-dd");

                                            if (!string.IsNullOrEmpty(MasterTableCellValue))
                                            {
                                                MasterTableCellValue = Convert.ToDateTime(MasterTableCellValue).Date.ToString("yyyy-MM-dd");
                                            }
                                        }
                                        break;
                                    }




                                case "BONationality":
                                    {
                                        DP29Value = Dp29TableRow[j].ToString().ToLower() == "BAN".ToLower() ? "Bangladeshi".ToLower() : Dp29TableRow[j].ToString().ToLower();
                                        break;
                                    }



                                case "Residency":
                                    {
                                        DP29Value = Dp29TableRow[j].ToString().ToLower() == "Y".ToLower() ? "Resident".ToLower() : "Non Resident".ToLower();
                                        break;
                                    }


                                case "Gender":
                                    {
                                        DP29Value = Dp29TableRow[j].ToString().ToLower();
                                        if (DP29Value == "M".ToLower())
                                        {
                                            DP29Value = "Male".ToLower();
                                        }
                                        else
                                        {
                                            DP29Value = "Female".ToLower();
                                        }
                                        break;
                                    }



                                default:
                                    {
                                        DP29Value = Dp29TableRow[j].ToString().ToLower();
                                        break;
                                    }
                            }





                            //Match value Between Dp29 and MasterTable
                            if (DP29Value.Trim() == MasterTableCellValue.Trim())
                            {
                                //null value show
                                if (string.IsNullOrEmpty(DP29Value.Trim()) && string.IsNullOrEmpty(MasterTableCellValue.Trim()))
                                {
                                    TempDataTableList.Add("");
                                }
                                else
                                {
                                    TempDataTableList.Add("Match");
                                }

                                if (Status == "") Status = "Match";
                            }
                            else
                            {
                                TempDataTableList.Add(Dp29TableRow[j].ToString());
                                Status = "Active Account";
                            }

                        }//end column Name check

                    }//End 2nd loop





                    if (BackofficeSuspend)
                    {
                        Status = "BOffice Suspend";
                    }
                    if (CDBLSuspend)
                    {
                        Status = "CDBLSuspend";
                    }
                    if (BackofficeSuspend && CDBLSuspend)
                    {
                        Status = "Suspend All";
                    }
                    if (CDBLclose)
                    {
                        Status = "CDBL Close";
                    }
                    if (BackOfficeClose)
                    {
                        Status = "Back Office Close";
                    }
                    if (CDBLclose && BackOfficeClose)
                    {
                        Status = "Close All";
                    }
                    //add First column as Status
                    TempDataTableList.Insert(0, Status);

                }//End check two column leanth


                //collect Value From Templist for create insert query
                string Values = "";

                for (var u = 0; u < TempDataTableList.Count; u++)
                {
                    if (u == TempDataTableList.Count - 1)
                    {
                        Values += "'" + TempDataTableList[u].Replace("'", "''") + "'";
                    }
                    else
                    {
                        Values += "'" + TempDataTableList[u].Replace("'", "''") + "'" + ",";
                    }
                }




                if (Values == "")
                {
                    continue;
                }

               //build insert Query
                string querystring = "insert into SBP_DP29Mismatch (" + MismatchTableColumnName + ") values (" + Values + ")";


                //Save to database
                DP29Bal.SaveDP29MismatchTable(querystring);

                Thread.Sleep(100);
                int progress = i * 100 / (totalSteps - 1);
                this.Invoke(new StatusMessageShow(processbarshow), new object[] { progress });
                this.Invoke(new StatusMessageShow(countshow), new object[] { i });
            }//end 1st loop

            

            Thread.Sleep(500);
        }




        public void countshow(int i)
        {
            toolStripStatusCount.Text = i.ToString();
        }



        public void processbarshow(int progress)
        {
            toolStripProgressBar.Value = progress;
        }



        public void ProcessStatus(string Message)
        {
          toolStripStatusLabel.Text = Message;
        }














        //------------------------ End Btn Mismatch ---------------------------





        //---------------btn Close ------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //---------------Load Dp29Data Table -----------------
        private void btnLoadDP29_Click(object sender, EventArgs e)
        {
            ChkSelectAll.Enabled = false;
            dgdDisplayData.Columns.Clear();
            // Check DP29 Table is Available
            var Isexist = new DbConnection().IsTableExist("SBP_DP29");
            if (Isexist)
            {
                DP29File_DataMatchBAL DP29Bal = new DP29File_DataMatchBAL();
                var item = DP29Bal.GetClientBOInfo();
                toolStripStatusLabel.Text = "Total Row="+item.Rows.Count;

                dgdDisplayData.DataSource = item;

            }
        }





        private void btnLoadPrvData_Click(object sender, EventArgs e)
        {
            dgdDisplayData.Columns.Clear();
            DP29File_DataMatchBAL DP29Bal = new DP29File_DataMatchBAL();
            //load Data DP29 Mismatchtable
            DataTable misdata = DP29Bal.GetMismatchData();
            toolStripStatusLabel.Text = "Total Row=" + misdata.Rows.Count;
            //gridview add checkbox column
            DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            checkbox.HeaderText = "";
            checkbox.HeaderCell.Value = "CK";
            checkbox.Width = 30;
            checkbox.Name = "IID";
            dgdDisplayData.Columns.Insert(0, checkbox);

            //Show data in gridview
            dgdDisplayData.DataSource = misdata;

            //Gridveiw all column set readonly except checkbox
            for (int p = 1; p < dgdDisplayData.Columns.Count; p++)
            {
                dgdDisplayData.Columns[p].ReadOnly = true;
            }

            //Set Validation 
            btnFind.Enabled = true;
            btnForceClose.Enabled = true;
            btnChange.Enabled = true;
            ChkSelectAll.Enabled = true;

        }



        //----------------------btn Change ---------------------------------

        private void btnChange_Click(object sender, EventArgs e)
        {

            //set Validation
            toolStripStop.Visible = true;
            btnMismatch.Enabled = false;
            btnLoadPrvData.Enabled = false;
            btnForceClose.Enabled = false;
            btnChange.Enabled = false;
            btnLoadDP29.Enabled = false;
            btnReport.Enabled = false;
            Cencel = false;
            DataUpdate_backgroundWorker.RunWorkerAsync();
        }



        private void DataUpdate_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateSelectedColumn();

        }

        public void UpdateSelectedColumn()
        {
            // Check Selected Column which want update 
            List<string> selectedColumnName = new List<string>();

            foreach (var item in clbColumnName.CheckedItems)
            {
                selectedColumnName.Add(item.ToString());
            }

            if (selectedColumnName.Count == 0)
            {
                MessageBox.Show("please Select Column Name");
                return;
            }
            //---end update 



            DP29File_DataMatchBAL DP29Bal = new DP29File_DataMatchBAL();
            //Load Mapping table
            DataTable MappingTable = DP29Bal.MappingTableData();

            //create Data Table for Store Query Value
            DataTable TempDataTable = new DataTable();
            TempDataTable.Columns.Add("TableName", typeof(string));
            TempDataTable.Columns.Add("Value", typeof(string));
    

            int notcheckMark = 0;



            //Find Out How many row is GridView
            var totalSteps = this.dgdDisplayData.Rows.Count;


            //Read GridView Data
            for (int i = 0; i < totalSteps; i++)
            {
                string Custcode = "";

                if (Cencel == true)
                {
                    break;
                }


                int progressed = i * 100 / (totalSteps);

                //is Checkbox Mark
                bool isSelect = Convert.ToBoolean(dgdDisplayData.Rows[i].Cells["IID"].Value);
                if (!isSelect)
                {


                    this.Invoke(new StatusMessageShow(processbarshow), new object[] { progressed });
                    this.Invoke(new StatusMessageShow(countshow), new object[] { i });
                    continue;

                }

                TempDataTable.Clear();
                //Read GridView single Row
                for (var u = 2; u < dgdDisplayData.Rows[i].Cells.Count; u++)
                {

                    //Find Gridview Column Name
                    string gridViewcolumnName = dgdDisplayData.Columns[u].Name;

                    //check selected column name contain list 
                    if (!selectedColumnName.Contains(gridViewcolumnName))
                    {
                        if (gridViewcolumnName != "CustCode")
                        {
                            continue;
                        }


                    }



                    //Cell Value
                    string CellValue = dgdDisplayData.Rows[i].Cells[u].Value.ToString().Replace("'", "''").Trim();
                    // Cell Value contain Match

                    if (CellValue == "Match")
                    {
                        continue;
                    }
                    else if (string.IsNullOrEmpty(CellValue))
                    {
                        continue;
                    }





                    switch (gridViewcolumnName)
                    {
                        case "CustCode":
                            {
                                //store customer code in local variable for use build update Query
                                if (string.IsNullOrEmpty(CellValue))
                                {
                                    continue;
                                }
                                Custcode = CellValue;
                                continue;

                            }
                        case "BOIdentificationNumber":
                            {
                                continue;

                            }
                        case "BOType":
                            {
                                continue;

                            }
                        case "BOCategory":
                            {
                                continue;

                            }
                        case "InternalReferenceNumber":
                            {
                                continue;
                            }
                        case "DateofBirth":
                            {
                                CellValue = Convert.ToDateTime(CellValue).ToString("yyyy-MM-dd");
                                break;
                            }
                        case "SetupDate":
                            {
                                CellValue = Convert.ToDateTime(CellValue).ToString("yyyy-MM-dd");
                                break;
                            }

                        case "ClosureDate":
                            {
                                CellValue = Convert.ToDateTime(CellValue).ToString("yyyy-MM-dd");
                                break;
                            }


                        case "BONationality":
                            {
                                CellValue = CellValue.ToString().ToLower() == "BAN".ToLower() ? "Bangladeshi" : CellValue.ToString();
                                break;
                            }

                        case "Residency":
                            {
                                CellValue = CellValue.ToString().ToLower() == "Y".ToLower() ? "Resident" : "Non Resident";
                                break;
                            }
                        case "Gender":
                            {
                                if (CellValue.ToLower() == "M".ToLower())
                                {
                                    CellValue = "Male".ToLower();
                                }
                                else
                                {
                                    CellValue = "Female".ToLower();
                                }
                                break;
                            }
                    }





                    //Find Master table column Name and Table name using GridView Column name
                    var MappingData = (from DataRow q in MappingTable.Rows where q["CDBLFileColumnName"].ToString().ToLower() == gridViewcolumnName.ToLower() select q).FirstOrDefault();
                    if (MappingData != null)
                    {
                        string tableName = MappingData.ItemArray[3].ToString();
                        string ColumnName = MappingData.ItemArray[2].ToString();

                        //store key & value
                        string keyValue = ColumnName + "='" + CellValue + "'";
                        //add data in dataTable
                        TempDataTable.Rows.Add(tableName, keyValue);
                    }
                } //End ForLoop



                //------------------------Create update query-------------------
                //Find out All Table Name from mapping table
                var tableList = (from DataRow l in MappingTable.Rows group l by l["TargetTableName"] into g select g).ToArray();
                foreach (var c in tableList)
                {
                    var SingleTableName="";
                         SingleTableName = c.Key.ToString();

                    //Query Created dataTable load all row
                    var DataList = (from DataRow w in TempDataTable.Rows where w["TableName"].ToString().ToLower() == SingleTableName.ToLower() select w["Value"]).ToArray();
                    if (DataList.Length > 0)
                    {

                        string Query = "";
                        for (var cp = 0; cp < DataList.Length; cp++)
                        {
                            if (cp == DataList.Length - 1)
                            {
                                Query += DataList[cp].ToString();
                            }
                            else
                            {
                                Query += DataList[cp].ToString() + ",";
                            }
                        }
                        string MainQuery = "update " + SingleTableName + " set " + Query + " where Cust_Code= " + Custcode;







                        //insert data into table
                        try
                        {
                            DataTable data = DP29Bal.IsRowisAvailable("select * from " + SingleTableName + " where Cust_Code= " + Custcode);
                            if (data.Rows.Count > 0)
                            {
                                DP29Bal.UpdateDataFromGrid(MainQuery);
                            }
                            else
                            {
                                string RowInsertquery = "insert into " + SingleTableName + "(Cust_Code)values(" + Custcode + ")";
                                DP29Bal.RowInsert(RowInsertquery);
                                DP29Bal.UpdateDataFromGrid(MainQuery);
                            }

                            Thread.Sleep(100);

                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }
                notcheckMark = 1;
                int progress = i * 100 / (totalSteps - 1);
                this.Invoke(new StatusMessageShow(processbarshow), new object[] { progress });
                this.Invoke(new StatusMessageShow(countshow), new object[] { i });
            
            }
            if (notcheckMark == 0)
            {
                MessageBox.Show("Not update.Please Check Row from table ");

            }
            else
            {
                MessageBox.Show("update Complete");
            }
         
        }







        private void DataUpdate_backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }





        private void DataUpdate_backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke(new ProcessStatusshow(ProcessStatus), new object[] { "ProcessComplete" });
            toolStripProgressBar.Value = 0;
            toolStripStop.Visible = false;
            btnFind.Enabled = true;
            btnForceClose.Enabled = true;
            btnChange.Enabled = true;
            btnMismatch.Enabled = true;
            btnLoadPrvData.Enabled = true;
            btnForceClose.Enabled = true;
            btnChange.Enabled = true;
            btnLoadDP29.Enabled = true;
            btnReport.Enabled = true;
            toolStripStop.Visible = true;
          
        }




        


        //----------------------------btn Force Close -----------------------------

        private void btnForceClose_Click(object sender, EventArgs e)
        {

            var totalSteps = this.dgdDisplayData.Rows.Count;
            List<string> CustCodeList = new List<string>();


            for (int i = 0; i < totalSteps; i++)
            {
                bool isSelect = Convert.ToBoolean(dgdDisplayData.Rows[i].Cells["IID"].Value);
                if (!isSelect)
                {
                    int progressed = i * 100 / (totalSteps - 1);
                    toolStripProgressBar.Value = progressed;
                    toolStripStatusCount.Text = i.ToString();
                    Application.DoEvents();
                    continue;
                }

                for (var u = 2; u < dgdDisplayData.Rows[i].Cells.Count; u++)
                {

                    string Val = dgdDisplayData.Rows[i].Cells[u].Value.ToString().Replace("'", "''");
                    string gridViewcolumnName = dgdDisplayData.Columns[u].Name;
                    if (gridViewcolumnName == "CustCode")
                    {
                        CustCodeList.Add(Val);
                    }

                }
            }

            DialogResult dialogResult = MessageBox.Show("Do you want to Close " + CustCodeList.Count + " Account ", "Account Close", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (var dd in CustCodeList)
                {
                    string query = "update SBP_Customers set Cust_Status_ID=2 where Cust_Code=" + dd;
                    new DP29File_DataMatchBAL().ForceAccuntClose(query);
                }
                MessageBox.Show("Account Close Succesfully");
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

        }



        // ------------------------ Select All CheckBox --------------------------------------

        private void ChkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgdDisplayData.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    row.Cells[0].Value = false;
                }
                else
                {
                    row.Cells[0].Value = true;
                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            DP29File_DataMatchBAL DP29Bal = new DP29File_DataMatchBAL();
            frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();
          string comboValue=cmbReport.Text;

          switch (comboValue)
          {
              case "Select One": 
                  {
                      MessageBox.Show("Please Select one");
                      return;
                      
                  }

              case "Summary":
                  {
                      //--------------------Create Sammary --------------------------
                      crDP29MismatchReport cd = new crDP29MismatchReport();
                      cd.SetParameterValue("ActiveAccount", 0);
                      cd.SetParameterValue("CDBLandBackofficeClose", 0);
                      cd.SetParameterValue("CDBLSuspend", 0);
                      cd.SetParameterValue("BackOfficeSuspend", 0);
                      cd.SetParameterValue("NewEntry", 0);
                      cd.SetParameterValue("NotinBackOfficeButCDBLClose", 0);
                      cd.SetParameterValue("CDBLandBackofficeSuspend", 0);
                      cd.SetParameterValue("CDBLClose", 0);
                      cd.SetParameterValue("BackofficeClose", 0);
                 

                      DataTable data = DP29Bal.ReportDP29MisMatchTableQuery("select Status,count(Status) from SBP_DP29Mismatch group by Status");

                      for (var i = 0; i < data.Rows.Count; i++)
                      {
                          string TitleName = data.Rows[i][0].ToString();
                          string Titlevalue = data.Rows[i][1].ToString();
                          switch (TitleName)
                          {
                              case "BOffice Suspend":
                                  {
                                      cd.SetParameterValue("BackOfficeSuspend", Titlevalue);
                                      break;
                                  }
                              case "CDBLSuspend":
                                  {
                                      cd.SetParameterValue("CDBLSuspend", Titlevalue);
                                      break;
                                  }
                              case "Suspend All":
                                  {
                                      cd.SetParameterValue("CDBLandBackofficeSuspend", Titlevalue);
                                      break;
                                  }
                              case "CDBL Close":
                                  {
                                      cd.SetParameterValue("CDBLClose", Titlevalue);
                                      break;
                                  }
                              case "Back Office Close":
                                  {
                                      cd.SetParameterValue("BackofficeClose", Titlevalue);
                                      break;

                                  }
                              case "Close All":
                                  {
                                      cd.SetParameterValue("CDBLandBackofficeClose", Titlevalue);
                                      break;
                                  }
                              case "ActiveAccount":
                                  {
                                      cd.SetParameterValue("ActiveAccount", Titlevalue);
                                      break;
                                  }
                              case "Not in BackOffice But CDBL Close":
                                  {
                                      cd.SetParameterValue("NotinBackOfficeButCDBLClose", Titlevalue);
                                      break;
                                  }
                              case "New Entry":
                                  {
                                      cd.SetParameterValue("NewEntry", Titlevalue);
                                      break;
                                  }
                          }
                      } //inner swich end


                      //  cd.SetDataSource(data);
                      frmcustomerAccInfo.crvPdfReport.ReportSource = cd;
                      frmcustomerAccInfo.Show();
                      break;
                      //----------------------End Sammary ----------------------------------
                  }
              case "Active Account":
                  {
                      CrDP29MismatchSpecificData CDmSD = new CrDP29MismatchSpecificData();
                      DataTable Arraydata = DP29Bal.ReportDP29MisMatchTableQuery("select  CustCode from SBP_DP29Mismatch where Status='" + comboValue + "' order by CustCode*1");
                      if (Arraydata != null)
                      {
                          var arrayData = (from DataRow u in Arraydata.Rows select u[0]).ToArray();
                          string ArraytoString = arrayData.Select(a => a.ToString()).Aggregate((i, j) => i + "     ,    " + j);
                          CDmSD.SetParameterValue("PageHeader", "Active Account");
                          CDmSD.SetParameterValue("Total", Arraydata.Rows.Count);
                          CDmSD.SetParameterValue("CustCode", ArraytoString);
                          frmcustomerAccInfo.crvPdfReport.ReportSource = CDmSD;
                          frmcustomerAccInfo.Show();
                      }
                      else
                      {
                          MessageBox.Show(" No data Found");
                      }
                      break;
                  }
              case "Not in BackOffice But CDBL Close":
                  {
                      CrDP29MismatchSpecificData CDmSD = new CrDP29MismatchSpecificData();
                      DataTable Arraydata = DP29Bal.ReportDP29MisMatchTableQuery("select  BOIdentificationNumber from SBP_DP29Mismatch where Status='" + comboValue + "' order by BOIdentificationNumber*1");
                      if (Arraydata != null)
                      {
                          var arrayData = (from DataRow u in Arraydata.Rows select u[0]).ToArray();
                          string ArraytoString = arrayData.Select(a => a.ToString()).Aggregate((i, j) => i + "     ,    " + j);
                          CDmSD.SetParameterValue("PageHeader", comboValue);
                          CDmSD.SetParameterValue("Total", Arraydata.Rows.Count);
                          CDmSD.SetParameterValue("CustCode", ArraytoString);
                          frmcustomerAccInfo.crvPdfReport.ReportSource = CDmSD;
                          frmcustomerAccInfo.Show();
                      }
                      else
                      {
                          MessageBox.Show(" No data Found");
                      }

                      break;
                  
                  }
              case "New Entry":
                  {
                      CrDP29MismatchSpecificData CDmSD = new CrDP29MismatchSpecificData();
                      DataTable Arraydata = DP29Bal.ReportDP29MisMatchTableQuery("select  BOIdentificationNumber from SBP_DP29Mismatch where Status='" + comboValue + "' order by BOIdentificationNumber*1");
                      if (Arraydata != null)
                      {
                          var arrayData = (from DataRow u in Arraydata.Rows select u[0]).ToArray();
                          string ArraytoString = arrayData.Select(a => a.ToString()).Aggregate((i, j) => i + "     ,    " + j);
                          CDmSD.SetParameterValue("PageHeader", comboValue);
                          CDmSD.SetParameterValue("Total", Arraydata.Rows.Count);
                          CDmSD.SetParameterValue("CustCode", ArraytoString);
                          frmcustomerAccInfo.crvPdfReport.ReportSource = CDmSD;
                          frmcustomerAccInfo.Show();
                      }
                      else
                      {
                          MessageBox.Show(" No data Found");
                      }

                      break;


                  }
              default:
                  {
                      CrDP29MismatchSpecificData CDmSD = new CrDP29MismatchSpecificData();
                      DataTable Arraydata = DP29Bal.ReportDP29MisMatchTableQuery("select  CustCode from SBP_DP29Mismatch where Status='" + comboValue + "' order by CustCode*1");
                      if (Arraydata != null)
                      {
                          var arrayData = (from DataRow u in Arraydata.Rows select u[0]).ToArray();
                          string ArraytoString = arrayData.Select(a => a.ToString()).Aggregate((i, j) => i + "     ,    " + j);
                          CDmSD.SetParameterValue("PageHeader", comboValue);
                          CDmSD.SetParameterValue("Total", Arraydata.Rows.Count);
                          CDmSD.SetParameterValue("CustCode", ArraytoString);
                          frmcustomerAccInfo.crvPdfReport.ReportSource = CDmSD;
                          frmcustomerAccInfo.Show();
                      }
                      else
                      {
                          MessageBox.Show(" No data Found");
                      }
                     
                      break;
                  }

          } //swich end
    
            
            
        }//End Method


        private void cbSelectAllListboxItem_CheckedChanged(object sender, EventArgs e)
        {
            if (clbColumnName.CheckedItems.Count > 0)
            {
                for (int i = 0; i < clbColumnName.Items.Count; i++)
                {
                    clbColumnName.SetItemChecked(i, false);
                }

            }
            else
            {
                for (int i = 0; i < clbColumnName.Items.Count; i++)
                {
                    clbColumnName.SetItemChecked(i, true);
                }
            }


        }

        //---------------------------GridView Filter -------------------------------




        private void btnFind_Click(object sender, EventArgs e)
        {
            string filterColumnName = dbcSelectColumn.SelectedItem.ToString();
            string filterValue = cmbFilterValue.Text;



            dgdDisplayData.Columns.Clear();
            DP29File_DataMatchBAL DP29Bal = new DP29File_DataMatchBAL();
            DataTable misdatatable = DP29Bal.FindMismatchTableData(filterColumnName, filterValue);
            DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            checkbox.HeaderText = "CK";
            checkbox.Width = 30;
            checkbox.Name = "IID";
            dgdDisplayData.Columns.Insert(0, checkbox);
            dgdDisplayData.DataSource = misdatatable;
            for (int p = 1; p < dgdDisplayData.Columns.Count; p++)
            {
                dgdDisplayData.Columns[p].ReadOnly = true;
            }
        }

        private void dbcSelectColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFilterValue.Items.Clear();
            string filterColumnName = dbcSelectColumn.Text;
            var value = new DP29File_DataMatchBAL().GetMismatchtableColumnGroupbyValue(filterColumnName);

            if (value != null)
            {
                cmbFilterValue.Items.AddRange(value);

            }


        }

        private void toolStripStop_Click(object sender, EventArgs e)
        {
            Cencel = true;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
                Dp29FileUploadSetting setting = new Dp29FileUploadSetting();
                setting.Show();
                this.Close();
        }

       


     




    }


   
}
