using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
   public class EmployeeDocumentBo
   {
        #region constructor
           public EmployeeDocumentBo()
           {
           }
        #endregion

       #region Private Field
           private string _employee_document_id;
           private string _employee_document_name;
           private string _employee_document_type;
           private byte[] _National_Id_imag;
           private byte[] _CV_PDF;

       #endregion
       #region

           public byte[] National_Id_imag
           {
               get { return _National_Id_imag; }
               set { _National_Id_imag = value; }
           }

           public byte[] CV_PDF
           {
               get { return _CV_PDF; }
               set { _CV_PDF = value; }
           }

           public string Employee_Document_ID
           {
               get {return this._employee_document_id; }
               set { this._employee_document_id = value; }
           }
           public string Employee_Document_Name
           {
               get { return this._employee_document_name; }
               set { this._employee_document_name = value; }
           }
           public string Employee_Document_Type
           {
               get { return this._employee_document_type; }
               set { this._employee_document_type = value; }
           }
       #endregion
   }
}
