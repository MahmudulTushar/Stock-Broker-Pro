using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.Constants;
using System.Threading;

namespace StockbrokerProNewArch
{
    public partial class frm_IPOSMSNofications : Form
    {
        private WaitWindow waitWindow;
        public static bool isProgressed;

        public frm_IPOSMSNofications()
        {
            InitializeComponent();
        }

        private void frm_IPO_SMSNofications_Load(object sender, EventArgs e)
        {
            IPOProcessBAL ipoBal = new IPOProcessBAL();
            DataTable dt = ipoBal.GetIPOSessionALL();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Company_Name";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedIndex = -1;
            
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGrid();
               
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadGrid()
        {
            DataTable dt = new DataTable();
            string GridCategory = comboBox2.Text;
            int SessionID = Convert.ToInt32(comboBox1.SelectedValue);

            SMSSyncBAL bal = new SMSSyncBAL();
            try
            {

                if (GridCategory == "Single Successful/Unsuccessfull")
                {
                    string AlreadyExportedIDs = bal.GetAlreadyExportedNotifications_ForSingle(SessionID);
                    dt = bal.GetIPOSMSNotification_Single_SuccUnsucc(SessionID, AlreadyExportedIDs);
                }
                else if (GridCategory == "Single Approved/Reject")
                {
                    string AlreadyExportedIDs = bal.GetAlreadyExportedNotifications_ForSingle(SessionID);
                    dt = bal.GetIPOSMSNotification_Single_ApproveReject(SessionID, AlreadyExportedIDs);
                }
                else if (GridCategory == "Parent Child Successfull/Unsuccessfull")
                {
                    string AlreadyExportedIDs = bal.GetAlreadyExportedNotifications_ForParentChild(SessionID);
                    dt = bal.GetIPOSMSNotification_ParentChild_SuccUnsucc(SessionID, AlreadyExportedIDs);
                }
                else if (GridCategory == "Parent Child Approved/Reject")
                {
                    string AlreadyExportedIDs = bal.GetAlreadyExportedNotifications_ForParentChild(SessionID);
                    dt = bal.GetIPOSMSNotification_ParentChild_ApproveReject(SessionID, AlreadyExportedIDs);
                }
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region
        //private void btnExportNotification_Click(object sender, EventArgs e)
        //{
        //    DataTable dt = new DataTable();
        //    string GridCategory = comboBox2.Text;
        //    int SessionID = Convert.ToInt32(comboBox1.SelectedValue);

        //    SMSSyncBAL bal = new SMSSyncBAL();
            
        //    Thread thrd = new Thread(WaitWindow_Thread);
        //    isProgressed = true;
        //    thrd.Start();
            
        //    try
        //    {
        //        bal.Connect_SBP();
        //        bal.Connect_SMS();
               
        //        if (GridCategory == "Single Successful/Unsuccessfull")
        //        {

        //            //string AlreadyExportedIDs = bal.GetAlreadyExportedNotifications_ForSingle_UITransApplied(SessionID);
        //            //dt = bal.GetIPOSMSNotification_Single_SuccUnsucc_UITransApplied(SessionID, AlreadyExportedIDs);

        //            //List<DataRow> uncsucc_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["ApplicationStatus"]).Trim() == Indication_IPOPaymentTransaction.IPOApplicationStatus_UnSuccessfull).ToList();
        //            //List<DataRow> succ_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["ApplicationStatus"]).Trim() == Indication_IPOPaymentTransaction.IPOApplicationStatus_Successfull).ToList();

        //            //string SMSFormat_uncsucc_All = bal.GetSMSFormat_UITransApply("SMS16");
        //            //List<DataRow> uncsucc_All_WithMessage = bal.GetSMSText_Single_Unsucc_UITransApplied(uncsucc_All, SMSFormat_uncsucc_All);
        //            //bal.InsertTable_SMSSyncExport_ForSingle_IPO_Confirmation_SMS_UITransApplied(uncsucc_All_WithMessage.ToList());

        //            //string SMSFormat_succ_All = bal.GetSMSFormat_UITransApply("SMS11");
        //            //List<DataRow> succ_All_WithMessage = bal.GetSMSText_Single_Successfull_UITransApplied(succ_All, SMSFormat_succ_All);
        //            //bal.InsertTable_SMSSyncExport_ForSingle_IPO_Confirmation_SMS_UITransApplied(succ_All_WithMessage.ToList());

        //            string AlreadyExportedIDs = bal.GetAlreadyExportedNotifications_ForSingle_UITransApplied(SessionID);
        //            //dt = bal.GetIPOSMSNotification_Single_SuccUnsucc_UITransApplied(SessionID, AlreadyExportedIDs);
        //            dt = bal.GetIPOSMSNotification_Single_SuccUnsucc(SessionID, AlreadyExportedIDs);

        //            List<DataRow> uncsucc_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["ApplicationStatus"]).Trim() == Indication_IPOPaymentTransaction.IPOApplicationStatus_UnSuccessfull).ToList();
        //            List<DataRow> succ_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["ApplicationStatus"]).Trim() == Indication_IPOPaymentTransaction.IPOApplicationStatus_Successfull).ToList();

        //            string SMSFormat_uncsucc_All = bal.GetSMSFormat_UITransApply("SMS14");
        //            List<DataRow> uncsucc_All_WithMessage = bal.GetSMSText_Single_Unsucc_UITransApplied(uncsucc_All, SMSFormat_uncsucc_All);
        //            bal.InsertTable_SMSSyncExport_ForSingle_IPO_Confirmation_SMS_UITransApplied(uncsucc_All_WithMessage.ToList());

        //            string SMSFormat_succ_All = bal.GetSMSFormat_UITransApply("SMS11");
        //            List<DataRow> succ_All_WithMessage = bal.GetSMSText_Single_Successfull_UITransApplied(succ_All, SMSFormat_succ_All);
        //            bal.InsertTable_SMSSyncExport_ForSingle_IPO_Confirmation_SMS_UITransApplied(succ_All_WithMessage.ToList());

        //            // bal.InsertTable_SMSSyncExport_ForSingle_IPO_Confirmation_SMS_UITransApplied(succ_All_WithMessage.ToList());
        //        }
        //        else if (GridCategory == "Single Approved/Reject")
        //        {
        //            string AlreadyExportedIDs = bal.GetAlreadyExportedNotifications_ForSingle_UITransApplied(SessionID);
        //            dt = bal.GetIPOSMSNotification_Single_ApproveReject_UITransApplied(SessionID, AlreadyExportedIDs);

        //            List<DataRow> approved_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["ApplicationStatus"]).Trim() == Indication_IPOPaymentTransaction.IPOApplicationStatus_Approved).ToList();
        //            List<DataRow> rejected_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["ApplicationStatus"]).Trim() == Indication_IPOPaymentTransaction.IPOApplicationStatus_Rejected).ToList();

        //            string SMSFormat_rejected_All = bal.GetSMSFormat_UITransApply("SMS16");
        //            List<DataRow> rejected_All_WithMessage = bal.GetSMSText_Single_Unsucc_UITransApplied(rejected_All, SMSFormat_rejected_All);
        //            bal.InsertTable_SMSSyncExport_ForSingle_IPO_Confirmation_SMS_UITransApplied(rejected_All_WithMessage.ToList());

        //            string SMSFormat_approved_All = bal.GetSMSFormat_UITransApply("SMS11");
        //            List<DataRow> approved_All_WithMessage = bal.GetSMSText_Single_Successfull_UITransApplied(approved_All, SMSFormat_approved_All);
        //            bal.InsertTable_SMSSyncExport_ForSingle_IPO_Confirmation_SMS_UITransApplied(approved_All_WithMessage.ToList());
        //        }
        //        else if (GridCategory == "Parent Child Successfull/Unsuccessfull")
        //        {
        //            string AlreadyExportedIDs = bal.GetAlreadyExportedNotifications_ForParentChild_UITransApplied(SessionID);
        //            dt = bal.GetIPOSMSNotification_ParentChild_SuccUnsucc_UITransApplied(SessionID, AlreadyExportedIDs);
        //            //dt = bal.GetIPOSMSNotification_ParentChild_SuccUnsucc(SessionID, AlreadyExportedIDs);

        //            // List<DataRow> succ_uncsucc_Together = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Succ_Clients"]).Trim() != string.Empty && Convert.ToString(t["Unsucc_Clients"]).Trim() != string.Empty).ToList();
        //            List<DataRow> succ_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Succ_Clients"]).Trim() != string.Empty && Convert.ToString(t["Unsucc_Clients"]).Trim() != string.Empty).ToList();
        //            List<DataRow> uncsucc_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Succ_Clients"]).Trim() == string.Empty && Convert.ToString(t["Unsucc_Clients"]).Trim() != string.Empty).ToList();

        //            string SMSFormat_succ_All = bal.GetSMSFormat_UITransApply("SMS40");
        //            List<DataRow> succ_All_WithMessage = bal.GetSMSText_ParentChild_Succ_Unsucc_Together_UITransApplied(succ_All, SMSFormat_succ_All);
        //            bal.InsertTable_SMSSyncExport_FroParentChild_IPO_Confirmation_SMS_UITransApplied(succ_All_WithMessage.ToList());

        //            string SMSFormat_uncsucc_All = bal.GetSMSFormat_UITransApply("SMS14");
        //            List<DataRow> uncsucc_All_WithMessage = bal.GetSMSText_ParentChild_AllUnsuc_UITransApplied(uncsucc_All, SMSFormat_uncsucc_All);
        //            bal.InsertTable_SMSSyncExport_FroParentChild_IPO_Confirmation_SMS_UITransApplied(uncsucc_All_WithMessage.ToList());


        //            //string AlreadyExportedIDs = bal.GetAlreadyExportedNotifications_ForParentChild_UITransApplied(SessionID);
        //            //dt = bal.GetIPOSMSNotification_ParentChild_SuccUnsucc_UITransApplied(SessionID, AlreadyExportedIDs);

        //            //List<DataRow> succ_uncsucc_Together = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Succ_Clients"]).Trim() != string.Empty && Convert.ToString(t["Unsucc_Clients"]).Trim() != string.Empty).ToList();
        //            //List<DataRow> uncsucc_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Succ_Clients"]).Trim()== string.Empty && Convert.ToString(t["Unsucc_Clients"]).Trim() != string.Empty).ToList();
        //            //List<DataRow> succ_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Succ_Clients"]).Trim()!= string.Empty && Convert.ToString(t["Unsucc_Clients"]).Trim() == string.Empty).ToList();

        //            //string SMSFormat_succ_uncsucc_Together = bal.GetSMSFormat_UITransApply("SMS12");
        //            //List<DataRow> succ_uncsucc_Together_WithMessage = bal.GetSMSText_ParentChild_Succ_Unsucc_Together_UITransApplied(succ_uncsucc_Together, SMSFormat_succ_uncsucc_Together);
        //            //bal.InsertTable_SMSSyncExport_FroParentChild_IPO_Confirmation_SMS_UITransApplied(succ_uncsucc_Together_WithMessage.ToList());

        //            //string SMSFormat_uncsucc_All = bal.GetSMSFormat_UITransApply("SMS14");
        //            //List<DataRow> uncsucc_All_WithMessage = bal.GetSMSText_ParentChild_AllUnsuc_UITransApplied(uncsucc_All, SMSFormat_uncsucc_All);
        //            //bal.InsertTable_SMSSyncExport_FroParentChild_IPO_Confirmation_SMS_UITransApplied(uncsucc_All_WithMessage.ToList());

        //            //string SMSFormat_succ_All = bal.GetSMSFormat_UITransApply("SMS15");
        //            //List<DataRow> succ_All_WithMessage = bal.GetSMSText_ParentChild_AllSucc_UITransApplied(succ_All, SMSFormat_succ_All);
        //            //bal.InsertTable_SMSSyncExport_FroParentChild_IPO_Confirmation_SMS_UITransApplied(succ_All_WithMessage.ToList());
        //        }
        //        else if (GridCategory == "Parent Child Approved/Reject")
        //        {
        //            string AlreadyExportedIDs = bal.GetAlreadyExportedNotifications_ForParentChild_UITransApplied(SessionID);
        //            dt = bal.GetIPOSMSNotification_ParentChild_ApproveReject_UITransApplied(SessionID, AlreadyExportedIDs);

        //            List<DataRow> app_rej_Together = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Succ_Clients"]).Trim() != string.Empty && Convert.ToString(t["Unsucc_Clients"]).Trim() != string.Empty).ToList();
        //            List<DataRow> rej_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Succ_Clients"]).Trim() == string.Empty && Convert.ToString(t["Unsucc_Clients"]).Trim() != string.Empty).ToList();
        //            List<DataRow> app_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Succ_Clients"]).Trim() != string.Empty && Convert.ToString(t["Unsucc_Clients"]).Trim() == string.Empty).ToList();

        //            string SMSFormat_app_rej_Together = bal.GetSMSFormat_UITransApply("SMS17");
        //            List<DataRow> app_rej_Together_WithMessage = bal.GetSMSText_ParentChild_Succ_Unsucc_Together_UITransApplied(app_rej_Together, SMSFormat_app_rej_Together);
        //            bal.InsertTable_SMSSyncExport_FroParentChild_IPO_Confirmation_SMS_UITransApplied(app_rej_Together_WithMessage.ToList());

        //            string SMSFormat_rej_All = bal.GetSMSFormat_UITransApply("SMS16");
        //            List<DataRow> rej_All_WithMessage = bal.GetSMSText_ParentChild_AllUnsuc_UITransApplied(rej_All, SMSFormat_rej_All);
        //            bal.InsertTable_SMSSyncExport_FroParentChild_IPO_Confirmation_SMS_UITransApplied(rej_All_WithMessage.ToList());

        //            string SMSFormat_app_All = bal.GetSMSFormat_UITransApply("SMS11");
        //            List<DataRow> app_All_WithMessage = bal.GetSMSText_ParentChild_AllSucc_UITransApplied(app_All, SMSFormat_app_All);
        //            bal.InsertTable_SMSSyncExport_FroParentChild_IPO_Confirmation_SMS_UITransApplied(app_All_WithMessage.ToList());
        //        }
        //        bal.Commit_SBP();
        //        bal.Commit_SMS();
        //        isProgressed = false;
        //        MessageBox.Show("Datat Exported Successfull!!");
        //        LoadGrid();
        //    }
        //    catch (Exception ex)
        //    {
        //        bal.Rollback_SBP();
        //        bal.Rollback_SMS();
        //    }
        //    finally
        //    {
        //        bal.CloseConnection_SBP();
        //        bal.CloseConnection_SMS();
        //    }
        //}
        #endregion
        private void btnExportNotification_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string GridCategory = comboBox2.Text;
            int SessionID = Convert.ToInt32(comboBox1.SelectedValue);

            SMSSyncBAL bal = new SMSSyncBAL();

            Thread thrd = new Thread(WaitWindow_Thread);
            isProgressed = true;
            thrd.Start();

            try
            {
                bal.Connect_SBP();
                bal.Connect_SMS();

                if (GridCategory == "Single Successful/Unsuccessfull")
                {

                    string AlreadyExportedIDs = bal.GetAlreadyExportedNotifications_ForParentChild_UITransApplied(SessionID);
                    dt = bal.GetIPOSMSNotification_Single_SuccUnsucc(SessionID, AlreadyExportedIDs);

                    List<DataRow> uncsucc_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["ApplicationStatus"]).Trim() == Indication_IPOPaymentTransaction.IPOApplicationStatus_UnSuccessfull).ToList();
                    List<DataRow> succ_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["ApplicationStatus"]).Trim() == Indication_IPOPaymentTransaction.IPOApplicationStatus_Successfull).ToList();

                    string SMSFormat_uncsucc_All = bal.GetSMSFormat_UITransApply("SMS14");
                    List<DataRow> uncsucc_All_WithMessage = bal.GetSMSText_Single_Unsucc_UITransApplied(uncsucc_All, SMSFormat_uncsucc_All);
                    bal.InsertTable_SMSSyncExport_ForSingle_IPO_Confirmation_SMS_UITransApplied(uncsucc_All_WithMessage.ToList());

                    string SMSFormat_succ_All = bal.GetSMSFormat_UITransApply("SMS11");
                    List<DataRow> succ_All_WithMessage = bal.GetSMSText_Single_Successfull_UITransApplied(succ_All, SMSFormat_succ_All);
                    bal.InsertTable_SMSSyncExport_ForSingle_IPO_Confirmation_SMS_UITransApplied(succ_All_WithMessage.ToList());


                }
                else if (GridCategory == "Single Approved/Reject")
                {
                    string AlreadyExportedIDs = bal.GetAlreadyExportedNotifications_ForParentChild_UITransApplied(SessionID);
                    dt = bal.GetIPOSMSNotification_Single_ApproveReject_UITransApplied(SessionID, AlreadyExportedIDs);

                    List<DataRow> approved_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["ApplicationStatus"]).Trim() == Indication_IPOPaymentTransaction.IPOApplicationStatus_Approved).ToList();
                    List<DataRow> rejected_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["ApplicationStatus"]).Trim() == Indication_IPOPaymentTransaction.IPOApplicationStatus_Rejected).ToList();

                    string SMSFormat_rejected_All = bal.GetSMSFormat_UITransApply("SMS16");
                    List<DataRow> rejected_All_WithMessage = bal.GetSMSText_Single_Unsucc_UITransApplied(rejected_All, SMSFormat_rejected_All);
                    bal.InsertTable_SMSSyncExport_ForSingle_IPO_Confirmation_SMS_UITransApplied(rejected_All_WithMessage.ToList());

                    string SMSFormat_approved_All = bal.GetSMSFormat_UITransApply("SMS11");
                    List<DataRow> approved_All_WithMessage = bal.GetSMSText_Single_Successfull_UITransApplied(approved_All, SMSFormat_approved_All);
                    bal.InsertTable_SMSSyncExport_ForSingle_IPO_Confirmation_SMS_UITransApplied(approved_All_WithMessage.ToList());
                }
                else if (GridCategory == "Parent Child Successfull/Unsuccessfull")
                {
                    string AlreadyExportedIDs = bal.GetAlreadyExportedNotifications_ForParentChild_UITransApplied(SessionID);
                    dt = bal.GetIPOSMSNotification_ParentChild_SuccUnsucc_UITransApplied(SessionID, AlreadyExportedIDs);


                    List<DataRow> succ_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Succ_Clients"]).Trim() != string.Empty && Convert.ToString(t["Unsucc_Clients"]).Trim() != string.Empty).ToList();
                    List<DataRow> uncsucc_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Succ_Clients"]).Trim() == string.Empty && Convert.ToString(t["Unsucc_Clients"]).Trim() != string.Empty).ToList();

                    string SMSFormat_succ_All = bal.GetSMSFormat_UITransApply("SMS40");
                    List<DataRow> succ_All_WithMessage = bal.GetSMSText_ParentChild_Succ_Unsucc_Together_UITransApplied(succ_All, SMSFormat_succ_All);
                    bal.InsertTable_SMSSyncExport_FroParentChild_IPO_Confirmation_SMS_UITransApplied(succ_All_WithMessage.ToList());

                    string SMSFormat_uncsucc_All = bal.GetSMSFormat_UITransApply("SMS14");
                    List<DataRow> uncsucc_All_WithMessage = bal.GetSMSText_ParentChild_AllUnsuc_UITransApplied(uncsucc_All, SMSFormat_uncsucc_All);
                    bal.InsertTable_SMSSyncExport_FroParentChild_IPO_Confirmation_SMS_UITransApplied(uncsucc_All_WithMessage.ToList());

                }
                else if (GridCategory == "Parent Child Approved/Reject")
                {
                    string AlreadyExportedIDs = bal.GetAlreadyExportedNotifications_ForParentChild_UITransApplied(SessionID);
                    dt = bal.GetIPOSMSNotification_ParentChild_ApproveReject_UITransApplied(SessionID, AlreadyExportedIDs);

                    List<DataRow> app_rej_Together = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Succ_Clients"]).Trim() != string.Empty && Convert.ToString(t["Unsucc_Clients"]).Trim() != string.Empty).ToList();
                    List<DataRow> rej_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Succ_Clients"]).Trim() == string.Empty && Convert.ToString(t["Unsucc_Clients"]).Trim() != string.Empty).ToList();
                    List<DataRow> app_All = dt.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Succ_Clients"]).Trim() != string.Empty && Convert.ToString(t["Unsucc_Clients"]).Trim() == string.Empty).ToList();

                    string SMSFormat_app_rej_Together = bal.GetSMSFormat_UITransApply("SMS17");
                    List<DataRow> app_rej_Together_WithMessage = bal.GetSMSText_ParentChild_Succ_Unsucc_Together_UITransApplied(app_rej_Together, SMSFormat_app_rej_Together);
                    bal.InsertTable_SMSSyncExport_FroParentChild_IPO_Confirmation_SMS_UITransApplied(app_rej_Together_WithMessage.ToList());

                    string SMSFormat_rej_All = bal.GetSMSFormat_UITransApply("SMS16");
                    List<DataRow> rej_All_WithMessage = bal.GetSMSText_ParentChild_AllUnsuc_UITransApplied(rej_All, SMSFormat_rej_All);
                    bal.InsertTable_SMSSyncExport_FroParentChild_IPO_Confirmation_SMS_UITransApplied(rej_All_WithMessage.ToList());

                    string SMSFormat_app_All = bal.GetSMSFormat_UITransApply("SMS11");
                    List<DataRow> app_All_WithMessage = bal.GetSMSText_ParentChild_AllSucc_UITransApplied(app_All, SMSFormat_app_All);
                    bal.InsertTable_SMSSyncExport_FroParentChild_IPO_Confirmation_SMS_UITransApplied(app_All_WithMessage.ToList());
                }
                bal.Commit_SBP();
                bal.Commit_SMS();
                isProgressed = false;
                MessageBox.Show("Datat Exported Successfull!!");
                LoadGrid();
            }
            catch (Exception ex)
            {
                bal.Rollback_SBP();
                bal.Rollback_SMS();
            }
            finally
            {
                bal.CloseConnection_SBP();
                bal.CloseConnection_SMS();
            }
        }

        private void WaitWindow_Thread()
        {
            WaitWindow waitWindow = new WaitWindow();
            waitWindow.Show();
            while (isProgressed)
            {
                waitWindow.Refresh();
            }
            waitWindow.Close();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            lb_RowCount.Text ="Count- "+Convert.ToString(dataGridView1.RowCount);
        }


    }
}
