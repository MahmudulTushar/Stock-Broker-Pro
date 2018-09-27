using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using System.Globalization;
using System.Deployment.Application;
using System.Configuration;
using CrystalDecisions.Enterprise;
using System.IO;
using StockbrokerProNewArch.Classes;

namespace StockbrokerProNewArch
{
    static class Program
    {
        static double _softwareVersion = 1.5;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //try
            //{
               // ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);

               

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ShadWindow shadWindow = new ShadWindow();
                shadWindow.Show();

                try
                {
                    double currentVersion;
                    string dateSeparator = string.Empty;
                    DatabaseConnectionCheck _databaseConnectionCheck = new DatabaseConnectionCheck();
                    //currentVersion = _databaseConnectionCheck.CheckDatabaseConnections();
                    CultureInfo myCI = CultureInfo.CurrentCulture;
                    myCI.ClearCachedData();
                    DateTimeFormatInfo currentDateFormat = myCI.DateTimeFormat;
                    dateSeparator = currentDateFormat.DateSeparator;
                    //if (!(currentDateFormat.ShortDatePattern == "dd" + dateSeparator + "MMM" + dateSeparator + "yyyy"))
                    //{
                    //    MessageBox.Show("Erro: Date Format Missmatch. Please Change Windows Short Date Format As dd" + dateSeparator + "MMM" + dateSeparator + "yyyy ");
                    //    shadWindow.Close();
                    //    return;
                    //}

                    if (_softwareVersion !=1.5)//(_softwareVersion != currentVersion)
                    {
                        MessageBox.Show("You are using an earlier version of Stock Broker Pro. Please Istall New Version: SBP-" + _softwareVersion.ToString(), "Update Message",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //SecureString password = new SecureString();
                        //password.AppendChar('1');
                        //password.AppendChar('2');
                        //password.AppendChar('2');
                        //Process.Start(@"\\150.1.122.2\SBP_Download\Setup.msi","administrator",password,"KSCL001");

                        shadWindow.Close();
                        return;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Database Connection Failed. Error : " + exception.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    shadWindow.Close();
                    return;
                }

                LogInForm logInForm = new LogInForm();
                DialogResult dialogResult = logInForm.ShowDialog();
                shadWindow.Close();

                if (dialogResult == DialogResult.OK)
                {
                    Application.Run(new ParentForm());
                }
            //}
            //catch (ConfigurationErrorsException ex)
            //{
            //    string filename = ex.Filename;
            //    Logger.ErrorLog(ex.Message, "Cannot open config file");

            //    if (System.IO.File.Exists(filename) == true)
            //    {
            //        Logger.ErrorLog(filename, System.IO.File.ReadAllText(filename));
            //        System.IO.File.Delete(filename);
            //        Logger.ErrorLog("Config file deleted");
            //        Properties.Settings.Default.Upgrade();
            //        // Properties.Settings.Default.Reload();
            //        // you could optionally restart the app instead
            //    }
            //    else
            //    {
            //        Logger.ErrorLog("Config file {0} does not exist", filename);
            //    }
            //}

        }
    }
}
