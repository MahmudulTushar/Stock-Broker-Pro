using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;


namespace BusinessAccessLayer.BAL
{
    public class AccTransactionBAL
    {
    public  string  ConnString;
    SqlCommand sqlcmd;
       
    private SqlConnection SqlConn = new SqlConnection("Data Source=120.130.1.5;Initial Catalog=SBP_Database;User ID=su; Password=123;Connection Timeout=0;");


    public DataTable ExQuery(string QString)
    {
        DataTable dt = new DataTable();

        try
        {   
            SqlDataAdapter myAdapter = new SqlDataAdapter(QString, SqlConn);

            myAdapter.Fill(dt);
            return dt;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void ExNonQuery(string QString)
    {
        try
        {
          //  SqlConn.Close();
            SqlCommand cmd = new SqlCommand(QString, SqlConn);
            SqlConn.Open();
            cmd.ExecuteNonQuery();
            SqlConn.Close();
          //sqlcmd.Connection = SqlConn;
          //sqlcmd.CommandType = CommandType.Text;
          //sqlcmd.CommandText = QString;
          //sqlcmd.ExecuteNonQuery();
        }
        catch (DataException)
        {
            throw;
        }
    }

    }
}
