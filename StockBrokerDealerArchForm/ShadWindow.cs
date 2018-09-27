using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Splash_DealerAccount;

namespace StockBrokerDealerArchForm
{
    public partial class ShadWindow : Form
    {
        public ShadWindow()
        {
            InitializeComponent();
        }

        private void ShadWindow_Load(object sender, EventArgs e)
        {
            SplashWindow sw = new SplashWindow();
            double op = 0.0;
            sw.Opacity = op;
            sw.Show();
            for (int i = 0; i < 20; ++i)
            {
                Thread.Sleep(50);
                op += 0.05;
                sw.Opacity = op;
                sw.Refresh();
            }
            sw.Opacity = 1;
            Thread.Sleep(1000);
            for (int i = 0; i < 20; ++i)
            {                   
                Thread.Sleep(50);
                op -= 0.05;
                sw.Opacity = op;       
                sw.Refresh();                          
            }
            sw.Opacity = 0;
            sw.Close();
        }
    }
}
