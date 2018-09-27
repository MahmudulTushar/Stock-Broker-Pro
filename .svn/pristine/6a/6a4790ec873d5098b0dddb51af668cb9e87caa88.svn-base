using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class LimitListP : Form
    {
        public LimitListP()
        {
            InitializeComponent();
        }

        private void btnCashLimit_Click(object sender, EventArgs e)
        {
            try
            {
                CashLimitBAL cashLimitBal = new CashLimitBAL();
                DataTable datatable = cashLimitBal.GetCashLimitDataP();
                if (datatable.Rows.Count > 0)
                {
                    Write(datatable);
                }
                else
                {
                    MessageBox.Show("No Data for export.");
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error occured." + exc.Message);
            }
        }
        public void Write(DataTable dt)
        {
            int i = 0;
            string sFileName = null;
            StreamWriter sw = null;
            try
            {
                SaveFileDialog oDialog = new SaveFileDialog();
                oDialog.Filter = "Text files | *.txt";
                
                if (oDialog.ShowDialog() == DialogResult.OK)
                {
                    sFileName = oDialog.FileName;
                }
                if (sFileName != null)
                {
                    sw = new StreamWriter(sFileName, false);
                    foreach (DataRow row in dt.Rows)
                    {
                        object[] array = row.ItemArray;

                        for (i = 0; i < array.Length - 1; i++)
                        {
                            sw.Write(array[i].ToString() + ",");
                        }
                        sw.WriteLine(array[i].ToString());
                    }
                    sw.Close();
                    MessageBox.Show("Report saved with file: " + sFileName, "To Text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();


                }
                else
                {
                    //oEXLApp.ActiveWorkbook.Close(false, Missing.Value, Missing.Value);
                    MessageBox.Show("Cannot export to Text...", "Can't export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Invalid Operation : \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
