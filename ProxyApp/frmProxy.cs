using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace ProxyApp
{
    public partial class frmProxy : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        uint processId = 0;
        //string cs = @"server=localhost:8080;userid=root;password=;database=proxyapp";
        string cs = @"server=166.62.27.144;userid=digimarkonUser;password=XIE9Q#(i&III;database=digimarkon";
        //string connstring = @"Data Source=myServerAddress;Initial Catalog=myDataBase;Integrated Security=SSPI;User ID=myDomain\myUsername;Password=myPassword;";
        string connstring = @"Data Source=DESKTOP-AH7HLNK;Initial Catalog=Proxyapp;Integrated Security=True";
        public List<string> lstUserAgents = new List<string>();
        List<string> lstURLs = new List<string>();
        public string iptype = ConfigurationManager.AppSettings["iptype"].ToString();
        public string isManual = "manual";
        public List<int> exceptionNumbers = new List<int>();
        string ipaddress = "";
        int port = 0;
        string url = "";
        int randomnumber = 0;
        string result = "";
        List<string> lstexception = new List<string>();
        List<string> lstCountry = new List<string>();
        string countrytext = "";
        bool isStopCalled = false;
        bool isbackgroundcompleted = false;
        string currentMessage = "";
        string currentDownloadstring = "";
        Thread thread;
        bool islastvalue = false;
        public frmLogin login;

        string usernamesql = "";
        string passwordsql = "";
        string ipaddresssql = "";
        string loginmethodsql = "";
        int portsql = 0;

        public void AddCountry()
        {
            lstCountry.Add("United Kingdom");
            lstCountry.Add("United States");
            lstCountry.Add("Canada");
            lstCountry.Add("Afghanistan");
            lstCountry.Add("Albania");
            lstCountry.Add("Algeria ");
            lstCountry.Add("Argentina");
            lstCountry.Add("Armenia");
            lstCountry.Add("Aruba");
            lstCountry.Add("Australia");
            lstCountry.Add("Austria");
            lstCountry.Add("Azerbaijan");
            lstCountry.Add("Bahamas");
            lstCountry.Add("Bahrain");
            lstCountry.Add("Bangladesh");
            lstCountry.Add("Belarus");
            lstCountry.Add("Belgium");
            lstCountry.Add("Bosnia and Herzegovina");
            lstCountry.Add("Brazil");
            lstCountry.Add("British Virgin Islands");
            lstCountry.Add("Brunei");
            lstCountry.Add("Bulgaria");
            lstCountry.Add("Cambodia");
            lstCountry.Add("Cameroon");
            lstCountry.Add("Chile");
            lstCountry.Add("China");
            lstCountry.Add("Colombia");
            lstCountry.Add("Costa Rica");
            lstCountry.Add("Croatia");
            lstCountry.Add("Cuba");
            lstCountry.Add("Cyprus");
            lstCountry.Add("Czechia");
            lstCountry.Add("Egypt");
            lstCountry.Add("Finland");
            lstCountry.Add("France");
            lstCountry.Add("Germany");
            lstCountry.Add("Greece");
            lstCountry.Add("Hashemite Kingdom of Jordan");
            lstCountry.Add("Hong Kong");
            lstCountry.Add("Hungary");
            lstCountry.Add("India");
            lstCountry.Add("Indonesia");
            lstCountry.Add("Iran");
            lstCountry.Add("Iraq");
            lstCountry.Add("Ireland");
            lstCountry.Add("Italy");
            lstCountry.Add("Japan");
            lstCountry.Add("Kazakhstan");
            lstCountry.Add("Kosovo");
            lstCountry.Add("Kuwait");
            lstCountry.Add("Luxembourg");
            lstCountry.Add("Malaysia");
            lstCountry.Add("Mauritius");
            lstCountry.Add("Mexico");
            lstCountry.Add("Morocco");
            lstCountry.Add("Netherlands");
            lstCountry.Add("New Zealand");
            lstCountry.Add("Norway");
            lstCountry.Add("Oman");
            lstCountry.Add("Pakistan");
            lstCountry.Add("Palestine");
            lstCountry.Add("Panama");
            lstCountry.Add("Philippines");
            lstCountry.Add("Poland");
            lstCountry.Add("Portugal");
            lstCountry.Add("Qatar");
            lstCountry.Add("Romania");
            lstCountry.Add("Russia");
            lstCountry.Add("Saudi Arabia");
            lstCountry.Add("Singapore");
            lstCountry.Add("Slovakia");
            lstCountry.Add("South Africa");
            lstCountry.Add("South Korea");
            lstCountry.Add("Spain");
            lstCountry.Add("Sri Lanka");
            lstCountry.Add("Sweden");
            lstCountry.Add("Switzerland");
            lstCountry.Add("Syria");
            lstCountry.Add("Taiwan");
            lstCountry.Add("Tajikistan");
            lstCountry.Add("Thailand");
            lstCountry.Add("Trinidad and Tobago");
            lstCountry.Add("Tunisia");
            lstCountry.Add("Turkey");
            lstCountry.Add("Ukraine");
            lstCountry.Add("United Arab Emirates");
            lstCountry.Add("Uzbekistan");
            lstCountry.Add("Venezuela");
            lstCountry.Add("Vietnam");
            lstCountry.Add("Zambia");
            
        }

        public void AddCountryToCombo()
        {
            cmbCountry.Items.Add("UnitedKingdom");
            cmbCountry.Items.Add("UnitedStates");
            cmbCountry.Items.Add("Canada");
            cmbCountry.Items.Add("Afghanistan");
            cmbCountry.Items.Add("Albania");
            cmbCountry.Items.Add("Algeria ");
            cmbCountry.Items.Add("Argentina");
            cmbCountry.Items.Add("Armenia");
            cmbCountry.Items.Add("Aruba");
            cmbCountry.Items.Add("Australia");
            cmbCountry.Items.Add("Austria");
            cmbCountry.Items.Add("Azerbaijan");
            cmbCountry.Items.Add("Bahamas");
            cmbCountry.Items.Add("Bahrain");
            cmbCountry.Items.Add("Bangladesh");
            cmbCountry.Items.Add("Belarus");
            cmbCountry.Items.Add("Belgium");
            cmbCountry.Items.Add("Bosnia and Herzegovina");
            cmbCountry.Items.Add("Brazil");
            cmbCountry.Items.Add("British Virgin Islands");
            cmbCountry.Items.Add("Brunei");
            cmbCountry.Items.Add("Bulgaria");
            cmbCountry.Items.Add("Cambodia");
            cmbCountry.Items.Add("Cameroon");
            cmbCountry.Items.Add("Chile");
            cmbCountry.Items.Add("China");
            cmbCountry.Items.Add("Colombia");
            cmbCountry.Items.Add("Costa Rica");
            cmbCountry.Items.Add("Croatia");
            cmbCountry.Items.Add("Cuba");
            cmbCountry.Items.Add("Cyprus");
            cmbCountry.Items.Add("Czechia");
            cmbCountry.Items.Add("Egypt");
            cmbCountry.Items.Add("Finland");
            cmbCountry.Items.Add("France");
            cmbCountry.Items.Add("Germany");
            cmbCountry.Items.Add("Greece");
            cmbCountry.Items.Add("Hashemite Kingdom of Jordan");
            cmbCountry.Items.Add("Hong Kong");
            cmbCountry.Items.Add("Hungary");
            cmbCountry.Items.Add("India");
            cmbCountry.Items.Add("Indonesia");
            cmbCountry.Items.Add("Iran");
            cmbCountry.Items.Add("Iraq");
            cmbCountry.Items.Add("Ireland");
            cmbCountry.Items.Add("Italy");
            cmbCountry.Items.Add("Japan");
            cmbCountry.Items.Add("Kazakhstan");
            cmbCountry.Items.Add("Kosovo");
            cmbCountry.Items.Add("Kuwait");
            cmbCountry.Items.Add("Luxembourg");
            cmbCountry.Items.Add("Malaysia");
            cmbCountry.Items.Add("Mauritius");
            cmbCountry.Items.Add("Mexico");
            cmbCountry.Items.Add("Morocco");
            cmbCountry.Items.Add("Netherlands");
            cmbCountry.Items.Add("New Zealand");
            cmbCountry.Items.Add("Norway");
            cmbCountry.Items.Add("Oman");
            cmbCountry.Items.Add("Pakistan");
            cmbCountry.Items.Add("Palestine");
            cmbCountry.Items.Add("Panama");
            cmbCountry.Items.Add("Philippines");
            cmbCountry.Items.Add("Poland");
            cmbCountry.Items.Add("Portugal");
            cmbCountry.Items.Add("Qatar");
            cmbCountry.Items.Add("Romania");
            cmbCountry.Items.Add("Russia");
            cmbCountry.Items.Add("Saudi Arabia");
            cmbCountry.Items.Add("Singapore");
            cmbCountry.Items.Add("Slovakia");
            cmbCountry.Items.Add("South Africa");
            cmbCountry.Items.Add("South Korea");
            cmbCountry.Items.Add("Spain");
            cmbCountry.Items.Add("Sri Lanka");
            cmbCountry.Items.Add("Sweden");
            cmbCountry.Items.Add("Switzerland");
            cmbCountry.Items.Add("Syria");
            cmbCountry.Items.Add("Taiwan");
            cmbCountry.Items.Add("Tajikistan");
            cmbCountry.Items.Add("Thailand");
            cmbCountry.Items.Add("Trinidad and Tobago");
            cmbCountry.Items.Add("Tunisia");
            cmbCountry.Items.Add("Turkey");
            cmbCountry.Items.Add("Ukraine");
            cmbCountry.Items.Add("United Arab Emirates");
            cmbCountry.Items.Add("Uzbekistan");
            cmbCountry.Items.Add("Venezuela");
            cmbCountry.Items.Add("Vietnam");
            cmbCountry.Items.Add("Zambia");

        }


        public frmProxy()
        {
            InitializeComponent();

            AddCountry();
            AddCountryToCombo();
            //cmbCountry.DataSource = lstCountry;
            //cmbCountry.Items.AddRange(lstCountry.ToArray());
            //cmbCountry.SelectedIndex = -1;
            
            //backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            //backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
            //backgroundWorker1.WorkerSupportsCancellation = true;
            string selection = ConfigurationManager.AppSettings["selectiontype"].ToString();
            if(selection.ToLower() == "manual")
            {
                isManual = "manual";
                rdoManualip.Checked = true;
                rdoAPI.Checked = false;
                rdoExcel.Checked = false;
            }
            else if(selection.ToLower() == "api")
            {
                isManual = "api";
                rdoManualip.Checked = false;
                rdoAPI.Checked = true;
                rdoExcel.Checked = false;
            }
            else if (selection.ToLower() == "excel")
            {
                isManual = "excel";
                rdoManualip.Checked = false;
                rdoAPI.Checked = false;
                rdoExcel.Checked = true;
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //isbackgroundcompleted = true;
            //if(lstexception.Count > 0)
            //{
            //    lstRunningIP.Items.Add("Error" + lstexception[0]);
            //}
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //StartClicked();
        }

        private void frmProxy_Load(object sender, EventArgs e)
        {
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "useragents.txt");
            int counter = 0;
            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "useragents.txt"));
            while ((line = file.ReadLine()) != null)
            {
                lstUserAgents.Add(line);
                counter++;
            }

            file.Close();
            DataTable dt = new DataTable();
            //using (MySqlConnection sql = new MySqlConnection())
            //{
            //    sql.ConnectionString = cs;
            //    if (sql.State == ConnectionState.Closed)
            //        sql.Open();
            //    MySqlCommand sqlCommand = new MySqlCommand();
            //    sqlCommand.CommandText = "Select * from AppInfo";
            //    sqlCommand.Connection = sql;
            //    sqlCommand.CommandType = CommandType.Text;

            //    MySqlDataAdapter sqlData = new MySqlDataAdapter();
            //    sqlData.SelectCommand = sqlCommand;
            //    sqlData.Fill(dt);

            //    sql.Close();
            //    if (dt.Rows.Count > 0)
            //    {
            //        usernamesql = dt.Rows[0]["usernameapi"].ToString();
            //        passwordsql = dt.Rows[0]["passwordapi"].ToString();
            //        ipaddresssql = dt.Rows[0]["ipaddressapi"].ToString();
            //        loginmethodsql = dt.Rows[0]["loginmethod"].ToString();
            //        portsql = Convert.ToInt32(dt.Rows[0]["portapi"].ToString());
            //    }
            //}
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://digimarkon.com/login/");
                var responseTask = client.GetAsync("appinfo");
                responseTask.Wait();

                var result = responseTask.Result;
                
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var resultdata = readTask.Result;
                    var data = JsonConvert.DeserializeObject<dynamic>(resultdata); 
                    if(data.Message.ToString() == "Data Found")
                    {
                        usernamesql = data.Result.usernameapi.ToString();
                        passwordsql = data.Result.passwordapi.ToString();
                        ipaddresssql = data.Result.ipaddressapi.ToString();
                        loginmethodsql = data.Result.loginmethod.ToString();
                        portsql = Convert.ToInt32(data.Result.portapi.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Default parameter Unsuccessful!");
                    }
                }
            }




                //string result = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "useragents.txt"));
            }

        private static string GetInstanceName()
        {
            string returnvalue = "not found";
            //Checks bandwidth usage for CUPC.exe..Change it with your application Name
            string applicationName = "ProxyApp";
            PerformanceCounterCategory[] Array = PerformanceCounterCategory.GetCategories();
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i].CategoryName.Contains(".NET CLR Networking"))
                    foreach (var item in Array[i].GetInstanceNames())
                    {
                        if (item.ToLower().Contains(applicationName.ToString().ToLower()))
                            returnvalue = item;

                    }

            }
            return returnvalue;
        }

        private void StartClicked()
        {
            try
            {

                if (isManual == "manual")
                {
                    //txtURL.Text = @"https://www.seomoz.org";
                    

                    Proxyrequest proxyrequest = new Proxyrequest();
                    result = proxyrequest.SendURLRequest(ipaddress, port, lstUserAgents[randomnumber], url);
                    Invoke(new Action(() => {
                    }));

                    this.Invoke((MethodInvoker)(() => lstRunningIP.Items.Add(ipaddress + ":" + port.ToString() + " ran successfully.....")));
                    txtdownloadstring.SetPropertyThreadSafe(() => txtdownloadstring.Text, result);
                }
                else if(isManual == "api")
                {
                    Proxyrequest proxyrequest = new Proxyrequest();
                    ipaddress = ipaddresssql; //ConfigurationManager.AppSettings["ipaddressapi"].ToString();
                    port = portsql; //Convert.ToInt32(ConfigurationManager.AppSettings["portapi"].ToString());
                    string usernameapi = usernamesql; //ConfigurationManager.AppSettings["usernameapi"].ToString();
                    string passwordapi = passwordsql; //ConfigurationManager.AppSettings["passwordapi"].ToString();
                    
                    passwordapi = passwordapi + "_country-" + countrytext;
                    
                    result = proxyrequest.SendURLRequest(ipaddress, port, lstUserAgents[randomnumber], url, usernameapi, passwordapi);

                    //Invoke(new Action(() => {
                    //}));

                    this.currentMessage = ipaddress + ":" + port.ToString() + " ran successfully.....";
                    this.currentDownloadstring = result;
                    if (result != "")
                    {
                        thread.Abort();
                    }

                    //this.Invoke((MethodInvoker)(() => lstRunningIP.Items.Add(ipaddress + ":" + port.ToString() + " ran successfully.....")));
                    //txtdownloadstring.SetPropertyThreadSafe(() => txtdownloadstring.Text, result);
                    
                }
                else if(isManual == "excel")
                {
                    Proxyrequest proxyrequest = new Proxyrequest();
                    ipaddress = ipaddresssql; //ConfigurationManager.AppSettings["ipaddressapi"].ToString();
                    port = portsql; //Convert.ToInt32(ConfigurationManager.AppSettings["portapi"].ToString());
                    string usernameapi = usernamesql; //ConfigurationManager.AppSettings["usernameapi"].ToString();
                    string passwordapi = passwordsql; //ConfigurationManager.AppSettings["passwordapi"].ToString();
                    //if (cmbCountry.SelectedIndex > -1)
                    //{
                        //_country-UnitedStates
                        passwordapi = passwordapi + "_country-" + countrytext;
                    //}
                    result = proxyrequest.SendURLRequest(ipaddress, port, lstUserAgents[randomnumber], url, usernameapi, passwordapi);
                    //Invoke(new Action(() => {
                    //}));

                    //this.Invoke((MethodInvoker)(() => lstRunningIP.Items.Add(ipaddress + ":" + port.ToString() + " ran successfully.....")));
                    //txtdownloadstring.SetPropertyThreadSafe(() => txtdownloadstring.Text, result);
                    this.currentMessage = ipaddress + ":" + port.ToString() + " ran successfully.....";
                    this.currentDownloadstring = result;
                    if (result != "")
                    {
                        thread.Abort();
                    }
                }
            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("Thread was being aborted."))
                {
                    
                }
                else
                {
                    lstexception.Add(ex.Message);
                }
                

            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (isManual == "manual")
                {
                    lstexception.Clear();
                    url = txtURL.Text;
                    if(url == "")
                    {
                        url = ConfigurationManager.AppSettings["url"].ToString();
                    }
                    ipaddress = txtIPAddress.Text.Trim();
                    port = Convert.ToInt32(txtPort.Text);
                    randomnumber = GenerateRandomNumber();
                    lstRunningIP.Items.Add(ipaddress + ":" + port.ToString() + " running.....");
                    result = "";
                    txtdownloadstring.Clear();
                    //backgroundWorker1.RunWorkerAsync();
                }
                else if(isManual == "api")
                {
                    int loopvalue = 1;
                    if(txtLoopvalue.Text != "")
                    {
                        loopvalue = Convert.ToInt32(txtLoopvalue.Text);
                    }
                    for(int ij = 0; ij < loopvalue; ij++)
                    {
                        
                        //while (backgroundWorker1.IsBusy && !isbackgroundcompleted)
                        //{
                        //    Thread.Sleep(3000);
                        //}
                        //isbackgroundcompleted = false;
                        
                        while (thread != null && thread.IsAlive)
                        {
                            Thread.Sleep(3000);
                        }
                        if (currentMessage != "")
                            lstRunningIP.Items.Add(currentMessage);
                        if (currentDownloadstring != "")
                            txtdownloadstring.Text = currentDownloadstring;
                        if (isStopCalled)
                        {
                            isStopCalled = false;
                            break;
                        }
                        if(ij == loopvalue - 1)
                        {
                            islastvalue = true;
                        }
                        lstexception.Clear();
                        url = txtURL.Text;
                        if (url == "")
                        {
                            url = ConfigurationManager.AppSettings["url"].ToString();
                        }
                        txtPort.Clear();
                        randomnumber = GenerateRandomNumber();
                        ipaddress = ipaddresssql; //ConfigurationManager.AppSettings["ipaddressapi"].ToString();
                        port = portsql;// Convert.ToInt32(ConfigurationManager.AppSettings["portapi"].ToString());
                        lstRunningIP.Items.Add(ipaddress + ":" + port.ToString() + " started.....");
                        result = "";
                        //txtdownloadstring.Clear();
                        if (cmbCountry.SelectedItem != null)
                            countrytext = cmbCountry.SelectedItem.ToString();
                        //backgroundWorker1.RunWorkerAsync();

                        thread = new Thread(new ThreadStart(StartClicked));
                        thread.IsBackground = true;
                        thread.Start();

                        if(!islastvalue)
                            thread.Join();

                        if (txtTimedelay.Text != "")
                        {
                            //Thread.Sleep(10000);
                            Thread.Sleep(Convert.ToInt32(txtTimedelay.Text) * 1000);
                        }
                        //else
                        //{
                            
                        //}
                    }

                    if (islastvalue)
                    {
                        lstRunningIP.Items.Add(currentMessage);
                        lstRunningIP.Items.Add("...... Finished ......");
                        txtdownloadstring.Text = currentDownloadstring;
                        islastvalue = false;
                        currentMessage = "";
                        currentDownloadstring = "";
                    }

                }
                else if(isManual == "excel")
                {
                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestIps.xlsx"));
                    Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkbook.Sheets[1];
                    Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

                    if (xlApp != null)
                    {
                        if (xlWorkbook != null)
                        {
                            
                                GetWindowThreadProcessId(new IntPtr(xlApp.Hwnd), out processId);

                                
                        }
                    }

                    var colcount = xlRange.Columns.Count;
                    var rowcount = xlRange.Rows.Count;
                    int index = -1;
                    int countryindex = -1;
                    for (int i = 1; i <= rowcount; i++)
                    {
                        if(i == 1)
                        {
                            string colname = "Campaign URL";
                            string countryname = "Country";
                            for (int j = 1; j <= colcount; j++)
                            {
                                if(xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                                {
                                    if(xlRange.Cells[i, j].Value2 == colname)
                                    {
                                        index = j;
                                        
                                    }
                                    if (xlRange.Cells[i, j].Value2 == countryname)
                                    {
                                        countryindex = j;

                                    }
                                }
                            }
                        }
                        else
                        {
                            if (xlRange.Cells[i, index] != null && xlRange.Cells[i, index].Value2 != null)
                            {
                                if(xlRange.Cells[i, countryindex] != null && xlRange.Cells[i, countryindex].Value2 != null)
                                {
                                    lstURLs.Add(xlRange.Cells[i, index].Value2 + "~" + xlRange.Cells[i, countryindex].Value2);
                                }
                                else
                                {
                                    lstURLs.Add(xlRange.Cells[i, index].Value2);
                                }
                                
                            }
                        }
                        
                    }



                    //rule of thumb for releasing com objects:
                    //  never use two dots, all COM objects must be referenced and released individually
                    //  ex: [somthing].[something].[something] is bad

                    //release com objects to fully kill excel process from running in the background


                    //Marshal.ReleaseComObject(xlRange);
                    //Marshal.ReleaseComObject(xlWorksheet);


                    ////close and release
                    //xlWorkbook.Close();
                    //Marshal.ReleaseComObject(xlWorkbook);

                    ////quit and release
                    //xlApp.Quit();
                    //Marshal.ReleaseComObject(xlApp);
                    //xlRange = null;
                    //xlWorksheet = null;
                    //xlWorkbook = null;
                    //xlApp = null;

                    //GC.Collect();
                    //GC.WaitForPendingFinalizers();
                    //GC.Collect();
                    //GC.WaitForPendingFinalizers();

                    if (xlApp != null)
                    {
                        if (xlWorkbook != null)
                        {
                            
                            xlWorkbook.Close(true, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestIps.xlsx"), null);
                            //xlWorkbook.Close();
                            xlApp.Quit();

                            Marshal.ReleaseComObject(xlRange);
                            Marshal.ReleaseComObject(xlWorksheet);


                            //close and release
                            
                            Marshal.ReleaseComObject(xlWorkbook);

                            //quit and release
                            
                            Marshal.ReleaseComObject(xlApp);
                            xlRange = null;
                            xlWorksheet = null;
                            xlWorkbook = null;
                            xlApp = null;

                        }
                    }

                    try
                    {
                        if (processId != 0)
                        {
                            Process excelProcess = Process.GetProcessById((int)processId);
                            //excelProcess.CloseMainWindow();
                            //excelProcess.Refresh();
                            //excelProcess.Close();
                            //excelProcess.Dispose();
                            excelProcess.Kill();
                        }
                    }
                    catch
                    {
                        // Process was already killed
                    }

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();



                    int ij = 0;
                    int loopvalue = lstURLs.Count - 1;
                    foreach (var value in lstURLs)
                    {
                        //while (backgroundWorker1.IsBusy && !isbackgroundcompleted)
                        //{
                        //    Thread.Sleep(3000);
                        //}
                        //isbackgroundcompleted = false;
                        
                        while (thread != null && thread.IsAlive)
                        {
                            Thread.Sleep(3000);
                        }
                        if (currentMessage != "")
                            lstRunningIP.Items.Add(currentMessage);
                        if (currentDownloadstring != "")
                            txtdownloadstring.Text = currentDownloadstring;
                        if (isStopCalled)
                        {
                            isStopCalled = false;
                            break;
                        }
                        if (ij == loopvalue - 1)
                        {
                            islastvalue = true;
                        }
                        lstexception.Clear();
                        string[] split = value.Split('~');
                        if(split.Length == 2 && split[1].Trim() != "")
                        {
                            //string passwordtemp = ConfigurationManager.AppSettings["passwordapi"].ToString();
                            countrytext = split[1].Trim();
                        }
                        else
                        {
                            if (cmbCountry.SelectedItem != null)
                                countrytext = cmbCountry.SelectedItem.ToString();
                        }
                        txtURL.Text = split[0];
                        url = txtURL.Text;
                        if (url == "")
                        {
                            url = ConfigurationManager.AppSettings["url"].ToString();
                        }
                        txtPort.Clear();
                        randomnumber = GenerateRandomNumber();
                        ipaddress = ipaddresssql; //ConfigurationManager.AppSettings["ipaddressapi"].ToString();
                        port = portsql; //Convert.ToInt32(ConfigurationManager.AppSettings["portapi"].ToString());
                        lstRunningIP.Items.Add(ipaddress + ":" + port.ToString() + " started.....");
                        result = "";
                        //txtdownloadstring.Clear();
                        ij++;
                        //backgroundWorker1.RunWorkerAsync();
                        thread = new Thread(new ThreadStart(StartClicked));
                        thread.IsBackground = true;
                        thread.Start();

                        if (!islastvalue)
                            thread.Join();
                        if (txtTimedelay.Text != "")
                        {
                            //Thread.Sleep(5000);
                            Thread.Sleep(Convert.ToInt32(txtTimedelay.Text) * 1000);
                        }
                        //else
                        //{
                            
                        //}

                    }

                    if (islastvalue)
                    {
                        lstRunningIP.Items.Add(currentMessage);
                        lstRunningIP.Items.Add("...... Finished ......");
                        txtdownloadstring.Text = currentDownloadstring;
                        islastvalue = false;
                        currentMessage = "";
                        currentDownloadstring = "";
                    }
                }
            }
            catch(Exception ex)
            {
                
            }
            
            
            
        }

        private int GenerateRandomNumber()
        {
            int min = 0;
            int max = lstUserAgents.Count - 1;
            var exclude = new HashSet<int>(exceptionNumbers);
            var range = Enumerable.Range(min, max).Where(i => !exclude.Contains(i));

            var rand = new System.Random();
            int index = rand.Next(min, max - exclude.Count);
            return range.ElementAt(index);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isStopCalled = true;
            exceptionNumbers.Clear();
            currentDownloadstring = "";
            currentMessage = "";
            //backgroundWorker1.CancelAsync();
            thread.Abort();
            islastvalue = false;
            lstexception.Clear();
            lstRunningIP.Items.Add("Stopped ............");
            
        }

        private void choosetype_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoManualip.Checked)
            {
                isManual = "manual";
            }
            else if(rdoAPI.Checked)
            {
                isManual = "api";
            }
            else if (rdoExcel.Checked)
            {
                isManual = "excel";
            }
        }

        private void AddUserAgents()
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstRunningIP.Items.Clear();
            txtdownloadstring.Clear();
            exceptionNumbers.Clear();
            txtIPAddress.Clear();
            txtPort.Clear();
            islastvalue = false;
            currentDownloadstring = "";
            currentMessage = "";
            lstexception.Clear();
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmProxy_FormClosed(object sender, FormClosedEventArgs e)
        {
            login.Close();
            login.Dispose();
        }
    }
}
