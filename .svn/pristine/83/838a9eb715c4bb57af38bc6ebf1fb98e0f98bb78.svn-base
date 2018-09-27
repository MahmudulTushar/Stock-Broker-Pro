using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockbrokerProNewArch
{
    public partial class frmCustomizedMessageBox : Form
    {
        private string MessageText = string.Empty;
        private string HeaderText = string.Empty;
        private Point point = new Point();
        public frmCustomizedMessageBox(string messagetext,string headerText,Point pnt)
        {
            InitializeComponent();
            MessageText = messagetext;
            HeaderText = headerText;
            point = pnt;
        }

        private void frmCustomizedMessageBox_Load(object sender, EventArgs e)
        {
            messageText.Text = MessageText;
            this.Text = HeaderText;
            this.Location = point;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
