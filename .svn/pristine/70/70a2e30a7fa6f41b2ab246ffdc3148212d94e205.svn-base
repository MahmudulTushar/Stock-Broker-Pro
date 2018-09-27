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
    public partial class HolidayAdd : Form
    {
        public HolidayAdd()
        {
            InitializeComponent();
        }
        private GlobalVariableBO.ModeSelection currentMode = GlobalVariableBO.ModeSelection.NewMode;
        private int _HolidayIdForUpdate = 0;
        private int _HolidayIdForDelete = 0;
        private void btnCancel_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void btnSaveHoliday_Click(object sender, EventArgs e)
        {
            SaveHolydayInfo();
        }

        private void SaveHolydayInfo()
        {
            try
            {
                HolidayBO holydayBo=new HolidayBO();
                holydayBo.HolydayDate = dtHolidayDate.Value;
                holydayBo.Purpose = txtPurpose.Text;
                HoliDayBAL holiDayBal=new HoliDayBAL();
                switch (currentMode)
                {
                    case GlobalVariableBO.ModeSelection.NewMode:
                        try
                        {
                            if (IsValidateField())
                            {
                                holiDayBal.SaveOthersHoliday(holydayBo);
                                MessageBox.Show("Holiday Information Saved Successfully", "Successfully Saved.");
                                LoadDataIntoGrid();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Holiday Information Saved unsuccessful because of the error :" + ex.Message);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.UpdateMode:
                        try
                        {
                            holiDayBal.Update(holydayBo, _HolidayIdForUpdate);
                            MessageBox.Show("Holiday Information has successfully updated.","Success.");
                            LoadDataIntoGrid();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Holiday Information update unsuccessful because of the error :" + ex.Message);
                        }
                        break;
                    case GlobalVariableBO.ModeSelection.NoneMode:
                        MessageBox.Show("You have select none mode.Please select a mode.");
                        break;
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show("Error Occured."+exp.Message);
            }
        }
        private bool IsValidateField()
        {
            if (IsDuplicateHoliday())
            {
                MessageBox.Show("Holiday Information Allready exist.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsDuplicateHoliday()
        {
            HoliDayBAL holiDayBal = new HoliDayBAL();
            if (holiDayBal.CheckHolidayDuplicate(Convert.ToDateTime(dtHolidayDate.Value.ToShortDateString())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       

        private void HolidayAdd_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
            ClearAll();
        }

        private void LoadDataIntoGrid()
        {
            HoliDayBAL holiDayBal= new HoliDayBAL();
            DataTable datatable = holiDayBal.GetAllHoliday();
            dtgHoliday.DataSource = datatable;
            dtgHoliday.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgHoliday.Columns[0].Width = 50;
            label5.Text = "Holiday : " + dtgHoliday.Rows.Count;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.NewMode;
            gbholiday.Text = "Holiday Entry";
            btnNew.Enabled = false;
            btnNew.BackColor = Color.Gray;
            btnUpdate.Enabled = true;
            btnUpdate.ResetBackColor();
            ClearAll();
        }

        private void ClearAll()
        {
            dtHolidayDate.Value = DateTime.Today;
            txtPurpose.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            currentMode = GlobalVariableBO.ModeSelection.UpdateMode;
            gbholiday.Text = "Edit Holiday";
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.Gray;
            btnNew.Enabled = true;
            btnNew.ResetBackColor();
            LoadDataForUpdate();
        
        }

        private void LoadDataForUpdate()
        {
            foreach (DataGridViewRow row in this.dtgHoliday.SelectedRows)
            {
                _HolidayIdForUpdate = Convert.ToInt32(dtgHoliday[0, row.Index].Value);
                if (dtgHoliday[1, row.Index].Value != DBNull.Value)
                    dtHolidayDate.Value = Convert.ToDateTime(dtgHoliday[1, row.Index].Value);
                txtPurpose.Text = dtgHoliday[2, row.Index].Value.ToString();
            }
        }

        private void dtgHoliday_SelectionChanged(object sender, EventArgs e)
        {

            if (currentMode == GlobalVariableBO.ModeSelection.UpdateMode)
            {
                LoadDataForUpdate();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            HoliDayBAL holiDayBal=new HoliDayBAL();
            if (_HolidayIdForDelete != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to delete?", "Delete confirmation", MessageBoxButtons.YesNo))
                {
                    holiDayBal.DeleteHoliday(_HolidayIdForDelete);
                    MessageBox.Show("Delete Successfull", "Delete confirmation");
                    LoadDataIntoGrid();
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete", "Delete item check");
            }
        }

        private void dtgHoliday_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DataGridViewRow dr = dtgHoliday.CurrentRow;
                _HolidayIdForDelete = Convert.ToInt32(dr.Cells[0].Value.ToString());

            }
            catch (Exception)
            {
                _HolidayIdForDelete = 0;
            }

        }
    }
}
