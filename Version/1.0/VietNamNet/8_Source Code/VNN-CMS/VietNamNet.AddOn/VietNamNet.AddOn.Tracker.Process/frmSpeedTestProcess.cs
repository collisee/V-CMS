using System;
using System.Collections.Generic;
using System.IO;
using System.Transactions;
using System.Windows.Forms;
using System.Xml;
using log4net;
using SubSonic;
using VietNamNet.AddOn.Tracker.Components;
using VietNamNet.AddOn.Tracker.Core;
using VietNamNet.AddOn.Tracker.Core.CMS;
using VietNamNet.AddOn.Tracker.Process.Commponents;

namespace VietNamNet.AddOn.Tracker.Process
{
    public partial class frmSpeedTestProcess : Form
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

        private readonly ILog iLog = LogManager.GetLogger(Constants.ServiceName.Comment);
        //protected ILog iLog = LogManager.GetLogger("adsafsdf");
        #endregion

        #region Members
        public frmSpeedTestProcess()
        {
            log4net.Config.DOMConfigurator.Configure();
            InitializeComponent();
        }
        private void frmCommentProcess_Load(object sender, EventArgs e)
        {
            txtFileName.Text = Configurations.Comment.LogFilePath();
            SetupEnvironment();

            //MessageBox.Show("done ....");
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
        }
        private void SetupEnvironment()
        {
            txtMessage.Text = "";

            // gọi vào db lấy ngày cập nhật gần nhất
            DateTime d = new Select(ArticleComment.Columns.LastModifiedAt).Top("1").From(ArticleComment.Schema.Name).OrderDesc(ArticleComment.Columns.LastModifiedAt).ExecuteScalar<DateTime>();

            if (d <= DateTime.Now.AddYears(-1))
            {
                _lastUpdate = DateTime.Now.AddDays(-7);
            }
            else
            {
                _lastUpdate = d;
            }

            //txtLastUpdate.Text = _lastUpdate.ToString();
            
            _entries.Clear();

           
                timer1.Enabled = true;
                //timer1.Interval = 2 * 60 * 1000; // get interval from config file
                timer1.Interval = Configurations.Comment.TrackerInterval() * 1000;
                runProcess();
             
        }

        private void ReadLogfile(string filePath)
        {
            c = 0;
            DateTime d = _lastUpdate;

            while (d <= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddHours(1).Hour,0,0))
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
                //txtMessage.Text = "Read file: " + FileName.Substring(FileName.IndexOf("log4net\\")) + "\r\n" + txtMessage.Text;
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

                //try
                //{
                    //Update to Database
                    //
                    using (SharedDbConnectionScope sharedConnectionScope = new SharedDbConnectionScope())
                    {
                        using (TransactionScope ts = new TransactionScope())
                        {


                            foreach (LogEntry log in _entries)
                            {
                                if (log.TimeStamp.CompareTo(_lastUpdate) > 0) // Nếu ngày lớn hơn lần cuối cập thì update vào DB
                                {
                                    if (log.Message.IndexOf("[article:") >= 0 &&
                                         log.Message.IndexOf("[mail:") >= 0 &&
                                         log.Message.IndexOf("[phone:") >= 0 &&
                                         log.Message.IndexOf("[subject:") >= 0 &&
                                         log.Message.IndexOf("[message:") >= 0 &&
                                         log.Message.IndexOf("[name:") >= 0
                                        )
                                    {

                                        //string b = log.Message.Substring(log.Message.IndexOf("[article:")).Substring(log.Message.Substring(log.Message.IndexOf("[article:")).IndexOf(":") + 1, log.Message.Substring(log.Message.IndexOf("[article:")).IndexOf("]") - (log.Message.Substring(log.Message.IndexOf("[article:")).IndexOf(":") + 1));

                                        ArticleComment comment = new ArticleComment();

                                        comment.ArticleId = int.Parse(log.Message.Substring(log.Message.IndexOf("[article:")).Substring(log.Message.Substring(log.Message.IndexOf("[article:")).IndexOf(":") + 1, log.Message.Substring(log.Message.IndexOf("[article:")).IndexOf("]") - (log.Message.Substring(log.Message.IndexOf("[article:")).IndexOf(":") + 1)));
                                        comment.PId = 0;

                                        comment.Name = log.Message.Substring(log.Message.IndexOf("[name:")).Substring(log.Message.Substring(log.Message.IndexOf("[name:")).IndexOf(":") + 1, log.Message.Substring(log.Message.IndexOf("[name:")).IndexOf("]") - (log.Message.Substring(log.Message.IndexOf("[name:")).IndexOf(":") + 1)); // phân tích Name

                                        comment.Phone = log.Message.Substring(log.Message.IndexOf("[phone:")).Substring(log.Message.Substring(log.Message.IndexOf("[phone:")).IndexOf(":") + 1, log.Message.Substring(log.Message.IndexOf("[phone:")).IndexOf("]") - (log.Message.Substring(log.Message.IndexOf("[phone:")).IndexOf(":") + 1));
                                        comment.Email = log.Message.Substring(log.Message.IndexOf("[mail:")).Substring(log.Message.Substring(log.Message.IndexOf("[mail:")).IndexOf(":") + 1, log.Message.Substring(log.Message.IndexOf("[mail:")).IndexOf("]") - (log.Message.Substring(log.Message.IndexOf("[mail:")).IndexOf(":") + 1));


                                        comment.Subject = log.Message.Substring(log.Message.IndexOf("[subject:")).Substring(log.Message.Substring(log.Message.IndexOf("[subject:")).IndexOf(":") + 1, log.Message.Substring(log.Message.IndexOf("[subject:")).IndexOf("]") - (log.Message.Substring(log.Message.IndexOf("[subject:")).IndexOf(":") + 1));
                                        comment.Detail = log.Message.Substring(log.Message.IndexOf("[message:")).Substring(log.Message.Substring(log.Message.IndexOf("[message:")).IndexOf(":") + 1, log.Message.Substring(log.Message.IndexOf("[message:")).IndexOf("]") - (log.Message.Substring(log.Message.IndexOf("[message:")).IndexOf(":") + 1));


                                        comment.Status = "Chưa xử lý";

                                        comment.History = "";

                                        comment.CreatedAt = log.TimeStamp; comment.CreatedBy = 1;
                                        comment.LastModifiedAt = log.TimeStamp; comment.LastModifiedBy = 1;
                                        comment.Flag = null;


                                        comment.Save();

                                        countUpdate++;
                                        _lastUpdate = log.TimeStamp;
                                    }
                                }

                            }
                            ts.Complete();
                            ts.Dispose();


                        }
                    }
                    iLog.Info("Last update success at: " + DateTime.Now + "; log updated: " + countUpdate.ToString() + "\r\n"); 
                    txtMessage.Text = "Last update success at: " + DateTime.Now + "; log updated: " + countUpdate.ToString() + "\r\n" + txtMessage.Text;

                    //txtLastUpdate.Text = _lastUpdate.ToString();
                //}
                //catch (Exception ex)
                //{
                //    iLog.Info("Last update fail at: " + DateTime.Now.ToString() + ";ex=" + ex.Message + "\r\n"); 
                //    txtMessage.Text = "Last update fail at: " + DateTime.Now.ToString() + ";ex=" + ex.Message + "\r\n" + txtMessage.Text;
                //}
            }
        }

        #endregion


    }
}