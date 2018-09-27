using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
   public class ParentAndChildBO
    {
       public ParentAndChildBO()
       {
       }

       #region Parent info
       private string _parent_code;
       private string _child_code;
       private string _child_boid;
       private string _parent_name;
       private string _handeler_name;
       private string _parent_gender;
       private string _parent_profession;
       private string _parent_email;
       private string _parent_cell;
       private string _parent_land;
       private string _parent_present_addr;
       private string _parent_permanent_add;

       public string Parent_Code
       {
           get{return _parent_code;}
           set{_parent_code=value;}
       }
       public string Child_Code
       {
           get{return _child_code;}
           set{_child_code=value;}
       }
       public string Chil_BoId
       {
           get{return _child_boid;}
           set{_child_boid=value;}
       }
       public string Parent_Name
       {
           get{return _parent_name;}
           set{_parent_name=value;}
       }
       public string Handeler_Name
       {
           get { return _handeler_name; }
           set { _handeler_name = value; }
       }
       public string Parent_Gender
       {
           get { return _parent_gender; }
           set { _parent_gender = value; }
       }
       public string Parent_Profession
       {
           get { return _parent_profession; }
           set { _parent_profession = value; }
       }
       public string parent_Email
       {
           get { return _parent_email; }
           set { _parent_email = value; }
       }
       public string Parent_Cell
       {
           get { return _parent_cell; }
           set { _parent_cell = value; }
       }
       public string parent_land
       {
           get { return _parent_land; }
           set { _parent_land = value; }
       }
       public string Parent_Present_addr
       {
           get { return _parent_present_addr; }
           set { _parent_present_addr = value; }
       }
       public string parent_Permanent_add
       {
           get { return _parent_permanent_add; }
           set { _parent_permanent_add = value; }
       }
       #endregion

       #region Child Code

       private string _owner_code;
       private string _owner_boid;
       private string _owner_permanent_add;
       private string _owner_parent_name;
       private string _owner_name;
       private string _owner_gender;
       private string _owner_profession;
       private string _owner_email;
       private string _owner_cell;
       private string _owner_land;
       private string _owner_present_addr;
       private string _owner_name_1;
       private string _owner_name_2;

       public string Owner_boid
       {
           get { return _owner_boid; }
           set { _owner_boid = value; }
       }

       public string Owner_code
       {
           get { return _owner_code; }
           set { _owner_code = value; }
       }

       

       public string Owner_parent_name
       {
           get { return _owner_parent_name; }
           set { _owner_parent_name = value; }
       }
       

       public string Owner_name
       {
           get { return _owner_name; }
           set { _owner_name = value; }
       }
       

       public string Owner_gender
       {
           get { return _owner_gender; }
           set { _owner_gender = value; }
       }
       

       public string Owner_profession
       {
           get { return _owner_profession; }
           set { _owner_profession = value; }
       }
       

       public string Owner_email
       {
           get { return _owner_email; }
           set { _owner_email = value; }
       }
       

       public string Owner_cell
       {
           get { return _owner_cell; }
           set { _owner_cell = value; }
       }
       

       public string Owner_land
       {
           get { return _owner_land; }
           set { _owner_land = value; }
       }

       public string Owner_Email_1
       {
           get { return _owner_name_1; }
           set { _owner_name_1 = value; }
       }

       public string Owner_Email_2
       {
           get { return _owner_name_2; }
           set { _owner_name_2 = value; }
       }

       public string Owner_present_addr
       {
           get { return _owner_present_addr; }
           set { _owner_present_addr = value; }
       }
       

       public string Owner_permanent_add
       {
           get { return _owner_permanent_add; }
           set { _owner_permanent_add = value; }
       }
        #endregion

       
    }
}
