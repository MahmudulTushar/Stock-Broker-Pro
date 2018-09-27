using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using System.IO;

namespace StockbrokerProNewArch
{
    public partial class frm_IPOResultImport : Form
    {
        public frm_IPOResultImport()
        {
            InitializeComponent();
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                txtFileLocation.Text = openFileDialog1.FileName;
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            try
            {
                ImportFileValidation();
                IPOProcessBAL ipoBal = new IPOProcessBAL();
                UploadProcess();
                DataTable dt=ipoBal.GetIPOResultTempData();
                dg_ResultTemp.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ImportFileValidation()
        {
            IPOProcessBAL ipoBal = new IPOProcessBAL();
            
            //checking Short Code
            string Short_Code_from_Database= ipoBal.GetCompanyShortCodeBySessionID(Convert.ToInt32(cmb_SessionName.SelectedValue));
            string Short_Code_From_File = ProcessResultFile(txtFileLocation.Text).Rows.Cast<DataRow>().Select(t => Convert.ToString(t[6])).Distinct().First();
            if (Short_Code_from_Database != Short_Code_From_File)
                throw new Exception("Short Code Form File Not Matched!!");
            
        }

        private void LoadCombo()
        {
            IPOProcessBAL ipoBal = new IPOProcessBAL();
            DataTable dt=ipoBal.GetIPOSessionALL();
            cmb_SessionName.DataSource = dt;
            cmb_SessionName.DisplayMember = "Company_Name";
            cmb_SessionName.ValueMember = "ID";
            cmb_SessionName.SelectedIndex= - 1;
        }

        private void frm_IPOResultImport_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void cmb_SessionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            IPOProcessBAL ipoBal=new IPOProcessBAL();
            if (cmb_SessionName.ValueMember != string.Empty)
            {
                
                int id = Convert.ToInt32(cmb_SessionName.SelectedValue);
                txt_SessionName.Text=ipoBal.GetIPOSessionName_CompanyName_BySessionID(id);
                txt_SessionID.Text = Convert.ToString(id);
            }
        }
        private void UploadProcess()
        {
            DataTable ipoResultDataTable = null;
            ipoResultDataTable = ProcessResultFile(txtFileLocation.Text);
            IPOProcessBAL ipoBal = new IPOProcessBAL();
            ipoBal.TruncateResultTemp();
            ipoBal.UpdateResultTemp(ipoResultDataTable);
            int id = Convert.ToInt32(cmb_SessionName.SelectedValue);
            ipoBal.UpdateResultTempBySessionID(id);
        }

        private DataTable ProcessResultFile(string filePath)
        {
            string lineText;
            string[] tempValue;
            char proChar = '~';
            StreamReader streamReader = new StreamReader(filePath);
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            lineText = streamReader.ReadLine();
            tempValue = lineText.Trim().Split(proChar);

            for (int i = 0; i < tempValue.Length; ++i)
            {
                dataTable.Columns.Add(new DataColumn());
            }

            do
            {
                dataRow = dataTable.NewRow();
                string[] values = lineText.Trim().Split(proChar);
                values[4] = values[4].Substring(8, 8);
                
                dataRow.ItemArray = values;
                dataTable.Rows.Add(dataRow);
                lineText = streamReader.ReadLine();
            } while (lineText != null);
           
            return dataTable;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Process_Click(object sender, EventArgs e)
        {
            try
            {
                IPOProcessBAL ipoBal = new IPOProcessBAL();
                ipoBal.UpdateApplication_ByResultTemp();
                MessageBox.Show("Datat Process Successfully");
                DataTable dt = ipoBal.GetIPOResultTempData();
                dg_ResultTemp.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dg_ResultTemp_DataSourceChanged(object sender, EventArgs e)
        {
            lbl_CountGrid.Text = "Count: " + dg_ResultTemp.Rows.Count;
        }


    }
}
