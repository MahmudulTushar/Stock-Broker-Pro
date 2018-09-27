using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BusinessAccessLayer.BO;
using DataAccessLayer;
using BusinessAccessLayer.Constants;
using System.Linq;


namespace BusinessAccessLayer.BAL
{
    public class SingleImageBAL
    {
        CommonBAL cmnBAL = new CommonBAL();
        // public bool _IsUpdateImg;

        private DbConnection _dbConnection;
        public SingleImageBAL()
        {
            _dbConnection = new DbConnection();
        }

        private bool _IsExistImage = false;

        public bool IsExistImage
        {
            get { return _IsExistImage; }
            set { _IsExistImage = value; }
        }

        //Single Photo UpLoad
        public void SaveToDatabase(SingleImageBO singleImageBo)
        {

            string qry = "";

            string qry_ImgExt = "";
            string cheeckQuery = "";
            string tableName = string.Empty;
            string tableName_ImgExt = string.Empty;


            DataTable dataTable = new DataTable();

            switch (singleImageBo.ImageSelectionMode)
            {
                case "1st Account Holder":
                    tableName =
                        Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Cust_Image").
                            SingleOrDefault().Key;
                    tableName_ImgExt =
                        Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Cust_Image").
                            SingleOrDefault().Value;
                    try
                    {
                        if (IsExistPhoto(singleImageBo))
                        {
                            qry = "UPDATE " + tableName +
                                  " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                  singleImageBo.CustCode + "';";
                        }
                        else
                        {
                            qry = "insert into " + tableName_ImgExt +
                                  " ([Cust_Code],[Photo],Update_Date) values(@CustCode,@ImageData,@Update_Date)";
                        }
                    }
                    catch (Exception ex)
                    {
                        qry = string.Empty;
                    }

                    try
                    {
                        if (IsExistPhoto_ImgExt((singleImageBo)))
                        {
                            qry_ImgExt = "UPDATE " + tableName_ImgExt +
                                         " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                         singleImageBo.CustCode + "';";
                        }
                        else
                        {
                            qry_ImgExt = "insert into " + tableName_ImgExt +
                                         " ([Cust_Code],[Photo],Update_Date) values(@CustCode,@ImageData,@Update_Date)";
                        }
                    }
                    catch (Exception ex)
                    {
                        qry_ImgExt = string.Empty;
                    }

                    SqlParm(qry, qry_ImgExt, singleImageBo);
                    break;

                case "2nd Account Holder":
                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Joint_holder_Image");
                    tableName =
                        Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Joint_holder_Image").
                            SingleOrDefault().Key;
                    tableName_ImgExt =
                        Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Joint_holder_Image").
                           SingleOrDefault().Value;

                    try
                    {
                        if (IsExistPhoto(singleImageBo))
                        {
                            qry = "UPDATE " + tableName +
                                  " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                  singleImageBo.CustCode + "';";
                        }
                        else
                        {
                            qry = "insert into " + tableName_ImgExt +
                                  " ([Cust_Code],[Photo],Update_Date) values(@CustCode,@ImageData,@Update_Date)";
                        }
                    }
                    catch (Exception ex)
                    {
                        qry = string.Empty;
                    }

                    try
                    {
                        if (IsExistPhoto_ImgExt(singleImageBo))
                        {
                            qry_ImgExt = "UPDATE " + tableName_ImgExt +
                                         " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                         singleImageBo.CustCode + "';";
                        }
                        else
                        {
                            qry_ImgExt = "insert into " + tableName_ImgExt +
                                         " ([Cust_Code],[Photo],Update_Date) values(@CustCode,@ImageData,@Update_Date)";
                        }
                    }
                    catch (Exception ex)
                    {
                        qry_ImgExt = string.Empty;
                    }

                    SqlParm(qry, qry_ImgExt, singleImageBo);
                    break;

                case "Nominee1":
                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee1_Image");
                    tableName =
                        Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee1_Image").
                            SingleOrDefault().Key;
                    tableName_ImgExt =
                        Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee1_Image").
                            SingleOrDefault().Value;
                    try
                    {
                        if (IsExistPhoto(singleImageBo))
                        {

                            qry = "UPDATE " + tableName +
                                  " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                  singleImageBo.CustCode + "';";
                        }
                        else
                        {

                            qry = "insert into " + tableName +
                                  " ([Cust_Code],[Photo],Update_Date) values(@CustCode,@ImageData,@Update_Date)";
                        }
                    }
                    catch (Exception ex)
                    {
                        qry = string.Empty;
                    }
                    try
                    {
                        if (IsExistPhoto_ImgExt(singleImageBo))
                        {
                            qry_ImgExt = "UPDATE " + tableName_ImgExt +
                                         " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                         singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry_ImgExt = "insert into " + tableName_ImgExt +
                                         " ([Cust_Code],[Photo],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ey)
                    {
                        qry_ImgExt = string.Empty;

                    }

                    SqlParm(qry, qry_ImgExt, singleImageBo);
                    break;

                case "Nominee2":
                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee2_Image");
                    tableName =
                        Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee2_Image").
                            SingleOrDefault().Key;
                    tableName_ImgExt =
                        Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee2_Image").
                            SingleOrDefault().Value;
                    try
                    {
                        if (IsExistPhoto(singleImageBo))
                        {

                            qry = "UPDATE " + tableName + " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                  singleImageBo.CustCode + "';";
                        }
                        else
                        {

                            qry = "insert into " + tableName +
                                  " ([Cust_Code],[Photo],Update_Date) values(@CustCode,@ImageData,@Update_Date)";
                        }

                    }
                    catch (Exception ex)
                    {
                        qry = string.Empty;
                    }

                    try
                    {
                        if (IsExistPhoto_ImgExt(singleImageBo))
                        {
                            qry_ImgExt = "UPDATE " + tableName_ImgExt +
                                         " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                         singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry_ImgExt = "insert into " + tableName_ImgExt +
                                         " ([Cust_Code],[Photo],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ey)
                    {

                        qry_ImgExt = string.Empty;
                    }

                    SqlParm(qry, qry_ImgExt, singleImageBo);
                    break;

                case "Guardian1":
                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian1_Image");
                    tableName =
                        Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian1_Image").
                            SingleOrDefault().Key;
                    tableName_ImgExt =
                        Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian1_Image").
                            SingleOrDefault().Value;

                    try
                    {
                        if (IsExistPhoto(singleImageBo))
                        {
                            qry = "UPDATE " + tableName +
                                  " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                  singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry = "insert into " + tableName +
                                  "([Cust_Code],[Photo],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry = string.Empty;
                    }

                    try
                    {
                        if (IsExistPhoto_ImgExt(singleImageBo))
                        {
                            qry_ImgExt = "UPDATE " + tableName_ImgExt +
                                         " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                         singleImageBo.CustCode + "';";


                        }
                        else
                        {
                            qry_ImgExt = "insert into " + tableName_ImgExt +
                                         " ([Cust_Code],[Photo],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry_ImgExt = string.Empty;
                    }


                    SqlParm(qry, qry_ImgExt, singleImageBo);
                    break;

                case "Guardian2":
                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian2_Image");
                    tableName =
                        Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian2_Image").
                            SingleOrDefault().Key;
                    tableName_ImgExt =
                        Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian2_Image").
                            SingleOrDefault().Value;

                    try
                    {
                        if (IsExistPhoto(singleImageBo))
                        {
                            qry = "UPDATE " + tableName +
                                  " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                  singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry = "insert into " + tableName +
                                  " ([Cust_Code],[Photo],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry = string.Empty;
                    }

                    try
                    {
                        if (IsExistPhoto_ImgExt(singleImageBo))
                        {
                            qry_ImgExt = "UPDATE " + tableName_ImgExt +
                                         " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                         singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry_ImgExt = "insert into " + tableName_ImgExt +
                                         " ([Cust_Code],[Photo],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry_ImgExt = string.Empty;
                    }


                    SqlParm(qry, qry_ImgExt, singleImageBo);
                    break;

                case "POA":
                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_POA_Image");
                    tableName =
                        Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_POA_Image").
                            SingleOrDefault().Key;
                    tableName_ImgExt =
                        Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_POA_Image").
                            SingleOrDefault().Value;
                    try
                    {
                        if (IsExistPhoto(singleImageBo))
                        {
                            qry = "UPDATE " + tableName +
                                  " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                  singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry = "insert into " + tableName +
                                  " ([Cust_Code],[Photo],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry = string.Empty;
                    }

                    try
                    {
                        if (IsExistPhoto_ImgExt(singleImageBo))
                        {
                            qry_ImgExt = "UPDATE " + tableName_ImgExt +
                                         " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                         singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry_ImgExt = "insert into " + tableName_ImgExt +
                                         " ([Cust_Code],[Photo],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry_ImgExt = string.Empty;
                    }



                    SqlParm(qry, qry_ImgExt, singleImageBo);
                    break;

                case "Author":
                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Author_Image");
                    tableName =
                        Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Author_Image").
                            SingleOrDefault().Key;
                    tableName_ImgExt =
                        Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Author_Image").
                            SingleOrDefault().Value;
                    try
                    {
                        if (IsExistPhoto(singleImageBo))
                        {
                            qry = "UPDATE " + tableName +
                                  " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                  singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry = "insert into " + tableName +
                                  " ([Cust_Code],[Photo],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry = string.Empty;
                    }

                    try
                    {
                        if (IsExistPhoto_ImgExt(singleImageBo))
                        {
                            qry_ImgExt = "UPDATE " + tableName_ImgExt +
                                         " SET Photo=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                         singleImageBo.CustCode + "';";

                        }
                        else
                        {

                            qry_ImgExt = "insert into " + tableName_ImgExt +
                                         " ([Cust_Code],[Photo],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry_ImgExt = string.Empty;
                    }



                    SqlParm(qry, qry_ImgExt, singleImageBo);
                    break;

                default:
                    break;
            }

        }

        public bool IsExistPhoto(SingleImageBO singleImageBo)
        {

            string cheeckQuery = "";
            string cheeckQuery_ImgExt = "";
            bool IsExistPhoto = false;
            string tableName = string.Empty;
            string tableName_ImgExt = string.Empty;
            switch (singleImageBo.ImageSelectionMode)
            {
                case "1st Account Holder":
                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Cust_Image");
                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Cust_Image").SingleOrDefault().Key;

                    cheeckQuery = "Select Cust_Code,Photo from " + tableName + " where Cust_Code='" +
                                  singleImageBo.CustCode + "';";
                    IsExistPhoto = CheckExistingPhoto(cheeckQuery);
                    break;

                case "2nd Account Holder":
                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Joint_holder_Image");
                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Joint_holder_Image").SingleOrDefault().Key;
                    cheeckQuery =
                        "Select Cust_Code,Photo from " + tableName + " where Cust_Code='" +
                        singleImageBo.CustCode + "';";


                    IsExistPhoto = CheckExistingPhoto(cheeckQuery);
                    break;

                case "Nominee1":
                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee1_Image");
                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee1_Image").SingleOrDefault().Key;

                    cheeckQuery = "Select Cust_Code,Photo from " + tableName + " where Cust_Code='" +
                                  singleImageBo.CustCode + "';";


                    IsExistPhoto = CheckExistingPhoto(cheeckQuery);
                    break;

                case "Nominee2":
                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee2_Image");
                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee2_Image").SingleOrDefault().Key;

                    cheeckQuery = "Select Cust_Code,Photo from " + tableName + " where Cust_Code='" +
                                  singleImageBo.CustCode + "';";

                    IsExistPhoto = CheckExistingPhoto(cheeckQuery);
                    break;

                case "Guardian1":
                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian1_Image");
                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian1_Image").SingleOrDefault().Key;

                    cheeckQuery = "Select Cust_Code,Photo from " + tableName + " where Cust_Code='" +
                                  singleImageBo.CustCode + "';";
                    IsExistPhoto = CheckExistingPhoto(cheeckQuery);
                    break;

                case "Guardian2":
                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian2_Image");
                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian2_Image").SingleOrDefault().Key;

                    cheeckQuery = "Select Cust_Code,Photo from " + tableName + " where Cust_Code='" +
                                  singleImageBo.CustCode + "';";
                    IsExistPhoto = CheckExistingPhoto(cheeckQuery);
                    break;

                case "POA":
                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_POA_Image");
                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_POA_Image").SingleOrDefault().Key;

                    cheeckQuery = "Select Cust_Code,Photo from " + tableName + " where Cust_Code='" +
                                  singleImageBo.CustCode + "';";
                    IsExistPhoto = CheckExistingPhoto(cheeckQuery);
                    break;

                case "Author":
                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Author_Image");
                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Author_Image").SingleOrDefault().Key;

                    cheeckQuery = "Select Cust_Code,Photo from " + tableName + " where Cust_Code='" +
                                  singleImageBo.CustCode + "';";
                    IsExistPhoto = CheckExistingPhoto(cheeckQuery);
                    break;

                default:
                    IsExistPhoto = false;
                    break;
            }

            return IsExistPhoto;

        }

        public bool IsExistPhoto_ImgExt(SingleImageBO singleImageBo)
        {

            string cheeckQuery = "";
            string cheeckQuery_ImgExt = "";
            bool IsExistPhoto = false;
            string tableName = string.Empty;
            string tableName_ImgExt = string.Empty;
            switch (singleImageBo.ImageSelectionMode)
            {
                case "1st Account Holder":
                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Cust_Image");
                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Cust_Image").SingleOrDefault().Value;

                    cheeckQuery_ImgExt = "Select Cust_Code,Photo from " + tableName_ImgExt + " where Cust_Code='" +
                                  singleImageBo.CustCode + "';";

                    IsExistPhoto = CheckExistingPhoto_ImgExt(cheeckQuery_ImgExt);
                    break;

                case "2nd Account Holder":
                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Joint_holder_Image");
                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Joint_holder_Image").SingleOrDefault().Value;

                    cheeckQuery_ImgExt =
                        "Select Cust_Code,Photo from " + tableName_ImgExt + " where Cust_Code='" +
                        singleImageBo.CustCode + "';";

                    IsExistPhoto = CheckExistingPhoto_ImgExt(cheeckQuery_ImgExt);
                    break;

                case "Nominee1":
                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee1_Image");
                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee1_Image").SingleOrDefault().Value;

                    cheeckQuery_ImgExt =
                        "Select Cust_Code,Photo from " + tableName_ImgExt + " where Cust_Code='" +
                        singleImageBo.CustCode + "';";

                    IsExistPhoto = CheckExistingPhoto_ImgExt(cheeckQuery_ImgExt);
                    break;

                case "Nominee2":
                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee2_Image");
                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee2_Image").SingleOrDefault().Value;

                    cheeckQuery_ImgExt = "Select Cust_Code,Photo from " + tableName_ImgExt + " where Cust_Code='" +
                                  singleImageBo.CustCode + "';";

                    IsExistPhoto = CheckExistingPhoto_ImgExt(cheeckQuery_ImgExt);
                    break;

                case "Guardian1":
                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian1_Image");
                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian1_Image").SingleOrDefault().Value;

                    cheeckQuery_ImgExt = "Select Cust_Code,Photo from " + tableName_ImgExt + " where Cust_Code='" +
                                  singleImageBo.CustCode + "';";
                    IsExistPhoto = CheckExistingPhoto_ImgExt(cheeckQuery_ImgExt);
                    break;

                case "Guardian2":
                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian2_Image");
                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian2_Image").SingleOrDefault().Value;

                    cheeckQuery_ImgExt = "Select Cust_Code,Photo from " + tableName_ImgExt + " where Cust_Code='" +
                                                      singleImageBo.CustCode + "';";
                    IsExistPhoto = CheckExistingPhoto_ImgExt(cheeckQuery_ImgExt);
                    break;

                case "POA":
                    //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_POA_Image");
                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_POA_Image").SingleOrDefault().Value;

                    cheeckQuery_ImgExt = "Select Cust_Code,Photo from " + tableName_ImgExt + " where Cust_Code='" +
                                  singleImageBo.CustCode + "';";
                    IsExistPhoto = CheckExistingPhoto_ImgExt(cheeckQuery_ImgExt);
                    break;

                case "Author":
                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Author_Image");
                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Author_Image").SingleOrDefault().Value;

                    cheeckQuery_ImgExt = "Select Cust_Code,Photo from " + tableName_ImgExt + " where Cust_Code='" +
                                  singleImageBo.CustCode + "';";
                    IsExistPhoto = CheckExistingPhoto_ImgExt(cheeckQuery_ImgExt);
                    break;

                default:
                    IsExistPhoto = false;
                    break;
            }

            return IsExistPhoto;

        }

        private bool CheckExistingPhoto(string queryString)
        {
            bool IsExistingPhoto = false;
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);

                if (data.Rows.Count > 0)
                {
                    IsExistingPhoto = true;
                }


            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return IsExistingPhoto;

        }

        private bool CheckExistingPhoto_ImgExt(string queryString_ImgExt)
        {
            bool IsExistingPhoto = false;
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase_ImageExt();
                data = _dbConnection.ExecuteQuery_ImageExt(queryString_ImgExt);

                if (data.Rows.Count > 0)
                {
                    IsExistingPhoto = true;
                }
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase_ImageExt();
            }

            return IsExistingPhoto;
        }

        public bool IsExistSignature(SingleImageBO singleImageBo)
        {

            string cheeckQuery = "";
            bool IsExistSignature = false;
            string tableName = string.Empty;

            try
            {
                switch (singleImageBo.ImageSelectionMode)
                {
                    case "1st Account Holder":
                        // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Cust_Image");
                        tableName =
                            Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Cust_Image").
                                SingleOrDefault().Key;

                        cheeckQuery = "Select Cust_Code,Signature from " + tableName + " where Cust_Code='" +
                                      singleImageBo.CustCode + "';";

                        IsExistSignature = CheckExistingSignasture(cheeckQuery);
                        break;

                    case "2nd Account Holder":
                        // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Joint_holder_Image");
                        tableName =
                            Indication_Fixed_DatabaseName.TableName_ImageExt.Where(
                                t => t.Key == "SBP_Joint_holder_Image").SingleOrDefault().Key;

                        cheeckQuery = "Select Cust_Code,Signature from " + tableName + " where Cust_Code='" +
                                      singleImageBo.CustCode + "';";

                        IsExistSignature = CheckExistingSignasture(cheeckQuery);
                        break;

                    case "Nominee1":
                        // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee1_Image");
                        tableName =
                            Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee1_Image").
                                SingleOrDefault().Key;

                        cheeckQuery = "Select Cust_Code,Signature from " + tableName + " where Cust_Code='" +
                                      singleImageBo.CustCode + "';";

                        IsExistSignature = CheckExistingSignasture(cheeckQuery);
                        break;

                    case "Nominee2":
                        //  tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee2_Image");
                        tableName =
                            Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee2_Image").
                                SingleOrDefault().Key;
                        cheeckQuery = "Select Cust_Code,Signature from " + tableName + " where Cust_Code='" +
                                      singleImageBo.CustCode + "';";

                        IsExistSignature = CheckExistingSignasture(cheeckQuery);
                        break;

                    case "Guardian1":
                        // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian1_Image");
                        tableName =
                            Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian1_Image").
                                SingleOrDefault().Key;

                        cheeckQuery = "Select Cust_Code,Signature from " + tableName + " where Cust_Code='" +
                                      singleImageBo.CustCode + "';";

                        IsExistSignature = CheckExistingSignasture(cheeckQuery);
                        break;

                    case "Guardian2":
                        //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian2_Image");
                        tableName =
                            Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian2_Image").
                                SingleOrDefault().Key;

                        cheeckQuery = "Select Cust_Code,Signature from " + tableName + " where Cust_Code='" +
                                      singleImageBo.CustCode + "';";

                        IsExistSignature = CheckExistingSignasture(cheeckQuery);
                        break;

                    case "POA":
                        //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_POA_Image");
                        tableName =
                            Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_POA_Image").
                                SingleOrDefault().Key;
                        cheeckQuery = "Select Cust_Code,Signature from " + tableName + " where Cust_Code='" +
                                      singleImageBo.CustCode + "';";

                        IsExistSignature = CheckExistingSignasture(cheeckQuery);
                        break;

                    case "Author":
                        // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Author_Image");
                        tableName =
                            Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Author_Image").
                                SingleOrDefault().Key;
                        cheeckQuery = "Select Cust_Code,Signature from " + tableName + " where Cust_Code='" +
                                      singleImageBo.CustCode + "';";

                        IsExistSignature = CheckExistingSignasture(cheeckQuery);
                        break;

                    default:
                        IsExistSignature = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                IsExistSignature = false;
            }

            return IsExistSignature;

        }

        public bool IsExistSignature_ImgExt(SingleImageBO singleImageBo)
        {

            string cheeckQuery_ImgExt = "";
            bool IsExistSignature = false;
            string tableName_ImgExt = string.Empty;

            try
            {
                switch (singleImageBo.ImageSelectionMode)
                {
                    case "1st Account Holder":
                        //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Cust_Image");
                        tableName_ImgExt =
                            Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Cust_Image").
                                SingleOrDefault().Value;

                        cheeckQuery_ImgExt = "Select Cust_Code,Signature from " + tableName_ImgExt +
                                             " where Cust_Code='" +
                                             singleImageBo.CustCode + "';";

                        IsExistSignature = CheckExistingSignasture_ImgExt(cheeckQuery_ImgExt);
                        break;

                    case "2nd Account Holder":
                        // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Joint_holder_Image");
                        tableName_ImgExt =
                            Indication_Fixed_DatabaseName.TableName_ImageExt.Where(
                                t => t.Key == "SBP_Joint_holder_Image").SingleOrDefault().Value;
                        cheeckQuery_ImgExt = "Select Cust_Code,Signature from " + tableName_ImgExt +
                                             " where Cust_Code='" +
                                             singleImageBo.CustCode + "';";

                        IsExistSignature = CheckExistingSignasture_ImgExt(cheeckQuery_ImgExt);
                        break;

                    case "Nominee1":
                        // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee1_Image");
                        tableName_ImgExt =
                            Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee1_Image").
                                SingleOrDefault().Value;
                        cheeckQuery_ImgExt = "Select Cust_Code,Signature from " + tableName_ImgExt +
                                             " where Cust_Code='" +
                                             singleImageBo.CustCode + "';";

                        IsExistSignature = CheckExistingSignasture_ImgExt(cheeckQuery_ImgExt);
                        break;

                    case "Nominee2":
                        //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee2_Image");
                        tableName_ImgExt =
                            Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee2_Image").
                                SingleOrDefault().Value;
                        cheeckQuery_ImgExt = "Select Cust_Code,Signature from " + tableName_ImgExt +
                                             " where Cust_Code='" +
                                             singleImageBo.CustCode + "';";

                        IsExistSignature = CheckExistingSignasture_ImgExt(cheeckQuery_ImgExt);
                        break;

                    case "Guardian1":
                        // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian1_Image");
                        tableName_ImgExt =
                            Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian1_Image").
                                SingleOrDefault().Value;
                        cheeckQuery_ImgExt = "Select Cust_Code,Signature from " + tableName_ImgExt +
                                             " where Cust_Code='" +
                                             singleImageBo.CustCode + "';";

                        IsExistSignature = CheckExistingSignasture_ImgExt(cheeckQuery_ImgExt);
                        break;

                    case "Guardian2":
                        //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian2_Image");
                        tableName_ImgExt =
                            Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian2_Image").
                                SingleOrDefault().Value;
                        cheeckQuery_ImgExt = "Select Cust_Code,Signature from " + tableName_ImgExt +
                                             " where Cust_Code='" +
                                             singleImageBo.CustCode + "';";

                        IsExistSignature = CheckExistingSignasture_ImgExt(cheeckQuery_ImgExt);
                        break;

                    case "POA":
                        //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_POA_Image");
                        tableName_ImgExt =
                            Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_POA_Image").
                                SingleOrDefault().Value;
                        cheeckQuery_ImgExt = "Select Cust_Code,Signature from " + tableName_ImgExt +
                                             " where Cust_Code='" +
                                             singleImageBo.CustCode + "';";

                        IsExistSignature = CheckExistingSignasture_ImgExt(cheeckQuery_ImgExt);
                        break;

                    case "Author":
                        //tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Author_Image");
                        tableName_ImgExt =
                            Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Author_Image").
                                SingleOrDefault().Value;
                        cheeckQuery_ImgExt = "Select Cust_Code,Signature from " + tableName_ImgExt +
                                             " where Cust_Code='" +
                                             singleImageBo.CustCode + "';";

                        IsExistSignature = CheckExistingSignasture_ImgExt(cheeckQuery_ImgExt);
                        break;

                    default:
                        IsExistSignature = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                IsExistSignature = false;
            }
            return IsExistSignature;

        }

        private bool CheckExistingSignasture(string queryString)
        {
            bool IsExistingSignature = false;
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase();
                data = _dbConnection.ExecuteQuery(queryString);

                if (data.Rows.Count > 0)
                {
                    IsExistingSignature = true;
                }

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase();
            }

            return IsExistingSignature;
        }

        private bool CheckExistingSignasture_ImgExt(string queryString)
        {
            bool IsExistingSignature = false;
            DataTable data = new DataTable();

            try
            {
                _dbConnection.ConnectDatabase_ImageExt();
                data = _dbConnection.ExecuteQuery_ImageExt(queryString);

                if (data.Rows.Count > 0)
                {
                    IsExistingSignature = true;
                }
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                _dbConnection.CloseDatabase_ImageExt();
            }

            return IsExistingSignature;
        }

        //private DataTable dtImageSave(string query)
        //{
        //    DataTable dtImage;
        //    dtImage = null;

        //    if (GlobalVariableBO._isExist_SBP_Database_ImageExt)
        //    {

        //        try
        //        {
        //            _dbConnection.ConnectDatabase_ImageExt();
        //            dtImage = _dbConnection.ExecuteQuery_ImageExt(query);

        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //        finally
        //        {
        //            _dbConnection.CloseDatabase_ImageExt();
        //        }

        //        return dtImage;

        //    }
        //    else
        //    {
        //        try
        //        {
        //            _dbConnection.ConnectDatabase();
        //            dtImage = _dbConnection.ExecuteQuery(query);

        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //        finally
        //        {
        //            _dbConnection.CloseDatabase();
        //        }

        //        return dtImage;
        //    }
        //}

        private void SqlParm(string query, string qeury_ImgExt, SingleImageBO singleImageBo)
        {
            string connectionString = string.Empty;
            connectionString = _dbConnection.ConnectionStringImageExt;
            SqlConnection CN_ImgExt = new SqlConnection(connectionString);
            connectionString = _dbConnection.ConnectionString;
            SqlConnection CN = new SqlConnection(connectionString);
            try
            {
                SqlCommand SqlCom = new SqlCommand(qeury_ImgExt, CN_ImgExt);
                SqlCom.Parameters.Add(new SqlParameter("@CustCode", (object)singleImageBo.CustCode));
                SqlCom.Parameters.Add(new SqlParameter("@ImageData", (object)singleImageBo.ImgByte));
                SqlCom.Parameters.Add(new SqlParameter("@Update_Date", (object)cmnBAL.GetCurrentServerDate()));
                CN_ImgExt.Open();
                SqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                try
                {
                    SqlCommand SqlCom = new SqlCommand(query, CN);
                    SqlCom.Parameters.Add(new SqlParameter("@CustCode", (object)singleImageBo.CustCode));
                    SqlCom.Parameters.Add(new SqlParameter("@ImageData", (object)singleImageBo.ImgByte));
                    SqlCom.Parameters.Add(new SqlParameter("@Update_Date", (object)cmnBAL.GetCurrentServerDate()));
                    CN.Open();
                    SqlCom.ExecuteNonQuery();
                }
                catch (Exception ey)
                {
                    throw new Exception(ey.Message);
                }
                finally
                {
                    if (CN.State == ConnectionState.Open)
                        CN.Close();
                }
            }
            finally
            {
                if (CN_ImgExt.State == ConnectionState.Open)
                    CN_ImgExt.Close();
            }
        }

        //Single Signature Upload
        public void SaveSignatureToDatabase(SingleImageBO singleImageBo)
        {
            string qry = "";
            string qry_ImgExt = string.Empty;

            DataTable dataTable = new DataTable();
            string tableName = string.Empty;
            string tableName_ImgExt = string.Empty;
            // 
            switch (singleImageBo.ImageSelectionMode)
            {
                case "1st Account Holder":
                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Cust_Image");
                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Cust_Image").SingleOrDefault().Key;
                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Cust_Image").SingleOrDefault().Value;

                    try
                    {
                        if (IsExistSignature(singleImageBo))
                        {
                            qry =
                                "UPDATE " + tableName +
                                " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry =
                                "insert into " + tableName +
                                " ([Cust_Code],[Signature],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry = string.Empty;
                    }

                    try
                    {
                        if (IsExistSignature_ImgExt(singleImageBo))
                        {
                            qry_ImgExt =
                                "UPDATE " + tableName_ImgExt +
                                " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry_ImgExt =
                                "insert into " + tableName_ImgExt +
                                " ([Cust_Code],[Signature],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry_ImgExt = string.Empty;
                    }

                    SqlParm(qry, qry_ImgExt, singleImageBo);
                    break;

                case "2nd Account Holder":
                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Joint_holder_Image");
                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Joint_holder_Image").SingleOrDefault().Key;
                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Joint_holder_Image").SingleOrDefault().Value;

                    try
                    {
                        if (IsExistSignature(singleImageBo))
                        {
                            qry =
                                "UPDATE " + tableName +
                                " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry =
                                "insert into " + tableName +
                                " ([Cust_Code],[Signature],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry = string.Empty;
                    }

                    try
                    {
                        if (IsExistSignature_ImgExt(singleImageBo))
                        {
                            qry_ImgExt =
                                "UPDATE " + tableName_ImgExt +
                                " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry_ImgExt =
                                "insert into " + tableName_ImgExt +
                                " ([Cust_Code],[Signature],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry_ImgExt = string.Empty;
                    }




                    SqlParm(qry, qry_ImgExt, singleImageBo);
                    break;

                case "Nominee1":
                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee1_Image");
                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee1_Image").SingleOrDefault().Key;
                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee1_Image").SingleOrDefault().Value;

                    try
                    {
                        if (IsExistSignature(singleImageBo))
                        {
                            qry =
                                "UPDATE " + tableName +
                                " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry =
                                "insert into " + tableName +
                                "([Cust_Code],[Signature],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry = string.Empty;
                    }

                    try
                    {
                        if (IsExistSignature_ImgExt(singleImageBo))
                        {
                            qry_ImgExt =
                                "UPDATE " + tableName_ImgExt +
                                " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry_ImgExt =
                                "insert into " + tableName_ImgExt +
                                "([Cust_Code],[Signature],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry_ImgExt = string.Empty;
                    }



                    SqlParm(qry, qry_ImgExt, singleImageBo);
                    break;

                case "Nominee2":
                    //  tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Nominee2_Image");
                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee2_Image").SingleOrDefault().Key;
                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Nominee2_Image").SingleOrDefault().Value;

                    try
                    {
                        if (IsExistSignature(singleImageBo))
                        {
                            qry =
                                "UPDATE " + tableName +
                                " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry =
                                "insert into " + tableName +
                                " ([Cust_Code],[Signature],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry = string.Empty;
                    }

                    try
                    {
                        if (IsExistSignature_ImgExt(singleImageBo))
                        {
                            qry_ImgExt =
                                "UPDATE " + tableName_ImgExt +
                                " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry_ImgExt =
                                "insert into " + tableName_ImgExt +
                                " ([Cust_Code],[Signature],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry_ImgExt = string.Empty;
                    }

                    SqlParm(qry, qry_ImgExt, singleImageBo);
                    break;

                case "Guardian1":
                    // tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian1_Image");
                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian1_Image").SingleOrDefault().Key;
                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian1_Image").SingleOrDefault().Value;


                    try
                    {
                        if (IsExistSignature(singleImageBo))
                        {
                            qry =
                                "UPDATE " + tableName +
                                " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry =
                                "insert into " + tableName +
                                "([Cust_Code],[Signature],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry = string.Empty;
                    }

                    try
                    {
                        if (IsExistSignature_ImgExt(singleImageBo))
                        {
                            qry_ImgExt =
                                "UPDATE " + tableName_ImgExt +
                                " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry_ImgExt =
                                "insert into " + tableName_ImgExt +
                                "([Cust_Code],[Signature],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry_ImgExt = string.Empty;
                    }

                    SqlParm(qry, qry_ImgExt, singleImageBo);
                    break;

                case "Guardian2":
                    //  tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Guardian2_Image");
                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian2_Image").SingleOrDefault().Key;
                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Guardian2_Image").SingleOrDefault().Value;

                    try
                    {
                        if (IsExistSignature(singleImageBo))
                        {
                            qry =
                                "UPDATE " + tableName +
                                " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry =
                                "insert into " + tableName +
                                " ([Cust_Code],[Signature],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry = string.Empty;
                    }

                    try
                    {
                        if (IsExistSignature_ImgExt(singleImageBo))
                        {
                            qry_ImgExt =
                                "UPDATE " + tableName_ImgExt +
                                " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry_ImgExt =
                                "insert into " + tableName_ImgExt +
                                " ([Cust_Code],[Signature],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry_ImgExt = string.Empty;
                    }

                    SqlParm(qry, qry_ImgExt, singleImageBo);
                    break;

                case "POA":
                    //  tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_POA_Image");
                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_POA_Image").SingleOrDefault().Key;
                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_POA_Image").SingleOrDefault().Value;

                    try
                    {
                        if (IsExistSignature(singleImageBo))
                        {
                            qry =
                                "UPDATE " + tableName +
                                " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry =
                                "insert into " + tableName +
                                " ([Cust_Code],[Signature],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry = string.Empty;
                    }

                    try
                    {
                        if (IsExistSignature_ImgExt(singleImageBo))
                        {
                            qry_ImgExt =
                                "UPDATE " + tableName_ImgExt +
                                " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry_ImgExt =
                                "insert into " + tableName_ImgExt +
                                " ([Cust_Code],[Signature],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry_ImgExt = string.Empty;
                    }


                    SqlParm(qry, qry_ImgExt, singleImageBo);
                    break;

                case "Author":
                    //  tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Author_Image");
                    tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Author_Image").SingleOrDefault().Key;
                    tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Author_Image").SingleOrDefault().Value;

                    try
                    {
                        if (IsExistSignature(singleImageBo))
                        {
                            qry =
                                "UPDATE " + tableName +
                                " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry =
                                "insert into " + tableName +
                                " ([Cust_Code],[Signature],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry = string.Empty;
                    }

                    try
                    {
                        if (IsExistSignature_ImgExt(singleImageBo))
                        {
                            qry_ImgExt =
                                "UPDATE " + tableName_ImgExt +
                                " SET Signature=@ImageData,Update_Date=@Update_Date where Cust_Code='" +
                                singleImageBo.CustCode + "';";

                        }
                        else
                        {
                            qry_ImgExt =
                                "insert into " + tableName_ImgExt +
                                " ([Cust_Code],[Signature],Update_Date) values(@CustCode,@ImageData,@Update_Date)";

                        }
                    }
                    catch (Exception ex)
                    {
                        qry_ImgExt = string.Empty;
                    }


                    SqlParm(qry, qry_ImgExt, singleImageBo);
                    break;

                default:
                    break;
            }
        }

        public string BOIdToCustCode(string BoID)
        {
            string CutCode = string.Empty;
            DataTable dt = new DataTable();
            string query = @"SELECT Cust_Code 
                                FROM SBP_Customers
                                WHERE BO_ID='" + BoID + @"'";

            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
                if (dt.Rows.Count >0 )
                {
                    CutCode = dt.Rows[0][0].ToString();
                }               
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return CutCode;
        }

        public void SaveOtherImageToDatabase(byte[] _bArrayImgByte, string Cust_Code, string ImgPurpose)
        {
            SaveImgBO saveImgBO = new SaveImgBO();
            CommonBAL commbal = new CommonBAL();
            saveImgBO.CustomerCode = Cust_Code;
            saveImgBO.ImageArrayByte = _bArrayImgByte;
            saveImgBO.ImagePurpose = ImgPurpose;
            saveImgBO.FormSaveID = commbal.GenerateID_ImgExt("ID");
            try
            {
                InsertForm(saveImgBO);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Upload failed" + ex.Message);
            }
        }

        public void InsertForm(SaveImgBO imgBO)
        {
            string qry = "";
            string qry_ImgExt = "";
            byte[] imgByte = new byte[0];
            string tableName = string.Empty;
            string tableName_ImgExt = string.Empty;

            //     tableName = Indication_Fixed_DatabaseName.GetTableName("SBP_Others_Upload");
            tableName = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Others_Upload").SingleOrDefault().Key;
            tableName_ImgExt = Indication_Fixed_DatabaseName.TableName_ImageExt.Where(t => t.Key == "SBP_Others_Upload").SingleOrDefault().Value;

            qry = "insert INTO " + tableName + " ([ID],[Cust_Code],[Purpose],[Image],Update_Date) values(@formid,@OriginalPath,@ImagePurpose,@ImageData,@Update_Date)";
            qry_ImgExt = "insert INTO " + tableName_ImgExt + " ([ID],[Cust_Code],[Purpose],[Image],Update_Date) values(@formid,@OriginalPath,@ImagePurpose,@ImageData,@Update_Date)";
            SqlParmForForm(qry, qry_ImgExt, imgBO);
        }
        private void SqlParmForForm(string query, string query_ImgExt, SaveImgBO imgBO)
        {
            string connectionString = string.Empty;
            connectionString = _dbConnection.ConnectionStringImageExt;
            SqlConnection CN_ImgExt = new SqlConnection(connectionString);
            connectionString = _dbConnection.ConnectionString;
            SqlConnection CN = new SqlConnection(connectionString);
            try
            {
                SqlCommand SqlCom = new SqlCommand(query_ImgExt, CN_ImgExt);

                SqlCom.Parameters.Add(new SqlParameter("@formid", (object)imgBO.FormSaveID));
                SqlCom.Parameters.Add(new SqlParameter("@OriginalPath", (object)imgBO.CustomerCode));
                SqlCom.Parameters.Add(new SqlParameter("@ImagePurpose", (object)imgBO.ImagePurpose));
                SqlCom.Parameters.Add(new SqlParameter("@ImageData", (object)imgBO.ImageArrayByte));
                SqlCom.Parameters.Add(new SqlParameter("@Update_Date", (object)cmnBAL.GetCurrentServerDate()));

                CN_ImgExt.Open();
                SqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                try
                {
                    SqlCommand SqlCom = new SqlCommand(query, CN);
                    SqlCom.Parameters.Add(new SqlParameter("@formid", (object)imgBO.FormSaveID));
                    SqlCom.Parameters.Add(new SqlParameter("@OriginalPath", (object)imgBO.CustomerCode));
                    SqlCom.Parameters.Add(new SqlParameter("@ImagePurpose", (object)imgBO.ImagePurpose));
                    SqlCom.Parameters.Add(new SqlParameter("@ImageData", (object)imgBO.ImageArrayByte));
                    SqlCom.Parameters.Add(new SqlParameter("@Update_Date", (object)cmnBAL.GetCurrentServerDate()));

                    CN.Open();
                    SqlCom.ExecuteNonQuery();

                }
                catch (Exception ey)
                {
                    throw new Exception(ey.Message);
                }

                finally
                {
                    if (CN.State == ConnectionState.Open)
                        CN.Close();
                }
            }
            finally
            {
                if (CN_ImgExt.State == ConnectionState.Open)
                    CN_ImgExt.Close();
            }


        }
    }
}



