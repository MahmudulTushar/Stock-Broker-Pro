using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DataAccessLayer;

namespace StockbrokerProNewArch
{
    public partial class Frm_Emp_CV_View : Form
    {
        
        private DbConnection dbcon=new DbConnection ();

        public Frm_Emp_CV_View()
        {
            InitializeComponent();
        }

        private   byte[] pdfBytes = null;

        private void button1_Click(object sender, EventArgs e)
        {
            string ToLocation = "D:\\Report.pdf";

            File.Delete(ToLocation);

            using (System.IO.FileStream fs = new System.IO.FileStream(ToLocation, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
            {
                using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                {
                    try
                    {
                        bw.Write(PdfView(txt_EmpID.Text));
                        bw.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Employe ID is not find !!");
                    }
                   
                }

                axAcroPDF1.Refresh();
                axAcroPDF1.src = ToLocation;

            }

        }

        public byte[] PdfView(string P_ID)
        {
            dbcon.Connect_ImageDB();

          DataTable dt = dbcon.ExecuteQuery(@"SELECT Emp_ID, Emp_CV_PDF  FROM   HR_Emp_DocFile WHERE (Emp_ID = '" + P_ID + "') ");          

            pdfBytes = null;
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                pdfBytes = (byte[])row["Emp_CV_PDF"];
           }      
            return pdfBytes;

        }

    }
}
