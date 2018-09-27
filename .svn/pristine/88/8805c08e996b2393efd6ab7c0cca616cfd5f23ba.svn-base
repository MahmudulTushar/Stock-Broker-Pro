using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;

namespace StockbrokerProNewArch
{
    public partial class frm_Market_Value : Form
    {
        public frm_Market_Value()
        {
            InitializeComponent();
           
            
            string q = @"SELECT  Trading_Code, P_E_1_Basic, PE_Margining  FROM  Tb_DSE_Price_Earning_Ratio";
            Load_Combobox(Cmb_Com_Code, q, "Trading_Code", "PE_Margining");

        }
        private DbConnection dbConn = new DbConnection();

        private void frm_Market_Value_Load(object sender, EventArgs e)
        {
            //string q = @"SELECT  Trading_Code, P_E_1_Basic, PE_Margining  FROM  Tb_DSE_Price_Earning_Ratio";
            //Load_Combobox(Cmb_Com_Code, q, "Trading_Code", "PE_Margining");
        }

        private void Load_Combobox(ComboBox Combo, string query, string displayMember, string valueMember)
        {
            Combo.SelectedIndex = -1;

            dbConn.ConnectDatabase();

            Combo.DataSource = dbConn.ExecuteQuery(query);

            Combo.DisplayMember = displayMember;
            Combo.ValueMember = valueMember;
            Combo.SelectedIndex = -1;
            Combo.SelectedText = "Select Itme"; 
        }
        

        private void Cmb_Com_Code_SelectedIndexChanged(object sender, EventArgs e)
        {
            PE_Data_Find();
        }

        private void PE_Data_Find()
        {
            string selected = this.Cmb_Com_Code.GetItemText(this.Cmb_Com_Code.SelectedItem);

            string x = this.Cmb_Com_Code.GetItemText(this.Cmb_Com_Code.SelectedIndex);

            if (selected != "System.Data.DataRowView" && selected != "")
            {
                string query = @"SELECT  YCP, P_E_1_Basic, PE_Margining 
                                                          FROM  Tb_DSE_Price_Earning_Ratio
                                                                WHERE     (Trading_Code = N'" + selected + "')";
                dbConn.ConnectDatabase();
                DataTable dt = dbConn.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0] != DBNull.Value)
                        lab_ycp_val.Text = dt.Rows[0][0].ToString();

                    if (dt.Rows[0][1] != DBNull.Value)
                        lab_pe_val.Text = dt.Rows[0][1].ToString();

                    if (dt.Rows[0][2] != DBNull.Value)
                        lab_margin_val.Text = dt.Rows[0][2].ToString();
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

   


      
    }
}
