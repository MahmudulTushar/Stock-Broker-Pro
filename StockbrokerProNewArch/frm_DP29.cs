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

namespace StockbrokerProNewArch
{
    public partial class frm_DP29 : Form
    {
        public frm_DP29()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFileLocationBrowser_Click(object sender, EventArgs e)
        {
            if (ofdFileOpen.ShowDialog() == DialogResult.OK)
                txtFileLocation.Text = ofdFileOpen.FileName;
        }

        private void btnStartImport_Click(object sender, EventArgs e)
        {
            ProcessBO_29();
        }

        private void ProcessBO_29()
        {
            try
            {
                if(txtFileLocation.Text.Trim()==string.Empty)
                {
                    MessageBox.Show("No file is Selceted.", "File Upload", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }

                else if(txtFileLocation.Text.Trim()!=string.Empty && ofdFileOpen.FileName.Length==0)
                {
                    MessageBox.Show("No data Exists in the selection File.", "File Upload", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }

                else
                {
                        CustomerBO_DP29Collection objCustomerBO_DP29Collection = new CustomerBO_DP29Collection();
                        objCustomerBO_DP29Collection = GetCustomerCollection(ofdFileOpen.FileName);
                        CustomerBO_DP29BAL objCustomerDP29BAL = new CustomerBO_DP29BAL();
                        progress.Maximum = objCustomerBO_DP29Collection.Count;
                        lbProText.Text = "Uploading...";

                        foreach (CustomerBO_DP29 objCustomerBO_DP29 in objCustomerBO_DP29Collection)
                        {
                                                
                            try
                            {
                               
                                objCustomerDP29BAL.InsertCustomerBO_DP29(objCustomerBO_DP29);
                                progress.Value = progress.Value + 1;
                                

                                if (progress.Value == progress.Maximum)
                                {
                                    lbProText.Text = "Uploading is Completed";
                                    GetClientBOInformation();
                                }
                                
                             }
                            catch (Exception ex)
                            {
                                
                               AddErrorInGrid(objCustomerBO_DP29.BoId,objCustomerBO_DP29.CustomerFullName,ex.Message);
                            }
                           
                        }

                    MessageBox.Show("Sucessfully Uploaded File Information");

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddErrorInGrid(string BOID,string Cust_Name, string errorMessage)
        {

            string[] rowString = new string[] { (dgvErrors.Rows.Count + 1).ToString(),BOID,Cust_Name, errorMessage };
            dgvErrors.Rows.Add(rowString);
        }

        private CustomerBO_DP29Collection GetCustomerCollection(string filepath)
        {
            const char existingChar = '~';
            CustomerBO_DP29Collection objCustomerBO_DP29Collection=new CustomerBO_DP29Collection();
            StreamReader streamReader=new StreamReader(filepath);

            try
            {
                while (streamReader.Peek()>0)
                {
                    string[] Info = streamReader.ReadLine().Split(existingChar);
                    CustomerBO_DP29 objCustomerBO=new CustomerBO_DP29();
                    CustomerBO_DP29BAL objCustomerBAL=new CustomerBO_DP29BAL();

                    objCustomerBO.BoId = Info[0].Replace("'", "''");
                    objCustomerBO.BoType = Info[1].Replace("'", "''");
                    objCustomerBO.BoCategory = Info[2].Replace("'", "''");
                    objCustomerBO.CustomerFullName = Info[3].Replace("'", "''");
                    objCustomerBO.CustomerShortName = Info[4].Replace("'", "''");
                    objCustomerBO.Address= Info[5].Replace("'", "''");
                    objCustomerBO.City = Info[6].Replace("'", "''");
                    objCustomerBO.Satate = Info[7].Replace("'", "''");
                    objCustomerBO.Country = Info[8].Replace("'", "''");
                    objCustomerBO.PurposeCode = Info[9].Replace("'", "''");
                    objCustomerBO.Residency = Info[10].Replace("'", "''");
                    objCustomerBO.Phone = Info[11].Replace("'", "''");
                    objCustomerBO.Fax= Info[12].Replace("'", "''");
                    objCustomerBO.Email = Info[13].Replace("'", "''");
                    objCustomerBO.InternalReferenceNo= Info[14].Replace("'", "''");
                    objCustomerBO.SetupDate = Info[15].Replace("'", "''");
                    objCustomerBO.BoStatus = Info[16].Replace("'", "''");
                    objCustomerBO.ClosureDate = Info[17].Replace("'", "''");
                    objCustomerBO.FatherName = Info[18].Replace("'", "''");
                    objCustomerBO.MotherName = Info[19].Replace("'", "''");
                    objCustomerBO.BankName = Info[20].Replace("'", "''");
                    objCustomerBO.BranchName = Info[21].Replace("'", "''");
                    objCustomerBO.AccountNo = Info[22].Replace("'", "''");
                    objCustomerBO_DP29Collection.Add(objCustomerBO);

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return objCustomerBO_DP29Collection;
        }

        private void GetClientBOInformation()
        {
            try
            {
                CustomerBO_DP29BAL objBO29BAL=new CustomerBO_DP29BAL();
                DataTable data=new DataTable();
                data = objBO29BAL.GetClientBOInfo();
                dgvClientInfo.DataSource = data;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvExtension_GridFilterBound(object sender, GridViewExtensions.GridFilterEventArgs args)
        {
                      
        }

        private void dgvExtension_AfterFiltersChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvExtension_BeforeFiltersChanging(object sender, EventArgs e)
        {
            MessageBox.Show("Before Filter Changing");
        }
    }
}
