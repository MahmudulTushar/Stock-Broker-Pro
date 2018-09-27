using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class DbConnectionBasic
    {
        private static string _connectionString;
        private static string _connectionStringImageExt;
        private static string _connectionStringWeb2014;
        private static string _connectionStringSMSSender;
        private static string _connectionStringBankBook;

        public static string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public static string ConnectionStringImageExt
        {
            get { return _connectionStringImageExt; }
            set { _connectionStringImageExt = value; }
        }


        public static string ConnectionStringWeb2014
        {
            get { return _connectionStringWeb2014; }
            set { _connectionStringWeb2014 = value; }
        }

        public static string ConnectionStringSMSSender
        {
            get { return _connectionStringSMSSender; }
            set { _connectionStringSMSSender = value; }
        }

        public static string connectionStringBankBook
        {
            get { return _connectionStringBankBook; }
            set { _connectionStringBankBook = value; }
        }
    }
}
