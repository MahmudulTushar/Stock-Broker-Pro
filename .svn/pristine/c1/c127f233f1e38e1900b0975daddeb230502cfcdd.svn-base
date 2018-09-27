using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StockbrokerProNewArch.Classes;

namespace StockbrokerProNewArch
{
    public partial class frmWebDataExport : Form
    {
        public frmWebDataExport()
        {
            InitializeComponent();
        }

        private void btnExportLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string foldername = folderBrowserDialog.SelectedPath;
                txtLocation.Text = foldername;
               
            }

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLocation.Text.Trim() != string.Empty)
                {
                    this.Height = 203;
                    WebDataExportOld webDataExport = new WebDataExportOld();
                    webDataExport.GenerateFile(txtLocation.Text);
                    lblProcess.Text = "Data Sucessfully Exported";
                    MessageBox.Show("Data Sucessfully Exported.","Data Export",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                   
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

       
    }
}
