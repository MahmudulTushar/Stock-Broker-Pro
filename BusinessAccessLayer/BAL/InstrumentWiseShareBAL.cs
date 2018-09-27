using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;

namespace BusinessAccessLayer.BAL
{
    public class InstrumentWiseShareBAL
    {
        DbConnection _dbConnection;
        public InstrumentWiseShareBAL()
        {
            _dbConnection = new DbConnection();
        }

        public DataTable GetInstrumentWiseShareReportData()
        {
            DataTable dtInstrumentWiseShareReport = null;
            string quryString = @"SELECT 
                                  sbt.[Cust_Code]
                                  ,
                                  (
                                    SELECT cpi.Cust_Name 
                                    FROM dbo.SBP_Cust_Personal_Info AS cpi
                                    WHERE cpi.Cust_Code=sbt.Cust_Code	
                                  ) AS 'Cust_Name'
                                , sbt.[Comp_Short_Code]
                                ,
                                (
                                SELECT cc.Comp_Category
                                FROM dbo.SBP_Comp_Category AS cc
                                WHERE Comp_Cat_ID=(
			                                SELECT Comp_Cat_ID
                                                        FROM dbo.SBP_Company AS c
                                                        WHERE c.Comp_Short_Code=sbt.Comp_Short_Code
                                                   )
                                ) AS 'Category'
                                ,
                                (
                                SELECT ISIN_No FROM dbo.SBP_Company AS c 
                                WHERE c.Comp_Short_Code=sbt.Comp_Short_Code
                                ) AS 'ISIN'

                                ,SUM(sbt.[Balance]) AS 'Total_Balance'
                                ,SUM(sbt.[Matured_Balance]) AS 'Matured_Balance'
                                FROM SBP_Share_Balance_Temp AS sbt
                                WHERE sbt.[Comp_Short_Code] <> ''
                                GROUP BY 
                                sbt.[Cust_Code]
                                ,sbt.[Comp_Short_Code]
                                HAVING SUM(sbt.[Balance])>0 AND SUM(sbt.[Matured_Balance])>0";
            try
            {
                _dbConnection.ConnectDatabase();
                dtInstrumentWiseShareReport = _dbConnection.ExecuteQuery(quryString);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dtInstrumentWiseShareReport;
        }

    }
}
