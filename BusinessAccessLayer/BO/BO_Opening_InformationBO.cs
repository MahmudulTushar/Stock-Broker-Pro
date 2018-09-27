using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    //added by nazmul 2016-05-31
    public class BO_Opening_InformationBO
    {
        private int _Sl_No;
        private string _Name;
        private string _CellNo;
        private DateTime _OpDate;
        private int _Qty;
        private double _Price;
        private double _TotalPrice;
        private int _FrmNoFast;
        private int _FrmNoLast;
        private int _BranchId;
        private DateTime _CreateDate;
        private string _CreateBy;
        private string _Remarks;

        public BO_Opening_InformationBO()
        {
            _Sl_No = 0;
            _Name = string.Empty;
            _CellNo = string.Empty;
            _OpDate = DateTime.MinValue;
            _Qty = 0;
            _Price = 0;
            _TotalPrice = 0;
            _FrmNoFast = 0;
            _FrmNoLast = 0;
            _BranchId = 0;
            _CreateDate = DateTime.MinValue;
            _CreateBy = string.Empty;
            _Remarks = string.Empty;
        }

        public int Sl_No
        {
            get { return _Sl_No; }
            set { _Sl_No = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string CellNo
        {
            get { return _CellNo; }
            set { _CellNo = value; }
        }
        public DateTime OpDate
        {
            get { return _OpDate; }
            set { _OpDate = value; }
        }
        public int Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        public double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        public double TotalPrice
        {
            get { return _TotalPrice; }
            set { _TotalPrice = value; }
        }
        public int FrmNoFast
        {
            get { return _FrmNoFast; }
            set { _FrmNoFast = value; }
        }
        public int FrmNoLast
        {
            get { return _FrmNoLast; }
            set { _FrmNoLast = value; }
        }
        public int BranchId
        {
            get { return _BranchId; }
            set { _BranchId = value; }
        }
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        public string CreateBy
        {
            get { return _CreateBy; }
            set { _CreateBy = value; }
        }
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
    }
}
