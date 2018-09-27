using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessAccessLayer.BO;

namespace BusinessAccessLayer.BAL
{
   public class PayinBAL
    {

       private DbConnection _dbConnection;
       public PayinBAL()
       {
           _dbConnection = new DbConnection();
       }

       public void InsertPayoutSattlement(PayinBO objPayin)
       {
           string querystring = "INSERT INTO SBP_Payin (ExecDate,BOID,CounterBOID,BrokerCode,ISIN,TradeQty,PayFlag,CustCode) SELECT REPLACE(CONVERT(varchar(12),'"+objPayin.SattlementDate.ToString("dd-MM-yyyy")+"',105),'-',''),'"+objPayin.BOId+"',(SELECT TOP 1 BO_ID FROM SBP_Broker_Info)+'"+objPayin.CounterBOID+"','000122','"+objPayin.CompanyISIN+"',REPLACE(STR("+objPayin.TradeQty+",12,0),' ','0'),'O',CONVERT(char(16),'"+objPayin.CustomerCode+"')";
           string Logquery = "INSERT INTO SBP_Payinout_Log (CodeFrom,ISIN,Quantity,PayFlag,Status,EventDate,EntryBy) VALUES ('"+objPayin.CustomerCode+"','"+objPayin.CompanyISIN + "'," + objPayin.TradeQty+ ",'" + objPayin.Paylog + "','INSERT',GETDATE(),'"+ GlobalVariableBO._userName + "')";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.StartTransaction();
               _dbConnection.ExecuteNonQuery(querystring);
               _dbConnection.ExecuteNonQuery(Logquery);
               _dbConnection.Commit();
           }
           catch (Exception)
           {
               _dbConnection.Rollback();
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

       }

       public void InsertPayinSattlement(PayinBO objPayin)
       {
           string querystring = "INSERT INTO SBP_Payin (ExecDate,BOID,CounterBOID,BrokerCode,ISIN,TradeQty,PayFlag,CustCode) SELECT REPLACE(CONVERT(varchar(12),'" + objPayin.SattlementDate.ToString("dd-MM-yyyy") + "',105),'-',''),(SELECT TOP 1 BO_ID FROM SBP_Broker_Info)+'" + objPayin.BOId + "','" + objPayin.CounterBOID + "','000122','" + objPayin.CompanyISIN + "',REPLACE(STR(" + objPayin.TradeQty + ",12,0),' ','0'),'I',CONVERT(char(16),'" + objPayin.CustomerCode + "')";
           string Logquery = "INSERT INTO SBP_Payinout_Log (CodeFrom,ISIN,Quantity,PayFlag,Status,EventDate,EntryBy) VALUES ('" + objPayin.CustomerCode + "','" + objPayin.CompanyISIN + "'," + objPayin.TradeQty + ",'" + objPayin.Paylog + "','INSERT',GETDATE(),'" + GlobalVariableBO._userName + "')";

           try
           {
               _dbConnection.ConnectDatabase();
               _dbConnection.StartTransaction();
               _dbConnection.ExecuteNonQuery(querystring);
               _dbConnection.ExecuteNonQuery(Logquery);
               _dbConnection.Commit();
           }
           catch (Exception)
           {
               _dbConnection.Rollback();
               throw;
           }

           finally
           {
               _dbConnection.CloseDatabase();
           }

       }
    }
}
