namespace StockBrokerProWs
{
    partial class StockBrokerProWs
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.EventLog_SBP_Ws = new System.Diagnostics.EventLog();
            this.SBP_WsTimer_SMSReceiver = new System.Windows.Forms.Timer(this.components);
            this.SBP_WsTimer_SMSSender = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EventLog_SBP_Ws)).BeginInit();
            // 
            // EventLog_SBP_Ws
            // 
            this.EventLog_SBP_Ws.Log = "SBPWsEventLog";
            this.EventLog_SBP_Ws.Source = "SBPWsSource";
            // 
            // SBP_WsTimer_SMSReceiver
            // 
            this.SBP_WsTimer_SMSReceiver.Enabled = true;
            this.SBP_WsTimer_SMSReceiver.Interval = 5000;
            this.SBP_WsTimer_SMSReceiver.Tick += new System.EventHandler(this.SBP_WsTimer_SMSReceiver_Tick);
            // 
            // SBP_WsTimer_SMSSender
            // 
            this.SBP_WsTimer_SMSSender.Interval = 2000;
            this.SBP_WsTimer_SMSSender.Tick += new System.EventHandler(this.SBP_WsTimer_SMSSender_Tick);
            // 
            // StockBrokerProWs
            // 
            this.ServiceName = "StockBrokerProWs";
            ((System.ComponentModel.ISupportInitialize)(this.EventLog_SBP_Ws)).EndInit();

        }

        #endregion

        private System.Diagnostics.EventLog EventLog_SBP_Ws;
        private System.Windows.Forms.Timer SBP_WsTimer_SMSReceiver;
        private System.Windows.Forms.Timer SBP_WsTimer_SMSSender;
    }
}
