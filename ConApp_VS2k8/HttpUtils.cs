using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using Lsi.Libs.LsiNLogger;

namespace ConApp_VS2k8
{
    public class HttpUtils
    {
        public static void HttpRequestPost(string url, string apiId, string from, string to, string timestamp,
           string text, string charset, string udh, string moMsgId)
        {
            const string httpXForwardedForKey = "HTTP_X_FORWARDED_FOR";
            const string remoteAddr = "REMOTE_ADDR";

            try
            {
                WebClient myWebClient = new WebClient();
                NameValueCollection myNameValueCollection = new NameValueCollection();
                myNameValueCollection.Add("api_id", apiId);
                myNameValueCollection.Add("from", from);
                myNameValueCollection.Add("to", to);
                myNameValueCollection.Add("timestamp", timestamp);
                myNameValueCollection.Add("text", text);
                myNameValueCollection.Add("charset", charset);
                myNameValueCollection.Add("udh", udh);
                myNameValueCollection.Add("moMsgId", moMsgId);

                myWebClient.Headers.Add(httpXForwardedForKey, "64.129.32.194");
                myWebClient.Headers.Add(remoteAddr, "192.168.8.2");
                //myWebClient.Headers.Add(remoteAddr, "64.129.32.194");

                byte[] responseArray = myWebClient.UploadValues(url, "POST", myNameValueCollection);
                string response = Encoding.ASCII.GetString(responseArray);
                LsiLogger.Trace(string.Format("Response received was:{0}{1}", Environment.NewLine, response));
            }
            catch (Exception ex)
            {
                LsiLogger.Trace(string.Format("Error while create request:{0}{1}", Environment.NewLine, ex));
            }
        }


    }
}
