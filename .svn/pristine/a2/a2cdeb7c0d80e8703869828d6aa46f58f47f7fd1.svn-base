using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public class CityBankBO
    {
        private DateTime _chequeDate;
        private string _description;
        private string _chequeNo;
        private string _debit;
        private string _credit;
        private string _balance;
        public CityBankBO()
        {
            _description = "";
            _debit = "";
            _credit = "";
            _chequeNo = "";
            _balance = "";
        }

        public DateTime ChequeDate
        {
            get { return _chequeDate; }
            set { _chequeDate = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string ChequeNo
        {
            get { return _chequeNo; }
            set { _chequeNo = value; }
        }

        public string Debit
        {
            get { return _debit; }
            set { _debit = value; }
        }

        public string Credit
        {
            get { return _credit; }
            set { _credit = value; }
        }

        public string Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        public class CityBankCollectionBO : System.Collections.CollectionBase
        {

            public CityBankCollectionBO()
            {
                base.InnerList.Clear();
            }

            public virtual void Add(CityBankBO oItem)
            {
                base.InnerList.Add(oItem);
            }

            public virtual CityBankBO this[int index]
            {
                get
                {
                    return (CityBankBO)(base.InnerList[index]);
                }
                set
                {

                    base.InnerList[index] = value;
                }
            }

        }
    }
}
