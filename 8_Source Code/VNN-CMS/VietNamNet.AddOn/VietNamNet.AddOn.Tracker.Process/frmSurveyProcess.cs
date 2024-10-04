using System;
using System.Collections.Generic;
using System.IO;
using System.Transactions;
using System.Windows.Forms;
using System.Xml;
using log4net;
using SubSonic;
using VietNamNet.AddOn.Tracker.Components;
using VietNamNet.AddOn.Tracker.Core.CMS;
using VietNamNet.AddOn.Tracker.Process.Commponents;

namespace VietNamNet.AddOn.Tracker.Process
{
    public partial class frmSurveyProcess : Form
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

        protected ILog iLog = LogManager.GetLogger(Constants.ServiceName.Survey);
        #endregion

        #region Members
        public frmSurveyProcess()
        {
            log4net.Config.DOMConfigurator.Configure();
            InitializeComponent();
        }
        private void frmSurveyProcess_Load(object sender, EventArgs e)
        {
            txtFileName.Text = Configurations.Survey.LogFilePath();
            SetupEnvironment();
            if (Configurations.Forms.AutoClose())
            {
                this.Dispose();
            } 
        }
        private void cmdRead_Click(object sender, EventArgs e)
        {
            runProcess();
        }
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            SetupEnvironment();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                
                runProcess();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex=" + ex.Message);
            }
        }

        #endregion

        #region Private Methods
        private void runProcess()
        {
            _entries.Clear();

            // file name đọc từ config
            ReadLogfile(txtFileName.Text);
            UpdateLogProcess();

            this.Dispose();
        }
        private void SetupEnvironment()
        {
            txtMessage.Text = "";
           
            // gọi vào db lấy ngày cập nhật gần nhất
            DateTime d = new Select(SurveyResult.Columns.ModifiOn).Top("1").From(SurveyResult.Schema.Name).OrderDesc(SurveyResult.Columns.ModifiOn).ExecuteScalar<DateTime>();
            //MessageBox.Show("Thời gian lấy dữ liệu lần cuối: "  + d.ToString());

            if (d <= DateTime.Now.AddYears(-1))
            {
                _lastUpdate = DateTime.Now.AddDays(-7) ;
            }
            else
            {
                _lastUpdate = d;
            }

            _entries.Clear();

            try
            {
                timer1.Enabled = true;
                //timer1.Interval = 2 * 60 * 1000; // get interval from config file
                timer1.Interval = Configurations.Survey.TrackerInterval() * 1000;
                runProcess();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex=" + ex.Message);
            }
        }

        private void ReadLogfile(string filePath)
        {
            c = 0;
            DateTime d = _lastUpdate;

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
                    iLog.Info("Read file: " + FileName.Substring(FileName.IndexOf("log4net\\")) + "\r\n"); 
                    txtMessage.Text = "Read file: " + FileName.Substring(FileName.IndexOf("log4net\\")) + "\r\n" + txtMessage.Text;
                }
                d = d.AddHours(1);
            }
            iLog.Info("Number of file read: " + c.ToString() + "\r\n"); 
            txtMessage.Text = "Number of file read: " + c.ToString() + "\r\n" + txtMessage.Text;
        }
        private void UpdateLogProcess()
        {
            if (_entries.Count > 0)
            {
                string oId;
                int countUpdate = 0; 

                try
                {
                    //Update to Database
                    using (SharedDbConnectionScope sharedConnectionScope = new SharedDbConnectionScope())
                    {
                        using (TransactionScope ts = new TransactionScope())
                        {

                            foreach (LogEntry log in _entries)
                            {
                                if (log.TimeStamp.CompareTo(_lastUpdate) > 0) // Nếu ngày lớn hơn lần cuối cập thì update vào DB
                                {
                                    oId = log.Message.Substring(log.Message.LastIndexOf("itemId==") + 8, log.Message.IndexOf("]", log.Message.IndexOf("itemId==") + 8) - (log.Message.IndexOf("itemId==") + 8));

                                    foreach (String i in oId.Split(','))
                                    {
                                        
                                        SurveyResult result = new SurveyResult();
                                        result.SurveyOptionId = int.Parse(i);
                                        result.Notes = log.Message; 
                                        result.IsDeleted = false; result.IsActive = true;
                                        result.CreatedOn = log.TimeStamp; result.CreatedBy = "1";
                                        result.ModifiOn = log.TimeStamp; result.ModifiedBy = "1";
                                        result.Save();
                                    }
                                    countUpdate++;
                                    _lastUpdate = log.TimeStamp;
                                } 

                            }
                            ts.Complete();
                            ts.Dispose();


                        }
                    }
                    iLog.Info("Last update success at: " + DateTime.Now + "; log updated: " + countUpdate.ToString() + "\r\n"); 
                    txtMessage.Text = "Last update success at: " + DateTime.Now + "; log updated: " + countUpdate.ToString() + "\r\n" + txtMessage.Text;
                     
                    //txtLastUpdate.Text = _lastUpdate.ToString();
                }
                catch (Exception ex)
                {
                    iLog.Info("Last update success at: " + DateTime.Now + "; log updated: " + countUpdate.ToString() + "\r\n"); 
                    txtMessage.Text = "Last update fail at: " + DateTime.Now.ToString() + ";ex=" + ex.Message + "\r\n" + txtMessage.Text;
                }
            }
        }

        #endregion

     
    }
}