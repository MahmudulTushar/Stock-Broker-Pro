using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
    public class ShareListBO
    {
        private DateTime dtTo;
        private DateTime dtFrom;
        private string workStation;

        public string WorkStation
        {
            get { return workStation; }
            set { workStation = value; }
        }

        public ShareListBO()
        {
            //    dtTo = 
            //    dtTo = "";

        }

        public DateTime DtFrom
        {
            get { return dtFrom; }
            set { dtFrom = value; }
        }

        public DateTime DtTo
        {
            get { return dtTo; }
            set { dtTo = value; }
        }


    }
}
