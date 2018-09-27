using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BAL
{
   public class xmlSchemaBAL
    {
       private DbConnection _dbconnect;
       public xmlSchemaBAL()
       {
           _dbconnect = new DbConnection();
       }
       public DataTable GetSchema()
       {
           DataTable dt = new DataTable();
           string query = @"Select trans.Customer, MAX(trans.UserID) as UserId
                            INTO #LastTradeWS
                            From SBP_Transactions as trans
                            Where EventDate=(
                                                        Select  MAX(t.Trade_Date)
                                                        From SBP_Share_Balance_Temp as t
                                                        Where t.Cust_Code=trans.Customer
                            )
                            Group By trans.Customer      

                            select 
                            scpi.Cust_Name as 'Name'
                            ,scpi.Last_Name as 'Short Name'
                            ,sc.cust_code as 'Client Code'
                            ,'12023500'+sc.BO_ID as 'BOID'
                            ,'1' as 'Branch ID'
                            ,scci.Address1 as 'Address'
                            ,scci.Phone as 'Telephone'
                            --,(  Select UserId
                            --    From #LastTradeWS as ws
                            --    Where Customer=sc.cust_code    
                            --) AS 'DealerID'
                            ,'KSLTRDR002' AS 'DealerID'
                            ,scai.Recidency as 'AccountType'
                            ,scpi.National_ID as 'Nationa id'
                            from SBP_Customers as sc
                            Left Outer join SBP_Cust_Contact_Info as scci
                            on sc.cust_Code =scci.cust_code
                            Left Outer join SBP_Cust_Additional_Info as scai
                            on scai.cust_code=sc.cust_code
                            Left Outer join SBP_Cust_Personal_Info as scpi
                            on sc.cust_code=scpi.cust_code
                            where sc.cust_status_id=1 and sc.Cust_Code>=100
                            and Isnull(sc.Cust_Code,'')<>''
                            ";
           try
           {
               _dbconnect.ConnectDatabase();
               dt=_dbconnect.ExecuteQuery(query);
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               _dbconnect.CloseDatabase();
           }
           return dt;
       }

       public DataTable GetClientCashLimit()
       {
           DataTable dt = new DataTable();
           //           string query = @" select  distinct
           //						     temp.Cust_Code as 'Client Code'
           //	                         ,SUM(temp.Balance) as 'Cash'
           //	                         ,'1' as 'Branch Name'
           //                             from  
           //                             SBP_Money_Balance_Temp as temp
           //                             inner join SBP_Customers as sc
           //                             on sc.cust_code=temp.cust_code
           //                             where sc.cust_status_id=1 and temp.cust_code>100 and isnull(sc.Cust_Code,'')<>'' group by temp.Cust_Code";

           string query = @"select  distinct
                                temp.Cust_Code as 'Client Code'
                                ,(
                                Case	
                                When ad.Recidency='Resident' Then SUM(temp.Balance)
                                Else 0
                                END
                                ) as 'Cash'
                                ,'1' as 'Branch Name'
                                --,ad.Recidency
                                from  
                                DEALERDB.dbo.SBP_Money_Balance_Temp as temp
                                INNER JOIN DEALERDB.dbo.SBP_Customers as sc
                                on sc.cust_code=temp.cust_code 
                                INNER Join DEALERDB.dbo.SBP_Cust_Additional_Info As ad
                                on ad.Cust_Code=sc.Cust_Code
                                where 
                                sc.cust_status_id=1	                           
                                --And ad.Recidency =''
                                group by temp.Cust_Code,ad.Recidency
                       UNION ALL
                               select  distinct
	                            temp.Cust_Code as 'Client Code'
	                            ,(
	                            Case	
	                            When ad.Recidency='Resident' Then SUM(temp.Balance)
	                            Else 0
	                            END
	                            ) as 'Cash'
	                            ,'1' as 'Branch Name'
	                            --,ad.Recidency
	                            from  
	                            SBP_Money_Balance_Temp as temp
	                            INNER JOIN SBP_Customers as sc
	                            on sc.cust_code=temp.cust_code 
	                            INNER Join SBP_Cust_Additional_Info As ad
	                            on ad.Cust_Code=sc.Cust_Code
	                            where 
	                            sc.cust_status_id=1 
	                            and temp.cust_code>=100 
	                            and isnull(sc.Cust_Code,'')<>''
	                            --And ad.Recidency =''
                                AND sc.BO_Status_ID =1
	                            group by temp.Cust_Code,ad.Recidency";
           try
           {
               _dbconnect.ConnectDatabase();
               dt = this._dbconnect.ExecuteQuery(query);
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               _dbconnect.CloseDatabase();
           }
           return dt;
       }
       public DataTable GetPositions()
       {
           DataTable dt = new DataTable();
           string query = @"declare @date varchar(11)
                            set @date= Convert(Varchar(10),getdate(),111)
                            
                            DECLARE @ShareLimit TABLE(
	                            ISIN_No Varchar(100),
	                            Comp_Short_Code Varchar(100),
	                            BO_ID Varchar(100),
	                            Cust_Name Varchar(100),
	                            Balance MONEY,
	                            MaturedBalProposed MONEY,
	                            Cust_Code Varchar(100),
	                            [DateString] varchar(100),
	                            [Date] DateTime	
                            )

                            INSERT @ShareLimit EXECUTE GenerateShareLimit
    
                            --Select * From @ShareLimit
    
                            Select 
                            '1' as 'Branch ID'
                            ,cust.Cust_Code as 'Client Code'
                            ,lmt.Comp_Short_Code as 'SecurityCode'
                            ,SUM(lmt.MaturedBalProposed) as 'Quantity'
                            ,((dbo.[GetBuyAvg] (cust.Cust_Code,@date,lmt.Comp_Short_Code))) as 'Buy_Avg'
                            ,((dbo.[GetBuyAvg] (cust.Cust_Code,@date,lmt.Comp_Short_Code)))*SUM(lmt.MaturedBalProposed) as 'Total Cost'
                            From @ShareLimit as lmt 
                            JOIN SBP_Customers as cust On cust.Cust_Code=lmt.Cust_Code
                            WHERE cust.Cust_Code is not null And cust.Cust_Code>=100 
                            AND cust.BO_Status_ID=1 AND lmt.Comp_Short_Code NOT IN (
                                                                                            Select Comp_Short_Code
                                                                                            From SBP_OtcMarket_Share
							                                                        )
                            GROUP BY cust.Cust_Code,lmt.Comp_Short_Code
                            HAVING SUM(lmt.MaturedBalProposed)>0
                            ORDER by cust.cust_code
                            ";
           try
           {
               _dbconnect.ConnectDatabase();
                
               dt = _dbconnect.ExecuteQuery(query);
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               this._dbconnect.CloseDatabase();
           }
           return dt;

       }



       #region NEW_FLEX_TP
       public DataTable Get_Cust_Register()
       {
           DataTable dt = new DataTable();
           try
           {
               string Porc_Query = @"Proc_Flex_TP_Customer_Shorting";

               _dbconnect.ConnectDatabase();
               dt = _dbconnect.ExecuteProQuery(Porc_Query);
               _dbconnect.CloseDatabase();
           }
           catch (Exception)
           {

               throw;
           }
           return dt;
       }

       public void Multiple_Limit_Process()
       {
           string Query = @"Delete SBP_Flex_Tp_Cust_Information_temp 
                            Where Convert(VARCHAR(10),(Create_date),120)=Convert(VARCHAR(10),(GETDATE()),120)
                            AND Status_Close <> 1";
           _dbconnect.ConnectDatabase();
           _dbconnect.ExecuteNonQuery(Query);
           _dbconnect.CloseDatabase();
       }

       public void Insert_Register_Cust_code(DataTable dt)
       {
           List<string> Cust_Code = dt.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Client_Code"]).ToString()).ToList();



           string Delete_Query = "Delete SBP_Flex_Tp_Cust_Information_temp Where Client_Code IN ('" + string.Join(",", Cust_Code.ToArray()) + "')";
           _dbconnect.ConnectDatabase();
           _dbconnect.ExecuteNonQuery(Delete_Query);
           _dbconnect.CloseDatabase();


           foreach (DataRow dr in dt.Rows)
           {
               string Query = @"INSERT INTO [SBP_Flex_Tp_Cust_Information_temp]
                                           ([Name]
                                           ,[Name_Len] 
                                           ,[Short_Name]
                                           ,[Client_Code]
                                           ,[BOID]
                                           ,[Branch_ID]
                                           ,[Address]
                                           ,[Address_Len]
                                           ,[Telephone]
                                           ,[Balance]
                                           ,[DealerID]
                                           ,[AccountType]
                                           ,[Nationa_id]
                                           ,[Net_Adjustment]
                                           ,[BO_Status_ID]
                                           ,[RcVersion]
                                           ,[RcVersionDate]
                                           ,[Cust_Cheaking]
                                           ,[Create_date])
                                     VALUES
                                           (  '" + dr["Name"].ToString() + @"'
                                             ,'" + dr["Name_Len"].ToString() + @"'
                                             ,'" + dr["Short_Name"].ToString() + @"'
                                             ,'" + dr["Client_Code"].ToString() + @"'
                                             ,'" + dr["BOID"].ToString() + @"'
                                             ,'" + dr["Branch_ID"].ToString() + @"'
                                             ,'" + dr["Address"].ToString() + @"'
                                             ,'" + dr["Address_Len"].ToString() + @"'
                                             ,'" + dr["Telephone"].ToString() + @"'
                                             ,'" + dr["Balance"].ToString() + @"'
                                             ,'" + dr["DealerID"].ToString() + @"'
                                             ,'" + dr["AccountType"].ToString() + @"'
                                             ,'" + dr["Nationa_id"].ToString() + @"'
                                             ,'" + dr["Net_Adjustment"].ToString() + @"'
                                             ,'" + dr["BO_Status_ID"].ToString() + @"'
                                             ,'" + dr["RcVersion"].ToString() + @"'
                                             ,'" + Convert.ToDateTime(dr["RcVersionDate"].ToString()) + @"'
                                             ,'" + dr["Cust_Cheaking"].ToString() + @"'
                                             ,GETDATE()
                                           )";
               _dbconnect.ConnectDatabase();
               _dbconnect.ExecuteNonQuery(Query);
               _dbconnect.CloseDatabase();
           }
       }

       #endregion


       #region Position
       public DataTable GetPositions_Flex_TP()
       {
           DataTable dt = new DataTable();
           string query = @"declare @date varchar(11)
                            set @date= Convert(Varchar(10),getdate(),111)
                            
                            DECLARE @ShareLimit TABLE(
	                            ISIN_No Varchar(100),
	                            Comp_Short_Code Varchar(100),
	                            BO_ID Varchar(100),
	                            Cust_Name Varchar(100),
	                            Balance MONEY,
	                            MaturedBalProposed MONEY,
	                            Cust_Code Varchar(100),
	                            [DateString] varchar(100),
	                            [Date] DateTime	
                            )

                            INSERT @ShareLimit EXECUTE GenerateShareLimit_Flex_TP
    
                            --Select * From @ShareLimit
    
                            Select 
                            '1' as 'Branch ID'
                            ,cust.Cust_Code as 'Client Code'
                            ,lmt.Comp_Short_Code as 'SecurityCode'
                            ,SUM(lmt.MaturedBalProposed) as 'Quantity'
                            ,((dbo.[GetBuyAvg] (cust.Cust_Code,@date,lmt.Comp_Short_Code))) as 'Buy_Avg'
                            ,((dbo.[GetBuyAvg] (cust.Cust_Code,@date,lmt.Comp_Short_Code)))*SUM(lmt.MaturedBalProposed) as 'Total Cost'
                            From @ShareLimit as lmt 
                            JOIN SBP_Customers as cust On cust.Cust_Code=lmt.Cust_Code
                            WHERE cust.Cust_Code is not null And cust.Cust_Code>=100 
                            AND cust.BO_Status_ID=1 AND lmt.Comp_Short_Code NOT IN (
                                                                                            Select Comp_Short_Code
                                                                                            From SBP_OtcMarket_Share
							                                                        )
                            GROUP BY cust.Cust_Code,lmt.Comp_Short_Code
                            HAVING SUM(lmt.MaturedBalProposed)>0
                            ORDER by cust.cust_code
                            ";
           try
           {
               _dbconnect.ConnectDatabase();
               dt = _dbconnect.ExecuteQuery(query);
               _dbconnect.CloseDatabase();
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               this._dbconnect.CloseDatabase();
           }
           return dt;

       }


       public DataTable GetDealerPositions_Flex_TP()
       {
           DataTable dt = new DataTable();
           string query = @"declare @date varchar(11)
                            set @date= Convert(Varchar(10),getdate(),111)

                                DECLARE @ShareLimit TABLE(
	                            ISIN_No Varchar(100),
	                            Comp_Short_Code Varchar(100),
	                            BO_ID Varchar(100),
	                            Cust_Name Varchar(100),
	                            Balance MONEY,
	                            MaturedBalProposed MONEY,
	                            Cust_Code Varchar(100),
	                            [DateString] varchar(100),
	                            [Date] DateTime	
                            )

                            INSERT @ShareLimit EXECUTE DEALERDB.dbo.GenerateShareLimit_Flex_TP
    
                            --Select * From @ShareLimit
    
                            Select 
                            '1' as 'Branch ID'
                            ,cust.Cust_Code as 'Client Code'
                            ,lmt.Comp_Short_Code as 'SecurityCode'
                            ,SUM(lmt.MaturedBalProposed) as 'Quantity'
                            ,((dbo.[GetBuyAvg] (cust.Cust_Code,@date,lmt.Comp_Short_Code))) as 'Buy_Avg'
                            ,((dbo.[GetBuyAvg] (cust.Cust_Code,@date,lmt.Comp_Short_Code)))*SUM(lmt.MaturedBalProposed) as 'Total Cost'
                            From @ShareLimit as lmt 
                            JOIN DEALERDB.dbo.SBP_Customers as cust On cust.Cust_Code=lmt.Cust_Code
                            WHERE cust.Cust_Code is not null  
                            AND cust.BO_Status_ID=1 AND lmt.Comp_Short_Code NOT IN (
                                                                                            Select Comp_Short_Code
                                                                                            From DEALERDB.dbo.SBP_OtcMarket_Share
							                                                        )
                            GROUP BY cust.Cust_Code,lmt.Comp_Short_Code
                            HAVING SUM(lmt.MaturedBalProposed)>0
                            ORDER by cust.cust_code
                            ";
           try
           {
               _dbconnect.ConnectDatabase();
               dt = _dbconnect.ExecuteQuery(query);
               _dbconnect.CloseDatabase();
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               this._dbconnect.CloseDatabase();
           }
           return dt;

       }

       public DataTable Get_Payout_Positions()
       {
           DataTable dt = new DataTable();
           string query = @"declare @date varchar(11)
                            set @date= Convert(Varchar(10),getdate(),111)
                            
                            DECLARE @ShareLimit TABLE(
	                            ISIN_No Varchar(100),
	                            Comp_Short_Code Varchar(100),
	                            BO_ID Varchar(100),
	                            Cust_Name Varchar(100),
	                            Balance MONEY,
	                            MaturedBalProposed MONEY,
	                            Cust_Code Varchar(100),
	                            [DateString] varchar(100),
	                            [Date] DateTime	
                            )

                            INSERT @ShareLimit EXECUTE GenerateShare_Payout_Limit
    
                            --Select * From @ShareLimit
    
                            Select 
                            '1' as 'Branch ID'
                            ,cust.Cust_Code as 'Client Code'
                            ,lmt.Comp_Short_Code as 'SecurityCode'
                            ,SUM(lmt.MaturedBalProposed) as 'Quantity'
                            ,((dbo.[GetBuyAvg] (cust.Cust_Code,@date,lmt.Comp_Short_Code))) as 'Buy_Avg'
                            ,((dbo.[GetBuyAvg] (cust.Cust_Code,@date,lmt.Comp_Short_Code)))*SUM(lmt.MaturedBalProposed) as 'Total Cost'
                            From @ShareLimit as lmt 
                            JOIN SBP_Customers as cust On cust.Cust_Code=lmt.Cust_Code
                            WHERE cust.Cust_Code is not null And cust.Cust_Code>=100 
                            AND cust.BO_Status_ID=1 AND lmt.Comp_Short_Code NOT IN (
                                                                                            Select Comp_Short_Code
                                                                                            From SBP_OtcMarket_Share
							                                                        )
                            GROUP BY cust.Cust_Code,lmt.Comp_Short_Code
                            HAVING SUM(lmt.MaturedBalProposed)>0
                            ORDER by cust.cust_code
                            ";
           try
           {
               _dbconnect.ConnectDatabase();
               dt = _dbconnect.ExecuteQuery(query);
               _dbconnect.CloseDatabase();
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               this._dbconnect.CloseDatabase();
           }
           return dt;

       }

       public DataTable Get_Bonus_Right_Positions(string Date)
       {
           DataTable dt = new DataTable();
           string query = @"declare @date varchar(11)
                            set @date= Convert(Varchar(10),getdate(),111)
                            
                            DECLARE @ShareLimit TABLE(
	                            ISIN_No Varchar(100),
	                            Comp_Short_Code Varchar(100),
	                            BO_ID Varchar(100),
	                            Cust_Name Varchar(100),
	                            Balance MONEY,
	                            MaturedBalProposed MONEY,
	                            Cust_Code Varchar(100),
	                            [DateString] varchar(100),
	                            [Date] DateTime,
                                Remark Varchar(20)	
                            )

                            INSERT @ShareLimit EXECUTE [GenerateShareLimit_Right_Bonus]@Date='" + Date + @"'



    
                            --Select * From @ShareLimit
    
                            Select 
                            '1' as 'Branch ID'
                            ,cust.Cust_Code as 'Client Code'
                            ,lmt.Comp_Short_Code as 'SecurityCode'
                            ,SUM(lmt.MaturedBalProposed) as 'Quantity'
                            ,((dbo.[GetBuyAvg] (cust.Cust_Code,@date,lmt.Comp_Short_Code))) as 'Buy_Avg'
                            ,(CASE WHEN lmt.Remark ='BONUS' THEN 0 ELSE
                            ((dbo.[GetBuyAvg] (cust.Cust_Code,@date,lmt.Comp_Short_Code)))*SUM(lmt.MaturedBalProposed) END) as 'Total Cost'
                            From @ShareLimit as lmt 
                            JOIN SBP_Customers as cust On cust.Cust_Code=lmt.Cust_Code
                            WHERE cust.Cust_Code is not null And cust.Cust_Code>=100 
                            AND cust.BO_Status_ID=1 AND lmt.Comp_Short_Code NOT IN (
                                                                                            Select Comp_Short_Code
                                                                                            From SBP_OtcMarket_Share
							                                                        )
                            GROUP BY cust.Cust_Code,lmt.Comp_Short_Code,lmt.Remark
                            HAVING SUM(lmt.MaturedBalProposed)>0
                            ORDER by cust.cust_code
                            ";
           try
           {
               _dbconnect.ConnectDatabase();
               dt = _dbconnect.ExecuteQuery(query);
               _dbconnect.CloseDatabase();
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               this._dbconnect.CloseDatabase();
           }
           return dt;

       }

       public DataTable Get_IPO_Positions(string Date)
       {
           DataTable dt = new DataTable();
           string query = @"declare @date varchar(11)
set @date= Convert(Varchar(10),getdate(),111)

DECLARE @ShareLimit TABLE(
    ISIN_No Varchar(100),
    Comp_Short_Code Varchar(100),
    BO_ID Varchar(100),
    Cust_Name Varchar(100),
    Balance MONEY,
    MaturedBalProposed MONEY,
    Cust_Code Varchar(100),
    [DateString] varchar(100),
    [Date] DateTime,
    Remark Varchar(20)	
)

INSERT @ShareLimit EXECUTE [GenerateShareLimit_IPO]@Date='"+Date+@"'




--Select * From @ShareLimit

Select 
'1' as 'Branch ID'
,cust.Cust_Code as 'Client Code'
,lmt.Comp_Short_Code as 'SecurityCode'
,SUM(lmt.MaturedBalProposed) as 'Quantity'
,((dbo.[GetBuyAvg] (cust.Cust_Code,@date,lmt.Comp_Short_Code))) as 'Buy_Avg'
,(CASE WHEN lmt.Remark ='IPO' THEN 0 ELSE
((dbo.[GetBuyAvg] (cust.Cust_Code,@date,lmt.Comp_Short_Code)))*SUM(lmt.MaturedBalProposed) END) as 'Total Cost'
From @ShareLimit as lmt 
JOIN SBP_Customers as cust On cust.Cust_Code=lmt.Cust_Code
WHERE cust.Cust_Code is not null And cust.Cust_Code>=100 
AND cust.BO_Status_ID=1 AND lmt.Comp_Short_Code NOT IN (
                                                                Select Comp_Short_Code
                                                                From SBP_OtcMarket_Share
                                                        )
GROUP BY cust.Cust_Code,lmt.Comp_Short_Code,lmt.Remark
HAVING SUM(lmt.MaturedBalProposed)>0
ORDER by cust.cust_code
                            ";
           try
           {
               _dbconnect.ConnectDatabase();
               dt = _dbconnect.ExecuteQuery(query);
               _dbconnect.CloseDatabase();
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               this._dbconnect.CloseDatabase();
           }
           return dt;

       }

       #endregion
    }
}
