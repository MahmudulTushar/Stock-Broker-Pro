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
using StockbrokerProNewArch.Classes;

namespace StockbrokerProNewArch
{
   
    
    partial class frm_FlexTp_FtpSync : Form
    {

        public string TempFilePath;
        
        public frm_FlexTp_FtpSync()
        {
            CommonBAL bal=new CommonBAL();
            InitializeComponent();
            TempFilePath = bal.GetSBPTempFileLocation();
            txt_Path.Text = @"ftp://10.250.128.103:8021/";
            txt_UserName.Text = "ftp_KSL";
            txt_Password.Text = "MyODY5%";
        }

        
        public void Export_ClientFile()
        {

            FlexTpSyncBal bal = new FlexTpSyncBal();
            List<ClientRegistration> crReg = new List<ClientRegistration>();
            List<ClientDeactivation> crDeActive = new List<ClientDeactivation>();
           

            try
            {
                bal.ConnectDatabase();

                List<ClientLimits> cashLimit = new List<ClientLimits>();

                DataTable dtcash_Base = bal.GetRecentClientLimit_UITransApplied();
                //var dtcash = dtcash_Base.Rows.Cast<DataRow>().GroupBy(t => Convert.ToString(t["Cust_Code"]))
                //    .Select(t => new { Cust_Code = Convert.ToString(t.Key), Balance =t.Sum(o=> Convert.ToDouble(o["Matured_Balance"].ToString()))}).ToList();
                //ClientLimits limit=new ClientLimits();
                if (dtcash_Base.Rows.Count > 0)
                {

                    foreach (DataRow row in dtcash_Base.Rows)
                    {
                        //try
                        //{
                        SBPXMLSchema.ClientLimits limit = new ClientLimits();
                        //limit.BranchID = "1";// row["Branch Name"].ToString();
                        //if (Convert.ToString(row[0]) == "1001" || Convert.ToString(row[0]) == "10003")
                        //{
                        //    string kk = "Kamal";
                        //}
                        if (Convert.ToDouble(row["Balance"]) > 0)
                        {
                            double dbl_Cash = Convert.ToDouble(row["Balance"].ToString());
                            double round_dbl_Cash = Math.Round(dbl_Cash);
                            long lng_Cash = long.Parse(round_dbl_Cash.ToString());
                            limit.Cash = lng_Cash;//long.Parse(Math.Round(Convert.ToDouble(row["Cash"].ToString())).ToString());
                        }
                        else
                        {
                            limit.Cash = long.Parse("0");
                        }
                        limit.ClientCode = row["Cust_Code"].ToString();
                        cashLimit.Add(limit);
                        //}
                        //catch (Exception ex)
                        //{
                        //    string kk = ex.Message;
                        //}
                    }
                    //Write(dtcash);
                }

                DataTable dt = new DataTable();
                dt = bal.GetRecentClientRegistration_UITransApplied();
                List<string> NegCustCode = dtcash_Base.Rows.Cast<DataRow>().Where(t => Convert.ToDouble(t["Balance"].ToString()) < 0).Select(t => Convert.ToString(t["Cust_Code"])).ToList();
                List<DataRow> NewRegistered = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["ProcessingMode"]) == "New").ToList();
                List<DataRow> ChangeRegistered = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["ProcessingMode"]) == "Changed").ToList();
                List<DataRow> DeActiveRegistered = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["ProcessingMode"]) == "Closed").ToList();

                foreach (DataRow dr in NewRegistered)                               
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
                    crRegTemp.ClientCode = dr["Cust_Code"].ToString();
                    crRegTemp.DealerID = dr["Assigned_WorkStation"].ToString();
                    crRegTemp.ICNo = dr["ICNo"].ToString();
                    crRegTemp.Name = dr["Cust_Name"].ToString();
                    crRegTemp.ShortName = dr["Short_Name"].ToString().Split(' ').Last();
                    if (NegCustCode.Contains(dr["Cust_Code"].ToString()))
                        crRegTemp.ShortSellingAllowed = SBPXMLSchema.BooleanYesNo.No;
                    else
                        crRegTemp.ShortSellingAllowed = SBPXMLSchema.BooleanYesNo.Yes;
                    crRegTemp.Tel = dr["Tel"].ToString();
                    crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.Yes;
                    crReg.Add(crRegTemp);
                    //}
                    //catch (Exception ex)
                    //{
                    //    string kk = ex.Message;
                    //}
                }

                foreach (DataRow dr in ChangeRegistered)
                {
                    //try
                    //{
                    SBPXMLSchema.ClientRegistration tempRegistration = new ClientRegistration();
                    if (dr["AccountType"].ToString() == "Non Resident")
                        tempRegistration.AccountType = SBPXMLSchema.AccountType.R;// NRB
                    else if (dr["AccountType"].ToString() == "Resident")
                        tempRegistration.AccountType = SBPXMLSchema.AccountType.N;// NORMAL
                    tempRegistration.Address = dr["Address"].ToString();
                    tempRegistration.BOID = dr["BOID"].ToString();
                    tempRegistration.ClientCode = dr["Cust_Code"].ToString();
                    tempRegistration.DealerID = dr["Assigned_WorkStation"].ToString();
                    tempRegistration.ICNo = dr["ICNo"].ToString();
                    tempRegistration.Name = dr["Cust_Name"].ToString();
                    tempRegistration.ShortName = dr["Short_Name"].ToString().Split(' ').Last();
                    if (NegCustCode.Contains(dr["Cust_Code"].ToString()))
                        tempRegistration.ShortSellingAllowed = SBPXMLSchema.BooleanYesNo.No;
                    else
                        tempRegistration.ShortSellingAllowed = SBPXMLSchema.BooleanYesNo.Yes;
                    tempRegistration.Tel = dr["Tel"].ToString();
                    tempRegistration.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.Yes;
                    crReg.Add(tempRegistration);

                    SBPXMLSchema.ClientDeactivation tmpDeActive = new ClientDeactivation();
                    tmpDeActive.ClientCode = dr["Cust_Code"].ToString();
                    crDeActive.Add(tmpDeActive);

                    //}
                    //catch (Exception ex)
                    //{
                    //    string kk = ex.Message;
                    //}
                }

                foreach (DataRow dr in DeActiveRegistered)
                {
                    SBPXMLSchema.ClientDeactivation tmpDeActive = new ClientDeactivation();
                    tmpDeActive.ClientCode = dr["Cust_Code"].ToString();
                    crDeActive.Add(tmpDeActive);

                    //}
                    //catch (Exception ex)
                    //{
                    //    string kk = ex.Message;
                    //}
                }

                Clients cs = new Clients();
                //cs.DeactivateAllClients = (object)string.Empty;
                cs.Deactivate = crDeActive.ToArray();
                cs.Register = crReg.ToArray();                
                cs.Limits = cashLimit.ToArray();
                cs.ProcessingMode = SBPXMLSchema.ProcessingMode_Clients.BatchInsertOrUpdate;
                SBPXMLSchema.XMLExport xprt = new XMLExport(XMLExportType.Clients, cs, TempFilePath + "\\");
                xprt.Export();

                FtpClient ftp = new FtpClient(txt_Path.Text, txt_UserName.Text, txt_Password.Text);
                ftp.upload(xprt.ClientXML_FileName, xprt.fileName);
                ftp.upload(xprt.ClientXML_Control_FileName,xprt.fileName);
                
                bal.UpdateFtpTransferInformation_ClientRegistration_UITransApplied(xprt.fileName,FlexTpExportFileType.ClientRegistration,dt);
                //bal.UpdateFtpTransferInformation_ClientLimit_UITransApplied(xprt.fileName, FlexTpExportFileType.ClientLimit, dtcash_Base);

                bal.Commit();
            }
            catch (Exception ex)
            {
                bal.RollBack();
                throw new Exception(ex.Message);
            }
            finally 
            {
                bal.CloseDatabase();
            }
        
        }

        public void RefillClientsRecords()
        {
            try
            {
                FlexTpSyncBal bal = new FlexTpSyncBal();

                //bal.RefillRecent_ClientLimit();
                bal.RefillRecent_ClientRegistration();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        private void btnClient_Click(object sender, EventArgs e)
        {
            try
            {
                RefillClientsRecords();
                Export_ClientFile();
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
                
                MessageBox.Show("Write successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}
