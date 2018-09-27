using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessAccessLayer.BO;

namespace BusinessAccessLayer.BAL
{
    public class CategoryEntryBAL
    {
        private DbConnection _dbConnection = new DbConnection();

        public DataTable getCategoryType()
        {
            DataTable dt;
            string query = @"select Category_Type_ID as 'ID',Category_Type as 'Category_Type' from SBP_Expense_Category_Type";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        public DataTable getCategoryTypeForSub()
        {
            DataTable dt;
            string query = @"select Category_ID as 'ID',category_Name as 'Name' from SBP_Expense_Category_Lookup";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        public DataTable getFrequencyName()
        {
            DataTable dt;
            string query = @"select Frequency_ID as 'ID', Frequency_Name as 'FName' from dbo.SBP_Expense_Frequency";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        public DataTable getExpenseType()
        {
            DataTable dt;
            string query = @"select Expense_Type_ID as 'ID',expense_type as 'expType' from dbo.SBP_Expense_Type";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        public DataTable getExpenseNameForSub()
        {
            DataTable dt;
            string query = @"select Expense_ID as 'ID',Expense_Description as 'ExpenseName' from SBP_Expense_Lookup order by  Expense_Description asc";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        public DataTable getCategoryTypeInformation()
        {
            DataTable dt;
            string query = @"select l.Category_ID as 'ID'
	                               ,l.Category_Name 
	                               ,l.Category_Type_ID 
	                               ,CONVERT(varchar(10),l.Update_Date,120) as 'Entry_Date'
		                            from SBP_Expense_Category_Lookup as l
		                            order by ID desc";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        public DataTable getSubCategoryType()
        {
            DataTable dt;
            string query = @" select Expense_ID
	                                ,Expense_Description as 'Expense_Name'
	                                ,(select category_Name as 'Name' 
		                                    from SBP_Expense_Category_Lookup as cl
		                                    where cl.Category_ID=exl.Category_ID) as 'Cat_Name'
	                                ,(select Frequency_Name  
	                                        from dbo.SBP_Expense_Frequency as f
	                                        where f.Frequency_ID=exl.Frequency_ID) as 'Frequency'
	                                ,(select t.expense_type 
		                                    from dbo.SBP_Expense_Type as t
		                                    where t.Expense_Type_ID=exl.Expense_Type_ID) as 'Exp_Type'
                                 from SBP_Expense_Lookup as exl
                                 order by Expense_ID desc";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        public DataTable getSubSubExpenseName()
        {
            DataTable dt;
            string query = @"select  Sub_Category_Type_ID as 'ID'
                                    ,Sub_Category_Type_Name as 'Sub_ExpName'
		                            ,(select Expense_Description
			                             from SBP_Expense_Lookup as l
			                             where l.Expense_ID=t.ExpenseID) as 'Expense_Name'		                            
		                            ,(select Category_Name 
			                             from SBP_Expense_Category_Lookup as cl
			                             where cl.Category_ID=t.Category_ID) as 'Category_Name'
                             from SBP_Expense_Sub_Category_Type as t 
                             order by t.Sub_Category_Type_ID desc";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        public DataTable getExistingHeadCode()
        {
            DataTable dt;
            string query = @"select 
	                             distinct(HeadCode) as 'Head_Code'
	                             ,BasicHead as 'Basic_Head'
	                             ,count(HeadName) as 'Items'
                            from [dbo].[SBP_HeadCodeEntry]
                            group by HeadCode,BasicHead
                            order by HeadCode";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        public DataTable getExistingSubHeadInformation()
        {
            DataTable dt;
            string query = @"select HeadCode as 'Head_Code'
                              ,BasicHead as 'Basic_Head'
                              ,HeadSubCode as 'SubHead_Code'   
                              ,HeadName as 'SubHead_Name'
                            from [dbo].[SBP_HeadCodeEntry]
                            where HeadName is not null";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        public DataTable getExistingHeadName()
        {
            DataTable dt;
            string query = @"select 
	                             distinct(HeadCode) as 'Head_Code'
	                             ,BasicHead as 'Basic_Head'
	                             ,count(HeadName) as 'Items'
                            from [dbo].[SBP_HeadCodeEntry]
                            group by HeadCode,BasicHead
                            order by HeadCode";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        public DataTable getNextHeadCode(string prefix)
        {
            DataTable dt;
            string query = @"select Count(distinct(HeadCode))+1 as 'NextHeadCode'
                             from SBP_HeadCodeEntry
                             where HeadCode like '" + prefix + "%'";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        public int getNextRomanDigitCode(string HCodeForSub)
        {
            DataTable dt;
            int romanDigit;
            string query = @"select count(Isnull(HeadCode,0))+1 as 'NextRomanDisit' 
                                from SBP_HeadCodeEntry
                                where HeadCode='" + HCodeForSub + "' and HeadSubCode is not null";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
                romanDigit = Convert.ToInt32(dt.Rows[0]["NextRomanDisit"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return romanDigit;
        }

        public void SaveNewSubHeadName(string HCodeForSub, string BHeadNameForSub, string HeadSubCode, string SubHName, string HeadDescription) //new
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_HeadCodeEntry]
                                           ([HeadCode]
                                           ,[BasicHead]
                                           ,[HeadSubCode]
                                           ,[HeadName]
                                           ,[HeadDescription]
                                           ,[EntryDate]
                                           ,[EntryBy])
                                     VALUES
                                           ('" + HCodeForSub + @"'
                                           ,'" + BHeadNameForSub + @"'
                                           ,'" + HeadSubCode + @"'
                                           ,'" + SubHName + @"'
                                           ,'" + HeadDescription + @"'
                                           ,'" + GlobalVariableBO._currentServerDate.ToString("yyyy/MM/dd") + @"'
                                           ,'" + GlobalVariableBO._userName + @"')";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
        

        public DataTable getHeadNameByHeadType(string prefix)
        {
            DataTable dt;
//            string query = @"select distinct(BasicHead) as 'BH'
//                             from [dbo].[SBP_HeadCodeEntry] 
//                             where HeadCode like '" + prefix + "%'";
            string query = @"select distinct(BasicHead) as 'BH'
	                               ,HeadCode as 'HC'
                             from [dbo].[SBP_HeadCodeEntry] 
                             where HeadCode like '" + prefix + "%'";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }
        
        public void SaveNewHeadCode(string HeadCode, string BasicHead, DateTime EntryDate)
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_HeadCodeEntry]
                               ([HeadCode]
                               ,[BasicHead]
                               ,[EntryDate]
                               ,[EntryBy])
                         VALUES
                               ('" + HeadCode + @"'
                               ,'" + BasicHead + @"'
                               ,'" + EntryDate + @"'
                               ,'" + GlobalVariableBO._userName + "')";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }
        public void SaveNewSubHeadName()
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_HeadCodeEntry]
                                   ([HeadCode]
                                   ,[BasicHead]
                                   ,[HeadSubCode]
                                   ,[HeadName]
                                   ,[HeadDescription]
                                   ,[EntryDate]
                                   ,[EntryBy])
                             VALUES
                                   (<HeadCode, varchar(10),>
                                   ,<BasicHead, varchar(50),>
                                   ,<HeadSubCode, varchar(10),>
                                   ,<HeadName, varchar(50),>
                                   ,<HeadDescription, varchar(100),>
                                   ,<EntryDate, date,>
                                   ,<EntryBy, varchar(20),>)";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        public DataTable getExistingSubHeadCode()
        {
            DataTable dt;
            string query = @"select 
	                             distinct(HeadCode) as 'Head_Code'
	                            ,BasicHead as 'Basic_Head' 
                             from [dbo].[SBP_HeadCodeEntry]";
            try
            {
                _dbConnection.ConnectDatabase();
                dt = _dbConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
            return dt;
        }

        public void SaveCategoryType(string catName,string catTpID)
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Expense_Category_Lookup]
                                       ([Category_Name]
                                       ,[Category_Type_ID]
                                       ,[Sub_Category]
                                       ,[Update_Date]
                                       ,[Entry_By])
                                 VALUES
                                       ('" + catName + @"'
                                       ,'"+catTpID+@"'
                                       ,''
                                       ,'"+GlobalVariableBO._currentServerDate+@"'
                                       ,'"+GlobalVariableBO._userName+@"')";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        public void SaveCategoryName(int cID,string CName,int fID, int expTypeID)
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Expense_Lookup]
                                       ([Category_ID]
                                       ,[Expense_Description]
                                       ,[Frequency_ID]
                                       ,[Update_Date]
                                       ,[Expense_Type_ID]
                                       ,[Entry_By])
                                 VALUES
                                       (" + cID + @"
                                       ,'" + CName + @"'
                                       ," + fID + @"
                                       ,'"+GlobalVariableBO._currentServerDate+@"'
                                       ," + expTypeID + @"
                                       ,'"+GlobalVariableBO._userName+@"'
                                       )";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
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

        public void SaveSubExpenseName(int expID, string subExpenseName, int catID)
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_Expense_Sub_Category_Type]
                                   ([ExpenseID]
                                   ,[Sub_Category_Type_Name]
                                   ,[Category_ID]
                                   ,[EntryBy]
                                   ,[EntryDate])
                             VALUES
                                   (" + expID + @"
                                   ,'" + subExpenseName + @"'
                                   ," + catID + @"
                                   ,'"+GlobalVariableBO._userName+@"'
                                   ,'"+GlobalVariableBO._currentServerDate+@"')";
            try
            {
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(query);
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
        public void saveHeadName()
        {
            string query = @"INSERT INTO [SBP_Database].[dbo].[SBP_HeadCodeEntry]
                                   ([HeadCode]
                                   ,[BasicHead]
                                   ,[HeadSubCode]
                                   ,[HeadName]
                                   ,[HeadDescription]
                                   ,[EntryDate]
                                   ,[EntryBy])
                             VALUES
                                   (<HeadCode, varchar(10),>
                                   ,<BasicHead, varchar(50),>
                                   ,<HeadSubCode, varchar(10),>
                                   ,<HeadName, varchar(50),>
                                   ,<HeadDescription, varchar(100),>
                                   ,<EntryDate, datetime,>
                                   ,<EntryBy, varchar(20),>)";
            try
            {

            }
            catch
            {

            }
            finally
            { 
                
            }
        }
    }
}
