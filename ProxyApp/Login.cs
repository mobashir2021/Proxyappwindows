using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Management;
using MySql.Data.MySqlClient;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Xml;
using System.Collections.Specialized;

namespace ProxyApp
{
    public partial class frmLogin : Form
    {
        string connstring = @"Data Source=myServerAddress;Initial Catalog=myDataBase;Integrated Security=SSPI;User ID=myDomain\myUsername;Password=myPassword;";
        string cs = @"server=166.62.27.144;userid=digimarkonUser;password=XIE9Q#(i&III;database=digimarkon";
        //string connstring = @"Data Source=DESKTOP-AH7HLNK;Initial Catalog=Proxyapp;Integrated Security=True";
        string Username = "";
        string Password = "";
        string Macaddress = "";
        public frmLogin()
        {
            InitializeComponent();

            //var url = "https://sanjibdangi:UGoBIJVhWyAmtSvN_country-Hungary_session-67U9YXqW@proxy.packetstream.io:31111";
            //Uri myUri = new Uri(url);
            //var ip = Dns.GetHostAddresses(myUri.Host)[0];
            int i = 2;

            //        string strReturnVal;
            //        string ipResponse = IPRequestHelper("http://ip-api.com/xml/" + ip);

            //        //return ipResponse;
            //        XmlDocument ipInfoXML = new XmlDocument();
            //        ipInfoXML.LoadXml(ipResponse);
            //        XmlNodeList responseXML = ipInfoXML.GetElementsByTagName("query");

            //        NameValueCollection dataXML = new NameValueCollection();

            //        dataXML.Add(responseXML.Item(0).ChildNodes[2].InnerText, responseXML.Item(0).ChildNodes[2].Value);

            //        strReturnVal = responseXML.Item(0).ChildNodes[1].InnerText.ToString(); // Contry
            //        strReturnVal += "(" +

            //responseXML.Item(0).ChildNodes[2].InnerText.ToString() + ")";

        }

        public string IPRequestHelper(string url)
        {

            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();

            StreamReader responseStream = new StreamReader(objResponse.GetResponseStream());
            string responseRead = responseStream.ReadToEnd();

            responseStream.Close();
            responseStream.Dispose();

            return responseRead;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtusername.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Kindly enter Username/Password!");
                return;
            }
            //DataTable dt = new DataTable();
            //using (MySqlConnection sql = new MySqlConnection())
            //{
            //    sql.ConnectionString = cs;
            //    if (sql.State == ConnectionState.Closed)
            //        sql.Open();
            //    MySqlCommand sqlCommand = new MySqlCommand();
            //    sqlCommand.CommandText = "Proxyproc";
            //    sqlCommand.Parameters.Add("conditionaloperator", MySqlDbType.Int32).Value = 1;
            //    sqlCommand.Parameters.Add("username", MySqlDbType.VarChar).Value = txtusername.Text.Trim();
            //    sqlCommand.Parameters.Add("password", MySqlDbType.VarChar).Value = txtPassword.Text.Trim();
            //    sqlCommand.Connection = sql;
            //    sqlCommand.CommandType = CommandType.StoredProcedure;

            //    MySqlDataAdapter sqlData = new MySqlDataAdapter();
            //    sqlData.SelectCommand = sqlCommand;
            //    sqlData.Fill(dt);


            //    sql.Close();
            //}

            //Task<string> task = getLogin(txtusername.Text.Trim(), txtPassword.Text.Trim());
            //task.Wait();
            //var result = task.Result;

            string data = "username=" + txtusername.Text.Trim() + "&password=" + txtPassword.Text.Trim(); //replace <value>
            byte[] dataStream = Encoding.UTF8.GetBytes(data);
            string urlPath = "https://digimarkon.com/login/";
            string request = urlPath + "getuserinfo";
            WebRequest webRequest = WebRequest.Create(request);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = dataStream.Length;  
            Stream newStream = webRequest.GetRequestStream();
            // Send the data.
            newStream.Write(dataStream,0,dataStream.Length);
            newStream.Close();
            HttpWebResponse webResponse =(HttpWebResponse) webRequest.GetResponse();
            var encoding = ASCIIEncoding.ASCII;
            string responseText = "";
            using (var reader = new System.IO.StreamReader(webResponse.GetResponseStream(), encoding))
            {
                responseText = reader.ReadToEnd();
            }
            Username = "";
            var resultdata = JsonConvert.DeserializeObject<dynamic>(responseText);
            if(resultdata.Message.ToString() == "Data Found")
            {
                Username = resultdata.Result.Username.ToString();
                Password = resultdata.Result.Password.ToString();
                Macaddress = resultdata.Result.MacAddress.ToString();
            }
            else
            {
                MessageBox.Show("Kindly Enter Correct Username/Password or contact Administrator!");
                return;
            }

            if (string.IsNullOrEmpty(Username))
            {
                MessageBox.Show("Kindly Enter Correct Username/Password or contact Administrator!");
                return;
            }

            if (!string.IsNullOrEmpty(Macaddress))
            {
                if (Macaddress != GetSystemid())
                {
                    MessageBox.Show("This is not authorized system, contact Administrator!");
                    return;
                }
            }
            else
            {
                string madddd = GetSystemid();
                string data1 = "username=" + txtusername.Text.Trim() + "&password=" + txtPassword.Text.Trim() + "&macaddress=" + GetSystemid(); //replace <value>
                byte[] dataStream1 = Encoding.UTF8.GetBytes(data1);
                string urlPath1 = "https://digimarkon.com/login/";
                string request1 = urlPath1 + "updatemacadd";
                WebRequest webRequest1 = WebRequest.Create(request1);
                webRequest1.Method = "POST";
                webRequest1.ContentType = "application/x-www-form-urlencoded";
                webRequest1.ContentLength = dataStream1.Length;
                Stream newStream1 = webRequest1.GetRequestStream();
                // Send the data.
                newStream1.Write(dataStream1, 0, dataStream1.Length);
                newStream1.Close();
                HttpWebResponse webResponse1 = (HttpWebResponse)webRequest1.GetResponse();
                var encoding1 = ASCIIEncoding.ASCII;
                string responseText1 = "";
                using (var reader1 = new System.IO.StreamReader(webResponse1.GetResponseStream(), encoding))
                {
                    responseText1 = reader1.ReadToEnd();
                }
            }
            //if (dt.Rows.Count == 0)
            //{
            //    MessageBox.Show("Kindly Enter Correct Username/Password or contact Administrator!");
            //    return;
            //}


            //Username = dt.Rows[0]["Username"].ToString();
            //Password = dt.Rows[0]["Password"].ToString();
            //Macaddress = dt.Rows[0]["MacAddress"].ToString();

            //if (!string.IsNullOrEmpty(Macaddress))
            //{
            //    if (Macaddress != GetSystemid())
            //    {
            //        MessageBox.Show("This is not authorized system, contact Administrator!");
            //        return;
            //    }
            //}
            //else
            //{
            //    using (MySqlConnection sql = new MySqlConnection())
            //    {
            //        sql.ConnectionString = cs;
            //        if (sql.State == ConnectionState.Closed)
            //            sql.Open();
            //        MySqlCommand sqlCommand = new MySqlCommand();
            //        sqlCommand.CommandText = "Proxyproc";
            //        sqlCommand.Parameters.Add("@conditionaloperator", MySqlDbType.Int32).Value = 2;
            //        sqlCommand.Parameters.Add("@username", MySqlDbType.VarChar).Value = txtusername.Text.Trim();
            //        sqlCommand.Parameters.Add("@password", MySqlDbType.VarChar).Value = txtPassword.Text.Trim();
            //        sqlCommand.Parameters.Add("@macaddress", MySqlDbType.VarChar).Value = GetSystemid();
            //        sqlCommand.Connection = sql;
            //        sqlCommand.CommandType = CommandType.StoredProcedure;


            //        sqlCommand.ExecuteNonQuery();


            //        sql.Close();
            //    }
            //}


            frmProxy proxy = new frmProxy();
            proxy.login = this;
            proxy.Show();
            this.Hide();
        }

        private async Task<string> getLogin(string username, string password)
        {
            using (var client = new HttpClient())
            {
                //var parameters = new Dictionary<string, string> { { "username", username }, { "password", password } };
                //var encodedContent = new FormUrlEncodedContent(parameters);
                List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> pair1 = new KeyValuePair<string, string>("username", username);
                KeyValuePair<string, string> pair2 = new KeyValuePair<string, string>("password", password);
                keyValues.Add(pair1);
                keyValues.Add(pair2);
                //IEnumerable<KeyValuePair<string, string>> keys = keyValues;


                var content = new FormUrlEncodedContent(keyValues);
                client.BaseAddress = new Uri("https://digimarkon.com/login/");
                //string url = @"https://digimarkon.com/login/getuserinfo";
                var responseTask = await client.PostAsync("getuserinfo", content);
                

                var result = responseTask.Content.ReadAsStringAsync().Result;
                return result;
            }
        }

        private string GetSystemid()
        {
            ManagementObjectCollection mbsList = null;
            ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
            mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject mo in mbsList)
            {
                id = mo["ProcessorID"].ToString();
            }

            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectCollection moc = mos.Get();
            string motherBoard = "";
            foreach (ManagementObject mo in moc)
            {
                motherBoard = (string)mo["SerialNumber"];
            }

            string myUniqueID = id + motherBoard;
            return myUniqueID;
        }
    }
}
