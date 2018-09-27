using System;

namespace BusinessAccessLayer.BO
{
    public class AuthorInroducerBO
    {
        private string _authorCustCode;
        private string _authorName;
        private string _authorAddress;
        private string _authorMobile;
        private string _introName;
        private string _introAddress;
        private string _introBOID;
        private string _introRemarks;
        public AuthorInroducerBO()
        {
            _authorCustCode ="";
            _authorName = "";
            _authorAddress = "";
            _authorMobile = "";
            _introName = "";
            _introAddress = "";
            _introBOID = "";
            _introRemarks = "";
        }

        public string AuthorName
        {
            get { return _authorName; }
            set { _authorName = value; }
        }

        public string AuthorAddress
        {
            get { return _authorAddress; }
            set { _authorAddress = value; }
        }

        public string AuthorMobile
        {
            get { return _authorMobile; }
            set { _authorMobile = value; }
        }

        public string IntroName
        {
            get { return _introName; }
            set { _introName = value; }
        }

        public string IntroAddress
        {
            get { return _introAddress; }
            set { _introAddress = value; }
        }

        public string IntroRemarks
        {
            get { return _introRemarks; }
            set { _introRemarks = value; }
        }
        public string AuthorCustCode
        {
            get { return _authorCustCode; }
            set { _authorCustCode = value; }
        }

        public string IntroBOID
        {
            get { return _introBOID; }
            set { _introBOID = value; }
        }
    }
}
