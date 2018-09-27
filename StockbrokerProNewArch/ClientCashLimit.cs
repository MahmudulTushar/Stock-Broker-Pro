using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using System.Data;
using SBPXMLSchema;
using System.IO;

namespace StockbrokerProNewArch
{
    partial class ClientCashLimit : Form
    {
        public ClientCashLimit()
        {
            InitializeComponent();
            cmbgenerate.SelectedIndex = 0;
            
        }

        private void ClientRegistration()
        {
            XMLFolderChoose.ShowDialog();
            string folderpath = XMLFolderChoose.SelectedPath;
            if (folderpath != string.Empty)
            {
                xmlSchemaBAL objbal = new xmlSchemaBAL();
                List<ClientRegistration> crList = new List<ClientRegistration>();
                DataTable dt = new DataTable();
                dt = objbal.GetSchema();
                foreach (DataRow dr in dt.Rows)
                {
                    //try
                    //{
                        SBPXMLSchema.ClientRegistration crRegTemp = new ClientRegistration();
                        if (dr["AccountType"].ToString() == "Non Resident")
                            crRegTemp.AccountType = SBPXMLSchema.AccountType.R;// NRB
                        else if (dr["AccountType"].ToString() == "Resident")
                            crRegTemp.AccountType = SBPXMLSchema.AccountType.N;// NORMAL
                        crRegTemp.Address = dr["Address"].ToString();
                        crRegTemp.BOID = dr["BOID"].ToString();
                        crRegTemp.ICNo = dr["Branch ID"].ToString();
                        //crRegTemp.BranchID = "1";//dr["Branch ID"].ToString();
                        crRegTemp.ClientCode = dr["Client Code"].ToString();
                        crRegTemp.DealerID = dr["DealerID"].ToString();
                        crRegTemp.ICNo = dr["Nationa id"].ToString();
                        crRegTemp.Name = dr["Name"].ToString();
                        crRegTemp.ShortName = dr["Short Name"].ToString().Split(' ').Last();
                        crRegTemp.ShortSellingAllowed = SBPXMLSchema.BooleanYesNo.No;
                        crRegTemp.Tel = dr["Telephone"].ToString();
                        crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.No;
                        crList.Add(crRegTemp);
                    //}
                    //catch (Exception ex)
                    //{
                    //    string kk = ex.Message;
                    //}
                }

                List<ClientLimits> cashLimit = new List<ClientLimits>();
                DataTable dtcash = new DataTable();
                dtcash = objbal.GetClientCashLimit();
                //ClientLimits limit=new ClientLimits();
                if (dtcash.Rows.Count > 0)
                {

                    foreach (DataRow row in dtcash.Rows)
                    {
                        //try
                        //{
                            SBPXMLSchema.ClientLimits limit = new ClientLimits();
                            //limit.BranchID = "1";// row["Branch Name"].ToString();
                            //if (Convert.ToString(row[0]) == "1001" || Convert.ToString(row[0]) == "10003")
                            //{
                            //    string kk = "Kamal";
                            //}
                            if (Convert.ToDouble(row["Cash"]) > 0)
                            {
                                double dbl_Cash = Convert.ToDouble(row["Cash"].ToString());
                                double round_dbl_Cash = Math.Round(dbl_Cash);
                                long lng_Cash = long.Parse(round_dbl_Cash.ToString());
                                limit.Cash = lng_Cash;//long.Parse(Math.Round(Convert.ToDouble(row["Cash"].ToString())).ToString());
                            }
                            else
                            {
                                limit.Cash = long.Parse("0");
                            }
                            limit.ClientCode = row["Client Code"].ToString();
                            cashLimit.Add(limit);
                        //}
                        //catch (Exception ex)
                        //{
                        //    string kk = ex.Message;
                        //}
                    }
                    //Write(dtcash);
                }
                List<InsertOnePosition> InsertPos = new List<InsertOnePosition>();
                DataTable dtposition = new DataTable();
                dtposition = objbal.GetPositions();
                foreach (DataRow row in dtposition.Rows)
                {
                    SBPXMLSchema.InsertOnePosition ps = new InsertOnePosition();
                    //pos.BranchID = row["Branch ID"].ToString();
                    ps.ClientCode = row["Client Code"].ToString();
                    ps.SecurityCode = row["SecurityCode"].ToString();
                    ps.Quantity = Convert.ToInt32(row["Quantity"]);
                    ps.TotalCost = Convert.ToDouble(row["Total Cost"]);
                    InsertPos.Add(ps);
                }

                if (cmbgenerate.SelectedItem.Equals("Client cash"))
                {
                    try
                    {
                        Clients cs = new Clients();
                        cs.DeactivateAllClients =(object)string.Empty; 
                        cs.Register = crList.ToArray();
                        cs.Limits = cashLimit.ToArray();
                        cs.ProcessingMode = SBPXMLSchema.ProcessingMode_Clients.BatchInsertOrUpdate;
                        SBPXMLSchema.XMLExport xprt = new XMLExport(XMLExportType.Clients, cs, folderpath);
                        xprt.Export();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (cmbgenerate.SelectedItem.Equals("Position"))
                {
                    try
                    {
                        Positions p = new Positions();
                        p.Items = InsertPos.ToArray();
                        p.ProcessingMode = SBPXMLSchema.ProcessingMode_Position.BatchInsertOrUpdate;
                        SBPXMLSchema.XMLExport xprt = new XMLExport(XMLExportType.Position, p, folderpath);
                        xprt.Export();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            //SBPXMLSchema.InsertOnePosition ist = new InsertOnePosition();
           
            
            //try
            //{
            //    SBPXMLSchema.XMLExport xprt = new XMLExport(XMLExportType.Position, p, @"F:\ClientXml\ClientLimit.xml");
            //    xprt.Export();                
            //    //File.WriteAllText(@"D:\test.xml", cs);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

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
                            sw.Write(array[i].ToString() + "~");
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

        private void btnClientcash_Click(object sender, EventArgs e)
        {
            try
            {
                SBPXMLSchema.XMLExport.Date = System.DateTime.Now;
                SBPXMLSchema.XMLExport.Time = System.DateTime.Now;
                ClientRegistration();
                MessageBox.Show("Write successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnposition_Click(object sender, EventArgs e)
        {
            try
            {
                SBPXMLSchema.XMLExport.Date = System.DateTime.Now;
                SBPXMLSchema.XMLExport.Time = System.DateTime.Now;
                ClientRegistration();
                MessageBox.Show("Write successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}
