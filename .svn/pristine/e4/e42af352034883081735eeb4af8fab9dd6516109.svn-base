using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace StockbrokerProNewArch
{
    public partial class frmUserQueryDetailsViewer : Form
    {
        public string QueryText = string.Empty;
        public frmUserQueryDetailsViewer()
        {
            InitializeComponent();
        }

        private void frmUserQueryDetailsViewer_Load(object sender, EventArgs e)
        {
            textBox1.Text = Regex.Replace(QueryText, @"\t|\n|\r", "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
