using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class MDIMargin : Form
    {

        public MDIMargin()
        {
            InitializeComponent();
        }
        private void marginRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarginChargePlan marginChargePlan = new MarginChargePlan { MdiParent = this };
            marginChargePlan.Show();
        }

        private void marginPlanEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MDIMargin_Load(object sender, EventArgs e)
        {
            ResetPrevillize();
            LoadPrevillize();
        }

        private void LoadPrevillize()
        {
            bool result = false;
            //DataTable previllizeDataTable = new DataTable();
            DataTable RoleWithUserprevillizeDataTable = new DataTable();
            DataTable RolewisePrevillizeDataTable = new DataTable();

            PrevillizeManagementBAL previllizeManagementBal = new PrevillizeManagementBAL();
            //previllizeDataTable = previllizeManagementBal.GetUserPrevillize();
            //for (int i = 0; i < previllizeDataTable.Rows.Count; i++)
            //{
            //    SetPrevillize(previllizeDataTable.Rows[i][0].ToString());
            //}
            RoleWithUserprevillizeDataTable = previllizeManagementBal.GetAssignedPrevillize();
            if (RoleWithUserprevillizeDataTable.Rows.Count > 0)
            {
                for (int i = 0; i < RoleWithUserprevillizeDataTable.Rows.Count; i++)
                {
                    if (RoleWithUserprevillizeDataTable.Rows[i][0].ToString().ToLower() == GlobalVariableBO._userName.ToLower())
                    {
                        result = true;
                        break;
                    }
                }
                if (result)
                {
                    for (int i = 0; i < RoleWithUserprevillizeDataTable.Rows.Count; i++)
                    {
                        if (RoleWithUserprevillizeDataTable.Rows[i][0].ToString().ToLower() == GlobalVariableBO._userName.ToLower())
                        {
                            SetPrevillize(RoleWithUserprevillizeDataTable.Rows[i]["Previllize"].ToString());
                        }
                    }
                }

               // DeactiveMenu();
            }
            else if (RoleWithUserprevillizeDataTable.Rows.Count == 0)
            {
                RolewisePrevillizeDataTable = previllizeManagementBal.GetRoleWisePrevillize();

                for (int i = 0; i < RolewisePrevillizeDataTable.Rows.Count; i++)
                {
                    SetPrevillize(RolewisePrevillizeDataTable.Rows[i]["Previllize"].ToString());
                }
               // DeactiveMenu();
            }

            if (GlobalVariableBO._employeeCode == String.Empty)
            {
                applyHolidayToolStripMenuItem.Enabled = false;
            }

            else
            {
                applyHolidayToolStripMenuItem.Enabled = true;
            }
           
        }

        private void SetPrevillize(string previllize)
        {
            switch (previllize)
            {
                case "Margin Registration":
                    //marginRegistrationToolStripMenuItem.Visible = true;
                    break;
                case "Margin Plan Entry":
                    //marginPlanEntryToolStripMenuItem.Visible = true;
                    break;
                default:
                    break;

            }
        }

        private void ResetPrevillize()
        {
            //marginRegistrationToolStripMenuItem.Visible = false;
            //marginPlanEntryToolStripMenuItem.Visible = false;
        }

        private void employeeInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmplyInfo objemployeeInfo=new frmEmplyInfo();
            objemployeeInfo.Show();
        }

        private void cloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void employeeHolidayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeApproved objEmployeeHoliday = new frmEmployeeApproved();
            objEmployeeHoliday.Show();
        }

        private void confirmSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPayrollSetting objPayrollSetting = new frmPayrollSetting();
            objPayrollSetting.Text = "Confirm Salary : Month Selection";
            objPayrollSetting.Show();
        }

        private void deoleteSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPayrollSetting objPayrollSetting = new frmPayrollSetting();
            objPayrollSetting.Text = "Delete Salary : Month Selection";
            objPayrollSetting.OperationValue = 1;
            objPayrollSetting.Show();
        }

        private void applyHolidayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeHolidayAllow objApplly = new frmEmployeeHolidayAllow();
            objApplly.Text = "Apply leave.";
            objApplly.EmployeeCode = GlobalVariableBO._employeeCode;
            objApplly.MdiParent = this;
            objApplly.Show();
        }
    }
}
