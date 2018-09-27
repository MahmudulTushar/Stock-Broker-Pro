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
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class AdditionalHolderInfo : Form
    {
        public AdditionalHolderInfo()
        {
            InitializeComponent();
        }

        private void btnFileLocationBrowser_Click(object sender, EventArgs e)
        {
            if (ofdFileOpen.ShowDialog() == DialogResult.OK)
                txtFileLocation.Text = ofdFileOpen.FileName;
        }

        private void btnStartImport_Click(object sender, EventArgs e)
        {
            UploadProcess();
        }

        private void AdditionalHolderInfo_Load(object sender, EventArgs e)
        {
            Reset();
        }
        private void UploadProcess()
        {
            ProcessingMessage("Processing CDBL File...");
            if (txtFileLocation.Text.Length.Equals(0))
            {
                err.SetError(txtFileLocation, "CDBL File location is a required field.");
                return;
            }
            else
            {
                err.SetError(txtFileLocation, "");
            }

            AdditionalInfoCollectionBO additionalInfoCollectionBo = new AdditionalInfoCollectionBO();
            try
            {
                additionalInfoCollectionBo = ProcessTextFile(txtFileLocation.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Fail to process txt file. No data saved. Because : " + exception.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset();
                return;
            }
            ProcessingMessage("Importing data into database....");
            progress.Maximum = additionalInfoCollectionBo.Count + 1;
            
            AdditionalInfoBAL additionalInfoBal = new AdditionalInfoBAL();
            

            try
            {
                //additionalInfoBal.ConnectDatabase();
                foreach (AdditionalInfoBO additionalInfoBo in additionalInfoCollectionBo)
                {
                    try
                    {
                        additionalInfoBal.ProcessDatabase(additionalInfoBo);
                    }
                    catch (Exception exception)
                    {
                        AddErrorInGrid(additionalInfoBo.AdditionalHolderName, exception.Message);
                    }
                    progress.PerformStep();
                }
                //additionalInfoBal.Commit();
                ProcessingMessage("Data imported successfully....");
                MessageBox.Show("New Additional Information Imported Successfully.", "Import Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //additionalInfoBal.RollBack();
            }
            //finally
            //{
            //    //additionalInfoBal.CloseDatabase();
            //}
            Reset();
        }

        private void ModificationProcess()
        {
            ProcessingMessage("Processing CDBL File...");
            if (txtFileLocation.Text.Length.Equals(0))
            {
                err.SetError(txtFileLocation, "CDBL File location is a required field.");
                return;
            }
            else
            {
                err.SetError(txtFileLocation, "");
            }

            AdditionalInfoCollectionBO additionalInfoCollectionBo = new AdditionalInfoCollectionBO();
            try
            {
                additionalInfoCollectionBo = ProcessTextFile(txtFileLocation.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Fail to process txt file. No data saved. Because : " + exception.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset();
                return;
            }
            ProcessingMessage("Updating data into database....");
            AdditionalInfoBAL additionalInfoBal = new AdditionalInfoBAL();

            try
            {
                //additionalInfoBal.ConnectDatabase();
                progress.Maximum = additionalInfoCollectionBo.Count + 1;
                foreach (AdditionalInfoBO additionalInfoBo in additionalInfoCollectionBo)
                {
                    try
                    {
                        additionalInfoBal.ProcessDatabase(additionalInfoBo);
                    }
                    catch (Exception exception)
                    {
                        AddErrorInGrid(additionalInfoBo.AdditionalHolderName, exception.Message);
                    }
                    progress.PerformStep();
                }
                ProcessingMessage("Data updated successfully....");
                MessageBox.Show("Customer Information Updated Successfully.", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //additionalInfoBal.Commit();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //additionalInfoBal.RollBack();
            }
            //finally
            //{
            //    additionalInfoBal.CloseDatabase();
            //}
            Reset();
        }

        private AdditionalInfoCollectionBO ProcessTextFile(string filePath)
        {
            const char proChar = '~';
            AdditionalInfoCollectionBO additionalInfoCollectionBo = new AdditionalInfoCollectionBO();
            StreamReader streamReader = new StreamReader(filePath);

            while (streamReader.Peek() >= 0)
            {
                string[] values = streamReader.ReadLine().Split(proChar);
                AdditionalInfoBO additionalInfoBo = new AdditionalInfoBO();
                AdditionalInfoBAL additionalInfoBal = new AdditionalInfoBAL();
                additionalInfoBo.CustCode = additionalInfoBal.GetCustCodeByBOID(values[0]);
                if (additionalInfoBo.CustCode.Trim()== "")
                {
                    AddErrorInGrid(values[0], "BO ID Not Found.");

                }
                else
                {
                    additionalInfoBo.FirstHolderName = values[1];
                    additionalInfoBo.PurposeCode = values[2];
                    additionalInfoBo.SerialNo = values[3];
                    additionalInfoBo.AdditionalHolderName = values[4];
                    additionalInfoBo.Institution = values[5];
                    additionalInfoBo.InstitutionName = values[6];
                    additionalInfoBo.Address1 = values[7];
                    additionalInfoBo.Address2 = values[8];
                    additionalInfoBo.Address3 = values[9];
                    additionalInfoBo.City = values[10];
                    additionalInfoBo.Division = values[11];
                    additionalInfoBo.Country = values[12];
                    additionalInfoBo.PostCode = values[13];
                    additionalInfoBo.Phone = values[14];
                    additionalInfoBo.Email = values[15];
                    additionalInfoBo.Fax = values[16];
                    if (!values[17].Trim().Length.Equals(0))
                        additionalInfoBo.EffetiveFrom = Convert.ToDateTime(values[17]);
                    if (!values[18].Trim().Length.Equals(0))
                        additionalInfoBo.EffectiveTo = Convert.ToDateTime(values[18]);
                    if (!values[19].Trim().Length.Equals(0))
                        additionalInfoBo.EntryDate = Convert.ToDateTime(values[19]);
                    additionalInfoBo.PassportNo = values[20];
                    if (!values[21].Trim().Length.Equals(0))
                        additionalInfoBo.PassportIssueDate = Convert.ToDateTime(values[21]);
                    if (!values[22].Trim().Length.Equals(0))
                        additionalInfoBo.PassportExpireDate = Convert.ToDateTime(values[22]);
                    additionalInfoBo.PassportIssuePlace = values[23];
                    additionalInfoBo.RelationShip = values[24];
                    additionalInfoBo.Percentage = float.Parse(values[25]);
                    additionalInfoBo.NationalID =values[26];
                    additionalInfoCollectionBo.Add(additionalInfoBo);
                }
            }
            return additionalInfoCollectionBo;
        }
        private void AddErrorInGrid(string customerCode, string errorMessage)
        {

            string[] rowString = new string[] { (dgvErrors.Rows.Count + 1).ToString(), customerCode, errorMessage };
            dgvErrors.Rows.Add(rowString);
        }
        private void ProcessingMessage(string message)
        {
            lbProText.Text = message;
            progress.PerformStep();
        }

        private void Reset()
        {
            lbProText.Text = "Ready for new import process..";
            progress.Maximum = 100;
            progress.Value = 0;
        }
    }
}
