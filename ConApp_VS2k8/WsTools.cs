using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace ConApp_VS2k8
{
    public class WsTools
    {
        public static string CreateRequest(string asmxUrl, string xml, int? timeOut)
        {
            string sendReq = AddSoapTags(xml);
            byte[] buffer = new ASCIIEncoding().GetBytes(sendReq);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(asmxUrl);
            if (timeOut.HasValue)
            {
                req.Timeout = timeOut.Value;
            }
            req.Method = "POST";
            req.ContentType = "text/xml; charset=utf-8";
            req.Referer = asmxUrl;
            req.ContentLength = buffer.Length;
            req.ProtocolVersion = HttpVersion.Version11;
            Stream reqst = req.GetRequestStream();
            reqst.Write(buffer, 0, buffer.Length);
            reqst.Flush();
            reqst.Close();
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream());
            string response = RemoveXmlTag(RemoveSoapTags(sr.ReadToEnd()));
            sr.Close();
            return response;
        }
        private static string RemoveSoapTags(string xml)
        {
            xml = xml.Replace("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body>", string.Empty);
            xml = xml.Replace("</soap:Body></soap:Envelope>", string.Empty);
            return xml;
        }

        private static string RemoveXmlTag(string xml)
        {
            xml = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", string.Empty);
            return xml;
        }

        private static string PrepareResponse(string response, bool replaceDatetime)
        {
            response = response.Replace("\n", string.Empty);
            response = response.Replace("\r", string.Empty);
            response = response.Replace("\t", string.Empty);
            response = response.Replace("  ", string.Empty);
            response = AddSoapTags(response);
            XmlDocument xmlResponse = new XmlDocument();
            xmlResponse.LoadXml(response);
            return FormatXML(xmlResponse);
        }

        private static string FormatXML(XmlDocument doc)
        {
            string returnValue = string.Empty;
            using (StringWriter sw = new StringWriter())
            {
                using (XmlTextWriter xtw = new XmlTextWriter(sw))
                {
                    xtw.Formatting = Formatting.Indented;
                    doc.WriteTo(xtw);
                    returnValue = sw.ToString();
                }
            }
            return returnValue;
        }

        private static string AddSoapTags(string xml)
        {
            return string.Format("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body>{0}</soap:Body></soap:Envelope>", xml);
        }
    }
}
