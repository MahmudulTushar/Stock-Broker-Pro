using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace StockbrokerProNewArch
{
    public partial class Margin_Non_Margin_History : Form
    {
        DataTable companyDataTable = new DataTable();
        CompanyBAL companyBal = new CompanyBAL();
        public Margin_Non_Margin_History()
        {
            InitializeComponent();
        }

        private void Frm_AllCompanyList_Load(object sender, EventArgs e)
        {
            
            LoadData();
        }
        private void LoadData()
        {
            dg_AllCompany.AllowUserToAddRows = false;
            dg_AllCompany.RowHeadersVisible = false;
            
            companyDataTable = companyBal.GetAllData();
            //foreach (DataRow dr in companyDataTable.Rows)
            //{
            //    string Cmp_Name = Convert.ToString(dr["Comp_Name"]);
            //    string ShortCode = Convert.ToString(dr["Comp_Short_Code"]);
            //    string Category = Convert.ToString(dr["Category_Name"]);
            //    string ISIN = Convert.ToString(dr["ISIN_No"]);
            //    string Sector = Convert.ToString(dr["Sector_ID"]);
            //    string Margin_NonMargin = Convert.ToString(dr["Margin"])==""?"":Convert.ToString(dr["Margin"]);
            //    //dg_AllCompany.Rows.Add(new object[] { Cmp_Name, ShortCode, });
            //}            
            dg_AllCompany.DataSource = companyDataTable;
        }

        private void btn_MarginUPdate_Click(object sender, EventArgs e)
        { 
            string CompanyName = dg_AllCompany.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells["Comp_Name"].Value)).FirstOrDefault(); ;
            string short_Code = dg_AllCompany.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells["Comp_Short_Code"].Value)).FirstOrDefault(); ;

            //companyBo.CompanyCategoryID = dg_AllCompany.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToInt32(c.Cells["Sector_ID"].Value)).FirstOrDefault(); ;

            bool IsMargin = dg_AllCompany.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToBoolean(c.Cells["IsMargin"].Value)).FirstOrDefault(); ;
             companyBal.UpdateMargin(short_Code, IsMargin);
             MessageBox.Show("Information UPdate successfully");
             companyDataTable = companyBal.GetAllData();
             dg_AllCompany.DataSource = companyDataTable;
        }

        private void Btt_Exportdata_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dg_AllCompany, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }

        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText)+ "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        private void btt_ExportPDF_Click(object sender, EventArgs e)
        {
           
            SaveFileDialog sfd = new SaveFileDialog();
          //  sfd.Filter = "Excel Documents (*.Pdf)|*.pdf";
            sfd.FileName = "Export.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ExportPDF(sfd.FileName);
               // ToCsV(dg_AllCompany, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }

        private void ExportPDF(string filename)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(dg_AllCompany.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;


            //Adding Header row
            foreach (DataGridViewColumn column in dg_AllCompany.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(100, 200, 200);
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dg_AllCompany.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }

            ////Exporting to PDF
            //string folderPath = "C:\\PDFs\\";
            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}
           
            using (FileStream stream = new FileStream(filename , FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DSE_P_E_Ratio frm = new DSE_P_E_Ratio();

            frm.ShowDialog(this);
        }

        
    }
}
