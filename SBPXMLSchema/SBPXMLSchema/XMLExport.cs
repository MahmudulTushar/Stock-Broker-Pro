using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SBPXMLSchema
{
    public enum XMLExportType{Clients,Position};
    
    public class XMLExport
    {
        string fileName;
        XMLExportType type;
        Clients cs;
        Positions ps;
        Control control;

        public XMLExport(XMLExportType p_type,Object obj, string p_fileName)
        {
            fileName = p_fileName;
            type = p_type;
            
            if (type == XMLExportType.Clients)
                cs = (Clients)obj;
            else if (type == XMLExportType.Position)
                ps = (Positions)obj;
        }

        public void Export()
        {
            try
            {
                validate();

                if (type == XMLExportType.Clients)
                {
                    var settings = new System.Xml.XmlWriterSettings { OmitXmlDeclaration = false, Indent = false };
                    var ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlSerializer s = new XmlSerializer(typeof(Clients));
                    using (var writer = System.Xml.XmlWriter.Create(fileName, settings))
                    {
                        s.Serialize(writer, cs, ns);
                    }
                    
                }
                else if (type == XMLExportType.Position)
                {
                    var settings = new System.Xml.XmlWriterSettings { OmitXmlDeclaration = false, Indent = false };
                    var ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlSerializer s = new XmlSerializer(typeof(Positions));
                    using (var writer = System.Xml.XmlWriter.Create(fileName, settings))
                    {
                        s.Serialize(writer, ps, ns);
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
    
    }
}
