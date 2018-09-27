using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class frm_IPO_AutoSubscription : Form
    {
        IPOProcessBAL bal = new IPOProcessBAL();
        string cust_code = "";
        /// <summary>
        /// Add or update subscrption status for auto application
        /// </summary>
        /// <param name="code">Passing the code who is going to be subscription or Update his/her subscription</param>
        public frm_IPO_AutoSubscription(string code)
        {
            InitializeComponent();
            cust_code = code;
            //cust_code = "4509";
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            bal.GetIPOAccountBalanceFor_AutoApplication<string>("0", "Registration", cust_code);
        }
        

    }
}
