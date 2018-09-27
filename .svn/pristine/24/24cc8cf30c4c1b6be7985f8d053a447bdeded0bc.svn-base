using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class WorkStationEntry : Form
    {
        private GlobalVariableBO.ModeSelection currentMode = GlobalVariableBO.ModeSelection.NewMode;
        private string _workStationForUpdate = "";
        public WorkStationEntry()
        {
            InitializeComponent();
        }

        private void WorkStationEntry_Load(object sender, EventArgs e)
        {
            LoadDDLBranch();
            LoadDataIntoGrid();
            ClearAll();
        }

        private void LoadDDLBranch()
        {
            LoadDDLBAL loadDdlbal = new LoadDDLBAL();
            DataTable dtData = loadDdlbal.LoadBranchesDDL();
            ddlBranchName.DataSource = dtData;
            ddlBranchName.DisplayMember = "Branch_Name";
            ddlBranchName.ValueMember = "Branch_ID";
            if (ddlBranchName.HasChildren)
                ddlBranchName.SelectedIndex = 0;
        }

        private void ClearAll()
        {
            txtWorkStationName.Text = "";
            ddlBranchName.SelectedIndex = 0;

        }

        private void LoadDataIntoGrid()
        {
            WorkStationBAL workStationBal = new WorkStationBAL();
            DataTable datatable = workStationBal.GetAllWorkStations();
            dtgWorkStation.DataSource = datatable;
            this.dtgWorkStation.Columns[1].Visible = false;
            dtgWorkStation.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            lblRecord.Text = "Total Workstation : " + dtgWorkStation.Rows.Count;

        }
        
        private void btnNew_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.NewMode;
            gbWorkStationEntry.Text = "Workstation Entry";
            btnNew.Enabled = false;
            btnNew.BackColor = Color.Gray;
            btnUpdate.Enabled = true;
            btnUpdate.ResetBackColor();
            ClearAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            gbWorkStationEntry.Text = "Update branch Information";
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Gray;
            btnNew.Enabled = true;
            btnNew.ResetBackColor();
            LoadDataForUpdate();

        }

    private void LoadDataForUpdate()
        {
            foreach (DataGridViewRow row in this.dtgWorkStation.SelectedRows)
            {
                _workStationForUpdate = dtgWorkStation[0, row.Index].Value.ToString();
                txtWorkStationName.Text = dtgWorkStation[0, row.Index].Value.ToString();
                ddlBranchName.SelectedValue = dtgWorkStation[1, row.Index].Value;
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveBranch_Click(object sender, EventArgs e)
        {
            SaveWorkStationInfo();
        }

        private void SaveWorkStationInfo()
        {
             try
            {
                WorkStationBO workStationBo = new WorkStationBO();
                workStationBo.WorkStation = txtWorkStationName.Text;
                workStationBo.BranchId =Convert.ToInt32(ddlBranchName.SelectedValue);
                WorkStationBAL workStationBal = new WorkStationBAL();
                switch (currentMode)
                {
                    case GlobalVariableBO.ModeSelection.NewMode:
                        try
                        {
                            if (IsValidateField())
                            {
                                workStationBal.Insert(workStationBo);
                                LoadDataIntoGrid();
                                MessageBox.Show(workStationBo.WorkStation + " Workstation has successfully saved.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("New  WorkstationCreation unsuccessful because of the error :" + ex.Message);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.UpdateMode:
                        try
                        {
                            workStationBal.Update(workStationBo, _workStationForUpdate);
                            LoadDataIntoGrid();
                            MessageBox.Show(workStationBo.WorkStation + " Workstation Information has successfully updated.");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Workstation information update unsuccessful because of the error :" + ex.Message);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.NoneMode:
                        MessageBox.Show("You have select none mode.Please select a mode.");
                        break;
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
            }
        }

        private bool IsValidateField()
        {
            if (IsDuplicateWorkStationName())
            {
                MessageBox.Show("Work Station Name Allready exist.Please try a different Work Station Name.");
                return false;
            }
           

            else
            {
                return true;
            }
        }

        private bool IsDuplicateWorkStationName()
        {
            WorkStationBAL workStationBal = new WorkStationBAL();
            if (workStationBal.CheckWorkStationDuplicate(txtWorkStationName.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void dtgWorkStation_SelectionChanged(object sender, EventArgs e)
        {
            if (currentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                LoadDataForUpdate();
            }
        }
       
    }
}
