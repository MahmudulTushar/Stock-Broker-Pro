using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Xml;


namespace SBPXMLSchema
{
    public enum XMLExportType{Clients,Position};
    
    public class XMLExport
    {
        public static DateTime Date;
        public static DateTime Time;
        public string fileName;
        string fileNameControl;
        public string ClientXML_FileName = Date.ToString("yyyyMMdd") + "-" + Time.ToString("HHmmss") + "-" + "clients" + "-" + "KSL" + ".xml";
        public string PositionXML_FileName = Date.ToString("yyyyMMdd") + "-" + Time.ToString("HHmmss") + "-" + "positions" + "-" + "KSL" + ".xml";
        public string ClientXML_Control_FileName = Date.ToString("yyyyMMdd") + "-" + Time.ToString("HHmmss") + "-" + "clients" + "-" + "KSL" + "-" + "ctrl" + ".xml";
        public string PositionXML_Control_FileName = Date.ToString("yyyyMMdd") + "-" + Time.ToString("HHmmss") + "-" + "positions" + "-" + "KSL" + "-" + "ctrl" + ".xml";
        XMLExportType type;
        Clients cs;
        Positions ps;
        Control clientsControl;
        Control positionControl;

        public XMLExport(XMLExportType p_type,Object obj, string p_fileName)
        {
            fileName = p_fileName;
            type = p_type;

            if (type == XMLExportType.Clients)
            {
                cs = (Clients)obj;
                fileName = p_fileName+"\\"+ClientXML_FileName;
                fileNameControl = p_fileName+"\\"+ClientXML_Control_FileName;
            }
            else if (type == XMLExportType.Position)
            {
                ps = (Positions)obj;
                fileName = p_fileName+"\\"+PositionXML_FileName;
                fileNameControl = p_fileName+"\\"+PositionXML_Control_FileName;
            }
        }

        private void Populate_Control()
        {
            if (type == XMLExportType.Clients)
            {
                clientsControl = new Control();
                int count = TotalRecordNo();
                string hashvalue = ConvertToHash(Convert.ToString(count));
                clientsControl.Hash = hashvalue;


            }
            else if (type == XMLExportType.Position)
            {
                positionControl = new Control();
                int count = TotalRecordNo();
                string hashvalue = ConvertToHash(Convert.ToString(count));
                positionControl.Hash = hashvalue;
            }
        }

        private int TotalRecordNo()
        {
            int result = 0;
            if (type == XMLExportType.Clients)
            {
                int count = 0;
                if (cs.Deactivate != null)
                    count = count + cs.Deactivate.Length;
                if (cs.Limits != null)
                    count = count + cs.Limits.Length;
                if (cs.Register != null)
                    count = count + cs.Register.Length;
                if (cs.Suspend != null)
                    count = count + cs.Suspend.Length;
                if (cs.DeactivateAllClients != null)
                    count = count + 1;
                result = count;
            }
            else if (type == XMLExportType.Position)
            {
                int count_pos = 0;
                if (ps.DeleteAllPositions != null)
                    count_pos = count_pos + 1;
                if (ps.Items != null)
                    count_pos = count_pos + ps.Items.Length;
                result = count_pos;
            }
            return result;

        }

        public void Export()
        {
            try
            {
                validate();

                if (type == XMLExportType.Clients)
                {
                    var settings = new System.Xml.XmlWriterSettings { OmitXmlDeclaration = false, Indent = true };
                    var ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlSerializer s = new XmlSerializer(typeof(Clients));

                    using (var writer = System.Xml.XmlWriter.Create(fileName, settings))
                    {
                        s.Serialize(writer, cs, ns);
                    }

                    Populate_Control();

                    XmlSerializer s_Control = new XmlSerializer(typeof(Control));
                    using (var writer = System.Xml.XmlWriter.Create(fileNameControl, settings))
                    {
                        s_Control.Serialize(writer, clientsControl, ns);
                    }


                }
                else if (type == XMLExportType.Position)
                {
                    var settings = new System.Xml.XmlWriterSettings { OmitXmlDeclaration = false, Indent = true };
                    var ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlSerializer s = new XmlSerializer(typeof(Positions));
                    using (var writer = System.Xml.XmlWriter.Create(fileName, settings))
                    {
                        s.Serialize(writer, ps, ns);
                    }

                    Populate_Control();

                    XmlSerializer s_Control = new XmlSerializer(typeof(Control));
                    using (var writer = System.Xml.XmlWriter.Create(fileNameControl, settings))
                    {
                        s_Control.Serialize(writer, positionControl, ns);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            };
        }

        private void validate()
        {
            if (fileName == string.Empty)
                throw new Exception("File Name Is Empty");
        }

        private string ConvertToHash(string value)
        {
            string result = string.Empty;
            string sSourceData = value;
            //Create a byte array from source data.
            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            result = ByteArrayToString(tmpHash);

            return result;
        }

        private string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    
    }
}
