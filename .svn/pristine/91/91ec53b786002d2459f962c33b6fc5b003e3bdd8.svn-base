using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using DataAccessLayer;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class DSE_P_E_Ratio : Form
    {

        private DbConnection dbConn= new DbConnection ();
        



        public DSE_P_E_Ratio()
        {
            InitializeComponent();
        }
             
        
        private void GetDataTable()
        {

            try
            {
                string fullPathToExcel = txt_FileLoction.Text;  //ie C:\Temp\YourExcel.xls
                string connString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=yes'", fullPathToExcel);

                OleDbConnection excelConnection = new OleDbConnection(connString);
                OleDbCommand cmd = new OleDbCommand("SELECT * from [Sheet1$]", excelConnection);

                excelConnection.Open();

                OleDbDataReader dr = cmd.ExecuteReader();


                string Delete_Query = @"Truncate Table Tb_DSE_Price_Earning_Ratio";
                dbConn.ConnectDatabase();
                dbConn.ExecuteNonQuery(Delete_Query);
                dbConn.ConnectDatabase();

                while (dr.Read())
                {
                    if (dr[1].ToString() != "")
                    {

                        //(string)dataGridView1.Rows[i].Cells["TransactionID"].Value ?? string.Empty


                        string Sl = dr[0].ToString();
                        string Trading_Code = dr[1].ToString();

                        double Close_Price = 0;
                        if (dr[2].ToString() != "")
                            Close_Price = Convert.ToDouble(dr[2].ToString());

                        double YCP = 0;
                        if (dr[3].ToString() != "")
                            YCP = Convert.ToDouble(dr[3].ToString());

                        double P_E_1_Basic = 0;
                        if (dr[4].ToString() != "")
                            P_E_1_Basic = Convert.ToDouble(dr[4].ToString());



                        CommonBAL bal = new CommonBAL();
                        string ctg = bal.GetCompanyCategory(Trading_Code);

                        string Margingin = "Margin";

                        if (ctg == "Z")
                        {
                            Margingin = "Non_Margin";
                        }
                        else if (P_E_1_Basic > 40)
                        {
                            Margingin = "Non_Margin";
                        }
                        else if (P_E_1_Basic <= 0)
                        {
                            Margingin = "Non_Margin";
                        }


                        String sqlStart = @"INSERT INTO Tb_DSE_Price_Earning_Ratio
                                     (       Sl, 
                                            Trading_Code,
                                            Close_Price, 
                                            YCP,
                                            P_E_1_Basic,                                         
                                            Stutas,
                                            PE_Margining
                                       )
                                    VALUES(
                                            '" + Sl + @"',
                                            '" + Trading_Code + @"',
                                            '" + Close_Price + @"',
                                            '" + YCP + @"',
                                            '" + P_E_1_Basic + @"',                                                                                     
                                            '1',
                                            '" + Margingin + @"'
                                             )";

                        // dbConn.ConnectDatabase();
                        dbConn.ExecuteNonQuery(sqlStart);
                    }
                }
                excelConnection.Close();

                DSE_PE_LodeGird();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Data Input Unsuccessful", "", MessageBoxButtons.OK, MessageBoxIcon.Warning  );
            }
            finally
            {

                MessageBox.Show("Data Input Successfully","", MessageBoxButtons.OK);
            }

        }

        private void btt_Processingexcel_Click(object sender, EventArgs e)
        {
            GetDataTable();

          //  DSE_PE_LodeGird();

        }

        private void DSE_PE_LodeGird()
        {

            string query = @"SELECT Sl,Trading_Code, YCP, P_E_1_Basic AS P_E_Update, PE_Margining
                                     FROM Tb_DSE_Price_Earning_Ratio";

            dbConn.ConnectDatabase();
            DSE_PE_GridView.DataSource = dbConn.ExecuteQuery(query);

            lab_desDTrowCount.Text = "Total Count Row  : " + DSE_PE_GridView.RowCount ;
        }

        private void btt_Findexel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

           openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Excel Files";

            openFileDialog1.CheckFileExists = true;
          
            openFileDialog1.Filter = "Excel files|*.xls;*.xlsx";

            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_FileLoction.Text = openFileDialog1.FileName;
            }
          
        }

        private void DSE_P_E_Ratio_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PE_Mismas_LodeGird();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (Gridview_PE_Mismas.RowCount >0)
            {
                string Query = @"UPDATE  SBP_Company
                            SET  IsMargin =(
                                             case when PE.PE_Margining='Margin' Then 1 
			                                    When PE.PE_Margining='Non_Margin'  Then 0 
			                                        Else '' END 
			             	                )
                            FROM  SBP_Company as com INNER JOIN
                                   Tb_DSE_Price_Earning_Ratio as PE ON com.Comp_Short_Code = PE.Trading_Code";

                dbConn.ConnectDatabase();
                dbConn.ExecuteNonQuery(Query);

                PE_Mismas_LodeGird();
            }

        }


        private void PE_Mismas_LodeGird()
        {

            string query = @" SELECT comp.Comp_Short_Code,
                                per.PE_Margining as DSE_Margin_Status, 
                                        (case when comp.IsMargin=1 Then'Margin'  
			                                   When comp.IsMargin=0 Then'Non_Margin' 
			                                       Else '' END 
		                                )As SBP_Margin_Status                           
                                FROM dbo.SBP_Company AS comp INNER JOIN
                                        dbo.Tb_DSE_Price_Earning_Ratio AS per ON comp.Comp_Short_Code = per.Trading_Code                     
                                             WHERE (per.PE_Margining <> ( case when comp.IsMargin=1 Then'Margin'  
			                                                                  When comp.IsMargin=0 Then'Non_Margin' 
			                                                               Else '' END  
			                             ))";

            dbConn.ConnectDatabase();
            Gridview_PE_Mismas.DataSource = dbConn.ExecuteQuery(query);
        }

        private void lab_desDTrowCount_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_Market_Value frm = new frm_Market_Value();

            frm.ShowDialog(this);
        }



    }
}
