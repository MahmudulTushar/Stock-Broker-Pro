using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using SBPXMLSchema;
using System.Threading;
using System.IO;
using System.Net;

namespace StockbrokerProNewArch
{
    public partial class FrmFlex_TP_Data_Export_Module : Form
    {
        private xmlSchemaBAL objxmlSchemaBAL = new xmlSchemaBAL();
        public static bool isProgressed;
        string folderpath = string.Empty;
        public FrmFlex_TP_Data_Export_Module()
        {
            InitializeComponent();
            dtpTime.Enabled = true;

 
        }

        private void FrmFlex_TP_Data_Export_Module_Load(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (Isvalidation())
                return;
            XMLFolderChoose.ShowDialog();
            folderpath = XMLFolderChoose.SelectedPath;
            //Thread thrd = new Thread(WaitWindow_ThreadforIPOExport);
            //isProgressed = true;
            //thrd.Start();
            objxmlSchemaBAL.Multiple_Limit_Process();
            Client_Register();
            //isProgressed = false;
            MessageBox.Show("Write successfully","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
            FrmFlex_TP_Data_Export_Module frm = new FrmFlex_TP_Data_Export_Module();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);
        }


        private void WaitWindow_ThreadforIPOExport()
        {
            WaitWindow waitWindow = new WaitWindow();
            waitWindow.Show();
            while (isProgressed)
            {
                waitWindow.Refresh();
            }
            waitWindow.Close();
        }

        public void Client_Register()
        {
            try
            {

                SBPXMLSchema.XMLExport.Date = dtpDate.Value;
                SBPXMLSchema.XMLExport.Time = dtpTime.Value;
                

                if (cmbgenerate.Text.ToUpper().Trim() == ("Client cash").Trim().ToUpper())
                {
                    xmlSchemaBAL objbal = new xmlSchemaBAL();                  

                    List<ClientRegistration> crList = new List<ClientRegistration>();
                    List<ClientDeactivation> crDeActive = new List<ClientDeactivation>();
                    List<ClientSuspension> crSuspension = new List<ClientSuspension>();

                    DataTable dt = new DataTable();
                    dt = objbal.Get_Cust_Register();   
                
                    List<DataRow> NewRegistered = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Cust_Cheaking"]).ToUpper().Trim() == ("NEW").ToUpper().Trim()).ToList();
                    List<DataRow> ChangeRegistered = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Cust_Cheaking"]).ToUpper().Trim() == ("Change").ToUpper().Trim()).ToList();
                    List<DataRow> DeactiveRegistered = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Cust_Cheaking"]).ToUpper().Trim() == ("Closed").ToUpper().Trim()).ToList();
                    List<DataRow> SuspendRegistered = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Cust_Cheaking"]).ToUpper().Trim() == ("Suspened").ToUpper().Trim()).ToList();

                    #region NewRegistered
                    foreach (DataRow dr in NewRegistered)
                    {

                        SBPXMLSchema.ClientRegistration crRegTemp = new ClientRegistration();
                        if (dr["Client_Code"].ToString().ToUpper().Trim() == ("KSL122").ToUpper().Trim())
                        {
                            if (dr["AccountType"].ToString() == "Non Resident")
                                crRegTemp.AccountType = SBPXMLSchema.AccountType.R;// NRB
                            if (dr["AccountType"].ToString() == "Resident")
                                crRegTemp.AccountType = SBPXMLSchema.AccountType.D;// NORMAL
                        }
                        else
                        {
                            if (dr["AccountType"].ToString() == "Non Resident")
                                crRegTemp.AccountType = SBPXMLSchema.AccountType.R;// NRB
                            if (dr["AccountType"].ToString() == "Resident")
                                crRegTemp.AccountType = SBPXMLSchema.AccountType.N;// NORMAL
                        }
                        
                        crRegTemp.Address = dr["Address"].ToString();
                        crRegTemp.BOID = dr["BOID"].ToString();
                        //crRegTemp.ICNo = dr["Branch_ID"].ToString();
                        //crRegTemp.BranchID = "1";//dr["Branch ID"].ToString();
                        crRegTemp.ClientCode = dr["Client_Code"].ToString();
                        crRegTemp.DealerID = dr["DealerID"].ToString();
                        //crRegTemp.ICNo = dr["Nationa_id"].ToString();
                        crRegTemp.Name = dr["Name"].ToString();
                        crRegTemp.ShortName = dr["Short_Name"].ToString().Split(' ').Last();
                        crRegTemp.ShortSellingAllowed = SBPXMLSchema.BooleanYesNo.No;
                        crRegTemp.Tel = dr["Telephone"].ToString();

                        if (dr["Net_Adjustment"].ToString().ToUpper().Trim() != "")
                        {
                            string AAA = dr["Client_Code"].ToString();
                            if (dr["Net_Adjustment"].ToString().ToUpper().Trim() == ("YES").ToUpper().Trim())
                            {
                                crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.Yes;
                            }
                            if (dr["Net_Adjustment"].ToString().ToUpper().Trim() == ("No").ToUpper().Trim())
                            {
                                crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.No;
                            }
                        }
                        else
                        {
                            string AAA = dr["Client_Code"].ToString();
                            if (dr["AccountType"].ToString().Trim().ToUpper() == ("Non Resident").ToUpper().Trim())
                            {
                                crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.No;
                            }
                            if (Convert.ToDouble(dr["Balance"].ToString()) > 0)
                            {
                                crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.Yes;
                            }
                            if (Convert.ToDouble(dr["Balance"].ToString()) < 0)
                            {
                                crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.No;
                            }

                        }
                        //crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.Yes;
                        crList.Add(crRegTemp);
                    }
                    #endregion


                    #region NewRegistered
                    foreach (DataRow dr in ChangeRegistered)
                    {

                        SBPXMLSchema.ClientRegistration crRegTemp = new ClientRegistration();
                        if (dr["Client_Code"].ToString().ToUpper().Trim() == ("KSL122").ToUpper().Trim())
                        {
                            if (dr["AccountType"].ToString().ToUpper().Trim() == ("Non Resident").ToUpper().Trim())
                                crRegTemp.AccountType = SBPXMLSchema.AccountType.R;// NRB
                            else if (dr["AccountType"].ToString().Trim().ToUpper() == ("Resident").ToUpper().Trim())
                                crRegTemp.AccountType = SBPXMLSchema.AccountType.D;// NORMAL
                        }
                        else
                        {
                            if (dr["AccountType"].ToString().ToUpper().Trim() == ("Non Resident").ToUpper().Trim())
                                crRegTemp.AccountType = SBPXMLSchema.AccountType.R;// NRB
                            else if (dr["AccountType"].ToString().Trim().ToUpper() == ("Resident").ToUpper().Trim())
                                crRegTemp.AccountType = SBPXMLSchema.AccountType.N;// NORMAL
                        }
                       
                        crRegTemp.Address = dr["Address"].ToString();
                        crRegTemp.BOID = dr["BOID"].ToString();
                        //crRegTemp.ICNo = dr["Branch_ID"].ToString();
                        //crRegTemp.BranchID = "1";//dr["Branch ID"].ToString();
                        crRegTemp.ClientCode = dr["Client_Code"].ToString();
                        crRegTemp.DealerID = dr["DealerID"].ToString();
                        //crRegTemp.ICNo = dr["Nationa_id"].ToString();
                        crRegTemp.Name = dr["Name"].ToString();
                        crRegTemp.ShortName = dr["Short_Name"].ToString().Split(' ').Last();
                        crRegTemp.ShortSellingAllowed = SBPXMLSchema.BooleanYesNo.No;
                        crRegTemp.Tel = dr["Telephone"].ToString();

                        if (dr["Net_Adjustment"].ToString().ToUpper().Trim() != "")
                        {
                            string AAA = dr["Client_Code"].ToString();
                            if (dr["Net_Adjustment"].ToString().ToUpper().Trim() == ("YES").ToUpper().Trim())
                            {
                                crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.Yes;
                            }
                            if (dr["Net_Adjustment"].ToString().ToUpper().Trim() == ("No").ToUpper().Trim())
                            {
                                crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.No;
                            }
                        }
                        else
                        {
                            string AAA = dr["Client_Code"].ToString();
                            if (dr["AccountType"].ToString().Trim().ToUpper() == ("Non Resident").ToUpper().Trim())
                            {
                                crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.No;
                            }
                            if (Convert.ToDouble(dr["Balance"].ToString()) > 0)
                            {
                                crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.Yes;
                            }
                            if (Convert.ToDouble(dr["Balance"].ToString()) < 0)
                            {
                                crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.No;
                            }

                        }
                        //crRegTemp.WithNetAdjustment = SBPXMLSchema.BooleanYesNo.Yes;
                        //SBPXMLSchema.ClientDeactivation tmpDeActive = new ClientDeactivation();
                        //tmpDeActive.ClientCode = dr["Client_Code"].ToString();
                        //crDeActive.Add(tmpDeActive);
                        //DeactiveRegistered.Add(dr);

                        crList.Add(crRegTemp);
                    }
                    #endregion

                    #region DeactiveRegistered
                    foreach (DataRow dr in DeactiveRegistered)
                    {
                        SBPXMLSchema.ClientDeactivation tmpDeActive = new ClientDeactivation();
                        tmpDeActive.ClientCode = dr["Client_Code"].ToString();
                        crDeActive.Add(tmpDeActive);
                    }
                    #endregion

                    #region SuspendRegistered
                    foreach (DataRow dr in SuspendRegistered)
                    {
                        SBPXMLSchema.ClientSuspension tmpSusActive = new ClientSuspension();
                        tmpSusActive.ClientCode = dr["Client_Code"].ToString();
                        tmpSusActive.Buy_Suspend = SuspendResume.Suspend;
                        tmpSusActive.Sell_Suspend = SuspendResume.Suspend;
                        crSuspension.Add(tmpSusActive);
                    }
                    #endregion

                    //objbal.Insert_Register_Cust_code(dt);

                    #region cashLimit

                    List<ClientLimits> cashLimit = new List<ClientLimits>();
                    DataTable dtcash = new DataTable();
                    dtcash = objbal.GetClientCashLimit();
                    if (dtcash.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtcash.Rows)
                        {
                            
                            SBPXMLSchema.ClientLimits limit = new ClientLimits();
                      
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
                           
                        }
                    }


                    #endregion


                    #region Write_CustInformation_Cash_Limit

                    try
                    {
                        Clients cs = new Clients();                        
                        cs.Deactivate = crDeActive.ToArray();
                        cs.Suspend = crSuspension.ToArray();
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
                    #endregion

                }
                else if (cmbgenerate.Text.ToUpper().Trim() == ("Position").Trim().ToUpper())
                {

                    #region Position

                    List<InsertOnePosition> InsertPos = new List<InsertOnePosition>();
                    DataTable dtposition = new DataTable();
                    DataTable dtDposition = new DataTable();
                    DataTable dtAllPosition = new DataTable();
                    xmlSchemaBAL objbal_position = new xmlSchemaBAL();
                    dtposition = objbal_position.GetPositions_Flex_TP();
                    dtDposition = objbal_position.GetDealerPositions_Flex_TP();
                    dtposition.Merge(dtDposition);
                    foreach (DataRow row in dtposition.Rows)
                    {
                        SBPXMLSchema.InsertOnePosition ps = new InsertOnePosition();
                        ps.ClientCode = row["Client Code"].ToString();
                        ps.SecurityCode = row["SecurityCode"].ToString();
                        ps.Quantity = Convert.ToInt32(row["Quantity"]);
                        ps.TotalCost = Convert.ToDouble(row["Total Cost"]);
                        InsertPos.Add(ps);
                    }
                    #endregion

                    #region Write_Position
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
                    #endregion
                }
                else if (cmbgenerate.Text.ToUpper().Trim() == ("Pay-Out Position").ToUpper().Trim())
                {

                    #region Position

                    List<InsertOnePosition> InsertPos = new List<InsertOnePosition>();
                    DataTable dtposition = new DataTable();
                    xmlSchemaBAL objbal_position = new xmlSchemaBAL();
                    dtposition = objbal_position.Get_Payout_Positions();
                    foreach (DataRow row in dtposition.Rows)
                    {
                        SBPXMLSchema.InsertOnePosition ps = new InsertOnePosition();
                        ps.ClientCode = row["Client Code"].ToString();
                        ps.SecurityCode = row["SecurityCode"].ToString();
                        ps.Quantity = Convert.ToInt32(row["Quantity"]);
                        ps.TotalCost = Convert.ToDouble(row["Total Cost"]);
                        InsertPos.Add(ps);
                    }
                    #endregion

                    #region Write_Position
                    try
                    {
                        Positions p = new Positions();
                        p.Items = InsertPos.ToArray();
                        p.ProcessingMode = SBPXMLSchema.ProcessingMode_Position.IncrementQuantity;
                        SBPXMLSchema.XMLExport xprt = new XMLExport(XMLExportType.Position, p, folderpath);
                        xprt.Export();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    #endregion
                }
                else if (cmbgenerate.Text.ToUpper().Trim() == ("Position & Pay-Out-Position").ToUpper().Trim())
                {

                    #region Position

                    List<InsertOnePosition> InsertPos = new List<InsertOnePosition>();
                    DataTable dtposition = new DataTable();
                    DataTable dtDposition = new DataTable();
                    xmlSchemaBAL objbal_position = new xmlSchemaBAL();
                    dtposition = objbal_position.GetPositions();
                    dtDposition = objbal_position.GetDealerPositions_Flex_TP();
                    dtposition.Merge(dtDposition);
                    foreach (DataRow row in dtposition.Rows)
                    {
                        SBPXMLSchema.InsertOnePosition ps = new InsertOnePosition();
                        ps.ClientCode = row["Client Code"].ToString();
                        ps.SecurityCode = row["SecurityCode"].ToString();
                        ps.Quantity = Convert.ToInt32(row["Quantity"]);
                        ps.TotalCost = Convert.ToDouble(row["Total Cost"]);
                        InsertPos.Add(ps);
                    }
                    #endregion

                    #region Write_Position
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
                    #endregion
                }
                else if (cmbgenerate.Text.ToUpper().Trim() == ("Bonus&Right Share Position").ToUpper().Trim())
                {

                    #region Position

                    List<InsertOnePosition> InsertPos = new List<InsertOnePosition>();
                    DataTable dtposition = new DataTable();
                    xmlSchemaBAL objbal_position = new xmlSchemaBAL();
                    string Date = dtpDate.Value.ToString("yyyy-MM-dd");
                    //dtposition = objbal_position.Get_Bonus_Right_Positions(Date);
                    dtposition = objbal_position.Get_IPO_Positions(Date);
                    foreach (DataRow row in dtposition.Rows)
                    {
                        SBPXMLSchema.InsertOnePosition ps = new InsertOnePosition();
                        ps.ClientCode = row["Client Code"].ToString();
                        ps.SecurityCode = row["SecurityCode"].ToString();
                        ps.Quantity = Convert.ToInt32(row["Quantity"]);
                        ps.TotalCost = Convert.ToDouble(row["Total Cost"]);
                        InsertPos.Add(ps);
                    }
                    #endregion

                    #region Write_Position
                    try
                    {
                        Positions p = new Positions();
                        p.Items = InsertPos.ToArray();
                        p.ProcessingMode = SBPXMLSchema.ProcessingMode_Position.IncrementQuantity;
                        SBPXMLSchema.XMLExport xprt = new XMLExport(XMLExportType.Position, p, folderpath);
                        xprt.Export();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    #endregion
                }



            }
            catch (Exception)
            {                
                throw;
            }
        }


        public bool Isvalidation()
        {
            if (cmbgenerate.Text == "")
            {
                MessageBox.Show("Please Select Cash/Position.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbgenerate.Focus();
                return true;
            }
            else return false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string ftpurl = @"ftp://10.250.128.103:8021/";
            string ftpusername = "ftp_KSL";
            string ftppassword = "MyODY5%";


            string filename = Path.GetFileName(folderpath);
            string ftpfullpath = ftpurl;
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
            ftp.Credentials = new NetworkCredential(ftpusername, ftppassword);

            ftp.KeepAlive = true;
            ftp.UseBinary = true;
            ftp.Method = WebRequestMethods.Ftp.UploadFile;

            FileStream fs = File.OpenRead(folderpath);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            fs.Close();

            Stream ftpstream = ftp.GetRequestStream();
            ftpstream.Write(buffer, 0, buffer.Length);
            ftpstream.Close();
        }
    }
}
