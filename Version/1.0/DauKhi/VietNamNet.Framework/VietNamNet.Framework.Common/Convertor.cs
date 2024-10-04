using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace VietNamNet.Framework.Common
{
    public class Convertor
    {
        public static object ToObject(Type objectType, string xml)
        {
            object obj = null;
            try
            {
                XmlSerializer xs = new XmlSerializer(objectType);
                MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(xml));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                return xs.Deserialize(memoryStream);
            }
            catch (Exception ex)
            {
                obj = null;
            }

            return obj;
        }

        public static string ToString(object xmlObject)
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(xmlObject.GetType());
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                xs.Serialize(xmlTextWriter, xmlObject);
                memoryStream = (MemoryStream) xmlTextWriter.BaseStream;
                XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                return XmlizedString;
            }
            catch (Exception ex)
            {
            }

            return string.Empty;
        }


        public static String UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();

            String constructedString = encoding.GetString(characters);

            return (constructedString);
        }


        public static Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();

            Byte[] byteArray = encoding.GetBytes(pXmlString);

            return byteArray;
        }
    }
}