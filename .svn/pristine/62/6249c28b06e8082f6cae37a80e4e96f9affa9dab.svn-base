using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using BusinessAccessLayer.BAL;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;





namespace StockbrokerProNewArch
{
    public partial class frmDataBaseBackUp : System.Windows.Forms.Form
    {
       
        DbConnection _DbConnection = new DbConnection();       
        string Connectionstring = string.Empty;
        private int progessvalue =0;
        private int i = 0;
        private SqlCommand SqLCommand;
        private SqlConnection SqlConnection;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection constring;

        string Connection = string.Empty;
        public frmDataBaseBackUp()
        {
            InitializeComponent();          
            prgBackuplProgress.BackColor = Color.Red;
        }

        private void frmDataBaseBackUp_Load(object sender, EventArgs e)
        {
            serverName(".");
            prgBackuplProgress.BackColor = Color.Red;           
        }

       
      
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        #region New Arac

        public void serverName(string str)
        {
            string dataSourse = "Initial Catalog=Master";
            string SBPDatabase ="Initial Catalog=SBP_Database";
            string CallCenterDataBase="Initial Catalog=dbksclCallCenter";
            string Connection = DbConnectionBasic.ConnectionString.ToLower();
            List<string> ListConnection = new List<string>();
            char[] SpliteChar = { ';'};
            string[] ConArr = Connection.Split(SpliteChar);
            foreach (string Value in ConArr)
            {
                if (SBPDatabase.ToLower().Contains(Value))
                {
                    if (Value == "")
                    {
                        ListConnection.Add(Value);
                    }
                    else
                    {
                        ListConnection.Add(dataSourse);
                    }
                }
                else if (CallCenterDataBase.ToLower().Contains(Value))
                {
                    if (Value == "")
                    {
                        ListConnection.Add(Value);
                    }
                    else
                    {
                        ListConnection.Add(dataSourse);
                    }
                }
                else
                {
                    ListConnection.Add(Value);
                }
            }

            string[] Connectionstringarray = ListConnection.ToArray();
            Connectionstring = string.Join(";", Connectionstringarray);            
            con = new SqlConnection(Connectionstring);            
            con.Open();
            cmd = new SqlCommand("select *  from sysservers  where srvproduct='SQL Server'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ComboBoxserverName.Items.Add(dr[2]);
            }
            dr.Close();
        }
      
        public void LoadCombo()
        {
            con = new SqlConnection(Connectionstring);
            con.Open();
            cmbDataBaseName.Items.Clear();
            cmd = new SqlCommand("select * from sysdatabases", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbDataBaseName.Items.Add(dr[0]);
            }
            dr.Close();
        }

        public void CreateConnectionStrion()
        {
            string Connection = DbConnectionBasic.ConnectionString.ToLower();
            string DataBaseName = "Initial Catalog= " + cmbDataBaseName.Text;
            string[] ConnectionArray = Connection.Split(';');
            string SBPDatabase = "Initial Catalog=SBP_Database";
            List<string> listConn = new List<string>();           
            string DatabaselogName = string.Empty;

            foreach (string value in ConnectionArray)
            {
                if (SBPDatabase.ToLower().Contains(value))
                {
                    if (value == "")
                    {
                        listConn.Add(value);
                    }
                    else
                    {
                        listConn.Add(DataBaseName);
                    }
                }
                else
                {
                    listConn.Add(value);
                }
            }

            string[] ConArray = listConn.ToArray();
            string Connectionstring = string.Join(";", ConArray);           
             constring = new SqlConnection(Connectionstring);
             Connection = Connectionstring;
        }


        public void query(string que)
        {
            cmd = new SqlCommand(que, constring);
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            i++;
        }

        public bool Validation()
        {
            if (string.IsNullOrEmpty(ComboBoxserverName.Text))
            {
                MessageBox.Show("Server Name Can Not Be blank");
                ComboBoxserverName.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(cmbDataBaseName.Text))
            {
                MessageBox.Show("DataBase Name Can Not be blank");
                cmbDataBaseName.Focus();
                return true;    
            }
            else if (string.IsNullOrEmpty(txtPath.Text))
            {
                MessageBox.Show("Please select where to save.", "Information !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPath.Focus();
                return true;
            }

            return false;
        }


        public void blank(string str)
        {
            try
            {
            
                if (str == "backup")
                {
                    string Query = string.Empty;
                    string DatabaseServerAddress = @"\\150.1.122.2";
                    string FixedFolderName = "Db Backup Temp";
                    string BackUpFileName = txtBackUpName.Text + ".bak";
                    string BackUpLocation = txtPath.Text;
                    string BackupPath = @"D:\"+FixedFolderName+@"\" + BackUpFileName;

                    Query = (@"BACKUP DATABASE " + cmbDataBaseName.Text + " TO DISK = N'" + BackupPath + "'");
                    //Query = @"BACKUP DATABASE BankBook TO DISK = N'D:\DataBaseBackUpPosition\" + BackUpFileName + "'";                 
                    ConnectDatabase();
                    ExecuteNonQuery(Query);
                    string MoveTo = BackUpLocation + @"\"+ BackUpFileName;
                    string MoveFrom = DatabaseServerAddress + @"\" + FixedFolderName + @"\" + BackUpFileName;
                    System.IO.File.Move(MoveFrom, MoveTo);
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
        }



        public void ConnectDatabase()
        {

            SqlConnection = new SqlConnection(Connectionstring);

            try
            {
                SqlConnection.Open();
                SqLCommand = SqlConnection.CreateCommand();               
            }
            catch (Exception)
            {
                if (SqlConnection.State == ConnectionState.Open)
                    SqlConnection.Close();
                throw;
            }

        }

        public void ExecuteNonQuery(string queryString)
        {            
             SqLCommand.CommandText = queryString;
             SqLCommand.CommandType = CommandType.Text;
             if (SqLCommand.Parameters.Count != 0 && (!queryString.Contains("@")))
            {
                SqLCommand.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                SqLCommand.CommandType = CommandType.Text;
            }

            try
            {
                SqLCommand.CommandTimeout = 0;
                SqLCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
      
        private void btnBrowes_Click(object sender, EventArgs e)
        {
            try
            {
                flbBackup.ShowDialog();
                txtPath.Text = flbBackup.SelectedPath.ToString();                
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message, Application.ProductName);
            }
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {

            if (Validation())
                return;
            {
               // CreateConnectionStrion();
               // blank("backup");
                prgBackuplProgress.Maximum = 150;
                prgBackuplProgress.BackColor = Color.Red;
                prgBackuplProgress.Visible = true;
                progessvalue = 0;
                prgBackuplProgress.BackColor = Color.Red;
                timerProgress.Enabled = true;
            }

        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            try
            {
                prgBackuplProgress.BackColor = Color.Red;
                progessvalue += 5;
                if (progessvalue == 20)
                {
                    blank("backup"); 
                    
                }
                else if (progessvalue == 100)
                {
                    if (i == 1)
                    {
                        MessageBox.Show("The backup of database '"+cmbDataBaseName.Text+"' completed successfully.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        prgBackuplProgress.Visible = false;
                        timerProgress.Enabled = false;
                        this.Close();
                        if(DialogResult.Yes ==MessageBox.Show("Do You Want To Clear the Log.", Application.ProductName, MessageBoxButtons.YesNo))
                        {
                            FrmLogFileClear frm = new FrmLogFileClear();
                            frm.StartPosition = FormStartPosition.CenterScreen;
                            frm.ShowDialog(this);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Database Backup Not Completed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        prgBackuplProgress.Visible = false;
                        timerProgress.Enabled = false;
                    }
                }
                else if (progessvalue > 100)
                {
                    prgBackuplProgress.Visible = false;
                    timerProgress.Enabled = false;
                }
                prgBackuplProgress.Value = progessvalue;
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        private void ComboBoxserverName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void cmbDataBaseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBackUpName.Text = cmbDataBaseName.Text + "-" + System.DateTime.Now.ToShortDateString() + "-" + System.DateTime.Now.ToString("HH.mm.ss.tt"); 
        }
       
    }
}
