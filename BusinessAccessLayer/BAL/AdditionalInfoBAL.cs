using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;
using System.Data.SqlClient;

namespace BusinessAccessLayer.BAL
{
    public class AdditionalInfoBAL
    {
        private DbConnection _dbConnection;


        public AdditionalInfoBAL()
        {
            _dbConnection = new DbConnection();
        }

        public void ConnectDatabase()
        {
            _dbConnection.ConnectDatabase();
            _dbConnection.ClearParameters();
            _dbConnection.StartTransaction();
        }

        public void ClearTransaction()
        {

        }

        public void CloseDatabase()
        {
            _dbConnection.CloseDatabase();
        }

        public void Commit()
        {
            _dbConnection.Commit();
        }

        public void RollBack()
        {
            _dbConnection.Rollback();
        }

        public SqlTransaction GetTransaction()
        {
            return _dbConnection.GetTransaction();
        }
        public void SetTransaction(SqlTransaction trans)
        {
            _dbConnection.SetTransaction(trans);
        }

       
        public void ProcessDatabase(AdditionalInfoBO additionalInfoBo)
        {
            string QueryString = "";
           // additionalInfoBo.CustCode = new CommonBAL().GetIdByName( "", "BO_Type_ID", "BO_Type", "SBP_BO_Type");

            switch (additionalInfoBo.PurposeCode)
            {
                case "Power of Attorney":
                    QueryString = "INSERT INTO SBP_POA(Cust_Code,Name,Address,City,Post_Code,Division,Country,Phone,Fax,Email,Passport_No,Issue_Place,Issue_Date,Expire_Date,Effective_From,Effective_To,Entry_Date,Entry_By)" +
                @" VALUES(
                '" + additionalInfoBo.CustCode + @"'
                ,'" + additionalInfoBo.AdditionalHolderName + @"'
                ,'" + additionalInfoBo.Address1 + " " + additionalInfoBo.Address2 + " " + additionalInfoBo.Address3 + @"'
                ,'" + additionalInfoBo.City + @"'
                ,'" + additionalInfoBo.PostCode + @"'
                ,'" + additionalInfoBo.Division + @"'
                ,'" + additionalInfoBo.Country + @"'
                ,'" + additionalInfoBo.Phone + @"'
                ,'" + additionalInfoBo.Fax + @"'
                ,'" + additionalInfoBo.Email + @"'
                ,'" + additionalInfoBo.PassportNo + @"'
                ,'" + additionalInfoBo.PassportIssuePlace + @"'
                ," + Convert.ToString(additionalInfoBo.PassportIssueDate == DateTime.MinValue ? "NULL" : "'" + additionalInfoBo.PassportIssueDate.ToString("MM-dd-yyyy") + "'") + @"
                ," + Convert.ToString(additionalInfoBo.PassportExpireDate == DateTime.MinValue ? "NULL" : "'" + additionalInfoBo.PassportExpireDate.ToString("MM-dd-yyyy") + "'") + @"
                ,'" + additionalInfoBo.EffetiveFrom.ToString("MM-dd-yyyy") + @"'
                ,'" + additionalInfoBo.EffectiveTo.ToString("MM-dd-yyyy") + @"'
                ," + Convert.ToString(additionalInfoBo.EntryDate == DateTime.MinValue ? "NULL" : "'" + additionalInfoBo.EntryDate.ToString("MM-dd-yyyy") + "'") + @"
                ,'" +GlobalVariableBO._userName+"')";

                    break;
                    //**********************Confusion******************
                case "Nominee":
                //case "Heir":
                    if (additionalInfoBo.SerialNo == "1")
                    {
                        QueryString = "INSERT INTO SBP_Nominee1(Cust_Code, Name,Address,City,Post_Code,Division,Country,Phone,Fax,Email,Passport_No,Issue_Place,Issue_Date,Expire_Date,Relationship,Percentage,Entry_Date,Entry_By)" +
               @" VALUES(
                        '" + additionalInfoBo.CustCode + @"'
                        ,'" + additionalInfoBo.AdditionalHolderName + @"'
                        ,'" + additionalInfoBo.Address1 + " " + additionalInfoBo.Address2 + " " + additionalInfoBo.Address3 + @"'
                        ,'" + additionalInfoBo.City + @"'
                        ,'" + additionalInfoBo.PostCode + @"'
                        ,'" + additionalInfoBo.Division + @"'
                        ,'" + additionalInfoBo.Country + @"'
                        ,'" + additionalInfoBo.Phone + @"'
                        ,'" + additionalInfoBo.Fax + @"'
                        ,'" + additionalInfoBo.Email + @"'
                        ,'" + additionalInfoBo.PassportNo + @"'
                        ,'" + additionalInfoBo.PassportIssuePlace + @"'
                        ,"+Convert.ToString(additionalInfoBo.PassportIssueDate==DateTime.MinValue?"NULL":"'"+additionalInfoBo.PassportIssueDate.ToString("MM-dd-yyyy") + "'")+@"
                        ," + Convert.ToString(additionalInfoBo.PassportExpireDate == DateTime.MinValue ? "NULL" : "'" + additionalInfoBo.PassportExpireDate.ToString("MM-dd-yyyy") + "'") + @"
                        ,'" + additionalInfoBo.RelationShip + @"'
                        ," + additionalInfoBo.Percentage + @"
                        ," + Convert.ToString(additionalInfoBo.EntryDate == DateTime.MinValue ? "NULL" : "'" + additionalInfoBo.EntryDate.ToString("MM-dd-yyyy") + "'") + @"
                        ,'" + GlobalVariableBO._userName + "')";


                    }
                    else
                    {
                        QueryString = "INSERT INTO SBP_Nominee2(Cust_Code, Name,Address,City,Post_Code,Division,Country,Phone,Fax,Email,Passport_No,Issue_Place,Issue_Date,Expire_Date,Relationship,Percentage,Entry_Date,Entry_By)" +
              @" VALUES(
                    '" + additionalInfoBo.CustCode + @"'
                    ,'" + additionalInfoBo.AdditionalHolderName + @"'
                    ,'" + additionalInfoBo.Address1 + " " + additionalInfoBo.Address2 + " " + additionalInfoBo.Address3 + @"'
                    ,'" + additionalInfoBo.City + @"'
                    ,'" + additionalInfoBo.PostCode + @"'
                    ,'" + additionalInfoBo.Division + @"'
                    ,'" + additionalInfoBo.Country + @"'
                    ,'" + additionalInfoBo.Phone + @"'
                    ,'" + additionalInfoBo.Fax + @"'
                    ,'" + additionalInfoBo.Email + @"'
                    ,'" + additionalInfoBo.PassportNo + @"'
                    ,'" + additionalInfoBo.PassportIssuePlace + @"'
                    ," + Convert.ToString(additionalInfoBo.PassportIssueDate == DateTime.MinValue ? "NULL" : "'" + additionalInfoBo.PassportIssueDate.ToString("MM-dd-yyyy") + "'") + @"
                    ," + Convert.ToString(additionalInfoBo.PassportExpireDate == DateTime.MinValue ? "NULL" : "'" + additionalInfoBo.PassportExpireDate.ToString("MM-dd-yyyy") + "'") + @"
                    ,'" + additionalInfoBo.RelationShip + @"'
                    ," + additionalInfoBo.Percentage + @"
                    ," + Convert.ToString(additionalInfoBo.EntryDate == DateTime.MinValue ? "NULL" : "'" + additionalInfoBo.EntryDate.ToString("MM-dd-yyyy") + "'") + @"
                    ,'" + GlobalVariableBO._userName + "')";


                    }
                    break;
                case "Guardian":
                    if (additionalInfoBo.SerialNo == "1")
                    {
                        QueryString = "INSERT INTO SBP_Guardian1(Cust_Code, Name,Address,City,Post_Code,Division,Country,Phone,Fax,Email,Passport_No,Issue_Place,Issue_Date,Expire_Date,Relationship,Entry_Date,Entry_By)" +
                            @" VALUES(
                        '" + additionalInfoBo.CustCode + @"'
                        ,'" + additionalInfoBo.AdditionalHolderName + @"'
                        ,'" + additionalInfoBo.Address1 + " " + additionalInfoBo.Address2 + " " + additionalInfoBo.Address3 + @"'
                        ,'" + additionalInfoBo.City + @"'
                        ,'" + additionalInfoBo.PostCode + @"'
                        ,'" + additionalInfoBo.Division + @"'
                        ,'" + additionalInfoBo.Country + @"'
                        ,'" + additionalInfoBo.Phone + @"'
                        ,'" + additionalInfoBo.Fax + @"'
                        ,'" + additionalInfoBo.Email + @"'
                        ,'" + additionalInfoBo.PassportNo + @"'
                        ,'" + additionalInfoBo.PassportIssuePlace + @"'
                        ," + Convert.ToString(additionalInfoBo.PassportIssueDate == DateTime.MinValue ? "NULL" : "'" + additionalInfoBo.PassportIssueDate.ToString("MM-dd-yyyy") + "'") + @"
                        ," + Convert.ToString(additionalInfoBo.PassportExpireDate == DateTime.MinValue ? "NULL" : "'" + additionalInfoBo.PassportExpireDate.ToString("MM-dd-yyyy") + "'") + @"
                        ,'" + additionalInfoBo.RelationShip + @"'
                        ," + Convert.ToString(additionalInfoBo.EntryDate == DateTime.MinValue ? "NULL" : "'" + additionalInfoBo.EntryDate.ToString("MM-dd-yyyy") + "'") + @"
                        ,'" + GlobalVariableBO._userName + "')";
                    }
                    else
                    {
                        QueryString = "INSERT INTO SBP_Guardian2(Cust_Code, Name,Address,City,Post_Code,Division,Country,Phone,Fax,Email,Passport_No,Issue_Place,Issue_Date,Expire_Date,Relationship,Entry_Date,Entry_By)" +
                             " VALUES('" + additionalInfoBo.CustCode + "','" + additionalInfoBo.AdditionalHolderName + "','" + additionalInfoBo.Address1 + " " + additionalInfoBo.Address2 + " " + additionalInfoBo.Address3 + "','" + additionalInfoBo.City + "','" + additionalInfoBo.PostCode + "','" + additionalInfoBo.Division + "','" + additionalInfoBo.Country + "','" + additionalInfoBo.Phone + "','" + additionalInfoBo.Fax + "','" + additionalInfoBo.Email + "','" + additionalInfoBo.PassportNo + "','" + additionalInfoBo.PassportIssuePlace + "','" + additionalInfoBo.PassportIssueDate.ToShortDateString() + "','" + additionalInfoBo.PassportExpireDate.ToShortDateString() + "','" + additionalInfoBo.RelationShip + "','" + additionalInfoBo.EntryDate.ToShortDateString() + "','" + GlobalVariableBO._userName + "')";


                    }
                    break;
            }

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.StartTransaction();
                _dbConnection.ExecuteNonQuery(QueryString);
                _dbConnection.Commit();
            }
            catch (Exception exception)
            {
               _dbConnection.Rollback();
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
        public string GetCustCodeByBOID(string boId)
        {
            string queryString = @"SELECT Cust_Code FROM SBP_Customers WHERE BO_ID='" + boId.Substring(8,8) + "';";
            DataTable dataTable;
            string custCode = "";
            try
            {
                _dbConnection.ConnectDatabase();
                dataTable = _dbConnection.ExecuteQuery(queryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            if (dataTable.Rows.Count > 0)
                custCode = dataTable.Rows[0]["Cust_Code"].ToString();
            return custCode;
        }
    }

}
