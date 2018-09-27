using System;

namespace BusinessAccessLayer.BO
{
    public class CustomerAdditionalInfoBO
    {
        private string _custCode;
        private string _residency;
        private string _nationality;
        private int _statementCycleID;
        private string _internalRefNo;
        private string _companyRegNo;
        private DateTime _companyRegDate;
        private int _isAccLinkRequest;
        private string _accLinkBO;
        private int _isStandingIns;
        private string _assignedWorkstation;
        private string _Net_Adjustment;

      
        
       
        public CustomerAdditionalInfoBO()
        {
            _custCode = "";
            _residency = "";
            _nationality = "";
            _statementCycleID = 0;
            _internalRefNo = "";
            _companyRegNo = "";
            _isAccLinkRequest = 0;
            _accLinkBO = "";
            _isStandingIns = 0;
            _assignedWorkstation = "";
            _Net_Adjustment = "";
            //_companyRegDate =;


        }
        public string Net_Adjustment
        {
            get { return _Net_Adjustment; }
            set { _Net_Adjustment = value; }
        }

        public string AssignedWorkstation
        {
            get { return _assignedWorkstation; }
            set { _assignedWorkstation = value; }
        }

        public string CustCode
        {
            get { return _custCode; }
            set { _custCode = value; }
        }

        public string Residency
        {
            get { return _residency; }
            set { _residency = value; }
        }

        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }

        public int StatementCycleID
        {
            get { return _statementCycleID; }
            set { _statementCycleID = value; }
        }

        public string InternalRefNo
        {
            get { return _internalRefNo; }
            set { _internalRefNo = value; }
        }

        public string CompanyRegNo
        {
            get { return _companyRegNo; }
            set { _companyRegNo = value; }
        }

        public DateTime CompanyRegDate
        {
            get { return _companyRegDate; }
            set { _companyRegDate = value; }
        }

        public int IsAccLinkRequest
        {
            get { return _isAccLinkRequest; }
            set { _isAccLinkRequest = value; }
        }

        public string AccLinkBo
        {
            get { return _accLinkBO; }
            set { _accLinkBO = value; }
        }

        public int IsStandingIns
        {
            get { return _isStandingIns; }
            set { _isStandingIns = value; }
        }
    }
}
