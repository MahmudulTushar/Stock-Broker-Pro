using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class LockWindow : Form
    {
        public LockWindow()
        {
            InitializeComponent();
        }

        private void LockWindow_Load(object sender, EventArgs e)
        {
            LockWindow2 lockWindow2=new LockWindow2();
            lockWindow2.ShowDialog();
            this.Close();
        }
    }
}
