using System;

namespace BusinessAccessLayer.BO
{
    public class BrokerInfoBO
    {
        private string _name;
        private string _boId;
        private string _tradeId;
        private string _exchangeName;
        private string _cdblParticipantId;
        private DateTime _openDate;
        private byte[] _logoImage;
        private byte[] _dirSignImage;
        private byte[] _defaultSignImage; 
        public BrokerInfoBO()
        {
            _name = "";
            _boId = "";
            _tradeId = "";
            _exchangeName = "";
            _cdblParticipantId = "";
            _logoImage = new byte[0];
            _dirSignImage = new byte[0];
            _defaultSignImage = new byte[0];
        }
         
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DateTime OpenDate
        {
            get { return _openDate; }
            set { _openDate = value; }
        }
        public string BOId
        {
            get { return _boId; }
            set { _boId = value; }
        }

        public byte[] LogoImage
        {
            get { return _logoImage; }
            set { _logoImage = value; }
        }

        public byte[] DirSignImage
        {
            get { return _dirSignImage; }
            set { _dirSignImage = value; }
        }

        public byte[] DefaultSignImage
        {
            get { return _defaultSignImage; }
            set { _defaultSignImage = value; }
        }

        public string TradeId
        {
            get { return _tradeId; }
            set { _tradeId = value; }
        }

        public string ExchangeName
        {
            get { return _exchangeName; }
            set { _exchangeName = value; }
        }

        public string CdblParticipantId
        {
            get { return _cdblParticipantId; }
            set { _cdblParticipantId = value; }
        }
    }
}