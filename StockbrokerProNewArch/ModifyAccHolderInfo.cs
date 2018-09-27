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
using BusinessAccessLayer.Constants;
using System.Globalization;


namespace StockbrokerProNewArch
{
    public partial class ModifyAccHolderInfo : Form
    {
        public ModifyAccHolderInfo()
        {
            InitializeComponent();
        }


        public struct ModBo
        {
            public DateTime DATE;
            public string BOID;
            public string BANKNAME;
            public string BRNACHNAME;
            public string ROUTINGNO;
        }


        //---------------------Initial Value-----------------

        List<ModBo> CustBankBranchRoutingList = new List<ModBo>();



        //-------------- Load Event----------------

        private void ModifyAccHolderInfo_Load(object sender, EventArgs e)
        {
            Reset();
            groupBox2.Visible = false;
            groupBox3.Location = new Point(12, 81);
            this.Height = 294;
            btnNominee.Enabled = false;
            btnPOA.Enabled = false;
            btnNominee2.Enabled = false;
        }





        //--------------Process -------------------


        private List<string> ProcessTextFile(string filePath)
        {
            DataTable POA_OR_Nominee = new DataTable();

            DataColumn CustID = new DataColumn("CustID", typeof(string));
            DataColumn Col1 = new DataColumn("BoID", typeof(string));
            DataColumn Col2 = new DataColumn("ColumnName", typeof(string));
            DataColumn Col3 = new DataColumn("ColumnValue", typeof(string));
            POA_OR_Nominee.Columns.Add(CustID);
            POA_OR_Nominee.Columns.Add(Col1);
            POA_OR_Nominee.Columns.Add(Col2);
            POA_OR_Nominee.Columns.Add(Col3);
       

            const char proChar = '~';
            List<string> modifiedCustomerCollectionBo = new List<string>();

            //read file 
            StreamReader streamReader = new StreamReader(filePath);
            CustomerBAL customerBal = new CustomerBAL();
            while (streamReader.Peek() >= 0)
            {

                string[] values = streamReader.ReadLine().Split(proChar);
                //IsBoid exists 
                if (!customerBal.CheckBoId(values[1].Substring(8, 8)))
                {
                    AddErrorInGrid(values[1], "BO ID Not Found");
                }
                else
                {

                    if (values[2].Trim() == "Annual Maintenance Fee Dues")
                    {
                        string tempQuery = GetModifyQuery(values[2], values[6], values[1].Substring(8, 8));
                        if (tempQuery != string.Empty)
                        {
                            modifiedCustomerCollectionBo.Add(tempQuery);
                        }
                    }
                    else
                    {
                        var columnName = values[3].Trim();

                        switch (columnName)
                        {

                            case "Modifying global details of a BO":
                                {
                                    string tempQuery = GetModifyQuery(values[4], values[6], values[1].Substring(8, 8));
                                    if (tempQuery != string.Empty)
                                    {
                                        modifiedCustomerCollectionBo.Add(tempQuery);
                                    }
                                    break;
                                }
                            case "Modifying POA/additional holder details":
                                {
                                    string Boid = values[1].Substring(8, 8);

                                    CustomerBAL custBal = new CustomerBAL();
                                    string CustCode = custBal.getCustCode(Boid);
                                    POA_OR_Nominee.Rows.Add(CustCode, Boid, values[4], values[6]);
                                    break;
                                }
                        }
                    }


                }
            }
            if (POA_OR_Nominee.Rows.Count > 0)
            {
                GridViewDataShow(POA_OR_Nominee);
                groupBox2.Location = new Point(12, 81);
                groupBox2.Visible = true;
                groupBox3.Location = new Point(12, 454);
                this.Height = 672;
            }

            return modifiedCustomerCollectionBo;
        }






        private void UploadProcess()
        {
            ProcessingMessage("Processing CDBL File...");

            //Null Value Check 
            if (txtFileLocation.Text.Length.Equals(0))
            {
                err.SetError(txtFileLocation, "CDBL File location is a required field.");
                return;
            }
            else
            {
                err.SetError(txtFileLocation, "");
            }


            //Create a list
            List<string> modifiedCustomersQueryBO = new List<string>();

            try
            {
                modifiedCustomersQueryBO = ProcessTextFile(txtFileLocation.Text);
                AddBankBranchRoutingModifyQuery(ref modifiedCustomersQueryBO);

            }
            catch (Exception exception)
            {
                MessageBox.Show("Fail to process txt file. No data saved. Because : " + exception.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset();
                return;
            }

            var GridviewRow = this.dgdAdditionalView.Rows.Count;
            if (GridviewRow > 0)
            {
                btnNominee.Enabled = true;
                btnPOA.Enabled = true;
                btnNominee2.Enabled =true;
                SaveInDatabase(modifiedCustomersQueryBO,"Your Bo Account information Modify Successfully but Need Update POA/Nominee information");
            }
            else
            {
                SaveInDatabase(modifiedCustomersQueryBO, "Your Bo Account information Modify Successfully");
            }
        }





        private void AddBankBranchRoutingModifyQuery(ref List<string> QryList)
        {
            DataTable dtRoutingNo = new DataTable();
            string queryString = string.Empty;
            CustomerBAL customerBal = new CustomerBAL();
            DataTable dtBankBranch = new DataTable();
            string temp = string.Empty;
            try
            {
                var allBOList = CustBankBranchRoutingList
                    .Where(p => p.BOID != string.Empty)
                    .Select(t => t.BOID).ToList().Distinct();

                foreach (string boid in allBOList)
                {
                    temp = boid;
                    if (temp.ToString() == "18233621")
                    {
                        string cc = "";
                    }
                    DateTime datetmp_RoutingNo = new DateTime();
                    DateTime datetmp_BankName = new DateTime();
                    DateTime datetmp_BranchName = new DateTime();

                    string bankNameTemp = string.Empty;
                    string branchNameTemp = string.Empty;
                    string routingNoTemp = string.Empty;

                    List<ModBo> customerBos = CustBankBranchRoutingList.Where(b => b.BOID == boid).ToList();

                    datetmp_BankName = customerBos.Where(p => p.BANKNAME != string.Empty).Select(c => c.DATE).DefaultIfEmpty(
                            DateTime.MinValue).Max();

                    datetmp_BranchName =
                        customerBos.Where(p => p.BRNACHNAME != string.Empty).Select(c => c.DATE).DefaultIfEmpty(
                            DateTime.MinValue).Max();


                    datetmp_RoutingNo = customerBos.Where(p => p.ROUTINGNO != string.Empty).Select(c => c.DATE).DefaultIfEmpty(
                            DateTime.MinValue).Max();


                    bankNameTemp = customerBos.Where(t => t.BANKNAME != string.Empty
                                                                 && t.DATE == datetmp_BankName
                        ).Select(e => e.BANKNAME).FirstOrDefault();

                    branchNameTemp = customerBos.Where(t => t.BRNACHNAME != string.Empty
                                                                   && t.DATE == datetmp_BranchName
                        ).Select(e => e.BRNACHNAME).FirstOrDefault();

                    routingNoTemp = customerBos.Where(t => t.ROUTINGNO != string.Empty
                                                                      && t.DATE == datetmp_RoutingNo
                        ).Select(e => e.ROUTINGNO).FirstOrDefault();

                    dtBankBranch =
                           customerBal.GetBankBranchRoutingInfo(routingNoTemp);

                    if (routingNoTemp != null && dtBankBranch.Rows.Count == 1)
                    {
                        queryString = "UPDATE SBP_Cust_Bank_Info SET Bank_ID=" + Convert.ToInt32(dtBankBranch.Rows[0]["Bank_ID"].ToString()) +
                                      ",Bank_Name='" + dtBankBranch.Rows[0]["Bank_Name"].ToString() +
                                      "',Branch_ID=" + Convert.ToInt32(dtBankBranch.Rows[0]["Branch_ID"].ToString()) +
                                      ",Branch_Name='" + dtBankBranch.Rows[0]["Branch_Name"].ToString() +
                                      "',Routing_No='" + routingNoTemp +
                                      "' FROM SBP_Customers,SBP_Cust_Bank_Info WHERE SBP_Cust_Bank_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" +
                                      boid + "';";
                        QryList.Add(queryString);
                    }
                    else
                    {
                        queryString =
                            "UPDATE SBP_Cust_Bank_Info SET Bank_ID=NULL,Bank_Name= NULL, Branch_ID=NULL,Branch_Name=NULL,Routing_No=NULL FROM SBP_Customers,SBP_Cust_Bank_Info WHERE SBP_Cust_Bank_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" +
                            boid + "';";
                        QryList.Add(queryString);
                    }


                    //else if (bankNameTemp != null && branchNameTemp != null && routingNoTemp == null)
                    //{
                    //    dtRoutingNo = customerBal.GetBankBranchRoutingInfo(bankNameTemp, branchNameTemp);
                    //    if (dtRoutingNo.Rows.Count == 1)
                    //    {
                    //        queryString = "UPDATE SBP_Cust_Bank_Info SET Bank_ID=" + Convert.ToInt32(dtRoutingNo.Rows[0]["Bank_ID"].ToString()) +
                    //                      ",Bank_Name='" + bankNameTemp +
                    //                     "',Branch_ID=" + Convert.ToInt32(dtRoutingNo.Rows[0]["Branch_ID"].ToString()) +
                    //                      ",Branch_Name='" + branchNameTemp +
                    //                     "',Routing_No='" + dtRoutingNo.Rows[0]["Routing_No"].ToString() +
                    //                      "' FROM SBP_Customers WHERE SBP_Cust_Bank_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" +
                    //                      boid + "';";
                    //        QryList.Add(queryString);
                    //    }
                    //    else
                    //    {
                    //        queryString =
                    //            "UPDATE SBP_Cust_Bank_Info SET Bank_ID=NULL,Bank_Name= NULL, Branch_ID=NULL,Branch_Name=NULL,Routing_No=NULL FROM SBP_Customers WHERE SBP_Cust_Bank_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" +
                    //            boid + "';";
                    //        QryList.Add(queryString);
                    //    }
                    //}

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        private void SaveInDatabase(List<string> modifiedCustomersQueryBO, string Message)
        {
            ProcessingMessage("Importing data into database....");

            progress.Maximum = modifiedCustomersQueryBO.Count + 1;
            CustomerBAL customerBal = new CustomerBAL();

            foreach (string query in modifiedCustomersQueryBO)
            {
                try
                {
                    customerBal.ProcessCustomerModification(query);
                }
                catch (Exception exception)
                {
                    AddErrorInGrid(query, exception.Message);
                    continue;
                }
                progress.PerformStep();
            }
            ProcessingMessage("Bank Branch Updating.....");
            //customerBal.Update_BankID_BranchID_In_SBPCustBankInfo();
            ProcessingMessage("Data Imported Successfully.....");
            MessageBox.Show(Message, "Import Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Reset();
        }






        public void GridViewDataShow(DataTable dt)
        {
            dgdAdditionalView.Columns.Clear();
            //Add Gridview Checkbox
            DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            checkbox.HeaderText = "Check";
            checkbox.Name = "IID";
            checkbox.Width = 30;
            dgdAdditionalView.Columns.Insert(0, checkbox);

            //load data in GridView
            dgdAdditionalView.DataSource = dt;

            for (int p = 1; p < dgdAdditionalView.Columns.Count; p++)
            {
                dgdAdditionalView.Columns[p].ReadOnly = true;
            }
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





        private string POA_OR_NomineeQueryCreate(string flag, string BoID, string columnName, string Value)
        {
            string QueryString = "";
            if (flag == "POA")
            {
                switch (columnName)
                {
                    case "C1047":
                        {
                            //QueryString ="UPDATE info SET Name='" + Value + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "BO_MIDDLE_NAME":
                        {
                          //  QueryString ="UPDATE info SET MiddleName='" + Value + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "BO_LAST_NAME":
                        {
                            //QueryString ="UPDATE info SET LastName='" + Value + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "SHORT_NAME":
                        {
                            QueryString = "UPDATE info SET Name='" + Value + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "BO_TITLE":
                        {
                            QueryString = "";
                            break;
                        }
                    case "BO_SUFFIX":
                        {
                            QueryString = "";
                            break;
                        }
                    case "ADDR_1":
                        {
                            QueryString = "UPDATE info SET Address='" + Value + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "ADDR_2":
                        {
                            QueryString = "UPDATE info SET Address2='" + Value + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "ADDR_3":
                        {
                            QueryString = "UPDATE info SET Address3='" + Value + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "CITY":
                        {
                            QueryString = "UPDATE info SET City='" + Value + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "STATE":
                        {
                            QueryString = "UPDATE info SET Division='" + Value + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "CNTRY":
                        {
                            QueryString = "UPDATE info SET Country='" + Value + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "POSTAL_CODE":
                        {
                            QueryString = "UPDATE info SET Post_Code='" + Value + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "PHONE_1":
                        {
                            QueryString = "UPDATE info SET Phone='" + Value + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "PHONE_2":
                        {
                            QueryString = "UPDATE info SET Mobile='" + Value + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "BO_FAX":
                        {
                            QueryString = "UPDATE info SET Fax='" + Value + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "BO_EMAIL":
                        {
                            QueryString = "UPDATE info SET Email='" + Value + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;


                        }
                    case "PASSPORT_NUMB":
                        {
                            QueryString = "UPDATE info SET Passport_No='" + Value + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "PASSPORT_ISSUE_DATE":
                        {

                            DateTime result = DateTime.ParseExact(Value, "ddMMyyyy", CultureInfo.CurrentCulture);
                            QueryString = "UPDATE info SET Issue_Date='" + result + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "PASSPORT_EXPIRY_DATE":
                        {
                            DateTime result = DateTime.ParseExact(Value, "ddMMyyyy", CultureInfo.CurrentCulture);
                            QueryString = "UPDATE info SET Expire_Date='" + result + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "POA_REMARKS":
                        {
                               string DateOfBirth = Value.Substring(14, 11).Replace('.', '-');
                               if (DateOfBirth != "")
                               {
                                   DateTime dpq = Convert.ToDateTime(DateOfBirth);
                                   QueryString = "UPDATE info SET DOB='" + dpq.ToString("MM-dd-yyyy") + "' FROM SBP_Customers as cust JOIN SBP_POA as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                               }
                                break;

                        }
                    case "BO_FRGN_SUFFIX":
                        {
                            QueryString = "";
                            break;

                        }

                }//end Swich
            }





            else if (flag == "Nominee1")
            {
                switch (columnName)
                {
                    case "C1047":
                        {
                            //QueryString = "UPDATE info SET Name='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "BO_MIDDLE_NAME":
                        {
                           // QueryString = "UPDATE info SET MiddleName='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "BO_LAST_NAME":
                        {
                           // QueryString = "UPDATE info SET LastName='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "SHORT_NAME":
                        {
                            QueryString = "UPDATE info SET Name='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "BO_TITLE":
                        {
                            QueryString = "";
                            break;
                        }
                    case "BO_SUFFIX":
                        {
                            QueryString = "";
                            break;
                        }
                    case "ADDR_1":
                        {
                            QueryString = "UPDATE info SET Address='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "ADDR_2":
                        {
                            QueryString = "UPDATE info SET Address2='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "ADDR_3":
                        {
                            QueryString = "UPDATE info SET Address3='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "CITY":
                        {
                            QueryString = "UPDATE info SET City='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "STATE":
                        {
                            QueryString = "UPDATE info SET Division='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "CNTRY":
                        {
                            QueryString = "UPDATE info SET Country='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "POSTAL_CODE":
                        {
                            QueryString = "UPDATE info SET Post_Code='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "PHONE_1":
                        {
                            QueryString = "UPDATE info SET Phone='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "PHONE_2":
                        {
                            QueryString = "UPDATE info SET Mobile='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "BO_FAX":
                        {
                            QueryString = "UPDATE info SET Fax='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "BO_EMAIL":
                        {
                            QueryString = "UPDATE info SET Email='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;


                        }
                    case "PASSPORT_NUMB":
                        {
                            QueryString = "UPDATE info SET Passport_No='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "PASSPORT_ISSUE_DATE":
                        {
                            DateTime result = DateTime.ParseExact(Value, "ddMMyyyy", CultureInfo.CurrentCulture);
                            QueryString = "UPDATE info SET Issue_Date='" + result + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "PASSPORT_EXPIRY_DATE":
                        {
                            DateTime result = DateTime.ParseExact(Value, "ddMMyyyy", CultureInfo.CurrentCulture);
                            QueryString = "UPDATE info SET Expire_Date='" + result + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "POA_REMARKS":
                        {
                            
                            string DateOfBirth = Value.Substring(14, 11).Replace('.', '-');
                            if (DateOfBirth != "")
                            {
                                DateTime dpq = Convert.ToDateTime(DateOfBirth);

                                QueryString = "UPDATE info SET DOB='" + dpq.ToString("MM-dd-yyyy") + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            }
                                break;

                        }
                    case "BO_FRGN_SUFFIX":
                        {
                            QueryString = "";
                            break;

                        }
                    case "RELATIONSHIP":
                        {
                            QueryString = "UPDATE info SET Relationship='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee1 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                }//end Swich


            } //end If





            else if (flag == "Nominee2")
            {
                switch (columnName)
                {
                    case "C1047":
                        {
                           // QueryString = "UPDATE info SET Name='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "BO_MIDDLE_NAME":
                        {
                           // QueryString = "UPDATE info SET MiddleName='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "BO_LAST_NAME":
                        {
                           // QueryString = "UPDATE info SET LastName='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "SHORT_NAME":
                        {
                            QueryString = "UPDATE info SET Name='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "BO_TITLE":
                        {
                            QueryString = "";
                            break;
                        }
                    case "BO_SUFFIX":
                        {
                            QueryString = "";
                            break;
                        }
                    case "ADDR_1":
                        {
                            QueryString = "UPDATE info SET Address='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "ADDR_2":
                        {
                            QueryString = "UPDATE info SET Address2='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "ADDR_3":
                        {
                            QueryString = "UPDATE info SET Address3='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "CITY":
                        {
                            QueryString = "UPDATE info SET City='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "STATE":
                        {
                            QueryString = "UPDATE info SET Division='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "CNTRY":
                        {
                            QueryString = "UPDATE info SET Country='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "POSTAL_CODE":
                        {
                            QueryString = "UPDATE info SET Post_Code='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "PHONE_1":
                        {
                            QueryString = "UPDATE info SET Phone='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;
                        }
                    case "PHONE_2":
                        {
                            QueryString = "UPDATE info SET Mobile='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "BO_FAX":
                        {
                            QueryString = "UPDATE info SET Fax='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "BO_EMAIL":
                        {
                            QueryString = "UPDATE info SET Email='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;


                        }
                    case "PASSPORT_NUMB":
                        {
                            QueryString = "UPDATE info SET Passport_No='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "PASSPORT_ISSUE_DATE":
                        {
                            DateTime result = DateTime.ParseExact(Value, "ddMMyyyy", CultureInfo.CurrentCulture);
                            QueryString = "UPDATE info SET Issue_Date='" + result + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "PASSPORT_EXPIRY_DATE":
                        {
                            DateTime result = DateTime.ParseExact(Value, "ddMMyyyy", CultureInfo.CurrentCulture);
                            QueryString = "UPDATE info SET Expire_Date='" + result + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                    case "POA_REMARKS":
                        {

                            string DateOfBirth = Value.Substring(14, 11).Replace('.', '-');
                            if (DateOfBirth!="")
                         {
                            DateTime dpq = Convert.ToDateTime(DateOfBirth) ;
                            QueryString = "UPDATE info SET DOB='" + dpq.ToString("MM-dd-yyyy") + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';"; 
                         }

                            break;

                        }
                    case "BO_FRGN_SUFFIX":
                        {
                            QueryString = "";
                            break;

                        }
                    case "RELATIONSHIP":
                        {
                            QueryString = "UPDATE info SET Relationship='" + Value + "' FROM SBP_Customers as cust JOIN SBP_Nominee2 as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + BoID + "';";
                            break;

                        }
                }//end Swich


            } //end If

            return QueryString;
        }





        private string GetModifyQuery(string columnName, string modValue, string boId)
        {
            CommonBAL objBal = new CommonBAL();
            bool boidFound = false;
            string queryString = "";
            CustomerBO customerBo = new CustomerBO();

            switch (columnName)
            {

                case Indication_ModifyAccountHolder_FieldDescription.Suspend_for_Annual_Maintenance_Fees_Dus:
                    queryString = "UPDATE SBP_Customers SET BO_Status_ID=4 Where BO_ID='" + boId + "'";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.C1047:
                    queryString = "UPDATE info SET First_Name='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Personal_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.BO_TITLE:
                    queryString = "UPDATE info SET First_Name='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Personal_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.BO_MIDDLE_NAME:
                    queryString = "UPDATE info SET Middle_Name='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Personal_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.BO_LAST_NAME:
                    queryString = "UPDATE info SET Last_Name='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Personal_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.SHORT_NAME:
                    queryString = "UPDATE info SET Cust_Name='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Personal_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.BO_FATHER_HUSBAND:
                    queryString = "UPDATE info SET Father_Name='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Personal_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.BO_MOTHER_NAME:
                    queryString = "UPDATE info SET Mother_Name='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Personal_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.OCCUPATION:
                    queryString = "UPDATE info SET Occupation='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Personal_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.ADDR_1:
                    queryString = "UPDATE info SET Address1='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Contact_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.ADDR_2:
                    queryString = "UPDATE info SET Address2='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Contact_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.ADDR_3:
                    queryString = "UPDATE info SET Address3='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Contact_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.PHONE_1:
                    queryString = "UPDATE info SET Mobile='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Contact_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.PHONE_2:
                    queryString = "UPDATE info SET Phone='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Contact_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.BO_EMAIL:
                    queryString = "UPDATE info SET Email='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Contact_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.BO_FAX:
                    queryString = "UPDATE info SET Fax='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Contact_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.POSTAL_CODE:
                    queryString = "UPDATE info SET Post_Code='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Contact_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.CITY:
                    queryString = "UPDATE info SET City_Name='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Contact_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.STATE:
                    queryString = "UPDATE info SET Division_Name='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Contact_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.CNTRY:
                    queryString = "UPDATE info SET Country_Name='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Contact_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.PASSPORT_NUMB:
                    queryString = "UPDATE info SET Passport_No='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Passport_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.PASSPORT_ISSUE_PLACE:
                    queryString = "UPDATE info SET Issue_Place='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Passport_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.TAX_ID_NUMB:
                    queryString = "UPDATE info SET TIN='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Bank_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.ELEC_DIVIDEND:
                    queryString = "UPDATE info SET Is_EDC=" + (Convert.ToInt16(modValue == "Y")) + " FROM SBP_Customers as cust JOIN SBP_Cust_Bank_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.BANK_NAME:
                    //queryString = "UPDATE SBP_Cust_Bank_Info SET Bank_Name='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Bank_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";

                    var BankName_Temp = new ModBo() { DATE = objBal.GetCurrentServerDate(), BOID = boId, BANKNAME = modValue.Trim(), BRNACHNAME = string.Empty, ROUTINGNO = string.Empty };
                    CustBankBranchRoutingList.Add(BankName_Temp);
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.BANK_BRNCH_NAME:
                    //queryString = "UPDATE SBP_Cust_Bank_Info SET Branch_Name='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Bank_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
                    customerBo.BoId = boId;
                    customerBo.BranchName = modValue.Trim();

                    var BranchName_Temp = new ModBo() { DATE = objBal.GetCurrentServerDate(), BOID = boId, BANKNAME = string.Empty, BRNACHNAME = modValue.Trim(), ROUTINGNO = string.Empty };
                    //CustBankBranchRoutingList.Add(customerBo);
                    CustBankBranchRoutingList.Add(BranchName_Temp);
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.BANK_ACCT_NUMB:
                    queryString = "UPDATE info SET Account_No='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Bank_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.Bank_Routing_Number:
                    //queryString = "UPDATE SBP_Cust_Bank_Info SET Routing_No='" + modValue + "' FROM SBP_Customers WHERE  SBP_Cust_Bank_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";

                    var RoutingNo_Temp = new ModBo() { DATE = objBal.GetCurrentServerDate(), BOID = boId, BANKNAME = string.Empty, BRNACHNAME = string.Empty, ROUTINGNO = modValue.Trim() };
                    CustBankBranchRoutingList.Add(RoutingNo_Temp);
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.International_Bank_Account_Number:
                    queryString = "UPDATE info SET IBAN='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Bank_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.Bank_Swift_Code:
                    queryString = "UPDATE info SET SWIFT_Code='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Bank_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
                case Indication_ModifyAccountHolder_FieldDescription.District_Name:
                    queryString = "UPDATE info SET District_Name='" + modValue + "' FROM SBP_Customers as cust JOIN SBP_Cust_Bank_Info as info ON cust.Cust_Code=info.Cust_Code WHERE cust.BO_ID='" + boId + "';";
                    break;
            }
            return queryString;
        }




        //------------------event ---------------------


        private void btnStartImport_Click(object sender, EventArgs e)
        {
            UploadProcess();
        }

       



        private void btnFileLocationBrowser_Click(object sender, EventArgs e)
        {
            if (ofdFileOpen.ShowDialog() == DialogResult.OK)
                txtFileLocation.Text = ofdFileOpen.FileName;
        }





        private void btnPOA_Click(object sender, EventArgs e)
        {
            DataTable POA_OR_Nominee = new DataTable();

            DataColumn CustID = new DataColumn("CustID", typeof(string));
            DataColumn Col1 = new DataColumn("BoID", typeof(string));
            DataColumn Col2 = new DataColumn("ColumnName", typeof(string));
            DataColumn Col3 = new DataColumn("ColumnValue", typeof(string));
            POA_OR_Nominee.Columns.Add(CustID);
            POA_OR_Nominee.Columns.Add(Col1);
            POA_OR_Nominee.Columns.Add(Col2);
            POA_OR_Nominee.Columns.Add(Col3);

            
            //Find Out How many row is GridView
            var totalSteps = this.dgdAdditionalView.Rows.Count;

            List<string> QueryList = new List<string>();
            int Checkboxflag = 0;

            //Read GridView Data
            for (int i = 0; i < totalSteps; i++)
            {
                //is Checkbox Mark
                bool isSelect = Convert.ToBoolean(dgdAdditionalView.Rows[i].Cells["IID"].Value);
                string CustCode = dgdAdditionalView.Rows[i].Cells["CustID"].Value.ToString(); 
                string Boid=dgdAdditionalView.Rows[i].Cells["BoID"].Value.ToString();
                string ColumnName=dgdAdditionalView.Rows[i].Cells["ColumnName"].Value.ToString();
                string ColumnValue=dgdAdditionalView.Rows[i].Cells["ColumnValue"].Value.ToString();

                if (isSelect)
                {
                    Checkboxflag = 1;
                    string Query = POA_OR_NomineeQueryCreate("POA", Boid, ColumnName, ColumnValue);
                    QueryList.Add(Query);
                }
                else
                {
                    
                    //add Data table
                    POA_OR_Nominee.Rows.Add(CustCode, Boid, ColumnName, ColumnValue);
                }
            } //end for loop

            if (Checkboxflag == 0)
            {
                MessageBox.Show("Please Select row from Table");
              
            }
            else
            {
                SaveInDatabase(QueryList, "Power of Attorney information modify successfully");
               
            }


                GridViewDataShow(POA_OR_Nominee);

            if (this.dgdAdditionalView.Rows.Count < 1)
            {
                groupBox2.Visible = false;
                groupBox3.Location = new Point(12, 81);
                this.Height = 294;
            }

        }





        private void btnNominee_Click(object sender, EventArgs e)
        {
            DataTable POA_OR_Nominee = new DataTable();

            DataColumn CustID = new DataColumn("CustID", typeof(string));
            DataColumn Col1 = new DataColumn("BoID", typeof(string));
            DataColumn Col2 = new DataColumn("ColumnName", typeof(string));
            DataColumn Col3 = new DataColumn("ColumnValue", typeof(string));
            POA_OR_Nominee.Columns.Add(CustID);
            POA_OR_Nominee.Columns.Add(Col1);
            POA_OR_Nominee.Columns.Add(Col2);
            POA_OR_Nominee.Columns.Add(Col3);


            //Find Out How many row is GridView
            var totalSteps = this.dgdAdditionalView.Rows.Count;

            List<string> QueryList = new List<string>();
            int Checkboxflag = 0;
            //Read GridView Data
            for (int i = 0; i < totalSteps; i++)
            {
                //is Checkbox Mark
                bool isSelect = Convert.ToBoolean(dgdAdditionalView.Rows[i].Cells["IID"].Value);
                string CustCode = dgdAdditionalView.Rows[i].Cells["CustID"].Value.ToString(); 
                string Boid = dgdAdditionalView.Rows[i].Cells["BoID"].Value.ToString();
                string ColumnName = dgdAdditionalView.Rows[i].Cells["ColumnName"].Value.ToString();
                string ColumnValue = dgdAdditionalView.Rows[i].Cells["ColumnValue"].Value.ToString();

                if (isSelect)
                {
                    Checkboxflag = 1;
                    string Query = POA_OR_NomineeQueryCreate("Nominee1", Boid, ColumnName, ColumnValue);
                    QueryList.Add(Query);
                }
                else
                {
                    //add Data table
                    POA_OR_Nominee.Rows.Add(CustCode, Boid, ColumnName, ColumnValue);
                }
            } //end for loop

            if (Checkboxflag == 0)
            {
                MessageBox.Show("Please Select row from Table");

            }
            else
            {
                SaveInDatabase(QueryList, "Nominee information update successfully");
            }
            GridViewDataShow(POA_OR_Nominee);

            if (this.dgdAdditionalView.Rows.Count < 1)
            {
                groupBox2.Visible = false;
                groupBox3.Location = new Point(12, 81);
                this.Height = 294;
            }



        }






        private void btnNominee2_Click(object sender, EventArgs e)
        {

            DataTable POA_OR_Nominee = new DataTable();

            DataColumn CustID = new DataColumn("CustID", typeof(string));
            DataColumn Col1 = new DataColumn("BoID", typeof(string));
            DataColumn Col2 = new DataColumn("ColumnName", typeof(string));
            DataColumn Col3 = new DataColumn("ColumnValue", typeof(string));
            POA_OR_Nominee.Columns.Add(CustID);
            POA_OR_Nominee.Columns.Add(Col1);
            POA_OR_Nominee.Columns.Add(Col2);
            POA_OR_Nominee.Columns.Add(Col3);


            //Find Out How many row is GridView
            var totalSteps = this.dgdAdditionalView.Rows.Count;

            List<string> QueryList = new List<string>();
            int Checkboxflag = 0;
            //Read GridView Data
            for (int i = 0; i < totalSteps; i++)
            {
                //is Checkbox Mark
                bool isSelect = Convert.ToBoolean(dgdAdditionalView.Rows[i].Cells["IID"].Value);
                string CustCode = dgdAdditionalView.Rows[i].Cells["CustID"].Value.ToString(); 
                string Boid = dgdAdditionalView.Rows[i].Cells["BoID"].Value.ToString();
                string ColumnName = dgdAdditionalView.Rows[i].Cells["ColumnName"].Value.ToString();
                string ColumnValue = dgdAdditionalView.Rows[i].Cells["ColumnValue"].Value.ToString();

                if (isSelect)
                {
                    Checkboxflag = 1;
                    string Query = POA_OR_NomineeQueryCreate("Nominee2", Boid, ColumnName, ColumnValue);
                    QueryList.Add(Query);
                }
                else
                {
                    //add Data table
                    POA_OR_Nominee.Rows.Add(CustCode, Boid, ColumnName, ColumnValue);
                }
            } //end for loop
            if (Checkboxflag == 0)
            {
                MessageBox.Show("Please Select row from Table");

            }
            else
            {
                SaveInDatabase(QueryList, "Nominee2 information update successfully");
            }
            GridViewDataShow(POA_OR_Nominee);

            if (this.dgdAdditionalView.Rows.Count < 1)
            {
                groupBox2.Visible = false;
                groupBox3.Location = new Point(12, 81);
                this.Height = 294;
            }


        }//end method





        //private string GetModifyQuery(string columnName, string modValue, string boId)
        //{
        //    CommonBAL objBal = new CommonBAL();
        //    bool boidFound = false;
        //    string queryString = "";
        //    CustomerBO customerBo = new CustomerBO();

        //    switch (columnName)
        //    {

        //        case Indication_ModifyAccountHolder_FieldDescription.C1047:
        //            queryString = "UPDATE SBP_Cust_Personal_Info SET First_Name='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Personal_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.BO_TITLE:
        //            queryString = "UPDATE SBP_Cust_Personal_Info SET First_Name='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Personal_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.BO_MIDDLE_NAME:
        //            queryString = "UPDATE SBP_Cust_Personal_Info SET Middle_Name='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Personal_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.BO_LAST_NAME:
        //            queryString = "UPDATE SBP_Cust_Personal_Info SET Last_Name='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Personal_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.SHORT_NAME:
        //            queryString = "UPDATE SBP_Cust_Personal_Info SET Cust_Name='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Personal_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.BO_FATHER_HUSBAND:
        //            queryString = "UPDATE SBP_Cust_Personal_Info SET Father_Name='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Personal_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.BO_MOTHER_NAME:
        //            queryString = "UPDATE SBP_Cust_Personal_Info SET Mother_Name='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Personal_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.OCCUPATION:
        //            queryString = "UPDATE SBP_Cust_Personal_Info SET Occupation='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Personal_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.ADDR_1:
        //            queryString = "UPDATE SBP_Cust_Contact_Info SET Address1='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Contact_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.ADDR_2:
        //            queryString = "UPDATE SBP_Cust_Contact_Info SET Address2='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Contact_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.ADDR_3:
        //            queryString = "UPDATE SBP_Cust_Contact_Info SET Address3='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Contact_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.PHONE_1:
        //            queryString = "UPDATE SBP_Cust_Contact_Info SET Mobile='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Contact_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.PHONE_2:
        //            queryString = "UPDATE SBP_Cust_Contact_Info SET Phone='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Contact_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.BO_EMAIL:
        //            queryString = "UPDATE SBP_Cust_Contact_Info SET Email='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Contact_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.BO_FAX:
        //            queryString = "UPDATE SBP_Cust_Contact_Info SET Fax='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Contact_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.POSTAL_CODE:
        //            queryString = "UPDATE SBP_Cust_Contact_Info SET Post_Code='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Contact_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.CITY:
        //            queryString = "UPDATE SBP_Cust_Contact_Info SET City_Name='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Contact_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.STATE:
        //            queryString = "UPDATE SBP_Cust_Contact_Info SET Division_Name='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Contact_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.CNTRY:
        //            queryString = "UPDATE SBP_Cust_Contact_Info SET Country_Name='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Contact_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.PASSPORT_NUMB:
        //            queryString = "UPDATE SBP_Cust_Passport_Info SET Passport_No='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Passport_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.PASSPORT_ISSUE_PLACE:
        //            queryString = "UPDATE SBP_Cust_Passport_Info SET Issue_Place='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Passport_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.TAX_ID_NUMB:
        //            queryString = "UPDATE SBP_Cust_Bank_Info SET TIN='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Bank_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.ELEC_DIVIDEND:
        //            queryString = "UPDATE SBP_Cust_Bank_Info SET Is_EDC=" + (Convert.ToInt16(modValue == "Y")) + " FROM SBP_Customers WHERE SBP_Cust_Bank_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.BANK_NAME:
        //            //queryString = "UPDATE SBP_Cust_Bank_Info SET Bank_Name='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Bank_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";

        //            var BankName_Temp = new ModBo() { DATE = objBal.GetCurrentServerDate(), BOID = boId, BANKNAME = modValue.Trim(), BRNACHNAME = string.Empty, ROUTINGNO = string.Empty };
        //            CustBankBranchRoutingList.Add(BankName_Temp);
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.BANK_BRNCH_NAME:
        //            //queryString = "UPDATE SBP_Cust_Bank_Info SET Branch_Name='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Bank_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            customerBo.BoId = boId;
        //            customerBo.BranchName = modValue.Trim();

        //            var BranchName_Temp = new ModBo() { DATE = objBal.GetCurrentServerDate(), BOID = boId, BANKNAME = string.Empty, BRNACHNAME = modValue.Trim(), ROUTINGNO = string.Empty };
        //            //CustBankBranchRoutingList.Add(customerBo);
        //            CustBankBranchRoutingList.Add(BranchName_Temp);
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.BANK_ACCT_NUMB:
        //            queryString = "UPDATE SBP_Cust_Bank_Info SET Account_No='" + modValue + "' FROM SBP_Customers WHERE SBP_Cust_Bank_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.Bank_Routing_Number:
        //            //queryString = "UPDATE SBP_Cust_Bank_Info SET Routing_No='" + modValue + "' FROM SBP_Customers WHERE  SBP_Cust_Bank_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";

        //            var RoutingNo_Temp = new ModBo() { DATE = objBal.GetCurrentServerDate(), BOID = boId, BANKNAME = string.Empty, BRNACHNAME = string.Empty, ROUTINGNO = modValue.Trim() };
        //            CustBankBranchRoutingList.Add(RoutingNo_Temp);
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.International_Bank_Account_Number:
        //            queryString = "UPDATE SBP_Cust_Bank_Info SET IBAN='" + modValue + "' FROM SBP_Customers WHERE  SBP_Cust_Bank_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.Bank_Swift_Code:
        //            queryString = "UPDATE SBP_Cust_Bank_Info SET SWIFT_Code='" + modValue + "' FROM SBP_Customers WHERE  SBP_Cust_Bank_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //        case Indication_ModifyAccountHolder_FieldDescription.District_Name:
        //            queryString = "UPDATE SBP_Cust_Bank_Info SET District_Name='" + modValue + "' WHERE  SBP_Cust_Bank_Info.Cust_Code=SBP_Customers.Cust_Code and SBP_Customers.BO_ID='" + boId + "';";
        //            break;
        //    }
        //    return queryString;
        //}


    }
}
