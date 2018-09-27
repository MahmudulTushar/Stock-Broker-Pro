using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using System.Data.SqlClient;

namespace StockbrokerProNewArch
{
    public partial class FrmLogFileClear : Form
    {

        private int progessvalue = 0;
        private int i = 0;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string Connectionstring = string.Empty;
        public static SqlConnection data;
        public FrmLogFileClear()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLogFileClear_Load(object sender, EventArgs e)
        {
            serverName();
        }


        public void serverName()
        {
            string dataSourse = "Initial Catalog=Master";
            string SBPDatabase = "Initial Catalog=SBP_Database";
            string CallCenterDataBase = "Initial Catalog=dbksclCallCenter";
            string Connection = DbConnectionBasic.ConnectionString.ToLower();
            List<string> ListConnection = new List<string>();
            char[] SpliteChar = { ';' };
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
            cmd = new SqlCommand("select * from sysdatabases where dbid>4", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbDataBaseName.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void ComboBoxserverName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCombo();
        }

        public bool Validation()
        {
            if (string.IsNullOrEmpty(ComboBoxserverName.Text))
            {
                MessageBox.Show("Server name Can Not be blank.");
                ComboBoxserverName.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(cmbDataBaseName.Text))
            {
                MessageBox.Show("Data Base name Can not be Blank");
                cmbDataBaseName.Focus();
                return true;
            }
            return false;
        }

        public void dataBaseClear()
        {
            string Connection = DbConnectionBasic.ConnectionString.ToLower();
            string DataBaseName ="Initial Catalog= " + cmbDataBaseName.Text;
            string[] ConnectionArray = Connection.Split(';');
            string SBPDatabase = "Initial Catalog=SBP_Database";
            List<string> listConn = new List<string>();
            Int64 logfileSize = 0;
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

            data = new SqlConnection(Connectionstring);

            SqlConnection constring = new SqlConnection(Connectionstring);
            constring.Open();
            cmbDataBaseName.Items.Clear();
            SqlCommand cmddata = new SqlCommand("select name,size from sysfiles WHERE groupid = 0", constring);
            dr = cmddata.ExecuteReader();
            while (dr.Read())
            {
                DatabaselogName = dr[0].ToString();
                logfileSize = Convert.ToInt64(dr[1].ToString());
            }
            dr.Close();


            if ((2 * 128) < logfileSize)
            {
                string Query = "DBCC SHRINKFILE('" + DatabaselogName + "', 2) BACKUP LOG " + cmbDataBaseName.Text + " TO DISK='NUL' DBCC SHRINKFILE('" + DatabaselogName + "', 2)";
                cmddata = new SqlCommand(Query, constring);
                cmddata.CommandTimeout = 0;
                cmddata.ExecuteNonQuery();
                MessageBox.Show("DataBase Log Clear Successfully.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("DataBase Already Log Clear","Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            i++;
        }
        private void btClear_Click(object sender, EventArgs e)
        {
            if (Validation())
                return;
            dataBaseClear();
        }


        public void ClearText()
        {
            cmbDataBaseName.Text = "";
            ComboBoxserverName.Text = "";
        }
    }
}
