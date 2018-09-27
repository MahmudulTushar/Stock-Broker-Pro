using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BO
{
  public class EmailConfirmationBO
    {
        private string _to;
        public string To
        {
            get { return _to; }
            set { _to = value; }
        }

        private string _form;
        public string Form
        {
            get { return _form; }
            set { _form = value; }
        }

        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        private string _body;
        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }
    }
}
