using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
   public class EmployeeBranchMapBO
    {
        public EmployeeBranchMapBO()
        {
        }

        #region Private Field
        private string _branch_map_employee_id;
        private string _branch_map_employee_branch_id;
        private string _branch_map_employee_workstation_id;
        private DateTime _branch_map_employee_from_date;
        private DateTime _branch_map_employee_to_date;
        #endregion

        #region public Field
        public string Branch_Map_Employee_ID
        {
            get { return this._branch_map_employee_id; }
            set { this._branch_map_employee_id = value; }
        }
        public string Branch_Map_Employee_Brach_ID
        {
            get { return this._branch_map_employee_branch_id; }
            set { this._branch_map_employee_branch_id = value; }
        }
        public string Branch_Map_Employee_WorkStation_ID
        {
            get { return this._branch_map_employee_workstation_id; }
            set { this._branch_map_employee_workstation_id = value; }
        }
        public DateTime Branch_Map_Employee_From_Date
        {
            get { return this._branch_map_employee_from_date; }
            set { this._branch_map_employee_from_date = value; }
        }
        public DateTime Branch_Map_Employee_To_Date
        {
            get { return this._branch_map_employee_to_date; }
            set { this._branch_map_employee_to_date = value; }
        }
        #endregion
    }
}
