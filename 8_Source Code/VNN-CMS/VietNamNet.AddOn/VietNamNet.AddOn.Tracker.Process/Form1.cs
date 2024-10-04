using System;
using System.Collections.Generic;
using System.IO;
using System.Transactions;
using System.Windows.Forms;
using System.Xml;
using SubSonic;
using VietNamNet.AddOn.Tracker.Core;
using VietNamNet.AddOn.Tracker.Core.CMS;
using VietNamNet.AddOn.Tracker.Process.Commponents;

namespace VietNamNet.AddOn.Tracker.Process
{
    public partial class Form1 : Form
    {
        #region Members

        private int c = 0;
        private string _fileName = string.Empty;
        private string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                //RecentFileList.InsertFile(value);
            }
        }

        private List<LogEntry> _entries = new List<LogEntry>();
        public List<LogEntry> Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }

        private DateTime _lastUpdate;
        #endregion

        #region Public Methods
        public Form1()
        {
            InitializeComponent();

        }
        #endregion

        #region Event Handlers
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SetupEnvironment();
            }
            catch (Exception ex)
            {
                txtMessage.Text = "Exception at: " + DateTime.Now.ToString() + ";ex=" + ex.Message + "\r\n" + txtMessage.Text;
            }
        }
        private void Read_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
           
        }
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                _entries.Clear();
                OpenFile(txtFileName.Text); Update2DB();
            }
            catch (Exception ex)
            {
                txtMessage.Text = "Exception at: " + DateTime.Now.ToString() + ";ex=" + ex.Message + "\r\n" + txtMessage.Text;
            }
        }
        #endregion

        #region Private Methods
        private void SetupEnvironment()
        {
            txtMessage.Text = "";

            // gọi vào db lấy ngày cập nhật gần nhất
            DateTime d = new Select(SurveyResult.Columns.ModifiOn).Top("1").From(SurveyResult.Schema.Name).OrderDesc(SurveyResult.Columns.ModifiOn).ExecuteScalar<DateTime>();
            //MessageBox.Show("Thời gian lấy dữ liệu lần cuối: "  + d.ToString());

            if (d <= DateTime.Now.AddYears(-1))
            {
                txtLastUpdate.Text = DateTime.Now.AddDays(-7).ToString();
            } else
            {
                txtLastUpdate.Text = d.ToString();
            }

            _entries.Clear();

            try
            {
                timer1.Enabled = true;
                timer1.Interval = 2 * 60 * 1000; // get interval from config file
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex=" + ex.Message);
            }
        }

        private void OpenFile(string filePath)
        {
            c =0;
            DateTime d =  DateTime.Parse(txtLastUpdate.Text);

            while (d <= DateTime.Now)
            {
                FileName = string.Format(filePath, d.ToString("yyyyMMdd-HH"));

                List<LogEntry> le = LogFile.ReadFileBuffer(FileName);
                if (le.Count > 0)
                {
                    foreach (LogEntry e in le)
                    {
                        _entries.Add(e);
                    }
                    c++;
                    txtMessage.Text = "Number of file read: " + FileName.Substring(FileName.IndexOf("log4net\\")) + "\r\n" + txtMessage.Text;
                }
                d = d.AddHours(1);
            }

            txtMessage.Text = "Number of file read: " + c.ToString() + "\r\n" + txtMessage.Text ;
        }
        
        private void Clear()
        {
            //
            //txtLevel.Text = string.Empty;
            //txtTimeStamp.Text = string.Empty;
            //txtMachineName.Text = string.Empty;
            //txtThread.Text = string.Empty;
            //txtItem.Text = string.Empty;
            //txtHostName.Text = string.Empty;
            //txtUserName.Text = string.Empty;
            //txtApp.Text = string.Empty;
            //txtClass.Text = string.Empty;
            //txtMethod.Text = string.Empty;
            //txtLine.Text = string.Empty;
            //txtfile.Text = string.Empty;
            //txtMessage.Text = string.Empty;
            //txtThrowable.Text = string.Empty;
        }

        //private void LoadFile()
        //{
        //    //txtFileName.Text = FileName;

        //    listView1.Tag = null;

        //    DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        //    string sXml = string.Empty;
        //    string sBuffer = string.Empty;
        //    int iIndex = 1;

        //    Clear();

        //    try
        //    {
        //        FileStream oFileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        //        StreamReader oStreamReader = new StreamReader(oFileStream);
        //        sBuffer = string.Format("<root>{0}</root>", oStreamReader.ReadToEnd());
        //        oStreamReader.Close();
        //        oFileStream.Close();

        //        #region Read File Buffer
        //        ////////////////////////////////////////////////////////////////////////////////
        //        StringReader oStringReader = new StringReader(sBuffer);
        //        XmlTextReader oXmlTextReader = new XmlTextReader(oStringReader);
        //        oXmlTextReader.Namespaces = false;
        //        while (oXmlTextReader.Read())
        //        {
        //            if ((oXmlTextReader.NodeType == XmlNodeType.Element) && (oXmlTextReader.Name == "log4j:event"))
        //            {
        //                LogEntry logentry = new LogEntry();

        //                logentry.Item = iIndex;

        //                double dSeconds = Convert.ToDouble(oXmlTextReader.GetAttribute("timestamp"));
        //                logentry.TimeStamp = dt.AddMilliseconds(dSeconds).ToLocalTime();
        //                //logentry.TimeStamp = DateTime.Parse(oXmlTextReader.GetAttribute("timestamp"));
        //                logentry.Thread = oXmlTextReader.GetAttribute("thread");

        //                #region get level
        //                /*///////////////////////////////////////////////////////////////////////////////
        //                logentry.Level = oXmlTextReader.GetAttribute("level");
        //                switch (logentry.Level)
        //                {
        //                    case "ERROR":
        //                        {
        //                            logentry.Image = LogEntry.Images(LogEntry.IMAGE_TYPE.ERROR);
        //                            break;
        //                        }
        //                    case "INFO":
        //                        {
        //                            logentry.Image = LogEntry.Images(LogEntry.IMAGE_TYPE.INFO);
        //                            break;
        //                        }
        //                    case "DEBUG":
        //                        {
        //                            logentry.Image = LogEntry.Images(LogEntry.IMAGE_TYPE.DEBUG);
        //                            break;
        //                        }
        //                    case "WARN":
        //                        {
        //                            logentry.Image = LogEntry.Images(LogEntry.IMAGE_TYPE.WARN);
        //                            break;
        //                        }
        //                    case "FATAL":
        //                        {
        //                            logentry.Image = LogEntry.Images(LogEntry.IMAGE_TYPE.FATAL);
        //                            break;
        //                        }
        //                    default:
        //                        {
        //                            logentry.Image = LogEntry.Images(LogEntry.IMAGE_TYPE.CUSTOM);
        //                            break;
        //                        }
        //                }
        //                ///////////////////////////////////////////////////////////////////////////////*/
        //                #endregion

        //                #region read xml
        //                ////////////////////////////////////////////////////////////////////////////////
        //                while (oXmlTextReader.Read())
        //                {
        //                    if (oXmlTextReader.Name == "log4j:event")   // end element
        //                        break;
        //                    else
        //                    {
        //                        switch (oXmlTextReader.Name)
        //                        {
        //                            case ("log4j:message"):
        //                                {
        //                                    logentry.Message = oXmlTextReader.ReadString();
        //                                    break;
        //                                }
        //                            case ("log4j:data"):
        //                                {
        //                                    switch (oXmlTextReader.GetAttribute("name"))
        //                                    {
        //                                        case ("log4jmachinename"):
        //                                            {
        //                                                logentry.MachineName = oXmlTextReader.GetAttribute("value");
        //                                                break;
        //                                            }
        //                                        case ("log4net:HostName"):
        //                                            {
        //                                                logentry.HostName = oXmlTextReader.GetAttribute("value");
        //                                                break;
        //                                            }
        //                                        case ("log4net:UserName"):
        //                                            {
        //                                                logentry.UserName = oXmlTextReader.GetAttribute("value");
        //                                                break;
        //                                            }
        //                                        case ("log4japp"):
        //                                            {
        //                                                logentry.App = oXmlTextReader.GetAttribute("value");
        //                                                break;
        //                                            }
        //                                    }
        //                                    break;
        //                                }
        //                            case ("log4j:throwable"):
        //                                {
        //                                    logentry.Throwable = oXmlTextReader.ReadString();
        //                                    break;
        //                                }
        //                            case ("log4j:locationInfo"):
        //                                {
        //                                    logentry.Class = oXmlTextReader.GetAttribute("class");
        //                                    logentry.Method = oXmlTextReader.GetAttribute("method");
        //                                    logentry.File = oXmlTextReader.GetAttribute("file");
        //                                    logentry.Line = oXmlTextReader.GetAttribute("line");
        //                                    break;
        //                                }
        //                        }
        //                    }
        //                }
        //                ////////////////////////////////////////////////////////////////////////////////
        //                #endregion

        //                _entries.Add(logentry);
        //                iIndex++;

        //                #region Show Counts
        //                /*///////////////////////////////////////////////////////////////////////////////
        //                int ErrorCount =
        //                (
        //                    from entry in Entries
        //                    where entry.Level == "ERROR"
        //                    select entry
        //                ).Count();

        //                if (ErrorCount > 0)
        //                {
        //                    labelErrorCount.Content = string.Format("{0:#,#}  ", ErrorCount);
        //                    labelErrorCount.Visibility = Visibility.Visible;
        //                    imageError.Visibility = Visibility.Visible;
        //                }
        //                else
        //                {
        //                    labelErrorCount.Visibility = Visibility.Hidden;
        //                    imageError.Visibility = Visibility.Hidden;
        //                }

        //                int InfoCount = 
        //                (
        //                    from entry in Entries
        //                    where entry.Level == "INFO"
        //                    select entry
        //                ).Count();

        //                if (InfoCount > 0)
        //                {
        //                    labelInfoCount.Content = string.Format("{0:#,#}  ", InfoCount);
        //                    labelInfoCount.Visibility = Visibility.Visible;
        //                    imageInfo.Visibility = Visibility.Visible;
        //                }
        //                else
        //                {
        //                    labelInfoCount.Visibility = Visibility.Hidden;
        //                    imageInfo.Visibility = Visibility.Hidden;
        //                }

        //                int WarnCount =
        //                (
        //                    from entry in Entries
        //                    where entry.Level == "WARN"
        //                    select entry
        //                ).Count();

        //                if (WarnCount > 0)
        //                {
        //                    labelWarnCount.Content = string.Format("{0:#,#}  ", WarnCount);
        //                    labelWarnCount.Visibility = Visibility.Visible;
        //                    imageWarn.Visibility = Visibility.Visible;
        //                }
        //                else
        //                {
        //                    labelWarnCount.Visibility = Visibility.Hidden;
        //                    imageWarn.Visibility = Visibility.Hidden;
        //                }

        //                int DebugCount =
        //                (
        //                    from entry in Entries
        //                    where entry.Level == "DEBUG"
        //                    select entry
        //                ).Count();

        //                if (DebugCount > 0)
        //                {
        //                    labelDebugCount.Content = string.Format("{0:#,#}  ", DebugCount);
        //                    labelDebugCount.Visibility = Visibility.Visible;
        //                    imageDebug.Visibility = Visibility.Visible;
        //                }
        //                else
        //                {
        //                    labelDebugCount.Visibility = Visibility.Hidden;
        //                    labelDebugCount.Visibility = Visibility.Hidden;
        //                }
        //                ///////////////////////////////////////////////////////////////////////////////*/
        //                #endregion
        //            }
        //        }
        //        ////////////////////////////////////////////////////////////////////////////////
        //        #endregion
        //        c++;
        //        txtMessage.Text += "reading file: " + FileName + "\r\n";
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log bug tại đây
        //        //MessageBox.Show(ex.ToString());
        //    }
        //    //MessageBox.Show("count=" + _entries.Count.ToString());
            
        //}

        private void Update2DB()
        {
            if (_entries.Count > 0)
            {
                string oId;
                int countUpdate = 0;
                _lastUpdate = DateTime.Parse(txtLastUpdate.Text.Trim());
                
                try
                {
                    //Update to Database
                    //
                    using (SharedDbConnectionScope sharedConnectionScope = new SharedDbConnectionScope())
                    {
                        using (TransactionScope ts = new TransactionScope())
                        {

                            foreach (LogEntry log in _entries)
                            {
                                if (log.TimeStamp > _lastUpdate)
                                {
                                    oId = log.Message.Substring(log.Message.LastIndexOf("itemId==") + 8, log.Message.IndexOf("]", log.Message.IndexOf("itemId==") + 8) - (log.Message.IndexOf("itemId==") + 8));

                                    foreach (String i in oId.Split(','))
                                    {
                                        // Nếu ngày lớn hơn lần cuối cập thì update vào DB
                                        SurveyResult result = new SurveyResult();
                                        result.SurveyOptionId = int.Parse(i);
                                        result.Notes = "";
                                        result.IsDeleted = false; result.IsActive = true;
                                        result.CreatedOn = log.TimeStamp; result.CreatedBy = "1";
                                        result.ModifiOn = log.TimeStamp; result.ModifiedBy = "1";
                                        result.Save();
                                        
                                    }
                                    countUpdate++;
                                }

                            }
                            ts.Complete();
                            ts.Dispose();

                           
                        }
                    }
                    txtMessage.Text = "Last update success at: " + DateTime.Now + "; log updated: " + countUpdate.ToString() + "\r\n" + txtMessage.Text;
                    txtLastUpdate.Text = DateTime.Now.ToString();
                }
                catch (Exception ex)
                {
                    txtMessage.Text = "Last update fail at: " + DateTime.Now.ToString() + ";ex=" + ex.Message + "\r\n" + txtMessage.Text;
                }
            }
        }
        #endregion

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            SetupEnvironment();
        }

       
      

    }
}