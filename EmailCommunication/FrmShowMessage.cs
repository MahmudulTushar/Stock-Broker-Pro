using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using ElectronicCommunication.SMS;

namespace ElectronicCommunication
{
    public partial class FrmShowMessage : Form
    {
       
        DbConnection objConnectionString = new DbConnection();
        string message = string.Empty;
        public FrmShowMessage(string text)
        {
            InitializeComponent();
            message = text;
        }

        private void FrmShowMessage_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox1.Text = message;              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }      

       
    }
}
