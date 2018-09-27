using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Globalization;

namespace BusinessAccessLayer.BAL
{
   public class ValidateExelField
   {
       #region Excel Connection
       public DataTable GetData(string fileName)
       {
           string extension = Path.GetExtension(fileName);
           string str2 = string.Empty;
           if (extension.ToLower().Equals(".xls"))
           {
               str2 = "provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;Data Source='";
           }
           else
           {
               str2 = "provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=Excel 12.0;Data Source='";
           }
           OleDbConnection connection = new OleDbConnection(str2 + fileName + "'");
           //connection.Open();
           OleDbCommand command = new OleDbCommand
           {
               CommandText = "SELECT * FROM [Sheet1$]",
               Connection = connection
           };
           DataTable dataTable = new DataTable();
           OleDbDataAdapter adapter = new OleDbDataAdapter
           {
               SelectCommand = command
           };
           try
           {
               connection.Open();
               adapter.Fill(dataTable);
           }
           catch (Exception exception)
           {
               Console.WriteLine(exception.Message);
           }
           finally
           {
               connection.Close();
           }
           return dataTable;
       }
       #endregion

       #region Text Reader
       public static DataTable ReadFile(string filename, string delimiter)
       {
           return ReadFile(filename, delimiter, null);
       }

       public static DataTable ReadFile(string filename, string delimiter, string[] columnNames)
       {
           DataTable table = new DataTable
           {
               Locale = CultureInfo.CurrentCulture
           };
           if (!File.Exists(filename))
           {
               throw new FileNotFoundException("File not found", filename);
           }
           using (TextReader reader = new StreamReader(filename, Encoding.Default))
           {
               string str;
               if (columnNames == null)
               {
                   str = reader.ReadLine();
                   if (string.IsNullOrEmpty(str))
                   {
                       throw new IOException("Could not read column names from file.");
                   }
                   columnNames = str.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
               }
               foreach (string str2 in columnNames)
               {
                   table.Columns.Add(str2);
               }
               while ((str = reader.ReadLine()) != null)
               {
                   string[] values = str.Split(new string[] { delimiter }, StringSplitOptions.None);
                   if (values.Length != columnNames.Length)
                   {
                       string format = "Data row has {0} columns and {1} are defined by column names.";
                       throw new DataException(string.Format(format, values.Length, columnNames.Length));
                   }
                   table.Rows.Add(values);
               }
           }
           return table;
       }
       #endregion
       private string cityroutNo = "";
        private string errorString;

        private bool IsAlpha(string strToCheck)
        {
            Regex regex = new Regex("[^a-zA-Z]");
            return !regex.IsMatch(strToCheck);
        }

        private bool IsAlphaNumeric(string strToCheck)
        {
            Regex regex = new Regex("[^a-zA-Z0-9]");
            return !regex.IsMatch(strToCheck);
        }

        private bool IsAlphaNumericForEFT(string strToCheck)
        {
            Regex regex = new Regex("[^a-z.,() A-Z0-9-]");
            return !regex.IsMatch(strToCheck);
        }

        private bool IsCityRoutNo(string strNumber)
        {
            if (strNumber == "")
            {
                return false;
            }
            if (strNumber.ToString().Substring(0, 3) == "225")
            {
                return false;
            }
            Regex regex = new Regex("[^0-9]");
            return !regex.IsMatch(strNumber);
        }

        private bool IsEFTAccountNumber(string strToCheck)
        {
            if (strToCheck.Contains("  "))
            {
                return false;
            }
            Regex regex = new Regex("[^a-zA-Z0-9/.#()&: -]");
            return !regex.IsMatch(strToCheck);
        }

        private bool IsEFTReceiverID(string strToCheck)
        {
            if (strToCheck.Contains("  "))
            {
                return false;
            }
            Regex regex = new Regex(@"[^\w\s]");
            return !regex.IsMatch(strToCheck);
        }

        private bool IsEFTReceiverNamer(string strToCheck)
        {
            Regex regex = new Regex("[^a-zA-Z0-9/.#()&: -]");
            return !regex.IsMatch(strToCheck);
        }

        private bool IsInteger(string strNumber)
        {
            Regex regex = new Regex("[^0-9-]");
            Regex regex2 = new Regex("^-[0-9]+$|^[0-9]+$");
            return (!regex.IsMatch(strNumber) && regex2.IsMatch(strNumber));
        }

        private bool IsNaturalNumber(string strNumber)
        {
            Regex regex = new Regex("[^0-9]");
            Regex regex2 = new Regex("0*[1-9][0-9]*");
            return (!regex.IsMatch(strNumber) && regex2.IsMatch(strNumber));
        }

        private bool IsNumber(string strNumber)
        {
            Regex regex = new Regex("[^0-9.-]");
            Regex regex2 = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex regex3 = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            string str = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            string str2 = "^([-]|[0-9])[0-9]*$";
            Regex regex4 = new Regex("(" + str + ")|(" + str2 + ")");
            return (((!regex.IsMatch(strNumber) && !regex2.IsMatch(strNumber)) && !regex3.IsMatch(strNumber)) && regex4.IsMatch(strNumber));
        }

        private bool IsPositiveNumber(string strNumber)
        {
            Regex regex = new Regex("[^0-9.]");
            Regex regex2 = new Regex("^[.][0-9]+$|[0-9]*[.]*[0-9]+$");
            Regex regex3 = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            return ((!regex.IsMatch(strNumber) && regex2.IsMatch(strNumber)) && !regex3.IsMatch(strNumber));
        }

        private bool IsRoutingNoOKorNOT(string strNumber)
        {
            int num = 10;
            int num2 = 10;
            int num3 = 0;
            int num4 = 0;
            string str = strNumber;
            int num5 = int.Parse(str.Substring(0, 1));
            int num6 = int.Parse(str.Substring(1, 1));
            int num7 = int.Parse(str.Substring(2, 1));
            int num8 = int.Parse(str.Substring(3, 1));
            int num9 = int.Parse(str.Substring(4, 1));
            int num10 = int.Parse(str.Substring(5, 1));
            int num11 = int.Parse(str.Substring(6, 1));
            int num12 = int.Parse(str.Substring(7, 1));
            int num13 = int.Parse(str.Substring(8, 1));
            int num14 = (((((((num5 * 5) + (num6 * 7)) + num7) + (num8 * 5)) + (num9 * 7)) + num10) + (num11 * 5)) + (num12 * 7);
            string str2 = num14.ToString();
            if (str2.Length == 3)
            {
                num4 = (int.Parse(str2.Substring(0, 2)) * num) + num2;
            }
            else
            {
                num4 = (int.Parse(str2.Substring(0, 1)) * num) + num2;
            }
            num3 = num4 - num14;
            if (int.Parse(num3.ToString().Substring(Math.Max(0, num3.ToString().Length - 1))) != num13)
            {
                return false;
            }
            Regex regex = new Regex("[^0-9-]");
            return !regex.IsMatch(strNumber);
        }

        private bool IsWholeNumber(string strNumber)
        {
            Regex regex = new Regex("[^0-9]");
            return !regex.IsMatch(strNumber);
        }

        private DataTable readEx(string filePath, string shiftName)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=Excel 8.0;");
            connection.Open();
            OleDbCommand command = new OleDbCommand("SELECT * FROM [" + shiftName + "$]", connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter {
                SelectCommand = command
            };
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public string ValidateExcelForEFT(string excelFilePath)
        {
            string extension = Path.GetExtension(excelFilePath);
            DataTable data = new DataTable();
            //ExcelDB ldb = new ExcelDB();
            if (extension.ToLower().Equals(".txt"))
            {
                data = this.readEx(excelFilePath, "Sheet1");
            }
            else
            {
                data = GetData(excelFilePath);
            }
            StringBuilder builder = new StringBuilder();
            int num = 1;
            int num2 = 0;
            if (data.Rows.Count < 1)
            {
                builder.AppendLine("Data is not available in Sheet1");
                builder.AppendLine("or Sheet1 not found");
                builder.AppendLine("or rename your data sheet as Sheet1.");
            }
            for (int i = 0; i < data.Rows.Count; i++)
            {
                num++;
                string str2 = string.Empty;
                try
                {
                    str2 = data.Rows[i]["AccType"].ToString().Trim();
                }
                catch
                {
                    builder.AppendLine("\"AccType\" column not found");
                    break;
                }
                string str3 = string.Empty;
                try
                {
                    str3 = data.Rows[i]["BankAccNo"].ToString().Trim();
                }
                catch
                {
                    builder.AppendLine("\"BankAccNo\" column not found");
                    break;
                }
                string str4 = string.Empty;
                try
                {
                    str4 = data.Rows[i]["SenderAccNumber"].ToString().Trim();
                }
                catch
                {
                    builder.AppendLine("\"SenderAccNumber\" column not found");
                    break;
                }
                string str5 = string.Empty;
                try
                {
                    str5 = data.Rows[i]["ReceivingBankRouting"].ToString().Trim();
                }
                catch
                {
                    builder.AppendLine("\"ReceivingBankRouting\" column not found");
                    break;
                }
                string strNumber = string.Empty;
                try
                {
                    strNumber = data.Rows[i]["Amount"].ToString().Replace(",", "").Trim();
                }
                catch
                {
                    builder.AppendLine("\"Amount\" column not found");
                    break;
                }
                string str7 = string.Empty;
                try
                {
                    str7 = data.Rows[i]["ReceiverID"].ToString().Trim();
                }
                catch
                {
                    builder.AppendLine("\"ReceiverID\" column not found");
                    break;
                }
                string str8 = string.Empty;
                try
                {
                    str8 = data.Rows[i]["ReceiverName"].ToString().Trim();
                }
                catch
                {
                    builder.AppendLine("\"ReceiverName\" column not found");
                    break;
                }
                string str9 = string.Empty;
                try
                {
                    str9 = data.Rows[i]["Reason"].ToString().Trim();
                }
                catch
                {
                    builder.AppendLine("\"Reason\" column not found");
                    break;
                }
                if ((((!str9.Equals(string.Empty) || !str4.Equals(string.Empty)) || (!str5.Equals(string.Empty) || !str3.Equals(string.Empty))) || ((!str2.Equals(string.Empty) || !strNumber.Equals(string.Empty)) || !str7.Equals(string.Empty))) || !str8.Equals(string.Empty))
                {
                    if (!str2.ToUpper().StartsWith("C") && !str2.ToUpper().StartsWith("S"))
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - Account Type is not in the norrect format - ");
                        builder.AppendLine(str2);
                        num2++;
                    }
                    if (str3.Length > 0x11)
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - Bank Account No. legnth is greater than ");
                        builder.Append(0x11);
                        builder.Append("\t");
                        builder.AppendLine(str3);
                        num2++;
                    }
                    if (str3.Equals(string.Empty))
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - Bank Account No. is not in the correct format - ");
                        builder.AppendLine(str3);
                        num2++;
                    }
                    if (!this.IsEFTAccountNumber(str3.Replace(" ", "")))
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - Bank Account No. is not in the correct format - ");
                        builder.AppendLine(str3);
                        num2++;
                    }
                    if (str4.Length > 0x11)
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - Sender Account No. legnth is greater than ");
                        builder.Append(0x11);
                        builder.Append("\t");
                        builder.AppendLine(str4);
                        num2++;
                    }
                    if (str4.Equals(string.Empty))
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - Sender Account No. is not in the correct format - ");
                        builder.AppendLine(str4);
                        num2++;
                    }
                    if (!this.IsEFTAccountNumber(str4.Replace(" ", "")))
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - Bank Account No. is not in the correct format - ");
                        builder.AppendLine(str4);
                        num2++;
                    }
                    if (str5.Length > 9)
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - Receiving Bank Routing No. legnth is greater than ");
                        builder.Append(9);
                        builder.Append("\t");
                        builder.AppendLine(str5);
                        num2++;
                    }
                    if ((!this.IsWholeNumber(str5) || str5.Equals(string.Empty)) || (str5.Length != 9))
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - Receiving Bank Routing No. is not in the correct format - ");
                        builder.AppendLine(str5);
                        num2++;
                    }
                    if (str5.ToString().Substring(0, 3) == "225")
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - This is 'The City Bank Ltd' Routing No. Pls correct it. - ");
                        builder.AppendLine(str5);
                        num2++;
                    }
                    if (!this.IsRoutingNoOKorNOT(str5))
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - This is not valid Routing No. - ");
                        builder.AppendLine(str5);
                        num2++;
                    }
                    if (!(this.IsPositiveNumber(strNumber) && !strNumber.Equals(string.Empty)))
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - Amount is not in the correct format - ");
                        builder.AppendLine(strNumber);
                        num2++;
                    }
                    if (str7.Length > 15)
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - ReceiverID legnth is greater than ");
                        builder.Append(15);
                        builder.Append("\t");
                        builder.AppendLine(str7);
                        num2++;
                    }
                    if (!(this.IsEFTReceiverID(str7) && !str7.Equals(string.Empty)))
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - Receiver ID is not in the correct format - ");
                        builder.AppendLine(str7);
                        num2++;
                    }
                    if (str8.Length > 0x16)
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - Receiver Name legnth is greater than ");
                        builder.Append(0x16);
                        builder.Append("\t");
                        builder.AppendLine(str8);
                        num2++;
                    }
                    if (str8.Equals(string.Empty))
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - Receiver Name is not in the correct format - ");
                        builder.AppendLine(str8);
                        num2++;
                    }
                    if (!(this.IsEFTReceiverNamer(str8) && !str8.Equals(string.Empty)))
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - Receiver Name is not in the correct format - ");
                        builder.AppendLine(str8);
                        num2++;
                    }
                    if (str9.Length > 80)
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - Reason legnth is greater than ");
                        builder.Append(80);
                        builder.Append("\t");
                        builder.AppendLine(str9);
                        num2++;
                    }
                    if (!(this.IsEFTAccountNumber(str9) && !str9.Equals(string.Empty)))
                    {
                        builder.Append("Row No. = ");
                        builder.Append(num);
                        builder.Append(" - Payment Info is not in the correct format - ");
                        builder.AppendLine(str9);
                        num2++;
                    }
                }
            }
            if (num2 > 0)
            {
                builder.Append("Total Error = ");
                builder.AppendLine(num2.ToString());
            }
            return builder.ToString();
        }
    
    }
}
