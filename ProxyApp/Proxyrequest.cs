using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProxyApp
{
    public class Proxyrequest
    {
        
        public string SendURLRequest(string ipaddress, int port, string Useragent, string url, string username = "" , string password = "")
        {
            //string url = @"http://greenbrickdigital.go2cloud.org/aff_c?offer_id=3591&aff_id=1531";
            //string url = ConfigurationManager.AppSettings["url"].ToString();

            //HttpWebRequest tryone = (HttpWebRequest)WebRequest.Create(url);
            //WebResponse resone = tryone.GetResponse();

            ErrorLog log = new ErrorLog();
            

            try
            {

                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
                 //webProxy = new WebProxy();

                WebProxy webProxy = new WebProxy(ipaddress, port);
                
                string[] values = password.Split('_');
                string[] inner = values[1].Split('-');
                if(inner.Length == 2)
                {
                    if (inner[1] == "")
                        password = values[0];
                }


                if (username != "" && password != "")
                {
                    ICredentials credentials = new NetworkCredential(username, password);
                    webProxy.UseDefaultCredentials = true;
                    webProxy.Credentials = credentials;

                }

                if (ConfigurationManager.AppSettings["loginmethod"].ToString() == "dns")
                {
                    string address = @"http://" + username + ":" + password + "@" + ipaddress + ":" + port.ToString();
                    webProxy.Address = new Uri(address);
                }


                //webProxy.BypassProxyOnLocal = true;
                //webProxy.UseDefaultCredentials = true;
                webReq.Proxy = webProxy;
                
                webReq.MaximumAutomaticRedirections = 5000;
                string timeoutvalue = ConfigurationManager.AppSettings["timeout"].ToString();
                webReq.Timeout = Convert.ToInt32(timeoutvalue);
                webReq.UserAgent = Useragent;

                //webReq.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
                webReq.CookieContainer = new CookieContainer();
                webReq.Method = "GET";
                using (WebResponse response = webReq.GetResponse())
                {
                    var total = response.ContentLength;
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                        string res = reader.ReadToEnd();
                        return res;
                    }
                }
            }
            catch (Exception ex)
            {
                
                log.WriteToErrorLog(ex.Message, ex.StackTrace, ex.Message);
                throw ex;
            }
        }
    }
}
