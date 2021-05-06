

namespace Libreria.Soporte.Helpers
{
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    public class SerializerHelper
    {
        /// <summary>
        /// Permite serializar un objeto
        /// </summary>
        /// <param name="objeto">System.Object objeto</param>
        /// <param name="t">System.Type t</param>
        /// <returns>Retorna SerializeObject</returns>
        public static string Serialize<T>(T value)
        {

            if (value == null)
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
            settings.Indent = false;
            settings.OmitXmlDeclaration = true;

            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, value);
                }
                return textWriter.ToString();
            }
        }

        /// <summary>
        /// Permite deserealizar un objeto
        /// </summary>
        /// <typeparam name="T">System.Type t tipo del </typeparam>
        /// <param name="xml">xml para deserealizar</param>
        /// <returns> Retorna el objeto correspondiente</returns>
        public static T Deserialize<T>(string xml)
        {

            if (string.IsNullOrEmpty(xml))
            {
                return default(T);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            XmlReaderSettings settings = new XmlReaderSettings();
            // No settings need modifying here

            using (StringReader textReader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
                {
                    return (T)serializer.Deserialize(xmlReader);
                }
            }
        }

        public static XmlDocument ObtenerXmlDocument<T>(T Obj)
        {
            XmlDocument _XmlDocument = new XmlDocument();
            string xml = string.Empty;
            xml = ObtenerXml(Obj);

            //Cargar en objeto xmldocument
            _XmlDocument.LoadXml(xml);
            //eliminar primer nodo de declaracion xml
            if (_XmlDocument.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
                _XmlDocument.RemoveChild(_XmlDocument.FirstChild);

            return _XmlDocument;
        }



        public static string ObtenerXml<T>(T Obj)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            string xml = "";
            XmlDocument xDocument = new XmlDocument();
            //Serializar objeto
            using (StringWriter sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    ser.Serialize(writer, Obj);
                    xml = sww.ToString(); // Your XML
                }
            }

            return xml;
        }
    }
}
