using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using DataAccessLayer;
using System.Data;


namespace BusinessAccessLayer.BAL
{
   public class AssetInformationBAL

    {
        private DbConnection _dbConnection;

        public AssetInformationBAL()
        {
            _dbConnection=new DbConnection();
        }

        public void InsertIntoDataBase(AssetEntryBO objAssetEntryBO)
        {
            string queryString = "";
            queryString = "INSERT INTO SBP_Capex_Asset (BranchID,CategoryId,AssetName,Quantity,PurcshaseDate,ServicesDate,PurchasePrice,SalvageValue,LifeTime,Depreciation_Rate,EntryDate) VALUES (" + GlobalVariableBO._branchId + "," + objAssetEntryBO.CatagoryId + ",'" + objAssetEntryBO.AssetName + "'," + objAssetEntryBO.AssetQuantity + ",'" + objAssetEntryBO.PurchaseDate + "','" + objAssetEntryBO.ServicesDate + "'," + objAssetEntryBO.PurchasePrice + "," + objAssetEntryBO.SalvageValue + "," + objAssetEntryBO.LifeTime + "," + objAssetEntryBO.DeprceiationRate + ",CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME) )";

            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

       public DataTable GetAssetEntryInfo()
       {
           DataTable dataTable=new DataTable();

           string queryString = "";
           queryString = "SELECT AssetID,CategoryName AS 'Category Name',AssetName AS 'Asset Name',Quantity,CONVERT(VARCHAR,PurcshaseDate,106) AS 'Purchase Date',CAST(PurchasePrice AS FLOAT) AS 'Purchase Price(Tk.)',CAST(SalvageValue AS FLOAT) AS 'Salvage Value',LifeTime AS 'Life Time',Depreciation_Rate AS 'Depreciation Rate'  FROM SBP_Capex_Asset,SBP_Capex_Category WHERE BranchId=" + GlobalVariableBO._branchId + " AND SBP_Capex_Asset.CategoryId=SBP_Capex_Category.CategoryId ORDER BY AssetID DESC ;";

           try
           {
               dataTable = ExecuteToquery(queryString);
           }
           catch (Exception)
           {
               
               throw;
           }

           return dataTable;

       }

       public DataTable  GetCurrentAssetInfo()
       {
           DataTable dataTable = new DataTable();

           string queryString = "";
           queryString = "SELECT AssetName,Quantity,PurcshaseDate,ServicesDate,PurchasePrice,SalvageValue,LifeTime,Depreciation_Rate AS 'Depreciation Rate',BranchId  FROM SBP_Capex_Asset WHERE BranchId=" + GlobalVariableBO._branchId + ";";

           try
           {
               dataTable = ExecuteToquery(queryString);
           }
           catch (Exception)
           {

               throw;
           }

           return dataTable;
       }

       public DataTable  GetAssetInfoByAssetId(int AssetId)
       {
           
           DataTable dtAssetInfo=new DataTable();

           string stringQuery = "";
           stringQuery = "SELECT AssetName,Quantity,PurcshaseDate,ServicesDate,PurchasePrice,SalvageValue,LifeTime FROM SBP_Capex_Asset WHERE AssetID=" + AssetId + ";";

           try
           {
               dtAssetInfo = ExecuteToquery(stringQuery);
           }
           catch (Exception)
           {
               
               throw;
           }

           return dtAssetInfo;
       }

       public DataTable GetAssetList(int CatagoryId)
       {
           DataTable dtAssetList=new DataTable();

           string queryString = "";
           queryString = "SELECT DISTINCT AssetName FROM SBP_Capex_Asset WHERE BranchID=" + GlobalVariableBO._branchId + " AND CategoryId="+CatagoryId+";";

           try
           {
               dtAssetList = ExecuteToquery(queryString);
           }
           catch (Exception)
           {
               
               throw;
           }

           return dtAssetList;
       }

       private DataTable ExecuteToquery(string query)
       {
           DataTable dataTable = new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dataTable = _dbConnection.ExecuteQuery(query);
           }
           catch (Exception exception)
           {
               throw exception;
           }
           finally
           {
               _dbConnection.CloseDatabase();
           }
           return dataTable;
       }

       public void UpdateAssetInfo(AssetEntryBO objAssetBO,int AssetId)
       {
           string queryString = "";
           queryString = "UPDATE SBP_Capex_Asset SET AssetName='" + objAssetBO.AssetName + "',Quantity=" + objAssetBO.AssetQuantity + ",PurcshaseDate='" + objAssetBO.PurchaseDate + "',ServicesDate='" + objAssetBO.ServicesDate + "',PurchasePrice=" + objAssetBO.PurchasePrice + ",SalvageValue=" + objAssetBO.SalvageValue + ",LifeTime=" + objAssetBO.LifeTime + " WHERE AssetID="+ AssetId +";";
           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ExecuteNonQuery(queryString);
           }
           catch (Exception)
           {
               throw;
           }
           finally
           {
               _dbConnection.CloseDatabase();
           }
       }

       public DataTable GetMonthlyCapexReport(DateTime FromDate,DateTime ToDate)
       {
           TimeSpan span =ToDate-FromDate;
           int Totalday = Int32.Parse(span.Days.ToString());

           DataTable dtMonthlyCapexReport=new DataTable();

           string queryString = "";

           queryString = "SELECT AssetName,"
                         +"Quantity,PurcshaseDate,"
                         +"ServicesDate,PurchasePrice,"
                         +"SalvageValue,LifeTime,"
                         +"PurchasePrice-SalvageValue AS 'Net Value',"
                         + "Depreciation_Rate AS 'Depreciation Rate',"
                         +"CASE WHEN CAST(CONVERT(VARCHAR(10),DATEADD(DAY,LifeTime,ServicesDate),101) AS DATETIME)<='" + FromDate.ToString("yyyy-MM-dd")+"' "
                         +"THEN (PurchasePrice-SalvageValue)*Quantity "
                         +" ELSE " 
                         +" CASE WHEN CAST(CONVERT(VARCHAR(10),DATEADD(DAY,LifeTime,ServicesDate),101) AS DATETIME)<='" + ToDate.ToString("yyyy-MM-dd") + "' "
                         +"THEN (PurchasePrice-SalvageValue)*Quantity"
                         +" ELSE "
                         +" CASE WHEN DATEDIFF(DAY,'"+ FromDate +"','" + ToDate + "')=0"
                         +" THEN ((PurchasePrice-SalvageValue)/LifeTime)*Quantity"
                         +" ELSE "
                         +"((PurchasePrice-SalvageValue)/LifeTime)*DATEDIFF(DAY,'"+ToDate+"','"+ FromDate + "')*Quantity" 
	                     +" END "
	                     +" END " 
                         +" END AS 'Total Depreciation' "
                         + ",BranchID"
                         +"FROM SBP_Capex_Asset ORDER BY AssetID DESC";
           try
           {
               _dbConnection.ConnectDatabase();
               dtMonthlyCapexReport = _dbConnection.ExecuteQuery(queryString);
              
           }
           catch (Exception)
           {
               throw;
           }
           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtMonthlyCapexReport;
       }

       public DataTable GetTotalAssetExpense()
       {
           string queryString = "";
           queryString = "SELECT AssetName,Quantity,PurcshaseDate,ServicesDate,PurchasePrice,"
                         + " SalvageValue,LifeTime,PurchasePrice-SalvageValue AS 'Net Value',"
                         + " (PurchasePrice-SalvageValue)/(LifeTime) AS 'Depreciation Rate',"
                         + " CASE"
                         + " WHEN DATEADD(DAY,LifeTime,ServicesDate)<GETDATE()"
                         + " THEN (PurchasePrice-SalvageValue)"
                         + " WHEN DATEADD(DAY,LifeTime,ServicesDate)>=GETDATE()"
                         + " THEN ((PurchasePrice-SalvageValue)/LifeTime)*DATEDIFF(DAY,ServicesDate,GETDATE())"
                         + " END"
                         + " AS 'Total Depreciation',"
                         + " CASE"
                         + " WHEN DATEADD(DAY,LifeTime,ServicesDate)<GETDATE()"
                         + " THEN 0"
                         + " WHEN DATEADD(DAY,LifeTime,ServicesDate)>=GETDATE()"
                         +
                         " THEN PurchasePrice-((PurchasePrice-SalvageValue)/LifeTime)*DATEDIFF(DAY,ServicesDate,GETDATE())"
                         + " END"
                         + " AS 'Balence'"
                         + ",BranchID"
                         + " FROM SBP_Capex_Asset WHERE BranchID=" + GlobalVariableBO._branchId + "";

           DataTable dtTotalExpenseList = new DataTable();

           try
           {
               dtTotalExpenseList = ExecuteToquery(queryString);
           }
           catch (Exception)
           {

               throw;
           }

           return dtTotalExpenseList;

       }

       public void DeleteAssetInfo(int AssetID)
       {
           string queryString = "";
           queryString = "DELETE FROM SBP_Capex_Asset WHERE AssetID="+ AssetID + "";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ExecuteNonQuery(queryString);
           }
           catch (Exception)
           {
               
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }
       }

       private int _totalRecord;
       public int TotalRecord
       {
           get { return _totalRecord; }
           set { _totalRecord = value; }
       }

       private float _purpasePrice;
       public float PurpasePrice
       {
           get { return _purpasePrice; }
           set { _purpasePrice = value; }
       }

       private float _salagePrice;
       public float SalvagePrice
       {
           get { return _salagePrice; }
           set { _salagePrice = value; }
       }


       private float _deprciationValue;
       public float DepriceationValue
       {
           get { return _deprciationValue; }
           set { _deprciationValue = value; }
       }

       public void GetAssetCommonInfo()
       {
           string queryString = "";
           queryString = "SELECT COUNT(*),ISNULL(SUM(PurchasePrice),0.00),ISNULL(SUM(SalvageValue),0.00),ISNULL(SUM(PurchasePrice),0.00)-ISNULL(SUM(SalvageValue),0.00) FROM dbo.SBP_Capex_Asset ;";

           DataTable dataTable=new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dataTable = _dbConnection.ExecuteQuery(queryString);

               _totalRecord = Int32.Parse(dataTable.Rows[0][0].ToString());
               _purpasePrice = float.Parse(dataTable.Rows[0][1].ToString());
               _salagePrice = float.Parse(dataTable.Rows[0][2].ToString());
               _deprciationValue = float.Parse(dataTable.Rows[0][3].ToString());


           }
           catch (Exception)
           {
               
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }
       }

       public void InsertCapexCatagory(string CatagoryName)
       {
           string queryString = "";
           queryString = "INSERT INTO SBP_Capex_Category (CategoryName) VALUES ('"+CatagoryName+"')";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.ExecuteNonQuery(queryString);
           }
           catch (Exception)
           {
               
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }
       }

       public int GetCapexCategory()
       {
           string queryString = "SELECT COUNT(*) FROM SBP_Capex_Category";
           DataTable data = new DataTable();
           int totalRecord = 0;

           try
           {
               _dbConnection.ConnectDatabase();
               data = _dbConnection.ExecuteQuery(queryString);
               totalRecord = Int32.Parse(data.Rows[0][0].ToString());
           }

           catch (Exception)
           {
               throw;
           }

           finally
           {
              _dbConnection.CloseDatabase();
           }

           return totalRecord;

       }

       public DataTable GetCapexCategoryList()
       {
           string queryString = "";
           queryString = "SELECT CategoryId,CategoryName FROM SBP_Capex_Category ORDER BY CategoryId DESC;";

           DataTable dtList=new DataTable();

           try
           {
               _dbConnection.ConnectDatabase();
               dtList = _dbConnection.ExecuteQuery(queryString);
           }
           catch (Exception)
           {
               
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

           return dtList;

       }
    }
}
