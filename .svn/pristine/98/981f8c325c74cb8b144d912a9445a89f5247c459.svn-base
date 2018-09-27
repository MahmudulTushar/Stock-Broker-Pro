using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using CrystalDecisions.CrystalReports.Engine;

namespace StockbrokerProNewArch
{
    public partial class frmPayrollSetting : Form
    {
        public frmPayrollSetting()
        {
            InitializeComponent();
        }

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        private int _operationValue;

        public int OperationValue
        {
            get { return _operationValue; }
            set { _operationValue = value; }
        }       

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if(_operationValue==1)
            {
                frmPayroll objPayroll=new frmPayroll();
                objPayroll.SeletctedMonth = dtpMonth.Value;
                Close();
                objPayroll.Show();
            }

          
            else
            {
                frmViewAllEmployee objPayrollOpeation = new frmViewAllEmployee();
                objPayrollOpeation.SeletedMonth = dtpMonth.Value;
                Close();
                objPayrollOpeation.Show();   
            }
           
        }

        private void GetCommonInfo()
        {

            try
            {
                CommonInfoBal objCommonInfoBal = new CommonInfoBal();
                DataRow drCommonInfo = null;

                drCommonInfo = objCommonInfoBal.GetCommpanyInfo();

                if (drCommonInfo != null)
                {
                    _CommpanyName = drCommonInfo.Table.Rows[0][0].ToString();
                    _branchName = drCommonInfo.Table.Rows[0][1].ToString();
                    _branchAddress = drCommonInfo.Table.Rows[0][2].ToString();
                    _branchContactNumber = drCommonInfo.Table.Rows[0][3].ToString();


                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmPayrollSetting_Load(object sender, EventArgs e)
        {

        }

    }
}
